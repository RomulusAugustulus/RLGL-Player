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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RLGL_Player
{
    /*
     * The PaintingOverlay is a special transparent dialog window that handles
     * clicking on the video and gives visual feedback where the censorbars
     * will be positioned.
     */ 
    public partial class PaintingOverlay : Form
    {
        private int currentId;
        private Dictionary<int, PointF> currentPositions;
        private Dictionary<int, Color> editorCensorbarColors;

        public delegate void PositionUpdateHandler(object sender, PositionUpdateEventArgs e);

        /*
         * Is fired when this control receives a double click.
         */ 
        public event PositionUpdateHandler PositionUpdated;

        public PaintingOverlay()
        {
            InitializeComponent();
            currentPositions = new Dictionary<int, PointF>();

            this.TransparencyKey = Color.Crimson;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //empty implementation
        }

        /*
         * Draw dots at the center of each censorbar for the current frame.
         */ 
        private void PaintingOverlay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Crimson);

            foreach(int id in currentPositions.Keys)
            {
                SolidBrush b = new SolidBrush(editorCensorbarColors[id]);
                Rectangle rect = new Rectangle((int)(currentPositions[id].X * this.Width)-10,(int)(currentPositions[id].Y * this.Height)-10,20,20);
                e.Graphics.FillEllipse(b, rect);
                b.Dispose();
            }
        }

        /*
         * Send the position of the mouse to the parent window and return focus.
         */ 
        private void PaintingOverlay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point mousePos = e.Location;
            PointF relativePos = new PointF((float)mousePos.X / (float)this.Width, (float)mousePos.Y / (float)this.Height);

            PositionUpdated(this, new PositionUpdateEventArgs(currentId, relativePos));
            this.Owner.Focus();
        }

        public void SetCurrentId(int id)
        {
            currentId = id;
        }

        public void SetCensorbarColorScheme(Dictionary<int, Color> colors)
        {
            this.editorCensorbarColors = colors;
        }

        /*
         * Get new positions of the censorbars and draw them on the control.
         */ 
        public void UpdatePositions(Dictionary<int, PointF> positions)
        {
            this.currentPositions = positions;
            this.Refresh();
        }
    }

    /*
     * Position update events transport the currently selected id and
     * the position.
     */ 
    public class PositionUpdateEventArgs : System.EventArgs
    {
        private int id;
        private PointF position;

        public PositionUpdateEventArgs(int id, PointF position)
        {
            this.id = id;
            this.position = position;
        }

        public int GetID()
        {
            return id;
        }

        public PointF GetPosition()
        {
            return position;
        }
    }
}
