namespace VehicleTransportClient
{
    partial class FormAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddress));
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbArea = new DevComponents.DotNetBar.Controls.ComboTree();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLocalizerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDirectionLocalizer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDirectionLocalizer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbLocation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblHID = new System.Windows.Forms.Label();
            this.lblRedChildHID = new System.Windows.Forms.Label();
            this.txtChildHID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblChildHID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chbox = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panelWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.chbox);
            this.panelWorkArea.Controls.Add(this.label11);
            this.panelWorkArea.Controls.Add(this.label6);
            this.panelWorkArea.Controls.Add(this.txtCode);
            this.panelWorkArea.Controls.Add(this.label9);
            this.panelWorkArea.Controls.Add(this.lblRedChildHID);
            this.panelWorkArea.Controls.Add(this.txtChildHID);
            this.panelWorkArea.Controls.Add(this.lblChildHID);
            this.panelWorkArea.Controls.Add(this.label8);
            this.panelWorkArea.Controls.Add(this.txtHid);
            this.panelWorkArea.Controls.Add(this.lblHID);
            this.panelWorkArea.Controls.Add(this.cmbLocation);
            this.panelWorkArea.Controls.Add(this.txtDirectionLocalizer);
            this.panelWorkArea.Controls.Add(this.label3);
            this.panelWorkArea.Controls.Add(this.lblDirectionLocalizer);
            this.panelWorkArea.Controls.Add(this.txtLocalizerName);
            this.panelWorkArea.Controls.Add(this.label10);
            this.panelWorkArea.Controls.Add(this.cmbArea);
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.txtMemo);
            this.panelWorkArea.Controls.Add(this.label7);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Controls.Add(this.label4);
            this.panelWorkArea.Controls.Add(this.label5);
            this.panelWorkArea.Dock = System.Windows.Forms.DockStyle.None;
            this.panelWorkArea.Location = new System.Drawing.Point(0, 27);
            this.panelWorkArea.Size = new System.Drawing.Size(495, 331);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(338, 28);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(285, 290);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 10;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(157, 290);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtMemo
            // 
            // 
            // 
            // 
            this.txtMemo.Border.Class = "TextBoxBorder";
            this.txtMemo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMemo.Location = new System.Drawing.Point(87, 193);
            this.txtMemo.MaxLength = 50;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(387, 81);
            this.txtMemo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(24, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 63;
            this.label5.Text = "备    注：";
            // 
            // balloonTip1
            // 
            this.balloonTip1.AlertAnimation = DevComponents.DotNetBar.eAlertAnimation.LeftToRight;
            this.balloonTip1.DefaultBalloonWidth = 100;
            this.balloonTip1.MinimumBalloonWidth = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(261, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 63;
            this.label1.Text = "所属区域：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(261, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 63;
            this.label4.Text = "位    置：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(24, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 63;
            this.label7.Text = "基站名称：";
            // 
            // cmbArea
            // 
            this.cmbArea.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cmbArea.BackgroundStyle.Class = "TextBoxBorder";
            this.cmbArea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cmbArea.ButtonDropDown.Visible = true;
            this.cmbArea.DropDownHeight = 200;
            this.cmbArea.Location = new System.Drawing.Point(326, 27);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(145, 21);
            this.cmbArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbArea.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(238, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 68;
            this.label10.Text = "*";
            // 
            // txtLocalizerName
            // 
            // 
            // 
            // 
            this.txtLocalizerName.Border.Class = "TextBoxBorder";
            this.txtLocalizerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLocalizerName.Location = new System.Drawing.Point(87, 66);
            this.txtLocalizerName.MaxLength = 50;
            this.txtLocalizerName.Name = "txtLocalizerName";
            this.txtLocalizerName.Size = new System.Drawing.Size(145, 21);
            this.txtLocalizerName.TabIndex = 2;
            // 
            // lblDirectionLocalizer
            // 
            this.lblDirectionLocalizer.AutoSize = true;
            this.lblDirectionLocalizer.BackColor = System.Drawing.Color.Transparent;
            this.lblDirectionLocalizer.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDirectionLocalizer.Location = new System.Drawing.Point(261, 149);
            this.lblDirectionLocalizer.Name = "lblDirectionLocalizer";
            this.lblDirectionLocalizer.Size = new System.Drawing.Size(65, 12);
            this.lblDirectionLocalizer.TabIndex = 73;
            this.lblDirectionLocalizer.Text = "反向基站：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(477, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 74;
            this.label3.Text = "*";
            // 
            // txtDirectionLocalizer
            // 
            // 
            // 
            // 
            this.txtDirectionLocalizer.Border.Class = "TextBoxBorder";
            this.txtDirectionLocalizer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDirectionLocalizer.Location = new System.Drawing.Point(324, 147);
            this.txtDirectionLocalizer.MaxLength = 50;
            this.txtDirectionLocalizer.Name = "txtDirectionLocalizer";
            this.txtDirectionLocalizer.Size = new System.Drawing.Size(145, 21);
            this.txtDirectionLocalizer.TabIndex = 7;
            this.txtDirectionLocalizer.Click += new System.EventHandler(this.txtDirectionLocalizer_Click);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DisplayMember = "Text";
            this.cmbLocation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.ItemHeight = 15;
            this.cmbLocation.Items.AddRange(new object[] {
            this.comboItem2,
            this.comboItem1});
            this.cmbLocation.Location = new System.Drawing.Point(326, 68);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(145, 21);
            this.cmbLocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbLocation.TabIndex = 3;
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "井下";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "井上";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(238, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 78;
            this.label8.Text = "*";
            // 
            // txtHid
            // 
            // 
            // 
            // 
            this.txtHid.Border.Class = "TextBoxBorder";
            this.txtHid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHid.Location = new System.Drawing.Point(87, 107);
            this.txtHid.MaxLength = 8;
            this.txtHid.Multiline = true;
            this.txtHid.Name = "txtHid";
            this.txtHid.Size = new System.Drawing.Size(145, 21);
            this.txtHid.TabIndex = 4;
            this.txtHid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHid_KeyPress);
            // 
            // lblHID
            // 
            this.lblHID.AutoSize = true;
            this.lblHID.BackColor = System.Drawing.Color.Transparent;
            this.lblHID.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblHID.Location = new System.Drawing.Point(24, 109);
            this.lblHID.Name = "lblHID";
            this.lblHID.Size = new System.Drawing.Size(65, 12);
            this.lblHID.TabIndex = 77;
            this.lblHID.Text = "主站 HID：";
            // 
            // lblRedChildHID
            // 
            this.lblRedChildHID.AutoSize = true;
            this.lblRedChildHID.BackColor = System.Drawing.Color.Transparent;
            this.lblRedChildHID.ForeColor = System.Drawing.Color.Red;
            this.lblRedChildHID.Location = new System.Drawing.Point(238, 151);
            this.lblRedChildHID.Name = "lblRedChildHID";
            this.lblRedChildHID.Size = new System.Drawing.Size(11, 12);
            this.lblRedChildHID.TabIndex = 81;
            this.lblRedChildHID.Text = "*";
            // 
            // txtChildHID
            // 
            // 
            // 
            // 
            this.txtChildHID.Border.Class = "TextBoxBorder";
            this.txtChildHID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtChildHID.Location = new System.Drawing.Point(87, 147);
            this.txtChildHID.MaxLength = 8;
            this.txtChildHID.Multiline = true;
            this.txtChildHID.Name = "txtChildHID";
            this.txtChildHID.Size = new System.Drawing.Size(145, 21);
            this.txtChildHID.TabIndex = 6;
            this.txtChildHID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChildHID_KeyPress);
            // 
            // lblChildHID
            // 
            this.lblChildHID.AutoSize = true;
            this.lblChildHID.BackColor = System.Drawing.Color.Transparent;
            this.lblChildHID.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblChildHID.Location = new System.Drawing.Point(24, 154);
            this.lblChildHID.Name = "lblChildHID";
            this.lblChildHID.Size = new System.Drawing.Size(65, 12);
            this.lblChildHID.TabIndex = 80;
            this.lblChildHID.Text = "子站 HID：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(238, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 84;
            this.label6.Text = "*";
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.Location = new System.Drawing.Point(87, 27);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(145, 21);
            this.txtCode.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(24, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 83;
            this.label9.Text = "基站编号：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(477, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 85;
            this.label11.Text = "*";
            // 
            // chbox
            // 
            this.chbox.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbox.BackgroundStyle.Class = "";
            this.chbox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbox.Location = new System.Drawing.Point(260, 105);
            this.chbox.Name = "chbox";
            this.chbox.Size = new System.Drawing.Size(100, 23);
            this.chbox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbox.TabIndex = 5;
            this.chbox.Text = "方向基站";
            this.chbox.CheckedChanged += new System.EventHandler(this.chbox_CheckedChanged);
            // 
            // FormAddress
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(497, 360);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormAddress";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "地点设置";
            this.Load += new System.EventHandler(this.FormAddress_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMemo;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.BalloonTip balloonTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.ComboTree cmbArea;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDirectionLocalizer;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLocalizerName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDirectionLocalizer;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbLocation;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private System.Windows.Forms.Label lblRedChildHID;
        private DevComponents.DotNetBar.Controls.TextBoxX txtChildHID;
        private System.Windows.Forms.Label lblChildHID;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHid;
        private System.Windows.Forms.Label lblHID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCode;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbox;
    }
}