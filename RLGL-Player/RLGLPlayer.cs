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
using LibVLCSharp.Shared;

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
        private RLGLCurrentMedia rlglCurrentMedia;
        private RLGLCensorData rlglCensorData;
        private Random randomNumberGenerator;
        private SoundPlayer metronome;
        private RLGLVideoQueue rlglVideoQueue;

        private List<Blackbar> censorbars;
        private bool censoring;
        private bool edging;
        private bool playEnding;
        private RLGLEndingPhase currentEndingPhase;
        private int currentEndingCountdown;
        private static string[] imageFileExtensions = new string[] { ".jpg", ".png", ".bmp" };

        private bool fullscreen;
        private PreferencesDlg preferencesDlg;
        private VolumeBar volumeBar;

        private LibVLC libVLC;
        private MediaPlayer mediaPlayer;

        private DateTime sessionStart;

        public RLGLPlayer()
        {
            Core.Initialize();
            libVLC = new LibVLC();
            mediaPlayer = new MediaPlayer(libVLC);

            mediaPlayer.EndReached += new EventHandler<EventArgs>(VLC_Control_EndReached);
            mediaPlayer.Playing += new EventHandler<EventArgs>(VLC_Control_Playing);

            randomNumberGenerator = new Random();
            rlglPreferences = new RLGLPreferences();
            metronome = new SoundPlayer();
            censorbars = new List<Blackbar>();
            censoring = false;
            edging = false;
            playEnding = false;
            rlglCensorData = null;
            rlglVideoQueue = null;
            currentEndingPhase = null;
            fullscreen = false;
            preferencesDlg = new PreferencesDlg();
            volumeBar = new VolumeBar();
            sessionStart = DateTime.Now;
            InitializeComponent();
        }

        //Load a new media queue, play it and start with the first phase.
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RLGLPlayingQueueDlg rlglPlayingQueueDlg = new RLGLPlayingQueueDlg(libVLC, rlglPreferences);

            if(rlglPlayingQueueDlg.ShowDialog() == DialogResult.OK)
            {
                if (rlglVideoQueue != null)
                {
                    rlglVideoQueue.CancelQueue();
                    ResetRLGLInfo();
                }

                rlglVideoQueue = rlglPlayingQueueDlg.VideoQueue;

                StartQueue();
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
            if (!playEnding)
            {
                if (rlglVideoQueue.CurrentPhase == RLGLPhase.Green)
                {
                    bool edge = false;
                    if (edging)
                    {
                        if (randomNumberGenerator.Next(1, 101) <= rlglPreferences.EdgeChance)
                        {
                            edge = true;
                        }
                    }

                    if (edge)
                    {
                        ShowPhase(RLGLPhase.Edge);
                        rlglVideoQueue.CurrentPhase = RLGLPhase.Edge;
                        RLGL_SwitchTimer.Stop();
                        RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinEdge, rlglPreferences.MaxEdge) * 1000;
                        RLGL_SwitchTimer.Start();
                    }
                    else
                    {
                        ShowPhase(RLGLPhase.Red);
                        rlglVideoQueue.CurrentPhase = RLGLPhase.Red;
                        RLGL_SwitchTimer.Stop();
                        RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed) * 1000;
                        RLGL_SwitchTimer.Start();
                    }
                }
                else if (rlglVideoQueue.CurrentPhase == RLGLPhase.Red)
                {
                    ShowPhase(RLGLPhase.Green);
                    rlglVideoQueue.CurrentPhase = RLGLPhase.Green;
                    RLGL_SwitchTimer.Stop();
                    RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen) * 1000;
                    RLGL_SwitchTimer.Start();
                }
                else
                {
                    bool green = false;
                    if (rlglPreferences.GreenAfterEdge)
                    {
                        green = randomNumberGenerator.Next(0, 2) < 1;
                    }

                    if (green)
                    {
                        ShowPhase(RLGLPhase.Green);
                        rlglVideoQueue.CurrentPhase = RLGLPhase.Green;
                        RLGL_SwitchTimer.Stop();
                        RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen) * 1000;
                        RLGL_SwitchTimer.Start();
                    }
                    else
                    {
                        ShowPhase(RLGLPhase.Red);
                        rlglVideoQueue.CurrentPhase = RLGLPhase.Red;
                        RLGL_SwitchTimer.Stop();
                        RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinRed, rlglPreferences.MaxRed) * 1000;
                        RLGL_SwitchTimer.Start();
                    }
                }
            }
            else
            {
                RLGL_CountdownTimer.Stop();
                currentEndingPhase = rlglVideoQueue.Ending.GetNextPhase();
                if (currentEndingPhase != null)
                {
                    ShowPhase(currentEndingPhase);
                    RLGL_SwitchTimer.Stop();
                    RLGL_SwitchTimer.Interval = currentEndingPhase.Duration * 1000;
                    RLGL_SwitchTimer.Start();

                    if (currentEndingPhase.Phase == RLGLPhase.Countdown)
                    {
                        currentEndingCountdown = currentEndingPhase.CountdownBegin;
                        RLGL_CountdownTimer.Interval = currentEndingPhase.CountdownStep * 1000;
                        RLGL_CountdownTimer.Start();
                    }
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

            ResizeAndPositionVolumeBar();
            volumeBar.Show(this);
            VLC_Control.MediaPlayer = mediaPlayer;
        }

        //Save the preferences to the disc.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            rlglPreferences.SavePreferencesToFile("Preferences.config");
        }

        //After the video is finished, reset the information.
        private void VLC_Control_EndReached(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => ResetRLGLInfo()));
        }

        //Near the end of the video stop random mode and show the ending phases.
        private void RLGL_VideoEndTimer_Tick(object sender, EventArgs e)
        {
            Console.Out.WriteLine("Video end phase started!");
            Console.Out.WriteLine("Videos remaining: " + rlglVideoQueue.VideosRemaining());
            RLGL_SwitchTimer.Stop();
            RLGL_VideoEndTimer.Stop();

            playEnding = true;
            currentEndingPhase = rlglVideoQueue.Ending.GetNextPhase();
            if (currentEndingPhase != null)
            {
                ShowPhase(currentEndingPhase);
                RLGL_SwitchTimer.Interval = currentEndingPhase.Duration * 1000;
                RLGL_SwitchTimer.Start();

                if (currentEndingPhase.Phase == RLGLPhase.Countdown)
                {
                    currentEndingCountdown = currentEndingPhase.CountdownBegin;
                    RLGL_CountdownTimer.Interval = currentEndingPhase.CountdownStep * 1000;
                    RLGL_CountdownTimer.Start();
                }
            }
        }

        //Calculates the duration of the video and sets the timer accordingly.
        private void SetVideoEndTimer()
        {
            Console.Out.WriteLine(rlglVideoQueue.Duration * (rlglVideoQueue.InitLoop+1));
            int duration = (int)(TimeSpan.FromMilliseconds(rlglVideoQueue.Duration * (rlglVideoQueue.InitLoop+1)) - (TimeSpan.FromSeconds(rlglVideoQueue.Ending.Duration + 2))).TotalMilliseconds;

            if (duration < 1)
            {
                MessageBox.Show("Current selected ending is " + Math.Abs(duration)/1000 + " seconds longer than the video! Session will end before ending has finished!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RLGL_VideoEndTimer.Interval = 1;
            }
            else
            {
                RLGL_VideoEndTimer.Interval = duration;
            }

            RLGL_VideoEndTimer.Start();
        }

        //Show the given phase to the user.
        private void ShowPhase(RLGLPhase phase)
        {
            rlglCurrentMedia.ResetCensorDimension();
            switch(phase)
            {
                case RLGLPhase.Green:
                    RLGL_Layout.BackColor = rlglPreferences.GreenLightColor;
                    volumeBar.SetBackgroundColor(rlglPreferences.GreenLightColor);
                    L_Text.BackColor = rlglPreferences.GreenLightColor;
                    L_Text.Text = "Stroke";                        


                    if(rlglPreferences.Metronome && randomNumberGenerator.Next(1,101) <= rlglPreferences.MetronomeChance)
                    {
                        L_Text.Text += " - follow the beat";
                        SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinBpm, rlglPreferences.MaxBpm+1));
                    }
                    else
                    {
                        StopMetronome();
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
                    volumeBar.SetBackgroundColor(rlglPreferences.RedLightColor);
                    L_Text.BackColor = rlglPreferences.RedLightColor;
                    StopMetronome();
                    L_Text.Text = "Hands off";
                    
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
                    volumeBar.SetBackgroundColor(rlglPreferences.EdgeColor);
                    L_Text.BackColor = rlglPreferences.EdgeColor;                   
                    L_Text.Text = "Edge!";

                    if (rlglPreferences.Metronome && randomNumberGenerator.Next(1, 101) <= rlglPreferences.MetronomeEdgeChance)
                    {
                        L_Text.Text += " - follow the beat";
                        SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinEdgeBpm, rlglPreferences.MaxEdgeBpm + 1));
                    }
                    else
                    {
                        StopMetronome();
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
            }            
        }

        //Show the given ending phase to the user.
        private void ShowPhase(RLGLEndingPhase phase)
        {
            rlglCurrentMedia.ResetCensorDimension();
            switch (phase.Phase)
            {
                case RLGLPhase.Green:
                    RLGL_Layout.BackColor = rlglPreferences.GreenLightColor;
                    volumeBar.SetBackgroundColor(rlglPreferences.GreenLightColor);
                    L_Text.BackColor = rlglPreferences.GreenLightColor;
                    L_Text.Text = phase.Message;                    

                    if (rlglPreferences.Metronome)
                    {
                        if(phase.EndingMetronome && randomNumberGenerator.Next(1, 101) <= rlglPreferences.MetronomeEndingChance)
                        {
                            SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinEndingBpm, rlglPreferences.MaxEndingBpm + 1));
                        }
                        else if(randomNumberGenerator.Next(1,101) <= rlglPreferences.MetronomeChance)
                        {
                            SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinBpm, rlglPreferences.MaxBpm + 1));
                        }
                        else
                        {
                            StopMetronome();
                        }
                    }
                    else
                    {
                        StopMetronome();
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
                    volumeBar.SetBackgroundColor(rlglPreferences.RedLightColor);
                    L_Text.BackColor = rlglPreferences.RedLightColor;
                    StopMetronome();
                    L_Text.Text = phase.Message;

                    if (rlglPreferences.Censoring &&
                        !rlglPreferences.CensorOnlyGreen &&
                        randomNumberGenerator.Next(1, 101) <= rlglPreferences.CensorChance)
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
                    volumeBar.SetBackgroundColor(rlglPreferences.EdgeColor);
                    L_Text.BackColor = rlglPreferences.EdgeColor;
                    L_Text.Text = phase.Message;

                    if (rlglPreferences.Metronome)
                    {
                        if (phase.EndingMetronome && randomNumberGenerator.Next(1, 101) <= rlglPreferences.MetronomeEndingChance)
                        {
                            SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinEndingBpm, rlglPreferences.MaxEndingBpm + 1));
                        }
                        else if(randomNumberGenerator.Next(1, 101) <= rlglPreferences.MetronomeEdgeChance)
                        {
                            SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinEdgeBpm, rlglPreferences.MaxEdgeBpm + 1));
                        }
                        else
                        {
                            StopMetronome();
                        }
                    }
                    else
                    {
                        StopMetronome();
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

                case RLGLPhase.Ruin:
                    RLGL_Layout.BackColor = rlglPreferences.RuinedOrgasmColor;
                    volumeBar.SetBackgroundColor(rlglPreferences.RuinedOrgasmColor);
                    L_Text.BackColor = rlglPreferences.RuinedOrgasmColor;
                    StopMetronome();
                    L_Text.Text = phase.Message;

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

                case RLGLPhase.Countdown:
                    if (phase.CountdownEdge)
                    {
                        RLGL_Layout.BackColor = rlglPreferences.EdgeColor;
                        volumeBar.SetBackgroundColor(rlglPreferences.EdgeColor);
                        L_Text.BackColor = rlglPreferences.EdgeColor;
                    }
                    else
                    {
                        RLGL_Layout.BackColor = rlglPreferences.GreenLightColor;
                        volumeBar.SetBackgroundColor(rlglPreferences.GreenLightColor);
                        L_Text.BackColor = rlglPreferences.GreenLightColor;
                    }

                    if (phase.Message.Length > 0)
                    {
                        L_Text.Text = phase.Message + ": " + phase.CountdownBegin;
                    }
                    else
                    {
                        L_Text.Text = phase.CountdownBegin.ToString();
                    }

                    if (rlglPreferences.Metronome) 
                    {
                        if (phase.EndingMetronome)
                        {
                            if (randomNumberGenerator.Next(1, 101) <= rlglPreferences.MetronomeEndingChance)
                            {
                                SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinEndingBpm, rlglPreferences.MaxEndingBpm + 1));
                            }
                            else
                            {
                                StopMetronome();
                            }
                        }
                        else if(phase.CountdownEdge)
                        {
                            if(randomNumberGenerator.Next(1, 101) <= rlglPreferences.MetronomeEdgeChance)
                            {
                                SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinEdgeBpm, rlglPreferences.MaxEdgeBpm + 1));
                            }
                            else
                            {
                                StopMetronome();
                            }
                        }
                        else if(randomNumberGenerator.Next(1, 101) <= rlglPreferences.MetronomeChance)
                        {
                            SetMetronome(randomNumberGenerator.Next(rlglPreferences.MinBpm, rlglPreferences.MaxBpm + 1));
                        }
                        else
                        {
                            StopMetronome();
                        }
                    }
                    else
                    {
                        StopMetronome();
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
            }
        }

        // Play the next video in the currently selected queue
        private void PlayNextVideo(bool sessionStart)
        {
            (Media, string) nextVid = rlglVideoQueue.GetNextVideo();
            VLC_Control.MediaPlayer.Media = nextVid.Item1;
            
            rlglCurrentMedia = new RLGLCurrentMedia(nextVid.Item1, nextVid.Item2);

            for (int i = 0; i < censorbars.Count; i++)
            {
                censorbars[i].Close();
            }

            censorbars.Clear();

            rlglCensorData = RLGLCensorData.ReadFromFile(nextVid.Item2);
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

            VLC_Control.MediaPlayer.Play();

            if (sessionStart)
            {
                ShowPhase(rlglVideoQueue.CurrentPhase);

                RLGL_SwitchTimer.Stop();
                RLGL_SwitchTimer.Interval = randomNumberGenerator.Next(rlglPreferences.MinGreen, rlglPreferences.MaxGreen) * 1000;
                RLGL_SwitchTimer.Start();

            }
        }

        //Reset the visible interface. 
        private void ResetRLGLInfo()
        {  
            if (rlglVideoQueue.VideosRemaining() > 0)
            {
                PlayNextVideo(false);
            }
            else
            {
                RLGL_Layout.BackColor = SystemColors.Control;
                volumeBar.SetBackgroundColor(SystemColors.Control);
                L_Text.BackColor = SystemColors.Control;
                L_Text.Text = "";
                StopMetronome();
                RLGL_SwitchTimer.Stop();
                RLGL_VideoEndTimer.Stop();
                RLGL_Censor.Stop();
                RLGL_CountdownTimer.Stop();
                playEnding = false;
                currentEndingCountdown = -1;
                currentEndingPhase = null;

                edging = false;
                StopEdging();
                endSessionToolStripMenuItem.Enabled = false;

                if (rlglVideoQueue.Ending != null)
                {
                    rlglVideoQueue.Ending.ResetPhasePointer();
                }
                rlglVideoQueue.ResetQueue();

                RLGL_HideVolumeBar.Stop();
                if(!volumeBar.Visible)
                {
                    volumeBar.Show(this);
                    this.Focus();
                }
                RLGL_Timer.Stop();
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
                Dictionary<int, CensorbarInfo<PointF>> relativePositions = rlglCensorData.GetAllCensorPositionsAndSizes((int)(rlglCensorData.Duration.TotalSeconds * VLC_Control.MediaPlayer.Position));
                
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

            this.Focus();
        }

        //Play the metronome-sound.
        private void RLGL_Metronome_Tick(object sender, EventArgs e)
        {
            metronome.Play();
        }

        //Change the volume of the currently played media.
        public void SetVolume(int volume)
        {
            VLC_Control.MediaPlayer.Volume = volume;            
        }

        //Show an about dialog.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDlg aboutDlg = new AboutDlg();

            aboutDlg.ShowDialog();
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

            ResizeAndPositionVolumeBar();
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
                    Dictionary<int, CensorbarInfo<PointF>> relativePositions = rlglCensorData.GetAllCensorPositionsAndSizes((float)(rlglCensorData.Duration.TotalSeconds * VLC_Control.MediaPlayer.Position));

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
            RLGL_Layout.RowStyles[3].Height = (float)rlglPreferences.BottomBorder/100.0f * 50;
            RLGL_Layout.ColumnStyles[0].Width = (float)rlglPreferences.LeftBorder/100.0f * 50;
            RLGL_Layout.ColumnStyles[2].Width = (float)rlglPreferences.RightBorder/100.0f * 50;
        }

        //Enable edging phases.
        private void RLGL_EdgingTimer_Tick(object sender, EventArgs e)
        {
            edging = true;
            RLGL_EdgingTimer.Stop();
        }

        private void RLGL_Timer_Tick(object sender, EventArgs e)
        {
            L_TimePassed.Text = (DateTime.Now - sessionStart).ToString(@"hh\:mm\:ss");
        }

        /*
         * Starts the current loaded queue.
         * If the queue has no videos left or no videos at all, nothing happens.
         */ 
        private void StartQueue()
        {
            if (rlglVideoQueue.VideosRemaining() > 0)
            {
                endSessionToolStripMenuItem.Enabled = true;
                restartSessionToolStripMenuItem.Enabled = true;
                saveSessionToolStripMenuItem.Enabled = true;
                sessionStart = DateTime.Now;

                RLGLEnding ending = null;
                                
                int selector = randomNumberGenerator.Next(1, 100);
                int currentOffset = 0;
                for (int i = 0; i < rlglPreferences.Ending.Count; i++)
                {
                    if (rlglPreferences.Ending[i].Enabled && rlglPreferences.Ending[i].Ending.Duration * 1000 <= rlglVideoQueue.Duration)
                    {
                        if (selector <= rlglPreferences.Ending[i].Chance + currentOffset)
                        {
                            ending = rlglPreferences.Ending[i].Ending;
                            break;
                        }
                        else
                        {
                            currentOffset += rlglPreferences.Ending[i].Chance;
                        }
                    }
                }

                if(ending == null)
                {
                    Console.Out.WriteLine("No ending with shorter duration than playlist found! Choosing the shortest possible...");
                    int shortestDuration = int.MaxValue;

                    for (int i = 0; i < rlglPreferences.Ending.Count; i++)
                    {
                        if (rlglPreferences.Ending[i].Enabled)
                        {
                            if(rlglPreferences.Ending[i].Ending.Duration < shortestDuration)
                            {
                                ending = rlglPreferences.Ending[i].Ending;
                                shortestDuration = ending.Duration;
                            }
                        }
                    }
                }
                
                Console.Out.WriteLine("Decided for ending: " + ending.EndingName);
                rlglVideoQueue.Ending = ending;

                SetVideoEndTimer();

                edging = false;
                if (rlglPreferences.Edging)
                {
                    SetEdging();
                }

                PlayNextVideo(true);

                if (volumeBar.Visible)
                {
                    volumeBar.Hide();
                }
                 
                RLGL_Timer.Start();
            }
        }

        //Cancel active session and return to default screen.
        private void endSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rlglVideoQueue != null)
            {
                VLC_Control.MediaPlayer.Stop();
                rlglVideoQueue.CancelQueue();
                ResetRLGLInfo();
            }
        }

        //Toggle full screen on pressing F
        private void VLC_Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                this.WindowState = FormWindowState.Normal;

                MainMenu.Visible = fullscreen;
                this.MaximizeBox = fullscreen;
                this.WindowState = fullscreen ? FormWindowState.Normal : FormWindowState.Maximized;
                this.FormBorderStyle = fullscreen ? FormBorderStyle.Sizable : FormBorderStyle.None;
                fullscreen = !fullscreen;
            }
        }

        //Set the currently in the dialog displayed rlglpreferences as new ones.
        public void UpdateRLGLPreferences()
        {
            rlglPreferences.SavePreferences(preferencesDlg);
            RLGL_EdgingTimer.Interval = rlglPreferences.EdgingWarmup * 1000;
            UpdateRLGLLayoutSizes();
        }

        //Show the volumebar when the mouse hovers over the bottom text.
        private void L_Text_MouseHover(object sender, EventArgs e)
        {
            ShowVolumeBar();
        }

        //If the volumebar is not visible, show it.
        private void ShowVolumeBar()
        {
            if (!volumeBar.Visible)
            {
                volumeBar.Show(this);
                RLGL_HideVolumeBar.Start();
            }
        }

        //Calculate the correct dimensions and position of the volumebar
        private void ResizeAndPositionVolumeBar()
        {
            Point pos = RLGL_Layout.PointToScreen(Point.Empty);
            volumeBar.SetBounds(pos.X, pos.Y + RLGL_Layout.Height - 50, volumeBar.Width, 50);
        }

        //Reposition the volumebar when the window moves.
        private void RLGLPlayer_Move(object sender, EventArgs e)
        {
            ResizeAndPositionVolumeBar();
        }

        //Only if the user does not interact with the volumebar it will be hidden after 3 seconds.
        private void RLGL_HideVolumeBar_Tick(object sender, EventArgs e)
        {
            if(volumeBar.Visible && !volumeBar.MouseOnControl)
            {
                volumeBar.Hide();
                RLGL_HideVolumeBar.Stop();
            }
        }

        private void RLGL_CountdownTimer_Tick(object sender, EventArgs e)
        {
            currentEndingCountdown--;

            if (currentEndingPhase.Message.Length > 0)
            {
                L_Text.Text = currentEndingPhase.Message + ": " + currentEndingCountdown.ToString();
            }
            else
            {
                L_Text.Text = currentEndingCountdown.ToString();
            }

            if(currentEndingCountdown <= currentEndingPhase.CountdownEnd)
            {
                RLGL_CountdownTimer.Stop();
            }
        }

        private void VLC_Control_Playing(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => FocusCensorbars()));
        }

        private void FocusCensorbars()
        {
            if (censoring)
            {
                ShowCensoring(false);
            }
        }

        private void restartSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rlglVideoQueue != null)
            {
                VLC_Control.MediaPlayer.Stop();
                rlglVideoQueue.CancelQueue();
                ResetRLGLInfo();
            }

            StartQueue();
        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rlglVideoQueue != null)
            {
                if (SaveQueueDlg.ShowDialog() == DialogResult.OK)
                {
                    rlglVideoQueue.SaveVideoQueue(SaveQueueDlg.FileName);
                }
            }
        }
    }
}
