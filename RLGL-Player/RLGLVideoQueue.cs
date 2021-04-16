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
using System.IO;

namespace RLGL_Player
{
    /*
     * Stores a list of video links and provides the first one.
     */ 
    public class RLGLVideoQueue
    {
        private static ushort QueueVersion = 3;
        private List<string> videos;
        private int currentVideo;
        private int loop;
        private int initLoop;
        public RLGLVideoQueue()
        {
            videos = new List<string>();
            currentVideo = 0;
            loop = 0;
            initLoop = 0;
        }

        public RLGLVideoQueue(int loop)
        {
            videos = new List<string>();
            currentVideo = 0;
            this.loop = loop;
            initLoop = loop;
        }

        //Adds a video at the end of the queue.
        public void AddVideo(string vid)
        {
            videos.Add(vid);
        }

        /*
         * Gets the next link or an empty string if the queue has no links left.
         * Has ability to loop the playlist.
         */ 
        public string GetNextVideo()
        {
            if(currentVideo < videos.Count)
            {
                string vid = videos[currentVideo];
                currentVideo++;

                if(currentVideo == videos.Count && loop > 0)
                {
                    currentVideo = 0;
                    loop--;
                }

                return vid;
            }

            return "";
        }

        //Returns the number of videos remaining until the end of the queue.
        public int VideosRemaining()
        {
            return videos.Count - currentVideo;
        }

        //Set the queue to the end.
        public void CancelQueue()
        {
            loop = 0;
            currentVideo = videos.Count;
        }

        //Save a video queue as a file.
        public void SaveVideoQueue(string filename)
        {
            BinaryWriter fileWriter = new BinaryWriter(File.OpenWrite(filename));

            fileWriter.Write(QueueVersion);
            fileWriter.Write(initLoop);
            fileWriter.Write(videos.Count);

            for (int i = 0; i < videos.Count; i++)
            {
                fileWriter.Write(videos[i]);
            }

            fileWriter.Close();
        }

        /*
         * Load a queue from a file. Returns true if the queue was loaded successfully and adds a message indicating problems.
         */ 
        public (bool, string) LoadVideoQueue(string filename)
        {
            string message = "";
            try
            {
                BinaryReader fileReader = new BinaryReader(File.OpenRead(filename));

                ushort version = fileReader.ReadUInt16();
                initLoop = fileReader.ReadInt32();
                loop = initLoop;
                int numVid = fileReader.ReadInt32();

                for (int i = 0; i < numVid; i++)
                {
                    videos.Add(fileReader.ReadString());
                }
                
                if (version < QueueVersion)
                {
                    message = "Recognized an older playlist version! Stored preferences inside playlists are no longer supported and will be ignored.";
                }
                
                fileReader.Close();
            }
            catch(Exception)
            {
                message = "Failed to load the playlist.";
                return (false, message);
            }

            return (true, message);
        }

        public (int, List<string>) GetRLGLVideoQueue()
        {
            return (initLoop, videos);
        }
    }
}
