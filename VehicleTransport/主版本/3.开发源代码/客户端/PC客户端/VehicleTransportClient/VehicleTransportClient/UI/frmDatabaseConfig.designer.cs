namespace VehicleTransportClient.UI
{
    partial class frmDatabaseConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabaseConfig));
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtdbpwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtuserno = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtdb = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtserver = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.txtdbpwd);
            this.panelWorkArea.Controls.Add(this.txtuserno);
            this.panelWorkArea.Controls.Add(this.txtdb);
            this.panelWorkArea.Controls.Add(this.txtserver);
            this.panelWorkArea.Controls.Add(this.pictureBox3);
            this.panelWorkArea.Controls.Add(this.label8);
            this.panelWorkArea.Controls.Add(this.label7);
            this.panelWorkArea.Controls.Add(this.label6);
            this.panelWorkArea.Controls.Add(this.label5);
            this.panelWorkArea.Size = new System.Drawing.Size(407, 248);
            // 
            // panelTitle
            // 
            this.panelTitle.Location = new System.Drawing.Point(95, 0);
            this.panelTitle.Size = new System.Drawing.Size(220, 28);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.Location = new System.Drawing.Point(270, 183);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 5;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(120, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtdbpwd
            // 
            // 
            // 
            // 
            this.txtdbpwd.Border.Class = "TextBoxBorder";
            this.txtdbpwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtdbpwd.Location = new System.Drawing.Point(195, 133);
            this.txtdbpwd.MaxLength = 30;
            this.txtdbpwd.Name = "txtdbpwd";
            this.txtdbpwd.Size = new System.Drawing.Size(150, 21);
            this.txtdbpwd.TabIndex = 3;
            // 
            // txtuserno
            // 
            // 
            // 
            // 
            this.txtuserno.Border.Class = "TextBoxBorder";
            this.txtuserno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtuserno.Location = new System.Drawing.Point(195, 101);
            this.txtuserno.MaxLength = 30;
            this.txtuserno.Name = "txtuserno";
            this.txtuserno.Size = new System.Drawing.Size(150, 21);
            this.txtuserno.TabIndex = 2;
            // 
            // txtdb
            // 
            // 
            // 
            // 
            this.txtdb.Border.Class = "TextBoxBorder";
            this.txtdb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtdb.Location = new System.Drawing.Point(195, 69);
            this.txtdb.MaxLength = 30;
            this.txtdb.Name = "txtdb";
            this.txtdb.Size = new System.Drawing.Size(150, 21);
            this.txtdb.TabIndex = 1;
            // 
            // txtserver
            // 
            // 
            // 
            // 
            this.txtserver.Border.Class = "TextBoxBorder";
            this.txtserver.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtserver.Location = new System.Drawing.Point(195, 37);
            this.txtserver.MaxLength = 30;
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(150, 21);
            this.txtserver.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::VehicleTransportClient.Properties.Resources.BigIconSet;
            this.pictureBox3.Location = new System.Drawing.Point(28, 53);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 58;
            this.pictureBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(112, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "服务器名称：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(112, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 55;
            this.label7.Text = "数据库名称：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(124, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "用 户 名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(124, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 57;
            this.label5.Text = "密    码：";
            // 
            // frmDatabaseConfig
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 278);
            this.FormTitle = "数据库设置";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDatabaseConfig";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDatabaseConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmDatabaseConfig_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdbpwd;
        private DevComponents.DotNetBar.Controls.TextBoxX txtuserno;
        private DevComponents.DotNetBar.Controls.TextBoxX txtdb;
        private DevComponents.DotNetBar.Controls.TextBoxX txtserver;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}