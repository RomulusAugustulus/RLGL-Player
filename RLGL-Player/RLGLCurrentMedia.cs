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
using LibVLCSharp.Shared;

namespace RLGL_Player
{   
    public enum RLGLPhase { Green, Red, Edge, Countdown, Ruin }

    /*
     * The RLGLCurrentMedia class encapsulates relevant working data
     */ 
    class RLGLCurrentMedia
    {
        private Media media;
        private string path;
        private RLGLPhase currentPhase;
        private Dictionary<int, PointF> currentCensor;

        //Full path to the current played media-file.
        public Media Media { get => media; }
        //The currently played phase.
        public RLGLPhase CurrentPhase { get => currentPhase; set => currentPhase = value; }
        public string Path { get => path; }

        public RLGLCurrentMedia(Media media, string path, RLGLPhase startPhase)
        {
            this.media = media;
            this.path = path;
            currentPhase = startPhase;
            currentCensor = new Dictionary<int, PointF>();
        }

        //Set the relative dimensions of the censorbars to their default values.
        public void ResetCensorDimension()
        {
            currentCensor.Clear();
        }

        public PointF GetCensorDimension(int id)
        {
            PointF value;
            if (currentCensor.TryGetValue(id, out value))
            {
                return value;
            }

            return new PointF(-1.0f, -1.0f);
        }

        public void SetCensorDimension(int id, PointF dim)
        {
            if(currentCensor.ContainsKey(id))
            {
                currentCensor[id] = dim;
            }
            else
            {
                currentCensor.Add(id, dim);
            }
        }
    }
}
