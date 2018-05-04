namespace VehicleTransportClient.UI
{
    partial class frmServerConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServerConfig));
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtPort = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIP = new DevComponents.Editors.IpAddressInput();
            this.txtServerIP = new DevComponents.Editors.IpAddressInput();
            this.panelWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerIP)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.txtServerIP);
            this.panelWorkArea.Controls.Add(this.txtIP);
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.txtPort);
            this.panelWorkArea.Controls.Add(this.pictureBox3);
            this.panelWorkArea.Controls.Add(this.label8);
            this.panelWorkArea.Controls.Add(this.label7);
            this.panelWorkArea.Controls.Add(this.label6);
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
            this.btnNo.Location = new System.Drawing.Point(282, 183);
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
            this.btnOK.Location = new System.Drawing.Point(132, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPort
            // 
            // 
            // 
            // 
            this.txtPort.Border.Class = "TextBoxBorder";
            this.txtPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPort.Location = new System.Drawing.Point(195, 77);
            this.txtPort.MaxLength = 30;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(145, 21);
            this.txtPort.TabIndex = 1;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
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
            this.label8.Location = new System.Drawing.Point(137, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "本机IP：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(125, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 55;
            this.label7.Text = "服务器IP：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(137, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "端口号：";
            // 
            // txtIP
            // 
            this.txtIP.AutoOverwrite = true;
            // 
            // 
            // 
            this.txtIP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIP.ButtonCustom2.Enabled = false;
            this.txtIP.ButtonFreeText.Enabled = false;
            this.txtIP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtIP.ButtonFreeText.Visible = true;
            this.txtIP.Location = new System.Drawing.Point(195, 39);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(145, 21);
            this.txtIP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtIP.TabIndex = 59;
            // 
            // txtServerIP
            // 
            this.txtServerIP.AutoOverwrite = true;
            // 
            // 
            // 
            this.txtServerIP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtServerIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServerIP.ButtonCustom2.Enabled = false;
            this.txtServerIP.ButtonFreeText.Enabled = false;
            this.txtServerIP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtServerIP.ButtonFreeText.Visible = true;
            this.txtServerIP.Location = new System.Drawing.Point(195, 116);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(145, 21);
            this.txtServerIP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtServerIP.TabIndex = 60;
            // 
            // frmServerConfig
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 278);
            this.FormTitle = "服务器设置";
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmServerConfig";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDatabaseConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmDatabaseConfig_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServerIP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPort;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DevComponents.Editors.IpAddressInput txtServerIP;
        private DevComponents.Editors.IpAddressInput txtIP;
    }
}