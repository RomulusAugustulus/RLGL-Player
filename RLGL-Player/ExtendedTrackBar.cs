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
using System.ComponentModel;
using System.Windows.Forms;

namespace RLGL_Player
{
    /*
     * Extends a Trackbar with a number field to allow more precise editing.
     * Has also a label and a tooltip.
     */ 
    public partial class ExtendedTrackBar : UserControl
    {
        private string customTooltip;
        private int value;

        public delegate void ExtendedTrackBarValueHandler(object sender, EventArgs e);

        /*
         * Event is fired when the user changes the value of the trackbar.
         */
        public event ExtendedTrackBarValueHandler ExtendedTrackBarValueChanged;

        //The minimal value the trackbar can have.
        public int Minimum
        {
            get => TB_ExtendedTrackBar.Minimum;
            set
            {
                TB_ExtendedTrackBar.Minimum = value;
                NUD_ShowValue.Minimum = value;
            }
        }

        //The maximal value the trackbar can have.
        public int Maximum 
        { 
            get => TB_ExtendedTrackBar.Maximum; 
            set 
            { 
                TB_ExtendedTrackBar.Maximum = value; 
                NUD_ShowValue.Maximum = value; 
            }
        }

        //The number of ticks between two markers on the trackbar.
        public int TickFrequency 
        { 
            get => TB_ExtendedTrackBar.TickFrequency; 
            set => TB_ExtendedTrackBar.TickFrequency = value; 
        }

        //The current value of the trackbar. 
        public int Value 
        { 
            get => this.value; 
            set 
            {
                this.value = Math.Max(TB_ExtendedTrackBar.Minimum, Math.Min(TB_ExtendedTrackBar.Maximum, value));
                TB_ExtendedTrackBar.Value = TB_ExtendedTrackBar.Maximum + TB_ExtendedTrackBar.Minimum - this.value;
                NUD_ShowValue.Value = this.value;
            } 
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text 
        { 
            get => L_Label.Text; 
            set => L_Label.Text = value; 
        }

        //The tooltip displayed while hovering above the control.
        public string ToolTip
        {
            get => customTooltip;
            set
            {
                customTooltip = value;
                ExtendedTrackBarTooltip.SetToolTip(L_Label, customTooltip);
                ExtendedTrackBarTooltip.SetToolTip(TB_ExtendedTrackBar, customTooltip);
                ExtendedTrackBarTooltip.SetToolTip(NUD_ShowValue, customTooltip);
            }
        }

        public ExtendedTrackBar()
        {
            InitializeComponent();
        }

        private void TB_ExtendedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            value = TB_ExtendedTrackBar.Maximum + TB_ExtendedTrackBar.Minimum - TB_ExtendedTrackBar.Value;
            NUD_ShowValue.Value = value;
            if (ExtendedTrackBarValueChanged != null)
            {
                ExtendedTrackBarValueChanged(this, e);
            }
        }

        private void NUD_ShowValue_ValueChanged(object sender, EventArgs e)
        {
            value = (int)NUD_ShowValue.Value;
            TB_ExtendedTrackBar.Value = TB_ExtendedTrackBar.Maximum + TB_ExtendedTrackBar.Minimum - value;
        }
    }
}
