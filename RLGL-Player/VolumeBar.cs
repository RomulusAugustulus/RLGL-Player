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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RLGL_Player
{
    /*
     * The VolumeBar is a special transparent dialog window that shows
     * it's component only if someone hovers over another control.
     */ 
    public partial class VolumeBar : Form
    {
        private int lastVolume;
        private bool mouseOnControl;
        public bool MouseOnControl { get => mouseOnControl; }

        public VolumeBar()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Crimson;

            lastVolume = 100;
            PB_VolumeImageOff.Visible = false;
            PB_VolumeImageLoud.Visible = true;
            mouseOnControl = false;
        }

        public void SetBackgroundColor(Color backColor)
        {
            this.BackColor = backColor;
            TB_Volume.BackColor = backColor;
            PB_VolumeImageLoud.BackColor = backColor;
            PB_VolumeImageOff.BackColor = backColor;
        }

        private void TB_Volume_ValueChanged(object sender, System.EventArgs e)
        {
            if(TB_Volume.Value == 0)
            {
                PB_VolumeImageLoud.Visible = false;
                PB_VolumeImageOff.Visible = true;
            }
            else
            {
                PB_VolumeImageOff.Visible = false;
                PB_VolumeImageLoud.Visible = true;
            }

            RLGLPlayer mainForm = (RLGLPlayer)this.Owner;
            mainForm.SetVolume(TB_Volume.Value);
        }

        private void VolumeBar_MouseEnter(object sender, System.EventArgs e)
        {
            mouseOnControl = true;
        }

        private void VolumeBar_MouseLeave(object sender, System.EventArgs e)
        {
            mouseOnControl = false;
        }

        private void TB_Volume_MouseEnter(object sender, System.EventArgs e)
        {
            mouseOnControl = true;
        }

        private void TB_Volume_MouseLeave(object sender, System.EventArgs e)
        {
            mouseOnControl = false;
        }

        private void PB_VolumeImageOff_MouseEnter(object sender, System.EventArgs e)
        {
            mouseOnControl = true;
        }

        private void PB_VolumeImageOff_MouseLeave(object sender, System.EventArgs e)
        {
            mouseOnControl = false;
        }

        private void PB_VolumeImageLoud_MouseEnter(object sender, System.EventArgs e)
        {
            mouseOnControl = true;
        }

        private void PB_VolumeImageLoud_MouseLeave(object sender, System.EventArgs e)
        {
            mouseOnControl = false;
        }

        private void PB_VolumeImageOff_Click(object sender, System.EventArgs e)
        {
            TB_Volume.Value = lastVolume;
        }

        private void PB_VolumeImageLoud_Click(object sender, System.EventArgs e)
        {
            lastVolume = Math.Max(1, TB_Volume.Value);
            TB_Volume.Value = 0;
        }
    }
}
