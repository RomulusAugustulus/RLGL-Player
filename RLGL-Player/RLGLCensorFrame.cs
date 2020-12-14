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

namespace RLGL_Player
{
    /*
     * Representation of a single keyframe for a censorbar.
     */ 
    class RLGLCensorFrame : IComparable<RLGLCensorFrame>
    {
        private int timePos;
        private float xPos;
        private float yPos;
        private float xMove;
        private float yMove;
        private bool endFrame;
        private int id;
        private short censorSize;

        //Position inside the video
        public int TimePos { get => timePos; }
        //Relative position of the censorbar on the x-axis. Expected range: 0.0f - 1.0f
        public float XPos { get => xPos; }
        //Relative position of the censorbar on the y-axis. Expected range: 0.0f - 1.0f
        public float YPos { get => yPos; }
        //Movement of the censorbar on the x-axis to reach the next keyframe.
        public float XMove { get => xMove; }
        //Movement of the censorbar on the y-axis to reach the next keyframe.
        public float YMove { get => yMove; }
        //Flag if there is another frame after this one so that the censorbar gets moved over time.
        public bool EndFrame { get => endFrame; set => endFrame = value; }
        //Id of the censorbar
        public int Id { get => id; }
        /*
         * The size of the censorbar that the current frame should draw.
         * 0 = the default size specified in preferences
         * 1 = small censorbar
         * 2 = medium censorbar
         * 3 = big censorbar
         * 4 = unfair censorbar
         */
        public short CensorSize { get => censorSize; set => censorSize = value; }

        public RLGLCensorFrame()
        {
            timePos = 0;
            xPos = 0;
            yPos = 0;
            xMove = 0;
            yMove = 0;
            endFrame = true;
            id = -1;
            censorSize = 0;
        }

        public RLGLCensorFrame(int id, bool endFrame, int timePos, float xPos, float yPos, float xMove, float yMove, short censorSize)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.xMove = xMove;
            this.yMove = yMove;
            this.endFrame = endFrame;
            this.id = id;
            this.timePos = timePos;
            this.censorSize = censorSize;
        }

        public RLGLCensorFrame(int id, bool endFrame, int timePos, float xPos, float yPos, short censorSize)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.endFrame = endFrame;
            this.id = id;
            this.timePos = timePos;
            this.xMove = 0;
            this.yMove = 0;
            this.censorSize = censorSize;
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
            this.censorSize = 0;
        }

        public void SetPosition(float xPos, float yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        //calculates the movement from the current frames position to the specified position in 1 sec steps
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

        //Set movement back to 0
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

        //RLGLCensorFrames equal each other if their TimePos and Id are the same.
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
