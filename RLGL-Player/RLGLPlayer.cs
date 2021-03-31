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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Collections.Generic;

namespace RLGL_Player
{
    /*
     * RLGLPlayer is the main form of the application. 
     * It contains all the logic to play the different phases to any media.
     * 
     * RLGL_Timer is currently for debugging purposes. If you need the elapsed time of a video, uncommend
     * the code.
     */
public partial class RLGLPlayer : Form
    {
        private RLGLPreferences rlglPreferences;
        private RLGLPreferences tmpRlglPreferences;
        private RLGLCurrentMedia rlglCurrentMedia;
        private RLGLCensorData rlglCensorData;
        private Random randomNumberGenerator;
        private SoundPlayer metronome;
        private RLGLVideoQueue rlglVideoQueue;

        private List<Blackbar> censorbars;
        private bool censoring;
        private bool edging;
        private static string[] imageFileExtensions = new string[] { ".jpg", ".png", ".bmp" };

        private bool fullscreen;
        private PreferencesDlg preferencesDlg;

        public RLGLPlayer()
        {
            randomNumberGenerator = new Random();
            rlglPreferences = new RLGLPreferences();
            tmpRlglPreferences = rlglPreferences;
            metronome = new SoundPlayer();
            censorbars = new List<Blackbar>();
            censoring = false;
            edging = false;
            rlglCensorData = null;
            rlglVideoQueue = null;
            fullscreen = false;
            preferencesDlg = new PreferencesDlg();
            InitializeComponent();
        }

        //Load a new media queue, play it and start with the first phase.
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RLGLPlayingQueueDlg rlglPlayingQueueDlg = new RLGLPlayingQueueDlg();

            if(rlglPlayingQueueDlg.ShowDialog() == DialogResult.OK)
            {
                rlglVideoQueue = rlglPlayingQueueDlg.VideoQueue;

                StartQueue(rlglPreferences);
            }
        }

        //Show the preferences dialog and save any changes that are made.
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rlglPreferences.LoadPreferences(preferencesDlg);

            if(preferencesDlg.ShowDialog(this) == DialogResult.OK)
            {
                UpdateRLGLPreferences();
            }
        }

        //Quit the application.
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        //Switches between the different phases.
        private void RLGL_SwitchTimer_Tick(object sender, EventArgs e)
        {
            if(rlglCurrentMedia.CurrentPhase == RLGLPhase.Green)
            {
                bool edge = false;
                if(edging)
                {
                    if(randomNumberGenerator.Next(1,101) <= rlglPreferences.EdgeChance)
                    {
                        edge = true;
                    }
                }

                if (edge)
                {
                    ShowPhase(RLGLPhase.Edge, false);
                    rlglCurrentMedia.CurrentPhase = RLGLPhase.Edge;
                    RLGL_SwitchTimer.Stop();
                    RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinEdge, rlglPreferences.MaxEdge) * 1000;
                    RLGL_SwitchTimer.Start();
                }
                else
                {
                    ShowPhase(RLGLPhase.Red, false);
                    rlglCurrentMedia.CurrentPhase = RLGLPhase.Red;
                    RLGL_SwitchTimer.Stop();
                    RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed) * 1000;
                    RLGL_SwitchTimer.Start();
                }
            }
            else if(rlglCurrentMedia.CurrentPhase == RLGLPhase.Red)
            {
                ShowPhase(RLGLPhase.Green, false);
                rlglCurrentMedia.CurrentPhase = RLGLPhase.Green;
                RLGL_SwitchTimer.Stop();
                RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen) * 1000;
                RLGL_SwitchTimer.Start();
            }
            else
            {
                bool green = false;
                if(rlglPreferences.GreenAfterEdge)
                {
                    green = randomNumberGenerator.Next(0, 2) < 1;
                }

                if(green)
                {
                    ShowPhase(RLGLPhase.Green, false);
                    rlglCurrentMedia.CurrentPhase = RLGLPhase.Green;
                    RLGL_SwitchTimer.Stop();
                    RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen) * 1000;
                    RLGL_SwitchTimer.Start();
                }
                else
                {
                    ShowPhase(RLGLPhase.Red, false);
                    rlglCurrentMedia.CurrentPhase = RLGLPhase.Red;
                    RLGL_SwitchTimer.Stop();
                    RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed) * 1000;
                    RLGL_SwitchTimer.Start();
                }
            }
        }

        //Load necessary files at startup.
        private void Form1_Load(object sender, EventArgs e)
        {
            rlglPreferences.LoadPreferencesFromFile("Preferences.config");
            RLGL_EdgingTimer.Interval = rlglPreferences.EdgingWarmup * 1000;
            UpdateRLGLLayoutSizes();
            metronome.SoundLocation = "250551__druminfected__metronomeup.wav";
            L_Text.Text = "";
            L_TimePassed.Text = "";
        }

        //Save the preferences to the disc.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            rlglPreferences = tmpRlglPreferences;
            rlglPreferences.SavePreferencesToFile("Preferences.config");
        }

        //After the video is finished, reset the information.
        private void VLC_Control_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {
            this.BeginInvoke(new Action(() => ResetRLGLInfo()));
        }

        //As soon as the video is playing set the information.
        private void VLC_Control_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            this.BeginInvoke(new Action(() => SetVideoEndTimer()));
        }

        //Near the end of the video stop all timer and show the last phase.
        private void RLGL_VideoEndTimer_Tick(object sender, EventArgs e)
        {
            RLGL_SwitchTimer.Stop();
            RLGL_VideoEndTimer.Stop();
            RLGL_Censor.Stop();

            if (rlglVideoQueue.VideosRemaining() == 0)
            {
                switch (rlglPreferences.Ending)
                {
                    case RLGLEnding.AlwaysGreen:
                        ShowPhase(RLGLPhase.Green, true);
                        break;

                    case RLGLEnding.AlwaysRed:
                        ShowPhase(RLGLPhase.Red, true);
                        break;

                    case RLGLEnding.Random:
                        if (rlglCurrentMedia.Ending == RLGLSpecificEnding.Cum)
                        {
                            ShowPhase(RLGLPhase.Green, true);
                        }
                        else if(rlglCurrentMedia.Ending == RLGLSpecificEnding.Denied)
                        {
                            ShowPhase(RLGLPhase.Red, true);
                        }
                        break;
                }
            }
            else
            {
                ShowPhase(RLGLPhase.Red, true);
            }
        }

        //Calculates the duration of the video and sets the timer accordingly.
        private void SetVideoEndTimer()
        {
            RLGL_VideoEndTimer.Interval = (int)(VLC_Control.GetCurrentMedia().Duration - (rlglCurrentMedia.End + TimeSpan.FromSeconds(2))).TotalMilliseconds;
            RLGL_VideoEndTimer.Start();
        }

        //Show the given phase to the user.
        private void ShowPhase(RLGLPhase phase, bool lastIteration)
        {
            rlglCurrentMedia.ResetCensorDimension();
            switch(phase)
            {
                case RLGLPhase.Green:
                    RLGL_Layout.BackColor = rlglPreferences.GreenLightColor;
                    L_Text.BackColor = rlglPreferences.GreenLightColor;
                    if (lastIteration)
                    {
                        L_Text.Text = "Cum!";
                    }
                    else
                    {
                        L_Text.Text = "Stroke";                        
                    }

                    if(rlglPreferences.Metronome && randomNumberGenerator.Next(1,101) <= rlglPreferences.MetronomeChance)
                    {
                        L_Text.Text += " - follow the beat";
                        SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinBpm, rlglPreferences.MaxBpm+1));
                    }

                    if (rlglPreferences.Censoring)
                    {
                        if (randomNumberGenerator.Next(1, 101) <= rlglPreferences.CensorChance)
                        {
                            ShowCensoring(true);
                        }
                    }
                    else
                    {
                        HideCensoring();
                    }
                    break;

                case RLGLPhase.Red:
                    RLGL_Layout.BackColor = rlglPreferences.RedLightColor;
                    L_Text.BackColor = rlglPreferences.RedLightColor;
                    StopMetronome();
                    if (lastIteration && rlglVideoQueue.VideosRemaining() == 0)
                    {
                        L_Text.Text = "Hands off! You're denied!";
                    }
                    else
                    {
                        L_Text.Text = "Hands off";
                    }

                    if(rlglPreferences.Censoring && 
                        !rlglPreferences.CensorOnlyGreen && 
                        randomNumberGenerator.Next(1,101) <= rlglPreferences.CensorChance)
                    {
                        ShowCensoring(true);
                    }
                    else
                    {
                        HideCensoring();
                    }

                    break;

                case RLGLPhase.Edge:
                    RLGL_Layout.BackColor = rlglPreferences.EdgeColor;
                    L_Text.BackColor = rlglPreferences.EdgeColor;
                    StopMetronome();
                    L_Text.Text = "Edge!";

                    if (rlglPreferences.Censoring)
                    {
                        if (randomNumberGenerator.Next(1, 101) <= rlglPreferences.CensorChance)
                        {
                            ShowCensoring(true);
                        }
                    }
                    else
                    {
                        HideCensoring();
                    }
                    break;
            }            
        }

        // Play the next video in the currently selected queue
        private void PlayNextVideo(bool sessionStart)
        {
            string fileName = rlglVideoQueue.GetNextVideo();
            FileStream fs = File.OpenRead(fileName);
            VLC_Control.SetMedia(fs);

            TimeSpan lastDuration = TimeSpan.FromSeconds(0);
            RLGLSpecificEnding ending = RLGLSpecificEnding.Denied;

            if (rlglVideoQueue.VideosRemaining() == 0)
            {
                switch (rlglPreferences.Ending)
                {
                    case RLGLEnding.AlwaysGreen:
                        lastDuration = TimeSpan.FromSeconds(randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen));
                        ending = RLGLSpecificEnding.Cum;
                        break;

                    case RLGLEnding.AlwaysRed:
                        lastDuration = TimeSpan.FromSeconds(randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed));
                        break;

                    case RLGLEnding.Random:
                        ending = (RLGLSpecificEnding)randomNumberGenerator.Next(0, 2);
                        if (ending == RLGLSpecificEnding.Cum)
                        {
                            lastDuration = TimeSpan.FromSeconds(randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen));
                        }
                        else if(ending == RLGLSpecificEnding.Denied)
                        {
                            lastDuration = TimeSpan.FromSeconds(randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed));
                        }
                        break;
                }
            }
            else
            {
                lastDuration = TimeSpan.FromSeconds(randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed));
            }

            if (sessionStart)
            {
                rlglCurrentMedia = new RLGLCurrentMedia(fileName,
                    DateTime.Now, lastDuration, RLGLPhase.Green, ending);
            }
            else
            {
                rlglCurrentMedia = new RLGLCurrentMedia(fileName,
                    DateTime.Now, lastDuration,
                    (RLGLPhase)randomNumberGenerator.Next(0, 2),
                    ending);
            }

            for (int i = 0; i < censorbars.Count; i++)
            {
                censorbars[i].Close();
            }

            censorbars.Clear();

            rlglCensorData = RLGLCensorData.ReadFromFile(fileName);
            RLGL_Censor.Stop();

            if (rlglCensorData != null)
            {
                RLGL_Censor.Start();

                for (int i = 0; i < rlglCensorData.Ids.Count; i++)
                {
                    censorbars.Add(new Blackbar());
                }
            }
            else
            {
                censorbars.Add(new Blackbar());
            }

            ShowPhase(rlglCurrentMedia.CurrentPhase, false);

            VLC_Control.Play();

            if (rlglCurrentMedia.CurrentPhase == RLGLPhase.Red)
            {
                RLGL_SwitchTimer.Stop();
                RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed) * 1000;
                RLGL_SwitchTimer.Start();
            }
            else
            {
                RLGL_SwitchTimer.Stop();
                RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen) * 1000;
                RLGL_SwitchTimer.Start();
            }
        }

        //Reset the visible interface. 
        private void ResetRLGLInfo()
        {
            RLGL_Layout.BackColor = SystemColors.Control;
            L_Text.BackColor = SystemColors.Control;
            L_Text.Text = "";
            StopMetronome();
            RLGL_SwitchTimer.Stop();
            RLGL_VideoEndTimer.Stop();

            if(rlglVideoQueue.VideosRemaining() > 0)
            {
                PlayNextVideo(false);
            }
            else
            {
                rlglPreferences = tmpRlglPreferences;
                edging = false;
                StopEdging();
                sessionToolStripMenuItem.Visible = false;
                //RLGL_Timer.Stop();
            }
        }

        //Start a metronome with a speed bpm in beats per minute.
        private void SetMetronome(int bpm)
        {
            RLGL_Metronome.Interval = (int)(60.0f / (float)bpm * 1000.0f);
            RLGL_Metronome.Start();
        }

        //Stop the metronome.
        private void StopMetronome()
        {
            RLGL_Metronome.Stop();
        }

        //Starts the edging timer. Stops it if it is already running.
        private void SetEdging()
        {
            StopEdging();
            RLGL_EdgingTimer.Start();
        }

        //Stops the edging timer.
        private void StopEdging()
        {
            RLGL_EdgingTimer.Stop();
        }

        //Show a censorbar according to the users preferences or simply update a visible one.
        private void ShowCensoring(bool changingImagePossible)
        {
            censoring = true;
            Point initPos = VLC_Control.PointToScreen(Point.Empty);
            List<CensorbarInfo<Point>> pos = new List<CensorbarInfo<Point>>();

            switch(rlglPreferences.CensorType)
            {
                case RLGLCensorType.Color:
                    foreach (Blackbar b in censorbars)
                    {
                        b.BackColor = rlglPreferences.CensorColor;

                        if(b.PB_CensorImage.Image != null)
                        {
                            b.PB_CensorImage.Image = null;
                        }
                    }
                    break;

                case RLGLCensorType.Image:
                    if (changingImagePossible)
                    {
                        if (Directory.Exists(rlglPreferences.CensorPath))
                        {
                            DirectoryInfo dinfo = new DirectoryInfo(rlglPreferences.CensorPath);
                            FileInfo[] censorImages = dinfo.EnumerateFiles().Where(f => imageFileExtensions.Contains(f.Extension.ToLower())).ToArray();
                            if (censorImages.Length == 0)
                            {
                                foreach (Blackbar b in censorbars)
                                {
                                    b.BackColor = rlglPreferences.CensorColor;
                                }
                            }
                            else
                            {
                                foreach (Blackbar b in censorbars)
                                {
                                    b.PB_CensorImage.Image = Bitmap.FromFile(censorImages[randomNumberGenerator.Next(0, censorImages.Length)].FullName);
                                }
                            }
                        }
                        else
                        {
                            foreach (Blackbar b in censorbars)
                            {
                                b.BackColor = rlglPreferences.CensorColor;
                            }
                        }
                    }
                    break;
            }

            int width = VLC_Control.Width;
            int height = VLC_Control.Height;

            if (rlglCensorData == null)
            {
                Point p = initPos;

                p.X += width / 2;
                p.Y += 2 * height / 3;
                pos.Add(new CensorbarInfo<Point>(0, 0, p));
            }
            else
            {
                Dictionary<int, CensorbarInfo<PointF>> relativePositions = rlglCensorData.GetAllCensorPositionsAndSizes((int)(rlglCensorData.Duration.TotalSeconds * VLC_Control.Position));
                
                foreach(int id in relativePositions.Keys)
                {
                    Point p = initPos;
                    p.X += (int)(width * relativePositions[id].Position.X);
                    p.Y += (int)(height * relativePositions[id].Position.Y);
                    pos.Add(new CensorbarInfo<Point>(id, relativePositions[id].Size, p));
                }
            }

            ShowCensorbarsAroundPositions(pos);
        }

        //Hide a visible censorbar.
        private void HideCensoring()
        {
            rlglCurrentMedia.ResetCensorDimension();
            censoring = false;
            foreach (Blackbar b in censorbars)
            {
                if (b.Visible)
                {
                    b.Hide();
                }
            }
        }

        //Calculate the size of the censorbar and display it or update its dimension if its still visible.
        private void ShowCensorbarsAroundPositions(List<CensorbarInfo<Point>> pos)
        {
            int width = VLC_Control.Width;
            int height = VLC_Control.Height;
            Point vlcPos = VLC_Control.PointToScreen(Point.Empty);

            for (int i = 0; i < pos.Count; i++)
            {
                PointF percent = rlglCurrentMedia.GetCensorDimension(pos[i].Id);
                RLGLCensorSize size = rlglPreferences.CensorSize;
                
                if (pos[i].Size > 0)
                {
                    size = (RLGLCensorSize)(pos[i].Size - 1);
                }

                if (percent.X < 0.0f &&
                 percent.Y < 0.0f)
                {
                    switch (size)
                    {
                        case RLGLCensorSize.Small:
                            percent = new PointF(randomNumberGenerator.Next(5, 16) / 100.0f, randomNumberGenerator.Next(5, 16) / 100.0f);
                            break;

                        case RLGLCensorSize.Medium:
                            percent = new PointF(randomNumberGenerator.Next(15, 26) / 100.0f, randomNumberGenerator.Next(15, 26) / 100.0f);
                            break;

                        case RLGLCensorSize.Big:
                            percent = new PointF(randomNumberGenerator.Next(20, 31) / 100.0f, randomNumberGenerator.Next(20, 31) / 100.0f);
                            break;

                        case RLGLCensorSize.Unfair:
                            percent = new PointF(randomNumberGenerator.Next(40, 48) / 100.0f, randomNumberGenerator.Next(40, 48) / 100.0f);
                            break;
                    }

                    rlglCurrentMedia.SetCensorDimension(pos[i].Id, percent);
                }

                int estimatedHeight = (int)(height * 2 * percent.Y);
                int estimatedWidth = (int)(width * 2 * percent.X);

                int YPosBegin = pos[i].Position.Y - (int)(height * percent.Y);
                int XPosBegin = pos[i].Position.X - (int)(width * percent.X);

                if(XPosBegin < vlcPos.X)
                {
                    XPosBegin = vlcPos.X;
                }

                if(XPosBegin > vlcPos.X + width)
                {
                    XPosBegin = vlcPos.X + width;
                }

                if(YPosBegin < vlcPos.Y)
                {
                    YPosBegin = vlcPos.Y;
                }

                if(YPosBegin > vlcPos.Y + height)
                {
                    YPosBegin = vlcPos.Y + height;
                }

                if(estimatedWidth + XPosBegin > vlcPos.X + width)
                {
                    estimatedWidth = vlcPos.X + width - XPosBegin;
                }

                if(estimatedHeight + YPosBegin > vlcPos.Y + height)
                {
                    estimatedHeight = vlcPos.Y + height - YPosBegin;
                }
                
                censorbars[i].SetBounds(XPosBegin, YPosBegin, estimatedWidth, estimatedHeight);

                if (!censorbars[i].Visible)
                {
                    censorbars[i].Show(VLC_Control);
                }
            }

            for(int i=pos.Count;i<censorbars.Count;i++)
            {
                if(censorbars[i].Visible)
                {
                    censorbars[i].Hide();
                }
            }
        }

        //Play the metronome-sound.
        private void RLGL_Metronome_Tick(object sender, EventArgs e)
        {
            metronome.Play();
        }

        //Change the volume of the currently played media.
        private void TB_Volume_ValueChanged(object sender, EventArgs e)
        {
            VLC_Control.Audio.Volume = TB_Volume.Value;
        }

        //Show an about dialog.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDlg aboutDlg = new AboutDlg();

            aboutDlg.ShowDialog();
        }

        //Set the directory of the vlc-media-player.
        private void VLC_Control_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        //Update a censorbars position.
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if(censoring)
            {
                ShowCensoring(false);
            }
        }

        //Update a censorbars position and size.
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (censoring)
            {
                ShowCensoring(false);
            }
        }
        
        //Show the censor editor dialog
        private void censorEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CensorEditorDlg censorEditorDlg = new CensorEditorDlg();
            censorEditorDlg.Show(this);
        }

        //Update the positions of the censorbars regularily in case there is custom data loaded
        private void RLGL_Censor_Tick(object sender, EventArgs e)
        {
            if(censoring)
            {
                Point initPos = VLC_Control.PointToScreen(Point.Empty);
                List<CensorbarInfo<Point>> pos = new List<CensorbarInfo<Point>>();

                int width = VLC_Control.Width;
                int height = VLC_Control.Height;

                if (rlglCensorData == null)
                {
                    Point p = initPos;

                    p.X += width / 2;
                    p.Y += 2 * height / 3;
                    pos.Add(new CensorbarInfo<Point>(0, 0, p));
                }
                else
                {
                    Dictionary<int, CensorbarInfo<PointF>> relativePositions = rlglCensorData.GetAllCensorPositionsAndSizes((float)(rlglCensorData.Duration.TotalSeconds * VLC_Control.Position));

                    foreach (int id in relativePositions.Keys)
                    {
                        Point p = initPos;
                        p.X += (int)(width * relativePositions[id].Position.X);
                        p.Y += (int)(height * relativePositions[id].Position.Y);
                        pos.Add(new CensorbarInfo<Point>(id, relativePositions[id].Size, p));
                    }
                }

                ShowCensorbarsAroundPositions(pos);
            }
        }

        //Set the layout of the main-window according to the preferences.
        private void UpdateRLGLLayoutSizes()
        {
            RLGL_Layout.RowStyles[0].Height = (float)rlglPreferences.TopBorder/100.0f * 50;
            RLGL_Layout.RowStyles[2].Height = (float)rlglPreferences.BottomBorder/100.0f * 50;
            RLGL_Layout.ColumnStyles[0].Width = (float)rlglPreferences.LeftBorder/100.0f * 50;
            RLGL_Layout.ColumnStyles[3].Width = (float)rlglPreferences.RightBorder/100.0f * 50;
        }

        //Enable edging phases.
        private void RLGL_EdgingTimer_Tick(object sender, EventArgs e)
        {
            edging = true;
            RLGL_EdgingTimer.Stop();
        }

        private void RLGL_Timer_Tick(object sender, EventArgs e)
        {
            //L_TimePassed.Text = (DateTime.Now - rlglCurrentMedia.Start).ToString(@"hh\:mm\:ss");
        }

        /*
         * Saves the currently loaded queue to a file.
         */ 
        private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SaveQueueDlg.ShowDialog() == DialogResult.OK)
            {
                rlglVideoQueue.SaveVideoQueue(SaveQueueDlg.FileName, rlglPreferences);
                MessageBox.Show("Saved playlist.", "Save");
            }
        }

        /*
         * Load a queue from a file and starts playing it. Has also the option to customize the loaded playlist before starting it.
         */ 
        private void loadPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OpenQueueDlg.ShowDialog() == DialogResult.OK)
            {
                rlglVideoQueue = new RLGLVideoQueue();
                (bool, RLGLPreferences) loadedQueue = rlglVideoQueue.LoadVideoQueue(OpenQueueDlg.FileName, rlglPreferences);

                if(loadedQueue.Item1)
                {
                    if (MessageBox.Show("Do you want to customize the loaded playlist?", "Customize", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        RLGLPlayingQueueDlg queueDlg = new RLGLPlayingQueueDlg();
                        queueDlg.InitCustomizationDlg(rlglVideoQueue);

                        if(queueDlg.ShowDialog() == DialogResult.OK)
                        {
                            rlglVideoQueue = queueDlg.VideoQueue;

                            if(queueDlg.IgnoreQueuePreferences)
                            {
                                StartQueue(rlglPreferences);
                            }
                            else
                            {
                                StartQueue(loadedQueue.Item2);
                            }
                        }
                        else
                        {

                            StartQueue(loadedQueue.Item2);
                        }
                    }
                    else
                    {
                        StartQueue(loadedQueue.Item2);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load playlist! File was either not a RLGL-Playlist or file is corrupted!", "Error");
                }
            }
        }

        /*
         * Starts the current loaded queue and overrides the selected preferences with the specified ones.
         * If the queue has no videos left or no videos at all, nothing happens.
         */ 
        private void StartQueue(RLGLPreferences overridePrefs)
        {
            if (rlglVideoQueue.VideosRemaining() > 0)
            {
                tmpRlglPreferences = rlglPreferences;
                rlglPreferences = overridePrefs;

                savePlaylistToolStripMenuItem.Enabled = true;
                sessionToolStripMenuItem.Visible = true;

                edging = false;
                if (rlglPreferences.Edging)
                {
                    SetEdging();
                }

                PlayNextVideo(true);
                //RLGL_Timer.Start();
            }
        }

        //Cancel active session and return to default screen.
        private void endSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rlglVideoQueue != null)
            {
                VLC_Control.Stop();
                rlglVideoQueue.CancelQueue();
                ResetRLGLInfo();
            }
        }

        //Toggle full screen on pressing F
        private void VLC_Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                MainMenu.Visible = fullscreen;
                this.WindowState = fullscreen ? FormWindowState.Normal : FormWindowState.Maximized;
                this.FormBorderStyle = fullscreen ? FormBorderStyle.Sizable : FormBorderStyle.None;

                fullscreen = !fullscreen;
            }
        }

        public void UpdateRLGLPreferences()
        {
            rlglPreferences.SavePreferences(preferencesDlg);
            RLGL_EdgingTimer.Interval = rlglPreferences.EdgingWarmup * 1000;
            UpdateRLGLLayoutSizes();
        }
    }
}
