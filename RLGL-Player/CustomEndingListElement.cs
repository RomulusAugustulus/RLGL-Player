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
     * Encapsulates functionality to handle enable/disable custom endings.
     * Sets also a chance how often they will appear.
     */ 
    public partial class CustomEndingListElement : UserControl
    {
        private bool active = false;
        private int limit = 0;
        //Are currently made changes forced by the user?
        public bool IsActive { get => active; set => active = value; }
        //Gets if this ending should be used in sessions or not
        public bool IncludeElement { get => CB_Enabled.Checked; set => CB_Enabled.Checked = value; }
        //Gets if the chance can be influenced by other endings.
        public bool LockChance { get => CB_LockChance.Checked; set => CB_LockChance.Checked = value; }
        //This is the chance that the ending will be chosen. It's limited to the range of 0-100.
        public int Chance
        {
            get => ETB_Chance.Value;
            set
            {
                int v = value;
                v = Math.Min(Math.Max(ETB_Chance.Minimum, Math.Min(v, ETB_Chance.Maximum)), limit);                
                ETB_Chance.Value = v;
            }
        }

        //If this is set to something below 100 the actual chance can not exceed this limit.
        public int Limit 
        { 
            get
            {
                return limit;
            }

            set
            {
                int v = value;
                v = Math.Max(ETB_Chance.Minimum, Math.Min(v, ETB_Chance.Maximum));
                limit = v;

                if(Chance > limit)
                {
                    Chance = limit;
                }
            } 
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text { get => B_EndingElement.Text; set => B_EndingElement.Text = value; }

        public delegate void EndingElementClickHandler(object sender, EventArgs e);
        public delegate void EndingElementEnabledHandler(object sender, EventArgs e);
        public delegate void EndingElementLockedHandler(object sender, EventArgs e);
        public delegate void EndingElementValueHandler(object sender, EventArgs e);

        /*
         * Event is fired when the user clicks the button with the elements name.
         */
        public event EndingElementClickHandler EndingElementClick;
        /*
         * Event is fired when the user changes the enable checkbox's state.
         */
        public event EndingElementEnabledHandler EndingElementEnabledChanged;
        /*
         * Event is fired when the user changes the lock checkbox's state.
         */
        public event EndingElementLockedHandler EndingElementLockedChanged;
        /*
         * Event is fired when the user changes the value of the element.
         */
        public event EndingElementValueHandler EndingElementValueChanged;

        public CustomEndingListElement()
        {
            InitializeComponent();
            limit = ETB_Chance.Maximum;
        }

        private void B_EndingElement_Click(object sender, EventArgs e)
        {
            if (EndingElementClick != null)
            {
                EndingElementClick(this, e);
            }
        }

        private void CB_Enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (EndingElementEnabledChanged != null)
            {
                EndingElementEnabledChanged(this, e);
            }
        }

        private void CB_LockChance_CheckedChanged(object sender, EventArgs e)
        {
            if (EndingElementLockedChanged != null)
            {
                EndingElementLockedChanged(this, e);
            }
        }

        private void ETB_Chance_ExtendedTrackBarValueChanged(object sender, EventArgs e)
        {
            if (EndingElementValueChanged != null)
            {
                EndingElementValueChanged(this, e);
            }
        }

        private void CustomEndingListElement_Enter(object sender, EventArgs e)
        {
            active = true;
        }

        private void CustomEndingListElement_Leave(object sender, EventArgs e)
        {
            active = false;
        }
    }
}
