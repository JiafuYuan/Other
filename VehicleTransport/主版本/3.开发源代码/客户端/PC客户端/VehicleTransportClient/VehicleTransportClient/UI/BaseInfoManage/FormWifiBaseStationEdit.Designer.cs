namespace VehicleTransportClient
{
    partial class FormWifiBaseStationEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWifiBaseStationEdit));
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMac = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOK = new Common.ButtonEx();
            this.btnCancle = new Common.ButtonEx();
            this.cmbBS = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIP = new DevComponents.Editors.IpAddressInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelWorkArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.labelX1);
            this.panelWorkArea.Controls.Add(this.txtIP);
            this.panelWorkArea.Controls.Add(this.label7);
            this.panelWorkArea.Controls.Add(this.label6);
            this.panelWorkArea.Controls.Add(this.label10);
            this.panelWorkArea.Controls.Add(this.cmbBS);
            this.panelWorkArea.Controls.Add(this.btnCancle);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.txtMemo);
            this.panelWorkArea.Controls.Add(this.txtMac);
            this.panelWorkArea.Controls.Add(this.label5);
            this.panelWorkArea.Controls.Add(this.label4);
            this.panelWorkArea.Controls.Add(this.label3);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Controls.Add(this.txtName);
            this.panelWorkArea.Controls.Add(this.label2);
            this.panelWorkArea.Size = new System.Drawing.Size(523, 272);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(366, 28);
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Location = new System.Drawing.Point(100, 31);
            this.txtName.MaxLength = 10;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 21);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 65;
            this.label2.Text = "基站名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(20, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 66;
            this.label1.Text = "  IP地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(268, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 68;
            this.label3.Text = "定位基站：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(268, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 69;
            this.label4.Text = "MAC 地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(20, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 70;
            this.label5.Text = "备    注：";
            // 
            // txtMac
            // 
            // 
            // 
            // 
            this.txtMac.Border.Class = "TextBoxBorder";
            this.txtMac.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMac.Location = new System.Drawing.Point(348, 31);
            this.txtMac.MaxLength = 12;
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(145, 21);
            this.txtMac.TabIndex = 1;
            // 
            // txtMemo
            // 
            // 
            // 
            // 
            this.txtMemo.Border.Class = "TextBoxBorder";
            this.txtMemo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMemo.Location = new System.Drawing.Point(100, 123);
            this.txtMemo.MaxLength = 30;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(393, 87);
            this.txtMemo.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.BorderColor = System.Drawing.Color.Empty;
            this.btnOK.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnOK.EnabledEx = false;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(170, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnOK.Picture_MouseDown")));
            this.btnOK.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnOK.Picture_MouseMove")));
            this.btnOK.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnOK.Picture_Normal")));
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancle.BackgroundImage")));
            this.btnCancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancle.BorderColor = System.Drawing.Color.Empty;
            this.btnCancle.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnCancle.EnabledEx = false;
            this.btnCancle.FlatAppearance.BorderSize = 0;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Location = new System.Drawing.Point(351, 229);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnCancle.Picture_MouseDown")));
            this.btnCancle.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnCancle.Picture_MouseMove")));
            this.btnCancle.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnCancle.Picture_Normal")));
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 6;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // cmbBS
            // 
            this.cmbBS.DisplayMember = "Text";
            this.cmbBS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBS.FormattingEnabled = true;
            this.cmbBS.ItemHeight = 15;
            this.cmbBS.Location = new System.Drawing.Point(348, 78);
            this.cmbBS.Name = "cmbBS";
            this.cmbBS.Size = new System.Drawing.Size(145, 21);
            this.cmbBS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbBS.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(251, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 71;
            this.label10.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(251, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 72;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(499, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 73;
            this.label7.Text = "*";
            // 
            // txtIP
            // 
            this.txtIP.AutoOverwrite = true;
            this.txtIP.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.txtIP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIP.ButtonCustom2.Enabled = false;
            this.txtIP.ButtonFreeText.Enabled = false;
            this.txtIP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtIP.Location = new System.Drawing.Point(100, 78);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(145, 21);
            this.txtIP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtIP.TabIndex = 2;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(348, 53);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(167, 23);
            this.labelX1.TabIndex = 74;
            this.labelX1.Text = "Mac地址格式：8C7B9D435089";
            // 
            // FormWifiBaseStationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 302);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormWifiBaseStationEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormWifiBaseStationEdit";
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Common.ButtonEx btnCancle;
        private Common.ButtonEx btnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMemo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbBS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private DevComponents.Editors.IpAddressInput txtIP;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}