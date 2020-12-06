using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RLGL_Player
{
    public partial class CensorEditorDlg : Form
    {
        private RLGLCurrentMedia rlglCurrentMedia;
        private RLGLCensorData rlglCensorData;
        private bool initMedia;
        private bool isPaused;

        public CensorEditorDlg()
        {
            InitializeComponent();
            initMedia = false;
            isPaused = false;
        }

        private void VLC_Editor_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "all files(*.*)|*.*";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rlglCurrentMedia = new RLGLCurrentMedia(openFileDialog.FileName, DateTime.Now, TimeSpan.Zero, RLGLPhase.Green);
                InitEditor();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CensorEditorDlg_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CensorEditorDlg_Resize(object sender, EventArgs e)
        {

        }

        private void CensorEditorDlg_LocationChanged(object sender, EventArgs e)
        {

        }

        private void TB_VideoPosition_Scroll(object sender, EventArgs e)
        {
            VLC_Editor.Position = (float)TB_VideoPosition.Value / (float)TB_VideoPosition.Maximum;
        }

        private void VLC_Editor_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            if (!initMedia)
            {
                this.BeginInvoke(new Action(() => InitTrackBar()));
            }
        }

        private void InitEditor()
        {
            FileStream fs = File.OpenRead(rlglCurrentMedia.Media);
            VLC_Editor.SetMedia(fs);
            VLC_Editor.Audio.Volume = 0;
            VLC_Editor.Play();
        }

        private void InitTrackBar()
        {
            initMedia = true;
            TB_VideoPosition.Enabled = true;
            TB_VideoPosition.Minimum = 0;
            TB_VideoPosition.Maximum = (int)VLC_Editor.GetCurrentMedia().Duration.TotalSeconds;
            TB_VideoPosition.Value = 0;

            VLC_Editor.Position = (float)TB_VideoPosition.Value / (float)TB_VideoPosition.Maximum;
        }

        private void UpdateTrackBarPosition()
        {
            TB_VideoPosition.Value = (int)(VLC_Editor.Position * TB_VideoPosition.Maximum);
        }

        private void VLC_Editor_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateTrackBarPosition())); 
        }

        private void B_PauseResume_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            VLC_Editor.SetPause(isPaused);

            if(isPaused)
            {
                TB_VideoPosition.Enabled = false;
            }
            else
            {
                TB_VideoPosition.Enabled = true;
            }
        }
    }
}
