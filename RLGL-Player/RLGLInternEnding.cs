/*
 *  RLGL-Player - plays the famous game red light green light to any selected media.
 *  Copyright (C) 2021  Augustulus
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

namespace RLGL_Player
{
    /*
     * The InternEnding has additional information about the usage in the software.
     */ 
    public class RLGLInternEnding
    {
        public bool Enabled { get; set; }
        public bool Locked { get; set; }
        public int Chance { get; set; }
        public RLGLEnding Ending { get; set; }
        public string EndingName { get; set; }

        public RLGLInternEnding(bool enabled, bool locked, int chance, string endingName, RLGLEnding ending)
        {
            Enabled = enabled;
            Locked = locked;
            Chance = chance;
            Ending = ending;
            EndingName = endingName;
        }
    }
}
