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
            this.sliceContainer1 = new WindowsFormsApp1.Controls.SlideGlassLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliceContainer1)).BeginInit();
            this.SuspendLayout();
            // 
            // select1
            // 
            this.select1.Location = new System.Drawing.Point(531, 74);
            this.select1.Name = "select1";
            this.select1.Radius = 0;
            this.select1.Size = new System.Drawing.Size(154, 41);
            this.select1.TabIndex = 1;
            this.select1.Text = "select1";
            this.select1.SelectedIndexChanged += new AntdUI.IntEventHandler(this.select1_SelectedIndexChanged);
            // 
            // gridPanel1
            // 
            this.gridPanel1.Location = new System.Drawing.Point(36, 386);
            this.gridPanel1.Name = "gridPanel1";
            this.gridPanel1.Size = new System.Drawing.Size(300, 300);
            this.gridPanel1.TabIndex = 2;
            this.gridPanel1.Text = "gridPanel1";
            // 
            // inputLeft
            // 
            this.inputLeft.AlwaysShowControl = true;
            this.inputLeft.Location = new System.Drawing.Point(531, 121);
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
            this.inputTop.Location = new System.Drawing.Point(531, 215);
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
            this.inputRight.Location = new System.Drawing.Point(531, 168);
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
            this.inputBottom.Location = new System.Drawing.Point(531, 270);
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
            this.button1.Location = new System.Drawing.Point(670, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sliceContainer1
            // 
            this.sliceContainer1.BorderColor = System.Drawing.Color.Gray;
            this.sliceContainer1.CurrentSlideGlassType = null;
            this.sliceContainer1.Location = new System.Drawing.Point(36, 37);
            this.sliceContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.sliceContainer1.Name = "sliceContainer1";
            this.sliceContainer1.Size = new System.Drawing.Size(300, 300);
            this.sliceContainer1.TabIndex = 0;
            this.sliceContainer1.TabStop = false;
            this.sliceContainer1.Click += new System.EventHandler(this.sliceContainer1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 718);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputBottom);
            this.Controls.Add(this.inputRight);
            this.Controls.Add(this.inputTop);
            this.Controls.Add(this.inputLeft);
            this.Controls.Add(this.gridPanel1);
            this.Controls.Add(this.select1);
            this.Controls.Add(this.sliceContainer1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sliceContainer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SlideGlassLayout sliceContainer1;
        private AntdUI.Select select1;
        private AntdUI.GridPanel gridPanel1;
        private AntdUI.InputNumber inputLeft;
        private AntdUI.InputNumber inputTop;
        private AntdUI.InputNumber inputRight;
        private AntdUI.InputNumber inputBottom;
        private AntdUI.Button button1;
    }
}