namespace Mail_Test
{
    partial class SendMail
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTo = new System.Windows.Forms.Label();
            this.lblCC = new System.Windows.Forms.Label();
            this.lblBcc = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.txtBcc = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.btnAttachment = new System.Windows.Forms.Button();
            this.rtbAttachText = new System.Windows.Forms.RichTextBox();
            this.lblMailCount = new System.Windows.Forms.Label();
            this.chbAsync = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxReuse = new System.Windows.Forms.CheckBox();
            this.cbbNumber = new System.Windows.Forms.ComboBox();
            this.rdoFour = new System.Windows.Forms.RadioButton();
            this.rdoThree = new System.Windows.Forms.RadioButton();
            this.rdoTwo = new System.Windows.Forms.RadioButton();
            this.rdoOne = new System.Windows.Forms.RadioButton();
            this.lblReply = new System.Windows.Forms.Label();
            this.rtbReply = new System.Windows.Forms.RichTextBox();
            this.lblConfig = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(16, 21);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(53, 12);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "收件人：";
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(28, 56);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(41, 12);
            this.lblCC.TabIndex = 1;
            this.lblCC.Text = "抄送：";
            // 
            // lblBcc
            // 
            this.lblBcc.AutoSize = true;
            this.lblBcc.Location = new System.Drawing.Point(28, 90);
            this.lblBcc.Name = "lblBcc";
            this.lblBcc.Size = new System.Drawing.Size(41, 12);
            this.lblBcc.TabIndex = 2;
            this.lblBcc.Text = "密送：";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(75, 12);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(366, 21);
            this.txtTo.TabIndex = 3;
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(75, 47);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(366, 21);
            this.txtCC.TabIndex = 3;
            // 
            // txtBcc
            // 
            this.txtBcc.Location = new System.Drawing.Point(75, 81);
            this.txtBcc.Name = "txtBcc";
            this.txtBcc.Size = new System.Drawing.Size(366, 21);
            this.txtBcc.TabIndex = 3;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(28, 123);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(41, 12);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "主题：";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(75, 114);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(366, 21);
            this.txtSubject.TabIndex = 3;
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(28, 216);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(41, 12);
            this.lblBody.TabIndex = 5;
            this.lblBody.Text = "正文：";
            // 
            // rtbBody
            // 
            this.rtbBody.Location = new System.Drawing.Point(75, 216);
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.Size = new System.Drawing.Size(366, 141);
            this.rtbBody.TabIndex = 6;
            this.rtbBody.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(156, 375);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(141, 38);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "发 送";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Location = new System.Drawing.Point(28, 171);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(41, 12);
            this.lblAttachment.TabIndex = 4;
            this.lblAttachment.Text = "附件：";
            // 
            // btnAttachment
            // 
            this.btnAttachment.Location = new System.Drawing.Point(75, 160);
            this.btnAttachment.Name = "btnAttachment";
            this.btnAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnAttachment.TabIndex = 8;
            this.btnAttachment.Text = "添加附件";
            this.btnAttachment.UseVisualStyleBackColor = true;
            this.btnAttachment.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // rtbAttachText
            // 
            this.rtbAttachText.Location = new System.Drawing.Point(156, 145);
            this.rtbAttachText.Name = "rtbAttachText";
            this.rtbAttachText.ReadOnly = true;
            this.rtbAttachText.Size = new System.Drawing.Size(285, 61);
            this.rtbAttachText.TabIndex = 9;
            this.rtbAttachText.Text = "";
            // 
            // lblMailCount
            // 
            this.lblMailCount.AutoSize = true;
            this.lblMailCount.Location = new System.Drawing.Point(241, 140);
            this.lblMailCount.Name = "lblMailCount";
            this.lblMailCount.Size = new System.Drawing.Size(65, 12);
            this.lblMailCount.TabIndex = 5;
            this.lblMailCount.Text = "邮件数量：";
            // 
            // chbAsync
            // 
            this.chbAsync.AutoSize = true;
            this.chbAsync.Location = new System.Drawing.Point(13, 138);
            this.chbAsync.Name = "chbAsync";
            this.chbAsync.Size = new System.Drawing.Size(96, 16);
            this.chbAsync.TabIndex = 11;
            this.chbAsync.Text = "启用异步发送";
            this.chbAsync.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbxReuse);
            this.panel1.Controls.Add(this.cbbNumber);
            this.panel1.Controls.Add(this.rdoFour);
            this.panel1.Controls.Add(this.rdoThree);
            this.panel1.Controls.Add(this.rdoTwo);
            this.panel1.Controls.Add(this.chbAsync);
            this.panel1.Controls.Add(this.rdoOne);
            this.panel1.Controls.Add(this.lblMailCount);
            this.panel1.Location = new System.Drawing.Point(464, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 171);
            this.panel1.TabIndex = 13;
            // 
            // cbxReuse
            // 
            this.cbxReuse.AutoSize = true;
            this.cbxReuse.Checked = true;
            this.cbxReuse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxReuse.Location = new System.Drawing.Point(115, 138);
            this.cbxReuse.Name = "cbxReuse";
            this.cbxReuse.Size = new System.Drawing.Size(108, 16);
            this.cbxReuse.TabIndex = 13;
            this.cbxReuse.Text = "重用SmtpClient";
            this.cbxReuse.UseVisualStyleBackColor = true;
            // 
            // cbbNumber
            // 
            this.cbbNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNumber.FormattingEnabled = true;
            this.cbbNumber.Items.AddRange(new object[] {
            "1",
            "22",
            "99",
            "222",
            "999",
            "2222",
            "9999",
            "22222",
            "99999",
            "222222",
            "999999",
            "2222222",
            "9999999"});
            this.cbbNumber.Location = new System.Drawing.Point(302, 136);
            this.cbbNumber.Name = "cbbNumber";
            this.cbbNumber.Size = new System.Drawing.Size(121, 20);
            this.cbbNumber.TabIndex = 12;
            // 
            // rdoFour
            // 
            this.rdoFour.AutoSize = true;
            this.rdoFour.Location = new System.Drawing.Point(13, 102);
            this.rdoFour.Name = "rdoFour";
            this.rdoFour.Size = new System.Drawing.Size(455, 28);
            this.rdoFour.TabIndex = 1;
            this.rdoFour.Text = "实验四：批量邮件同步和异步发送 \r\n（平行类库Parallel（手动分区），每个分区一个MailHelper、SmtpClient实例）";
            this.rdoFour.UseVisualStyleBackColor = true;
            this.rdoFour.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // rdoThree
            // 
            this.rdoThree.AutoSize = true;
            this.rdoThree.Location = new System.Drawing.Point(13, 68);
            this.rdoThree.Name = "rdoThree";
            this.rdoThree.Size = new System.Drawing.Size(455, 28);
            this.rdoThree.TabIndex = 1;
            this.rdoThree.Text = "实验三：批量邮件同步和异步发送 \r\n（平行类库Parallel（自动分区），每个分区一个MailHelper、SmtpClient实例）";
            this.rdoThree.UseVisualStyleBackColor = true;
            this.rdoThree.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // rdoTwo
            // 
            this.rdoTwo.AutoSize = true;
            this.rdoTwo.Location = new System.Drawing.Point(13, 34);
            this.rdoTwo.Name = "rdoTwo";
            this.rdoTwo.Size = new System.Drawing.Size(293, 28);
            this.rdoTwo.TabIndex = 1;
            this.rdoTwo.Text = "实验二：批量邮件同步和异步发送\r\n（单个线程，单个SmtpClient实例，SendAsync()）";
            this.rdoTwo.UseVisualStyleBackColor = true;
            this.rdoTwo.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // rdoOne
            // 
            this.rdoOne.AutoSize = true;
            this.rdoOne.Location = new System.Drawing.Point(13, 12);
            this.rdoOne.Name = "rdoOne";
            this.rdoOne.Size = new System.Drawing.Size(431, 16);
            this.rdoOne.TabIndex = 0;
            this.rdoOne.Text = "实验一：单条邮件同步和异步发送（可通过添加大附件来观察同步异步效果）";
            this.rdoOne.UseVisualStyleBackColor = true;
            this.rdoOne.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // lblReply
            // 
            this.lblReply.AutoSize = true;
            this.lblReply.Location = new System.Drawing.Point(462, 216);
            this.lblReply.Name = "lblReply";
            this.lblReply.Size = new System.Drawing.Size(89, 12);
            this.lblReply.TabIndex = 14;
            this.lblReply.Text = "发送反馈信息：";
            // 
            // rtbReply
            // 
            this.rtbReply.Location = new System.Drawing.Point(464, 234);
            this.rtbReply.Name = "rtbReply";
            this.rtbReply.ReadOnly = true;
            this.rtbReply.Size = new System.Drawing.Size(480, 179);
            this.rtbReply.TabIndex = 15;
            this.rtbReply.Text = "";
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Location = new System.Drawing.Point(462, 15);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(89, 12);
            this.lblConfig.TabIndex = 14;
            this.lblConfig.Text = "邮件发送方案：";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(308, 375);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(133, 38);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "清空反馈信息";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 425);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.rtbReply);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.lblReply);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbAttachText);
            this.Controls.Add(this.btnAttachment);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rtbBody);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtBcc);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblBcc);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.lblTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SendMail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件发送";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.Label lblBcc;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.TextBox txtBcc;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.RichTextBox rtbBody;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Button btnAttachment;
        private System.Windows.Forms.RichTextBox rtbAttachText;
        private System.Windows.Forms.Label lblMailCount;
        private System.Windows.Forms.CheckBox chbAsync;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoOne;
        private System.Windows.Forms.RadioButton rdoThree;
        private System.Windows.Forms.RadioButton rdoTwo;
        private System.Windows.Forms.ComboBox cbbNumber;
        private System.Windows.Forms.Label lblReply;
        private System.Windows.Forms.RichTextBox rtbReply;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbxReuse;
        private System.Windows.Forms.RadioButton rdoFour;
    }
}

