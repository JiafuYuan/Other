namespace VehicleTransportServer
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvUseList = new System.Windows.Forms.DataGridView();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkPasueRoll = new System.Windows.Forms.CheckBox();
            this.chkShowSend = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLogCount = new System.Windows.Forms.ComboBox();
            this.chkShowError = new System.Windows.Forms.CheckBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.chkShowHearbeat = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblServerInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDBInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSocketCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUseList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShow,
            this.tsmiExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 48);
            // 
            // tsmiShow
            // 
            this.tsmiShow.Name = "tsmiShow";
            this.tsmiShow.Size = new System.Drawing.Size(134, 22);
            this.tsmiShow.Text = "显示主窗体";
            this.tsmiShow.Click += new System.EventHandler(this.tsmiShow_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(134, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 163);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器运行日志";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column16,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column15,
            this.Column4,
            this.Column8,
            this.Column9});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 17);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(1022, 143);
            this.dgvList.TabIndex = 2;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "序号";
            this.Column16.Name = "Column16";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "日志类型";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "日志内容";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "发送状态";
            this.Column7.Name = "Column7";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "命令类型";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.FillWeight = 260F;
            this.Column2.HeaderText = "时间";
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "命令执行";
            this.Column3.Name = "Column3";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "失败原因";
            this.Column15.Name = "Column15";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "命令内容";
            this.Column4.Name = "Column4";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "IP地址";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "端口号";
            this.Column9.Name = "Column9";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvUseList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1028, 175);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "在线用户列表";
            // 
            // dgvUseList
            // 
            this.dgvUseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column14,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dgvUseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUseList.Location = new System.Drawing.Point(3, 17);
            this.dgvUseList.Name = "dgvUseList";
            this.dgvUseList.RowTemplate.Height = 23;
            this.dgvUseList.Size = new System.Drawing.Size(1022, 155);
            this.dgvUseList.TabIndex = 3;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "用户类型";
            this.Column14.Name = "Column14";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "用户名";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column11.HeaderText = "最后活动";
            this.Column11.Name = "Column11";
            this.Column11.Width = 130;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "IP";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "端口";
            this.Column13.Name = "Column13";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1028, 48);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkPasueRoll);
            this.panel2.Controls.Add(this.chkShowSend);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboLogCount);
            this.panel2.Controls.Add(this.chkShowError);
            this.panel2.Controls.Add(this.chkLog);
            this.panel2.Controls.Add(this.chkShowHearbeat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 26);
            this.panel2.TabIndex = 9;
            // 
            // chkPasueRoll
            // 
            this.chkPasueRoll.AutoSize = true;
            this.chkPasueRoll.Location = new System.Drawing.Point(483, 5);
            this.chkPasueRoll.Name = "chkPasueRoll";
            this.chkPasueRoll.Size = new System.Drawing.Size(72, 16);
            this.chkPasueRoll.TabIndex = 10;
            this.chkPasueRoll.Text = "暂停滚动";
            this.chkPasueRoll.UseVisualStyleBackColor = true;
            // 
            // chkShowSend
            // 
            this.chkShowSend.AutoSize = true;
            this.chkShowSend.Location = new System.Drawing.Point(353, 5);
            this.chkShowSend.Name = "chkShowSend";
            this.chkShowSend.Size = new System.Drawing.Size(96, 16);
            this.chkShowSend.TabIndex = 9;
            this.chkShowSend.Text = "隐藏发送信息";
            this.chkShowSend.UseVisualStyleBackColor = true;
            this.chkShowSend.CheckedChanged += new System.EventHandler(this.chkShowSend_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(771, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "日志显示记录数：";
            // 
            // cboLogCount
            // 
            this.cboLogCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLogCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLogCount.FormattingEnabled = true;
            this.cboLogCount.Items.AddRange(new object[] {
            "30",
            "50",
            "100",
            "200",
            "500",
            "1000"});
            this.cboLogCount.Location = new System.Drawing.Point(874, 3);
            this.cboLogCount.Name = "cboLogCount";
            this.cboLogCount.Size = new System.Drawing.Size(121, 20);
            this.cboLogCount.TabIndex = 7;
            this.cboLogCount.SelectedIndexChanged += new System.EventHandler(this.cboLogCount_SelectedIndexChanged);
            // 
            // chkShowError
            // 
            this.chkShowError.AutoSize = true;
            this.chkShowError.Location = new System.Drawing.Point(232, 5);
            this.chkShowError.Name = "chkShowError";
            this.chkShowError.Size = new System.Drawing.Size(96, 16);
            this.chkShowError.TabIndex = 5;
            this.chkShowError.Text = "隐藏错误信息";
            this.chkShowError.UseVisualStyleBackColor = true;
            this.chkShowError.CheckedChanged += new System.EventHandler(this.chkShowError_CheckedChanged);
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(21, 4);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(72, 16);
            this.chkLog.TabIndex = 3;
            this.chkLog.Text = "保存日志";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged_1);
            // 
            // chkShowHearbeat
            // 
            this.chkShowHearbeat.AutoSize = true;
            this.chkShowHearbeat.Location = new System.Drawing.Point(117, 4);
            this.chkShowHearbeat.Name = "chkShowHearbeat";
            this.chkShowHearbeat.Size = new System.Drawing.Size(96, 16);
            this.chkShowHearbeat.TabIndex = 4;
            this.chkShowHearbeat.Text = "隐藏心跳命令";
            this.chkShowHearbeat.UseVisualStyleBackColor = true;
            this.chkShowHearbeat.CheckedChanged += new System.EventHandler(this.chkShowHearbeat_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 208);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1028, 3);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblServerInfo,
            this.toolStripStatusLabel3,
            this.lblDBInfo,
            this.toolStripStatusLabel5,
            this.lblSocketCount,
            this.toolStripStatusLabel2,
            this.lblUserCount,
            this.lblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1028, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "服务器信息:";
            // 
            // lblServerInfo
            // 
            this.lblServerInfo.Margin = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.lblServerInfo.Name = "lblServerInfo";
            this.lblServerInfo.Size = new System.Drawing.Size(115, 17);
            this.lblServerInfo.Text = "192.168.1.100：1234";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel3.Text = "数据库信息:";
            // 
            // lblDBInfo
            // 
            this.lblDBInfo.Margin = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.lblDBInfo.Name = "lblDBInfo";
            this.lblDBInfo.Size = new System.Drawing.Size(67, 17);
            this.lblDBInfo.Text = "172.21.2.58";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(88, 17);
            this.toolStripStatusLabel5.Text = "Socket连接数:";
            // 
            // lblSocketCount
            // 
            this.lblSocketCount.Margin = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.lblSocketCount.Name = "lblSocketCount";
            this.lblSocketCount.Size = new System.Drawing.Size(13, 17);
            this.lblSocketCount.Text = "3";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel2.Text = "在线用户数:";
            // 
            // lblUserCount
            // 
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(13, 17);
            this.lblUserCount.Text = "0";
            // 
            // lblTime
            // 
            this.lblTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(432, 17);
            this.lblTime.Spring = true;
            this.lblTime.Text = "toolStripStatusLabel4";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 408);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUseList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiShow;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvUseList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLogCount;
        private System.Windows.Forms.CheckBox chkShowError;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.CheckBox chkShowHearbeat;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.CheckBox chkShowSend;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblServerInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblDBInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblSocketCount;
        private System.Windows.Forms.CheckBox chkPasueRoll;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblUserCount;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}

