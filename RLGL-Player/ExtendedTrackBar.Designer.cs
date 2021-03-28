
namespace RLGL_Player
{
    partial class ExtendedTrackBar
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
            this.components = new System.ComponentModel.Container();
            this.ExtendedTrackBarLayout = new System.Windows.Forms.TableLayoutPanel();
            this.DecimalTextBoxLayout = new System.Windows.Forms.TableLayoutPanel();
            this.NUD_ShowValue = new System.Windows.Forms.NumericUpDown();
            this.TB_ExtendedTrackBar = new System.Windows.Forms.TrackBar();
            this.L_Label = new System.Windows.Forms.Label();
            this.ExtendedTrackBarTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.ExtendedTrackBarLayout.SuspendLayout();
            this.DecimalTextBoxLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ShowValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_ExtendedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ExtendedTrackBarLayout
            // 
            this.ExtendedTrackBarLayout.ColumnCount = 3;
            this.ExtendedTrackBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ExtendedTrackBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExtendedTrackBarLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.ExtendedTrackBarLayout.Controls.Add(this.DecimalTextBoxLayout, 2, 0);
            this.ExtendedTrackBarLayout.Controls.Add(this.TB_ExtendedTrackBar, 1, 0);
            this.ExtendedTrackBarLayout.Controls.Add(this.L_Label, 0, 0);
            this.ExtendedTrackBarLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtendedTrackBarLayout.Location = new System.Drawing.Point(0, 0);
            this.ExtendedTrackBarLayout.Name = "ExtendedTrackBarLayout";
            this.ExtendedTrackBarLayout.RowCount = 1;
            this.ExtendedTrackBarLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExtendedTrackBarLayout.Size = new System.Drawing.Size(345, 54);
            this.ExtendedTrackBarLayout.TabIndex = 100;
            // 
            // DecimalTextBoxLayout
            // 
            this.DecimalTextBoxLayout.ColumnCount = 1;
            this.DecimalTextBoxLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DecimalTextBoxLayout.Controls.Add(this.NUD_ShowValue, 0, 1);
            this.DecimalTextBoxLayout.Location = new System.Drawing.Point(288, 3);
            this.DecimalTextBoxLayout.Name = "DecimalTextBoxLayout";
            this.DecimalTextBoxLayout.RowCount = 3;
            this.DecimalTextBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DecimalTextBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.DecimalTextBoxLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DecimalTextBoxLayout.Size = new System.Drawing.Size(54, 48);
            this.DecimalTextBoxLayout.TabIndex = 1;
            // 
            // NUD_ShowValue
            // 
            this.NUD_ShowValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NUD_ShowValue.Location = new System.Drawing.Point(3, 14);
            this.NUD_ShowValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_ShowValue.Name = "NUD_ShowValue";
            this.NUD_ShowValue.Size = new System.Drawing.Size(48, 20);
            this.NUD_ShowValue.TabIndex = 0;
            this.NUD_ShowValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_ShowValue.ValueChanged += new System.EventHandler(this.NUD_ShowValue_ValueChanged);
            // 
            // TB_ExtendedTrackBar
            // 
            this.TB_ExtendedTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_ExtendedTrackBar.Location = new System.Drawing.Point(83, 3);
            this.TB_ExtendedTrackBar.Name = "TB_ExtendedTrackBar";
            this.TB_ExtendedTrackBar.Size = new System.Drawing.Size(199, 48);
            this.TB_ExtendedTrackBar.TabIndex = 0;
            this.TB_ExtendedTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TB_ExtendedTrackBar.ValueChanged += new System.EventHandler(this.TB_ExtendedTrackBar_ValueChanged);
            // 
            // L_Label
            // 
            this.L_Label.AutoSize = true;
            this.L_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_Label.Location = new System.Drawing.Point(3, 0);
            this.L_Label.Name = "L_Label";
            this.L_Label.Size = new System.Drawing.Size(74, 54);
            this.L_Label.TabIndex = 2;
            this.L_Label.Text = "Extended Trackbar";
            this.L_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExtendedTrackBarTooltip
            // 
            this.ExtendedTrackBarTooltip.AutoPopDelay = 10000;
            this.ExtendedTrackBarTooltip.InitialDelay = 500;
            this.ExtendedTrackBarTooltip.ReshowDelay = 100;
            this.ExtendedTrackBarTooltip.ToolTipTitle = "Help";
            // 
            // ExtendedTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExtendedTrackBarLayout);
            this.Name = "ExtendedTrackBar";
            this.Size = new System.Drawing.Size(345, 54);
            this.ExtendedTrackBarLayout.ResumeLayout(false);
            this.ExtendedTrackBarLayout.PerformLayout();
            this.DecimalTextBoxLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ShowValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_ExtendedTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ExtendedTrackBarLayout;
        private System.Windows.Forms.TrackBar TB_ExtendedTrackBar;
        private System.Windows.Forms.TableLayoutPanel DecimalTextBoxLayout;
        private System.Windows.Forms.NumericUpDown NUD_ShowValue;
        private System.Windows.Forms.Label L_Label;
        private System.Windows.Forms.ToolTip ExtendedTrackBarTooltip;
    }
}
