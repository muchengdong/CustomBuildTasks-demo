using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OpenCvSharp.Stitcher;

namespace WindowsFormsApp1.Controls
{

    public class CustomImageBox : Control
    {
        private float _scale = 1.0F;
        private float _pyhCellSize = 3.5F; // 物理格子尺寸 毫米
        private const float _maxBoxSize = 110.0F; // 最大物理尺寸 毫米
        private float _cellSize; // 像素
        private int _parentW; // 父容器宽度 像素
        private int _parentH; // 父容器高度 像素

        private Matrix _transformMatrix = new Matrix();
        private Image _image = null; // 底图对象

        // 鼠标左键框选相关的逻辑画布坐标
        private PointF _startPoint;
        private PointF _currentPoint;
        private int _startCol = -1;
        private int _endCol = -1;
        private int _startRow = -1;
        private int _endRow = -1;
        private bool _isDragging = false; // 是否正在左键框选

        // 【新增】鼠标右键平移相关的物理像素坐标
        private Point _lastMousePosition; // 记录上一次鼠标的屏幕像素位置
        private bool _isPanning = false;      // 是否正在右键平移画布

        // 提供外部传入图片的属性
        public Image Image
        {
            get => _image;
            set
            {
                _image = value;
                this.Invalidate();
            }
        }

        public CustomImageBox()
        {
            this.DoubleBuffered = true;
            this.Resize += _customImageBox_Resize;
            this.Paint += _customImageBox_Paint;
            this.MouseDown += _customImageBox_MouseDown;
            this.MouseMove += _customImageBox_MouseMove;
            this.MouseUp += _customImageBox_MouseUp;
            this.MouseWheel += _customImageBox_MouseWheel;
        }

        // 辅助函数：物理像素坐标 -> 画布逻辑坐标
        private PointF GetLogicalPoint(Point mouseLocation)
        {
            if (_transformMatrix == null) return mouseLocation;
            using (Matrix invertMatrix = _transformMatrix.Clone())
            {
                invertMatrix.Invert();
                PointF[] points = new PointF[] { mouseLocation };
                invertMatrix.TransformPoints(points);
                return points[0];
            }
        }

        private void _customImageBox_MouseWheel(object sender, MouseEventArgs e)
        {
            float stepFactor = e.Delta > 0 ? 1.1f : (1.0f / 1.1f);
            float newScale = _scale * stepFactor;
            newScale = Math.Max(1.0f, Math.Min(newScale, 20f));

            float realFactor = newScale / _scale;
            _scale = newScale;

            // 这里采用【方案A】控件可见区域中心点缩放（可根据需要改回 e.X, e.Y 鼠标中心缩放）
            float centerX = this.Width / 2f;
            float centerY = this.Height / 2f;

            _transformMatrix.Translate(-centerX, -centerY, MatrixOrder.Append);
            _transformMatrix.Scale(realFactor, realFactor, MatrixOrder.Append);
            _transformMatrix.Translate(centerX, centerY, MatrixOrder.Append);

            // 缩放导致画布变化，如果在框选中，刷新当前的逻辑坐标
            if (_isDragging)
            {
                _currentPoint = GetLogicalPoint(e.Location);
                _endCol = (int)Math.Floor(_currentPoint.X / _cellSize);
                _endRow = (int)Math.Floor(_currentPoint.Y / _cellSize);
            }

            this.Invalidate();
        }

        private void _customImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            // 1. 左键：框选网格
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _startPoint = GetLogicalPoint(e.Location);
                _currentPoint = _startPoint;

                _startCol = (int)Math.Floor(_currentPoint.X / _cellSize);
                _endCol = _startCol;
                _startRow = (int)Math.Floor(_currentPoint.Y / _cellSize);
                _endRow = _startRow;

                this.Invalidate();
            }
            // 2. 【新增】右键：触发画布平移
            else if (e.Button == MouseButtons.Right)
            {
                _isPanning = true;
                _lastMousePosition = e.Location; // 记录按下时的物理像素位置
                this.Cursor = Cursors.SizeAll;   // 变换鼠标指针样式为“十字手”
            }
        }

        private void _customImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            // 左键框选逻辑
            if (_isDragging)
            {
                _currentPoint = GetLogicalPoint(e.Location);
                _endCol = (int)Math.Floor(_currentPoint.X / _cellSize);
                _endRow = (int)Math.Floor(_currentPoint.Y / _cellSize);

                this.Invalidate();
            }
            // 右键平移逻辑
            else if (_isPanning)
            {
                // 计算当前鼠标和上一帧鼠标之间的“物理像素差值”
                float deltaX = e.X - _lastMousePosition.X;
                float deltaY = e.Y - _lastMousePosition.Y;

                // 直接追加平移矩阵。平移不需要处理缩放比例，屏幕移动多少像素，画布就平移多少像素
                _transformMatrix.Translate(deltaX, deltaY, MatrixOrder.Append);

                // 更新历史鼠标位置
                _lastMousePosition = e.Location;
                this.Invalidate();
            }
        }

        private void _customImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
                this.Invalidate();
            }

            else if (e.Button == MouseButtons.Right)
            {
                _isPanning = false;
                this.Cursor = Cursors.Default; // 还原鼠标指针
            }
        }

        private void _customImageBox_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var gState = g.Save();

            if (this.Parent != null)
            {
                var parentClientSize = this.Parent.ClientSize;
                _parentH = parentClientSize.Height;
                _parentW = parentClientSize.Width;
            }

            _cellSize = _parentH / _maxBoxSize * _pyhCellSize;

            // 应用我们维护好的变换矩阵（包含缩放和平移）
            g.Transform = _transformMatrix;

            // 绘制图片
            DrawImage(g);

            // 绘制网格线
            DrawGrid(g);

            // 绘制选的黄色区域
            DrawSelectedGrid(g);

            g.Restore(gState);
        }

        private void DrawImage(Graphics g)
        {
            if (_image == null) return;
            // 矩阵已处理好缩放和平移，直接在(0,0)位置以原始像素尺寸绘制图片即可

            var imageX = (_parentW - _image.Width) / 2;
            var imageY = (_parentH - _image.Height) / 2;
            g.DrawImage(_image, imageX, imageY, _image.Width, _image.Height);
        }

        private void DrawSelectedGrid(Graphics g)
        {
            using (Brush selectSelectBrush = new SolidBrush(Color.FromArgb(120, 255, 235, 59)))
            using (Pen cellBorderPen = new Pen(Color.FromArgb(180, 255, 160, 0), 1.0F))
            using (Pen greenBorderPen = new Pen(Color.DarkCyan, 2.0F))
            {
                // 绘制绿色的鼠标拖拽实时虚线框
                var x = _startPoint.X;
                var y = _startPoint.Y;
                var width = _currentPoint.X - x;
                var height = _currentPoint.Y - y;
                g.DrawRectangle(greenBorderPen, x, y, width, height);

                // 绘制选中的网格单元
                if (_startCol >= 0 && _startRow >= 0 && _endCol >= 0 && _endRow >= 0)
                {
                    int minCol = Math.Min(_startCol, _endCol);
                    int maxCol = Math.Max(_startCol, _endCol);
                    int minRow = Math.Min(_startRow, _endRow);
                    int maxRow = Math.Max(_startRow, _endRow);

                    for (int row = minRow; row <= maxRow; row++)
                    {
                        for (int col = minCol; col <= maxCol; col++)
                        {
                            float cellX = col * _cellSize;
                            float cellY = row * _cellSize;

                            g.FillRectangle(selectSelectBrush, cellX, cellY, _cellSize, _cellSize);
                            g.DrawRectangle(cellBorderPen, cellX, cellY, _cellSize, _cellSize);
                        }
                    }
                }
            }
        }

        private void DrawGrid(Graphics g)
        {
            using (var gridPen = new Pen(Color.FromArgb(100, Color.DarkGray), 1.0F))
            {
                gridPen.Alignment = PenAlignment.Inset;
                gridPen.DashStyle = DashStyle.Dash;

                // 1. 获取当前控件的四个物理角坐标
                PointF[] screenCorners = new PointF[]
                {
            new PointF(0, 0),                        // 左上
            new PointF(this.Width, this.Height)      // 右下
                };

                // 利用逆矩阵，将屏幕的物理边界转换为当前画布的“逻辑坐标边界”
                using (Matrix invertMatrix = _transformMatrix.Clone())
                {
                    invertMatrix.Invert();
                    invertMatrix.TransformPoints(screenCorners);
                }

                // 当前可见区域在画布上的真实范围（带缩放和平移后的绝对坐标）
                float visibleLeft = screenCorners[0].X;
                float visibleTop = screenCorners[0].Y;
                float visibleRight = screenCorners[1].X;
                float visibleBottom = screenCorners[1].Y;

                // 根据可见边界，动态计算应该绘制的起始行/列和结束行/列（通过 Math.Floor 和 Math.Ceiling 确保完全覆盖屏幕）
                int startCol = (int)Math.Floor(visibleLeft / _cellSize);
                int endCol = (int)Math.Ceiling(visibleRight / _cellSize);
                int startRow = (int)Math.Floor(visibleTop / _cellSize);
                int endRow = (int)Math.Ceiling(visibleBottom / _cellSize);

                //动态绘制可见区域内的列线
                for (int col = startCol; col <= endCol; col++)
                {
                    float x = col * _cellSize;
                    // 线的起点和终点延伸到当前可见区域的上下边界
                    g.DrawLine(gridPen, x, visibleTop, x, visibleBottom);
                }

                // 动态绘制可见区域内的行线
                for (int row = startRow; row <= endRow; row++)
                {
                    float y = row * _cellSize;
                    // 线的起点和终点延伸到当前可见区域的左右边界
                    g.DrawLine(gridPen, visibleLeft, y, visibleRight, y);
                }
            }
        }


        private void _customImageBox_Resize(object sender, EventArgs e)
        {
            this.ResetDraw();
            this.Invalidate();
        }

        private void ResetDraw()
        {
            _scale = 1.0F;
            _transformMatrix?.Reset();
            _startPoint = new PointF(0, 0);
            _currentPoint = new PointF(0, 0);
            _startCol = -1;
            _endCol = -1;
            _startRow = -1;
            _endRow = -1;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _transformMatrix?.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
