
namespace RLGL_Player
{
    partial class VolumeBar
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
            this.TB_Volume = new System.Windows.Forms.TrackBar();
            this.PB_VolumeImageLoud = new System.Windows.Forms.PictureBox();
            this.PB_VolumeImageOff = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_VolumeImageLoud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_VolumeImageOff)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_Volume
            // 
            this.TB_Volume.BackColor = System.Drawing.SystemColors.Control;
            this.TB_Volume.Location = new System.Drawing.Point(69, 3);
            this.TB_Volume.Maximum = 100;
            this.TB_Volume.Name = "TB_Volume";
            this.TB_Volume.Size = new System.Drawing.Size(144, 45);
            this.TB_Volume.TabIndex = 4;
            this.TB_Volume.TickFrequency = 10;
            this.TB_Volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TB_Volume.Value = 100;
            this.TB_Volume.ValueChanged += new System.EventHandler(this.TB_Volume_ValueChanged);
            this.TB_Volume.MouseEnter += new System.EventHandler(this.TB_Volume_MouseEnter);
            this.TB_Volume.MouseLeave += new System.EventHandler(this.TB_Volume_MouseLeave);
            // 
            // PB_VolumeImageLoud
            // 
            this.PB_VolumeImageLoud.BackColor = System.Drawing.SystemColors.Control;
            this.PB_VolumeImageLoud.Image = global::RLGL_Player.Properties.Resources.loud_157172_1280;
            this.PB_VolumeImageLoud.Location = new System.Drawing.Point(12, 3);
            this.PB_VolumeImageLoud.Name = "PB_VolumeImageLoud";
            this.PB_VolumeImageLoud.Size = new System.Drawing.Size(56, 45);
            this.PB_VolumeImageLoud.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_VolumeImageLoud.TabIndex = 5;
            this.PB_VolumeImageLoud.TabStop = false;
            this.PB_VolumeImageLoud.Click += new System.EventHandler(this.PB_VolumeImageLoud_Click);
            this.PB_VolumeImageLoud.MouseEnter += new System.EventHandler(this.PB_VolumeImageLoud_MouseEnter);
            this.PB_VolumeImageLoud.MouseLeave += new System.EventHandler(this.PB_VolumeImageLoud_MouseLeave);
            // 
            // PB_VolumeImageOff
            // 
            this.PB_VolumeImageOff.BackColor = System.Drawing.SystemColors.Control;
            this.PB_VolumeImageOff.Image = global::RLGL_Player.Properties.Resources.sound_157175_1280;
            this.PB_VolumeImageOff.Location = new System.Drawing.Point(12, 3);
            this.PB_VolumeImageOff.Name = "PB_VolumeImageOff";
            this.PB_VolumeImageOff.Size = new System.Drawing.Size(36, 45);
            this.PB_VolumeImageOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_VolumeImageOff.TabIndex = 6;
            this.PB_VolumeImageOff.TabStop = false;
            this.PB_VolumeImageOff.Click += new System.EventHandler(this.PB_VolumeImageOff_Click);
            this.PB_VolumeImageOff.MouseEnter += new System.EventHandler(this.PB_VolumeImageOff_MouseEnter);
            this.PB_VolumeImageOff.MouseLeave += new System.EventHandler(this.PB_VolumeImageOff_MouseLeave);
            // 
            // VolumeBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 50);
            this.Controls.Add(this.PB_VolumeImageOff);
            this.Controls.Add(this.PB_VolumeImageLoud);
            this.Controls.Add(this.TB_Volume);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VolumeBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MouseEnter += new System.EventHandler(this.VolumeBar_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.VolumeBar_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.TB_Volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_VolumeImageLoud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_VolumeImageOff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar TB_Volume;
        private System.Windows.Forms.PictureBox PB_VolumeImageLoud;
        private System.Windows.Forms.PictureBox PB_VolumeImageOff;
    }
}