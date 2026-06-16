using OpenCvSharp;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            this.customImageBox1.Dock = DockStyle.Fill;

            var imgMat = Cv2.ImRead(@"D:\CustomBuildTasks-demo\src\WindowsFormsApp1\Resources\test.jpg");
            this.customImageBox1.Image = imgMat.ToBitmap();

        }

        private void customImageBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
