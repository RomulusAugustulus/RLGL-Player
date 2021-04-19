using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLGL_Player
{
    public partial class WorkingDlg : Form
    {
        public WorkingDlg()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        public void InitProgressbar()
        {
            PB_WorkingProgress.Value = 0;
        }

        public void SetProgress(int value)
        {
            PB_WorkingProgress.Value = value;
        }

        private void WorkingDlg_VisibleChanged(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        public void SetMarquee(bool marquee)
        {
            if(marquee)
            {
                PB_WorkingProgress.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                PB_WorkingProgress.Style = ProgressBarStyle.Blocks;
            }
        }
    }
}
