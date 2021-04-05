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
using System.Collections.Generic;
using System.IO;

namespace RLGL_Player
{
    /*
     * An Ending is a collection of different phases that will be played
     * one after another.
     */ 
    public class RLGLEnding
    {
        private const ushort endingVersion = 1;
        private int duration;
        private List<RLGLEndingPhase> endingPhases;
        private int currentPos;
        private string endingName;

        public int Duration { get => duration; }
        public string EndingName { get => endingName; }

        public RLGLEnding(string endingName)
        {
            this.endingName = endingName;
            duration = 0;
            currentPos = 0;
            endingPhases = new List<RLGLEndingPhase>();
        }

        public void AddPhase(RLGLEndingPhase phase)
        {
            endingPhases.Add(phase);
            duration += phase.Duration;
        }

        public RLGLEndingPhase GetNextPhase()
        {
            RLGLEndingPhase p = null;

            if (currentPos < endingPhases.Count)
            {
                p = endingPhases[currentPos];
                currentPos++;
            }

            return p;
        }

        public void ResetPhasePointer()
        {
            currentPos = 0;
        }

        public List<RLGLEndingPhase> GetAllPhases()
        {
            return endingPhases;
        }

        public void SaveRLGLEnding()
        {
            BinaryWriter endingWriter = new BinaryWriter(File.Open(Directory.GetCurrentDirectory() + "\\Endings\\" + endingName + ".ending", FileMode.OpenOrCreate));

            endingWriter.Write(endingVersion);
            endingWriter.Write(duration);
            endingWriter.Write(endingName);
            endingWriter.Write(endingPhases.Count);
            for(int i=0;i<endingPhases.Count;i++)
            {
                endingWriter.Write(endingPhases[i].Name);
                endingWriter.Write(endingPhases[i].Duration);
                endingWriter.Write(endingPhases[i].Message);
                endingWriter.Write((int)endingPhases[i].Phase);
                endingWriter.Write(endingPhases[i].CountdownBegin);
                endingWriter.Write(endingPhases[i].CountdownEnd);
                endingWriter.Write(endingPhases[i].CountdownStep);
            }

            endingWriter.Close();
        }

        public void LoadRLGLEnding()
        {
            BinaryReader endingReader = new BinaryReader(File.OpenRead(endingName));

            ushort version = endingReader.ReadUInt16();

            if(version == endingVersion)
            {
                duration = endingReader.ReadInt32();
                endingName = endingReader.ReadString();
                int phaseCount = endingReader.ReadInt32();
                for(int i=0;i<phaseCount;i++)
                {
                    RLGLEndingPhase p = new RLGLEndingPhase();
                    p.Name = endingReader.ReadString();
                    p.Duration = endingReader.ReadInt32();
                    p.Message = endingReader.ReadString();
                    p.Phase = (RLGLPhase)endingReader.ReadInt32();
                    p.CountdownBegin = endingReader.ReadInt32();
                    p.CountdownEnd = endingReader.ReadInt32();
                    p.CountdownStep = endingReader.ReadInt32();
                    endingPhases.Add(p);
                }

                endingReader.Close();
            }
            else
            {
                LoadLegacyVersion(endingReader, version);
            }
        }

        private void LoadLegacyVersion(BinaryReader endingReader, ushort version)
        {
            //Do nothing there are no legacy versions at the moment.
        }
    }
}
