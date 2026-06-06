using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsFormsApp1.Controls
{
    internal class PhysicalSlideGlassLayout : PictureBox
    {
        private static SizeF _maxSlideGlassSize = new SizeF(110.0F, 110.0F); // 110x110毫米
        private static SizeF _slideGlassType1 = _maxSlideGlassSize; // 110x110毫米
        private static SizeF _slideGlassType2 = new SizeF(25.0F, 75.0F); // 25x75毫米
        private const float _borderWidthPx = 2.0F; // 边框宽度 像素
        private const float _paddingPx = 3.0f;     // 内边距 像素
        private const float _minSlideGlassSize = 3.0F; // 黄色框至少保留 3mm
        private SlideGlassType _currentSlideGlassType; // 当前切片类型（110x110、25x75等）

        private Color _borderColor = Color.Gray; // 边框颜色

        private ScanAreaBoundary _scanAreaBoundary = new ScanAreaBoundary(0); // 输入扫描区域边界 像素（左、上、右、下）

        private ScanAreaBoundary _scanAreaBoundaryMaxLimit = new ScanAreaBoundary(0); // 最大扫描区域边界 像素（左、上、右、下）

        private PointF _currentMousePos = PointF.Empty;
        private bool _readOnly = false; // 是否只读（只读时不允许修改扫描区域边界）

        // 所有切片类型列表（如 110x110、25x75 等），每个类型下包含对应的切片配置列表
        private List<SlideGlassType> _slideGlassType = new List<SlideGlassType>()
        {
            new SlideGlassType() {
                Name = "110 * 110",
                Value = 1,
                SlideGlassPhyConfigs = new List<SlideGlassPhysicalConfig>()
                {
                    new SlideGlassPhysicalConfig() { SlideGlassSize = _slideGlassType1, OffsetX = 0.0F, OffsetY = 0.0F }
                }
            },

            new SlideGlassType() {
                Name = "左 25 * 75",
                Value = 2,
                SlideGlassPhyConfigs = new List<SlideGlassPhysicalConfig>()
                {
                    new SlideGlassPhysicalConfig() { SlideGlassSize = _slideGlassType2, OffsetX = 21.0F, OffsetY = 17.5F }
                }
            },
            new SlideGlassType() {
                Name = "右 25 * 75",
                Value = 3,
                SlideGlassPhyConfigs = new List<SlideGlassPhysicalConfig>()
                {
                    new SlideGlassPhysicalConfig() { SlideGlassSize = _slideGlassType2, OffsetX = 63.0F, OffsetY = 17.5F }
                }
            },
            new SlideGlassType() {
                Name = "左右 25 * 25",
                Value = 4,
                SlideGlassPhyConfigs = new List<SlideGlassPhysicalConfig>()
                {
                    new SlideGlassPhysicalConfig() { SlideGlassSize = _slideGlassType2, OffsetX = 21.0F, OffsetY = 17.5F },
                    new SlideGlassPhysicalConfig() { SlideGlassSize = _slideGlassType2, OffsetX = 63.0F, OffsetY = 17.5F },
                }
             }
        };




        public SlideGlassType CurrentSlideGlassType
        {
            get => _currentSlideGlassType;
            set
            {
                if (_currentSlideGlassType == value) return;
                _currentSlideGlassType = value;
                this.Invalidate(); // 切片类型改变时，触发重绘以更新显示
            }
        }
        public List<SlideGlassType> SlideGlassTypes { get => _slideGlassType; }
        public Color BorderColor
        {
            get => _borderColor;
            set
            {

                if (_borderColor == value) return;
                _borderColor = value;
                this.Invalidate(); // 边框颜色改变时，触发重绘以更新显示
            }
        }

        public ScanAreaBoundary ScanAreaBoundary
        {
            get => _scanAreaBoundary; set
            {
                if (_scanAreaBoundary == value) return;
                _scanAreaBoundary = value;
                this.Invalidate(); // 扫描区域边界改变时，触发重绘以更新显示
            }
        }
        public ScanAreaBoundary ScanAreaBoundaryMaxLimit { get => _scanAreaBoundaryMaxLimit; set => _scanAreaBoundaryMaxLimit = value; }
        public bool ReadOnly { get => _readOnly; set => _readOnly = value; }

        public PhysicalSlideGlassLayout()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint, true);
            this.Paint += _slideGlassLayout_Paint;
            this.MouseMove += _slideGlassLayout_MouseMove;
            this.MouseLeave += _slideGlassLayout_MouseLeave;
        }

        private void _slideGlassLayout_MouseLeave(object sender, EventArgs e)
        {
            this._currentMousePos = PointF.Empty;
            this.Invalidate();
        }

        private void _slideGlassLayout_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this._currentMousePos  = e.Location;
            this.Invalidate(); 

        }

        private void _slideGlassLayout_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (this._currentMousePos != Point.Empty && !this._readOnly) {

                using (Pen p = new Pen(Color.Green, 1))
                {
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(p, 0, _currentMousePos.Y, this.Width, _currentMousePos.Y);
                    g.DrawLine(p, _currentMousePos.X, 0, _currentMousePos.X, this.Height);
                }
            }

            var pbW = this.Width;
            var pbH = this.Height;

            var ratioX = pbW / _slideGlassType1.Width;
            var ratioY = pbH / _slideGlassType1.Height;

            // 绘制最外层灰色隔离大框
            using (Pen bigBorderPen = new Pen(Color.Gray, _borderWidthPx))
            {
                bigBorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                bigBorderPen.DashStyle = DashStyle.Dash;
                g.DrawRectangle(bigBorderPen, 0, 0, pbW, pbH);
            }

            // 计算当前控件里的可用像素总宽高
            float totalWidthPx = pbW - (_borderWidthPx + _paddingPx) * 2;
            float totalHeightPx = pbH - (_borderWidthPx + _paddingPx) * 2;
            if (totalWidthPx <= 0 || totalHeightPx <= 0) return;

            // 基于 110 * 110 mm 总画布建立核心像素换算比例
            float pxPerMmX = totalWidthPx / _maxSlideGlassSize.Width;
            float pxPerMmY = totalHeightPx / _maxSlideGlassSize.Height;

            // 110×110mm 总红框的绝对像素起点
            float redRectX = _borderWidthPx + _paddingPx;
            float redRectY = _borderWidthPx + _paddingPx;

            //// 绘制固定的 110 × 110 mm 红色总外边界框
            //using (Pen SlideGlassBoxBorderPen = new Pen(Color.Red, 4.0F))
            //{
            //    SlideGlassBoxBorderPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            //    g.DrawRectangle(SlideGlassBoxBorderPen, redRectX, redRectY, totalWidthPx, totalHeightPx);
            //}


            // 遍历当前切片类型下的所有切片配置，动态绘制每个切片配置对应的绿框和黄框
            if (_currentSlideGlassType != null)
            {

                foreach (var currentConfig in _currentSlideGlassType.SlideGlassPhyConfigs)
                {
                    // 根据当前配置的 Offset 和 Size，动态算出绿框（切片）的像素位置
                    float greenRectX = redRectX + (currentConfig.OffsetX * pxPerMmX);
                    float greenRectY = redRectY + (currentConfig.OffsetY * pxPerMmY);
                    float greenWidthPx = currentConfig.SlideGlassSize.Width * pxPerMmX;
                    float greenHeightPx = currentConfig.SlideGlassSize.Height * pxPerMmY;

                    // 只有在不是纯 110 模式下，才画绿框提示用户当前的有效操作区在哪里
                    if (currentConfig.SlideGlassSize.Width <= _maxSlideGlassSize.Width || currentConfig.SlideGlassSize.Height <= _maxSlideGlassSize.Height)
                    {
                        using (Pen localBoxPen = new Pen(_borderColor, 3.0F))
                        {
                            localBoxPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            g.DrawRectangle(localBoxPen, greenRectX, greenRectY, greenWidthPx, greenHeightPx);
                        }
                    }

                    if (_readOnly)
                    {
                        continue; // 如果是只读模式，不绘制黄色选区框
                    }

                    // 计算用户在当前有效工作区内部输入的像素缩进量
                    float leftPx = _scanAreaBoundary.Left * pxPerMmX;
                    float topPx = _scanAreaBoundary.Top * pxPerMmY;
                    float rightPx = _scanAreaBoundary.Right * pxPerMmX;
                    float bottomPx = _scanAreaBoundary.Bottom * pxPerMmY;

                    // 动态计算黄色选区框的像素宽高（当前绿色区域 减去 四周缩进）
                    float yellowWidth = greenWidthPx - leftPx - rightPx;
                    float yellowHeight = greenHeightPx - topPx - bottomPx;

                    // 3.0毫米格子最小物理安全底线
                    float minSizePxX = _minSlideGlassSize * pxPerMmX;
                    float minSizePxY = _minSlideGlassSize * pxPerMmY;
                    if (yellowWidth < minSizePxX) yellowWidth = minSizePxX;
                    if (yellowHeight < minSizePxY) yellowHeight = minSizePxY;

                    // 精准计算黄色框的起始坐标（死死绑定在绿框的起点 greenRectX/Y 上往内加）
                    float yellowStartX = greenRectX + leftPx;
                    float yellowStartY = greenRectY + topPx;

                    // 在有效区域内部完美绘制黄色的半透明选区
                    using (Brush selectSelectBrush = new SolidBrush(Color.FromArgb(120, 255, 235, 59)))
                    using (Pen yellowBorderPen = new Pen(Color.FromArgb(200, 255, 215, 0), 2.0F))
                    {
                        //g.FillRectangle(selectSelectBrush, yellowStartX, yellowStartY, yellowWidth, yellowHeight);
                        //g.DrawRectangle(yellowBorderPen, yellowStartX, yellowStartY, yellowWidth, yellowHeight);
                    }
                }
            }

        }


        public void RefreshRestrictions()
        {
            if (_currentSlideGlassType != null && _currentSlideGlassType.SlideGlassPhyConfigs != null)
            {
                foreach (var currentConfig in _currentSlideGlassType.SlideGlassPhyConfigs)
                {
                    // 根据当前模式有效区的毫米数，扣除必须留下的 3mm
                    float allowableW = currentConfig.SlideGlassSize.Width - _minSlideGlassSize;
                    float allowableH = currentConfig.SlideGlassSize.Height - _minSlideGlassSize;

                    // 控制边界上限 输入的左边界 + 右边界 <= 绿框宽度 - 3mm；输入的上边界 + 下边界 <= 绿框高度 - 3mm
                    _scanAreaBoundaryMaxLimit.Right = Math.Max(0, allowableW - _scanAreaBoundary.Right);
                    _scanAreaBoundaryMaxLimit.Left = Math.Max(0, allowableW - _scanAreaBoundary.Left);
                    _scanAreaBoundaryMaxLimit.Top = Math.Max(0, allowableH - _scanAreaBoundary.Top);
                    _scanAreaBoundaryMaxLimit.Bottom = Math.Max(0, allowableH - _scanAreaBoundary.Bottom);
                }

                this.Invalidate();
            }

        }
    }

    /// <summary>
    /// 切片类型类，包含切片类型名称、对应的整数值以及该类型下的所有切片配置列表
    /// </summary>
    public class SlideGlassType
    {
        public string Name; // 切片类型名称（如 110x110、25x75 等）
        public int Value;  // 切片类型对应的整数值（如 1、2 等）
        public List<SlideGlassPhysicalConfig> SlideGlassPhyConfigs;  // 该切片类型下的所有切片配置列表 
    }


    /// <summary>
    /// 扫描区域边界类，包含用户输入的扫描区域相对于绿框的四个边界值（左、上、右、下），单位为毫米
    /// </summary>
    public class ScanAreaBoundary
    {
        public float Left;   // 扫描区域左边界（mm）
        public float Top;    // 扫描区域上边界（mm）
        public float Right;  // 扫描区域右边界（mm）
        public float Bottom; // 扫描区域下边界（mm）

        public ScanAreaBoundary(float left, float top, float right, float bottom) : this(left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public ScanAreaBoundary(float initialValue)
        {
            Left = initialValue;
            Top = initialValue;
            Right = initialValue;
            Bottom = initialValue;
        }
    }

    /// <summary>
    /// 切片配置类，包含切片的物理尺寸和相对于 110mm 大框的偏移信息
    /// </summary>
    public class SlideGlassPhysicalConfig
    {
        public SizeF SlideGlassSize;   // 切片的物理尺寸（mm）
        public float OffsetX;      // 有效区相对于 110mm 大框左上角的横向偏移（mm）
        public float OffsetY;      // 有效区相对于 110mm 大框左上角的纵向偏移（mm）
    }

}
