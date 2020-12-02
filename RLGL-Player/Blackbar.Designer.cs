namespace RLGL_Player
{
    partial class Blackbar
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
            this.PB_CensorImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_CensorImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_CensorImage
            // 
            this.PB_CensorImage.BackColor = System.Drawing.Color.Transparent;
            this.PB_CensorImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_CensorImage.Location = new System.Drawing.Point(0, 0);
            this.PB_CensorImage.Name = "PB_CensorImage";
            this.PB_CensorImage.Size = new System.Drawing.Size(226, 110);
            this.PB_CensorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_CensorImage.TabIndex = 0;
            this.PB_CensorImage.TabStop = false;
            // 
            // Blackbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(226, 110);
            this.Controls.Add(this.PB_CensorImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Blackbar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Blackbar";
            ((System.ComponentModel.ISupportInitialize)(this.PB_CensorImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox PB_CensorImage;
    }
}