namespace RLGL_Player
{
    partial class AboutDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDlg));
            this.PB_Icon = new System.Windows.Forms.PictureBox();
            this.L_AboutInfo = new System.Windows.Forms.Label();
            this.L_Copyright = new System.Windows.Forms.Label();
            this.L_Idea = new System.Windows.Forms.Label();
            this.L_Videoplayer = new System.Windows.Forms.Label();
            this.L_LinktToVLC = new System.Windows.Forms.LinkLabel();
            this.B_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Icon
            // 
            this.PB_Icon.Image = ((System.Drawing.Image)(resources.GetObject("PB_Icon.Image")));
            this.PB_Icon.Location = new System.Drawing.Point(12, 22);
            this.PB_Icon.Name = "PB_Icon";
            this.PB_Icon.Size = new System.Drawing.Size(76, 78);
            this.PB_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Icon.TabIndex = 0;
            this.PB_Icon.TabStop = false;
            // 
            // L_AboutInfo
            // 
            this.L_AboutInfo.AutoSize = true;
            this.L_AboutInfo.Location = new System.Drawing.Point(135, 42);
            this.L_AboutInfo.Name = "L_AboutInfo";
            this.L_AboutInfo.Size = new System.Drawing.Size(115, 13);
            this.L_AboutInfo.TabIndex = 1;
            this.L_AboutInfo.Text = "RLGL-Player    v. 0.3.1";
            // 
            // L_Copyright
            // 
            this.L_Copyright.AutoSize = true;
            this.L_Copyright.Location = new System.Drawing.Point(121, 62);
            this.L_Copyright.Name = "L_Copyright";
            this.L_Copyright.Size = new System.Drawing.Size(149, 13);
            this.L_Copyright.TabIndex = 2;
            this.L_Copyright.Text = "Copyright (C) 2020 Augustulus";
            // 
            // L_Idea
            // 
            this.L_Idea.AutoSize = true;
            this.L_Idea.Location = new System.Drawing.Point(141, 93);
            this.L_Idea.Name = "L_Idea";
            this.L_Idea.Size = new System.Drawing.Size(104, 13);
            this.L_Idea.TabIndex = 3;
            this.L_Idea.Text = "Idea by Haggard316";
            // 
            // L_Videoplayer
            // 
            this.L_Videoplayer.AutoSize = true;
            this.L_Videoplayer.Location = new System.Drawing.Point(9, 312);
            this.L_Videoplayer.Name = "L_Videoplayer";
            this.L_Videoplayer.Size = new System.Drawing.Size(250, 13);
            this.L_Videoplayer.TabIndex = 4;
            this.L_Videoplayer.Text = "This application uses VLC-Media-Player as a plugin:";
            // 
            // L_LinktToVLC
            // 
            this.L_LinktToVLC.AutoSize = true;
            this.L_LinktToVLC.Location = new System.Drawing.Point(12, 332);
            this.L_LinktToVLC.Name = "L_LinktToVLC";
            this.L_LinktToVLC.Size = new System.Drawing.Size(159, 13);
            this.L_LinktToVLC.TabIndex = 5;
            this.L_LinktToVLC.TabStop = true;
            this.L_LinktToVLC.Text = "https://github.com/videolan/vlc";
            this.L_LinktToVLC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.L_LinktToVLC_LinkClicked);
            // 
            // B_OK
            // 
            this.B_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_OK.Location = new System.Drawing.Point(160, 360);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(75, 23);
            this.B_OK.TabIndex = 6;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 156);
            this.label1.TabIndex = 7;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // AboutDlg
            // 
            this.AcceptButton = this.B_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.L_LinktToVLC);
            this.Controls.Add(this.L_Videoplayer);
            this.Controls.Add(this.L_Idea);
            this.Controls.Add(this.L_Copyright);
            this.Controls.Add(this.L_AboutInfo);
            this.Controls.Add(this.PB_Icon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About...";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Icon;
        private System.Windows.Forms.Label L_AboutInfo;
        private System.Windows.Forms.Label L_Copyright;
        private System.Windows.Forms.Label L_Idea;
        private System.Windows.Forms.Label L_Videoplayer;
        private System.Windows.Forms.LinkLabel L_LinktToVLC;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.Label label1;
    }
}