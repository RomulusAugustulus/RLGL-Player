﻿/*
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RLGL_Player
{
    public partial class RLGLPlayingQueueDlg : Form
    {
        private List<(string, string)> videos;
        private RLGLVideoQueue videoQueue;
        private bool ignoreQueuePreferences;
        public RLGLVideoQueue VideoQueue { get => videoQueue; }
        public bool IgnoreQueuePreferences { get => ignoreQueuePreferences; }

        public RLGLPlayingQueueDlg()
        {
            InitializeComponent();
            EnableControls(false);
            videoQueue = new RLGLVideoQueue();
            videos = new List<(string, string)>();
            L_FullPath.Text = "";
            ignoreQueuePreferences = true;
        }

        //Changes the appearance of the dialog to alter an existing queue.
        public void InitCustomizationDlg(RLGLVideoQueue queue)
        {
            CB_IgnorePlaylistPreferences.Visible = true;
            LB_Queue.Items.Clear();

            (int, List<string>) loadedQueue = queue.GetRLGLVideoQueue();
            NUD_Loop.Value = loadedQueue.Item1;

            for(int i=0;i<loadedQueue.Item2.Count;i++)
            {
                string filename = Path.GetFileName(loadedQueue.Item2[i]);
                videos.Add((filename, loadedQueue.Item2[i]));
                LB_Queue.Items.Add(filename);
            }
        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            if(OpenVideoDlg.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < OpenVideoDlg.FileNames.Length; i++)
                {
                    string filename = Path.GetFileName(OpenVideoDlg.FileNames[i]);
                    videos.Add((filename, OpenVideoDlg.FileNames[i]));
                    LB_Queue.Items.Add(filename);
                }
            }
        }

        private void B_Up_Click(object sender, EventArgs e)
        {
            MoveInQueue(-1);
        }

        private void B_Down_Click(object sender, EventArgs e)
        {
            MoveInQueue(1);
        }

        private void B_Delete_Click(object sender, EventArgs e)
        {
            videos.RemoveAt(LB_Queue.SelectedIndex);
            LB_Queue.Items.RemoveAt(LB_Queue.SelectedIndex);
            LB_Queue.SelectedIndex = -1;
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            if(NUD_Loop.Value != 0)
            {
                videoQueue = new RLGLVideoQueue((int)NUD_Loop.Value);
            }

            if (CB_Shuffle.Checked)
            {
                while (videos.Count != 0)
                {
                    int vid = rand.Next(videos.Count);
                    videoQueue.AddVideo(videos[vid].Item2);
                    videos.RemoveAt(vid);
                }
            }
            else
            {
                for (int i = 0; i < videos.Count; i++)
                {
                    videoQueue.AddVideo(videos[i].Item2);
                }
            }

            if(!CB_IgnorePlaylistPreferences.Checked)
            {
                ignoreQueuePreferences = false;
            }
        }

        private void LB_Queue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LB_Queue.SelectedIndex == -1)
            {
                L_FullPath.Text = "";
                EnableControls(false);
            }
            else
            {
                L_FullPath.Text = videos[LB_Queue.SelectedIndex].Item2;
                EnableControls(true);
            }
        }

        private void EnableControls(bool enable)
        {
            B_Up.Enabled = enable;
            B_Down.Enabled = enable;
            B_Delete.Enabled = enable;
        }

        // Moves the currently selected index of the listbox by change amount.
        private void MoveInQueue(int change)
        {
            int selIndex = LB_Queue.SelectedIndex;
            string elem = (string)LB_Queue.Items[selIndex];
            LB_Queue.Items.RemoveAt(selIndex);
            (string, string) vidElem = videos[selIndex];
            videos.RemoveAt(selIndex);

            if(selIndex + change < 0)
            {
                LB_Queue.Items.Insert(0, elem);
                videos.Insert(0, vidElem);
                LB_Queue.SelectedIndex = 0;
            }
            else if(selIndex + change >= LB_Queue.Items.Count)
            {
                LB_Queue.Items.Add(elem);
                videos.Add(vidElem);
                LB_Queue.SelectedIndex = LB_Queue.Items.Count - 1;
            }
            else
            {
                LB_Queue.Items.Insert(selIndex + change, elem);
                videos.Insert(selIndex + change, vidElem);
                LB_Queue.SelectedIndex = selIndex + change;
            }
        }
    }
}
