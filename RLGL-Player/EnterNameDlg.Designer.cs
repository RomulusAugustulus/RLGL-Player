
namespace RLGL_Player
{
    partial class EnterNameDlg
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
            this.L_EnterName = new System.Windows.Forms.Label();
            this.TB_EnterName = new System.Windows.Forms.TextBox();
            this.B_OK = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // L_EnterName
            // 
            this.L_EnterName.AutoSize = true;
            this.L_EnterName.Location = new System.Drawing.Point(9, 9);
            this.L_EnterName.Name = "L_EnterName";
            this.L_EnterName.Size = new System.Drawing.Size(96, 13);
            this.L_EnterName.TabIndex = 0;
            this.L_EnterName.Text = "Enter a new name:";
            // 
            // TB_EnterName
            // 
            this.TB_EnterName.Location = new System.Drawing.Point(12, 25);
            this.TB_EnterName.Name = "TB_EnterName";
            this.TB_EnterName.Size = new System.Drawing.Size(305, 20);
            this.TB_EnterName.TabIndex = 1;
            // 
            // B_OK
            // 
            this.B_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.B_OK.Location = new System.Drawing.Point(242, 54);
            this.B_OK.Name = "B_OK";
            this.B_OK.Size = new System.Drawing.Size(75, 23);
            this.B_OK.TabIndex = 2;
            this.B_OK.Text = "OK";
            this.B_OK.UseVisualStyleBackColor = true;
            this.B_OK.Click += new System.EventHandler(this.B_OK_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.B_Cancel.Location = new System.Drawing.Point(12, 54);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(75, 23);
            this.B_Cancel.TabIndex = 3;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            // 
            // EnterNameDlg
            // 
            this.AcceptButton = this.B_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.B_Cancel;
            this.ClientSize = new System.Drawing.Size(329, 89);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_OK);
            this.Controls.Add(this.TB_EnterName);
            this.Controls.Add(this.L_EnterName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterNameDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_EnterName;
        private System.Windows.Forms.TextBox TB_EnterName;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.Button B_Cancel;
    }
}