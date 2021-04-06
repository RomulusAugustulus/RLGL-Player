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
using System.Collections.Generic;
using System.Windows.Forms;

namespace RLGL_Player
{
    /*
     *This dialog provides basic controls to edit a custom ending. 
     */
    public partial class EndingConfiguratorDlg : Form
    {
        private List<RLGLEndingPhase> phases;
        private RLGLEndingPhase currentPhase;
        private int overallDuration;
        private RLGLEnding ending;

        public RLGLEnding Ending { get => ending; }

        public EndingConfiguratorDlg()
        {
            phases = new List<RLGLEndingPhase>();
            overallDuration = 0;
            InitializeComponent();
        }

        public void InitEnding(RLGLEnding ending)
        {
            this.ending = ending;
            phases = ending.GetAllPhases();
            overallDuration = ending.Duration;
            UpdateOverallDurationUI();

            LB_EndingParts.Items.Clear();

            for(int i=0;i<phases.Count;i++)
            {
                LB_EndingParts.Items.Add(phases[i].Name);
            }
        }

        /*
         * Adding a new phase. 
         * This phase will be a dummy one with green light and a duration of 1 second.
         */ 
        private void B_AddPhase_Click(object sender, EventArgs e)
        {
            EnterNameDlg enterNameDlg = new EnterNameDlg();

            if(enterNameDlg.ShowDialog() == DialogResult.OK)
            {
                RLGLEndingPhase p = new RLGLEndingPhase();
                p.Name = enterNameDlg.Input;
                p.Duration = 1;
                p.Message = "Stroke";
                p.Phase = RLGLPhase.Green;
                p.CountdownBegin = 10;
                p.CountdownEnd = 0;
                p.CountdownStep = 1;

                phases.Add(p);
                LB_EndingParts.Items.Add(p.Name);

                UpdateOverallDurationUI();
            }
        }

        //Update the duration for the whole ending.
        private void UpdateOverallDurationUI()
        {
            overallDuration = 0;
            foreach (RLGLEndingPhase p in phases)
            {
                overallDuration += p.Duration;
            }

            L_EndingDurationValue.Text = overallDuration + " s";
        }

        private void B_Delete_Click(object sender, EventArgs e)
        {
            phases.RemoveAt(LB_EndingParts.SelectedIndex);
            LB_EndingParts.Items.RemoveAt(LB_EndingParts.SelectedIndex);
            LB_EndingParts.SelectedIndex = -1;
            UpdateOverallDurationUI();
        }

        private void B_Down_Click(object sender, EventArgs e)
        {
            MoveInQueue(1);
        }

        private void B_Up_Click(object sender, EventArgs e)
        {
            MoveInQueue(-1);
        }

        // Moves the currently selected index of the listbox by change amount.
        private void MoveInQueue(int change)
        {
            int selIndex = LB_EndingParts.SelectedIndex;
            LB_EndingParts.Items.RemoveAt(selIndex);
            RLGLEndingPhase phase = phases[selIndex];
            phases.RemoveAt(selIndex);

            if (selIndex + change < 0)
            {
                LB_EndingParts.Items.Insert(0, phase.Name);
                phases.Insert(0, phase);
                LB_EndingParts.SelectedIndex = 0;
            }
            else if (selIndex + change >= LB_EndingParts.Items.Count)
            {
                LB_EndingParts.Items.Add(phase.Name);
                phases.Add(phase);
                LB_EndingParts.SelectedIndex = LB_EndingParts.Items.Count-1;
            }
            else
            {
                LB_EndingParts.Items.Insert(selIndex + change, phase.Name);
                phases.Insert(selIndex + change, phase);
                LB_EndingParts.SelectedIndex = selIndex + change;
            }
        }

        private void LB_EndingParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_EndingParts.SelectedIndex == -1)
            {
                currentPhase = null;
                EnableControls(false);
            }
            else
            {
                currentPhase = phases[LB_EndingParts.SelectedIndex];
                EnableControls(true);
            }
        }

        //Saves the values from the controls to a RLGLEndingPhase object
        private void SavePhase()
        {
            if (currentPhase != null)
            {
                currentPhase.Duration = (int)NUD_PhaseDuration.Value;
                currentPhase.Message = TB_Text.Text.Trim();

                if (RB_Countdown.Checked)
                {
                    currentPhase.Phase = RLGLPhase.Countdown;
                }
                else if (RB_EdgeLight.Checked)
                {
                    currentPhase.Phase = RLGLPhase.Edge;
                }
                else if (RB_GreenLight.Checked)
                {
                    currentPhase.Phase = RLGLPhase.Green;
                }
                else if (RB_RedLight.Checked)
                {
                    currentPhase.Phase = RLGLPhase.Red;
                }
                else if (RB_RuinedOrgasm.Checked)
                {
                    currentPhase.Phase = RLGLPhase.Ruin;
                }

                currentPhase.CountdownBegin = (int)NUD_CountdownBegin.Value;
                currentPhase.CountdownEnd = (int)NUD_CountdownEnd.Value;
                currentPhase.CountdownStep = (int)NUD_CountdownStepDuration.Value;
            }
        }

        private void EnableCountdownControls()
        {
            if (RB_Countdown.Checked)
            {
                NUD_CountdownBegin.Enabled = true;
                NUD_CountdownEnd.Enabled = true;
                NUD_CountdownStepDuration.Enabled = true;

                NUD_PhaseDuration.Enabled = false;
                CalculateCountdownTime();
            }
            else
            {
                NUD_CountdownBegin.Enabled = false;
                NUD_CountdownEnd.Enabled = false;
                NUD_CountdownStepDuration.Enabled = false;

                NUD_PhaseDuration.Enabled = true;
            }
        }

        //Enable or disable certain controls based on the current selection.
        private void EnableControls(bool enable)
        {
            B_Up.Enabled = enable;
            B_Down.Enabled = enable;
            B_Delete.Enabled = enable;

            GB_FineTuning.Enabled = enable;

            if(enable)
            {
                switch(currentPhase.Phase)
                {
                    case RLGLPhase.Green:
                        RB_GreenLight.Checked = true;
                        break;

                    case RLGLPhase.Red:
                        RB_RedLight.Checked = true;
                        break;

                    case RLGLPhase.Edge:
                        RB_EdgeLight.Checked = true;
                        break;

                    case RLGLPhase.Countdown:
                        RB_Countdown.Checked = true;
                        break;

                    case RLGLPhase.Ruin:
                        RB_RuinedOrgasm.Checked = true;
                        break;
                }

                NUD_PhaseDuration.Value = currentPhase.Duration;
                TB_Text.Text = currentPhase.Message;

                NUD_CountdownBegin.Value = Math.Min(NUD_CountdownBegin.Maximum, Math.Max(currentPhase.CountdownBegin, NUD_CountdownBegin.Minimum));
                NUD_CountdownEnd.Value = Math.Min(NUD_CountdownEnd.Maximum, Math.Max(currentPhase.CountdownEnd, NUD_CountdownEnd.Minimum));
                NUD_CountdownStepDuration.Value = Math.Min(NUD_CountdownStepDuration.Maximum, Math.Max(currentPhase.CountdownStep, NUD_CountdownStepDuration.Minimum));

                EnableCountdownControls();
            }
            else
            {
                RB_Countdown.Checked = false;
                RB_EdgeLight.Checked = false;
                RB_GreenLight.Checked = false;
                RB_RedLight.Checked = false;
                RB_RuinedOrgasm.Checked = false;
                NUD_PhaseDuration.Value = 1;
                NUD_CountdownBegin.Value = 10;
                NUD_CountdownEnd.Value = 0;
                NUD_CountdownStepDuration.Value = 1;
                TB_Text.Text = "";
            }
        }

        private void B_Apply_Click(object sender, EventArgs e)
        {
            SavePhase();
            UpdateOverallDurationUI();
        }

        private void RB_Phase_Click(object sender, EventArgs e)
        {
            EnableCountdownControls();
        }

        private void NUD_Countdown_ValueChanged(object sender, EventArgs e)
        {
            if(NUD_CountdownBegin.Value < NUD_CountdownEnd.Value)
            {
                NUD_CountdownEnd.Value = NUD_CountdownBegin.Value;
            }

            if(RB_Countdown.Checked)
            {
                CalculateCountdownTime();
            }
        }

        //Gets the duration of a phase that is set to countdown.
        private void CalculateCountdownTime()
        {
            int duration = (int)((NUD_CountdownBegin.Value - NUD_CountdownEnd.Value + 1) * NUD_CountdownStepDuration.Value);
            NUD_PhaseDuration.Value = duration;
        }

        //Finishes the custom ending and closes the dialog.
        private void B_OK_Click(object sender, EventArgs e)
        {
            if (phases.Count == 0)
            {
                MessageBox.Show("You'll need to have at least one phase for the ending!", "Error");
                this.DialogResult = DialogResult.None;
            }
            else
            {
                string endingName = ending.EndingName;
                ending = new RLGLEnding(endingName);

                for (int i = 0; i < phases.Count; i++)
                {
                    ending.AddPhase(phases[i]);
                }
            }
        }
    }
}
