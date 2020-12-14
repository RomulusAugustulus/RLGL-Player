/*
 *  RLGL-Player - plays the famous game red light green light to any selected media.
 *  Copyright (C) 2020  Augustulus
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace RLGL_Player
{
    /*
     * Stores all information to draw custom censorbars over a video.
     * 
     */ 
    class RLGLCensorData
    {
        //The current version of the files
        private static ushort CensorDataVersion = 1;

        private string media;
        private TimeSpan duration;
        private Dictionary<int, List<RLGLCensorFrame>> keyframes;
        private List<int> ids;
        private Dictionary<int, Color> editorCensorbarColor;

        //The duration of the corresponding video
        public TimeSpan Duration { get => duration; }
        //The path to the video
        public string Media { get => media; }
        //The user-set colors of each censorbar to different between them in the editor. Editor only!
        public Dictionary<int, Color> EditorCensorbarColor { get => editorCensorbarColor; set => editorCensorbarColor = value; }
        //The ids of all stored censorbars
        public List<int> Ids { get => ids; }
        //All keyframes for the video
        internal Dictionary<int, List<RLGLCensorFrame>> Keyframes { get => keyframes; }

        public RLGLCensorData(string media)
        {
            this.media = media;
            this.duration = TimeSpan.Zero;
            keyframes = new Dictionary<int, List<RLGLCensorFrame>>();
            ids = new List<int>();
            editorCensorbarColor = new Dictionary<int, Color>();
        }

        public void SetDuration(TimeSpan duration)
        {
            if(this.duration == TimeSpan.Zero)
            {
                this.duration = duration;
            }
        }

        //Initialize a new censorbar for this video with set id and color. Returns false if the id is already in use.
        public bool AddNewCensorbar(int id, Color color)
        {
            if(ids.Contains(id))
            {
                return false;
            }

            ids.Add(id);
            keyframes.Add(id, new List<RLGLCensorFrame>());
            editorCensorbarColor.Add(id, color);

            return true;
        }

        /*
         * Adds a new keyframe to the video. If the keyframe already exists, it will override the existing one.
         * Otherwise it will be inserted at the given position.
         */
        public void AddKeyframe(int id, int timePos, float xPos, float yPos, short censorSize)
        {
            if(ids.Contains(id))
            {
                if(keyframes[id].Contains(new RLGLCensorFrame(id, timePos)))
                {
                    UpdateKeyframe(id, timePos, xPos, yPos, censorSize);
                }
                else
                {
                    List<RLGLCensorFrame> frames = keyframes[id];

                    for(int i=0;i<frames.Count;i++)
                    {
                        if(frames[i].TimePos > timePos)
                        {
                            InsertNewKeyframe(i, id, timePos, xPos, yPos, censorSize);
                        }
                    }

                    InsertNewKeyframeAtEnd(id, timePos, xPos, yPos, censorSize);
                }
            }
            else
            {
                ids.Add(id);
                keyframes.Add(id, new List<RLGLCensorFrame>());
                keyframes[id].Add(new RLGLCensorFrame(id, true, timePos, xPos, yPos, censorSize));
            }
        }

        //Updates the size and/or the position of an existing keyframe.
        public void UpdateKeyframe(int id, int timePos, float xPos, float yPos, short censorSize)
        {
            for(int i=0;i<keyframes[id].Count;i++)
            {
                if(keyframes[id][i].Equals(new RLGLCensorFrame(id,timePos)))
                {
                    keyframes[id][i].SetPosition(xPos, yPos);
                    keyframes[id][i].CensorSize = censorSize;
                    break;
                }
            }
        }

        //Updates the endframe-property if the specified frame exists. Returns false if not 
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

        //Returns positions of all active censorbars at the given time
        public Dictionary<int, PointF> GetAllCensorPositions(int timePos)
        {
            Dictionary<int, CensorbarInfo<PointF>> posNSize = GetAllCensorPositionsAndSizes(timePos);
            Dictionary<int, PointF> pos = new Dictionary<int, PointF>();
            
            foreach(int id in posNSize.Keys)
            {
                pos.Add(id, posNSize[id].Position);
            }

            return pos;
        }

        //Returns positions and sizes of all active censorbars at a given time
        public Dictionary<int, CensorbarInfo<PointF>> GetAllCensorPositionsAndSizes(float timePos)
        {
            Dictionary<int, CensorbarInfo<PointF>> positions = new Dictionary<int, CensorbarInfo<PointF>>();

            for (int i = 0; i < ids.Count; i++)
            {
                CensorbarInfo<PointF> posNSize = GetCensorbarPositionAndSize(ids[i], timePos);

                if (posNSize != null)
                {
                    positions.Add(ids[i], posNSize);
                }
            }

            return positions;
        }

        //Returns positions and sizes of all active censorbars at a given time
        public Dictionary<int, CensorbarInfo<PointF>> GetAllCensorPositionsAndSizes(int timePos)
        {
            return GetAllCensorPositionsAndSizes((float)timePos);
        }

        //Get the position and size of a censorbar at a given time. Returns null if there is no censorbar at the given time.
        public CensorbarInfo<PointF> GetCensorbarPositionAndSize(int id, float timePos)
        {
            if (ids.Contains(id))
            {
                int foundPos = keyframes[id].BinarySearch(new RLGLCensorFrame(id, (int)timePos));

                if (foundPos >= 0)
                {
                    RLGLCensorFrame frame = keyframes[id][foundPos];
                    return new CensorbarInfo<PointF>(id, frame.CensorSize, new PointF(frame.XPos, frame.YPos));
                }
                else
                {
                    foundPos = ~foundPos;

                    if (foundPos != 0)
                    {
                        RLGLCensorFrame frame = keyframes[id][foundPos - 1];

                        if (!frame.EndFrame)
                        {
                            float steps = timePos - frame.TimePos;
                            return new CensorbarInfo<PointF>(id, frame.CensorSize, new PointF(frame.XPos + steps * frame.XMove, frame.YPos + steps * frame.YMove));
                        }
                    }
                }
            }

            return null;
        }

        //Insert a new keyframe between existing ones.
        private void InsertNewKeyframe(int pos, int id, int timePos, float xPos, float yPos, short censorSize)
        {
            keyframes[id].Insert(pos, new RLGLCensorFrame(id, false, timePos, xPos, yPos, censorSize));
            RLGLCensorFrame frame = keyframes[id][pos + 1];
            keyframes[id][pos].CalculateMovement(frame.TimePos, frame.XPos, frame.YPos);
        }

        //insert a new keyframe at the end of the list of already inserted keyframes.
        private void InsertNewKeyframeAtEnd(int id, int timePos, float xPos, float yPos, short censorSize)
        {
            keyframes[id].Add(new RLGLCensorFrame(id, true, timePos, xPos, yPos, censorSize));

            if(keyframes[id].Count > 1)
            {
                int oldLast = keyframes[id].Count - 2;
                keyframes[id][oldLast].EndFrame = false;
                keyframes[id][oldLast].CalculateMovement(timePos, xPos, yPos);
            }
        }

        //Returns the keyframe that matches the given time or the next one in the future. If there is no future keyframe null is returned.
        public RLGLCensorFrame GetNextBiggerKeyframe(int id, int timePos)
        {
            if (ids.Contains(id))
            {
                int foundPos = keyframes[id].BinarySearch(new RLGLCensorFrame(id, timePos));

                if (foundPos >= 0)
                {
                    return keyframes[id][foundPos];                   
                }
                else
                {
                    foundPos = ~foundPos;

                    if (foundPos < keyframes[id].Count)
                    {
                        return keyframes[id][foundPos];
                    }
                }
            }

            return null;
        }

        /*
         * Save this RLGLCensorData to a file
         */ 
        public void SaveToFile()
        {
            string path = Path.GetDirectoryName(media);
            string fileName = Path.GetFileNameWithoutExtension(media);

            BinaryWriter fileWriter = new BinaryWriter(File.OpenWrite(Path.Combine(path, fileName) + ".cb"));

            //Version of this file for backwards-compatibility
            fileWriter.Write((ushort)1);
            //Duration of the video
            fileWriter.Write((double)duration.TotalSeconds);
            //Number of censorbars
            fileWriter.Write((int)ids.Count);
            
            //Save ids
            for(int i=0;i<ids.Count;i++)
            {
                fileWriter.Write((int)ids[i]);
            }

            //Save censorbar colors (only relevant for editor)
            foreach(int id in editorCensorbarColor.Keys)
            {
                Color col = editorCensorbarColor[id];
                //Id of the color
                fileWriter.Write((int)id);
                //Color
                fileWriter.Write((int)col.ToArgb());
            }

            //Save keyframes
            foreach(int id in keyframes.Keys)
            {
                List<RLGLCensorFrame> frames = keyframes[id];
                //Id of the following frames
                fileWriter.Write((int)id);
                //Number of frames
                fileWriter.Write((int)frames.Count);

                //Single frames
                for(int i=0;i<frames.Count;i++)
                {
                    RLGLCensorFrame f = frames[i];
                    //Id of the frame
                    fileWriter.Write((int)f.Id);
                    //TimePos of the frame
                    fileWriter.Write((int)f.TimePos);
                    //Is this an endframe?
                    fileWriter.Write((bool)f.EndFrame);
                    //Size of the censorbar
                    fileWriter.Write((short)f.CensorSize);
                    //Relative position of the censorbar
                    fileWriter.Write((float)f.XPos);
                    fileWriter.Write((float)f.YPos);
                    //Relative movement-direction of the censorbar
                    fileWriter.Write((float)f.XMove);
                    fileWriter.Write((float)f.YMove);
                }
            }

            fileWriter.Close();
        }

        /*
         * Read censordata from a file and creates a new RLGLCensorData-object.
         * In case that the file is corrupted or not existant null will be returned.
         */
        public static RLGLCensorData ReadFromFile(string file)
        {
            RLGLCensorData rlglCensorData = null;

            try
            {
                BinaryReader fileReader = new BinaryReader(File.OpenRead(Path.ChangeExtension(file, "cb")));

                ushort versionOfFile = fileReader.ReadUInt16();

                if (versionOfFile == RLGLCensorData.CensorDataVersion)
                {
                    //Read the duration of the media
                    double seconds = fileReader.ReadDouble();

                    //create our censorData-Object
                    rlglCensorData = new RLGLCensorData(file);
                    rlglCensorData.SetDuration(TimeSpan.FromSeconds(seconds));

                    //get the number of censorbars
                    int numberOfCensorbars = fileReader.ReadInt32();

                    //read ids of the censorbars
                    List<int> savedIds = new List<int>();

                    for (int i = 0; i < numberOfCensorbars; i++)
                    {
                        savedIds.Add(fileReader.ReadInt32());
                    }

                    rlglCensorData.SetIdList(savedIds);

                    //read the colors for the editor
                    Dictionary<int, Color> editorColors = new Dictionary<int, Color>();

                    for (int i = 0; i < numberOfCensorbars; i++)
                    {
                        int id = fileReader.ReadInt32();
                        int colCode = fileReader.ReadInt32();

                        editorColors.Add(id, Color.FromArgb(colCode));
                    }

                    rlglCensorData.EditorCensorbarColor = editorColors;

                    //read keyframes
                    Dictionary<int, List<RLGLCensorFrame>> savedKeyframes = new Dictionary<int, List<RLGLCensorFrame>>();

                    for (int i = 0; i < numberOfCensorbars; i++)
                    {
                        int id = fileReader.ReadInt32();
                        int numberOfFrames = fileReader.ReadInt32();

                        List<RLGLCensorFrame> frames = new List<RLGLCensorFrame>();

                        for (int j = 0; j < numberOfFrames; j++)
                        {
                            int fId = fileReader.ReadInt32();
                            int fTimePos = fileReader.ReadInt32();
                            bool fEndFrame = fileReader.ReadBoolean();
                            short censorSize = fileReader.ReadInt16();
                            float fXPos = fileReader.ReadSingle();
                            float fYPos = fileReader.ReadSingle();
                            float fXMove = fileReader.ReadSingle();
                            float fYMove = fileReader.ReadSingle();

                            frames.Add(new RLGLCensorFrame(fId, fEndFrame, fTimePos, fXPos, fYPos, fXMove, fYMove, censorSize));
                        }

                        savedKeyframes.Add(id, frames);
                    }

                    rlglCensorData.SetKeyframes(savedKeyframes);
                }
                else if (versionOfFile < RLGLCensorData.CensorDataVersion)
                {
                    //Backwards compatibility. Not used at the moment
                }

                fileReader.Close();
            }
            catch(Exception)
            {
                //something with the file went wrong, so we don't have any data
                return null;
            }

            return rlglCensorData;
        }

        private void SetIdList(List<int> ids)
        {
            this.ids = ids;
        }

        private void SetKeyframes(Dictionary<int, List<RLGLCensorFrame>> keyframes)
        {
            this.keyframes = keyframes;
        }

        /*
         * Remove an existing id from the dataset.
         * Deletes all keyframes that are attached to this id.
         * Returns false if no matching id is found.
         */ 
        public bool RemoveId(int id)
        {
            if(ids.Contains(id))
            {
                ids.Remove(id);
                keyframes.Remove(id);
                editorCensorbarColor.Remove(id);

                return true;
            }
                        
            return false;
        }
    }

    /*
     * Capsulation of the position and size of a censorbar.
     */ 
    public class CensorbarInfo<T>
    {
        private T position;
        private short size;
        private int id;
        public T Position { get => position; }
        public short Size { get => size; }
        public int Id { get => id; }

        public CensorbarInfo(int id, short size, T position)
        {
            this.id = id;
            this.size = size;
            this.position = position;
        }                
    }
}
