﻿
namespace RLGL_Player
{
    partial class RLGLPlayingQueueDlg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RLGLPlayingQueueDlg));
            this.LB_Queue = new System.Windows.Forms.ListBox();
            this.L_Queue = new System.Windows.Forms.Label();
            this.B_Load = new System.Windows.Forms.Button();
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Down = new System.Windows.Forms.Button();
            this.B_Up = new System.Windows.Forms.Button();
            this.OpenVideoDlg = new System.Windows.Forms.OpenFileDialog();
            this.B_Delete = new System.Windows.Forms.Button();
            this.L_FullPath = new System.Windows.Forms.Label();
            this.CB_Shuffle = new System.Windows.Forms.CheckBox();
            this.NUD_Loop = new System.Windows.Forms.NumericUpDown();
            this.L_Loop = new System.Windows.Forms.Label();
            this.PlayingQueueTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.B_LoadPlaylist = new System.Windows.Forms.Button();
            this.B_SavePlaylist = new System.Windows.Forms.Button();
            this.SaveQueueDlg = new System.Windows.Forms.SaveFileDialog();
            this.OpenQueueDlg = new System.Windows.Forms.OpenFileDialog();
            this.BG_CreatePlaylist = new System.ComponentModel.BackgroundWorker();
            this.PB_Preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Loop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_Queue
            // 
            this.LB_Queue.FormattingEnabled = true;
            this.LB_Queue.HorizontalScrollbar = true;
            this.LB_Queue.Location = new System.Drawing.Point(15, 25);
            this.LB_Queue.Name = "LB_Queue";
            this.LB_Queue.Size = new System.Drawing.Size(351, 264);
            this.LB_Queue.TabIndex = 0;
            this.LB_Queue.SelectedIndexChanged += new System.EventHandler(this.LB_Queue_SelectedIndexChanged);
            this.LB_Queue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LB_Queue_KeyDown);
            // 
            // L_Queue
            // 
            this.L_Queue.AutoSize = true;
            this.L_Queue.Location = new System.Drawing.Point(12, 9);
            this.L_Queue.Name = "L_Queue";
            this.L_Queue.Size = new System.Drawing.Size(79, 13);
            this.L_Queue.TabIndex = 1;
            this.L_Queue.Text = "Queued media:";
            // 
            // B_Load
            // 
            this.B_Load.Location = new System.Drawing.Point(386, 179);
            this.B_Load.Name = "B_Load";
            this.B_Load.Size = new System.Drawing.Size(125, 23);
            this.B_Load.TabIndex = 2;
            this.B_Load.Text = "Add...";
            this.B_Load.UseVisualStyleBackColor = true;
            this.B_Load.Click += new System.EventHandler(this.B_Load_Click);
            // 
            // B_OK
            // 
            this.B_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_OK.Location = new System.Drawing.Point(436, 415);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(75, 23);
            this.B_OK.TabIndex = 3;
            this.B_OK.Text = "Start";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_Cancel.Location = new System.Drawing.Point(12, 415);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 4;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            // 
            // B_Down
            // 
            this.B_Down.Location = new System.Drawing.Point(386, 237);
            this.B_Down.Name = "B_Down";
            this.B_Down.Size = new System.Drawing.Size(125, 23);
            this.B_Down.TabIndex = 5;
            this.B_Down.Text = "Down";
            this.B_Down.UseVisualStyleBackColor = true;
            this.B_Down.Click += new System.EventHandler(this.B_Down_Click);
            // 
            // B_Up
            // 
            this.B_Up.Location = new System.Drawing.Point(386, 208);
            this.B_Up.Name = "B_Up";
            this.B_Up.Size = new System.Drawing.Size(125, 23);
            this.B_Up.TabIndex = 6;
            this.B_Up.Text = "Up";
            this.B_Up.UseVisualStyleBackColor = true;
            this.B_Up.Click += new System.EventHandler(this.B_Up_Click);
            // 
            // OpenVideoDlg
            // 
            this.OpenVideoDlg.Filter = resources.GetString("OpenVideoDlg.Filter");
            this.OpenVideoDlg.Multiselect = true;
            this.OpenVideoDlg.Title = "Load...";
            // 
            // B_Delete
            // 
            this.B_Delete.Location = new System.Drawing.Point(386, 266);
            this.B_Delete.Name = "B_Delete";
            this.B_Delete.Size = new System.Drawing.Size(125, 23);
            this.B_Delete.TabIndex = 7;
            this.B_Delete.Text = "Remove";
            this.B_Delete.UseVisualStyleBackColor = true;
            this.B_Delete.Click += new System.EventHandler(this.B_Delete_Click);
            // 
            // L_FullPath
            // 
            this.L_FullPath.AutoEllipsis = true;
            this.L_FullPath.Location = new System.Drawing.Point(12, 292);
            this.L_FullPath.Name = "L_FullPath";
            this.L_FullPath.Size = new System.Drawing.Size(499, 21);
            this.L_FullPath.TabIndex = 8;
            this.L_FullPath.Text = "label1";
            this.L_FullPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.L_FullPath.UseMnemonic = false;
            // 
            // CB_Shuffle
            // 
            this.CB_Shuffle.AutoSize = true;
            this.CB_Shuffle.Location = new System.Drawing.Point(393, 389);
            this.CB_Shuffle.Name = "CB_Shuffle";
            this.CB_Shuffle.Size = new System.Drawing.Size(93, 17);
            this.CB_Shuffle.TabIndex = 9;
            this.CB_Shuffle.Text = "Shuffle playlist";
            this.CB_Shuffle.UseVisualStyleBackColor = true;
            // 
            // NUD_Loop
            // 
            this.NUD_Loop.Location = new System.Drawing.Point(464, 363);
            this.NUD_Loop.Name = "NUD_Loop";
            this.NUD_Loop.Size = new System.Drawing.Size(47, 20);
            this.NUD_Loop.TabIndex = 10;
            this.NUD_Loop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PlayingQueueTooltip.SetToolTip(this.NUD_Loop, "Set a number other than 0 to loop the whole playlist that many times. In combinat" +
        "ion with shuffle the playlist will only be shuffled 1 time!");
            // 
            // L_Loop
            // 
            this.L_Loop.AutoSize = true;
            this.L_Loop.Location = new System.Drawing.Point(390, 365);
            this.L_Loop.Name = "L_Loop";
            this.L_Loop.Size = new System.Drawing.Size(68, 13);
            this.L_Loop.TabIndex = 11;
            this.L_Loop.Text = "Loop playlist:";
            // 
            // PlayingQueueTooltip
            // 
            this.PlayingQueueTooltip.AutoPopDelay = 10000;
            this.PlayingQueueTooltip.InitialDelay = 500;
            this.PlayingQueueTooltip.ReshowDelay = 100;
            this.PlayingQueueTooltip.ToolTipTitle = "Help";
            // 
            // B_LoadPlaylist
            // 
            this.B_LoadPlaylist.Location = new System.Drawing.Point(142, 316);
            this.B_LoadPlaylist.Name = "B_LoadPlaylist";
            this.B_LoadPlaylist.Size = new System.Drawing.Size(116, 33);
            this.B_LoadPlaylist.TabIndex = 13;
            this.B_LoadPlaylist.Text = "Load playlist...";
            this.B_LoadPlaylist.UseVisualStyleBackColor = true;
            this.B_LoadPlaylist.Click += new System.EventHandler(this.B_LoadPlaylist_Click);
            // 
            // B_SavePlaylist
            // 
            this.B_SavePlaylist.Enabled = false;
            this.B_SavePlaylist.Location = new System.Drawing.Point(264, 316);
            this.B_SavePlaylist.Name = "B_SavePlaylist";
            this.B_SavePlaylist.Size = new System.Drawing.Size(116, 33);
            this.B_SavePlaylist.TabIndex = 14;
            this.B_SavePlaylist.Text = "Save playlist...";
            this.B_SavePlaylist.UseVisualStyleBackColor = true;
            this.B_SavePlaylist.Click += new System.EventHandler(this.B_SavePlaylist_Click);
            // 
            // SaveQueueDlg
            // 
            this.SaveQueueDlg.DefaultExt = "rgp";
            this.SaveQueueDlg.Filter = "RLGL-Playlist (*.rgp)|*.rgp";
            this.SaveQueueDlg.Title = "Save Playlist...";
            // 
            // OpenQueueDlg
            // 
            this.OpenQueueDlg.Filter = "RLGL-Playlist (*.rgp)|*.rgp";
            this.OpenQueueDlg.Title = "Load Playlist...";
            // 
            // BG_CreatePlaylist
            // 
            this.BG_CreatePlaylist.WorkerReportsProgress = true;
            this.BG_CreatePlaylist.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BG_CreatePlaylist_DoWork);
            this.BG_CreatePlaylist.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BG_CreatePlaylist_ProgressChanged);
            this.BG_CreatePlaylist.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BG_CreatePlaylist_RunWorkerCompleted);
            // 
            // PB_Preview
            // 
            this.PB_Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Preview.Location = new System.Drawing.Point(372, 25);
            this.PB_Preview.Name = "PB_Preview";
            this.PB_Preview.Size = new System.Drawing.Size(139, 148);
            this.PB_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Preview.TabIndex = 15;
            this.PB_Preview.TabStop = false;
            // 
            // RLGLPlayingQueueDlg
            // 
            this.AcceptButton = this.B_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.B_Cancel;
            this.ClientSize = new System.Drawing.Size(523, 450);
            this.Controls.Add(this.PB_Preview);
            this.Controls.Add(this.B_SavePlaylist);
            this.Controls.Add(this.B_LoadPlaylist);
            this.Controls.Add(this.L_Loop);
            this.Controls.Add(this.NUD_Loop);
            this.Controls.Add(this.CB_Shuffle);
            this.Controls.Add(this.L_FullPath);
            this.Controls.Add(this.B_Delete);
            this.Controls.Add(this.B_Up);
            this.Controls.Add(this.B_Down);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.B_Load);
            this.Controls.Add(this.L_Queue);
            this.Controls.Add(this.LB_Queue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RLGLPlayingQueueDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Load...";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Loop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Queue;
        private System.Windows.Forms.Label L_Queue;
        private System.Windows.Forms.Button B_Load;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Down;
        private System.Windows.Forms.Button B_Up;
        private System.Windows.Forms.OpenFileDialog OpenVideoDlg;
        private System.Windows.Forms.Button B_Delete;
        private System.Windows.Forms.Label L_FullPath;
        private System.Windows.Forms.CheckBox CB_Shuffle;
        private System.Windows.Forms.NumericUpDown NUD_Loop;
        private System.Windows.Forms.ToolTip PlayingQueueTooltip;
        private System.Windows.Forms.Label L_Loop;
        private System.Windows.Forms.Button B_LoadPlaylist;
        private System.Windows.Forms.Button B_SavePlaylist;
        private System.Windows.Forms.SaveFileDialog SaveQueueDlg;
        private System.Windows.Forms.OpenFileDialog OpenQueueDlg;
        private System.ComponentModel.BackgroundWorker BG_CreatePlaylist;
        private System.Windows.Forms.PictureBox PB_Preview;
    }
}