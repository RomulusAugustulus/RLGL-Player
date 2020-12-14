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
using System.Drawing;
using System.Windows.Forms;

namespace RLGL_Player
{
    /*
     * This is a simple control to encapsulate a checkbox with a color.
     */ 
    public partial class CensorbarSetting : UserControl
    {
        private int id;

        /*
         * The displayed text on this control,
         */ 
        public override string Text { get => RB_CensorbarSettings.Text; set => RB_CensorbarSettings.Text = value; }

        /*
         * The color that is selected by this control.
         */ 
        public Color SelectedColor { get => P_CensorbarSettingsColor.BackColor; set => P_CensorbarSettingsColor.BackColor = value; }

        /*
         * The id that this control is attached to.
         */ 
        public int Id { get => id; set => id = value; }

        /*
         * Sets the state of the checkbox of this control.
         */ 
        public bool Checked { get => RB_CensorbarSettings.Checked; set => RB_CensorbarSettings.Checked = value; }

        public delegate void ColorChangeClickHandler(object sender, EventArgs e);

        /*
         * Event is fired when the user clicks on the colored rectangle of the control.
         */ 
        public event ColorChangeClickHandler ColorChangeClick;

        public delegate void CheckedChangedHandler(object sender, CheckedChangedEventArgs e);

        /*
         * Event is fired when the user changes the state of the checkbox.
         */ 
        public event CheckedChangedHandler CheckedChanged;

        public CensorbarSetting()
        {
            InitializeComponent();
        }

        private void P_CensorbarSettingsColor_Click(object sender, EventArgs e)
        {
            ColorChangeClick(this, e);
        }

        private void RB_CensorbarSettings_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged(this, new CheckedChangedEventArgs(RB_CensorbarSettings.Checked));
        }
    }

    /*
     * Checked changed events transport the current state of the checkbox.
     */ 
    public class CheckedChangedEventArgs : System.EventArgs
    {
        private bool isChecked;

        public bool IsChecked { get => isChecked; }

        public CheckedChangedEventArgs(bool check)
        {
            this.isChecked = check;
        }
    }
}
