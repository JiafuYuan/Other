namespace VehicleTransportClient
{
    partial class FormCheckReport
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtplancode = new DevComponents.Editors.IntegerInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDept = new DevComponents.DotNetBar.Controls.ComboTree();
            this.label1 = new System.Windows.Forms.Label();
            this.dtInputStop = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtInputStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnStyleGrid = new System.Windows.Forms.ToolStripButton();
            this.btnDesignReport = new System.Windows.Forms.ToolStripButton();
            this.btnPrintreport = new System.Windows.Forms.ToolStripButton();
            this.dateTimeInput1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvList = new VehicleTransportClient.Tools.DataGridViewEx();
            this.运单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.审核时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.申请部门 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.申请人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.申请内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.目的地 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.计划到货时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.计划供车部门 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.计划供车地点 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.计划供车时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtplancode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInputStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInputStart)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dgvList);
            this.groupPanel1.Controls.Add(this.statusStrip1);
            this.groupPanel1.Controls.Add(this.panel1);
            this.groupPanel1.Controls.Add(this.toolStrip2);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(980, 360);
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
            this.groupPanel1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtplancode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbDept);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtInputStop);
            this.panel1.Controls.Add(this.dtInputStart);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 33);
            this.panel1.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(684, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 72;
            this.label4.Text = "运单号：";
            // 
            // txtplancode
            // 
            // 
            // 
            // 
            this.txtplancode.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtplancode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtplancode.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtplancode.Location = new System.Drawing.Point(739, 7);
            this.txtplancode.Margin = new System.Windows.Forms.Padding(3, 33, 3, 3);
            this.txtplancode.Name = "txtplancode";
            this.txtplancode.Size = new System.Drawing.Size(120, 21);
            this.txtplancode.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 69;
            this.label3.Text = "审核开始时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(240, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 68;
            this.label2.Text = "审核结束时间：";
            // 
            // cmbDept
            // 
            this.cmbDept.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cmbDept.BackgroundStyle.Class = "TextBoxBorder";
            this.cmbDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cmbDept.ButtonDropDown.Visible = true;
            this.cmbDept.DropDownHeight = 200;
            this.cmbDept.Location = new System.Drawing.Point(533, 6);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(145, 21);
            this.cmbDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbDept.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(486, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 67;
            this.label1.Text = "部门：";
            // 
            // dtInputStop
            // 
            // 
            // 
            // 
            this.dtInputStop.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtInputStop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInputStop.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtInputStop.ButtonDropDown.Visible = true;
            this.dtInputStop.CustomFormat = "yyyy-MM-dd";
            this.dtInputStop.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtInputStop.IsPopupCalendarOpen = false;
            this.dtInputStop.Location = new System.Drawing.Point(331, 6);
            // 
            // 
            // 
            this.dtInputStop.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtInputStop.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtInputStop.MonthCalendar.BackgroundStyle.Class = "";
            this.dtInputStop.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.dtInputStop.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtInputStop.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInputStop.MonthCalendar.DisplayMonth = new System.DateTime(2014, 8, 1, 0, 0, 0, 0);
            this.dtInputStop.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtInputStop.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtInputStop.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtInputStop.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInputStop.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtInputStop.Name = "dtInputStop";
            this.dtInputStop.Size = new System.Drawing.Size(145, 21);
            this.dtInputStop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtInputStop.TabIndex = 14;
            // 
            // dtInputStart
            // 
            // 
            // 
            // 
            this.dtInputStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtInputStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInputStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtInputStart.ButtonDropDown.Visible = true;
            this.dtInputStart.CustomFormat = "yyyy-MM-dd";
            this.dtInputStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtInputStart.IsPopupCalendarOpen = false;
            this.dtInputStart.Location = new System.Drawing.Point(91, 6);
            // 
            // 
            // 
            this.dtInputStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtInputStart.MonthCalendar.BackgroundStyle.Class = "";
            this.dtInputStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.dtInputStart.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtInputStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInputStart.MonthCalendar.DisplayMonth = new System.DateTime(2014, 11, 1, 0, 0, 0, 0);
            this.dtInputStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtInputStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtInputStart.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtInputStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtInputStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtInputStart.Name = "dtInputStart";
            this.dtInputStart.Size = new System.Drawing.Size(145, 21);
            this.dtInputStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtInputStart.TabIndex = 13;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(880, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStyleGrid,
            this.btnDesignReport,
            this.btnPrintreport});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(974, 25);
            this.toolStrip2.TabIndex = 15;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnStyleGrid
            // 
            this.btnStyleGrid.Image = global::VehicleTransportClient.Properties.Resources.GridStyle;
            this.btnStyleGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStyleGrid.Name = "btnStyleGrid";
            this.btnStyleGrid.Size = new System.Drawing.Size(52, 22);
            this.btnStyleGrid.Text = "样式";
            this.btnStyleGrid.Click += new System.EventHandler(this.btnStyle_Click);
            // 
            // btnDesignReport
            // 
            this.btnDesignReport.Image = global::VehicleTransportClient.Properties.Resources.Modify;
            this.btnDesignReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesignReport.Name = "btnDesignReport";
            this.btnDesignReport.Size = new System.Drawing.Size(52, 22);
            this.btnDesignReport.Text = "设计";
            this.btnDesignReport.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // btnPrintreport
            // 
            this.btnPrintreport.Image = global::VehicleTransportClient.Properties.Resources.日报表;
            this.btnPrintreport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintreport.Name = "btnPrintreport";
            this.btnPrintreport.Size = new System.Drawing.Size(52, 22);
            this.btnPrintreport.Text = "打印";
            this.btnPrintreport.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dateTimeInput1
            // 
            // 
            // 
            // 
            this.dateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput1.ButtonDropDown.Visible = true;
            this.dateTimeInput1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeInput1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dateTimeInput1.IsPopupCalendarOpen = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(177, 7);
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.Class = "";
            this.dateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.DisplayMonth = new System.DateTime(2014, 8, 1, 0, 0, 0, 0);
            this.dateTimeInput1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput1.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(180, 21);
            this.dateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput1.TabIndex = 11;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(126, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = " 开始时间：";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "井下";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "井上";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 332);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(974, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(15, 17);
            this.lblCount.Text = "0";
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
            this.运单号,
            this.审核时间,
            this.申请部门,
            this.申请人,
            this.申请内容,
            this.目的地,
            this.计划到货时间,
            this.计划供车部门,
            this.计划供车地点,
            this.计划供车时间});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvList.Location = new System.Drawing.Point(0, 58);
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
            this.dgvList.Size = new System.Drawing.Size(974, 274);
            this.dgvList.TabIndex = 19;
            // 
            // 运单号
            // 
            this.运单号.DataPropertyName = "vc_PlanCode";
            this.运单号.FillWeight = 105.471F;
            this.运单号.HeaderText = "运单号";
            this.运单号.Name = "运单号";
            this.运单号.ReadOnly = true;
            // 
            // 审核时间
            // 
            this.审核时间.DataPropertyName = "dt_CheckDateTime";
            this.审核时间.HeaderText = "审核时间";
            this.审核时间.Name = "审核时间";
            this.审核时间.ReadOnly = true;
            // 
            // 申请部门
            // 
            this.申请部门.DataPropertyName = "ApplyDepartmentName";
            this.申请部门.FillWeight = 105.471F;
            this.申请部门.HeaderText = "申请部门";
            this.申请部门.Name = "申请部门";
            this.申请部门.ReadOnly = true;
            // 
            // 申请人
            // 
            this.申请人.DataPropertyName = "ApplyPersonName";
            this.申请人.FillWeight = 105.471F;
            this.申请人.HeaderText = "申请人";
            this.申请人.Name = "申请人";
            this.申请人.ReadOnly = true;
            // 
            // 申请内容
            // 
            this.申请内容.HeaderText = "申请内容";
            this.申请内容.Name = "申请内容";
            this.申请内容.ReadOnly = true;
            // 
            // 目的地
            // 
            this.目的地.DataPropertyName = "ArriveDestinationAddressName";
            this.目的地.FillWeight = 105.471F;
            this.目的地.HeaderText = "目的地";
            this.目的地.Name = "目的地";
            this.目的地.ReadOnly = true;
            // 
            // 计划到货时间
            // 
            this.计划到货时间.DataPropertyName = "dt_ArriveDestinationDateTime";
            this.计划到货时间.FillWeight = 105.471F;
            this.计划到货时间.HeaderText = "计划到货时间";
            this.计划到货时间.Name = "计划到货时间";
            this.计划到货时间.ReadOnly = true;
            // 
            // 计划供车部门
            // 
            this.计划供车部门.DataPropertyName = "PlanGiveCarDepartmentName";
            this.计划供车部门.FillWeight = 105.471F;
            this.计划供车部门.HeaderText = "计划供车部门";
            this.计划供车部门.Name = "计划供车部门";
            this.计划供车部门.ReadOnly = true;
            // 
            // 计划供车地点
            // 
            this.计划供车地点.DataPropertyName = "PlanGiveCarAddressName";
            this.计划供车地点.FillWeight = 105.471F;
            this.计划供车地点.HeaderText = "计划供车地点";
            this.计划供车地点.Name = "计划供车地点";
            this.计划供车地点.ReadOnly = true;
            // 
            // 计划供车时间
            // 
            this.计划供车时间.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.计划供车时间.DataPropertyName = "dt_PlanGiveCarDateTime";
            this.计划供车时间.FillWeight = 105.471F;
            this.计划供车时间.HeaderText = "计划供车时间";
            this.计划供车时间.Name = "计划供车时间";
            this.计划供车时间.ReadOnly = true;
            // 
            // FormCheckReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 360);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCheckReport";
            this.Text = "审核信息报表";
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtplancode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInputStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInputStart)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnDesignReport;
        private System.Windows.Forms.ToolStripButton btnPrintreport;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtInputStop;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtInputStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboTree cmbDept;
        private System.Windows.Forms.Label label1;
        private Tools.DataGridViewEx dgvList;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.IntegerInput txtplancode;
        private System.Windows.Forms.ToolStripButton btnStyleGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn 运单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 审核时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 申请部门;
        private System.Windows.Forms.DataGridViewTextBoxColumn 申请人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 申请内容;
        private System.Windows.Forms.DataGridViewTextBoxColumn 目的地;
        private System.Windows.Forms.DataGridViewTextBoxColumn 计划到货时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 计划供车部门;
        private System.Windows.Forms.DataGridViewTextBoxColumn 计划供车地点;
        private System.Windows.Forms.DataGridViewTextBoxColumn 计划供车时间;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
    }
}