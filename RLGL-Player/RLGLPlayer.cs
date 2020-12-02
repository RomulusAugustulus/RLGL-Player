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
        private Random randomNumberGenerator;
        private SoundPlayer metronome;

        private Blackbar censorbar;
        private bool censoring;
        private static string[] imageFileExtensions = new string[] { ".jpg", ".png", ".bpm" };

        public RLGLPlayer()
        {
            randomNumberGenerator = new Random();
            rlglPreferences = new RLGLPreferences();
            metronome = new SoundPlayer();
            censorbar = new Blackbar();
            censoring = false;

            InitializeComponent();
        }

        //Load a new media, play it and start with the first phase.
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OpenVideoDlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(OpenVideoDlg.FileName);
                VLC_Control.SetMedia(fs);

                TimeSpan lastDuration = TimeSpan.FromSeconds(0);

                switch(rlglPreferences.Ending)
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

                rlglCurrentMedia = new RLGLCurrentMedia(OpenVideoDlg.FileName, 
                    DateTime.Now, lastDuration, 
                    (RLGLPhase)randomNumberGenerator.Next(0,2));
                                
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
        }

        //Show the preferences dialog and save any changes that are made.
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreferencesDlg preferencesDlg = new PreferencesDlg();
            rlglPreferences.LoadPreferences(preferencesDlg);

            if(preferencesDlg.ShowDialog() == DialogResult.OK)
            {
                rlglPreferences.SavePreferences(preferencesDlg);
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

            switch(rlglPreferences.Ending)
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

                    if(rlglPreferences.Censoring && randomNumberGenerator.Next(1,11) <= rlglPreferences.CensorProbability)
                    {
                        ShowCensoring(true);
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
                    if (lastIteration)
                    {
                        L_Text.Text = "Hands off! You're denied!";
                    }
                    else
                    {
                        L_Text.Text = "Hands off";
                    }

                    if(rlglPreferences.Censoring && 
                        rlglPreferences.CensorProbability > 5 && 
                        randomNumberGenerator.Next(1,11) <= rlglPreferences.CensorProbability)
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

        //Reset the visible interface. 
        private void ResetRLGLInfo()
        {
            RLGL_Layout.BackColor = SystemColors.Control;
            L_Text.BackColor = SystemColors.Control;
            L_Text.Text = "";
            StopMetronome();
            RLGL_SwitchTimer.Stop();
            RLGL_VideoEndTimer.Stop();
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
            Point pos = VLC_Control.PointToScreen(Point.Empty);
            
            switch(rlglPreferences.CensorType)
            {
                case RLGLCensorType.Color:
                    censorbar.BackColor = rlglPreferences.CensorColor;                    
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
                                censorbar.BackColor = rlglPreferences.CensorColor;
                            }
                            else
                            {
                                censorbar.PB_CensorImage.Image = Bitmap.FromFile(censorImages[randomNumberGenerator.Next(0, censorImages.Length)].FullName);
                            }
                        }
                        else
                        {
                            censorbar.BackColor = rlglPreferences.CensorColor;
                        }
                    }
                    break;
            }

            int width = VLC_Control.Width;
            int height = VLC_Control.Height;

            pos.X += width / 2;
            pos.Y += 2 * height / 3;
            ShowCensorbarAroundPosition(pos);
        }

        //Hide a visible censorbar.
        private void HideCensoring()
        {
            rlglCurrentMedia.ResetCensorDimension();
            censoring = false;
            censorbar.Hide();
        }

        //Calculate the size of the censorbar and display it or update its dimension if its still visible.
        private void ShowCensorbarAroundPosition(Point pos)
        {
            int width = VLC_Control.Width;
            int height = VLC_Control.Height;

            float percentX = rlglCurrentMedia.CurrentCensorX;
            float percentY = rlglCurrentMedia.CurrentCensorY;

            if (percentX < 0.0f &&
                 percentY < 0.0f)
            {
                switch (rlglPreferences.CensorSize)
                {
                    case RLGLCensorSize.Small:
                        percentX = randomNumberGenerator.Next(5, 16) / 100.0f;
                        percentY = randomNumberGenerator.Next(5, 16) / 100.0f;
                        break;

                    case RLGLCensorSize.Medium:
                        percentX = randomNumberGenerator.Next(15, 26) / 100.0f;
                        percentY = randomNumberGenerator.Next(15, 26) / 100.0f;
                        break;

                    case RLGLCensorSize.Big:
                        percentX = randomNumberGenerator.Next(20, 31) / 100.0f;
                        percentY = randomNumberGenerator.Next(20, 31) / 100.0f;
                        break;

                    case RLGLCensorSize.Unfair:
                        percentX = randomNumberGenerator.Next(30, 41) / 100.0f;
                        percentY = randomNumberGenerator.Next(30, 41) / 100.0f;
                        break;
                }

                rlglCurrentMedia.CurrentCensorX = percentX;
                rlglCurrentMedia.CurrentCensorY = percentY;
            }

            int estimatedHeight = (int)(height * 2 * percentY);
            int realHeight = estimatedHeight;
            int vlcPosY = VLC_Control.PointToScreen(Point.Empty).Y;

            if (estimatedHeight + pos.Y - (int)(height * percentY) > vlcPosY + height)
            {
                realHeight = vlcPosY + height - (pos.Y - (int)(height * percentY));
            }

            censorbar.SetBounds(pos.X - (int)(width * percentX), pos.Y - (int)(height * percentY), (int)(width * 2 * percentX), realHeight);

            if (!censorbar.Visible)
            {
                censorbar.Show(VLC_Control);
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
            if(censoring)
            {
                ShowCensoring(false);
            }
        }
    }
}
