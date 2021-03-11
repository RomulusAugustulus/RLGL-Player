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
using System.Windows.Forms;

namespace RLGL_Player
{
    public partial class RLGLPlayingQueueDlg : Form
    {
        private RLGLVideoQueue videoQueue;
        public RLGLVideoQueue VideoQueue { get => videoQueue; }

        public RLGLPlayingQueueDlg()
        {
            InitializeComponent();
            EnableControls(false);
            videoQueue = new RLGLVideoQueue();
        }

        private void L_Load_Click(object sender, EventArgs e)
        {
            if(OpenVideoDlg.ShowDialog() == DialogResult.OK)
            {
                LB_Queue.Items.AddRange(OpenVideoDlg.FileNames);
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
            LB_Queue.Items.RemoveAt(LB_Queue.SelectedIndex);
            LB_Queue.SelectedIndex = -1;
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LB_Queue.Items.Count; i++)
            {
                videoQueue.AddVideo((string)LB_Queue.Items[i]);
            }
        }

        private void LB_Queue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LB_Queue.SelectedIndex == -1)
            {
                EnableControls(false);
            }
            else
            {
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

            if(selIndex + change < 0)
            {
                LB_Queue.Items.Insert(0, elem);
            }
            else if(selIndex + change >= LB_Queue.Items.Count)
            {
                LB_Queue.Items.Add(elem);
            }
            else
            {
                LB_Queue.Items.Insert(selIndex + change, elem);
            }
        }
    }
}
