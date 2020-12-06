using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLGL_Player
{
    class RLGLCensorFrame : IComparable<RLGLCensorFrame>
    {
        private int timePos;
        private float xPos;
        private float yPos;
        private float xMove;
        private float yMove;
        private bool endFrame;
        private int id;

        public int TimePos { get => timePos; }
        public float XPos { get => xPos; }
        public float YPos { get => yPos; }
        public float XMove { get => xMove; }
        public float YMove { get => yMove; }
        public bool EndFrame { get => endFrame; set => endFrame = value; }
        public int Id { get => id; }

        public RLGLCensorFrame()
        {
            timePos = 0;
            xPos = 0;
            yPos = 0;
            xMove = 0;
            yMove = 0;
            endFrame = true;
            id = -1;
        }

        public RLGLCensorFrame(int id, bool endFrame, int timePos, float xPos, float yPos, float xMove, float yMove)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.xMove = xMove;
            this.yMove = yMove;
            this.endFrame = endFrame;
            this.id = id;
            this.timePos = timePos;
        }

        public RLGLCensorFrame(int id, bool endFrame, int timePos, float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.endFrame = endFrame;
            this.id = id;
            this.timePos = timePos;
            this.xMove = 0;
            this.yMove = 0;
        }

        public RLGLCensorFrame(int id, int timePos)
        {
            this.id = id;
            this.timePos = timePos;

            this.xPos = 0;
            this.yPos = 0;
            this.xMove = 0;
            this.yMove = 0;
            this.endFrame = false;
        }

        public void SetPosition(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public bool CalculateMovement(int nextTimePos, float nextXPos, float nextYPos)
        {
            if(endFrame)
            {
                return false;
            }

            int duration = nextTimePos - timePos;

            xMove = (nextXPos - xPos) / duration;
            yMove = (nextYPos - yPos) / duration;

            return true;
        }

        public void ResetMovement()
        {
            this.xMove = 0.0f;
            this.yMove = 0.0f;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            RLGLCensorFrame frame = (RLGLCensorFrame)obj;

            if(frame == null)
            {
                return false;
            }

            return Equals(frame);
        }

        public override int GetHashCode()
        {
            return id;
        }

        public bool Equals(RLGLCensorFrame frame)
        {
            if(frame == null)
            {
                return false;
            }

            return this.id.Equals(frame.id) && this.TimePos.Equals(frame.TimePos);
        }

        public int CompareTo(RLGLCensorFrame other)
        {
            if(other == null)
            {
                return 1;
            }

            return timePos.CompareTo(other.TimePos);
        }
    }
}
