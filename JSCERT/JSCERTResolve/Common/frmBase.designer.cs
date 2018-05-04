namespace Common
{
    partial class frmBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelWorkArea = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbtitle = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.menuStripMinMaxClose = new System.Windows.Forms.MenuStrip();
            this.pictureBoxClose = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxMax = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxMin = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelTopLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelTopRight.SuspendLayout();
            this.menuStripMinMaxClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelMain.Controls.Add(this.panelWorkArea);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(1, 1);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(478, 338);
            this.panelMain.TabIndex = 1;
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.BackColor = System.Drawing.SystemColors.Control;
            this.panelWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkArea.Location = new System.Drawing.Point(0, 28);
            this.panelWorkArea.Name = "panelWorkArea";
            this.panelWorkArea.Size = new System.Drawing.Size(478, 310);
            this.panelWorkArea.TabIndex = 3;
            this.panelWorkArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelWorkArea_Paint);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTop.BackgroundImage")));
            this.panelTop.Controls.Add(this.panelTitle);
            this.panelTop.Controls.Add(this.panelTopLeft);
            this.panelTop.Controls.Add(this.panelTopRight);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(478, 28);
            this.panelTop.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelTitle.Controls.Add(this.flowLayoutPanel1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitle.Location = new System.Drawing.Point(65, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(321, 28);
            this.panelTitle.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 28);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.AutoSize = true;
            this.panelTopLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelTopLeft.Controls.Add(this.panel2);
            this.panelTopLeft.Controls.Add(this.pictureBoxIcon);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Padding = new System.Windows.Forms.Padding(10, 5, 0, 1);
            this.panelTopLeft.Size = new System.Drawing.Size(65, 28);
            this.panelTopLeft.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.lbtitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(26, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 0);
            this.panel2.Size = new System.Drawing.Size(39, 22);
            this.panel2.TabIndex = 8;
            // 
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.BackColor = System.Drawing.Color.Transparent;
            this.lbtitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbtitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbtitle.Location = new System.Drawing.Point(2, 3);
            this.lbtitle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbtitle.MaximumSize = new System.Drawing.Size(0, 50);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(35, 12);
            this.lbtitle.TabIndex = 1;
            this.lbtitle.Text = "Title";
            this.lbtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxIcon.Image = global::Common.Properties.Resources.style;
            this.pictureBoxIcon.Location = new System.Drawing.Point(10, 5);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(16, 22);
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            // 
            // panelTopRight
            // 
            this.panelTopRight.BackColor = System.Drawing.Color.Transparent;
            this.panelTopRight.Controls.Add(this.menuStripMinMaxClose);
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTopRight.Location = new System.Drawing.Point(386, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(92, 28);
            this.panelTopRight.TabIndex = 6;
            // 
            // menuStripMinMaxClose
            // 
            this.menuStripMinMaxClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStripMinMaxClose.BackgroundImage")));
            this.menuStripMinMaxClose.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pictureBoxClose,
            this.pictureBoxMax,
            this.pictureBoxMin});
            this.menuStripMinMaxClose.Location = new System.Drawing.Point(0, 0);
            this.menuStripMinMaxClose.Name = "menuStripMinMaxClose";
            this.menuStripMinMaxClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStripMinMaxClose.Size = new System.Drawing.Size(92, 24);
            this.menuStripMinMaxClose.TabIndex = 7;
            this.menuStripMinMaxClose.Text = "menuStrip1";
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = global::Common.Properties.Resources.close;
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(28, 20);
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // pictureBoxMax
            // 
            this.pictureBoxMax.Image = global::Common.Properties.Resources.max;
            this.pictureBoxMax.Name = "pictureBoxMax";
            this.pictureBoxMax.Size = new System.Drawing.Size(28, 20);
            this.pictureBoxMax.Click += new System.EventHandler(this.pictureBoxMax_Click);
            // 
            // pictureBoxMin
            // 
            this.pictureBoxMin.Image = global::Common.Properties.Resources.min;
            this.pictureBoxMin.Name = "pictureBoxMin";
            this.pictureBoxMin.Size = new System.Drawing.Size(28, 20);
            this.pictureBoxMin.Click += new System.EventHandler(this.pictureBoxMin_Click);
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(64)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(480, 340);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStripMinMaxClose;
            this.Name = "frmBase";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "frmBase";
            this.panelMain.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelTopLeft.ResumeLayout(false);
            this.panelTopLeft.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelTopRight.ResumeLayout(false);
            this.panelTopRight.PerformLayout();
            this.menuStripMinMaxClose.ResumeLayout(false);
            this.menuStripMinMaxClose.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        public System.Windows.Forms.Panel panelWorkArea;
        private System.Windows.Forms.Panel panelTopLeft;
        public System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.MenuStrip menuStripMinMaxClose;
        private System.Windows.Forms.ToolStripMenuItem pictureBoxClose;
        private System.Windows.Forms.ToolStripMenuItem pictureBoxMax;
        private System.Windows.Forms.ToolStripMenuItem pictureBoxMin;
    }
}