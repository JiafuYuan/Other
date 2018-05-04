namespace Laura.Calculator
{
    partial class AboutForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lkBlog = new System.Windows.Forms.LinkLabel();
            this.lkCnBlog = new System.Windows.Forms.LinkLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laura.Calculator 1.0\r\n是基于 Laura.Compute 算法 的 简单计算器。\r\n软件源码 和 Laura.Compute 算法代码 同样" +
                "开源，希望大家多多支持。\r\n舒小龙 拥有本软件的 所有权利。";
            // 
            // lkBlog
            // 
            this.lkBlog.AutoSize = true;
            this.lkBlog.Location = new System.Drawing.Point(14, 92);
            this.lkBlog.Name = "lkBlog";
            this.lkBlog.Size = new System.Drawing.Size(93, 17);
            this.lkBlog.TabIndex = 1;
            this.lkBlog.TabStop = true;
            this.lkBlog.Text = "舒小龙 - 问莲阁";
            this.lkBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkBlog_LinkClicked);
            // 
            // lkCnBlog
            // 
            this.lkCnBlog.AutoSize = true;
            this.lkCnBlog.Location = new System.Drawing.Point(122, 92);
            this.lkCnBlog.Name = "lkCnBlog";
            this.lkCnBlog.Size = new System.Drawing.Size(93, 17);
            this.lkCnBlog.TabIndex = 2;
            this.lkCnBlog.TabStop = true;
            this.lkCnBlog.Text = "舒小龙 - 博客园";
            this.lkCnBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkCnBlog_LinkClicked);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(287, 115);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(98, 28);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确认(&OK)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 155);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lkCnBlog);
            this.Controls.Add(this.lkBlog);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lkBlog;
        private System.Windows.Forms.LinkLabel lkCnBlog;
        private System.Windows.Forms.Button btnOK;
    }
}