
namespace RLGL_Player
{
    partial class WorkingDlg
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
            this.PB_WorkingProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // PB_WorkingProgress
            // 
            this.PB_WorkingProgress.Location = new System.Drawing.Point(12, 12);
            this.PB_WorkingProgress.MarqueeAnimationSpeed = 30;
            this.PB_WorkingProgress.Name = "PB_WorkingProgress";
            this.PB_WorkingProgress.Size = new System.Drawing.Size(547, 23);
            this.PB_WorkingProgress.TabIndex = 0;
            // 
            // WorkingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 48);
            this.Controls.Add(this.PB_WorkingProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkingDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Working...";
            this.VisibleChanged += new System.EventHandler(this.WorkingDlg_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar PB_WorkingProgress;
    }
}