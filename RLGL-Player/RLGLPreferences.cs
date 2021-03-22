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

using System.Text;
using System.Drawing;
using System.IO;

namespace RLGL_Player
{
    public enum RLGLEnding { AlwaysGreen, AlwaysRed, Random }
    public enum RLGLCensorType { Color, Image }
    public enum RLGLCensorSize { Small, Medium, Big, Unfair }

    /*
     * RLGLPreferences handles all actions that are related to the user-settings,
     * like save and load them to/from disc or distribute them to the different forms.  
     */ 
    class RLGLPreferences
    {
        //The current version of the file. Used to preserve backwards-compatibility.
        private string preferencesFileVersion = "v.3";
        private int minGreen;
        private int maxGreen;
        private int minRed;
        private int maxRed;
        private RLGLEnding ending;
        private bool metronome;
        private int minBpm;
        private int maxBpm;
        private int metronomePossibility;
        private bool censoring;
        private RLGLCensorType censorType;
        private RLGLCensorSize censorSize;
        private int censorProbability;
        private string censorPath;
        private Color greenLightColor;
        private Color redLightColor;
        private Color censorColor;
        private int leftBorder;
        private int rightBorder;
        private int topBorder;
        private int bottomBorder;
        private bool edging;
        private int edgingWarmup;
        private int minEdge;
        private int maxEdge;
        private int edgeChance;
        private bool greenAfterEdge;
        private Color edgeColor;

        //Minimum number of seconds a green phase will last.
        public int MinGreen { get => minGreen; }
        //Maximum number of seconds a green phase will last.
        public int MaxGreen { get => maxGreen; }
        //Minimum number of seconds a red phase will last.
        public int MinRed { get => minRed; }
        //Maximum number of seconds a red phase will last.
        public int MaxRed { get => maxRed; }
        //Gets at which phase the video will end.
        public RLGLEnding Ending { get => ending; }
        //The color displayed while at a green phase.
        public Color GreenLightColor { get => greenLightColor; }
        //The color displayed while at a red phase.
        public Color RedLightColor { get => redLightColor; }
        //Getss how likely a metronome will be played at green phase.
        public int MetronomePossibility { get => metronomePossibility; }
        //The fastes speed the metronome will play in beats per minute.
        public int MaxBpm { get => maxBpm; }
        //The slowest speed the metronome will play in beats per minute.
        public int MinBpm { get => minBpm; }
        //Gets if a metronome can be used.
        public bool Metronome { get => metronome; }
        //Gets if censorbars may block parts of the played media.
        public bool Censoring { get => censoring; }
        //Gets the type of the censorbars.
        public RLGLCensorType CensorType { get => censorType; }
        //Gets the preferred size of the censorbars.
        public RLGLCensorSize CensorSize { get => censorSize; }
        //Gets how likely censorbars will appear.
        public int CensorProbability { get => censorProbability; }
        //Gets the color of the censorbars.
        public Color CensorColor { get => censorColor; }
        //Gets the path where the images are stored, that will censor the played media.
        public string CensorPath { get => censorPath; }
        //Gets the percentage of the left border.
        public int LeftBorder { get => leftBorder; }
        //Gets the percentage of the right border.
        public int RightBorder { get => rightBorder; }
        //Gets the percentage of the top border.
        public int TopBorder { get => topBorder; }
        //Gets the percentage of the bottom border.
        public int BottomBorder { get => bottomBorder; }
        //Gets if edging phases appear in a session.
        public bool Edging { get => edging; }
        //Gets how many seconds a session will run before edge phases might appear.
        public int EdgingWarmup { get => edgingWarmup; }
        //Gets the minimal duration of an edge phase.
        public int MinEdge { get => minEdge; }
        //Gets the maximal duration of an edge phase.
        public int MaxEdge { get => maxEdge; }
        //Gets the chance that a green phase will end in an edge phase.
        public int EdgeChance { get => edgeChance; }
        //Gets if directly after an edge phase another green phase can appear.
        public bool GreenAfterEdge { get => greenAfterEdge; }
        //Gets the color of the edge phases.
        public Color EdgeColor { get => edgeColor; }

        public RLGLPreferences()
        {
            minGreen = 10;
            maxGreen = 10;
            minRed = 10;
            maxRed = 10;
            ending = RLGLEnding.AlwaysGreen;
            greenLightColor = Color.FromArgb(255, 0, 255, 0);
            redLightColor = Color.FromArgb(255, 255, 0, 0);
            metronome = true;
            minBpm = 10;
            maxBpm = 10;
            metronomePossibility = 5;
            censoring = false;
            censorType = RLGLCensorType.Color;
            censorSize = RLGLCensorSize.Medium;
            censorProbability = 5;
            censorColor = Color.FromArgb(255, 0, 0, 0);
            censorPath = "";
            leftBorder = 100;
            rightBorder = 100;
            topBorder = 100;
            bottomBorder = 100;
            edging = false;
            edgingWarmup = 60;
            minEdge = 10;
            maxEdge = 10;
            edgeChance = 5;
            greenAfterEdge = false;
            edgeColor = Color.FromArgb(255, 0, 0, 255);
        }

        public RLGLPreferences(int minGreen, int maxGreen, int minRed, int maxRed, 
                                RLGLEnding ending, bool metronome, int minBpm, int maxBpm, 
                                int metronomePossibility, Color greenLightColor, Color redLightColor,
                                bool censoring, RLGLCensorType censorType, RLGLCensorSize censorSize,
                                int censorProbability, Color censorColor, string censorPath,
                                int leftBorder, int rightBorder, int topBorder, int bottomBorder,
                                bool edging, int edgingWarmup, int minEdge, int maxEdge, int edgeChance,
                                bool greenAfterEdge, Color edgeColor)
        {
            this.minGreen = minGreen;
            this.maxGreen = maxGreen;
            this.minRed = minRed;
            this.maxRed = maxRed;
            this.ending = ending;
            this.metronome = metronome;
            this.minBpm = minBpm;
            this.maxBpm = maxBpm;
            this.metronomePossibility = metronomePossibility;
            this.greenLightColor = greenLightColor;
            this.redLightColor = redLightColor;
            this.censoring = censoring;
            this.censorType = censorType;
            this.censorSize = censorSize;
            this.censorProbability = censorProbability;
            this.censorColor = censorColor;
            this.censorPath = censorPath;
            this.leftBorder = leftBorder;
            this.rightBorder = rightBorder;
            this.topBorder = topBorder;
            this.bottomBorder = bottomBorder;
            this.edging = edging;
            this.edgingWarmup = edgingWarmup;
            this.minEdge = minEdge;
            this.maxEdge = maxEdge;
            this.edgeChance = edgeChance;
            this.greenAfterEdge = greenAfterEdge;
            this.edgeColor = edgeColor;
        }

        //Sets the controls of a PreferencesDlg object to the currently stored preferences. 
        public void LoadPreferences(PreferencesDlg prefDlg)
        {
            prefDlg.NUD_MaxGreen.Value = maxGreen;
            prefDlg.NUD_MaxRed.Value = maxRed;
            prefDlg.NUD_MinGreen.Value = minGreen;
            prefDlg.NUD_MinRed.Value = minRed;
            prefDlg.RB_EndingGreen.Checked = false;
            prefDlg.RB_EndingRandom.Checked = false;
            prefDlg.RB_EndingRed.Checked = false;

            switch(ending)
            {
                case RLGLEnding.AlwaysGreen:
                    prefDlg.RB_EndingGreen.Checked = true;
                    break;

                case RLGLEnding.AlwaysRed:
                    prefDlg.RB_EndingRed.Checked = true;
                    break;

                case RLGLEnding.Random:
                    prefDlg.RB_EndingRandom.Checked = true;
                    break;
            }

            prefDlg.CB_Metronome.Checked = metronome;
            prefDlg.NUD_MinMetronome.Value = minBpm;
            prefDlg.NUD_MaxMetronome.Value = maxBpm;
            prefDlg.TB_MetronomeChance.Value = metronomePossibility;

            prefDlg.NUD_MaxMetronome.Enabled = metronome;
            prefDlg.NUD_MinMetronome.Enabled = metronome;
            prefDlg.TB_MetronomeChance.Enabled = metronome;           

            prefDlg.P_GreenLightColor.BackColor = greenLightColor;
            prefDlg.P_RedLightColor.BackColor = redLightColor;
            prefDlg.P_EdgeLightColor.BackColor = edgeColor;
            prefDlg.P_CensorColor.BackColor = censorColor;
            prefDlg.TBox_CensorPath.Text = censorPath;

            prefDlg.CB_Censoring.Checked = censoring;
            prefDlg.COMB_CensorSize.SelectedIndex = (int)censorSize;
            prefDlg.COMB_CensorType.SelectedIndex = (int)censorType;
            prefDlg.TB_CensorProbability.Value = censorProbability;

            prefDlg.COMB_CensorType.Enabled = censoring;
            prefDlg.COMB_CensorSize.Enabled = censoring;
            prefDlg.TB_CensorProbability.Enabled = censoring;

            prefDlg.NUD_LeftBorder.Value = leftBorder;
            prefDlg.NUD_RightBorder.Value = rightBorder;
            prefDlg.NUD_TopBorder.Value = topBorder;
            prefDlg.NUD_BottomBorder.Value = bottomBorder;

            prefDlg.CB_EdgePhase.Checked = edging;
            prefDlg.NUD_EdgeWarmup.Value = edgingWarmup;
            prefDlg.NUD_MinEdge.Value = minEdge;
            prefDlg.NUD_MaxEdge.Value = maxEdge;
            prefDlg.TB_EdgeChance.Value = edgeChance;
            prefDlg.CB_AllowGreenLight.Checked = greenAfterEdge;

            prefDlg.NUD_EdgeWarmup.Enabled = edging;
            prefDlg.NUD_MinEdge.Enabled = edging;
            prefDlg.NUD_MaxEdge.Enabled = edging;
            prefDlg.TB_EdgeChance.Enabled = edging;
            prefDlg.CB_AllowGreenLight.Enabled = edging;
        }

        //Gets the values from the controls of a PreferencesDlg object and stores them locally.
        public void SavePreferences(PreferencesDlg prefDlg)
        {
            maxGreen = (int)prefDlg.NUD_MaxGreen.Value;
            maxRed = (int)prefDlg.NUD_MaxRed.Value;
            minGreen = (int)prefDlg.NUD_MinGreen.Value;
            minRed = (int)prefDlg.NUD_MinRed.Value;
            
            if(prefDlg.RB_EndingGreen.Checked)
            {
                ending = RLGLEnding.AlwaysGreen;
            }

            if(prefDlg.RB_EndingRandom.Checked)
            {
                ending = RLGLEnding.Random;
            }

            if(prefDlg.RB_EndingRed.Checked)
            {
                ending = RLGLEnding.AlwaysRed;
            }

            metronome = prefDlg.CB_Metronome.Checked;
            minBpm = (int)prefDlg.NUD_MinMetronome.Value;
            maxBpm = (int)prefDlg.NUD_MaxMetronome.Value;
            metronomePossibility = prefDlg.TB_MetronomeChance.Value;
            
            greenLightColor = prefDlg.P_GreenLightColor.BackColor;
            redLightColor = prefDlg.P_RedLightColor.BackColor;
            censorColor = prefDlg.P_CensorColor.BackColor;
            edgeColor = prefDlg.P_EdgeLightColor.BackColor;
            censorPath = prefDlg.TBox_CensorPath.Text.Trim();

            censoring = prefDlg.CB_Censoring.Checked;
            censorType = (RLGLCensorType)prefDlg.COMB_CensorType.SelectedIndex;
            censorSize = (RLGLCensorSize)prefDlg.COMB_CensorSize.SelectedIndex;
            censorProbability = prefDlg.TB_CensorProbability.Value;

            leftBorder = (int)prefDlg.NUD_LeftBorder.Value;
            rightBorder = (int)prefDlg.NUD_RightBorder.Value;
            topBorder = (int)prefDlg.NUD_TopBorder.Value;
            bottomBorder = (int)prefDlg.NUD_BottomBorder.Value;

            edging = prefDlg.CB_EdgePhase.Checked;
            edgingWarmup = (int)prefDlg.NUD_EdgeWarmup.Value;
            minEdge = (int)prefDlg.NUD_MinEdge.Value;
            maxEdge = (int)prefDlg.NUD_MaxEdge.Value;
            edgeChance = prefDlg.TB_EdgeChance.Value;
            greenAfterEdge = prefDlg.CB_AllowGreenLight.Checked;
        }

        //Loads the contents of the file fileName if it exists and stores it locally.
        public void LoadPreferencesFromFile(string fileName)
        {
            if(File.Exists(fileName))
            {
                StreamReader prefFile = new StreamReader(fileName, Encoding.UTF8, false);

                string version = prefFile.ReadLine();
                
                if (version.Equals(preferencesFileVersion))
                {
                    maxGreen = int.Parse(prefFile.ReadLine());
                    maxRed = int.Parse(prefFile.ReadLine());
                    minGreen = int.Parse(prefFile.ReadLine());
                    minRed = int.Parse(prefFile.ReadLine());
                    ending = (RLGLEnding)int.Parse(prefFile.ReadLine());
                    metronome = bool.Parse(prefFile.ReadLine());
                    minBpm = int.Parse(prefFile.ReadLine());
                    maxBpm = int.Parse(prefFile.ReadLine());
                    metronomePossibility = int.Parse(prefFile.ReadLine());
                    greenLightColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                    redLightColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                    censoring = bool.Parse(prefFile.ReadLine());
                    censorType = (RLGLCensorType)int.Parse(prefFile.ReadLine());
                    censorSize = (RLGLCensorSize)int.Parse(prefFile.ReadLine());
                    censorProbability = int.Parse(prefFile.ReadLine());
                    censorColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                    censorPath = prefFile.ReadLine();
                    leftBorder = int.Parse(prefFile.ReadLine());
                    rightBorder = int.Parse(prefFile.ReadLine());
                    topBorder = int.Parse(prefFile.ReadLine());
                    bottomBorder = int.Parse(prefFile.ReadLine());
                    edging = bool.Parse(prefFile.ReadLine());
                    edgingWarmup = int.Parse(prefFile.ReadLine());
                    minEdge = int.Parse(prefFile.ReadLine());
                    maxEdge = int.Parse(prefFile.ReadLine());
                    edgeChance = int.Parse(prefFile.ReadLine());
                    greenAfterEdge = bool.Parse(prefFile.ReadLine());
                    edgeColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                }
                else if(version.StartsWith("v"))
                {
                    //Load older versions of the file. Currently not used!
                    ReadLegacyVersion(prefFile, version);
                }
                else
                {
                    //Load the first layout of the file. This has no version stored in it,
                    //so it has to handled separately.
                    ReadFirstVersion(prefFile, version);
                }

                //prevent having a too small bottom border by updating from older versions.
                if(bottomBorder < 80)
                {
                    bottomBorder = 80;
                }

                prefFile.Close();
            }
        }

        //Load older versions of the file to maintain backwards-compatibility. Currently not used!
        private void ReadLegacyVersion(StreamReader prefFile, string version)
        {
            //Load version 1 of the file-format
            if(version.Equals("v.1"))
            {
                maxGreen = int.Parse(prefFile.ReadLine());
                maxRed = int.Parse(prefFile.ReadLine());
                minGreen = int.Parse(prefFile.ReadLine());
                minRed = int.Parse(prefFile.ReadLine());
                ending = (RLGLEnding)int.Parse(prefFile.ReadLine());
                metronome = bool.Parse(prefFile.ReadLine());
                minBpm = int.Parse(prefFile.ReadLine());
                maxBpm = int.Parse(prefFile.ReadLine());
                metronomePossibility = int.Parse(prefFile.ReadLine());
                greenLightColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                redLightColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                censoring = bool.Parse(prefFile.ReadLine());
                censorType = (RLGLCensorType)int.Parse(prefFile.ReadLine());
                censorSize = (RLGLCensorSize)int.Parse(prefFile.ReadLine());
                censorProbability = int.Parse(prefFile.ReadLine());
                censorColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                censorPath = prefFile.ReadLine();
            }
            else if(version.Equals("v.2"))
            {
                maxGreen = int.Parse(prefFile.ReadLine());
                maxRed = int.Parse(prefFile.ReadLine());
                minGreen = int.Parse(prefFile.ReadLine());
                minRed = int.Parse(prefFile.ReadLine());
                ending = (RLGLEnding)int.Parse(prefFile.ReadLine());
                metronome = bool.Parse(prefFile.ReadLine());
                minBpm = int.Parse(prefFile.ReadLine());
                maxBpm = int.Parse(prefFile.ReadLine());
                metronomePossibility = int.Parse(prefFile.ReadLine());
                greenLightColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                redLightColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                censoring = bool.Parse(prefFile.ReadLine());
                censorType = (RLGLCensorType)int.Parse(prefFile.ReadLine());
                censorSize = (RLGLCensorSize)int.Parse(prefFile.ReadLine());
                censorProbability = int.Parse(prefFile.ReadLine());
                censorColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
                censorPath = prefFile.ReadLine();
                leftBorder = int.Parse(prefFile.ReadLine());
                rightBorder = int.Parse(prefFile.ReadLine());
                topBorder = int.Parse(prefFile.ReadLine());
                bottomBorder = int.Parse(prefFile.ReadLine());
            }
            else
            {
                //Not a correct version. Do nothing for now.                
            }
        }

        //Load a file with the first layout of the file.
        private void ReadFirstVersion(StreamReader prefFile, string version)
        {
            //in this version there is no explicit version naming at the beginning of the file!
            //there is also no censoring stuff!
            maxGreen = int.Parse(version);
            maxRed = int.Parse(prefFile.ReadLine());
            minGreen = int.Parse(prefFile.ReadLine());
            minRed = int.Parse(prefFile.ReadLine());
            ending = (RLGLEnding)int.Parse(prefFile.ReadLine());
            metronome = bool.Parse(prefFile.ReadLine());
            minBpm = int.Parse(prefFile.ReadLine());
            maxBpm = int.Parse(prefFile.ReadLine());
            metronomePossibility = int.Parse(prefFile.ReadLine());
            greenLightColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
            redLightColor = Color.FromArgb(int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()), int.Parse(prefFile.ReadLine()));
            censoring = false;
            censorColor = Color.FromArgb(255, 0, 0, 0);
            censorPath = "";
            censorSize = RLGLCensorSize.Medium;
            censorType = RLGLCensorType.Color;
            censorProbability = 5;
        }

        //Save the current locally stored preferences to a file fileName.
        public void SavePreferencesToFile(string fileName)
        {
            StreamWriter prefFile = new StreamWriter(fileName, false, Encoding.UTF8);

            prefFile.WriteLine(preferencesFileVersion);
            prefFile.WriteLine(maxGreen);
            prefFile.WriteLine(maxRed);
            prefFile.WriteLine(minGreen);
            prefFile.WriteLine(minRed);
            prefFile.WriteLine((int)ending);
            prefFile.WriteLine(metronome);
            prefFile.WriteLine(minBpm);
            prefFile.WriteLine(maxBpm);
            prefFile.WriteLine(metronomePossibility);
            prefFile.WriteLine(greenLightColor.A);
            prefFile.WriteLine(greenLightColor.R);
            prefFile.WriteLine(greenLightColor.G);
            prefFile.WriteLine(greenLightColor.B);
            prefFile.WriteLine(redLightColor.A);
            prefFile.WriteLine(redLightColor.R);
            prefFile.WriteLine(redLightColor.G);
            prefFile.WriteLine(redLightColor.B);
            prefFile.WriteLine(censoring);
            prefFile.WriteLine((int)censorType);
            prefFile.WriteLine((int)censorSize);
            prefFile.WriteLine(censorProbability);
            prefFile.WriteLine(censorColor.A);
            prefFile.WriteLine(censorColor.R);
            prefFile.WriteLine(censorColor.G);
            prefFile.WriteLine(censorColor.B);
            prefFile.WriteLine(censorPath);
            prefFile.WriteLine(leftBorder);
            prefFile.WriteLine(rightBorder);
            prefFile.WriteLine(topBorder);
            prefFile.WriteLine(bottomBorder);
            prefFile.WriteLine(edging);
            prefFile.WriteLine(edgingWarmup);
            prefFile.WriteLine(minEdge);
            prefFile.WriteLine(maxEdge);
            prefFile.WriteLine(edgeChance);
            prefFile.WriteLine(greenAfterEdge);
            prefFile.WriteLine(edgeColor.A);
            prefFile.WriteLine(edgeColor.R);
            prefFile.WriteLine(edgeColor.G);
            prefFile.WriteLine(edgeColor.B);

            prefFile.Close();
        }
    }
}
