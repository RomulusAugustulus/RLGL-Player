/*
 *  RLGL-Player - plays the famous game red light green light to any selected media.
 *  Copyright (C) 2021  Augustulus
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
using System;
using System.Windows.Forms;

namespace RLGL_Player
{
    public partial class EnterNameDlg : Form
    {
        private string name;
        public string Input { get => name; }

        public EnterNameDlg()
        {
            name = "";
            InitializeComponent();
        }

        private void B_OK_Click(object sender, EventArgs e)
        {
            name = TB_EnterName.Text.Trim();

            if(name.Length == 0)
            {
                MessageBox.Show("A name needs to have at least one character!", "Error");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
