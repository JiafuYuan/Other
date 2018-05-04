namespace VehicleTransportClient
{
    partial class FormRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRule));
            this.buttonEx2 = new Common.ButtonEx();
            this.btnOK = new Common.ButtonEx();
            this.txtMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.label10);
            this.panelWorkArea.Controls.Add(this.buttonEx2);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.txtMemo);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Controls.Add(this.txtName);
            this.panelWorkArea.Controls.Add(this.label2);
            this.panelWorkArea.Size = new System.Drawing.Size(411, 212);
            this.panelWorkArea.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(254, 28);
            // 
            // buttonEx2
            // 
            this.buttonEx2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEx2.BackgroundImage")));
            this.buttonEx2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEx2.BorderColor = System.Drawing.Color.Empty;
            this.buttonEx2.ButtonStyle = Common.ButtonStyle.Custom1;
            this.buttonEx2.EnabledEx = false;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx2.Location = new System.Drawing.Point(264, 163);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Picture_MouseDown")));
            this.buttonEx2.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Picture_MouseMove")));
            this.buttonEx2.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Picture_Normal")));
            this.buttonEx2.Size = new System.Drawing.Size(75, 23);
            this.buttonEx2.TabIndex = 3;
            this.buttonEx2.Text = "取消";
            this.buttonEx2.UseVisualStyleBackColor = true;
            this.buttonEx2.Click += new System.EventHandler(this.buttonEx2_Click);
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
            this.btnOK.Location = new System.Drawing.Point(104, 163);
            this.btnOK.Name = "btnOK";
            this.btnOK.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnOK.Picture_MouseDown")));
            this.btnOK.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnOK.Picture_MouseMove")));
            this.btnOK.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnOK.Picture_Normal")));
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtMemo
            // 
            // 
            // 
            // 
            this.txtMemo.Border.Class = "TextBoxBorder";
            this.txtMemo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMemo.Location = new System.Drawing.Point(104, 67);
            this.txtMemo.MaxLength = 20;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(235, 77);
            this.txtMemo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(24, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = "备    注：";
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.Location = new System.Drawing.Point(104, 31);
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
            this.label2.Location = new System.Drawing.Point(24, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 77;
            this.label2.Text = "角色名称：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(257, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 82;
            this.label10.Text = "*";
            // 
            // FormRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 242);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑 ";
            this.Load += new System.EventHandler(this.FormRule_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Common.ButtonEx buttonEx2;
        private Common.ButtonEx btnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMemo;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
    }
}