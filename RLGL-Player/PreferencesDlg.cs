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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RLGL_Player
{
    /*
     * Show a dialog that let's the user set all of the relevant settings.
     */ 
    public partial class PreferencesDlg : Form
    {
        //Holds all the known endings that a user has created.
        public List<RLGLInternEnding> EndingSettings { get; set; }
        public List<int> CustomColorDlgColors { get; set; }

        public PreferencesDlg()
        {            
            if(EndingSettings == null)
            {
                EndingSettings = new List<RLGLInternEnding>();
            }

            InitializeComponent();
        }

        public void SetCustomColorDlgColors()
        {
            ColorPicker.CustomColors = CustomColorDlgColors.ToArray();
        }

        //Creates a control for each found ending.
        private void ShowEndings()
        {
            EndingsLayout.Controls.Clear();

            for (int i=0;i<EndingSettings.Count;i++)
            {
                CustomEndingListElement e = new CustomEndingListElement();
                e.Text = EndingSettings[i].EndingName;
                e.EndingElementClick += new CustomEndingListElement.EndingElementClickHandler(this.CELE_ButtonClick);
                e.EndingElementEnabledChanged += new CustomEndingListElement.EndingElementEnabledHandler(this.CELE_EnabledChanged);
                e.EndingElementValueChanged += new CustomEndingListElement.EndingElementValueHandler(this.CELE_ValueChanged);
                e.EndingElementLockedChanged += new CustomEndingListElement.EndingElementLockedHandler(this.CELE_LockedChanged);
                e.Chance = EndingSettings[i].Chance;
                e.IncludeElement = EndingSettings[i].Enabled;
                e.LockChance = EndingSettings[i].Locked;
                
                EndingsLayout.Controls.Add(e);
            }
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
            ColorPicker.Color = P_GreenLightColor.BackColor;
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                P_GreenLightColor.BackColor = ColorPicker.Color;
            }

            CustomColorDlgColors = new List<int>(ColorPicker.CustomColors);
        }

        //Get the color from the color dialog.
        private void P_RedLightColor_Click(object sender, EventArgs e)
        {
            ColorPicker.Color = P_RedLightColor.BackColor;
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                P_RedLightColor.BackColor = ColorPicker.Color;
            }

            CustomColorDlgColors = new List<int>(ColorPicker.CustomColors);
        }

        //Enable/Disable settings for metronome usage
        private void CB_Metronome_CheckedChanged(object sender, EventArgs e)
        {
            bool check = CB_Metronome.Checked;
            
            NUD_MinMetronome.Enabled = check;
            NUD_MaxMetronome.Enabled = check;
            ETB_MetronomeChance.Enabled = check;
            
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
            ColorPicker.Color = P_CensorColor.BackColor;
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                P_CensorColor.BackColor = ColorPicker.Color;
            }

            CustomColorDlgColors = new List<int>(ColorPicker.CustomColors);
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

            ETB_CensorChance.Enabled = check;
            COMB_CensorSize.Enabled = check;
            COMB_CensorType.Enabled = check;
            CB_CensorOnlyGreen.Enabled = check;
        }

        //Get the color from the color dialog.
        private void P_EdgeLightColor_Click(object sender, EventArgs e)
        {
            ColorPicker.Color = P_EdgeLightColor.BackColor;
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                P_EdgeLightColor.BackColor = ColorPicker.Color;
            }

            CustomColorDlgColors = new List<int>(ColorPicker.CustomColors);
        }

        //Enable/Disable settings for edge phases
        private void CB_EdgePhase_CheckedChanged(object sender, EventArgs e)
        {
            bool check = CB_EdgePhase.Checked;

            ETB_EdgeChance.Enabled = check;
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

        //Apply current preferences without closing the options dialog.
        private void B_Apply_Click(object sender, EventArgs e)
        {
            if (AtleastOneEndingEnabled())
            {
                RLGLPlayer mainForm = (RLGLPlayer)this.Owner;
                mainForm.UpdateRLGLPreferences();
            }
            else
            {
                MessageBox.Show(this, "There needs to be at least 1 enabled ending!", "Error");
            }
        }

        private bool AtleastOneEndingEnabled()
        {
            return EndingSettings.Exists(x => x.Enabled == true);
        }

        //Creates a new ending from the users input.
        private void B_New_Click(object sender, EventArgs e)
        {
            EnterNameDlg enterNameDlg = new EnterNameDlg();

            if (enterNameDlg.ShowDialog() == DialogResult.OK)
            {
                RLGLEnding newEnding = new RLGLEnding(enterNameDlg.Input);

                RLGLEndingPhase newEndingPhase = new RLGLEndingPhase();
                newEndingPhase.Name = "Green";
                newEndingPhase.Message = "Cum";
                newEndingPhase.Duration = 30;
                newEndingPhase.CountdownBegin = 10;
                newEndingPhase.CountdownEnd = 0;
                newEndingPhase.CountdownStep = 1;
                newEnding.AddPhase(newEndingPhase);

                EndingSettings.Add(new RLGLInternEnding(false,false,0,newEnding.EndingName,newEnding));

                ShowEndings();
            }
        }

        //Opens an existing ending to configure it.
        private void CELE_ButtonClick(object sender, EventArgs e)
        {
            EndingConfiguratorDlg endingConfiguratorDlg = new EndingConfiguratorDlg();
            CustomEndingListElement customEnding = (CustomEndingListElement)sender;
            string name = customEnding.Text;
            int positionInList = -1;

            for(int i=0;i<EndingSettings.Count;i++)
            {
                if(EndingSettings[i].EndingName.Equals(name))
                {
                    endingConfiguratorDlg.InitEnding(EndingSettings[i].Ending);
                    positionInList = i;
                }
            }
            if(endingConfiguratorDlg.ShowDialog() == DialogResult.OK)
            {
                EndingSettings[positionInList].Ending = endingConfiguratorDlg.Ending;
            }
        }

        private void CELE_EnabledChanged(object sender, EventArgs e)
        {
            CustomEndingListElement customEnding = (CustomEndingListElement)sender;
            RLGLInternEnding end = EndingSettings.Find(x => x.EndingName.Equals(customEnding.Text));

            end.Enabled = customEnding.IncludeElement;

            if(end.Enabled)
            {
                CalculateCurrentChanceValues(customEnding);
            }
            else
            {
                foreach(CustomEndingListElement elem in EndingsLayout.Controls)
                {
                    if(elem.IncludeElement)
                    {
                        CalculateCurrentChanceValues(elem);
                        break;
                    }
                }
            }
        }

        private void CELE_LockedChanged(object sender, EventArgs e)
        {
            CustomEndingListElement customEnding = (CustomEndingListElement)sender;
            RLGLInternEnding end = EndingSettings.Find(x => x.EndingName.Equals(customEnding.Text));

            end.Locked = customEnding.LockChance;
        }

        private void CELE_ValueChanged(object sender, EventArgs e)
        {
            CustomEndingListElement currentElement = (CustomEndingListElement)sender;
            if (currentElement.IsActive && currentElement.IncludeElement)
            {
                CalculateCurrentChanceValues(currentElement);
            }
        }

        //Calculate the chances for all enabled endings. They have to be 100 added all together!
        private void CalculateCurrentChanceValues(CustomEndingListElement currentElement)
        {
            int lockValue = 100;
            foreach (RLGLInternEnding setting in EndingSettings)
            {
                if (setting.Enabled && setting.Locked)
                {
                    if (setting.EndingName.Equals(currentElement.Text))
                    {
                        lockValue -= currentElement.Chance;
                    }
                    else
                    {
                        lockValue -= setting.Chance;
                    }
                }
            }

            if (lockValue < 100)
            {
                foreach (CustomEndingListElement elem in EndingsLayout.Controls)
                {
                    if (!elem.LockChance && elem.IncludeElement)
                    {
                        elem.Limit = lockValue;
                    }
                }
            }

            int val = currentElement.Chance;
            int numberOfVariableElements = 0;

            foreach (RLGLInternEnding setting in EndingSettings)
            {
                if (!setting.EndingName.Equals(currentElement.Text) && setting.Enabled)
                {
                    val += setting.Chance;

                    if (!setting.Locked)
                    {
                        numberOfVariableElements++;
                    }
                }
            }

            if (numberOfVariableElements > 0)
            {
                int diff = 100 - val;
                diff = (int)((float)diff / numberOfVariableElements);
                int carry = (100 - val) - numberOfVariableElements * diff;
                int loop = 0;
                do
                {
                    for (int i = 0; i < EndingSettings.Count; i++)
                    {
                        RLGLInternEnding setting = EndingSettings[i];

                        if (!((setting.Locked || setting.EndingName.Equals(currentElement.Text) && setting.Enabled)))
                        {
                            int c = EndingSettings[i].Chance + diff + carry;
                            if (c > lockValue)
                            {
                                EndingSettings[i].Chance = lockValue;
                                carry = c - lockValue;
                            }
                            else if (c < 0)
                            {
                                EndingSettings[i].Chance = 0;
                                carry = c;
                            }
                            else
                            {
                                EndingSettings[i].Chance += diff + carry;
                                carry = 0;
                            }
                        }
                        else if (setting.EndingName.Equals(currentElement.Text) && setting.Enabled)
                        {
                            if (loop < 3)
                            {
                                EndingSettings[i].Chance = currentElement.Chance;
                            }
                            else
                            {
                                EndingSettings[i].Chance = currentElement.Chance + carry;
                                currentElement.Chance = EndingSettings[i].Chance;
                                carry = 0;
                            }
                        }
                    }

                    diff = 0;
                    loop++;
                } while (carry != 0);
            }
            else
            {
                bool resetChance = true;

                if (!currentElement.LockChance)
                {
                    int enabledEndings = 0;
                    RLGLInternEnding selectedEnding = EndingSettings[0];
                    for (int i = 0; i < EndingSettings.Count; i++)
                    {
                        if (EndingSettings[i].Enabled)
                        {
                            enabledEndings++;
                        }

                        if (EndingSettings[i].EndingName.Equals(currentElement.Text))
                        {
                            selectedEnding = EndingSettings[i];
                        }
                    }

                    if (enabledEndings == 1)
                    {
                        currentElement.Chance = 100;
                        selectedEnding.Chance = 100;
                        resetChance = false;
                    }
                }
                
                if(resetChance)
                {
                    for (int i = 0; i < EndingSettings.Count; i++)
                    {
                        if (EndingSettings[i].EndingName.Equals(currentElement.Text) && EndingSettings[i].Enabled)
                        {
                            currentElement.Chance = EndingSettings[i].Chance;
                        }
                    }
                }
            }

            UpdateEndingElements();
        }

        //Shows the current chances on the dialog.
        private void UpdateEndingElements()
        {
            foreach(CustomEndingListElement e in EndingsLayout.Controls)
            {
                if(!e.IsActive && e.IncludeElement)
                {                    
                    RLGLInternEnding element = EndingSettings.Find(x => x.EndingName.Equals(e.Text));
                    e.Chance = element.Chance;
                }
            }
        }

        private void PreferencesDlg_Shown(object sender, EventArgs e)
        {
            ShowEndings();
        }

        private void P_RuinedOrgasmColor_Click(object sender, EventArgs e)
        {
            ColorPicker.Color = P_RuinedOrgasmColor.BackColor;
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                P_RuinedOrgasmColor.BackColor = ColorPicker.Color;
            }

            CustomColorDlgColors = new List<int>(ColorPicker.CustomColors);
        }

        private void B_SaveExit_Click(object sender, EventArgs e)
        {
            if(!AtleastOneEndingEnabled())
            {
                MessageBox.Show(this, "There needs to be at least 1 enabled ending!", "Error");
                this.DialogResult = DialogResult.None;
            }
        }

        private void TAB_Preferences_Selected(object sender, TabControlEventArgs e)
        {
            ShowEndings();
        }

        private void B_ResetGreen_Click(object sender, EventArgs e)
        {
            P_GreenLightColor.BackColor = Color.FromArgb(255, 0, 255, 0);
        }

        private void B_ResetRed_Click(object sender, EventArgs e)
        {
            P_RedLightColor.BackColor = Color.FromArgb(255, 255, 0, 0);
        }

        private void B_ResetEdge_Click(object sender, EventArgs e)
        {
            P_EdgeLightColor.BackColor = Color.FromArgb(255, 83, 143, 255);
        }

        private void B_ResetRuin_Click(object sender, EventArgs e)
        {
            P_RuinedOrgasmColor.BackColor = Color.FromArgb(255, 199, 107, 243);
        }

        private void B_ResetCensor_Click(object sender, EventArgs e)
        {
            P_CensorColor.BackColor = Color.FromArgb(255, 0, 0, 0);
        }

        private void B_ResetAll_Click(object sender, EventArgs e)
        {
            P_GreenLightColor.BackColor = Color.FromArgb(255, 0, 255, 0);
            P_RedLightColor.BackColor = Color.FromArgb(255, 255, 0, 0);
            P_EdgeLightColor.BackColor = Color.FromArgb(255, 83, 143, 255); 
            P_RuinedOrgasmColor.BackColor = Color.FromArgb(255, 199, 107, 243);
            P_CensorColor.BackColor = Color.FromArgb(255, 0, 0, 0);
        }
    }
}
