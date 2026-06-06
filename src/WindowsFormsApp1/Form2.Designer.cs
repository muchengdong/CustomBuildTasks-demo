namespace WindowsFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.select1 = new AntdUI.Select();
            this.gridPanel1 = new AntdUI.GridPanel();
            this.inputLeft = new AntdUI.InputNumber();
            this.inputTop = new AntdUI.InputNumber();
            this.inputRight = new AntdUI.InputNumber();
            this.inputBottom = new AntdUI.InputNumber();
            this.button1 = new AntdUI.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dynamicPhysicalRulerControl2 = new WindowsFormsApp1.Controls.DynamicPhysicalRulerControl();
            this.dynamicPhysicalRulerControl1 = new WindowsFormsApp1.Controls.DynamicPhysicalRulerControl();
            this.sliceContainer1 = new WindowsFormsApp1.Controls.PhysicalSlideGlassLayout();
            this.panel2 = new AntdUI.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliceContainer1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // select1
            // 
            this.select1.Location = new System.Drawing.Point(766, 68);
            this.select1.Name = "select1";
            this.select1.Radius = 0;
            this.select1.Size = new System.Drawing.Size(154, 41);
            this.select1.TabIndex = 1;
            this.select1.Text = "select1";
            this.select1.SelectedIndexChanged += new AntdUI.IntEventHandler(this.select1_SelectedIndexChanged);
            // 
            // gridPanel1
            // 
            this.gridPanel1.Location = new System.Drawing.Point(710, 384);
            this.gridPanel1.Name = "gridPanel1";
            this.gridPanel1.Size = new System.Drawing.Size(300, 300);
            this.gridPanel1.TabIndex = 2;
            this.gridPanel1.Text = "gridPanel1";
            // 
            // inputLeft
            // 
            this.inputLeft.AlwaysShowControl = true;
            this.inputLeft.Location = new System.Drawing.Point(766, 115);
            this.inputLeft.Name = "inputLeft";
            this.inputLeft.Radius = 0;
            this.inputLeft.ShowControl = false;
            this.inputLeft.Size = new System.Drawing.Size(118, 41);
            this.inputLeft.TabIndex = 3;
            this.inputLeft.Text = "0";
            this.inputLeft.ValueChanged += new AntdUI.DecimalEventHandler(this.inputLeft_ValueChanged);
            // 
            // inputTop
            // 
            this.inputTop.AlwaysShowControl = true;
            this.inputTop.EnabledValueTextChange = true;
            this.inputTop.Location = new System.Drawing.Point(766, 209);
            this.inputTop.Name = "inputTop";
            this.inputTop.Radius = 0;
            this.inputTop.ShowControl = false;
            this.inputTop.Size = new System.Drawing.Size(118, 41);
            this.inputTop.TabIndex = 4;
            this.inputTop.Text = "0";
            this.inputTop.ValueChanged += new AntdUI.DecimalEventHandler(this.inputTop_ValueChanged);
            // 
            // inputRight
            // 
            this.inputRight.AlwaysShowControl = true;
            this.inputRight.EnabledValueTextChange = true;
            this.inputRight.Location = new System.Drawing.Point(766, 162);
            this.inputRight.Name = "inputRight";
            this.inputRight.Radius = 0;
            this.inputRight.ShowControl = false;
            this.inputRight.Size = new System.Drawing.Size(118, 41);
            this.inputRight.TabIndex = 5;
            this.inputRight.Text = "0";
            this.inputRight.ValueChanged += new AntdUI.DecimalEventHandler(this.inputRight_ValueChanged);
            // 
            // inputBottom
            // 
            this.inputBottom.AlwaysShowControl = true;
            this.inputBottom.EnabledValueTextChange = true;
            this.inputBottom.Location = new System.Drawing.Point(766, 264);
            this.inputBottom.Name = "inputBottom";
            this.inputBottom.Radius = 0;
            this.inputBottom.ShowControl = false;
            this.inputBottom.Size = new System.Drawing.Size(118, 41);
            this.inputBottom.TabIndex = 6;
            this.inputBottom.Text = "0";
            this.inputBottom.ValueChanged += new AntdUI.DecimalEventHandler(this.inputBottom_ValueChanged);
            // 
            // button1
            // 
            this.button1.BorderWidth = 1F;
            this.button1.Location = new System.Drawing.Point(905, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dynamicPhysicalRulerControl2);
            this.panel1.Controls.Add(this.dynamicPhysicalRulerControl1);
            this.panel1.Location = new System.Drawing.Point(24, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 400);
            this.panel1.TabIndex = 10;
            // 
            // dynamicPhysicalRulerControl2
            // 
            this.dynamicPhysicalRulerControl2.BackColor = System.Drawing.Color.White;
            this.dynamicPhysicalRulerControl2.CornerOffset = 30;
            this.dynamicPhysicalRulerControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dynamicPhysicalRulerControl2.Location = new System.Drawing.Point(0, 20);
            this.dynamicPhysicalRulerControl2.Margin = new System.Windows.Forms.Padding(0);
            this.dynamicPhysicalRulerControl2.Name = "dynamicPhysicalRulerControl2";
            this.dynamicPhysicalRulerControl2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.dynamicPhysicalRulerControl2.ScaleColor = System.Drawing.Color.Black;
            this.dynamicPhysicalRulerControl2.Size = new System.Drawing.Size(20, 380);
            this.dynamicPhysicalRulerControl2.TabIndex = 12;
            this.dynamicPhysicalRulerControl2.Text = "dynamicPhysicalRulerControl2";
            // 
            // dynamicPhysicalRulerControl1
            // 
            this.dynamicPhysicalRulerControl1.BackColor = System.Drawing.Color.White;
            this.dynamicPhysicalRulerControl1.CornerOffset = 30;
            this.dynamicPhysicalRulerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dynamicPhysicalRulerControl1.Location = new System.Drawing.Point(0, 0);
            this.dynamicPhysicalRulerControl1.Name = "dynamicPhysicalRulerControl1";
            this.dynamicPhysicalRulerControl1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.dynamicPhysicalRulerControl1.ScaleColor = System.Drawing.Color.Black;
            this.dynamicPhysicalRulerControl1.Size = new System.Drawing.Size(400, 20);
            this.dynamicPhysicalRulerControl1.TabIndex = 11;
            this.dynamicPhysicalRulerControl1.Text = "dynamicPhysicalRulerControl1";
            // 
            // sliceContainer1
            // 
            this.sliceContainer1.BorderColor = System.Drawing.Color.Gray;
            this.sliceContainer1.CurrentSlideGlassType = null;
            this.sliceContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliceContainer1.Location = new System.Drawing.Point(0, 0);
            this.sliceContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.sliceContainer1.Name = "sliceContainer1";
            this.sliceContainer1.ReadOnly = false;
            this.sliceContainer1.Size = new System.Drawing.Size(380, 380);
            this.sliceContainer1.TabIndex = 0;
            this.sliceContainer1.TabStop = false;
            this.sliceContainer1.Click += new System.EventHandler(this.sliceContainer1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sliceContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 380);
            this.panel2.TabIndex = 13;
            this.panel2.Text = "panel2";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 718);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputBottom);
            this.Controls.Add(this.inputRight);
            this.Controls.Add(this.inputTop);
            this.Controls.Add(this.inputLeft);
            this.Controls.Add(this.gridPanel1);
            this.Controls.Add(this.select1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sliceContainer1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PhysicalSlideGlassLayout sliceContainer1;
        private AntdUI.Select select1;
        private AntdUI.GridPanel gridPanel1;
        private AntdUI.InputNumber inputLeft;
        private AntdUI.InputNumber inputTop;
        private AntdUI.InputNumber inputRight;
        private AntdUI.InputNumber inputBottom;
        private AntdUI.Button button1;
        private System.Windows.Forms.Panel panel1;
        private Controls.DynamicPhysicalRulerControl dynamicPhysicalRulerControl1;
        private Controls.DynamicPhysicalRulerControl dynamicPhysicalRulerControl2;
        private AntdUI.Panel panel2;
    }
}