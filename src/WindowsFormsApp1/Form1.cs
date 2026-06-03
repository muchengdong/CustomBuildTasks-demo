using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.imageBox1.OnDrawComplete += ImageBox1_OnDrawComplete;
        }

        private void ImageBox1_OnDrawComplete(OpenCvSharp.Mat obj)
        {

            picPrewiew.Image = obj.ToBitmap();
        }

        private void picPrewiew_Click(object sender, EventArgs e)
        {

        }
    }
}
