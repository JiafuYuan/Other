namespace JSCERT
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panRight = new System.Windows.Forms.Panel();
            this.listBoxMsg = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.lblNav = new DevComponents.DotNetBar.LabelX();
            this.panelBorderRight = new System.Windows.Forms.Panel();
            this.panelBorderLeft = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelBottomCenter = new System.Windows.Forms.Panel();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.lbdbstate = new DevComponents.DotNetBar.LabelX();
            this.lbstate = new DevComponents.DotNetBar.LabelX();
            this.picBottomRight = new System.Windows.Forms.PictureBox();
            this.picBottomleft = new System.Windows.Forms.PictureBox();
            this.panelborder = new System.Windows.Forms.Panel();
            this.panelBorderCenter = new System.Windows.Forms.Panel();
            this.panelBorderTopRight = new System.Windows.Forms.Panel();
            this.picBorderLeft = new System.Windows.Forms.PictureBox();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelTitleCenter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCheckMgr = new DevComponents.DotNetBar.ButtonX();
            this.btnclose = new DevComponents.DotNetBar.ButtonX();
            this.button1 = new System.Windows.Forms.Button();
            this.picTitleLeft = new System.Windows.Forms.PictureBox();
            this.panelTitleRight = new System.Windows.Forms.Panel();
            this.lblWeeks = new DevComponents.DotNetBar.LabelX();
            this.lblTimes = new DevComponents.DotNetBar.LabelX();
            this.lblDate = new DevComponents.DotNetBar.LabelX();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopCenter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictop = new System.Windows.Forms.PictureBox();
            this.panelTopRight = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnmin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnmax = new System.Windows.Forms.ToolStripMenuItem();
            this.btnpicclose = new System.Windows.Forms.ToolStripMenuItem();
            this.picTopLeft = new System.Windows.Forms.PictureBox();
            this.lblAlarmCounts = new System.Windows.Forms.Label();
            this.lblCurrentAlarm = new System.Windows.Forms.Label();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblTime = new DevComponents.DotNetBar.LabelX();
            this.lblWeek = new DevComponents.DotNetBar.LabelX();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.btnVehicleMonth = new DevComponents.DotNetBar.ButtonItem();
            this.button2 = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panRight.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelBottomCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottomRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottomleft)).BeginInit();
            this.panelborder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBorderLeft)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.panelTitleCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleLeft)).BeginInit();
            this.panelTitleRight.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTopCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictop)).BeginInit();
            this.panelTopRight.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTopLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.Controls.Add(this.panRight);
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panelBorderRight);
            this.panelMain.Controls.Add(this.panelBorderLeft);
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Controls.Add(this.panelborder);
            this.panelMain.Controls.Add(this.panelTitle);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(873, 455);
            this.panelMain.TabIndex = 0;
            // 
            // panRight
            // 
            this.panRight.BackColor = System.Drawing.Color.White;
            this.panRight.Controls.Add(this.listBoxMsg);
            this.panRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRight.Location = new System.Drawing.Point(4, 154);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(865, 272);
            this.panRight.TabIndex = 8;
            // 
            // listBoxMsg
            // 
            this.listBoxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMsg.FormattingEnabled = true;
            this.listBoxMsg.ItemHeight = 12;
            this.listBoxMsg.Location = new System.Drawing.Point(0, 0);
            this.listBoxMsg.Name = "listBoxMsg";
            this.listBoxMsg.Size = new System.Drawing.Size(865, 272);
            this.listBoxMsg.TabIndex = 0;
            this.listBoxMsg.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxMsg_DrawItem);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.labelX6);
            this.panel2.Controls.Add(this.lblNav);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 40);
            this.panel2.TabIndex = 7;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.Location = new System.Drawing.Point(7, 8);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 13;
            this.labelX6.Text = "当前页面 >";
            // 
            // lblNav
            // 
            this.lblNav.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblNav.BackgroundStyle.Class = "";
            this.lblNav.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNav.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNav.Location = new System.Drawing.Point(80, 8);
            this.lblNav.Name = "lblNav";
            this.lblNav.Size = new System.Drawing.Size(153, 23);
            this.lblNav.TabIndex = 12;
            this.lblNav.Text = "首页";
            // 
            // panelBorderRight
            // 
            this.panelBorderRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBorderRight.BackgroundImage")));
            this.panelBorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBorderRight.Location = new System.Drawing.Point(869, 114);
            this.panelBorderRight.Name = "panelBorderRight";
            this.panelBorderRight.Size = new System.Drawing.Size(4, 312);
            this.panelBorderRight.TabIndex = 5;
            // 
            // panelBorderLeft
            // 
            this.panelBorderLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBorderLeft.BackgroundImage")));
            this.panelBorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBorderLeft.Location = new System.Drawing.Point(0, 114);
            this.panelBorderLeft.Name = "panelBorderLeft";
            this.panelBorderLeft.Size = new System.Drawing.Size(4, 312);
            this.panelBorderLeft.TabIndex = 4;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelBottomCenter);
            this.panelBottom.Controls.Add(this.picBottomRight);
            this.panelBottom.Controls.Add(this.picBottomleft);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 426);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(873, 29);
            this.panelBottom.TabIndex = 3;
            // 
            // panelBottomCenter
            // 
            this.panelBottomCenter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBottomCenter.BackgroundImage")));
            this.panelBottomCenter.Controls.Add(this.labelX9);
            this.panelBottomCenter.Controls.Add(this.lbdbstate);
            this.panelBottomCenter.Controls.Add(this.lbstate);
            this.panelBottomCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomCenter.Location = new System.Drawing.Point(10, 0);
            this.panelBottomCenter.Name = "panelBottomCenter";
            this.panelBottomCenter.Size = new System.Drawing.Size(853, 29);
            this.panelBottomCenter.TabIndex = 3;
            // 
            // labelX9
            // 
            this.labelX9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(396, 3);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(97, 23);
            this.labelX9.TabIndex = 16;
            this.labelX9.Text = "江苏省互联网应急中心";
            // 
            // lbdbstate
            // 
            this.lbdbstate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbdbstate.BackgroundStyle.Class = "";
            this.lbdbstate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbdbstate.Location = new System.Drawing.Point(155, 3);
            this.lbdbstate.Name = "lbdbstate";
            this.lbdbstate.Size = new System.Drawing.Size(135, 23);
            this.lbdbstate.TabIndex = 15;
            this.lbdbstate.Text = "数据库连接状态：成功";
            // 
            // lbstate
            // 
            this.lbstate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbstate.BackgroundStyle.Class = "";
            this.lbstate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbstate.Location = new System.Drawing.Point(6, 3);
            this.lbstate.Name = "lbstate";
            this.lbstate.Size = new System.Drawing.Size(135, 23);
            this.lbstate.TabIndex = 14;
            this.lbstate.Text = "网络连接状态：成功";
            // 
            // picBottomRight
            // 
            this.picBottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picBottomRight.Image = ((System.Drawing.Image)(resources.GetObject("picBottomRight.Image")));
            this.picBottomRight.Location = new System.Drawing.Point(863, 0);
            this.picBottomRight.Name = "picBottomRight";
            this.picBottomRight.Size = new System.Drawing.Size(10, 29);
            this.picBottomRight.TabIndex = 2;
            this.picBottomRight.TabStop = false;
            // 
            // picBottomleft
            // 
            this.picBottomleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picBottomleft.Image = ((System.Drawing.Image)(resources.GetObject("picBottomleft.Image")));
            this.picBottomleft.Location = new System.Drawing.Point(0, 0);
            this.picBottomleft.Name = "picBottomleft";
            this.picBottomleft.Size = new System.Drawing.Size(10, 29);
            this.picBottomleft.TabIndex = 1;
            this.picBottomleft.TabStop = false;
            // 
            // panelborder
            // 
            this.panelborder.Controls.Add(this.panelBorderCenter);
            this.panelborder.Controls.Add(this.panelBorderTopRight);
            this.panelborder.Controls.Add(this.picBorderLeft);
            this.panelborder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelborder.Location = new System.Drawing.Point(0, 106);
            this.panelborder.Name = "panelborder";
            this.panelborder.Size = new System.Drawing.Size(873, 8);
            this.panelborder.TabIndex = 2;
            // 
            // panelBorderCenter
            // 
            this.panelBorderCenter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBorderCenter.BackgroundImage")));
            this.panelBorderCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorderCenter.Location = new System.Drawing.Point(10, 0);
            this.panelBorderCenter.Name = "panelBorderCenter";
            this.panelBorderCenter.Size = new System.Drawing.Size(177, 8);
            this.panelBorderCenter.TabIndex = 4;
            // 
            // panelBorderTopRight
            // 
            this.panelBorderTopRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBorderTopRight.BackgroundImage")));
            this.panelBorderTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBorderTopRight.Location = new System.Drawing.Point(187, 0);
            this.panelBorderTopRight.Name = "panelBorderTopRight";
            this.panelBorderTopRight.Size = new System.Drawing.Size(686, 8);
            this.panelBorderTopRight.TabIndex = 3;
            // 
            // picBorderLeft
            // 
            this.picBorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picBorderLeft.Image = ((System.Drawing.Image)(resources.GetObject("picBorderLeft.Image")));
            this.picBorderLeft.Location = new System.Drawing.Point(0, 0);
            this.picBorderLeft.Name = "picBorderLeft";
            this.picBorderLeft.Size = new System.Drawing.Size(10, 8);
            this.picBorderLeft.TabIndex = 2;
            this.picBorderLeft.TabStop = false;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.panelTitleCenter);
            this.panelTitle.Controls.Add(this.picTitleLeft);
            this.panelTitle.Controls.Add(this.panelTitleRight);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 24);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(873, 82);
            this.panelTitle.TabIndex = 1;
            // 
            // panelTitleCenter
            // 
            this.panelTitleCenter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTitleCenter.BackgroundImage")));
            this.panelTitleCenter.Controls.Add(this.btnCheckMgr);
            this.panelTitleCenter.Controls.Add(this.btnclose);
            this.panelTitleCenter.Controls.Add(this.button1);
            this.panelTitleCenter.Controls.Add(this.button2);
            this.panelTitleCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitleCenter.Location = new System.Drawing.Point(10, 0);
            this.panelTitleCenter.Name = "panelTitleCenter";
            this.panelTitleCenter.Size = new System.Drawing.Size(439, 82);
            this.panelTitleCenter.TabIndex = 4;
            // 
            // btnCheckMgr
            // 
            this.btnCheckMgr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCheckMgr.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckMgr.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnCheckMgr.FocusCuesEnabled = false;
            this.btnCheckMgr.ForeColor = System.Drawing.Color.White;
            this.btnCheckMgr.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.btnCheckMgr.HoverImage = global::JSCERT.Properties.Resources.抓取2;
            this.btnCheckMgr.Image = global::JSCERT.Properties.Resources.采集;
            this.btnCheckMgr.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnCheckMgr.Location = new System.Drawing.Point(3, 3);
            this.btnCheckMgr.Name = "btnCheckMgr";
            this.btnCheckMgr.Size = new System.Drawing.Size(75, 75);
            this.btnCheckMgr.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btnCheckMgr.TabIndex = 10;
            this.btnCheckMgr.Text = "采集";
            this.btnCheckMgr.Click += new System.EventHandler(this.btnCheckMgr_Click);
            // 
            // btnclose
            // 
            this.btnclose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnclose.FocusCuesEnabled = false;
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.btnclose.HoverImage = global::JSCERT.Properties.Resources.退出系统2;
            this.btnclose.Image = global::JSCERT.Properties.Resources.退出系统;
            this.btnclose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnclose.Location = new System.Drawing.Point(84, 3);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 75);
            this.btnclose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btnclose.TabIndex = 14;
            this.btnclose.Text = "退出系统";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // picTitleLeft
            // 
            this.picTitleLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picTitleLeft.Image = global::JSCERT.Properties.Resources._02_ZUO;
            this.picTitleLeft.Location = new System.Drawing.Point(0, 0);
            this.picTitleLeft.Name = "picTitleLeft";
            this.picTitleLeft.Size = new System.Drawing.Size(10, 82);
            this.picTitleLeft.TabIndex = 1;
            this.picTitleLeft.TabStop = false;
            // 
            // panelTitleRight
            // 
            this.panelTitleRight.BackgroundImage = global::JSCERT.Properties.Resources._02_you;
            this.panelTitleRight.Controls.Add(this.lblWeeks);
            this.panelTitleRight.Controls.Add(this.lblTimes);
            this.panelTitleRight.Controls.Add(this.lblDate);
            this.panelTitleRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTitleRight.Location = new System.Drawing.Point(449, 0);
            this.panelTitleRight.Name = "panelTitleRight";
            this.panelTitleRight.Size = new System.Drawing.Size(424, 82);
            this.panelTitleRight.TabIndex = 2;
            // 
            // lblWeeks
            // 
            this.lblWeeks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeeks.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblWeeks.BackgroundStyle.Class = "";
            this.lblWeeks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWeeks.ForeColor = System.Drawing.Color.White;
            this.lblWeeks.Location = new System.Drawing.Point(332, 55);
            this.lblWeeks.Name = "lblWeeks";
            this.lblWeeks.Size = new System.Drawing.Size(64, 23);
            this.lblWeeks.TabIndex = 10;
            this.lblWeeks.Text = "星期四";
            // 
            // lblTimes
            // 
            this.lblTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimes.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTimes.BackgroundStyle.Class = "";
            this.lblTimes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTimes.ForeColor = System.Drawing.Color.White;
            this.lblTimes.Location = new System.Drawing.Point(326, 26);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(70, 23);
            this.lblTimes.TabIndex = 9;
            this.lblTimes.Text = "11:12:01";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblDate.BackgroundStyle.Class = "";
            this.lblDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(314, 3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(87, 23);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = " 2014-08-08";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTopCenter);
            this.panelTop.Controls.Add(this.panelTopRight);
            this.panelTop.Controls.Add(this.picTopLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(873, 24);
            this.panelTop.TabIndex = 0;
            // 
            // panelTopCenter
            // 
            this.panelTopCenter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTopCenter.BackgroundImage")));
            this.panelTopCenter.Controls.Add(this.label1);
            this.panelTopCenter.Controls.Add(this.pictop);
            this.panelTopCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopCenter.Location = new System.Drawing.Point(10, 0);
            this.panelTopCenter.Name = "panelTopCenter";
            this.panelTopCenter.Size = new System.Drawing.Size(439, 24);
            this.panelTopCenter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "应急中心数据处理工具";
            // 
            // pictop
            // 
            this.pictop.BackColor = System.Drawing.Color.Transparent;
            this.pictop.Image = ((System.Drawing.Image)(resources.GetObject("pictop.Image")));
            this.pictop.Location = new System.Drawing.Point(0, 4);
            this.pictop.Name = "pictop";
            this.pictop.Size = new System.Drawing.Size(16, 16);
            this.pictop.TabIndex = 1;
            this.pictop.TabStop = false;
            // 
            // panelTopRight
            // 
            this.panelTopRight.BackgroundImage = global::JSCERT.Properties.Resources._01_you;
            this.panelTopRight.Controls.Add(this.menuStrip1);
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTopRight.Location = new System.Drawing.Point(449, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.Size = new System.Drawing.Size(424, 24);
            this.panelTopRight.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnmin,
            this.btnmax,
            this.btnpicclose});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(332, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(92, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnmin
            // 
            this.btnmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnmin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmin.Image = ((System.Drawing.Image)(resources.GetObject("btnmin.Image")));
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(28, 20);
            this.btnmin.Text = "toolStripMenuItem1";
            this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
            // 
            // btnmax
            // 
            this.btnmax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnmax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmax.Image = ((System.Drawing.Image)(resources.GetObject("btnmax.Image")));
            this.btnmax.Name = "btnmax";
            this.btnmax.Size = new System.Drawing.Size(28, 20);
            this.btnmax.Text = "toolStripMenuItem2";
            this.btnmax.Click += new System.EventHandler(this.btnmax_Click);
            // 
            // btnpicclose
            // 
            this.btnpicclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnpicclose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnpicclose.Image = ((System.Drawing.Image)(resources.GetObject("btnpicclose.Image")));
            this.btnpicclose.Name = "btnpicclose";
            this.btnpicclose.Size = new System.Drawing.Size(28, 20);
            this.btnpicclose.Text = "toolStripMenuItem3";
            this.btnpicclose.Click += new System.EventHandler(this.btnpicclose_Click);
            // 
            // picTopLeft
            // 
            this.picTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picTopLeft.Image = ((System.Drawing.Image)(resources.GetObject("picTopLeft.Image")));
            this.picTopLeft.Location = new System.Drawing.Point(0, 0);
            this.picTopLeft.Name = "picTopLeft";
            this.picTopLeft.Size = new System.Drawing.Size(10, 24);
            this.picTopLeft.TabIndex = 0;
            this.picTopLeft.TabStop = false;
            // 
            // lblAlarmCounts
            // 
            this.lblAlarmCounts.Location = new System.Drawing.Point(0, 0);
            this.lblAlarmCounts.Name = "lblAlarmCounts";
            this.lblAlarmCounts.Size = new System.Drawing.Size(100, 23);
            this.lblAlarmCounts.TabIndex = 0;
            // 
            // lblCurrentAlarm
            // 
            this.lblCurrentAlarm.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentAlarm.Name = "lblCurrentAlarm";
            this.lblCurrentAlarm.Size = new System.Drawing.Size(100, 23);
            this.lblCurrentAlarm.TabIndex = 0;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(594, 26);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "11：12";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTime.BackgroundStyle.Class = "";
            this.lblTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(594, 26);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(75, 23);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "11：12";
            // 
            // lblWeek
            // 
            this.lblWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeek.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblWeek.BackgroundStyle.Class = "";
            this.lblWeek.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWeek.ForeColor = System.Drawing.Color.White;
            this.lblWeek.Location = new System.Drawing.Point(594, 55);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(75, 23);
            this.lblWeek.TabIndex = 10;
            this.lblWeek.Text = "星期四";
            // 
            // timerDateTime
            // 
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // btnVehicleMonth
            // 
            this.btnVehicleMonth.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnVehicleMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(124)))), ((int)(((byte)(175)))));
            this.btnVehicleMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicleMonth.Image")));
            this.btnVehicleMonth.ImagePaddingVertical = 10;
            this.btnVehicleMonth.Name = "btnVehicleMonth";
            this.btnVehicleMonth.Text = "车辆使用月报表";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(246, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 455);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应急中心数据处理工具";
            this.panelMain.ResumeLayout(false);
            this.panRight.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottomCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBottomRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottomleft)).EndInit();
            this.panelborder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBorderLeft)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitleCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitleLeft)).EndInit();
            this.panelTitleRight.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTopCenter.ResumeLayout(false);
            this.panelTopCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictop)).EndInit();
            this.panelTopRight.ResumeLayout(false);
            this.panelTopRight.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTopLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox picTopLeft;
        private System.Windows.Forms.Panel panelTopCenter;
        private System.Windows.Forms.Panel panelTopRight;
        private System.Windows.Forms.PictureBox pictop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelTitleRight;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnmin;
        private System.Windows.Forms.ToolStripMenuItem btnmax;
        private System.Windows.Forms.ToolStripMenuItem btnpicclose;
        private System.Windows.Forms.Panel panelborder;
        private System.Windows.Forms.PictureBox picBorderLeft;
        private System.Windows.Forms.Panel panelBorderCenter;
        private System.Windows.Forms.Panel panelBorderTopRight;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.PictureBox picBottomleft;
        private System.Windows.Forms.PictureBox picBottomRight;
        private System.Windows.Forms.Panel panelBottomCenter;
        private System.Windows.Forms.Panel panelBorderLeft;
        private System.Windows.Forms.Panel panelBorderRight;
        private DevComponents.DotNetBar.ButtonItem btnVehicleMonth;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX lbdbstate;
        private DevComponents.DotNetBar.LabelX lbstate;
        private System.Windows.Forms.Label lblCurrentAlarm;
        private System.Windows.Forms.Label lblAlarmCounts;
        private DevComponents.DotNetBar.LabelX lblWeeks;
        private DevComponents.DotNetBar.LabelX lblTimes;
        private DevComponents.DotNetBar.LabelX lblDate;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lblNav;
        private System.Windows.Forms.Panel panRight;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lblTime;
        private DevComponents.DotNetBar.LabelX lblWeek;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.FlowLayoutPanel panelTitleCenter;
        private DevComponents.DotNetBar.ButtonX btnCheckMgr;
        private DevComponents.DotNetBar.ButtonX btnclose;
        private System.Windows.Forms.PictureBox picTitleLeft;
        private System.Windows.Forms.ListBox listBoxMsg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}