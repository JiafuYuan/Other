namespace VehicleTransportClient.UI
{
    partial class FormSupplyCarMgr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSupplyCarMgr));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvList = new VehicleTransportClient.Tools.DataGridViewEx();
            this.colcheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label6 = new System.Windows.Forms.Label();
            this.dtStop = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label1 = new System.Windows.Forms.Label();
            this.txtplancode = new DevComponents.Editors.IntegerInput();
            this.btnquery = new Common.ButtonEx();
            this.btnreview = new Common.ButtonEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtplancode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dgvList);
            this.groupPanel1.Controls.Add(this.panel1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1000, 254);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AlternatingRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeight = 35;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colcheck,
            this.dataGridViewTextBoxColumn1,
            this.Column4,
            this.Column5,
            this.Column3,
            this.Column7,
            this.Column6,
            this.Column1,
            this.Column2});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvList.Location = new System.Drawing.Point(0, 80);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 25;
            this.dgvList.RowsDefaultBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowsDefaultSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvList.RowTemplate.Height = 33;
            this.dgvList.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(994, 168);
            this.dgvList.TabIndex = 18;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // colcheck
            // 
            this.colcheck.FillWeight = 50.76142F;
            this.colcheck.HeaderText = "";
            this.colcheck.Name = "colcheck";
            this.colcheck.ReadOnly = true;
            this.colcheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colcheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "vc_PlanCode";
            this.dataGridViewTextBoxColumn1.FillWeight = 105.471F;
            this.dataGridViewTextBoxColumn1.HeaderText = "运单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ApplyDepartmentName";
            this.Column4.FillWeight = 105.471F;
            this.Column4.HeaderText = "申请部门";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ApplyPersonName";
            this.Column5.FillWeight = 105.471F;
            this.Column5.HeaderText = "申请人";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ArriveDestinationAddressName";
            this.Column3.FillWeight = 105.471F;
            this.Column3.HeaderText = "目的地";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "dt_ArriveDestinationDateTime";
            this.Column7.FillWeight = 105.471F;
            this.Column7.HeaderText = "计划到货时间";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "PlanGiveCarDepartmentName";
            this.Column6.FillWeight = 105.471F;
            this.Column6.HeaderText = "计划供车部门";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PlanGiveCarAddressName";
            this.Column1.FillWeight = 105.471F;
            this.Column1.HeaderText = "计划供车地点";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "dt_PlanGiveCarDateTime";
            this.Column2.FillWeight = 105.471F;
            this.Column2.HeaderText = "计划供车时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 80);
            this.panel1.TabIndex = 17;
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
            this.flowLayoutPanel1.Controls.Add(this.btnquery);
            this.flowLayoutPanel1.Controls.Add(this.btnreview);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(41, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(953, 80);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
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
            this.label6.BackColor = System.Drawing.Color.Transparent;
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
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(447, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 35, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "运单号";
            // 
            // txtplancode
            // 
            // 
            // 
            // 
            this.txtplancode.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtplancode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtplancode.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtplancode.Location = new System.Drawing.Point(494, 33);
            this.txtplancode.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            this.txtplancode.Name = "txtplancode";
            this.txtplancode.Size = new System.Drawing.Size(103, 21);
            this.txtplancode.TabIndex = 38;
            // 
            // btnquery
            // 
            this.btnquery.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnquery.BackgroundImage")));
            this.btnquery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnquery.BorderColor = System.Drawing.Color.Empty;
            this.btnquery.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnquery.EnabledEx = false;
            this.btnquery.FlatAppearance.BorderSize = 0;
            this.btnquery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnquery.Location = new System.Drawing.Point(603, 33);
            this.btnquery.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            this.btnquery.Name = "btnquery";
            this.btnquery.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnquery.Picture_MouseDown")));
            this.btnquery.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnquery.Picture_MouseMove")));
            this.btnquery.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnquery.Picture_Normal")));
            this.btnquery.Size = new System.Drawing.Size(75, 23);
            this.btnquery.TabIndex = 32;
            this.btnquery.Text = "查询";
            this.btnquery.UseVisualStyleBackColor = true;
            this.btnquery.Click += new System.EventHandler(this.btnquery_Click);
            // 
            // btnreview
            // 
            this.btnreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnreview.BackgroundImage")));
            this.btnreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnreview.BorderColor = System.Drawing.Color.Empty;
            this.btnreview.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnreview.EnabledEx = false;
            this.btnreview.FlatAppearance.BorderSize = 0;
            this.btnreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreview.Location = new System.Drawing.Point(684, 33);
            this.btnreview.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            this.btnreview.Name = "btnreview";
            this.btnreview.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnreview.Picture_MouseDown")));
            this.btnreview.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnreview.Picture_MouseMove")));
            this.btnreview.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnreview.Picture_Normal")));
            this.btnreview.Size = new System.Drawing.Size(75, 23);
            this.btnreview.TabIndex = 41;
            this.btnreview.Text = "供车";
            this.btnreview.UseVisualStyleBackColor = true;
            this.btnreview.Click += new System.EventHandler(this.btnreview_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 80);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // FormSupplyCarMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 254);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSupplyCarMgr";
            this.Text = "供车";
            this.Load += new System.EventHandler(this.FormSupplyCarMgr_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtplancode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private Tools.DataGridViewEx dgvList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colcheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStart;
        private System.Windows.Forms.Label label6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStop;
        private Common.ButtonEx btnquery;
        private Common.ButtonEx btnreview;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.IntegerInput txtplancode;



    }
}