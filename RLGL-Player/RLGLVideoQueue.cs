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
using System.Collections.Generic;


namespace RLGL_Player
{
    /*
     * Stores a list of video links and provides the first one.
     */ 
    public class RLGLVideoQueue
    {
        private List<string> videos;
        private int currentVideo;

        public RLGLVideoQueue()
        {
            videos = new List<string>();
            currentVideo = 0;
        }

        //Adds a video at the end of the queue.
        public void AddVideo(string vid)
        {
            videos.Add(vid);
        }

        //Gets the next link or an empty string if the queue has no links left.
        public string GetNextVideo()
        {
            if(currentVideo < videos.Count)
            {
                string vid = videos[currentVideo];
                currentVideo++;

                return vid;
            }

            return "";
        }

        //Returns the number of videos remaining unti the end of the queue.
        public int VideosRemaining()
        {
            return videos.Count - currentVideo;
        }
    }
}
