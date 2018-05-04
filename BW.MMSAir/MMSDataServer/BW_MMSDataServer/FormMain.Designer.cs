namespace Bestway.Windows.Program.MMS
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSaveXML = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerWriteRunLog = new System.Windows.Forms.Timer(this.components);
            this.groupBox_ProgramStatus = new System.Windows.Forms.GroupBox();
            this.listBox_ShowMessage = new System.Windows.Forms.ListBox();
            this.timer_ClickBtnStart = new System.Windows.Forms.Timer(this.components);
            this.ProgramStatus = new System.Windows.Forms.StatusStrip();
            this.IntialName = new System.Windows.Forms.ToolStripStatusLabel();
            this.InitialStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.OPCServerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.OPCServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.OPCPowerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.OPCPowerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox_ProgramStatus.SuspendLayout();
            this.ProgramStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(2, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSaveXML
            // 
            this.btnSaveXML.Location = new System.Drawing.Point(116, 3);
            this.btnSaveXML.Name = "btnSaveXML";
            this.btnSaveXML.Size = new System.Drawing.Size(90, 23);
            this.btnSaveXML.TabIndex = 2;
            this.btnSaveXML.Text = "保存配置信息";
            this.btnSaveXML.UseVisualStyleBackColor = true;
            this.btnSaveXML.Click += new System.EventHandler(this.btnSaveXML_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "山东淄博矿业集团唐口煤业公司能量计量系统";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 54);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openToolStripMenuItem.Text = "打开主界面";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem.Text = "退出";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timerWriteRunLog
            // 
            this.timerWriteRunLog.Interval = 600000;
            // 
            // groupBox_ProgramStatus
            // 
            this.groupBox_ProgramStatus.Controls.Add(this.ProgramStatus);
            this.groupBox_ProgramStatus.Controls.Add(this.listBox_ShowMessage);
            this.groupBox_ProgramStatus.Location = new System.Drawing.Point(0, 27);
            this.groupBox_ProgramStatus.Name = "groupBox_ProgramStatus";
            this.groupBox_ProgramStatus.Size = new System.Drawing.Size(516, 359);
            this.groupBox_ProgramStatus.TabIndex = 3;
            this.groupBox_ProgramStatus.TabStop = false;
            this.groupBox_ProgramStatus.Text = "程序状态信息:";
            // 
            // listBox_ShowMessage
            // 
            this.listBox_ShowMessage.FormattingEnabled = true;
            this.listBox_ShowMessage.ItemHeight = 12;
            this.listBox_ShowMessage.Location = new System.Drawing.Point(2, 16);
            this.listBox_ShowMessage.Name = "listBox_ShowMessage";
            this.listBox_ShowMessage.Size = new System.Drawing.Size(511, 316);
            this.listBox_ShowMessage.TabIndex = 0;
            // 
            // ProgramStatus
            // 
            this.ProgramStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IntialName,
            this.InitialStatus,
            this.OPCServerName,
            this.OPCServerStatus,
            this.OPCPowerName,
            this.OPCPowerStatus});
            this.ProgramStatus.Location = new System.Drawing.Point(3, 334);
            this.ProgramStatus.Name = "ProgramStatus";
            this.ProgramStatus.Size = new System.Drawing.Size(510, 22);
            this.ProgramStatus.TabIndex = 1;
            this.ProgramStatus.Text = "statusStrip1";
            // 
            // IntialName
            // 
            this.IntialName.Name = "IntialName";
            this.IntialName.Size = new System.Drawing.Size(95, 17);
            this.IntialName.Text = "程序初始化状态:";
            // 
            // InitialStatus
            // 
            this.InitialStatus.Name = "InitialStatus";
            this.InitialStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // OPCServerName
            // 
            this.OPCServerName.Name = "OPCServerName";
            this.OPCServerName.Size = new System.Drawing.Size(96, 17);
            this.OPCServerName.Text = "OPC服务器状态:";
            // 
            // OPCServerStatus
            // 
            this.OPCServerStatus.Name = "OPCServerStatus";
            this.OPCServerStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // OPCPowerName
            // 
            this.OPCPowerName.Name = "OPCPowerName";
            this.OPCPowerName.Size = new System.Drawing.Size(120, 17);
            this.OPCPowerName.Text = "OPC电力服务器状态:";
            // 
            // OPCPowerStatus
            // 
            this.OPCPowerStatus.Name = "OPCPowerStatus";
            this.OPCPowerStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 387);
            this.Controls.Add(this.groupBox_ProgramStatus);
            this.Controls.Add(this.btnSaveXML);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "山东淄博矿业集团唐口煤业公司能量计量系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox_ProgramStatus.ResumeLayout(false);
            this.groupBox_ProgramStatus.PerformLayout();
            this.ProgramStatus.ResumeLayout(false);
            this.ProgramStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSaveXML;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer timerWriteRunLog;
        private System.Windows.Forms.GroupBox groupBox_ProgramStatus;
        private System.Windows.Forms.ListBox listBox_ShowMessage;
        private System.Windows.Forms.Timer timer_ClickBtnStart;
        private System.Windows.Forms.StatusStrip ProgramStatus;
        private System.Windows.Forms.ToolStripStatusLabel IntialName;
        private System.Windows.Forms.ToolStripStatusLabel InitialStatus;
        private System.Windows.Forms.ToolStripStatusLabel OPCServerName;
        private System.Windows.Forms.ToolStripStatusLabel OPCServerStatus;
        private System.Windows.Forms.ToolStripStatusLabel OPCPowerName;
        private System.Windows.Forms.ToolStripStatusLabel OPCPowerStatus;
    }
}