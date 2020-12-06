using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RLGL_Player
{
    class RLGLCensorData
    {
        private TimeSpan duration;
        private List<List<RLGLCensorFrame>> keyframes;
        private List<int> ids;

        public RLGLCensorData(TimeSpan duration)
        {
            this.duration = duration;
            keyframes = new List<List<RLGLCensorFrame>>();
            ids = new List<int>();
        }

        public void AddKeyframe(int id, int timePos, float xPos, float yPos)
        {
            if(ids.Contains(id))
            {
                if(keyframes[id].Contains(new RLGLCensorFrame(id, timePos)))
                {
                    UpdateKeyframe(id, timePos, xPos, yPos);
                }
                else
                {
                    List<RLGLCensorFrame> frames = keyframes[id];

                    for(int i=0;i<frames.Count;i++)
                    {
                        if(frames[i].TimePos > timePos)
                        {
                            InsertNewKeyframe(i, id, timePos, xPos, yPos);
                        }
                    }

                    InsertNewKeyframeAtEnd(id, timePos, xPos, yPos);
                }
            }
            else
            {
                ids.Add(id);
                keyframes.Add(new List<RLGLCensorFrame>());
                keyframes[id].Add(new RLGLCensorFrame(id, true, timePos, xPos, yPos));
            }
        }

        public void UpdateKeyframe(int id, int timePos, float xPos, float yPos)
        {
            for(int i=0;i<keyframes[id].Count;i++)
            {
                if(keyframes[id][i].Equals(new RLGLCensorFrame(id,timePos)))
                {
                    keyframes[id][i].SetPosition(xPos, yPos);
                    break;
                }
            }
        }

        public bool UpdateEndFrame(int id, int timePos, bool endFrame)
        {
            if(ids.Contains(id))
            {
                RLGLCensorFrame dummyFrame = new RLGLCensorFrame(id, timePos);
                if (keyframes[id].Contains(dummyFrame))
                {
                    for (int i = 0; i < keyframes[id].Count; i++)
                    {
                        if (keyframes[id][i].Equals(dummyFrame))
                        {
                            keyframes[id][i].EndFrame = endFrame;

                            if (!endFrame && i + 1 < keyframes[id].Count)
                            {
                                RLGLCensorFrame nextFrame = keyframes[id][i + 1];
                                keyframes[id][i].CalculateMovement(nextFrame.TimePos, nextFrame.XPos, nextFrame.YPos);
                            }
                            else if(endFrame)
                            {
                                keyframes[id][i].ResetMovement();
                            }

                            if (i - 1 > -1)
                            {
                                if (!keyframes[id][i - 1].EndFrame)
                                {
                                    keyframes[id][i - 1].CalculateMovement(timePos, keyframes[id][i].XPos, keyframes[id][i].YPos);
                                }
                            }

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public PointF GetCensorbarPosition(int id, int timePos)
        {
            if(ids.Contains(id))
            {
                int foundPos = keyframes[id].BinarySearch(new RLGLCensorFrame(id, timePos));

                if(foundPos >= 0)
                {
                    RLGLCensorFrame frame = keyframes[id][foundPos];
                    return new PointF(frame.XPos, frame.YPos);
                }
                else
                {
                    foundPos = ~foundPos;

                    if(foundPos != 0)
                    {
                        RLGLCensorFrame frame = keyframes[id][foundPos - 1];

                        if (!frame.EndFrame)
                        {
                            int steps = timePos - frame.TimePos;
                            return new PointF(steps * frame.XMove, steps * frame.YMove);
                        }
                    }                    
                }
            }

            return new PointF(-1, -1);
        }

        private void InsertNewKeyframe(int pos, int id, int timePos, float xPos, float yPos)
        {
            keyframes[id].Insert(pos, new RLGLCensorFrame(id, false, timePos, xPos, yPos));
            RLGLCensorFrame frame = keyframes[id][pos + 1];
            keyframes[id][pos].CalculateMovement(frame.TimePos, frame.XPos, frame.YPos);
        }

        private void InsertNewKeyframeAtEnd(int id, int timePos, float xPos, float yPos)
        {
            keyframes[id].Add(new RLGLCensorFrame(id, true, timePos, xPos, yPos));

            if(keyframes[id].Count > 1)
            {
                int oldLast = keyframes[id].Count - 2;
                keyframes[id][oldLast].EndFrame = false;
                keyframes[id][oldLast].CalculateMovement(timePos, xPos, yPos);
            }
        }
    }
}
