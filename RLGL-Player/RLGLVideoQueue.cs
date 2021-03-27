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
        private static ushort QueueVersion = 1;
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

        //Save a video queue as a file. Stores also the user preferences used with this queue.
        public void SaveVideoQueue(string filename, RLGLPreferences prefs)
        {
            BinaryWriter fileWriter = new BinaryWriter(File.OpenWrite(filename));

            fileWriter.Write(QueueVersion);
            fileWriter.Write(initLoop);
            fileWriter.Write(videos.Count);

            for (int i = 0; i < videos.Count; i++)
            {
                fileWriter.Write(videos[i]);
            }

            fileWriter.Write(prefs.MinGreen);
            fileWriter.Write(prefs.MaxGreen);
            fileWriter.Write(prefs.MinRed);
            fileWriter.Write(prefs.MaxRed);
            fileWriter.Write(prefs.Edging);
            fileWriter.Write(prefs.EdgingWarmup);
            fileWriter.Write(prefs.MinEdge);
            fileWriter.Write(prefs.MaxEdge);
            fileWriter.Write(prefs.EdgeChance);
            fileWriter.Write(prefs.GreenAfterEdge);
            fileWriter.Write((int)prefs.Ending);
            fileWriter.Write(prefs.Metronome);
            fileWriter.Write(prefs.MinBpm);
            fileWriter.Write(prefs.MaxBpm);
            fileWriter.Write(prefs.MetronomeChance);
            fileWriter.Write(prefs.Censoring);
            fileWriter.Write((int)prefs.CensorType);
            fileWriter.Write((int)prefs.CensorSize);
            fileWriter.Write(prefs.CensorOnlyGreen);
            fileWriter.Write(prefs.CensorChance);

            fileWriter.Close();
        }

        /*
         * Load a queue from a file. Returns a tuple of the preferences stored in this queue and 
         * a flag showing if loading the queue was successful!
         */ 
        public (bool, RLGLPreferences) LoadVideoQueue(string filename, RLGLPreferences prefs)
        {
            int minGreen = 0;
            int maxGreen = 0;
            int minRed = 0;
            int maxRed = 0;
            bool edging = false;
            int edgingWarmup = 0;
            int minEdge = 0;
            int maxEdge = 0;
            int edgeChance = 1;
            bool greenAfterEdge = false;
            RLGLEnding ending = RLGLEnding.AlwaysRed;
            bool metronome = false;
            int minBpm = 0;
            int maxBpm = 0;
            int metronomeChance = 1;
            bool censor = false;
            RLGLCensorType censorType = RLGLCensorType.Color;
            RLGLCensorSize censorSize = RLGLCensorSize.Medium;
            bool censorOnlyGreen = false;
            int censorChance = 1;

            try
            {
                BinaryReader fileReader = new BinaryReader(File.OpenRead(filename));

                ushort version = fileReader.ReadUInt16();

                if(version == QueueVersion)
                {
                    initLoop = fileReader.ReadInt32();
                    loop = initLoop;
                    int numVid = fileReader.ReadInt32();

                    for(int i=0;i<numVid;i++)
                    {
                        videos.Add(fileReader.ReadString());
                    }

                    minGreen = fileReader.ReadInt32();
                    maxGreen = fileReader.ReadInt32();
                    minRed = fileReader.ReadInt32();
                    maxRed = fileReader.ReadInt32();
                    edging = fileReader.ReadBoolean();
                    edgingWarmup = fileReader.ReadInt32();
                    minEdge = fileReader.ReadInt32();
                    maxEdge = fileReader.ReadInt32();
                    edgeChance = fileReader.ReadInt32();
                    greenAfterEdge = fileReader.ReadBoolean();
                    ending = (RLGLEnding)fileReader.ReadInt32();
                    metronome = fileReader.ReadBoolean();
                    minBpm = fileReader.ReadInt32();
                    maxBpm = fileReader.ReadInt32();
                    metronomeChance = fileReader.ReadInt32();
                    censor = fileReader.ReadBoolean();
                    censorType = (RLGLCensorType)fileReader.ReadInt32();
                    censorSize = (RLGLCensorSize)fileReader.ReadInt32();
                    censorOnlyGreen = fileReader.ReadBoolean();
                    censorChance = fileReader.ReadInt32();
                }
                else
                {
                    //Handle older version. This is not used at the moment!
                }

                fileReader.Close();
            }
            catch(Exception)
            {
                return (false, prefs);
            }

            return (true, new RLGLPreferences(minGreen,maxGreen,minRed,maxRed,ending,metronome,minBpm,maxBpm,metronomeChance,
                prefs.GreenLightColor,prefs.RedLightColor,censor,censorType,censorSize,censorChance,censorOnlyGreen,
                prefs.CensorColor,prefs.CensorPath,prefs.LeftBorder,prefs.RightBorder,prefs.TopBorder,prefs.BottomBorder,
                edging,edgingWarmup,minEdge,maxEdge,edgeChance,greenAfterEdge,prefs.EdgeColor));
        }

        public (int, List<string>) GetRLGLVideoQueue()
        {
            return (initLoop, videos);
        }
    }
}
