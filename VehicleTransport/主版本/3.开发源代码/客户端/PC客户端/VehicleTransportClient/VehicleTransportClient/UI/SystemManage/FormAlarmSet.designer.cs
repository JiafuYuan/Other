namespace VehicleTransportClient
{
    partial class FormAlarmSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlarmSet));
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTrue = new System.Windows.Forms.CheckBox();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.txtUnLoadVehicle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPDAOffLine = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUnusedVehicleTime = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtBackVehicle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtLoadVehicle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCom = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panelWorkArea.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.groupPanel2);
            this.panelWorkArea.Controls.Add(this.groupPanel1);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Dock = System.Windows.Forms.DockStyle.None;
            this.panelWorkArea.Location = new System.Drawing.Point(0, 27);
            this.panelWorkArea.Size = new System.Drawing.Size(645, 248);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(488, 28);
            // 
            // balloonTip1
            // 
            this.balloonTip1.AlertAnimation = DevComponents.DotNetBar.eAlertAnimation.LeftToRight;
            this.balloonTip1.DefaultBalloonWidth = 100;
            this.balloonTip1.MinimumBalloonWidth = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(32, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 117;
            this.label9.Text = "定位客户端：";
            // 
            // cbTrue
            // 
            this.cbTrue.AutoSize = true;
            this.cbTrue.BackColor = System.Drawing.Color.Transparent;
            this.cbTrue.Location = new System.Drawing.Point(115, 37);
            this.cbTrue.Name = "cbTrue";
            this.cbTrue.Size = new System.Drawing.Size(60, 16);
            this.cbTrue.TabIndex = 0;
            this.cbTrue.Text = "已安装";
            this.cbTrue.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(188, 199);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(396, 199);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.lblTip);
            this.groupPanel1.Controls.Add(this.txtUnLoadVehicle);
            this.groupPanel1.Controls.Add(this.txtPDAOffLine);
            this.groupPanel1.Controls.Add(this.txtUnusedVehicleTime);
            this.groupPanel1.Controls.Add(this.txtBackVehicle);
            this.groupPanel1.Controls.Add(this.txtLoadVehicle);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.lblCom);
            this.groupPanel1.Location = new System.Drawing.Point(33, 33);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(587, 146);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.BottomLeft;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 118;
            this.groupPanel1.Text = "告警设置";
            this.groupPanel1.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(502, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 127;
            this.label8.Text = "(小时)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(368, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 126;
            this.label6.Text = "(小时)";
            this.label6.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(221, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 128;
            this.label4.Text = "(小时)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(502, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 130;
            this.label2.Text = "(小时)";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.BackColor = System.Drawing.Color.Transparent;
            this.lblTip.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTip.Location = new System.Drawing.Point(220, 34);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(41, 12);
            this.lblTip.TabIndex = 129;
            this.lblTip.Text = "(小时)";
            // 
            // txtUnLoadVehicle
            // 
            // 
            // 
            // 
            this.txtUnLoadVehicle.Border.Class = "TextBoxBorder";
            this.txtUnLoadVehicle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUnLoadVehicle.Location = new System.Drawing.Point(389, 31);
            this.txtUnLoadVehicle.MaxLength = 3;
            this.txtUnLoadVehicle.Name = "txtUnLoadVehicle";
            this.txtUnLoadVehicle.Size = new System.Drawing.Size(107, 21);
            this.txtUnLoadVehicle.TabIndex = 1;
            this.txtUnLoadVehicle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnLoadVehicle_KeyPress);
            // 
            // txtPDAOffLine
            // 
            // 
            // 
            // 
            this.txtPDAOffLine.Border.Class = "TextBoxBorder";
            this.txtPDAOffLine.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPDAOffLine.Location = new System.Drawing.Point(255, 3);
            this.txtPDAOffLine.MaxLength = 3;
            this.txtPDAOffLine.Name = "txtPDAOffLine";
            this.txtPDAOffLine.Size = new System.Drawing.Size(107, 21);
            this.txtPDAOffLine.TabIndex = 4;
            this.txtPDAOffLine.Visible = false;
            this.txtPDAOffLine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPDAOffLine_KeyPress);
            // 
            // txtUnusedVehicleTime
            // 
            // 
            // 
            // 
            this.txtUnusedVehicleTime.Border.Class = "TextBoxBorder";
            this.txtUnusedVehicleTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUnusedVehicleTime.Location = new System.Drawing.Point(107, 72);
            this.txtUnusedVehicleTime.MaxLength = 3;
            this.txtUnusedVehicleTime.Name = "txtUnusedVehicleTime";
            this.txtUnusedVehicleTime.Size = new System.Drawing.Size(107, 21);
            this.txtUnusedVehicleTime.TabIndex = 3;
            this.txtUnusedVehicleTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnusedVehicleTime_KeyPress);
            // 
            // txtBackVehicle
            // 
            // 
            // 
            // 
            this.txtBackVehicle.Border.Class = "TextBoxBorder";
            this.txtBackVehicle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBackVehicle.Location = new System.Drawing.Point(389, 71);
            this.txtBackVehicle.MaxLength = 3;
            this.txtBackVehicle.Name = "txtBackVehicle";
            this.txtBackVehicle.Size = new System.Drawing.Size(107, 21);
            this.txtBackVehicle.TabIndex = 2;
            this.txtBackVehicle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBackVehicle_KeyPress);
            // 
            // txtLoadVehicle
            // 
            // 
            // 
            // 
            this.txtLoadVehicle.Border.Class = "TextBoxBorder";
            this.txtLoadVehicle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLoadVehicle.Location = new System.Drawing.Point(107, 31);
            this.txtLoadVehicle.MaxLength = 3;
            this.txtLoadVehicle.Name = "txtLoadVehicle";
            this.txtLoadVehicle.Size = new System.Drawing.Size(107, 21);
            this.txtLoadVehicle.TabIndex = 0;
            this.txtLoadVehicle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLoadVehicle_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(298, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 121;
            this.label7.Text = "卸车超时时长：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(164, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 123;
            this.label5.Text = "PDA 离线时长：";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 124;
            this.label3.Text = "闲置超时时长：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(298, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 122;
            this.label1.Text = "还车超时时长：";
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.BackColor = System.Drawing.Color.Transparent;
            this.lblCom.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCom.Location = new System.Drawing.Point(20, 35);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(89, 12);
            this.lblCom.TabIndex = 12;
            this.lblCom.Text = "装车超时时长：";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.label9);
            this.groupPanel2.Controls.Add(this.cbTrue);
            this.groupPanel2.Location = new System.Drawing.Point(442, 313);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(175, 15);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 119;
            this.groupPanel2.Text = "其它设置";
            this.groupPanel2.Visible = false;
            // 
            // FormAlarmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 277);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormAlarmSet";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "告警设置";
            this.panelWorkArea.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.BalloonTip balloonTip1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbTrue;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTip;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUnLoadVehicle;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPDAOffLine;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUnusedVehicleTime;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBackVehicle;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLoadVehicle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCom;
    }
}