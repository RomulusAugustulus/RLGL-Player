using System.Windows.Forms;

namespace RLGL_Player
{
    public partial class AboutDlg : Form
    {
        public AboutDlg()
        {
            InitializeComponent();
        }

        //Provide link to vlc.
        private void L_LinktToVLC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            L_LinktToVLC.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/videolan/vlc");
        }
    }
}
