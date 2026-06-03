namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picPrewiew = new System.Windows.Forms.PictureBox();
            this.imageBox1 = new WindowsFormsApp1.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPrewiew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picPrewiew
            // 
            this.picPrewiew.Location = new System.Drawing.Point(796, 179);
            this.picPrewiew.Name = "picPrewiew";
            this.picPrewiew.Size = new System.Drawing.Size(273, 242);
            this.picPrewiew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPrewiew.TabIndex = 1;
            this.picPrewiew.TabStop = false;
            this.picPrewiew.Click += new System.EventHandler(this.picPrewiew_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Image = global::WindowsFormsApp1.Properties.Resources.cat;
            this.imageBox1.Location = new System.Drawing.Point(12, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(532, 328);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox1.TabIndex = 0;
            this.imageBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 542);
            this.Controls.Add(this.picPrewiew);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picPrewiew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ImageBox imageBox1;
        private System.Windows.Forms.PictureBox picPrewiew;
    }
}

