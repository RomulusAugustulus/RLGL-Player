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
     */
public partial class RLGLPlayer : Form
    {
        private RLGLPreferences rlglPreferences;
        private RLGLCurrentMedia rlglCurrentMedia;
        private RLGLCensorData rlglCensorData;
        private Random randomNumberGenerator;
        private SoundPlayer metronome;
        private RLGLVideoQueue rlglVideoQueue;

        private List<Blackbar> censorbars;
        private bool censoring;
        private static string[] imageFileExtensions = new string[] { ".jpg", ".png", ".bmp" };

        public RLGLPlayer()
        {
            randomNumberGenerator = new Random();
            rlglPreferences = new RLGLPreferences();
            metronome = new SoundPlayer();
            censorbars = new List<Blackbar>();
            censoring = false;
            rlglCensorData = null;
            rlglVideoQueue = null;
            InitializeComponent();
        }

        //Load a new media queue, play it and start with the first phase.
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RLGLPlayingQueueDlg rlglPlayingQueueDlg = new RLGLPlayingQueueDlg();

            if(rlglPlayingQueueDlg.ShowDialog() == DialogResult.OK)
            {
                rlglVideoQueue = rlglPlayingQueueDlg.VideoQueue;

                if (rlglVideoQueue.VideosRemaining() > 0)
                {
                    PlayNextVideo();
                }
            }
        }

        //Show the preferences dialog and save any changes that are made.
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreferencesDlg preferencesDlg = new PreferencesDlg();
            rlglPreferences.LoadPreferences(preferencesDlg);

            if(preferencesDlg.ShowDialog() == DialogResult.OK)
            {
                rlglPreferences.SavePreferences(preferencesDlg);
                UpdateRLGLLayoutSizes();
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
                ShowPhase(RLGLPhase.Red, false);
                rlglCurrentMedia.CurrentPhase = RLGLPhase.Red;
                RLGL_SwitchTimer.Stop();
                RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed) * 1000;
                RLGL_SwitchTimer.Start();
            }
            else
            {
                ShowPhase(RLGLPhase.Green, false);
                rlglCurrentMedia.CurrentPhase = RLGLPhase.Green;
                RLGL_SwitchTimer.Stop();
                RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen) * 1000;
                RLGL_SwitchTimer.Start();
            }
        }

        //Load necessary files at startup.
        private void Form1_Load(object sender, EventArgs e)
        {
            rlglPreferences.LoadPreferencesFromFile("Preferences.config");
            UpdateRLGLLayoutSizes();
            metronome.SoundLocation = "250551__druminfected__metronomeup.wav";
            L_Text.Text = "";            
        }

        //Save the preferences to the disc.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                        ShowPhase((RLGLPhase)randomNumberGenerator.Next(0, 2), true);
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
            RLGL_VideoEndTimer.Interval = (int)(VLC_Control.GetCurrentMedia().Duration - (rlglCurrentMedia.End + TimeSpan.FromSeconds(20))).TotalMilliseconds;
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

                    if(rlglPreferences.Metronome && randomNumberGenerator.Next(1,11) <= rlglPreferences.MetronomePossibility)
                    {
                        L_Text.Text += " - follow the beat";
                        SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinBpm, rlglPreferences.MaxBpm+1));
                    }

                    if (rlglPreferences.Censoring)
                    {
                        int rnd = 0;
                        int probability = rlglPreferences.CensorProbability;

                        if (probability <= 5)
                        {
                            rnd = randomNumberGenerator.Next(1, 6);
                        }
                        else
                        {
                            rnd = randomNumberGenerator.Next(6, 11);
                        }

                        if (rnd <= probability)
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
                        rlglPreferences.CensorProbability > 5 && 
                        randomNumberGenerator.Next(6,11) <= rlglPreferences.CensorProbability)
                    {
                        ShowCensoring(true);
                    }
                    else
                    {
                        HideCensoring();
                    }

                    break;
            }            
        }

        // Play the next video in the currently selected queue
        private void PlayNextVideo()
        {
            string fileName = rlglVideoQueue.GetNextVideo();
            FileStream fs = File.OpenRead(fileName);
            VLC_Control.SetMedia(fs);

            TimeSpan lastDuration = TimeSpan.FromSeconds(0);

            if (rlglVideoQueue.VideosRemaining() == 0)
            {
                switch (rlglPreferences.Ending)
                {
                    case RLGLEnding.AlwaysGreen:
                        lastDuration = TimeSpan.FromSeconds(randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen));
                        break;

                    case RLGLEnding.AlwaysRed:
                        lastDuration = TimeSpan.FromSeconds(randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed));
                        break;

                    case RLGLEnding.Random:
                        lastDuration = TimeSpan.FromSeconds(randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen));
                        break;
                }
            }
            else
            {
                lastDuration = TimeSpan.FromSeconds(randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed));
            }

            rlglCurrentMedia = new RLGLCurrentMedia(fileName,
                DateTime.Now, lastDuration,
                (RLGLPhase)randomNumberGenerator.Next(0, 2));

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
                PlayNextVideo();
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
            RLGL_Layout.RowStyles[0].Height = rlglPreferences.TopBorder;
            RLGL_Layout.RowStyles[2].Height = rlglPreferences.BottomBorder;
            RLGL_Layout.ColumnStyles[0].Width = rlglPreferences.LeftBorder;
            RLGL_Layout.ColumnStyles[3].Width = rlglPreferences.RightBorder;
        }
    }
}
