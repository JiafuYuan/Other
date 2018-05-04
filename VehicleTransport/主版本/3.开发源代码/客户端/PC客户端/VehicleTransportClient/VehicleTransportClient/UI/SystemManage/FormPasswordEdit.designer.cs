namespace VehicleTransportClient
{
    partial class FormPasswordEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPasswordEdit));
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOldPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewPasswordCopy = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.panelWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.label2);
            this.panelWorkArea.Controls.Add(this.txtUserName);
            this.panelWorkArea.Controls.Add(this.txtOldPassword);
            this.panelWorkArea.Controls.Add(this.label4);
            this.panelWorkArea.Controls.Add(this.label9);
            this.panelWorkArea.Controls.Add(this.txtNewPasswordCopy);
            this.panelWorkArea.Controls.Add(this.txtNewPassword);
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.label3);
            this.panelWorkArea.Controls.Add(this.label8);
            this.panelWorkArea.Controls.Add(this.label7);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Dock = System.Windows.Forms.DockStyle.None;
            this.panelWorkArea.Location = new System.Drawing.Point(0, 27);
            this.panelWorkArea.Size = new System.Drawing.Size(311, 217);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(154, 28);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(202, 171);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(74, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.label1.Location = new System.Drawing.Point(39, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 63;
            this.label1.Text = "用 户 名：";
            this.label1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(40, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 63;
            this.label7.Text = "旧 密 码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(39, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 63;
            this.label8.Text = "新 密 码：";
            // 
            // txtNewPassword
            // 
            // 
            // 
            // 
            this.txtNewPassword.Border.Class = "TextBoxBorder";
            this.txtNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNewPassword.Location = new System.Drawing.Point(108, 82);
            this.txtNewPassword.MaxLength = 50;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(145, 21);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(263, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 67;
            this.label9.Text = "*";
            // 
            // txtOldPassword
            // 
            // 
            // 
            // 
            this.txtOldPassword.Border.Class = "TextBoxBorder";
            this.txtOldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOldPassword.Location = new System.Drawing.Point(109, 35);
            this.txtOldPassword.MaxLength = 50;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(145, 21);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.Location = new System.Drawing.Point(108, 36);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(145, 21);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(263, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(39, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 63;
            this.label3.Text = "密码确认：";
            // 
            // txtNewPasswordCopy
            // 
            // 
            // 
            // 
            this.txtNewPasswordCopy.Border.Class = "TextBoxBorder";
            this.txtNewPasswordCopy.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNewPasswordCopy.Location = new System.Drawing.Point(108, 126);
            this.txtNewPasswordCopy.MaxLength = 50;
            this.txtNewPasswordCopy.Name = "txtNewPasswordCopy";
            this.txtNewPasswordCopy.Size = new System.Drawing.Size(145, 21);
            this.txtNewPasswordCopy.TabIndex = 2;
            this.txtNewPasswordCopy.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(263, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 67;
            this.label4.Text = "*";
            // 
            // FormPasswordEdit
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(313, 246);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormPasswordEdit";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "密码修改";
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.BalloonTip balloonTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNewPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOldPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNewPasswordCopy;
        private System.Windows.Forms.Label label3;
    }
}