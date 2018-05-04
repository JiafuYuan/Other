namespace VehicleTransportClient.UI
{
    partial class FormUnCheckReason
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnCheckReason));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncancle = new Common.ButtonEx();
            this.btnok = new Common.ButtonEx();
            this.txtreason = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.panelWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.panel1);
            this.panelWorkArea.Size = new System.Drawing.Size(428, 270);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(271, 28);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btncancle);
            this.panel1.Controls.Add(this.btnok);
            this.panel1.Controls.Add(this.txtreason);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 270);
            this.panel1.TabIndex = 0;
            // 
            // btncancle
            // 
            this.btncancle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncancle.BackgroundImage")));
            this.btncancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncancle.BorderColor = System.Drawing.Color.Empty;
            this.btncancle.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btncancle.EnabledEx = false;
            this.btncancle.FlatAppearance.BorderSize = 0;
            this.btncancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancle.Location = new System.Drawing.Point(280, 202);
            this.btncancle.Name = "btncancle";
            this.btncancle.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btncancle.Picture_MouseDown")));
            this.btncancle.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btncancle.Picture_MouseMove")));
            this.btncancle.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btncancle.Picture_Normal")));
            this.btncancle.Size = new System.Drawing.Size(75, 23);
            this.btncancle.TabIndex = 3;
            this.btncancle.Text = "取消";
            this.btncancle.UseVisualStyleBackColor = true;
            this.btncancle.Click += new System.EventHandler(this.btncancle_Click);
            // 
            // btnok
            // 
            this.btnok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnok.BackgroundImage")));
            this.btnok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnok.BorderColor = System.Drawing.Color.Empty;
            this.btnok.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnok.EnabledEx = false;
            this.btnok.FlatAppearance.BorderSize = 0;
            this.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnok.Location = new System.Drawing.Point(74, 202);
            this.btnok.Name = "btnok";
            this.btnok.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnok.Picture_MouseDown")));
            this.btnok.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnok.Picture_MouseMove")));
            this.btnok.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnok.Picture_Normal")));
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "确定";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // txtreason
            // 
            // 
            // 
            // 
            this.txtreason.Border.Class = "TextBoxBorder";
            this.txtreason.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtreason.Location = new System.Drawing.Point(130, 45);
            this.txtreason.Multiline = true;
            this.txtreason.Name = "txtreason";
            this.txtreason.Size = new System.Drawing.Size(234, 125);
            this.txtreason.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "驳回理由:";
            // 
            // FormUnCheckReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 300);
            this.FormTitle = "驳回 ";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormUnCheckReason";
            this.NeedMax = false;
            this.NeedMix = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "驳回 ";
            this.panelWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtreason;
        private System.Windows.Forms.Label label1;
        private Common.ButtonEx btncancle;
        private Common.ButtonEx btnok;
    }
}