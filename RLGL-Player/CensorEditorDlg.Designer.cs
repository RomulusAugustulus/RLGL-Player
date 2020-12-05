
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
            this.P_CensorEditor = new System.Windows.Forms.TableLayoutPanel();
            this.VLC_Editor = new Vlc.DotNet.Forms.VlcControl();
            this.TB_VideoPosition = new System.Windows.Forms.TrackBar();
            this.OpenFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.B_PauseResume = new System.Windows.Forms.Button();
            this.CensorEditorMenu.SuspendLayout();
            this.P_CensorEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLC_Editor)).BeginInit();
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
            // P_CensorEditor
            // 
            this.P_CensorEditor.ColumnCount = 2;
            this.P_CensorEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.59459F));
            this.P_CensorEditor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.4054F));
            this.P_CensorEditor.Controls.Add(this.VLC_Editor, 1, 0);
            this.P_CensorEditor.Controls.Add(this.TB_VideoPosition, 1, 1);
            this.P_CensorEditor.Controls.Add(this.B_PauseResume, 1, 2);
            this.P_CensorEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_CensorEditor.Location = new System.Drawing.Point(0, 24);
            this.P_CensorEditor.Name = "P_CensorEditor";
            this.P_CensorEditor.RowCount = 3;
            this.P_CensorEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.13082F));
            this.P_CensorEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.86918F));
            this.P_CensorEditor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.P_CensorEditor.Size = new System.Drawing.Size(1036, 554);
            this.P_CensorEditor.TabIndex = 1;
            // 
            // VLC_Editor
            // 
            this.VLC_Editor.BackColor = System.Drawing.Color.Black;
            this.VLC_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VLC_Editor.Location = new System.Drawing.Point(205, 3);
            this.VLC_Editor.Name = "VLC_Editor";
            this.VLC_Editor.Size = new System.Drawing.Size(828, 385);
            this.VLC_Editor.Spu = -1;
            this.VLC_Editor.TabIndex = 0;
            this.VLC_Editor.Text = "vlcControl1";
            this.VLC_Editor.VlcLibDirectory = null;
            this.VLC_Editor.VlcMediaplayerOptions = null;
            this.VLC_Editor.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.VLC_Editor_VlcLibDirectoryNeeded);
            this.VLC_Editor.Playing += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs>(this.VLC_Editor_Playing);
            this.VLC_Editor.PositionChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs>(this.VLC_Editor_PositionChanged);
            // 
            // TB_VideoPosition
            // 
            this.TB_VideoPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_VideoPosition.Enabled = false;
            this.TB_VideoPosition.Location = new System.Drawing.Point(205, 394);
            this.TB_VideoPosition.Maximum = 1200;
            this.TB_VideoPosition.Name = "TB_VideoPosition";
            this.TB_VideoPosition.Size = new System.Drawing.Size(828, 32);
            this.TB_VideoPosition.TabIndex = 1;
            this.TB_VideoPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TB_VideoPosition.Scroll += new System.EventHandler(this.TB_VideoPosition_Scroll);
            // 
            // OpenFileDlg
            // 
            this.OpenFileDlg.Filter = "censor-information-file(*.cif)|*.cif";
            this.OpenFileDlg.Title = "Select a file...";
            // 
            // SaveFileDlg
            // 
            this.SaveFileDlg.Filter = "censor-information-file(*.cif)|*.cif";
            this.SaveFileDlg.Title = "Save...";
            // 
            // B_PauseResume
            // 
            this.B_PauseResume.Location = new System.Drawing.Point(205, 432);
            this.B_PauseResume.Name = "B_PauseResume";
            this.B_PauseResume.Size = new System.Drawing.Size(91, 27);
            this.B_PauseResume.TabIndex = 2;
            this.B_PauseResume.Text = "Pause/Resume";
            this.B_PauseResume.UseVisualStyleBackColor = true;
            this.B_PauseResume.Click += new System.EventHandler(this.B_PauseResume_Click);
            // 
            // CensorEditorDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 578);
            this.Controls.Add(this.P_CensorEditor);
            this.Controls.Add(this.CensorEditorMenu);
            this.MainMenuStrip = this.CensorEditorMenu;
            this.Name = "CensorEditorDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CensorEditor...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CensorEditorDlg_FormClosing);
            this.LocationChanged += new System.EventHandler(this.CensorEditorDlg_LocationChanged);
            this.Resize += new System.EventHandler(this.CensorEditorDlg_Resize);
            this.CensorEditorMenu.ResumeLayout(false);
            this.CensorEditorMenu.PerformLayout();
            this.P_CensorEditor.ResumeLayout(false);
            this.P_CensorEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLC_Editor)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel P_CensorEditor;
        private Vlc.DotNet.Forms.VlcControl VLC_Editor;
        private System.Windows.Forms.TrackBar TB_VideoPosition;
        private System.Windows.Forms.OpenFileDialog OpenFileDlg;
        private System.Windows.Forms.SaveFileDialog SaveFileDlg;
        private System.Windows.Forms.Button B_PauseResume;
    }
}