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
    /*
     * Show a dialog that let's the user set all of the relevant settings.
     */ 
    public partial class PreferencesDlg : Form
    {
        public PreferencesDlg()
        {
            InitializeComponent();
        }

        //Minimum value can not be higher than maximal value.
        private void NUD_MinGreen_ValueChanged(object sender, EventArgs e)
        {
            if(NUD_MaxGreen.Value < NUD_MinGreen.Value)
            {
                NUD_MaxGreen.Value = NUD_MinGreen.Value;
            }
        }

        //Maximal value can not be lower than minimal value.
        private void NUD_MaxGreen_ValueChanged(object sender, EventArgs e)
        {
            if(NUD_MinGreen.Value > NUD_MaxGreen.Value)
            {
                NUD_MinGreen.Value = NUD_MaxGreen.Value;
            }
        }

        //Minimum value can not be higher than maximal value.
        private void NUD_MinRed_ValueChanged(object sender, EventArgs e)
        {
            if (NUD_MaxRed.Value < NUD_MinRed.Value)
            {
                NUD_MaxRed.Value = NUD_MinRed.Value;
            }
        }

        //Maximal value can not be lower than minimal value.
        private void NUD_MaxRed_ValueChanged(object sender, EventArgs e)
        {
            if (NUD_MinRed.Value > NUD_MaxRed.Value)
            {
                NUD_MinRed.Value = NUD_MaxRed.Value;
            }
        }

        //Get the color from the color dialog.
        private void P_GreenLightColor_Click(object sender, EventArgs e)
        {
            if(ColorPicker.ShowDialog() == DialogResult.OK)
            {
                P_GreenLightColor.BackColor = ColorPicker.Color;
            }
        }

        //Get the color from the color dialog.
        private void P_RedLightColor_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                P_RedLightColor.BackColor = ColorPicker.Color;
            }
        }

        //Enable/Disable settings for metronome usage
        private void CB_Metronome_CheckedChanged(object sender, EventArgs e)
        {
            bool check = CB_Metronome.Checked;
            
            NUD_MinMetronome.Enabled = check;
            NUD_MaxMetronome.Enabled = check;
            TB_MetronomeChance.Enabled = check;
            
        }

        //Minimum value can not be higher than maximal value.
        private void NUD_MinMetronome_ValueChanged(object sender, EventArgs e)
        {
            if (NUD_MaxMetronome.Value < NUD_MinMetronome.Value)
            {
                NUD_MaxMetronome.Value = NUD_MinMetronome.Value;
            }
        }

        //Maximal value can not be lower than minimal value.
        private void NUD_MaxMetronome_ValueChanged(object sender, EventArgs e)
        {
            if (NUD_MinMetronome.Value > NUD_MaxMetronome.Value)
            {
                NUD_MinMetronome.Value = NUD_MaxMetronome.Value;
            }
        }

        //Get the color from the color dialog.
        private void P_CensorColor_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                P_EdgeLightColor.BackColor = ColorPicker.Color;
            }
        }

        //Get the path from the folderbrowserdialog.
        private void B_CensorPath_Click(object sender, EventArgs e)
        {
            if(FolderSelector.ShowDialog() == DialogResult.OK)
            {
                TBox_CensorPath.Text = FolderSelector.SelectedPath;
            }
        }

        //Enable/Disable settings for censoring usage 
        private void CB_Censoring_CheckedChanged(object sender, EventArgs e)
        {
            bool check = CB_Censoring.Checked;

            TB_CensorProbability.Enabled = check;
            COMB_CensorSize.Enabled = check;
            COMB_CensorType.Enabled = check;
        }

        //Get the color from the color dialog.
        private void P_EdgeLightColor_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                P_EdgeLightColor.BackColor = ColorPicker.Color;
            }
        }

        //Enable/Disable settings for edge phases
        private void CB_EdgePhase_CheckedChanged(object sender, EventArgs e)
        {
            bool check = CB_EdgePhase.Checked;

            TB_EdgeChance.Enabled = check;
            CB_AllowGreenLight.Enabled = check;
            NUD_EdgeWarmup.Enabled = check;
            NUD_MaxEdge.Enabled = check;
            NUD_MinEdge.Enabled = check;
        }

        //Maximal value can not be lower than minimal value.
        private void NUD_MaxEdge_ValueChanged(object sender, EventArgs e)
        {
            if (NUD_MinEdge.Value > NUD_MaxEdge.Value)
            {
                NUD_MinEdge.Value = NUD_MaxEdge.Value;
            }
        }

        //Minimum value can not be higher than maximal value.
        private void NUD_MinEdge_ValueChanged(object sender, EventArgs e)
        {
            if (NUD_MaxEdge.Value < NUD_MinEdge.Value)
            {
                NUD_MaxEdge.Value = NUD_MinEdge.Value;
            }
        }
    }
}
