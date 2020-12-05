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
    public enum RLGLPhase { Green, Red }

    /*
     * The RLGLCurrentMedia class encapsulates relevant working data
     */ 
    class RLGLCurrentMedia
    {
        private string media;
        private DateTime start;
        private TimeSpan end;
        private RLGLPhase currentPhase;
        private float currentCensorX;
        private float currentCensorY;

        //Full path to the current played media-file.
        public string Media { get => media; }
        //The date and time at which the media-file is started.
        public DateTime Start { get => start; set => start = value; }
        //The duration of the last phase.
        public TimeSpan End { get => end; set => end = value; }
        //The currently played phase.
        public RLGLPhase CurrentPhase { get => currentPhase; set => currentPhase = value; }
        /*
         * The relative width of the censorbar in x-dimension. 
         * Note, that only half of this relative width is stored. Expected values are between 0.0f and 1.0f!
         */ 
        public float CurrentCensorX { get => currentCensorX; set => currentCensorX = value; }
        /*
         * The relative height of the censorbar in y-dimension. 
         * Note, that only half of this relative height is stored. Expected values are between 0.0f and 1.0f!
         */
        public float CurrentCensorY { get => currentCensorY; set => currentCensorY = value; }

        public RLGLCurrentMedia(string media, DateTime start, TimeSpan end, RLGLPhase startPhase)
        {
            this.media = media;
            this.start = start;
            this.end = end;
            currentPhase = startPhase;
            currentCensorX = -1.0f;
            currentCensorY = -1.0f;
        }

        //Set the relative width and height of the censorbar to the default values.
        public void ResetCensorDimension()
        {
            currentCensorX = -1.0f;
            currentCensorY = -1.0f;
        }
    }
}
