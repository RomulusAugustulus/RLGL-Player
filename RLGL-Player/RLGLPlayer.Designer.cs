namespace RLGL_Player
{
    partial class RLGLPlayer
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RLGLPlayer));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.censorEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VLC_Panel = new System.Windows.Forms.Panel();
            this.RLGL_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.VLC_Control = new LibVLCSharp.WinForms.VideoView();
            this.L_Text = new System.Windows.Forms.Label();
            this.L_TimePassed = new System.Windows.Forms.Label();
            this.P_ShowVolumeBar = new System.Windows.Forms.Panel();
            this.OpenQueueDlg = new System.Windows.Forms.OpenFileDialog();
            this.RLGL_SwitchTimer = new System.Windows.Forms.Timer(this.components);
            this.RLGL_VideoEndTimer = new System.Windows.Forms.Timer(this.components);
            this.RLGL_Metronome = new System.Windows.Forms.Timer(this.components);
            this.RLGL_Censor = new System.Windows.Forms.Timer(this.components);
            this.RLGL_EdgingTimer = new System.Windows.Forms.Timer(this.components);
            this.RLGL_Timer = new System.Windows.Forms.Timer(this.components);
            this.SaveQueueDlg = new System.Windows.Forms.SaveFileDialog();
            this.RLGL_HideVolumeBar = new System.Windows.Forms.Timer(this.components);
            this.RLGL_CountdownTimer = new System.Windows.Forms.Timer(this.components);
            this.saveSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenu.SuspendLayout();
            this.VLC_Panel.SuspendLayout();
            this.RLGL_Layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLC_Control)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sessionToolStripMenuItem,
            this.editorToolStripMenuItem,
            this.toolStripMenuItem2});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1076, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.toolStripMenuItem3,
            this.preferencesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadToolStripMenuItem.Text = "&Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.preferencesToolStripMenuItem.Text = "&Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartSessionToolStripMenuItem,
            this.endSessionToolStripMenuItem,
            this.toolStripMenuItem4,
            this.saveSessionToolStripMenuItem});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.sessionToolStripMenuItem.Text = "&Session";
            // 
            // endSessionToolStripMenuItem
            // 
            this.endSessionToolStripMenuItem.Enabled = false;
            this.endSessionToolStripMenuItem.Name = "endSessionToolStripMenuItem";
            this.endSessionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.endSessionToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.endSessionToolStripMenuItem.Text = "&End session";
            this.endSessionToolStripMenuItem.Click += new System.EventHandler(this.endSessionToolStripMenuItem_Click);
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.censorEditorToolStripMenuItem});
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.editorToolStripMenuItem.Text = "&Editor";
            // 
            // censorEditorToolStripMenuItem
            // 
            this.censorEditorToolStripMenuItem.Name = "censorEditorToolStripMenuItem";
            this.censorEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.censorEditorToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.censorEditorToolStripMenuItem.Text = "&Censor Editor...";
            this.censorEditorToolStripMenuItem.Click += new System.EventHandler(this.censorEditorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem2.Text = "&?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // VLC_Panel
            // 
            this.VLC_Panel.Controls.Add(this.RLGL_Layout);
            this.VLC_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VLC_Panel.Location = new System.Drawing.Point(0, 24);
            this.VLC_Panel.Name = "VLC_Panel";
            this.VLC_Panel.Size = new System.Drawing.Size(1076, 563);
            this.VLC_Panel.TabIndex = 1;
            // 
            // RLGL_Layout
            // 
            this.RLGL_Layout.BackColor = System.Drawing.SystemColors.Control;
            this.RLGL_Layout.ColumnCount = 3;
            this.RLGL_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RLGL_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RLGL_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RLGL_Layout.Controls.Add(this.VLC_Control, 1, 1);
            this.RLGL_Layout.Controls.Add(this.L_Text, 1, 3);
            this.RLGL_Layout.Controls.Add(this.L_TimePassed, 2, 3);
            this.RLGL_Layout.Controls.Add(this.P_ShowVolumeBar, 0, 3);
            this.RLGL_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RLGL_Layout.Location = new System.Drawing.Point(0, 0);
            this.RLGL_Layout.Margin = new System.Windows.Forms.Padding(0);
            this.RLGL_Layout.Name = "RLGL_Layout";
            this.RLGL_Layout.RowCount = 4;
            this.RLGL_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RLGL_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RLGL_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RLGL_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RLGL_Layout.Size = new System.Drawing.Size(1076, 563);
            this.RLGL_Layout.TabIndex = 1;
            // 
            // VLC_Control
            // 
            this.VLC_Control.BackColor = System.Drawing.Color.Black;
            this.VLC_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VLC_Control.Location = new System.Drawing.Point(53, 53);
            this.VLC_Control.MediaPlayer = null;
            this.VLC_Control.Name = "VLC_Control";
            this.RLGL_Layout.SetRowSpan(this.VLC_Control, 2);
            this.VLC_Control.Size = new System.Drawing.Size(970, 457);
            this.VLC_Control.TabIndex = 2;
            this.VLC_Control.Text = "videoView1";
            this.VLC_Control.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VLC_Control_KeyDown);
            // 
            // L_Text
            // 
            this.L_Text.AutoSize = true;
            this.L_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_Text.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Text.Location = new System.Drawing.Point(53, 513);
            this.L_Text.Name = "L_Text";
            this.L_Text.Size = new System.Drawing.Size(970, 50);
            this.L_Text.TabIndex = 1;
            this.L_Text.Text = "label1";
            this.L_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L_Text.MouseHover += new System.EventHandler(this.L_Text_MouseHover);
            // 
            // L_TimePassed
            // 
            this.L_TimePassed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_TimePassed.Location = new System.Drawing.Point(1029, 513);
            this.L_TimePassed.Name = "L_TimePassed";
            this.L_TimePassed.Size = new System.Drawing.Size(44, 50);
            this.L_TimePassed.TabIndex = 4;
            this.L_TimePassed.Text = "Time";
            this.L_TimePassed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P_ShowVolumeBar
            // 
            this.P_ShowVolumeBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_ShowVolumeBar.Location = new System.Drawing.Point(3, 516);
            this.P_ShowVolumeBar.Name = "P_ShowVolumeBar";
            this.P_ShowVolumeBar.Size = new System.Drawing.Size(44, 44);
            this.P_ShowVolumeBar.TabIndex = 5;
            this.P_ShowVolumeBar.MouseHover += new System.EventHandler(this.L_Text_MouseHover);
            // 
            // OpenQueueDlg
            // 
            this.OpenQueueDlg.Filter = "RLGL-Playlist (*.rgp)|*.rgp";
            this.OpenQueueDlg.Title = "Load Playlist...";
            // 
            // RLGL_SwitchTimer
            // 
            this.RLGL_SwitchTimer.Tick += new System.EventHandler(this.RLGL_SwitchTimer_Tick);
            // 
            // RLGL_VideoEndTimer
            // 
            this.RLGL_VideoEndTimer.Tick += new System.EventHandler(this.RLGL_VideoEndTimer_Tick);
            // 
            // RLGL_Metronome
            // 
            this.RLGL_Metronome.Tick += new System.EventHandler(this.RLGL_Metronome_Tick);
            // 
            // RLGL_Censor
            // 
            this.RLGL_Censor.Interval = 250;
            this.RLGL_Censor.Tick += new System.EventHandler(this.RLGL_Censor_Tick);
            // 
            // RLGL_EdgingTimer
            // 
            this.RLGL_EdgingTimer.Tick += new System.EventHandler(this.RLGL_EdgingTimer_Tick);
            // 
            // RLGL_Timer
            // 
            this.RLGL_Timer.Interval = 1000;
            this.RLGL_Timer.Tick += new System.EventHandler(this.RLGL_Timer_Tick);
            // 
            // SaveQueueDlg
            // 
            this.SaveQueueDlg.DefaultExt = "rgp";
            this.SaveQueueDlg.Filter = "RLGL-Playlist (*.rgp)|*.rgp";
            this.SaveQueueDlg.Title = "Save Playlist...";
            // 
            // RLGL_HideVolumeBar
            // 
            this.RLGL_HideVolumeBar.Interval = 3000;
            this.RLGL_HideVolumeBar.Tick += new System.EventHandler(this.RLGL_HideVolumeBar_Tick);
            // 
            // RLGL_CountdownTimer
            // 
            this.RLGL_CountdownTimer.Tick += new System.EventHandler(this.RLGL_CountdownTimer_Tick);
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Enabled = false;
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.saveSessionToolStripMenuItem.Text = "&Save last session as playlist";
            this.saveSessionToolStripMenuItem.Click += new System.EventHandler(this.saveSessionToolStripMenuItem_Click);
            // 
            // restartSessionToolStripMenuItem
            // 
            this.restartSessionToolStripMenuItem.Enabled = false;
            this.restartSessionToolStripMenuItem.Name = "restartSessionToolStripMenuItem";
            this.restartSessionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.restartSessionToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.restartSessionToolStripMenuItem.Text = "&Restart last session";
            this.restartSessionToolStripMenuItem.Click += new System.EventHandler(this.restartSessionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(253, 6);
            // 
            // RLGLPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 587);
            this.Controls.Add(this.VLC_Panel);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "RLGLPlayer";
            this.Text = "RLGL-Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.Move += new System.EventHandler(this.RLGLPlayer_Move);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.VLC_Panel.ResumeLayout(false);
            this.RLGL_Layout.ResumeLayout(false);
            this.RLGL_Layout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLC_Control)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel VLC_Panel;
        private System.Windows.Forms.OpenFileDialog OpenQueueDlg;
        private System.Windows.Forms.TableLayoutPanel RLGL_Layout;
        private System.Windows.Forms.Label L_Text;
        private System.Windows.Forms.Timer RLGL_SwitchTimer;
        private System.Windows.Forms.Timer RLGL_VideoEndTimer;
        private System.Windows.Forms.Timer RLGL_Metronome;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem censorEditorToolStripMenuItem;
        private System.Windows.Forms.Timer RLGL_Censor;
        private System.Windows.Forms.Timer RLGL_EdgingTimer;
        private System.Windows.Forms.Label L_TimePassed;
        private System.Windows.Forms.Timer RLGL_Timer;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.SaveFileDialog SaveQueueDlg;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endSessionToolStripMenuItem;
        private System.Windows.Forms.Timer RLGL_HideVolumeBar;
        private System.Windows.Forms.Timer RLGL_CountdownTimer;
        private System.Windows.Forms.Panel P_ShowVolumeBar;
        private LibVLCSharp.WinForms.VideoView VLC_Control;
        private System.Windows.Forms.ToolStripMenuItem saveSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    }
}

