/*
 *  RLGL-Player - plays the famous game red light green light to any selected media.
 *  Copyright (C) 2020  Augustulus
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

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

        //provide link to gnu.
        private void L_LinkGNU_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            L_LinkGNU.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.gnu.org/licenses/");
        }
    }
}
