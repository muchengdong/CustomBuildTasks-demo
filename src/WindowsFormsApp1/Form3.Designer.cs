namespace WindowsFormsApp1
{
    partial class Form3
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
            this.panel1 = new AntdUI.Panel();
            this.customImageBox1 = new WindowsFormsApp1.Controls.CustomImageBox();
            this.gridPanel1 = new AntdUI.GridPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridPanel1);
            this.panel1.Controls.Add(this.customImageBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Radius = 0;
            this.panel1.Size = new System.Drawing.Size(1006, 629);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // customImageBox1
            // 
            this.customImageBox1.Image = null;
            this.customImageBox1.Location = new System.Drawing.Point(531, 89);
            this.customImageBox1.Name = "customImageBox1";
            this.customImageBox1.Size = new System.Drawing.Size(403, 424);
            this.customImageBox1.TabIndex = 0;
            this.customImageBox1.Text = "customImageBox1";
            this.customImageBox1.Click += new System.EventHandler(this.customImageBox1_Click);
            // 
            // gridPanel1
            // 
            this.gridPanel1.Location = new System.Drawing.Point(94, 130);
            this.gridPanel1.Name = "gridPanel1";
            this.gridPanel1.Size = new System.Drawing.Size(146, 146);
            this.gridPanel1.TabIndex = 1;
            this.gridPanel1.Text = "gridPanel1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 629);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private Controls.CustomImageBox customImageBox1;
        private AntdUI.GridPanel gridPanel1;
    }
}