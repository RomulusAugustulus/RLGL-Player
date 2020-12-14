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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace RLGL_Player
{
    /*
     * A more complex dialog that has functionality to edit custom censordata
     * for a given video.
     */ 
    public partial class CensorEditorDlg : Form
    {
        private RLGLCurrentMedia rlglCurrentMedia;
        private RLGLCensorData rlglCensorData;
        private bool isPaused;
        private PaintingOverlay paintingOverlay;
        private int selectedCensorbar;
        private int keyframeViewerOffset;
        private List<CensorbarSetting> CS_Censorbar;
        private RLGLCensorFrame selectedKeyframe;
        private bool dirty;
        private int selectedCensorbarSize;

        public CensorEditorDlg()
        {
            InitializeComponent();

            CS_Censorbar = new List<CensorbarSetting>();

            isPaused = false;
            paintingOverlay = new PaintingOverlay();
            paintingOverlay.PositionUpdated += new PaintingOverlay.PositionUpdateHandler(PaintingOverlay_PositionUpdated);
            selectedCensorbar = -1;
            selectedCensorbarSize = 0;
            keyframeViewerOffset = 0;
            selectedKeyframe = null;
            L_CensorbarIdValue.Text = "";
            L_TimeStampValue.Text = "";
            dirty = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                PauseUnpause();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Set the vlclib directory for the video-control
        private void VLC_Editor_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        //Loads a new video that can be edited.
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dirty)
            {
                if (MessageBox.Show("Unsaved changes detected. Do you want to save them now?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveCensorData();
                }
            }

            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "All Files (*.*)|*.*";
            openFileDlg.FileName = "";
            openFileDlg.Title = "Select a file...";

            if(openFileDlg.ShowDialog() == DialogResult.OK)
            {
                rlglCensorData = null;
                VLC_Editor.Stop();
                rlglCurrentMedia = new RLGLCurrentMedia(openFileDlg.FileName, DateTime.Now, TimeSpan.Zero, RLGLPhase.Green);
                InitEditor();
                PB_KeyframeDrawingWindow.Invalidate();
            }
        }

        /*
         * Loads an existing video and the corresponding censordata, that can be then edited.
         * In case there is no censordata it's the same as a new loaded video.
         */ 
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dirty)
            {
                if (MessageBox.Show("Unsaved changes detected. Do you want to save them now?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveCensorData();
                }
            }

            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Filter = "All Files (*.*)|*.*";
            openFileDlg.FileName = "";
            openFileDlg.Title = "Select a file...";

            if(openFileDlg.ShowDialog() == DialogResult.OK)
            {
                rlglCensorData = RLGLCensorData.ReadFromFile(openFileDlg.FileName);
                rlglCurrentMedia = new RLGLCurrentMedia(openFileDlg.FileName, DateTime.Now, TimeSpan.Zero, RLGLPhase.Green);

                VLC_Editor.Stop();

                InitEditor();
                PB_KeyframeDrawingWindow.Invalidate();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCensorData();            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Ask for saving before the dialog is closed in case there are unsaved changes
        private void CensorEditorDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dirty)
            {
                if (MessageBox.Show("Unsaved changes detected. Do you want to save them now?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveCensorData();
                }
            }
        }

        private void CensorEditorDlg_Resize(object sender, EventArgs e)
        {
            RelocatePaintingOverlay();
            PB_KeyframeDrawingWindow.Invalidate();
        }

        private void CensorEditorDlg_LocationChanged(object sender, EventArgs e)
        {
            RelocatePaintingOverlay();
            PB_KeyframeDrawingWindow.Invalidate();
        }

        private void TB_VideoPosition_Scroll(object sender, EventArgs e)
        {
            VLC_Editor.Position = (float)TB_VideoPosition.Value / (float)TB_VideoPosition.Maximum;
        }

        //Set up all the relevant controls and datastructures in the editor.
        private void InitEditor()
        {
            FileStream fs = File.OpenRead(rlglCurrentMedia.Media);
            VLC_Editor.SetMedia(fs);            
            VLC_Editor.Cursor = Cursors.Cross;

            FLP_Censorbars.Controls.Clear();
            CS_Censorbar.Clear();

            if (!paintingOverlay.Visible)
            {
                paintingOverlay.Show(this);
            }

            VLC_Editor.GetCurrentMedia().ParsedChanged += new EventHandler<Vlc.DotNet.Core.VlcMediaParsedChangedEventArgs>(this.MediaParsedChanged);
            VLC_Editor.GetCurrentMedia().ParseAsync();

            RelocatePaintingOverlay();
            selectedCensorbar = 0;
            selectedCensorbarSize = 0;
            paintingOverlay.SetCurrentId(selectedCensorbar);            

            PB_KeyframeDrawingWindow.Enabled = true;

            CB_GeneralCensorbarSize.Enabled = true;
            CB_GeneralCensorbarSize.SelectedIndex = selectedCensorbarSize;
            B_PauseResume.Enabled = true;
            B_NewCensorbar.Enabled = true;
            B_Delete.Enabled = true;
            VLC_Editor.Play();
        }

        //Setup the trackbar and all structures that depend on the meta-data of the video
        private void InitTrackBar()
        {
            Dictionary<int, Color> editorCensorbarColors;

            if (rlglCensorData == null)
            {
                rlglCensorData = new RLGLCensorData(rlglCurrentMedia.Media);
                AddNewCensorbar();
                CS_Censorbar[0].Checked = true;                
            }
            else
            {
                editorCensorbarColors = rlglCensorData.EditorCensorbarColor;

                foreach (int id in editorCensorbarColors.Keys)
                {
                    CensorbarSetting cs = new CensorbarSetting();
                    cs.Parent = FLP_Censorbars;
                    cs.Size = new Size(FLP_Censorbars.Size.Width - 10, 24);
                    cs.Id = id;
                    cs.Text = CS_Censorbar.Count.ToString();
                    cs.SelectedColor = editorCensorbarColors[id];
                    cs.CheckedChanged += new CensorbarSetting.CheckedChangedHandler(this.CS_CensorbarSelected);
                    cs.ColorChangeClick += new CensorbarSetting.ColorChangeClickHandler(this.CS_ColorChangeClicked);
                    CS_Censorbar.Add(cs);
                }

                CS_Censorbar[0].Checked = true;

                if (CS_Censorbar.Count * 20 + 20 > PB_KeyframeDrawingWindow.Height)
                {
                    SB_Keyframes.Enabled = true;
                    SB_Keyframes.Minimum = 0;
                    SB_Keyframes.Maximum = CS_Censorbar.Count * 20 + 20 - PB_KeyframeDrawingWindow.Height;
                }
            }

            TB_VideoPosition.Enabled = true;
            TB_VideoPosition.Minimum = 0;
            TB_VideoPosition.Maximum = (int)rlglCensorData.Duration.TotalSeconds;
            TB_VideoPosition.Value = 0;

            VLC_Editor.Position = (float)TB_VideoPosition.Value / (float)TB_VideoPosition.Maximum;

            editorCensorbarColors = rlglCensorData.EditorCensorbarColor;

            paintingOverlay.SetCensorbarColorScheme(editorCensorbarColors);
        }

        //Set the duration of the loaded media and update the trackbar
        private void SetMediaDuration()
        {
            rlglCensorData.SetDuration(VLC_Editor.GetCurrentMedia().Duration);
            TB_VideoPosition.Minimum = 0;
            TB_VideoPosition.Maximum = (int)rlglCensorData.Duration.TotalSeconds;
            TB_VideoPosition.Value = 0;

            VLC_Editor.Position = (float)TB_VideoPosition.Value / (float)TB_VideoPosition.Maximum;
        }

        private void MediaParsedChanged(object sender, Vlc.DotNet.Core.VlcMediaParsedChangedEventArgs e)
        {
            InitTrackBar();
            VLC_Editor.GetCurrentMedia().ParsedChanged -= MediaParsedChanged;
        }

        /*
         * Sets the position of the trackbar new and also disables audio-output of the player, 
         * since the video needs to be playing ot modify the value
         */
        private void UpdateTrackBarPosition()
        {
            TB_VideoPosition.Value = (int)(VLC_Editor.Position * TB_VideoPosition.Maximum);

            if (rlglCensorData != null)
            {
                paintingOverlay.UpdatePositions(rlglCensorData.GetAllCensorPositions(TB_VideoPosition.Value));
            }

            if(VLC_Editor.Audio.Volume != 0)
            {
                VLC_Editor.Audio.Volume = 0;
            }
        }

        private void RelocatePaintingOverlay()
        {
            Point pos = VLC_Editor.PointToScreen(Point.Empty);
            paintingOverlay.SetBounds(pos.X, pos.Y, VLC_Editor.Width, VLC_Editor.Height);
        }

        private void VLC_Editor_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateTrackBarPosition())); 
        }

        private void B_PauseResume_Click(object sender, EventArgs e)
        {
            PauseUnpause();
        }

        private void PauseUnpause()
        {
            Pause(!isPaused);
        }

        private void Pause(bool pause)
        {
            isPaused = pause;
            VLC_Editor.SetPause(isPaused);

            if (isPaused)
            {
                TB_VideoPosition.Enabled = false;
                B_PauseResume.Text = "Resume";
            }
            else
            {
                TB_VideoPosition.Enabled = true;
                B_PauseResume.Text = "Pause";
            }
        }

        private void PaintingOverlay_PositionUpdated(object sender, PositionUpdateEventArgs e)
        {
            PointF pos = e.GetPosition();
            rlglCensorData.AddKeyframe(e.GetID(), TB_VideoPosition.Value, pos.X, pos.Y, (short)selectedCensorbarSize);
            PB_KeyframeDrawingWindow.Invalidate();
            
            paintingOverlay.UpdatePositions(rlglCensorData.GetAllCensorPositions(TB_VideoPosition.Value));
            dirty = true;
        }

        private void SetColorOfControl(CensorbarSetting cs, int pos)
        {
            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                cs.SelectedColor = ColorPicker.Color;
                rlglCensorData.EditorCensorbarColor[pos] = cs.SelectedColor;
                paintingOverlay.SetCensorbarColorScheme(rlglCensorData.EditorCensorbarColor);
                dirty = true;
            }
        }

        /*
         * Draw the contents of the keyframe-visualization-control.
         */
        private void PB_KeyframeDrawingWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(PB_KeyframeDrawingWindow.BackColor);

            if (rlglCensorData != null)
            {
                List<int> ids = rlglCensorData.Ids;
                Dictionary<int, List<RLGLCensorFrame>> frames = rlglCensorData.Keyframes;
                Font sansSerif = new Font("Microsoft Sans Serif", 8.25f);
                int length = PB_KeyframeDrawingWindow.Width - 16;
                float duration = (int)rlglCensorData.Duration.TotalSeconds;

                for (int i = 0; i < ids.Count; i++)
                {
                    g.DrawString(ids[i].ToString(), sansSerif, Brushes.Black, 0.0f, ids[i] * 20 + 4 - keyframeViewerOffset);
                    g.DrawLine(Pens.Black, new Point(8, ids[i] * 20 + 10 - keyframeViewerOffset), new Point(length + 8, ids[i] * 20 + 10 - keyframeViewerOffset));

                    SolidBrush b = new SolidBrush(rlglCensorData.EditorCensorbarColor[ids[i]]);

                    for(int n=0;n<frames[ids[i]].Count;n++)
                    {
                        RLGLCensorFrame f = frames[ids[i]][n];
                        Point start = new Point((int)(8 + ((float)f.TimePos / duration) * length), 0);
                        Point end = new Point(start.X, PB_KeyframeDrawingWindow.Height);

                        if (ids[i] == selectedCensorbar)
                        {
                            if (f.Equals(selectedKeyframe))
                            {
                                g.DrawLine(Pens.Red, start, end);
                            }
                            else
                            {
                                g.DrawLine(Pens.Black, start, end);
                            }
                        }

                        if (!f.EndFrame)
                        {
                            RLGLCensorFrame fNext = frames[ids[i]][n+1];
                            g.FillRectangle(b, new Rectangle( start.X, ids[i] * 20 + 7 - keyframeViewerOffset, (int)(((float)(fNext.TimePos - f.TimePos) / duration) * length), 6));
                        }
                    }

                    b.Dispose();
                }
            }
        }

        private void SB_Keyframes_Scroll(object sender, ScrollEventArgs e)
        {
            keyframeViewerOffset = SB_Keyframes.Value;
            PB_KeyframeDrawingWindow.Refresh();
        }

        /*
         * Show details of a keyframe by clicking on the keyframe-visualization-control
         */ 
        private void PB_KeyframeDrawingWindow_MouseClick(object sender, MouseEventArgs e)
        {
            int length = PB_KeyframeDrawingWindow.Width - 16;
            int timePos = (int)(((e.X - 8.0f) / (float)length) * rlglCensorData.Duration.TotalSeconds);

            selectedKeyframe = rlglCensorData.GetNextBiggerKeyframe(selectedCensorbar, timePos);

            if (selectedKeyframe != null)
            {
                VLC_Editor.Position = (float)((double)selectedKeyframe.TimePos / rlglCensorData.Duration.TotalSeconds);
                UpdateTrackBarPosition();
                Pause(true);
                PB_KeyframeDrawingWindow.Invalidate();

                UpdateKeyframeOptions();
            }
        }

        private void B_NewCensorbar_Click(object sender, EventArgs e)
        {
            AddNewCensorbar();
        }

        /*
         * Create a new censorbar and register it in the dataset. Also activate the scrollbar for the keyframe-visualization-control
         * if there are more censorbars than space in the control.
         */ 
        private void AddNewCensorbar()
        {
            CensorbarSetting cs = new CensorbarSetting();
            cs.Parent = FLP_Censorbars;
            cs.Size = new Size(FLP_Censorbars.Size.Width - 10, 24);
            cs.Id = CS_Censorbar.Count;
            cs.Text = CS_Censorbar.Count.ToString();
            cs.SelectedColor = Color.Red;
            cs.CheckedChanged += new CensorbarSetting.CheckedChangedHandler(this.CS_CensorbarSelected);
            cs.ColorChangeClick += new CensorbarSetting.ColorChangeClickHandler(this.CS_ColorChangeClicked);
            CS_Censorbar.Add(cs);

            rlglCensorData.AddNewCensorbar(cs.Id, cs.SelectedColor);
            PB_KeyframeDrawingWindow.Invalidate();

            if(CS_Censorbar.Count * 20 + 20 > PB_KeyframeDrawingWindow.Height)
            {
                SB_Keyframes.Enabled = true;
                SB_Keyframes.Minimum = 0;
                SB_Keyframes.Maximum = CS_Censorbar.Count * 20 + 20 - PB_KeyframeDrawingWindow.Height;
            }

            dirty = true;
        }

        /*
         * Set the paintingOverlay to use a new id, reset the keyframe options 
         * and also redraw the keyframe-visualization-control
         */ 
        private void CS_CensorbarSelected(object sender, CheckedChangedEventArgs e)
        {
            if(e.IsChecked)
            {
                CensorbarSetting cs = (CensorbarSetting)sender;

                if(selectedCensorbar != cs.Id)
                {
                    selectedKeyframe = null;
                    L_CensorbarIdValue.Text = "";
                    L_TimeStampValue.Text = "";
                    DB_X.Text = "";
                    DB_X.Enabled = false;
                    DB_Y.Text = "";
                    DB_Y.Enabled = false;
                    CB_EndFrame.Checked = false;
                    CB_EndFrame.Enabled = false;
                    B_UpdateFrame.Enabled = false;
                }

                selectedCensorbar = cs.Id;

                for(int i=0;i<CS_Censorbar.Count;i++)
                {
                    if(CS_Censorbar[i].Id != cs.Id)
                    {
                        CS_Censorbar[i].Checked = false;
                    }
                }

                paintingOverlay.SetCurrentId(selectedCensorbar);
                PB_KeyframeDrawingWindow.Invalidate();
            }
        }

        private void CS_ColorChangeClicked(object sender, EventArgs e)
        {
            CensorbarSetting cs = (CensorbarSetting)sender;
            SetColorOfControl(cs, cs.Id);
        }

        /*
         * Play the selected video in a loop
         */ 
        private void VLC_Editor_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            if (rlglCensorData != null)
            {
                this.BeginInvoke(new Action(() => ResetPlayingToStart()));
            }
        }

        //Reloads the video and resets the paintingOverlay to the first frame of the video
        private void ResetPlayingToStart()
        {
            TB_VideoPosition.Value = 0;
            paintingOverlay.UpdatePositions(rlglCensorData.GetAllCensorPositions(TB_VideoPosition.Value));

            FileStream fs = File.OpenRead(rlglCensorData.Media);
            VLC_Editor.SetMedia(fs);
            VLC_Editor.Play();
        }

        /*
         * Update the selected keyframe with the values from the options-controls
         */ 
        private void B_UpdateFrame_Click(object sender, EventArgs e)
        {
            rlglCensorData.UpdateKeyframe(selectedKeyframe.Id, selectedKeyframe.TimePos, float.Parse(DB_X.Text), float.Parse(DB_Y.Text), (short)CB_CensorSize.SelectedIndex);
            rlglCensorData.UpdateEndFrame(selectedKeyframe.Id, selectedKeyframe.TimePos, CB_EndFrame.Checked);

            selectedKeyframe = rlglCensorData.GetNextBiggerKeyframe(selectedKeyframe.Id, selectedKeyframe.TimePos);
            UpdateKeyframeOptions();
            PB_KeyframeDrawingWindow.Invalidate();
            dirty = true;
        }

        /*
         * Fill the options controls with values from the current selected keyframe.
         */ 
        private void UpdateKeyframeOptions()
        {
            L_CensorbarIdValue.Text = selectedKeyframe.Id.ToString();
            L_TimeStampValue.Text = selectedKeyframe.TimePos.ToString();
            DB_X.Text = selectedKeyframe.XPos.ToString();
            DB_Y.Text = selectedKeyframe.YPos.ToString();
            CB_EndFrame.Checked = selectedKeyframe.EndFrame;
            CB_CensorSize.SelectedIndex = selectedKeyframe.CensorSize;

            DB_X.Enabled = true;
            DB_Y.Enabled = true;
            CB_EndFrame.Enabled = true;
            B_UpdateFrame.Enabled = true;
            CB_CensorSize.Enabled = true;
        }

        /*
         * Save the current progress to the disc.
         */ 
        private void SaveCensorData()
        {
            if(File.Exists(Path.ChangeExtension(rlglCensorData.Media, "cb")))
            {
                if (MessageBox.Show("File already exists! Do you really want to override it?", "Saving", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            rlglCensorData.SaveToFile();
            dirty = false;

            MessageBox.Show("Saving successful!", "Saving", MessageBoxButtons.OK);
        }

        /*
         * Delete the whole censorbar with it's id and all keyframes.
         */ 
        private void B_Delete_Click(object sender, EventArgs e)
        {
            int pos = -1;
            for(int i=0;i<CS_Censorbar.Count;i++)
            {
                if(CS_Censorbar[i].Id == selectedCensorbar)
                {
                    pos = i;
                    break;
                }
            }

            FLP_Censorbars.Controls.RemoveAt(pos);
            CS_Censorbar.RemoveAt(pos);

            rlglCensorData.RemoveId(selectedCensorbar);
            
            selectedKeyframe = null;
            L_CensorbarIdValue.Text = "";
            L_TimeStampValue.Text = "";
            DB_X.Text = "";
            DB_X.Enabled = false;
            DB_Y.Text = "";
            DB_Y.Enabled = false;
            CB_EndFrame.Checked = false;
            CB_EndFrame.Enabled = false;
            B_UpdateFrame.Enabled = false;

            if (rlglCensorData.Ids.Count == 0)
            {
                B_Delete.Enabled = false;
                selectedCensorbar = -1;
            }
            else
            {
                selectedCensorbar = 0;
                CS_Censorbar[0].Checked = true;
            }

            paintingOverlay.SetCurrentId(selectedCensorbar);
            PB_KeyframeDrawingWindow.Invalidate();
        }

        private void CB_GeneralCensorbarSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCensorbarSize = CB_GeneralCensorbarSize.SelectedIndex;
        }

        private void VLC_Editor_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            this.Invoke(new Action(() => SetMediaDuration()));
        }
    }
}
