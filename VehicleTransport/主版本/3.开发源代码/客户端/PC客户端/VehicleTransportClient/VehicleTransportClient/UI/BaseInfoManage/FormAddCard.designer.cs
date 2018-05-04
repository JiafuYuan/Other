namespace VehicleTransportClient
{
    partial class FormAddCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddCard));
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStartNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOverNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.txtType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTip = new DevComponents.DotNetBar.LabelX();
            this.panelWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.lblTip);
            this.panelWorkArea.Controls.Add(this.txtType);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Controls.Add(this.label2);
            this.panelWorkArea.Controls.Add(this.txtOverNum);
            this.panelWorkArea.Controls.Add(this.label9);
            this.panelWorkArea.Controls.Add(this.txtStartNum);
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.label8);
            this.panelWorkArea.Controls.Add(this.label7);
            this.panelWorkArea.Dock = System.Windows.Forms.DockStyle.None;
            this.panelWorkArea.Location = new System.Drawing.Point(0, 27);
            this.panelWorkArea.Size = new System.Drawing.Size(288, 234);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(131, 28);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(168, 183);
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
            this.btnOK.Location = new System.Drawing.Point(29, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "发卡";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // balloonTip1
            // 
            this.balloonTip1.AlertAnimation = DevComponents.DotNetBar.eAlertAnimation.LeftToRight;
            this.balloonTip1.DefaultBalloonWidth = 100;
            this.balloonTip1.MinimumBalloonWidth = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(26, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 63;
            this.label7.Text = "截止卡号：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(27, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 63;
            this.label8.Text = "起始卡号：";
            // 
            // txtStartNum
            // 
            // 
            // 
            // 
            this.txtStartNum.Border.Class = "TextBoxBorder";
            this.txtStartNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartNum.Location = new System.Drawing.Point(98, 85);
            this.txtStartNum.MaxLength = 8;
            this.txtStartNum.Name = "txtStartNum";
            this.txtStartNum.Size = new System.Drawing.Size(145, 21);
            this.txtStartNum.TabIndex = 1;
            this.txtStartNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartNum_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(249, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 67;
            this.label9.Text = "*";
            // 
            // txtOverNum
            // 
            // 
            // 
            // 
            this.txtOverNum.Border.Class = "TextBoxBorder";
            this.txtOverNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOverNum.Location = new System.Drawing.Point(98, 133);
            this.txtOverNum.MaxLength = 8;
            this.txtOverNum.Name = "txtOverNum";
            this.txtOverNum.Size = new System.Drawing.Size(145, 21);
            this.txtOverNum.TabIndex = 2;
            this.txtOverNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOverNum_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(249, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 76;
            this.label2.Text = "*";
            // 
            // txtType
            // 
            // 
            // 
            // 
            this.txtType.Border.Class = "TextBoxBorder";
            this.txtType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtType.Location = new System.Drawing.Point(98, 37);
            this.txtType.MaxLength = 50;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(145, 21);
            this.txtType.TabIndex = 0;
            this.txtType.Click += new System.EventHandler(this.txtType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = "车辆类型：";
            // 
            // lblTip
            // 
            this.lblTip.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTip.BackgroundStyle.Class = "";
            this.lblTip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTip.Location = new System.Drawing.Point(26, 208);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(259, 23);
            this.lblTip.TabIndex = 79;
            // 
            // FormAddCard
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(290, 263);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormAddCard";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "批量发卡";
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.BalloonTip balloonTip1;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStartNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOverNum;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtType;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.LabelX lblTip;
    }
}