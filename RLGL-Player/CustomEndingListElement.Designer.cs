
namespace RLGL_Player
{
    partial class CustomEndingListElement
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
            this.ETB_Chance = new RLGL_Player.ExtendedTrackBar();
            this.CustomEndingListElementLayout = new System.Windows.Forms.TableLayoutPanel();
            this.CB_Enabled = new System.Windows.Forms.CheckBox();
            this.CB_LockChance = new System.Windows.Forms.CheckBox();
            this.B_EndingElement = new System.Windows.Forms.Button();
            this.CustomEndingListElementLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ETB_Chance
            // 
            this.ETB_Chance.Location = new System.Drawing.Point(194, 3);
            this.ETB_Chance.Maximum = 100;
            this.ETB_Chance.Minimum = 0;
            this.ETB_Chance.Name = "ETB_Chance";
            this.ETB_Chance.Size = new System.Drawing.Size(235, 47);
            this.ETB_Chance.TabIndex = 0;
            this.ETB_Chance.Text = "Chance (%):";
            this.ETB_Chance.TickFrequency = 10;
            this.ETB_Chance.ToolTip = null;
            this.ETB_Chance.Value = 0;
            this.ETB_Chance.ExtendedTrackBarValueChanged += new RLGL_Player.ExtendedTrackBar.ExtendedTrackBarValueHandler(this.ETB_Chance_ExtendedTrackBarValueChanged);
            // 
            // CustomEndingListElementLayout
            // 
            this.CustomEndingListElementLayout.ColumnCount = 4;
            this.CustomEndingListElementLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CustomEndingListElementLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.20481F));
            this.CustomEndingListElementLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.79518F));
            this.CustomEndingListElementLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.CustomEndingListElementLayout.Controls.Add(this.ETB_Chance, 2, 0);
            this.CustomEndingListElementLayout.Controls.Add(this.CB_Enabled, 0, 0);
            this.CustomEndingListElementLayout.Controls.Add(this.CB_LockChance, 3, 0);
            this.CustomEndingListElementLayout.Controls.Add(this.B_EndingElement, 1, 0);
            this.CustomEndingListElementLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomEndingListElementLayout.Location = new System.Drawing.Point(0, 0);
            this.CustomEndingListElementLayout.Name = "CustomEndingListElementLayout";
            this.CustomEndingListElementLayout.RowCount = 1;
            this.CustomEndingListElementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CustomEndingListElementLayout.Size = new System.Drawing.Size(508, 53);
            this.CustomEndingListElementLayout.TabIndex = 1;
            // 
            // CB_Enabled
            // 
            this.CB_Enabled.AutoSize = true;
            this.CB_Enabled.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_Enabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_Enabled.Location = new System.Drawing.Point(3, 3);
            this.CB_Enabled.Name = "CB_Enabled";
            this.CB_Enabled.Size = new System.Drawing.Size(14, 47);
            this.CB_Enabled.TabIndex = 1;
            this.CB_Enabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_Enabled.UseVisualStyleBackColor = true;
            this.CB_Enabled.CheckedChanged += new System.EventHandler(this.CB_Enabled_CheckedChanged);
            // 
            // CB_LockChance
            // 
            this.CB_LockChance.AutoSize = true;
            this.CB_LockChance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_LockChance.Location = new System.Drawing.Point(439, 3);
            this.CB_LockChance.Name = "CB_LockChance";
            this.CB_LockChance.Size = new System.Drawing.Size(66, 47);
            this.CB_LockChance.TabIndex = 2;
            this.CB_LockChance.Text = "Lock chance";
            this.CB_LockChance.UseVisualStyleBackColor = true;
            this.CB_LockChance.CheckedChanged += new System.EventHandler(this.CB_LockChance_CheckedChanged);
            // 
            // B_EndingElement
            // 
            this.B_EndingElement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_EndingElement.Location = new System.Drawing.Point(23, 3);
            this.B_EndingElement.Name = "B_EndingElement";
            this.B_EndingElement.Size = new System.Drawing.Size(165, 47);
            this.B_EndingElement.TabIndex = 3;
            this.B_EndingElement.Text = "button1";
            this.B_EndingElement.UseVisualStyleBackColor = true;
            this.B_EndingElement.Click += new System.EventHandler(this.B_EndingElement_Click);
            // 
            // CustomEndingListElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CustomEndingListElementLayout);
            this.Name = "CustomEndingListElement";
            this.Size = new System.Drawing.Size(508, 53);
            this.Enter += new System.EventHandler(this.CustomEndingListElement_Enter);
            this.Leave += new System.EventHandler(this.CustomEndingListElement_Leave);
            this.CustomEndingListElementLayout.ResumeLayout(false);
            this.CustomEndingListElementLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedTrackBar ETB_Chance;
        private System.Windows.Forms.TableLayoutPanel CustomEndingListElementLayout;
        private System.Windows.Forms.CheckBox CB_Enabled;
        private System.Windows.Forms.CheckBox CB_LockChance;
        private System.Windows.Forms.Button B_EndingElement;
    }
}
