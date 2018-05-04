namespace VehicleTransportClient
{
    partial class FormPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPerson));
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbSex = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtTelNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDuty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtWorkType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbDept = new DevComponents.DotNetBar.Controls.ComboTree();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.label11);
            this.panelWorkArea.Controls.Add(this.label10);
            this.panelWorkArea.Controls.Add(this.label9);
            this.panelWorkArea.Controls.Add(this.cmbDept);
            this.panelWorkArea.Controls.Add(this.txtWorkType);
            this.panelWorkArea.Controls.Add(this.txtCode);
            this.panelWorkArea.Controls.Add(this.txtDuty);
            this.panelWorkArea.Controls.Add(this.cmbSex);
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.txtTelNum);
            this.panelWorkArea.Controls.Add(this.txtName);
            this.panelWorkArea.Controls.Add(this.txtMemo);
            this.panelWorkArea.Controls.Add(this.label8);
            this.panelWorkArea.Controls.Add(this.label7);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Controls.Add(this.label4);
            this.panelWorkArea.Controls.Add(this.label3);
            this.panelWorkArea.Controls.Add(this.label6);
            this.panelWorkArea.Controls.Add(this.label2);
            this.panelWorkArea.Controls.Add(this.label5);
            this.panelWorkArea.Dock = System.Windows.Forms.DockStyle.None;
            this.panelWorkArea.Location = new System.Drawing.Point(0, 27);
            this.panelWorkArea.Size = new System.Drawing.Size(495, 303);
            this.panelWorkArea.TabIndex = 0;
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
            this.btnNo.Location = new System.Drawing.Point(285, 259);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 9;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(157, 259);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 8;
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
            this.txtMemo.Location = new System.Drawing.Point(87, 169);
            this.txtMemo.MaxLength = 50;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(387, 74);
            this.txtMemo.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(24, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 63;
            this.label5.Text = "备  注：";
            // 
            // balloonTip1
            // 
            this.balloonTip1.AlertAnimation = DevComponents.DotNetBar.eAlertAnimation.LeftToRight;
            this.balloonTip1.DefaultBalloonWidth = 100;
            this.balloonTip1.MinimumBalloonWidth = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(266, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 63;
            this.label2.Text = "姓  名：";
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Location = new System.Drawing.Point(329, 17);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 21);
            this.txtName.TabIndex = 1;
            // 
            // cmbSex
            // 
            this.cmbSex.DisplayMember = "Text";
            this.cmbSex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.ItemHeight = 15;
            this.cmbSex.Location = new System.Drawing.Point(87, 53);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(145, 21);
            this.cmbSex.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSex.TabIndex = 2;
            // 
            // txtTelNum
            // 
            // 
            // 
            // 
            this.txtTelNum.Border.Class = "TextBoxBorder";
            this.txtTelNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTelNum.Location = new System.Drawing.Point(87, 121);
            this.txtTelNum.MaxLength = 50;
            this.txtTelNum.Name = "txtTelNum";
            this.txtTelNum.Size = new System.Drawing.Size(145, 21);
            this.txtTelNum.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(266, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 63;
            this.label1.Text = "部  门：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(24, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 63;
            this.label3.Text = "电  话：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(266, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 63;
            this.label4.Text = "工  种：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(24, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 63;
            this.label6.Text = "性  别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(24, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 63;
            this.label7.Text = "职  务：";
            // 
            // txtDuty
            // 
            // 
            // 
            // 
            this.txtDuty.Border.Class = "TextBoxBorder";
            this.txtDuty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDuty.Location = new System.Drawing.Point(87, 89);
            this.txtDuty.MaxLength = 50;
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.Size = new System.Drawing.Size(145, 21);
            this.txtDuty.TabIndex = 4;
            // 
            // txtWorkType
            // 
            // 
            // 
            // 
            this.txtWorkType.Border.Class = "TextBoxBorder";
            this.txtWorkType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWorkType.Location = new System.Drawing.Point(329, 89);
            this.txtWorkType.MaxLength = 50;
            this.txtWorkType.Name = "txtWorkType";
            this.txtWorkType.Size = new System.Drawing.Size(145, 21);
            this.txtWorkType.TabIndex = 5;
            // 
            // cmbDept
            // 
            this.cmbDept.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cmbDept.BackgroundStyle.Class = "TextBoxBorder";
            this.cmbDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cmbDept.ButtonDropDown.Visible = true;
            this.cmbDept.DropDownHeight = 200;
            this.cmbDept.Location = new System.Drawing.Point(329, 53);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(145, 21);
            this.cmbDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbDept.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(24, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 63;
            this.label8.Text = "编  号：";
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.Location = new System.Drawing.Point(87, 17);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(145, 21);
            this.txtCode.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(238, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 67;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(480, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 68;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(480, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 69;
            this.label11.Text = "*";
            // 
            // FormPerson
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(497, 333);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormPerson";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户设置";
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
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSex;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTelNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtWorkType;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDuty;
        private DevComponents.DotNetBar.Controls.ComboTree cmbDept;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
    }
}