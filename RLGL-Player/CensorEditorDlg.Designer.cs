
namespace RLGL_Player
{
    partial class CensorEditorDlg
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
            this.CensorEditorMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TLP_CensorEditor = new System.Windows.Forms.TableLayoutPanel();
            this.VLC_Editor = new Vlc.DotNet.Forms.VlcControl();
            this.FLP_PauseResume = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_GeneralCensorbarSize = new System.Windows.Forms.ComboBox();
            this.B_PauseResume = new System.Windows.Forms.Button();
            this.B_Delete = new System.Windows.Forms.Button();
            this.B_NewCensorbar = new System.Windows.Forms.Button();
            this.GB_Censorbar = new System.Windows.Forms.GroupBox();
            this.FLP_Censorbars = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_KeyframeOptions = new System.Windows.Forms.GroupBox();
            this.CB_CensorSize = new System.Windows.Forms.ComboBox();
            this.L_SpecialCensorbarSize = new System.Windows.Forms.Label();
            this.B_UpdateFrame = new System.Windows.Forms.Button();
            this.CB_EndFrame = new System.Windows.Forms.CheckBox();
            this.L_Position = new System.Windows.Forms.Label();
            this.DB_Y = new RLGL_Player.DecimalBox();
            this.DB_X = new RLGL_Player.DecimalBox();
            this.L_CensorbarIdValue = new System.Windows.Forms.Label();
            this.L_CensorbarId = new System.Windows.Forms.Label();
            this.L_TimeStampValue = new System.Windows.Forms.Label();
            this.L_TimeStamp = new System.Windows.Forms.Label();
            this.PB_KeyframeDrawingWindow = new System.Windows.Forms.PictureBox();
            this.SB_Keyframes = new System.Windows.Forms.VScrollBar();
            this.TB_VideoPosition = new System.Windows.Forms.TrackBar();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.CensorEditorMenu.SuspendLayout();
            this.TLP_CensorEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLC_Editor)).BeginInit();
            this.FLP_PauseResume.SuspendLayout();
            this.GB_Censorbar.SuspendLayout();
            this.CB_KeyframeOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_KeyframeDrawingWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_VideoPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // CensorEditorMenu
            // 
            this.CensorEditorMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.CensorEditorMenu.Location = new System.Drawing.Point(0, 0);
            this.CensorEditorMenu.Name = "CensorEditorMenu";
            this.CensorEditorMenu.Size = new System.Drawing.Size(1036, 24);
            this.CensorEditorMenu.TabIndex = 0;
            this.CensorEditorMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newToolStripMenuItem.Text = "&New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.loadToolStripMenuItem.Text = "&Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveToolStripMenuItem.Text = "&Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // TLP_CensorEditor
            // 
            this.TLP_CensorEditor.ColumnCount = 3;
            this.TLP_CensorEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TLP_CensorEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_CensorEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP_CensorEditor.Controls.Add(this.VLC_Editor, 1, 0);
            this.TLP_CensorEditor.Controls.Add(this.FLP_PauseResume, 0, 1);
            this.TLP_CensorEditor.Controls.Add(this.GB_Censorbar, 0, 0);
            this.TLP_CensorEditor.Controls.Add(this.CB_KeyframeOptions, 0, 3);
            this.TLP_CensorEditor.Controls.Add(this.PB_KeyframeDrawingWindow, 1, 3);
            this.TLP_CensorEditor.Controls.Add(this.SB_Keyframes, 2, 3);
            this.TLP_CensorEditor.Controls.Add(this.TB_VideoPosition, 1, 2);
            this.TLP_CensorEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_CensorEditor.Location = new System.Drawing.Point(0, 24);
            this.TLP_CensorEditor.Name = "TLP_CensorEditor";
            this.TLP_CensorEditor.RowCount = 4;
            this.TLP_CensorEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_CensorEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_CensorEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TLP_CensorEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TLP_CensorEditor.Size = new System.Drawing.Size(1036, 635);
            this.TLP_CensorEditor.TabIndex = 1;
            // 
            // VLC_Editor
            // 
            this.VLC_Editor.BackColor = System.Drawing.Color.Black;
            this.VLC_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VLC_Editor.Location = new System.Drawing.Point(203, 3);
            this.VLC_Editor.Name = "VLC_Editor";
            this.TLP_CensorEditor.SetRowSpan(this.VLC_Editor, 2);
            this.VLC_Editor.Size = new System.Drawing.Size(810, 429);
            this.VLC_Editor.Spu = -1;
            this.VLC_Editor.TabIndex = 0;
            this.VLC_Editor.Text = "vlcControl1";
            this.VLC_Editor.VlcLibDirectory = null;
            this.VLC_Editor.VlcMediaplayerOptions = null;
            this.VLC_Editor.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.VLC_Editor_VlcLibDirectoryNeeded);
            this.VLC_Editor.Playing += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs>(this.VLC_Editor_Playing);
            this.VLC_Editor.PositionChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs>(this.VLC_Editor_PositionChanged);
            this.VLC_Editor.Stopped += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs>(this.VLC_Editor_Stopped);
            // 
            // FLP_PauseResume
            // 
            this.FLP_PauseResume.Controls.Add(this.CB_GeneralCensorbarSize);
            this.FLP_PauseResume.Controls.Add(this.B_PauseResume);
            this.FLP_PauseResume.Controls.Add(this.B_Delete);
            this.FLP_PauseResume.Controls.Add(this.B_NewCensorbar);
            this.FLP_PauseResume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP_PauseResume.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FLP_PauseResume.Location = new System.Drawing.Point(3, 398);
            this.FLP_PauseResume.Name = "FLP_PauseResume";
            this.TLP_CensorEditor.SetRowSpan(this.FLP_PauseResume, 2);
            this.FLP_PauseResume.Size = new System.Drawing.Size(194, 74);
            this.FLP_PauseResume.TabIndex = 3;
            // 
            // CB_GeneralCensorbarSize
            // 
            this.CB_GeneralCensorbarSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_GeneralCensorbarSize.Enabled = false;
            this.CB_GeneralCensorbarSize.FormattingEnabled = true;
            this.CB_GeneralCensorbarSize.ItemHeight = 13;
            this.CB_GeneralCensorbarSize.Items.AddRange(new object[] {
            "Default",
            "Small",
            "Medium",
            "Big",
            "Unfair"});
            this.CB_GeneralCensorbarSize.Location = new System.Drawing.Point(14, 3);
            this.CB_GeneralCensorbarSize.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.CB_GeneralCensorbarSize.Name = "CB_GeneralCensorbarSize";
            this.CB_GeneralCensorbarSize.Size = new System.Drawing.Size(177, 21);
            this.CB_GeneralCensorbarSize.TabIndex = 5;
            this.CB_GeneralCensorbarSize.SelectedIndexChanged += new System.EventHandler(this.CB_GeneralCensorbarSize_SelectedIndexChanged);
            // 
            // B_PauseResume
            // 
            this.B_PauseResume.Enabled = false;
            this.B_PauseResume.Location = new System.Drawing.Point(136, 36);
            this.B_PauseResume.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.B_PauseResume.Name = "B_PauseResume";
            this.B_PauseResume.Size = new System.Drawing.Size(55, 27);
            this.B_PauseResume.TabIndex = 2;
            this.B_PauseResume.Text = "Pause";
            this.B_PauseResume.UseVisualStyleBackColor = true;
            this.B_PauseResume.Click += new System.EventHandler(this.B_PauseResume_Click);
            // 
            // B_Delete
            // 
            this.B_Delete.Enabled = false;
            this.B_Delete.Location = new System.Drawing.Point(75, 36);
            this.B_Delete.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.B_Delete.Name = "B_Delete";
            this.B_Delete.Size = new System.Drawing.Size(55, 27);
            this.B_Delete.TabIndex = 4;
            this.B_Delete.Text = "Delete";
            this.B_Delete.UseVisualStyleBackColor = true;
            this.B_Delete.Click += new System.EventHandler(this.B_Delete_Click);
            // 
            // B_NewCensorbar
            // 
            this.B_NewCensorbar.Enabled = false;
            this.B_NewCensorbar.Location = new System.Drawing.Point(14, 36);
            this.B_NewCensorbar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.B_NewCensorbar.Name = "B_NewCensorbar";
            this.B_NewCensorbar.Size = new System.Drawing.Size(55, 27);
            this.B_NewCensorbar.TabIndex = 3;
            this.B_NewCensorbar.Text = "New";
            this.B_NewCensorbar.UseVisualStyleBackColor = true;
            this.B_NewCensorbar.Click += new System.EventHandler(this.B_NewCensorbar_Click);
            // 
            // GB_Censorbar
            // 
            this.GB_Censorbar.Controls.Add(this.FLP_Censorbars);
            this.GB_Censorbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_Censorbar.Location = new System.Drawing.Point(3, 3);
            this.GB_Censorbar.Name = "GB_Censorbar";
            this.GB_Censorbar.Size = new System.Drawing.Size(194, 389);
            this.GB_Censorbar.TabIndex = 4;
            this.GB_Censorbar.TabStop = false;
            this.GB_Censorbar.Text = "Censorbar";
            // 
            // FLP_Censorbars
            // 
            this.FLP_Censorbars.AutoScroll = true;
            this.FLP_Censorbars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP_Censorbars.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP_Censorbars.Location = new System.Drawing.Point(3, 16);
            this.FLP_Censorbars.Name = "FLP_Censorbars";
            this.FLP_Censorbars.Size = new System.Drawing.Size(188, 370);
            this.FLP_Censorbars.TabIndex = 0;
            // 
            // CB_KeyframeOptions
            // 
            this.CB_KeyframeOptions.Controls.Add(this.CB_CensorSize);
            this.CB_KeyframeOptions.Controls.Add(this.L_SpecialCensorbarSize);
            this.CB_KeyframeOptions.Controls.Add(this.B_UpdateFrame);
            this.CB_KeyframeOptions.Controls.Add(this.CB_EndFrame);
            this.CB_KeyframeOptions.Controls.Add(this.L_Position);
            this.CB_KeyframeOptions.Controls.Add(this.DB_Y);
            this.CB_KeyframeOptions.Controls.Add(this.DB_X);
            this.CB_KeyframeOptions.Controls.Add(this.L_CensorbarIdValue);
            this.CB_KeyframeOptions.Controls.Add(this.L_CensorbarId);
            this.CB_KeyframeOptions.Controls.Add(this.L_TimeStampValue);
            this.CB_KeyframeOptions.Controls.Add(this.L_TimeStamp);
            this.CB_KeyframeOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_KeyframeOptions.Location = new System.Drawing.Point(3, 478);
            this.CB_KeyframeOptions.Name = "CB_KeyframeOptions";
            this.CB_KeyframeOptions.Size = new System.Drawing.Size(194, 154);
            this.CB_KeyframeOptions.TabIndex = 7;
            this.CB_KeyframeOptions.TabStop = false;
            this.CB_KeyframeOptions.Text = "Keyframe Options";
            // 
            // CB_CensorSize
            // 
            this.CB_CensorSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_CensorSize.Enabled = false;
            this.CB_CensorSize.FormattingEnabled = true;
            this.CB_CensorSize.Items.AddRange(new object[] {
            "Default",
            "Small",
            "Medium",
            "Big",
            "Unfair"});
            this.CB_CensorSize.Location = new System.Drawing.Point(82, 98);
            this.CB_CensorSize.MaxDropDownItems = 5;
            this.CB_CensorSize.Name = "CB_CensorSize";
            this.CB_CensorSize.Size = new System.Drawing.Size(106, 21);
            this.CB_CensorSize.TabIndex = 10;
            // 
            // L_SpecialCensorbarSize
            // 
            this.L_SpecialCensorbarSize.AutoSize = true;
            this.L_SpecialCensorbarSize.Location = new System.Drawing.Point(11, 101);
            this.L_SpecialCensorbarSize.Name = "L_SpecialCensorbarSize";
            this.L_SpecialCensorbarSize.Size = new System.Drawing.Size(64, 13);
            this.L_SpecialCensorbarSize.TabIndex = 9;
            this.L_SpecialCensorbarSize.Text = "Censor size:";
            // 
            // B_UpdateFrame
            // 
            this.B_UpdateFrame.Enabled = false;
            this.B_UpdateFrame.Location = new System.Drawing.Point(113, 125);
            this.B_UpdateFrame.Name = "B_UpdateFrame";
            this.B_UpdateFrame.Size = new System.Drawing.Size(75, 23);
            this.B_UpdateFrame.TabIndex = 8;
            this.B_UpdateFrame.Text = "Update";
            this.B_UpdateFrame.UseVisualStyleBackColor = true;
            this.B_UpdateFrame.Click += new System.EventHandler(this.B_UpdateFrame_Click);
            // 
            // CB_EndFrame
            // 
            this.CB_EndFrame.AutoSize = true;
            this.CB_EndFrame.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CB_EndFrame.Enabled = false;
            this.CB_EndFrame.Location = new System.Drawing.Point(8, 77);
            this.CB_EndFrame.Name = "CB_EndFrame";
            this.CB_EndFrame.Size = new System.Drawing.Size(90, 17);
            this.CB_EndFrame.TabIndex = 7;
            this.CB_EndFrame.Text = "Is end frame?";
            this.CB_EndFrame.UseVisualStyleBackColor = true;
            // 
            // L_Position
            // 
            this.L_Position.AutoSize = true;
            this.L_Position.Location = new System.Drawing.Point(9, 55);
            this.L_Position.Name = "L_Position";
            this.L_Position.Size = new System.Drawing.Size(72, 13);
            this.L_Position.TabIndex = 6;
            this.L_Position.Text = "Position (x, y):";
            // 
            // DB_Y
            // 
            this.DB_Y.Enabled = false;
            this.DB_Y.Location = new System.Drawing.Point(128, 52);
            this.DB_Y.Name = "DB_Y";
            this.DB_Y.Size = new System.Drawing.Size(40, 20);
            this.DB_Y.TabIndex = 5;
            // 
            // DB_X
            // 
            this.DB_X.Enabled = false;
            this.DB_X.Location = new System.Drawing.Point(82, 52);
            this.DB_X.Name = "DB_X";
            this.DB_X.Size = new System.Drawing.Size(40, 20);
            this.DB_X.TabIndex = 4;
            // 
            // L_CensorbarIdValue
            // 
            this.L_CensorbarIdValue.AutoSize = true;
            this.L_CensorbarIdValue.Location = new System.Drawing.Point(79, 16);
            this.L_CensorbarIdValue.Name = "L_CensorbarIdValue";
            this.L_CensorbarIdValue.Size = new System.Drawing.Size(35, 13);
            this.L_CensorbarIdValue.TabIndex = 3;
            this.L_CensorbarIdValue.Text = "label1";
            // 
            // L_CensorbarId
            // 
            this.L_CensorbarId.AutoSize = true;
            this.L_CensorbarId.Location = new System.Drawing.Point(9, 16);
            this.L_CensorbarId.Name = "L_CensorbarId";
            this.L_CensorbarId.Size = new System.Drawing.Size(19, 13);
            this.L_CensorbarId.TabIndex = 2;
            this.L_CensorbarId.Text = "Id:";
            // 
            // L_TimeStampValue
            // 
            this.L_TimeStampValue.AutoSize = true;
            this.L_TimeStampValue.Location = new System.Drawing.Point(79, 34);
            this.L_TimeStampValue.Name = "L_TimeStampValue";
            this.L_TimeStampValue.Size = new System.Drawing.Size(35, 13);
            this.L_TimeStampValue.TabIndex = 1;
            this.L_TimeStampValue.Text = "label1";
            // 
            // L_TimeStamp
            // 
            this.L_TimeStamp.AutoSize = true;
            this.L_TimeStamp.Location = new System.Drawing.Point(9, 34);
            this.L_TimeStamp.Name = "L_TimeStamp";
            this.L_TimeStamp.Size = new System.Drawing.Size(64, 13);
            this.L_TimeStamp.TabIndex = 0;
            this.L_TimeStamp.Text = "Time stamp:";
            // 
            // PB_KeyframeDrawingWindow
            // 
            this.PB_KeyframeDrawingWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_KeyframeDrawingWindow.Enabled = false;
            this.PB_KeyframeDrawingWindow.Location = new System.Drawing.Point(203, 478);
            this.PB_KeyframeDrawingWindow.Name = "PB_KeyframeDrawingWindow";
            this.PB_KeyframeDrawingWindow.Size = new System.Drawing.Size(810, 154);
            this.PB_KeyframeDrawingWindow.TabIndex = 6;
            this.PB_KeyframeDrawingWindow.TabStop = false;
            this.PB_KeyframeDrawingWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.PB_KeyframeDrawingWindow_Paint);
            this.PB_KeyframeDrawingWindow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PB_KeyframeDrawingWindow_MouseClick);
            // 
            // SB_Keyframes
            // 
            this.SB_Keyframes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SB_Keyframes.Enabled = false;
            this.SB_Keyframes.Location = new System.Drawing.Point(1016, 475);
            this.SB_Keyframes.Name = "SB_Keyframes";
            this.SB_Keyframes.Size = new System.Drawing.Size(20, 160);
            this.SB_Keyframes.TabIndex = 5;
            this.SB_Keyframes.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SB_Keyframes_Scroll);
            // 
            // TB_VideoPosition
            // 
            this.TB_VideoPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_VideoPosition.Enabled = false;
            this.TB_VideoPosition.Location = new System.Drawing.Point(203, 438);
            this.TB_VideoPosition.Maximum = 1200;
            this.TB_VideoPosition.Name = "TB_VideoPosition";
            this.TB_VideoPosition.Size = new System.Drawing.Size(810, 34);
            this.TB_VideoPosition.TabIndex = 1;
            this.TB_VideoPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TB_VideoPosition.Scroll += new System.EventHandler(this.TB_VideoPosition_Scroll);
            // 
            // ColorPicker
            // 
            this.ColorPicker.Color = System.Drawing.Color.Red;
            // 
            // CensorEditorDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 659);
            this.Controls.Add(this.TLP_CensorEditor);
            this.Controls.Add(this.CensorEditorMenu);
            this.MainMenuStrip = this.CensorEditorMenu;
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "CensorEditorDlg";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CensorEditor...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CensorEditorDlg_FormClosing);
            this.LocationChanged += new System.EventHandler(this.CensorEditorDlg_LocationChanged);
            this.Resize += new System.EventHandler(this.CensorEditorDlg_Resize);
            this.CensorEditorMenu.ResumeLayout(false);
            this.CensorEditorMenu.PerformLayout();
            this.TLP_CensorEditor.ResumeLayout(false);
            this.TLP_CensorEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLC_Editor)).EndInit();
            this.FLP_PauseResume.ResumeLayout(false);
            this.GB_Censorbar.ResumeLayout(false);
            this.CB_KeyframeOptions.ResumeLayout(false);
            this.CB_KeyframeOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_KeyframeDrawingWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_VideoPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip CensorEditorMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel TLP_CensorEditor;
        private Vlc.DotNet.Forms.VlcControl VLC_Editor;
        private System.Windows.Forms.TrackBar TB_VideoPosition;
        private System.Windows.Forms.Button B_PauseResume;
        private System.Windows.Forms.FlowLayoutPanel FLP_PauseResume;
        private System.Windows.Forms.GroupBox GB_Censorbar;
        private System.Windows.Forms.ColorDialog ColorPicker;
        private System.Windows.Forms.VScrollBar SB_Keyframes;
        private System.Windows.Forms.PictureBox PB_KeyframeDrawingWindow;
        private System.Windows.Forms.Button B_NewCensorbar;
        private System.Windows.Forms.FlowLayoutPanel FLP_Censorbars;
        private System.Windows.Forms.GroupBox CB_KeyframeOptions;
        private System.Windows.Forms.Label L_CensorbarIdValue;
        private System.Windows.Forms.Label L_CensorbarId;
        private System.Windows.Forms.Label L_TimeStampValue;
        private System.Windows.Forms.Label L_TimeStamp;
        private System.Windows.Forms.Label L_Position;
        private DecimalBox DB_Y;
        private DecimalBox DB_X;
        private System.Windows.Forms.Button B_UpdateFrame;
        private System.Windows.Forms.CheckBox CB_EndFrame;
        private System.Windows.Forms.Button B_Delete;
        private System.Windows.Forms.ComboBox CB_CensorSize;
        private System.Windows.Forms.Label L_SpecialCensorbarSize;
        private System.Windows.Forms.ComboBox CB_GeneralCensorbarSize;
    }
}