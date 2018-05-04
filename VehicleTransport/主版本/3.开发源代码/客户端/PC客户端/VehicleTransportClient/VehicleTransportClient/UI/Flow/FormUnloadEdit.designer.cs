namespace VehicleTransportClient
{
    partial class FormUnloadEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnloadEdit));
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbParentType = new DevComponents.DotNetBar.Controls.ComboTree();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labunit = new System.Windows.Forms.Label();
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.panelWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.panel1);
            this.panelWorkArea.Size = new System.Drawing.Size(348, 220);
            // 
            // panelTitle
            // 
            this.panelTitle.Location = new System.Drawing.Point(83, 0);
            this.panelTitle.Size = new System.Drawing.Size(173, 28);
            // 
            // balloonTip1
            // 
            this.balloonTip1.AlertAnimation = DevComponents.DotNetBar.eAlertAnimation.LeftToRight;
            this.balloonTip1.DefaultBalloonWidth = 100;
            this.balloonTip1.MinimumBalloonWidth = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.txtCount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCar);
            this.panel1.Controls.Add(this.cmbParentType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labunit);
            this.panel1.Controls.Add(this.btnNo);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 220);
            this.panel1.TabIndex = 0;
            // 
            // txtCount
            // 
            // 
            // 
            // 
            this.txtCount.Border.Class = "TextBoxBorder";
            this.txtCount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCount.Location = new System.Drawing.Point(127, 107);
            this.txtCount.MaxLength = 5;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(99, 21);
            this.txtCount.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(277, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 100;
            this.label5.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(277, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(277, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 98;
            this.label10.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(61, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 96;
            this.label2.Text = "车辆编号：";
            // 
            // txtCar
            // 
            // 
            // 
            // 
            this.txtCar.Border.Class = "TextBoxBorder";
            this.txtCar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCar.Location = new System.Drawing.Point(126, 37);
            this.txtCar.MaxLength = 50;
            this.txtCar.Name = "txtCar";
            this.txtCar.Size = new System.Drawing.Size(145, 21);
            this.txtCar.TabIndex = 95;
            this.txtCar.Click += new System.EventHandler(this.txtCar_Click);
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
            this.cmbParentType.Location = new System.Drawing.Point(126, 71);
            this.cmbParentType.Name = "cmbParentType";
            this.cmbParentType.Size = new System.Drawing.Size(145, 21);
            this.cmbParentType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbParentType.TabIndex = 94;
            this.cmbParentType.SelectedIndexChanged += new System.EventHandler(this.cmbParentType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(62, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 92;
            this.label3.Text = "物料数量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(61, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 91;
            this.label4.Text = "物料类别：";
            // 
            // labunit
            // 
            this.labunit.AutoSize = true;
            this.labunit.BackColor = System.Drawing.Color.Transparent;
            this.labunit.Location = new System.Drawing.Point(242, 109);
            this.labunit.Name = "labunit";
            this.labunit.Size = new System.Drawing.Size(29, 12);
            this.labunit.TabIndex = 93;
            this.labunit.Text = "(吨)";
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(193, 161);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 90;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(65, 161);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 89;
            this.btnOK.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormUnloadEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.FormTitle = "卸车信息";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormUnloadEdit";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "卸车信息";
            this.panelWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.BalloonTip balloonTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCar;
        private DevComponents.DotNetBar.Controls.ComboTree cmbParentType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labunit;
        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCount;
    }
}