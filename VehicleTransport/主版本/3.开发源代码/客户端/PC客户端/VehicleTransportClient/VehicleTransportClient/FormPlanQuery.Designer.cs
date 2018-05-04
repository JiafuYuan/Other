namespace VehicleTransportClient
{
    partial class FormPlanQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlanQuery));
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvList = new VehicleTransportClient.Tools.DataGridViewEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label6 = new System.Windows.Forms.Label();
            this.dtStop = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label1 = new System.Windows.Forms.Label();
            this.txtplancode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbState = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnSearch = new Common.ButtonEx();
            this.btnstyle = new Common.ButtonEx();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbcount = new System.Windows.Forms.ToolStripStatusLabel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGivedt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGivePlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGiveDeptname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoaddt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackDeptment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPlanDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColPlanTrans = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.dgvList);
            this.panelMain.Controls.Add(this.panel3);
            this.panelMain.Controls.Add(this.statusStrip1);
            this.panelMain.Location = new System.Drawing.Point(12, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(984, 570);
            this.panelMain.TabIndex = 4;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AlternatingRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvList.ColumnHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeight = 35;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.Column3,
            this.Column6,
            this.Column2,
            this.Column4,
            this.Column5,
            this.ColGivedt,
            this.ColGivePlace,
            this.ColGiveDeptname,
            this.ColLoaddt,
            this.Column11,
            this.Column12,
            this.ColBackDt,
            this.ColBackAddress,
            this.ColBackDeptment,
            this.Column15,
            this.ColPlanDetail,
            this.ColPlanTrans});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvList.Location = new System.Drawing.Point(0, 76);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowsDefaultBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowsDefaultSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvList.RowTemplate.Height = 35;
            this.dgvList.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(984, 472);
            this.dgvList.TabIndex = 24;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 76);
            this.panel3.TabIndex = 23;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel1.BackgroundImage")));
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.dtStart);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.dtStop);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtplancode);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cmbState);
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Controls.Add(this.btnstyle);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(41, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(933, 76);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 35, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "计划到达开始时间";
            // 
            // dtStart
            // 
            // 
            // 
            // 
            this.dtStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtStart.ButtonDropDown.Visible = true;
            this.dtStart.CustomFormat = "yyyy-MM-dd";
            this.dtStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtStart.IsPopupCalendarOpen = false;
            this.dtStart.Location = new System.Drawing.Point(112, 33);
            this.dtStart.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            // 
            // 
            // 
            this.dtStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtStart.MonthCalendar.BackgroundStyle.Class = "";
            this.dtStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStart.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtStart.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStart.MonthCalendar.TodayButtonVisible = true;
            this.dtStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(108, 21);
            this.dtStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtStart.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 35, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "计划到达结束时间";
            // 
            // dtStop
            // 
            // 
            // 
            // 
            this.dtStop.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtStop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStop.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtStop.ButtonDropDown.Visible = true;
            this.dtStop.CustomFormat = "yyyy-MM-dd";
            this.dtStop.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtStop.IsPopupCalendarOpen = false;
            this.dtStop.Location = new System.Drawing.Point(333, 33);
            this.dtStop.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            // 
            // 
            // 
            this.dtStop.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtStop.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtStop.MonthCalendar.BackgroundStyle.Class = "";
            this.dtStop.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStop.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtStop.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtStop.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStop.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtStop.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtStop.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtStop.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtStop.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtStop.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStop.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtStop.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtStop.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtStop.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtStop.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtStop.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtStop.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtStop.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtStop.MonthCalendar.TodayButtonVisible = true;
            this.dtStop.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtStop.Name = "dtStop";
            this.dtStop.Size = new System.Drawing.Size(108, 21);
            this.dtStop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtStop.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 35, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "运单号";
            // 
            // txtplancode
            // 
            this.txtplancode.Location = new System.Drawing.Point(494, 33);
            this.txtplancode.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            this.txtplancode.MaxLength = 20;
            this.txtplancode.Name = "txtplancode";
            this.txtplancode.Size = new System.Drawing.Size(100, 21);
            this.txtplancode.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 35, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "单据状态";
            // 
            // cmbState
            // 
            this.cmbState.DisplayMember = "Text";
            this.cmbState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.ItemHeight = 15;
            this.cmbState.Location = new System.Drawing.Point(659, 33);
            this.cmbState.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(121, 21);
            this.cmbState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbState.TabIndex = 40;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.BorderColor = System.Drawing.Color.Empty;
            this.btnSearch.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnSearch.EnabledEx = false;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(786, 33);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnSearch.Picture_MouseDown")));
            this.btnSearch.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnSearch.Picture_MouseMove")));
            this.btnSearch.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnSearch.Picture_Normal")));
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnstyle
            // 
            this.btnstyle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnstyle.BackgroundImage")));
            this.btnstyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnstyle.BorderColor = System.Drawing.Color.Empty;
            this.btnstyle.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnstyle.EnabledEx = false;
            this.btnstyle.FlatAppearance.BorderSize = 0;
            this.btnstyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstyle.Location = new System.Drawing.Point(3, 92);
            this.btnstyle.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            this.btnstyle.Name = "btnstyle";
            this.btnstyle.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnstyle.Picture_MouseDown")));
            this.btnstyle.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnstyle.Picture_MouseMove")));
            this.btnstyle.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnstyle.Picture_Normal")));
            this.btnstyle.Size = new System.Drawing.Size(75, 23);
            this.btnstyle.TabIndex = 41;
            this.btnstyle.Text = "样式";
            this.btnstyle.UseVisualStyleBackColor = true;
            this.btnstyle.Click += new System.EventHandler(this.btnstyle_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(974, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 76);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 76);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbcount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbcount
            // 
            this.lbcount.Name = "lbcount";
            this.lbcount.Size = new System.Drawing.Size(131, 17);
            this.lbcount.Text = "toolStripStatusLabel1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "运单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "申请人";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "申请部门";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "申请内容";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "目的地";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "计划到达时间";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // ColGivedt
            // 
            this.ColGivedt.HeaderText = "计划供车时间";
            this.ColGivedt.Name = "ColGivedt";
            this.ColGivedt.ReadOnly = true;
            // 
            // ColGivePlace
            // 
            this.ColGivePlace.HeaderText = "计划供车地点";
            this.ColGivePlace.Name = "ColGivePlace";
            this.ColGivePlace.ReadOnly = true;
            // 
            // ColGiveDeptname
            // 
            this.ColGiveDeptname.HeaderText = "计划供车部门";
            this.ColGiveDeptname.Name = "ColGiveDeptname";
            this.ColGiveDeptname.ReadOnly = true;
            // 
            // ColLoaddt
            // 
            this.ColLoaddt.HeaderText = "计划装车时间";
            this.ColLoaddt.Name = "ColLoaddt";
            this.ColLoaddt.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "计划装车地点";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "计划装车部门";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // ColBackDt
            // 
            this.ColBackDt.HeaderText = "计划还车时间";
            this.ColBackDt.Name = "ColBackDt";
            this.ColBackDt.ReadOnly = true;
            // 
            // ColBackAddress
            // 
            this.ColBackAddress.HeaderText = "计划还车地点";
            this.ColBackAddress.Name = "ColBackAddress";
            this.ColBackAddress.ReadOnly = true;
            // 
            // ColBackDeptment
            // 
            this.ColBackDeptment.HeaderText = "计划还车部门";
            this.ColBackDeptment.Name = "ColBackDeptment";
            this.ColBackDeptment.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "状态";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // ColPlanDetail
            // 
            this.ColPlanDetail.HeaderText = "详情";
            this.ColPlanDetail.Name = "ColPlanDetail";
            this.ColPlanDetail.ReadOnly = true;
            this.ColPlanDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPlanDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColPlanTrans
            // 
            this.ColPlanTrans.HeaderText = "运输路线";
            this.ColPlanTrans.Name = "ColPlanTrans";
            this.ColPlanTrans.ReadOnly = true;
            this.ColPlanTrans.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColPlanTrans.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FormPlanQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 594);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPlanQuery";
            this.Text = "状态查询";
            this.Load += new System.EventHandler(this.FormPlanQuery_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbcount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Tools.DataGridViewEx dgvList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStart;
        private System.Windows.Forms.Label label6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbState;
        private Common.ButtonEx btnSearch;
        private Common.ButtonEx btnstyle;
        private System.Windows.Forms.TextBox txtplancode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGivedt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGivePlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGiveDeptname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoaddt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackDeptment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewLinkColumn ColPlanDetail;
        private System.Windows.Forms.DataGridViewLinkColumn ColPlanTrans;
    }
}