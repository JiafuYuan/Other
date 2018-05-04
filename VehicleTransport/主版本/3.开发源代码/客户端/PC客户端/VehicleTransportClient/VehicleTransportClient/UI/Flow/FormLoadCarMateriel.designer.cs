namespace VehicleTransportClient
{
    partial class FormLoadCarMateriel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadCarMateriel));
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbParentType = new DevComponents.DotNetBar.Controls.ComboTree();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labunit = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.panelWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.panelWorkArea.Controls.Add(this.panel1);
            this.panelWorkArea.Dock = System.Windows.Forms.DockStyle.None;
            this.panelWorkArea.Location = new System.Drawing.Point(0, 27);
            this.panelWorkArea.Size = new System.Drawing.Size(495, 230);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(336, 28);
            // 
            // balloonTip1
            // 
            this.balloonTip1.AlertAnimation = DevComponents.DotNetBar.eAlertAnimation.LeftToRight;
            this.balloonTip1.DefaultBalloonWidth = 100;
            this.balloonTip1.MinimumBalloonWidth = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCount);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbParentType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labunit);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnNo);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.txtMemo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 230);
            this.panel1.TabIndex = 0;
            // 
            // txtCount
            // 
            // 
            // 
            // 
            this.txtCount.Border.Class = "TextBoxBorder";
            this.txtCount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCount.Location = new System.Drawing.Point(316, 59);
            this.txtCount.MaxLength = 5;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 21);
            this.txtCount.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(241, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 93;
            this.label7.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(25, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 92;
            this.label2.Text = "车辆编号：";
            // 
            // txtCar
            // 
            // 
            // 
            // 
            this.txtCar.Border.Class = "TextBoxBorder";
            this.txtCar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCar.Location = new System.Drawing.Point(90, 25);
            this.txtCar.MaxLength = 50;
            this.txtCar.Name = "txtCar";
            this.txtCar.Size = new System.Drawing.Size(145, 21);
            this.txtCar.TabIndex = 91;
            this.txtCar.Click += new System.EventHandler(this.txtCar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(459, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 90;
            this.label1.Text = "*";
            // 
            // cmbParentType
            // 
            this.cmbParentType.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cmbParentType.BackgroundStyle.Class = "TextBoxBorder";
            this.cmbParentType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cmbParentType.ButtonDropDown.Visible = true;
            this.cmbParentType.DropDownHeight = 100;
            this.cmbParentType.Location = new System.Drawing.Point(90, 58);
            this.cmbParentType.Name = "cmbParentType";
            this.cmbParentType.Size = new System.Drawing.Size(145, 21);
            this.cmbParentType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbParentType.TabIndex = 89;
            this.cmbParentType.SelectedIndexChanged += new System.EventHandler(this.cmbParentType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(254, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 87;
            this.label3.Text = "物料数量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(25, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 86;
            this.label4.Text = "物料类别：";
            // 
            // labunit
            // 
            this.labunit.AutoSize = true;
            this.labunit.BackColor = System.Drawing.Color.Transparent;
            this.labunit.Location = new System.Drawing.Point(424, 63);
            this.labunit.Name = "labunit";
            this.labunit.Size = new System.Drawing.Size(0, 12);
            this.labunit.TabIndex = 88;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(241, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 85;
            this.label10.Text = "*";
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(286, 183);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 83;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(160, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 82;
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
            this.txtMemo.Location = new System.Drawing.Point(90, 95);
            this.txtMemo.MaxLength = 50;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(378, 74);
            this.txtMemo.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(25, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 84;
            this.label5.Text = "备  注：";
            // 
            // FormLoadCarMateriel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormLoadCarMateriel";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "区域设置";
            this.panelWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.BalloonTip balloonTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCar;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboTree cmbParentType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labunit;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMemo;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCount;
    }
}