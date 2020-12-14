
namespace RLGL_Player
{
    partial class CensorbarSetting
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TLP_CensorbarSettingsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.RB_CensorbarSettings = new System.Windows.Forms.RadioButton();
            this.P_CensorbarSettingsColor = new System.Windows.Forms.Panel();
            this.TLP_CensorbarSettingsLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP_CensorbarSettingsLayout
            // 
            this.TLP_CensorbarSettingsLayout.ColumnCount = 2;
            this.TLP_CensorbarSettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLP_CensorbarSettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.TLP_CensorbarSettingsLayout.Controls.Add(this.RB_CensorbarSettings, 0, 0);
            this.TLP_CensorbarSettingsLayout.Controls.Add(this.P_CensorbarSettingsColor, 1, 0);
            this.TLP_CensorbarSettingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_CensorbarSettingsLayout.Location = new System.Drawing.Point(0, 0);
            this.TLP_CensorbarSettingsLayout.Name = "TLP_CensorbarSettingsLayout";
            this.TLP_CensorbarSettingsLayout.RowCount = 1;
            this.TLP_CensorbarSettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_CensorbarSettingsLayout.Size = new System.Drawing.Size(150, 24);
            this.TLP_CensorbarSettingsLayout.TabIndex = 0;
            // 
            // RB_CensorbarSettings
            // 
            this.RB_CensorbarSettings.AutoSize = true;
            this.RB_CensorbarSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.RB_CensorbarSettings.Location = new System.Drawing.Point(3, 3);
            this.RB_CensorbarSettings.Name = "RB_CensorbarSettings";
            this.RB_CensorbarSettings.Size = new System.Drawing.Size(31, 17);
            this.RB_CensorbarSettings.TabIndex = 0;
            this.RB_CensorbarSettings.TabStop = true;
            this.RB_CensorbarSettings.Text = "0";
            this.RB_CensorbarSettings.UseVisualStyleBackColor = true;
            this.RB_CensorbarSettings.CheckedChanged += new System.EventHandler(this.RB_CensorbarSettings_CheckedChanged);
            // 
            // P_CensorbarSettingsColor
            // 
            this.P_CensorbarSettingsColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_CensorbarSettingsColor.Location = new System.Drawing.Point(40, 3);
            this.P_CensorbarSettingsColor.Name = "P_CensorbarSettingsColor";
            this.P_CensorbarSettingsColor.Size = new System.Drawing.Size(107, 18);
            this.P_CensorbarSettingsColor.TabIndex = 1;
            this.P_CensorbarSettingsColor.Click += new System.EventHandler(this.P_CensorbarSettingsColor_Click);
            // 
            // CensorbarSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLP_CensorbarSettingsLayout);
            this.Name = "CensorbarSetting";
            this.Size = new System.Drawing.Size(150, 24);
            this.TLP_CensorbarSettingsLayout.ResumeLayout(false);
            this.TLP_CensorbarSettingsLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP_CensorbarSettingsLayout;
        private System.Windows.Forms.RadioButton RB_CensorbarSettings;
        private System.Windows.Forms.Panel P_CensorbarSettingsColor;
    }
}
