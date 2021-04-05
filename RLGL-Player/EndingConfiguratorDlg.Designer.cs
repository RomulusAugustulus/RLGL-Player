
namespace RLGL_Player
{
    partial class EndingConfiguratorDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GB_EndingParts = new System.Windows.Forms.GroupBox();
            this.B_AddPhase = new System.Windows.Forms.Button();
            this.B_Delete = new System.Windows.Forms.Button();
            this.B_Up = new System.Windows.Forms.Button();
            this.B_Down = new System.Windows.Forms.Button();
            this.L_EndingDurationValue = new System.Windows.Forms.Label();
            this.L_EndingDuration = new System.Windows.Forms.Label();
            this.LB_EndingParts = new System.Windows.Forms.ListBox();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_OK = new System.Windows.Forms.Button();
            this.GB_FineTuning = new System.Windows.Forms.GroupBox();
            this.B_Apply = new System.Windows.Forms.Button();
            this.NUD_CountdownStepDuration = new System.Windows.Forms.NumericUpDown();
            this.L_CountdownStepDuration = new System.Windows.Forms.Label();
            this.NUD_CountdownEnd = new System.Windows.Forms.NumericUpDown();
            this.L_CountdownEnd = new System.Windows.Forms.Label();
            this.NUD_CountdownBegin = new System.Windows.Forms.NumericUpDown();
            this.L_CountdownBegin = new System.Windows.Forms.Label();
            this.TB_Text = new System.Windows.Forms.TextBox();
            this.L_Text = new System.Windows.Forms.Label();
            this.NUD_PhaseDuration = new System.Windows.Forms.NumericUpDown();
            this.L_PhaseDuration = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RB_GreenLight = new System.Windows.Forms.RadioButton();
            this.RB_RedLight = new System.Windows.Forms.RadioButton();
            this.RB_Countdown = new System.Windows.Forms.RadioButton();
            this.RB_EdgeLight = new System.Windows.Forms.RadioButton();
            this.RB_RuinedOrgasm = new System.Windows.Forms.RadioButton();
            this.L_Phase = new System.Windows.Forms.Label();
            this.GB_EndingParts.SuspendLayout();
            this.GB_FineTuning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CountdownStepDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CountdownEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CountdownBegin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PhaseDuration)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_EndingParts
            // 
            this.GB_EndingParts.Controls.Add(this.B_AddPhase);
            this.GB_EndingParts.Controls.Add(this.B_Delete);
            this.GB_EndingParts.Controls.Add(this.B_Up);
            this.GB_EndingParts.Controls.Add(this.B_Down);
            this.GB_EndingParts.Controls.Add(this.L_EndingDurationValue);
            this.GB_EndingParts.Controls.Add(this.L_EndingDuration);
            this.GB_EndingParts.Controls.Add(this.LB_EndingParts);
            this.GB_EndingParts.Location = new System.Drawing.Point(12, 12);
            this.GB_EndingParts.Name = "GB_EndingParts";
            this.GB_EndingParts.Size = new System.Drawing.Size(390, 240);
            this.GB_EndingParts.TabIndex = 0;
            this.GB_EndingParts.TabStop = false;
            this.GB_EndingParts.Text = "Ending";
            // 
            // B_AddPhase
            // 
            this.B_AddPhase.Location = new System.Drawing.Point(9, 201);
            this.B_AddPhase.Name = "B_AddPhase";
            this.B_AddPhase.Size = new System.Drawing.Size(375, 31);
            this.B_AddPhase.TabIndex = 11;
            this.B_AddPhase.Text = "Add new phase";
            this.B_AddPhase.UseVisualStyleBackColor = true;
            this.B_AddPhase.Click += new System.EventHandler(this.B_AddPhase_Click);
            // 
            // B_Delete
            // 
            this.B_Delete.Enabled = false;
            this.B_Delete.Location = new System.Drawing.Point(309, 173);
            this.B_Delete.Name = "B_Delete";
            this.B_Delete.Size = new System.Drawing.Size(75, 23);
            this.B_Delete.TabIndex = 10;
            this.B_Delete.Text = "Remove";
            this.B_Delete.UseVisualStyleBackColor = true;
            this.B_Delete.Click += new System.EventHandler(this.B_Delete_Click);
            // 
            // B_Up
            // 
            this.B_Up.Enabled = false;
            this.B_Up.Location = new System.Drawing.Point(309, 115);
            this.B_Up.Name = "B_Up";
            this.B_Up.Size = new System.Drawing.Size(75, 23);
            this.B_Up.TabIndex = 9;
            this.B_Up.Text = "Up";
            this.B_Up.UseVisualStyleBackColor = true;
            this.B_Up.Click += new System.EventHandler(this.B_Up_Click);
            // 
            // B_Down
            // 
            this.B_Down.Enabled = false;
            this.B_Down.Location = new System.Drawing.Point(309, 144);
            this.B_Down.Name = "B_Down";
            this.B_Down.Size = new System.Drawing.Size(75, 23);
            this.B_Down.TabIndex = 8;
            this.B_Down.Text = "Down";
            this.B_Down.UseVisualStyleBackColor = true;
            this.B_Down.Click += new System.EventHandler(this.B_Down_Click);
            // 
            // L_EndingDurationValue
            // 
            this.L_EndingDurationValue.AutoSize = true;
            this.L_EndingDurationValue.Location = new System.Drawing.Point(62, 19);
            this.L_EndingDurationValue.Name = "L_EndingDurationValue";
            this.L_EndingDurationValue.Size = new System.Drawing.Size(21, 13);
            this.L_EndingDurationValue.TabIndex = 2;
            this.L_EndingDurationValue.Text = "0 s";
            // 
            // L_EndingDuration
            // 
            this.L_EndingDuration.AutoSize = true;
            this.L_EndingDuration.Location = new System.Drawing.Point(6, 19);
            this.L_EndingDuration.Name = "L_EndingDuration";
            this.L_EndingDuration.Size = new System.Drawing.Size(50, 13);
            this.L_EndingDuration.TabIndex = 1;
            this.L_EndingDuration.Text = "Duration:";
            // 
            // LB_EndingParts
            // 
            this.LB_EndingParts.FormattingEnabled = true;
            this.LB_EndingParts.Location = new System.Drawing.Point(6, 35);
            this.LB_EndingParts.Name = "LB_EndingParts";
            this.LB_EndingParts.Size = new System.Drawing.Size(294, 160);
            this.LB_EndingParts.TabIndex = 0;
            this.LB_EndingParts.SelectedIndexChanged += new System.EventHandler(this.LB_EndingParts_SelectedIndexChanged);
            // 
            // B_Cancel
            // 
            this.B_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_Cancel.Location = new System.Drawing.Point(12, 258);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(90, 23);
            this.B_Cancel.TabIndex = 1;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            // 
            // B_OK
            // 
            this.B_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_OK.Location = new System.Drawing.Point(800, 258);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(90, 23);
            this.B_OK.TabIndex = 2;
            this.B_OK.Text = "Save and close";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // GB_FineTuning
            // 
            this.GB_FineTuning.Controls.Add(this.B_Apply);
            this.GB_FineTuning.Controls.Add(this.NUD_CountdownStepDuration);
            this.GB_FineTuning.Controls.Add(this.L_CountdownStepDuration);
            this.GB_FineTuning.Controls.Add(this.NUD_CountdownEnd);
            this.GB_FineTuning.Controls.Add(this.L_CountdownEnd);
            this.GB_FineTuning.Controls.Add(this.NUD_CountdownBegin);
            this.GB_FineTuning.Controls.Add(this.L_CountdownBegin);
            this.GB_FineTuning.Controls.Add(this.TB_Text);
            this.GB_FineTuning.Controls.Add(this.L_Text);
            this.GB_FineTuning.Controls.Add(this.NUD_PhaseDuration);
            this.GB_FineTuning.Controls.Add(this.L_PhaseDuration);
            this.GB_FineTuning.Controls.Add(this.tableLayoutPanel1);
            this.GB_FineTuning.Controls.Add(this.L_Phase);
            this.GB_FineTuning.Enabled = false;
            this.GB_FineTuning.Location = new System.Drawing.Point(408, 12);
            this.GB_FineTuning.Name = "GB_FineTuning";
            this.GB_FineTuning.Size = new System.Drawing.Size(482, 240);
            this.GB_FineTuning.TabIndex = 3;
            this.GB_FineTuning.TabStop = false;
            this.GB_FineTuning.Text = "Phase-Settings";
            // 
            // B_Apply
            // 
            this.B_Apply.Location = new System.Drawing.Point(392, 202);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(84, 23);
            this.B_Apply.TabIndex = 19;
            this.B_Apply.Text = "Apply";
            this.B_Apply.UseVisualStyleBackColor = true;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // NUD_CountdownStepDuration
            // 
            this.NUD_CountdownStepDuration.Location = new System.Drawing.Point(156, 205);
            this.NUD_CountdownStepDuration.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NUD_CountdownStepDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_CountdownStepDuration.Name = "NUD_CountdownStepDuration";
            this.NUD_CountdownStepDuration.Size = new System.Drawing.Size(73, 20);
            this.NUD_CountdownStepDuration.TabIndex = 18;
            this.NUD_CountdownStepDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_CountdownStepDuration.ValueChanged += new System.EventHandler(this.NUD_Countdown_ValueChanged);
            // 
            // L_CountdownStepDuration
            // 
            this.L_CountdownStepDuration.AutoSize = true;
            this.L_CountdownStepDuration.Location = new System.Drawing.Point(6, 207);
            this.L_CountdownStepDuration.Name = "L_CountdownStepDuration";
            this.L_CountdownStepDuration.Size = new System.Drawing.Size(144, 13);
            this.L_CountdownStepDuration.TabIndex = 17;
            this.L_CountdownStepDuration.Text = "Countdown-Step duration (s):";
            // 
            // NUD_CountdownEnd
            // 
            this.NUD_CountdownEnd.Location = new System.Drawing.Point(352, 170);
            this.NUD_CountdownEnd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_CountdownEnd.Name = "NUD_CountdownEnd";
            this.NUD_CountdownEnd.Size = new System.Drawing.Size(124, 20);
            this.NUD_CountdownEnd.TabIndex = 16;
            this.NUD_CountdownEnd.ValueChanged += new System.EventHandler(this.NUD_Countdown_ValueChanged);
            // 
            // L_CountdownEnd
            // 
            this.L_CountdownEnd.AutoSize = true;
            this.L_CountdownEnd.Location = new System.Drawing.Point(261, 172);
            this.L_CountdownEnd.Name = "L_CountdownEnd";
            this.L_CountdownEnd.Size = new System.Drawing.Size(85, 13);
            this.L_CountdownEnd.TabIndex = 15;
            this.L_CountdownEnd.Text = "Countdown end:";
            // 
            // NUD_CountdownBegin
            // 
            this.NUD_CountdownBegin.Location = new System.Drawing.Point(105, 170);
            this.NUD_CountdownBegin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_CountdownBegin.Name = "NUD_CountdownBegin";
            this.NUD_CountdownBegin.Size = new System.Drawing.Size(124, 20);
            this.NUD_CountdownBegin.TabIndex = 14;
            this.NUD_CountdownBegin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_CountdownBegin.ValueChanged += new System.EventHandler(this.NUD_Countdown_ValueChanged);
            // 
            // L_CountdownBegin
            // 
            this.L_CountdownBegin.AutoSize = true;
            this.L_CountdownBegin.Location = new System.Drawing.Point(6, 172);
            this.L_CountdownBegin.Name = "L_CountdownBegin";
            this.L_CountdownBegin.Size = new System.Drawing.Size(93, 13);
            this.L_CountdownBegin.TabIndex = 13;
            this.L_CountdownBegin.Text = "Countdown begin:";
            // 
            // TB_Text
            // 
            this.TB_Text.Location = new System.Drawing.Point(105, 131);
            this.TB_Text.Name = "TB_Text";
            this.TB_Text.Size = new System.Drawing.Size(371, 20);
            this.TB_Text.TabIndex = 12;
            // 
            // L_Text
            // 
            this.L_Text.AutoSize = true;
            this.L_Text.Location = new System.Drawing.Point(6, 134);
            this.L_Text.Name = "L_Text";
            this.L_Text.Size = new System.Drawing.Size(53, 13);
            this.L_Text.TabIndex = 11;
            this.L_Text.Text = "Message:";
            // 
            // NUD_PhaseDuration
            // 
            this.NUD_PhaseDuration.Location = new System.Drawing.Point(105, 98);
            this.NUD_PhaseDuration.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.NUD_PhaseDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_PhaseDuration.Name = "NUD_PhaseDuration";
            this.NUD_PhaseDuration.Size = new System.Drawing.Size(371, 20);
            this.NUD_PhaseDuration.TabIndex = 10;
            this.NUD_PhaseDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // L_PhaseDuration
            // 
            this.L_PhaseDuration.AutoSize = true;
            this.L_PhaseDuration.Location = new System.Drawing.Point(6, 100);
            this.L_PhaseDuration.Name = "L_PhaseDuration";
            this.L_PhaseDuration.Size = new System.Drawing.Size(64, 13);
            this.L_PhaseDuration.TabIndex = 9;
            this.L_PhaseDuration.Text = "Duration (s):";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.RB_GreenLight, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RB_RedLight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RB_Countdown, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.RB_EdgeLight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RB_RuinedOrgasm, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(51, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(425, 52);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // RB_GreenLight
            // 
            this.RB_GreenLight.AutoSize = true;
            this.RB_GreenLight.Location = new System.Drawing.Point(3, 3);
            this.RB_GreenLight.Name = "RB_GreenLight";
            this.RB_GreenLight.Size = new System.Drawing.Size(76, 17);
            this.RB_GreenLight.TabIndex = 0;
            this.RB_GreenLight.TabStop = true;
            this.RB_GreenLight.Text = "Green light";
            this.RB_GreenLight.UseVisualStyleBackColor = true;
            this.RB_GreenLight.Click += new System.EventHandler(this.RB_Phase_Click);
            // 
            // RB_RedLight
            // 
            this.RB_RedLight.AutoSize = true;
            this.RB_RedLight.Location = new System.Drawing.Point(3, 29);
            this.RB_RedLight.Name = "RB_RedLight";
            this.RB_RedLight.Size = new System.Drawing.Size(67, 17);
            this.RB_RedLight.TabIndex = 2;
            this.RB_RedLight.TabStop = true;
            this.RB_RedLight.Text = "Red light";
            this.RB_RedLight.UseVisualStyleBackColor = true;
            this.RB_RedLight.Click += new System.EventHandler(this.RB_Phase_Click);
            // 
            // RB_Countdown
            // 
            this.RB_Countdown.AutoSize = true;
            this.RB_Countdown.Location = new System.Drawing.Point(144, 29);
            this.RB_Countdown.Name = "RB_Countdown";
            this.RB_Countdown.Size = new System.Drawing.Size(79, 17);
            this.RB_Countdown.TabIndex = 6;
            this.RB_Countdown.TabStop = true;
            this.RB_Countdown.Text = "Countdown";
            this.RB_Countdown.UseVisualStyleBackColor = true;
            this.RB_Countdown.Click += new System.EventHandler(this.RB_Phase_Click);
            // 
            // RB_EdgeLight
            // 
            this.RB_EdgeLight.AutoSize = true;
            this.RB_EdgeLight.Location = new System.Drawing.Point(144, 3);
            this.RB_EdgeLight.Name = "RB_EdgeLight";
            this.RB_EdgeLight.Size = new System.Drawing.Size(72, 17);
            this.RB_EdgeLight.TabIndex = 3;
            this.RB_EdgeLight.TabStop = true;
            this.RB_EdgeLight.Text = "Edge light";
            this.RB_EdgeLight.UseVisualStyleBackColor = true;
            this.RB_EdgeLight.Click += new System.EventHandler(this.RB_Phase_Click);
            // 
            // RB_RuinedOrgasm
            // 
            this.RB_RuinedOrgasm.AutoSize = true;
            this.RB_RuinedOrgasm.Location = new System.Drawing.Point(285, 3);
            this.RB_RuinedOrgasm.Name = "RB_RuinedOrgasm";
            this.RB_RuinedOrgasm.Size = new System.Drawing.Size(98, 17);
            this.RB_RuinedOrgasm.TabIndex = 5;
            this.RB_RuinedOrgasm.TabStop = true;
            this.RB_RuinedOrgasm.Text = "Ruined Orgasm";
            this.RB_RuinedOrgasm.UseVisualStyleBackColor = true;
            this.RB_RuinedOrgasm.Click += new System.EventHandler(this.RB_Phase_Click);
            // 
            // L_Phase
            // 
            this.L_Phase.AutoSize = true;
            this.L_Phase.Location = new System.Drawing.Point(6, 19);
            this.L_Phase.Name = "L_Phase";
            this.L_Phase.Size = new System.Drawing.Size(40, 13);
            this.L_Phase.TabIndex = 1;
            this.L_Phase.Text = "Phase:";
            // 
            // EndingConfiguratorDlg
            // 
            this.AcceptButton = this.B_Apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.B_Cancel;
            this.ClientSize = new System.Drawing.Size(902, 292);
            this.Controls.Add(this.GB_FineTuning);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.GB_EndingParts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EndingConfiguratorDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Ending...";
            this.GB_EndingParts.ResumeLayout(false);
            this.GB_EndingParts.PerformLayout();
            this.GB_FineTuning.ResumeLayout(false);
            this.GB_FineTuning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CountdownStepDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CountdownEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CountdownBegin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PhaseDuration)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_EndingParts;
        private System.Windows.Forms.Label L_EndingDurationValue;
        private System.Windows.Forms.Label L_EndingDuration;
        private System.Windows.Forms.ListBox LB_EndingParts;
        private System.Windows.Forms.Button B_AddPhase;
        private System.Windows.Forms.Button B_Delete;
        private System.Windows.Forms.Button B_Up;
        private System.Windows.Forms.Button B_Down;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.GroupBox GB_FineTuning;
        private System.Windows.Forms.NumericUpDown NUD_CountdownStepDuration;
        private System.Windows.Forms.Label L_CountdownStepDuration;
        private System.Windows.Forms.NumericUpDown NUD_CountdownEnd;
        private System.Windows.Forms.Label L_CountdownEnd;
        private System.Windows.Forms.NumericUpDown NUD_CountdownBegin;
        private System.Windows.Forms.Label L_CountdownBegin;
        private System.Windows.Forms.TextBox TB_Text;
        private System.Windows.Forms.Label L_Text;
        private System.Windows.Forms.NumericUpDown NUD_PhaseDuration;
        private System.Windows.Forms.Label L_PhaseDuration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton RB_GreenLight;
        private System.Windows.Forms.RadioButton RB_RedLight;
        private System.Windows.Forms.RadioButton RB_Countdown;
        private System.Windows.Forms.RadioButton RB_EdgeLight;
        private System.Windows.Forms.RadioButton RB_RuinedOrgasm;
        private System.Windows.Forms.Label L_Phase;
        private System.Windows.Forms.Button B_Apply;
    }
}