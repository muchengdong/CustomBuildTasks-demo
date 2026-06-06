using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1.Controls
{
    internal class DynamicPhysicalRulerControl : Control
    {
        private float totalMm = 110f; // 逻辑总长度：110毫米
        private float stepMm = 3f;    // 逻辑基础格子：3毫米

        // 🔑 新增属性：左上角死角的偏移像素（默认30，需与你设置的标尺宽/高度一致）
        [Category("Ruler")]
        public int CornerOffset { get; set; } = 30;

        [Category("Ruler")]
        public Orientation Orientation { get; set; } = Orientation.Horizontal;

        [Category("Ruler")]
        public Color ScaleColor { get; set; } = Color.Black;

        public DynamicPhysicalRulerControl()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);

            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            using (Pen pen = new Pen(ScaleColor, 1))
            using (Brush brush = new SolidBrush(ScaleColor))
            using (Font font = new Font("Segoe UI", 7.5f))
            {
                if (Orientation == Orientation.Horizontal)
                {
                    // 1. 绘制水平底线（从偏移量开始画到最后）
                    g.DrawLine(pen, CornerOffset, Height - 1, Width, Height - 1);

                    // 计算扣除死角后，剩下可用的绘图像素宽度
                    int availableWidth = Width - CornerOffset;
                    if (availableWidth <= 0) return;

                    float pixelsPerMm = (float)availableWidth / totalMm;

                    // 2. 循环绘制缩放刻度
                    for (float mm = 0; mm <= totalMm; mm += stepMm)
                    {
                        // 核心修改：每一个 X 坐标都必须加上 CornerOffset 偏移量
                        int x = CornerOffset + (int)Math.Round(mm * pixelsPerMm);
                        if (x > Width) x = Width;

                        int tickHeight;
                        int mmInt = (int)Math.Round(mm);

                        if (mmInt % 30 == 0 || mmInt == (int)totalMm)
                        {
                            tickHeight = Height - 12;

                            string text = $"{mmInt}";
                            SizeF textSize = g.MeasureString(text, font);
                            float textX = (x + textSize.Width > Width) ? Width - textSize.Width : x + 2;

                            g.DrawString(text, font, brush, textX - 6, 2);
                        }
                        else if (mmInt % 15 == 0)
                        {
                            tickHeight = Height / 2;
                        }
                        else
                        {
                            tickHeight = Height / 4;
                        }

                        g.DrawLine(pen, x, Height - 1, x, Height - 1 - tickHeight);
                    }
                }
                else // 垂直标尺逻辑
                {
                    // 1. 绘制垂直右侧线（从偏移量开始往下画）
                    g.DrawLine(pen, Width - 1, CornerOffset, Width - 1, Height);

                    // 计算扣除死角后，剩下可用的绘图像素高度
                    int availableHeight = Height - CornerOffset;
                    if (availableHeight <= 0) return;

                    float pixelsPerMm = (float)availableHeight / totalMm;

                    // 2. 循环绘制垂直缩放刻度
                    for (float mm = 0; mm <= totalMm; mm += stepMm)
                    {
                        //  核心修改：每一个 Y 坐标都必须加上 CornerOffset 偏移量
                        int y = CornerOffset + (int)Math.Round(mm * pixelsPerMm);
                        if (y > Height) y = Height;

                        int tickWidth;
                        int mmInt = (int)Math.Round(mm);

                        if (mmInt % 30 == 0 || mmInt == (int)totalMm)
                        {
                            tickWidth = Width - 15;

                            string text = $"{mmInt}";
                            SizeF textSize = g.MeasureString(text, font);
                            float textY = (y + textSize.Height > Height) ? Height - textSize.Height : y + 2;

                            g.DrawString(text, font, brush, 2, textY);
                        }
                        else if (mmInt % 15 == 0)
                        {
                            tickWidth = Width / 2;
                        }
                        else
                        {
                            tickWidth = Width / 4;
                        }

                        g.DrawLine(pen, Width - 1, y, Width - 1 - tickWidth, y);
                    }
                }
            }
        }
    }

}
