using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class ImageBox: PictureBox
    {


        private PointF _startPointF;
        private PointF _endPointF;

        private bool _isDrawing = false;

        public event Action<Mat> OnDrawComplete = null;

        public ImageBox()
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.DoubleBuffered = true;

            this.MouseDown += ImageBox_MouseDown;
            this.MouseMove += ImageBox_MouseMove;
            this.MouseUp += ImageBox_MouseUp;
            this.Paint += ImageBox_Paint;
        }

        private void ImageBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            var width = Math.Abs(_endPointF.X - _startPointF.X);
            var height = Math.Abs(_endPointF.Y - _startPointF.Y);
            if (width <= 0 || height <= 0)
                return;

            var x = Math.Min(_startPointF.X, _endPointF.X);
            var y = Math.Min(_startPointF.Y, _endPointF.Y);
            using (Pen pen = new Pen(Color.FromArgb(200, Color.Green), 2F))
            {
                g.DrawRectangle(pen, x, y, width, height);
            }


        }

        private void ImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            this._isDrawing = false;
            this.Invalidate();

            using (var bitmap = new Bitmap(this.Width, this.Height))
            {
                this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
                this.OnDrawComplete?.Invoke(bitmap.ToMat());
            }
        }

        private void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button.Equals(MouseButtons.Left) && this._isDrawing) 
            {
                this._endPointF = e.Location;
                this.Invalidate();
            }

        }

        private void ImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left)) {
                this._isDrawing = true;
                this._startPointF = e.Location;

                this._endPointF = this._startPointF;
                this.Invalidate();
            }
           
        }




        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //    var g = pe.Graphics;

        //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        //    using (Pen pen = new Pen(Color.FromArgb(100, Color.Green), 1.2F))
        //    {

        //        var startX = _startPointF.X;
        //        var startY = _startPointF.Y;
        //        var width = _endPointF.X - startX;
        //        var height = _endPointF.Y - startY;
        //        g.DrawRectangle(pen, startX, startY, width, height);
        //    }

              


        //}



    }
}
