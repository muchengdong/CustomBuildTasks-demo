using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controls;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        private SlideGlassType _currentSlideGlassType;

        public Form2()
        {
            InitializeComponent();

            this.InitSelect();
            this.InitGridPanel();
            this.sliceContainer1.BorderColor = Color.Green;
            this.sliceContainer1.Cursor = Cursors.Cross;
            this.dynamicPhysicalRulerControl1.CornerOffset = 20;
            this.dynamicPhysicalRulerControl2.CornerOffset = 0;
        }

        private void InitSelect()
        {

            foreach (var item in sliceContainer1.SlideGlassTypes)
            {
                select1.Items.Add(new AntdUI.SelectItem(item.Name, item));
            }
        }

        private void InitGridPanel()
        {

            this.gridPanel1.Gap = 6;
            var slideGlassTypes = sliceContainer1.SlideGlassTypes.Reverse<SlideGlassType>();
            foreach (var item in slideGlassTypes)
            {
                var slideGlassLayout = new PhysicalSlideGlassLayout() { Tag = item, CurrentSlideGlassType = item, Dock = DockStyle.Fill };
                slideGlassLayout.Cursor = Cursors.Hand;
                slideGlassLayout.ReadOnly = true;
                slideGlassLayout.Click += _slideGlassLayout_Click;
                var panel = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(5) };
                panel.Controls.Add(slideGlassLayout);
                this.gridPanel1.Controls.Add(panel);
            }
        }

        private void _slideGlassLayout_Click(object sender, EventArgs e)
        {
            if (sender is PhysicalSlideGlassLayout slideGlassLayout)
            {
                slideGlassLayout.BorderColor = Color.Green;
                this._currentSlideGlassType = slideGlassLayout.CurrentSlideGlassType;
                var allControls = this.gridPanel1.Controls;
                foreach (Panel control in allControls)
                {
                    foreach (var item in control.Controls)
                    {
                        if (item is PhysicalSlideGlassLayout layout && layout != slideGlassLayout)
                        {
                            layout.BorderColor = Color.Gray;
                        }
                    }
                }
            }
        }

        private void sliceContainer1_Click(object sender, EventArgs e)
        {

        }

        private void select1_SelectedIndexChanged(object sender, AntdUI.IntEventArgs e)
        {

            if (this.select1.SelectedValue is SlideGlassType sliceType)
            {

                this.sliceContainer1.CurrentSlideGlassType = sliceType;
                //this.sliceContainer1.Invalidate();

                this.inputLeft.Value = 0;
                this.inputRight.Value = 0;
                this.inputTop.Value = 0;
                this.inputBottom.Value = 0;

                this.sliceContainer1.RefreshRestrictions();
                var limit = this.sliceContainer1.ScanAreaBoundaryMaxLimit;
                inputLeft.Maximum = (decimal)limit.Left;
                inputRight.Maximum = (decimal)limit.Right;
                inputTop.Maximum = (decimal)limit.Top;
                inputBottom.Maximum = (decimal)limit.Bottom;

                //this.sliceContainer1.Invalidate();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void inputLeft_ValueChanged(object sender, AntdUI.DecimalEventArgs e)
        {
            this.sliceContainer1.ScanAreaBoundary = new ScanAreaBoundary(
                (float)this.inputLeft.Value,
                (float)this.inputTop.Value,
                (float)this.inputRight.Value,
                (float)this.inputBottom.Value
             );
        }

        private void inputRight_ValueChanged(object sender, AntdUI.DecimalEventArgs e)
        {
            this.sliceContainer1.ScanAreaBoundary = new ScanAreaBoundary(
               (float)this.inputLeft.Value,
               (float)this.inputTop.Value,
               (float)this.inputRight.Value,
               (float)this.inputBottom.Value
            );

        }

        private void inputTop_ValueChanged(object sender, AntdUI.DecimalEventArgs e)
        {
            this.sliceContainer1.ScanAreaBoundary = new ScanAreaBoundary(
               (float)this.inputLeft.Value,
               (float)this.inputTop.Value,
               (float)this.inputRight.Value,
               (float)this.inputBottom.Value
            );
        }

        private void inputBottom_ValueChanged(object sender, AntdUI.DecimalEventArgs e)
        {
            this.sliceContainer1.ScanAreaBoundary = new ScanAreaBoundary(
               (float)this.inputLeft.Value,
               (float)this.inputTop.Value,
               (float)this.inputRight.Value,
               (float)this.inputBottom.Value
            );
        }
    }
}
