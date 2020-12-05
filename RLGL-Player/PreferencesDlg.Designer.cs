namespace RLGL_Player
{
    partial class PreferencesDlg
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
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.GB_RLGLSettings = new System.Windows.Forms.GroupBox();
            this.L_CensorPossibility = new System.Windows.Forms.Label();
            this.TB_CensorProbability = new System.Windows.Forms.TrackBar();
            this.L_CensorSize = new System.Windows.Forms.Label();
            this.COMB_CensorSize = new System.Windows.Forms.ComboBox();
            this.L_CensorType = new System.Windows.Forms.Label();
            this.COMB_CensorType = new System.Windows.Forms.ComboBox();
            this.CB_Censoring = new System.Windows.Forms.CheckBox();
            this.L_MetronomeChance = new System.Windows.Forms.Label();
            this.TB_MetronomeChance = new System.Windows.Forms.TrackBar();
            this.NUD_MaxMetronome = new System.Windows.Forms.NumericUpDown();
            this.L_MaxMetronome = new System.Windows.Forms.Label();
            this.NUD_MinMetronome = new System.Windows.Forms.NumericUpDown();
            this.L_MinMetronome = new System.Windows.Forms.Label();
            this.CB_Metronome = new System.Windows.Forms.CheckBox();
            this.RB_EndingRandom = new System.Windows.Forms.RadioButton();
            this.RB_EndingRed = new System.Windows.Forms.RadioButton();
            this.RB_EndingGreen = new System.Windows.Forms.RadioButton();
            this.L_Ending = new System.Windows.Forms.Label();
            this.NUD_MaxRed = new System.Windows.Forms.NumericUpDown();
            this.L_MaxRed = new System.Windows.Forms.Label();
            this.NUD_MinRed = new System.Windows.Forms.NumericUpDown();
            this.L_MinRed = new System.Windows.Forms.Label();
            this.NUD_MaxGreen = new System.Windows.Forms.NumericUpDown();
            this.L_MaxGreen = new System.Windows.Forms.Label();
            this.NUD_MinGreen = new System.Windows.Forms.NumericUpDown();
            this.L_GreenMin = new System.Windows.Forms.Label();
            this.GB_ProgramSettings = new System.Windows.Forms.GroupBox();
            this.B_CensorPath = new System.Windows.Forms.Button();
            this.TBox_CensorPath = new System.Windows.Forms.TextBox();
            this.L_CensorPath = new System.Windows.Forms.Label();
            this.P_CensorColor = new System.Windows.Forms.Panel();
            this.L_CensorColor = new System.Windows.Forms.Label();
            this.P_RedLightColor = new System.Windows.Forms.Panel();
            this.L_RedLightColor = new System.Windows.Forms.Label();
            this.P_GreenLightColor = new System.Windows.Forms.Panel();
            this.L_GreenLightColor = new System.Windows.Forms.Label();
            this.B_SaveExit = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.FolderSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.L_OnlyGreenLight = new System.Windows.Forms.Label();
            this.L_BothLights = new System.Windows.Forms.Label();
            this.GB_RLGLSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_CensorProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_MetronomeChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MaxMetronome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MinMetronome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MaxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MinRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MaxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MinGreen)).BeginInit();
            this.GB_ProgramSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_RLGLSettings
            // 
            this.GB_RLGLSettings.Controls.Add(this.L_BothLights);
            this.GB_RLGLSettings.Controls.Add(this.L_OnlyGreenLight);
            this.GB_RLGLSettings.Controls.Add(this.L_CensorPossibility);
            this.GB_RLGLSettings.Controls.Add(this.TB_CensorProbability);
            this.GB_RLGLSettings.Controls.Add(this.L_CensorSize);
            this.GB_RLGLSettings.Controls.Add(this.COMB_CensorSize);
            this.GB_RLGLSettings.Controls.Add(this.L_CensorType);
            this.GB_RLGLSettings.Controls.Add(this.COMB_CensorType);
            this.GB_RLGLSettings.Controls.Add(this.CB_Censoring);
            this.GB_RLGLSettings.Controls.Add(this.L_MetronomeChance);
            this.GB_RLGLSettings.Controls.Add(this.TB_MetronomeChance);
            this.GB_RLGLSettings.Controls.Add(this.NUD_MaxMetronome);
            this.GB_RLGLSettings.Controls.Add(this.L_MaxMetronome);
            this.GB_RLGLSettings.Controls.Add(this.NUD_MinMetronome);
            this.GB_RLGLSettings.Controls.Add(this.L_MinMetronome);
            this.GB_RLGLSettings.Controls.Add(this.CB_Metronome);
            this.GB_RLGLSettings.Controls.Add(this.RB_EndingRandom);
            this.GB_RLGLSettings.Controls.Add(this.RB_EndingRed);
            this.GB_RLGLSettings.Controls.Add(this.RB_EndingGreen);
            this.GB_RLGLSettings.Controls.Add(this.L_Ending);
            this.GB_RLGLSettings.Controls.Add(this.NUD_MaxRed);
            this.GB_RLGLSettings.Controls.Add(this.L_MaxRed);
            this.GB_RLGLSettings.Controls.Add(this.NUD_MinRed);
            this.GB_RLGLSettings.Controls.Add(this.L_MinRed);
            this.GB_RLGLSettings.Controls.Add(this.NUD_MaxGreen);
            this.GB_RLGLSettings.Controls.Add(this.L_MaxGreen);
            this.GB_RLGLSettings.Controls.Add(this.NUD_MinGreen);
            this.GB_RLGLSettings.Controls.Add(this.L_GreenMin);
            this.GB_RLGLSettings.Location = new System.Drawing.Point(12, 12);
            this.GB_RLGLSettings.Name = "GB_RLGLSettings";
            this.GB_RLGLSettings.Size = new System.Drawing.Size(421, 399);
            this.GB_RLGLSettings.TabIndex = 0;
            this.GB_RLGLSettings.TabStop = false;
            this.GB_RLGLSettings.Text = "Red Light Green Light Settings";
            // 
            // L_CensorPossibility
            // 
            this.L_CensorPossibility.AutoSize = true;
            this.L_CensorPossibility.Location = new System.Drawing.Point(28, 357);
            this.L_CensorPossibility.Name = "L_CensorPossibility";
            this.L_CensorPossibility.Size = new System.Drawing.Size(55, 13);
            this.L_CensorPossibility.TabIndex = 25;
            this.L_CensorPossibility.Text = "Possibility:";
            // 
            // TB_CensorProbability
            // 
            this.TB_CensorProbability.Location = new System.Drawing.Point(102, 344);
            this.TB_CensorProbability.Minimum = 1;
            this.TB_CensorProbability.Name = "TB_CensorProbability";
            this.TB_CensorProbability.Size = new System.Drawing.Size(302, 45);
            this.TB_CensorProbability.TabIndex = 24;
            this.TB_CensorProbability.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TB_CensorProbability.Value = 5;
            // 
            // L_CensorSize
            // 
            this.L_CensorSize.AutoSize = true;
            this.L_CensorSize.Location = new System.Drawing.Point(226, 316);
            this.L_CensorSize.Name = "L_CensorSize";
            this.L_CensorSize.Size = new System.Drawing.Size(64, 13);
            this.L_CensorSize.TabIndex = 23;
            this.L_CensorSize.Text = "Censor size:";
            // 
            // COMB_CensorSize
            // 
            this.COMB_CensorSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMB_CensorSize.FormattingEnabled = true;
            this.COMB_CensorSize.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Big",
            "Unfair"});
            this.COMB_CensorSize.Location = new System.Drawing.Point(303, 313);
            this.COMB_CensorSize.Name = "COMB_CensorSize";
            this.COMB_CensorSize.Size = new System.Drawing.Size(101, 21);
            this.COMB_CensorSize.TabIndex = 22;
            // 
            // L_CensorType
            // 
            this.L_CensorType.AutoSize = true;
            this.L_CensorType.Location = new System.Drawing.Point(28, 316);
            this.L_CensorType.Name = "L_CensorType";
            this.L_CensorType.Size = new System.Drawing.Size(66, 13);
            this.L_CensorType.TabIndex = 21;
            this.L_CensorType.Text = "Censor type:";
            // 
            // COMB_CensorType
            // 
            this.COMB_CensorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMB_CensorType.FormattingEnabled = true;
            this.COMB_CensorType.Items.AddRange(new object[] {
            "Color",
            "Image"});
            this.COMB_CensorType.Location = new System.Drawing.Point(102, 313);
            this.COMB_CensorType.Name = "COMB_CensorType";
            this.COMB_CensorType.Size = new System.Drawing.Size(101, 21);
            this.COMB_CensorType.TabIndex = 20;
            // 
            // CB_Censoring
            // 
            this.CB_Censoring.AutoSize = true;
            this.CB_Censoring.Location = new System.Drawing.Point(9, 290);
            this.CB_Censoring.Name = "CB_Censoring";
            this.CB_Censoring.Size = new System.Drawing.Size(108, 17);
            this.CB_Censoring.TabIndex = 19;
            this.CB_Censoring.Text = "Enable censoring";
            this.CB_Censoring.UseVisualStyleBackColor = true;
            this.CB_Censoring.CheckedChanged += new System.EventHandler(this.CB_Censoring_CheckedChanged);
            // 
            // L_MetronomeChance
            // 
            this.L_MetronomeChance.AutoSize = true;
            this.L_MetronomeChance.Location = new System.Drawing.Point(28, 261);
            this.L_MetronomeChance.Name = "L_MetronomeChance";
            this.L_MetronomeChance.Size = new System.Drawing.Size(55, 13);
            this.L_MetronomeChance.TabIndex = 18;
            this.L_MetronomeChance.Text = "Possibility:";
            // 
            // TB_MetronomeChance
            // 
            this.TB_MetronomeChance.Location = new System.Drawing.Point(102, 248);
            this.TB_MetronomeChance.Minimum = 1;
            this.TB_MetronomeChance.Name = "TB_MetronomeChance";
            this.TB_MetronomeChance.Size = new System.Drawing.Size(302, 45);
            this.TB_MetronomeChance.TabIndex = 17;
            this.TB_MetronomeChance.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TB_MetronomeChance.Value = 5;
            // 
            // NUD_MaxMetronome
            // 
            this.NUD_MaxMetronome.Location = new System.Drawing.Point(303, 217);
            this.NUD_MaxMetronome.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NUD_MaxMetronome.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MaxMetronome.Name = "NUD_MaxMetronome";
            this.NUD_MaxMetronome.Size = new System.Drawing.Size(101, 20);
            this.NUD_MaxMetronome.TabIndex = 16;
            this.NUD_MaxMetronome.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MaxMetronome.ValueChanged += new System.EventHandler(this.NUD_MaxMetronome_ValueChanged);
            // 
            // L_MaxMetronome
            // 
            this.L_MaxMetronome.AutoSize = true;
            this.L_MaxMetronome.Location = new System.Drawing.Point(226, 219);
            this.L_MaxMetronome.Name = "L_MaxMetronome";
            this.L_MaxMetronome.Size = new System.Drawing.Size(71, 13);
            this.L_MaxMetronome.TabIndex = 15;
            this.L_MaxMetronome.Text = "Maximal bpm:";
            // 
            // NUD_MinMetronome
            // 
            this.NUD_MinMetronome.Location = new System.Drawing.Point(102, 217);
            this.NUD_MinMetronome.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.NUD_MinMetronome.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MinMetronome.Name = "NUD_MinMetronome";
            this.NUD_MinMetronome.Size = new System.Drawing.Size(101, 20);
            this.NUD_MinMetronome.TabIndex = 14;
            this.NUD_MinMetronome.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MinMetronome.ValueChanged += new System.EventHandler(this.NUD_MinMetronome_ValueChanged);
            // 
            // L_MinMetronome
            // 
            this.L_MinMetronome.AutoSize = true;
            this.L_MinMetronome.Location = new System.Drawing.Point(28, 219);
            this.L_MinMetronome.Name = "L_MinMetronome";
            this.L_MinMetronome.Size = new System.Drawing.Size(68, 13);
            this.L_MinMetronome.TabIndex = 13;
            this.L_MinMetronome.Text = "Minimal bpm:";
            // 
            // CB_Metronome
            // 
            this.CB_Metronome.AutoSize = true;
            this.CB_Metronome.Location = new System.Drawing.Point(9, 199);
            this.CB_Metronome.Name = "CB_Metronome";
            this.CB_Metronome.Size = new System.Drawing.Size(114, 17);
            this.CB_Metronome.TabIndex = 12;
            this.CB_Metronome.Text = "Enable metronome";
            this.CB_Metronome.UseVisualStyleBackColor = true;
            this.CB_Metronome.CheckedChanged += new System.EventHandler(this.CB_Metronome_CheckedChanged);
            // 
            // RB_EndingRandom
            // 
            this.RB_EndingRandom.AutoSize = true;
            this.RB_EndingRandom.Location = new System.Drawing.Point(303, 165);
            this.RB_EndingRandom.Name = "RB_EndingRandom";
            this.RB_EndingRandom.Size = new System.Drawing.Size(112, 17);
            this.RB_EndingRandom.TabIndex = 11;
            this.RB_EndingRandom.TabStop = true;
            this.RB_EndingRandom.Text = "let program decide";
            this.RB_EndingRandom.UseVisualStyleBackColor = true;
            // 
            // RB_EndingRed
            // 
            this.RB_EndingRed.AutoSize = true;
            this.RB_EndingRed.Location = new System.Drawing.Point(185, 165);
            this.RB_EndingRed.Name = "RB_EndingRed";
            this.RB_EndingRed.Size = new System.Drawing.Size(112, 17);
            this.RB_EndingRed.TabIndex = 10;
            this.RB_EndingRed.TabStop = true;
            this.RB_EndingRed.Text = "always on red light";
            this.RB_EndingRed.UseVisualStyleBackColor = true;
            // 
            // RB_EndingGreen
            // 
            this.RB_EndingGreen.AutoSize = true;
            this.RB_EndingGreen.Location = new System.Drawing.Point(55, 165);
            this.RB_EndingGreen.Name = "RB_EndingGreen";
            this.RB_EndingGreen.Size = new System.Drawing.Size(124, 17);
            this.RB_EndingGreen.TabIndex = 9;
            this.RB_EndingGreen.TabStop = true;
            this.RB_EndingGreen.Text = "always on green light";
            this.RB_EndingGreen.UseVisualStyleBackColor = true;
            // 
            // L_Ending
            // 
            this.L_Ending.AutoSize = true;
            this.L_Ending.Location = new System.Drawing.Point(6, 167);
            this.L_Ending.Name = "L_Ending";
            this.L_Ending.Size = new System.Drawing.Size(43, 13);
            this.L_Ending.TabIndex = 8;
            this.L_Ending.Text = "Ending:";
            // 
            // NUD_MaxRed
            // 
            this.NUD_MaxRed.Location = new System.Drawing.Point(162, 115);
            this.NUD_MaxRed.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.NUD_MaxRed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MaxRed.Name = "NUD_MaxRed";
            this.NUD_MaxRed.Size = new System.Drawing.Size(253, 20);
            this.NUD_MaxRed.TabIndex = 7;
            this.NUD_MaxRed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MaxRed.ValueChanged += new System.EventHandler(this.NUD_MaxRed_ValueChanged);
            // 
            // L_MaxRed
            // 
            this.L_MaxRed.AutoSize = true;
            this.L_MaxRed.Location = new System.Drawing.Point(6, 117);
            this.L_MaxRed.Name = "L_MaxRed";
            this.L_MaxRed.Size = new System.Drawing.Size(141, 13);
            this.L_MaxRed.TabIndex = 6;
            this.L_MaxRed.Text = "Maximal duration of red light:";
            // 
            // NUD_MinRed
            // 
            this.NUD_MinRed.Location = new System.Drawing.Point(162, 87);
            this.NUD_MinRed.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.NUD_MinRed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MinRed.Name = "NUD_MinRed";
            this.NUD_MinRed.Size = new System.Drawing.Size(253, 20);
            this.NUD_MinRed.TabIndex = 5;
            this.NUD_MinRed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MinRed.ValueChanged += new System.EventHandler(this.NUD_MinRed_ValueChanged);
            // 
            // L_MinRed
            // 
            this.L_MinRed.AutoSize = true;
            this.L_MinRed.Location = new System.Drawing.Point(6, 89);
            this.L_MinRed.Name = "L_MinRed";
            this.L_MinRed.Size = new System.Drawing.Size(138, 13);
            this.L_MinRed.TabIndex = 4;
            this.L_MinRed.Text = "Minimal duration of red light:";
            // 
            // NUD_MaxGreen
            // 
            this.NUD_MaxGreen.Location = new System.Drawing.Point(162, 56);
            this.NUD_MaxGreen.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.NUD_MaxGreen.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MaxGreen.Name = "NUD_MaxGreen";
            this.NUD_MaxGreen.Size = new System.Drawing.Size(253, 20);
            this.NUD_MaxGreen.TabIndex = 3;
            this.NUD_MaxGreen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MaxGreen.ValueChanged += new System.EventHandler(this.NUD_MaxGreen_ValueChanged);
            // 
            // L_MaxGreen
            // 
            this.L_MaxGreen.AutoSize = true;
            this.L_MaxGreen.Location = new System.Drawing.Point(6, 58);
            this.L_MaxGreen.Name = "L_MaxGreen";
            this.L_MaxGreen.Size = new System.Drawing.Size(153, 13);
            this.L_MaxGreen.TabIndex = 2;
            this.L_MaxGreen.Text = "Maximal duration of green light:";
            // 
            // NUD_MinGreen
            // 
            this.NUD_MinGreen.Location = new System.Drawing.Point(162, 28);
            this.NUD_MinGreen.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.NUD_MinGreen.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MinGreen.Name = "NUD_MinGreen";
            this.NUD_MinGreen.Size = new System.Drawing.Size(253, 20);
            this.NUD_MinGreen.TabIndex = 1;
            this.NUD_MinGreen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_MinGreen.ValueChanged += new System.EventHandler(this.NUD_MinGreen_ValueChanged);
            // 
            // L_GreenMin
            // 
            this.L_GreenMin.AutoSize = true;
            this.L_GreenMin.Location = new System.Drawing.Point(6, 30);
            this.L_GreenMin.Name = "L_GreenMin";
            this.L_GreenMin.Size = new System.Drawing.Size(150, 13);
            this.L_GreenMin.TabIndex = 0;
            this.L_GreenMin.Text = "Minimal duration of green light:";
            // 
            // GB_ProgramSettings
            // 
            this.GB_ProgramSettings.Controls.Add(this.B_CensorPath);
            this.GB_ProgramSettings.Controls.Add(this.TBox_CensorPath);
            this.GB_ProgramSettings.Controls.Add(this.L_CensorPath);
            this.GB_ProgramSettings.Controls.Add(this.P_CensorColor);
            this.GB_ProgramSettings.Controls.Add(this.L_CensorColor);
            this.GB_ProgramSettings.Controls.Add(this.P_RedLightColor);
            this.GB_ProgramSettings.Controls.Add(this.L_RedLightColor);
            this.GB_ProgramSettings.Controls.Add(this.P_GreenLightColor);
            this.GB_ProgramSettings.Controls.Add(this.L_GreenLightColor);
            this.GB_ProgramSettings.Location = new System.Drawing.Point(439, 12);
            this.GB_ProgramSettings.Name = "GB_ProgramSettings";
            this.GB_ProgramSettings.Size = new System.Drawing.Size(420, 205);
            this.GB_ProgramSettings.TabIndex = 1;
            this.GB_ProgramSettings.TabStop = false;
            this.GB_ProgramSettings.Text = "General Settings";
            // 
            // B_CensorPath
            // 
            this.B_CensorPath.Location = new System.Drawing.Point(383, 162);
            this.B_CensorPath.Name = "B_CensorPath";
            this.B_CensorPath.Size = new System.Drawing.Size(31, 23);
            this.B_CensorPath.TabIndex = 4;
            this.B_CensorPath.Text = "...";
            this.B_CensorPath.UseVisualStyleBackColor = true;
            this.B_CensorPath.Click += new System.EventHandler(this.B_CensorPath_Click);
            // 
            // TBox_CensorPath
            // 
            this.TBox_CensorPath.Location = new System.Drawing.Point(115, 164);
            this.TBox_CensorPath.Name = "TBox_CensorPath";
            this.TBox_CensorPath.Size = new System.Drawing.Size(262, 20);
            this.TBox_CensorPath.TabIndex = 7;
            // 
            // L_CensorPath
            // 
            this.L_CensorPath.AutoSize = true;
            this.L_CensorPath.Location = new System.Drawing.Point(6, 167);
            this.L_CensorPath.Name = "L_CensorPath";
            this.L_CensorPath.Size = new System.Drawing.Size(103, 13);
            this.L_CensorPath.TabIndex = 6;
            this.L_CensorPath.Text = "Censor images path:";
            // 
            // P_CensorColor
            // 
            this.P_CensorColor.BackColor = System.Drawing.Color.Black;
            this.P_CensorColor.Location = new System.Drawing.Point(99, 89);
            this.P_CensorColor.Name = "P_CensorColor";
            this.P_CensorColor.Size = new System.Drawing.Size(316, 26);
            this.P_CensorColor.TabIndex = 5;
            this.P_CensorColor.Click += new System.EventHandler(this.P_CensorColor_Click);
            // 
            // L_CensorColor
            // 
            this.L_CensorColor.AutoSize = true;
            this.L_CensorColor.Location = new System.Drawing.Point(6, 94);
            this.L_CensorColor.Name = "L_CensorColor";
            this.L_CensorColor.Size = new System.Drawing.Size(84, 13);
            this.L_CensorColor.TabIndex = 4;
            this.L_CensorColor.Text = "Censorbar color:";
            // 
            // P_RedLightColor
            // 
            this.P_RedLightColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.P_RedLightColor.Location = new System.Drawing.Point(99, 57);
            this.P_RedLightColor.Name = "P_RedLightColor";
            this.P_RedLightColor.Size = new System.Drawing.Size(316, 26);
            this.P_RedLightColor.TabIndex = 3;
            this.P_RedLightColor.Click += new System.EventHandler(this.P_RedLightColor_Click);
            // 
            // L_RedLightColor
            // 
            this.L_RedLightColor.AutoSize = true;
            this.L_RedLightColor.Location = new System.Drawing.Point(6, 62);
            this.L_RedLightColor.Name = "L_RedLightColor";
            this.L_RedLightColor.Size = new System.Drawing.Size(78, 13);
            this.L_RedLightColor.TabIndex = 2;
            this.L_RedLightColor.Text = "Red light color:";
            // 
            // P_GreenLightColor
            // 
            this.P_GreenLightColor.BackColor = System.Drawing.Color.Green;
            this.P_GreenLightColor.Location = new System.Drawing.Point(99, 25);
            this.P_GreenLightColor.Name = "P_GreenLightColor";
            this.P_GreenLightColor.Size = new System.Drawing.Size(316, 26);
            this.P_GreenLightColor.TabIndex = 1;
            this.P_GreenLightColor.Click += new System.EventHandler(this.P_GreenLightColor_Click);
            // 
            // L_GreenLightColor
            // 
            this.L_GreenLightColor.AutoSize = true;
            this.L_GreenLightColor.Location = new System.Drawing.Point(6, 30);
            this.L_GreenLightColor.Name = "L_GreenLightColor";
            this.L_GreenLightColor.Size = new System.Drawing.Size(87, 13);
            this.L_GreenLightColor.TabIndex = 0;
            this.L_GreenLightColor.Text = "Green light color:";
            // 
            // B_SaveExit
            // 
            this.B_SaveExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_SaveExit.Location = new System.Drawing.Point(767, 417);
            this.B_SaveExit.Name = "B_SaveExit";
            this.B_SaveExit.Size = new System.Drawing.Size(92, 23);
            this.B_SaveExit.TabIndex = 2;
            this.B_SaveExit.Text = "Save and exit";
            this.B_SaveExit.UseVisualStyleBackColor = true;
            // 
            // B_Cancel
            // 
            this.B_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_Cancel.Location = new System.Drawing.Point(12, 417);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(92, 23);
            this.B_Cancel.TabIndex = 3;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            // 
            // FolderSelector
            // 
            this.FolderSelector.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // L_OnlyGreenLight
            // 
            this.L_OnlyGreenLight.AutoSize = true;
            this.L_OnlyGreenLight.Location = new System.Drawing.Point(99, 376);
            this.L_OnlyGreenLight.Name = "L_OnlyGreenLight";
            this.L_OnlyGreenLight.Size = new System.Drawing.Size(156, 13);
            this.L_OnlyGreenLight.TabIndex = 26;
            this.L_OnlyGreenLight.Text = "|--- censor only on green light ---|";
            // 
            // L_BothLights
            // 
            this.L_BothLights.AutoSize = true;
            this.L_BothLights.BackColor = System.Drawing.SystemColors.Control;
            this.L_BothLights.Location = new System.Drawing.Point(251, 376);
            this.L_BothLights.Name = "L_BothLights";
            this.L_BothLights.Size = new System.Drawing.Size(157, 13);
            this.L_BothLights.TabIndex = 27;
            this.L_BothLights.Text = "|------- censor on both lights -------|";
            // 
            // PreferencesDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 452);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_SaveExit);
            this.Controls.Add(this.GB_ProgramSettings);
            this.Controls.Add(this.GB_RLGLSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences...";
            this.GB_RLGLSettings.ResumeLayout(false);
            this.GB_RLGLSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_CensorProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_MetronomeChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MaxMetronome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MinMetronome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MaxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MinRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MaxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MinGreen)).EndInit();
            this.GB_ProgramSettings.ResumeLayout(false);
            this.GB_ProgramSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog ColorPicker;
        private System.Windows.Forms.GroupBox GB_RLGLSettings;
        private System.Windows.Forms.Label L_Ending;
        private System.Windows.Forms.Label L_MaxRed;
        private System.Windows.Forms.Label L_MinRed;
        private System.Windows.Forms.Label L_MaxGreen;
        private System.Windows.Forms.Label L_GreenMin;
        private System.Windows.Forms.GroupBox GB_ProgramSettings;
        private System.Windows.Forms.Label L_RedLightColor;
        private System.Windows.Forms.Label L_GreenLightColor;
        private System.Windows.Forms.Button B_SaveExit;
        private System.Windows.Forms.Button B_Cancel;
        public System.Windows.Forms.RadioButton RB_EndingRandom;
        public System.Windows.Forms.RadioButton RB_EndingRed;
        public System.Windows.Forms.RadioButton RB_EndingGreen;
        public System.Windows.Forms.NumericUpDown NUD_MaxRed;
        public System.Windows.Forms.NumericUpDown NUD_MinRed;
        public System.Windows.Forms.NumericUpDown NUD_MaxGreen;
        public System.Windows.Forms.NumericUpDown NUD_MinGreen;
        public System.Windows.Forms.Panel P_RedLightColor;
        public System.Windows.Forms.Panel P_GreenLightColor;
        private System.Windows.Forms.Label L_MetronomeChance;
        public System.Windows.Forms.TrackBar TB_MetronomeChance;
        public System.Windows.Forms.NumericUpDown NUD_MaxMetronome;
        private System.Windows.Forms.Label L_MaxMetronome;
        public System.Windows.Forms.NumericUpDown NUD_MinMetronome;
        private System.Windows.Forms.Label L_MinMetronome;
        public System.Windows.Forms.CheckBox CB_Metronome;
        public System.Windows.Forms.Panel P_CensorColor;
        private System.Windows.Forms.Label L_CensorColor;
        public System.Windows.Forms.CheckBox CB_Censoring;
        private System.Windows.Forms.Label L_CensorSize;
        private System.Windows.Forms.Label L_CensorType;
        private System.Windows.Forms.Label L_CensorPossibility;
        public System.Windows.Forms.TrackBar TB_CensorProbability;
        private System.Windows.Forms.Button B_CensorPath;
        public System.Windows.Forms.TextBox TBox_CensorPath;
        private System.Windows.Forms.Label L_CensorPath;
        private System.Windows.Forms.FolderBrowserDialog FolderSelector;
        public System.Windows.Forms.ComboBox COMB_CensorSize;
        public System.Windows.Forms.ComboBox COMB_CensorType;
        private System.Windows.Forms.Label L_BothLights;
        private System.Windows.Forms.Label L_OnlyGreenLight;
    }
}