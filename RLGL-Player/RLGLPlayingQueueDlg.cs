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
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RLGL_Player
{
    public partial class RLGLPlayingQueueDlg : Form
    {
        private enum CreatingFlag { None, StartSession, SaveList, LoadList }
        private WorkingDlg workingDlg;
        private List<(string, string)> videos;
        private RLGLPreferences prefs;
        private RLGLVideoQueue videoQueue;
        private CreatingFlag flag;
        public RLGLVideoQueue VideoQueue { get => videoQueue; }
        public LibVLC LibVLC { get; set; }

        public RLGLPlayingQueueDlg(LibVLC libVLC, RLGLPreferences prefs)
        {
            InitializeComponent();
            EnableControls(false);
            LibVLC = libVLC;
            videoQueue = new RLGLVideoQueue(libVLC);
            this.prefs = prefs;
            videoQueue.Prefs = prefs;
            videos = new List<(string, string)>();
            L_FullPath.Text = "";
            workingDlg = new WorkingDlg();
            flag = CreatingFlag.None;
        }

        //Changes the appearance of the dialog to alter an existing queue.
        public void InitCustomizationDlg(RLGLVideoQueue queue)
        {
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
                    B_SavePlaylist.Enabled = true;
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
            DeleteSelectedMedia();
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            flag = CreatingFlag.StartSession;
            CreateRLGLVideoQueue();
        }

        private void LB_Queue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LB_Queue.SelectedIndex == -1)
            {
                L_FullPath.Text = "";
                EnableControls(false);
                PB_Preview.Image = null;
            }
            else
            {
                L_FullPath.Text = videos[LB_Queue.SelectedIndex].Item2;
                EnableControls(true);
                string ext = Path.GetExtension(videos[LB_Queue.SelectedIndex].Item2);
                if (ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".png") || ext.Equals(".bmp") || ext.Equals(".webp"))
                {
                    PB_Preview.Image = Bitmap.FromFile(videos[LB_Queue.SelectedIndex].Item2);
                }
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

        private void CreateRLGLVideoQueue()
        {
            this.DialogResult = DialogResult.None;
            workingDlg.InitProgressbar();
            workingDlg.Show(this);
            BG_CreatePlaylist.RunWorkerAsync();

        }

        private void B_LoadPlaylist_Click(object sender, EventArgs e)
        {
            bool cancelLoad = false;
            if(LB_Queue.Items.Count != 0)
            {
                if(MessageBox.Show("Already added videos will be removed when loading an existing playlist.\nDo you want to load a playlist?","Added videos found",MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    cancelLoad = true;
                }
            }

            if(!cancelLoad)
            {
                if (OpenQueueDlg.ShowDialog() == DialogResult.OK)
                {
                    flag = CreatingFlag.LoadList;
                    workingDlg.InitProgressbar();
                    workingDlg.SetMarquee(true);
                    workingDlg.Show(this);
                    BG_CreatePlaylist.RunWorkerAsync();
                }
            }
        }

        private void B_SavePlaylist_Click(object sender, EventArgs e)
        {
            if (SaveQueueDlg.ShowDialog() == DialogResult.OK)
            {
                flag = CreatingFlag.SaveList;
                CreateRLGLVideoQueue();                
            }
        }

        private void BG_CreatePlaylist_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (flag != CreatingFlag.LoadList)
            {
                Random rand = new Random();
                float progress = 0.0f;
                float progressIncrease = 100.0f / videos.Count;
                BG_CreatePlaylist.ReportProgress((int)progress);

                if (NUD_Loop.Value != 0)
                {
                    videoQueue = new RLGLVideoQueue(LibVLC, (int)NUD_Loop.Value);
                    videoQueue.Prefs = prefs;
                }

                if (CB_Shuffle.Checked)
                {
                    while (videos.Count != 0)
                    {
                        int vid = rand.Next(videos.Count);
                        videoQueue.AddVideo(videos[vid].Item2);
                        videos.RemoveAt(vid);

                        progress += progressIncrease;
                        BG_CreatePlaylist.ReportProgress(Math.Min(100, (int)progress));
                    }
                }
                else
                {
                    for (int i = 0; i < videos.Count; i++)
                    {
                        videoQueue.AddVideo(videos[i].Item2);

                        progress += progressIncrease;
                        BG_CreatePlaylist.ReportProgress(Math.Min(100, (int)progress));
                    }
                }
            }
            else
            {
                videoQueue = new RLGLVideoQueue(LibVLC);
                videoQueue.Prefs = prefs;
                (bool, string) loadedQueue = videoQueue.LoadVideoQueue(OpenQueueDlg.FileName, true);
                e.Result = loadedQueue;
            }
        }

        private void BG_CreatePlaylist_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            workingDlg.SetProgress(e.ProgressPercentage);
        }

        private void BG_CreatePlaylist_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            workingDlg.Hide();

            if (flag == CreatingFlag.StartSession)
            {
                flag = CreatingFlag.None;
                this.DialogResult = DialogResult.OK;
            }
            else if(flag == CreatingFlag.SaveList)
            {
                flag = CreatingFlag.None;
                videoQueue.SaveVideoQueue(SaveQueueDlg.FileName);
                MessageBox.Show("Saved playlist.", "Save");
            }
            else if(flag == CreatingFlag.LoadList)
            {
                (bool, string) loadedQueue = ((bool, string)) e.Result;
                flag = CreatingFlag.None;
                workingDlg.SetMarquee(false);

                if (loadedQueue.Item1)
                {
                    InitCustomizationDlg(videoQueue);

                    if (loadedQueue.Item2.Length != 0)
                    {
                        MessageBox.Show(loadedQueue.Item2, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    B_SavePlaylist.Enabled = true;
                }
                else
                {
                    MessageBox.Show(loadedQueue.Item2, "Error");
                }
            }
        }

        private void LB_Queue_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete && LB_Queue.SelectedIndex != -1)
            {
                DeleteSelectedMedia();
            }
        }

        private void DeleteSelectedMedia()
        {
            int selIndex = LB_Queue.SelectedIndex;
            videos.RemoveAt(selIndex);
            LB_Queue.Items.RemoveAt(selIndex);

            if (LB_Queue.Items.Count == 0)
            {
                LB_Queue.SelectedIndex = -1;
                B_SavePlaylist.Enabled = false;
            }
            else if (LB_Queue.Items.Count <= selIndex)
            {
                LB_Queue.SelectedIndex = LB_Queue.Items.Count - 1;
            }
            else
            {
                LB_Queue.SelectedIndex = selIndex;
            }
        }
    }
}
