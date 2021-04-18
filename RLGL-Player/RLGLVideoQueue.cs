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
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
        private long duration;
        private List<Media> media;
        private LibVLC libVLC;

        public long Duration { get => duration; }
        public RLGLEnding Ending { get; set; }

        public RLGLVideoQueue(LibVLC libVLC)
        {
            videos = new List<string>();
            currentVideo = 0;
            loop = 0;
            initLoop = 0;
            this.libVLC = libVLC;
            media = new List<Media>();
        }

        public RLGLVideoQueue(LibVLC libVLC, int loop)
        {
            videos = new List<string>();
            currentVideo = 0;
            this.loop = loop;
            initLoop = loop;
            this.libVLC = libVLC;
            media = new List<Media>();
        }

        //Adds a video at the end of the queue.
        public void AddVideo(string vid)
        {
            videos.Add(vid);
            string ext = Path.GetExtension(vid);
            Media m = null;
            if (ext.Equals(".jpg"))
            {
                m = new Media(libVLC, vid, FromType.FromPath, new string[] { ":image-duration=20" });
            }
            else
            {
                m = new Media(libVLC, vid);
            }

            Task<MediaParsedStatus> parse = m.Parse();
            parse.Wait();

            duration += m.Duration;

            media.Add(m);
        }

        /*
         * Gets the next media and it's path or null if the queue has no media left.
         * Has ability to loop the playlist.
         */ 
        public (Media, string) GetNextVideo()
        {
            if(currentVideo < videos.Count)
            {
                Media vid = media[currentVideo];
                string path = videos[currentVideo];
                currentVideo++;

                if(currentVideo == videos.Count && loop > 0)
                {
                    currentVideo = 0;
                    loop--;
                }

                return (vid, path);
            }

            return (null, "");
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
                    AddVideo(fileReader.ReadString());
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
