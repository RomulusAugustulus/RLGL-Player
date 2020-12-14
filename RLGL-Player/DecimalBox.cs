using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLGL_Player
{    
    public class DecimalBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                if (this.Text.Length == 0)
                {
                    this.Text = "0.";
                    this.SelectionStart = 2;
                    e.Handled = true;
                }
                else if (this.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }

            base.OnKeyPress(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            double value = double.Parse(this.Text.Trim());
            if (value > 1.0)
            {
                this.Text = "1.0";
            }
            else if (value < 0.0)
            {
                this.Text = "0.0";
            }

            base.OnLostFocus(e);
        }
    }
}
