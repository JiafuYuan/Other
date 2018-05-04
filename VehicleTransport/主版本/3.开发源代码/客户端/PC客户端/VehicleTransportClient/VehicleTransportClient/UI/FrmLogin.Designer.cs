namespace VehicleTransportClient.UI
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.lbpwd = new System.Windows.Forms.Label();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.lblOk = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(95)))), ((int)(((byte)(161)))));
            this.label1.Location = new System.Drawing.Point(290, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // lbpwd
            // 
            this.lbpwd.AutoSize = true;
            this.lbpwd.BackColor = System.Drawing.Color.Transparent;
            this.lbpwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(95)))), ((int)(((byte)(161)))));
            this.lbpwd.Location = new System.Drawing.Point(290, 202);
            this.lbpwd.Name = "lbpwd";
            this.lbpwd.Size = new System.Drawing.Size(53, 12);
            this.lbpwd.TabIndex = 2;
            this.lbpwd.Text = "密  码：";
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(349, 199);
            this.txtpwd.MaxLength = 10;
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(120, 21);
            this.txtpwd.TabIndex = 2;
            this.txtpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpwd_KeyDown);
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(349, 162);
            this.txtuser.MaxLength = 10;
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(120, 21);
            this.txtuser.TabIndex = 1;
            // 
            // lblOk
            // 
            this.lblOk.Image = global::VehicleTransportClient.Properties.Resources.登录_03;
            this.lblOk.Location = new System.Drawing.Point(269, 246);
            this.lblOk.Name = "lblOk";
            this.lblOk.Size = new System.Drawing.Size(74, 28);
            this.lblOk.TabIndex = 6;
            this.lblOk.Click += new System.EventHandler(this.btok_Click);
            // 
            // lblCancel
            // 
            this.lblCancel.Image = global::VehicleTransportClient.Properties.Resources.登录_05;
            this.lblCancel.Location = new System.Drawing.Point(410, 246);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(74, 28);
            this.lblCancel.TabIndex = 7;
            this.lblCancel.Click += new System.EventHandler(this.btcancle_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::VehicleTransportClient.Properties.Resources.登录_1_;
            this.ClientSize = new System.Drawing.Size(521, 320);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.lblOk);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.lbpwd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbpwd;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label lblOk;
        private System.Windows.Forms.Label lblCancel;
    }
}