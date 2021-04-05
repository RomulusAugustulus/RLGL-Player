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
     * An EndingPhase holds the information about one phase that can be
     * used in an Ending.
     */
    public class RLGLEndingPhase
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public RLGLPhase Phase { get; set; }
        public string Message { get; set; }
        public int CountdownBegin { get; set; }
        public int CountdownEnd { get; set; }
        public int CountdownStep { get; set; }
    }
}
