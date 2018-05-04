namespace Bestway.Windows.Tools.ADODB
{
    partial class DBLoggingInDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBLoggingInDialog));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboProviderName = new System.Windows.Forms.ComboBox();
            this.lblProviderName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtHostID = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDBName = new System.Windows.Forms.Label();
            this.lblHostID = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboProviderName);
            this.groupBox1.Controls.Add(this.lblProviderName);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.txtDBName);
            this.groupBox1.Controls.Add(this.txtHostID);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.lblDBName);
            this.groupBox1.Controls.Add(this.lblHostID);
            this.groupBox1.Location = new System.Drawing.Point(24, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录信息";
            // 
            // cboProviderName
            // 
            this.cboProviderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProviderName.FormattingEnabled = true;
            this.cboProviderName.Location = new System.Drawing.Point(104, 27);
            this.cboProviderName.Name = "cboProviderName";
            this.cboProviderName.Size = new System.Drawing.Size(170, 20);
            this.cboProviderName.TabIndex = 0;
            // 
            // lblProviderName
            // 
            this.lblProviderName.AutoSize = true;
            this.lblProviderName.Location = new System.Drawing.Point(31, 30);
            this.lblProviderName.Name = "lblProviderName";
            this.lblProviderName.Size = new System.Drawing.Size(71, 12);
            this.lblProviderName.TabIndex = 4;
            this.lblProviderName.Text = "数据库类型:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(104, 130);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(170, 21);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(104, 104);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(170, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(104, 78);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(170, 21);
            this.txtDBName.TabIndex = 2;
            // 
            // txtHostID
            // 
            this.txtHostID.Location = new System.Drawing.Point(104, 52);
            this.txtHostID.Name = "txtHostID";
            this.txtHostID.Size = new System.Drawing.Size(170, 21);
            this.txtHostID.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(31, 133);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 12);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "用户密码:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(31, 107);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(71, 12);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "登录用户名:";
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(31, 81);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(71, 12);
            this.lblDBName.TabIndex = 1;
            this.lblDBName.Text = "数据库名称:";
            // 
            // lblHostID
            // 
            this.lblHostID.AutoSize = true;
            this.lblHostID.Location = new System.Drawing.Point(31, 55);
            this.lblHostID.Name = "lblHostID";
            this.lblHostID.Size = new System.Drawing.Size(71, 12);
            this.lblHostID.TabIndex = 0;
            this.lblHostID.Text = "服务器地址:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(353, 24);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 29);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "连接(&L)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(353, 59);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DBLoggingInDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 212);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBLoggingInDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库连接";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.TextBox txtHostID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Label lblHostID;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboProviderName;
        private System.Windows.Forms.Label lblProviderName;

    }
}