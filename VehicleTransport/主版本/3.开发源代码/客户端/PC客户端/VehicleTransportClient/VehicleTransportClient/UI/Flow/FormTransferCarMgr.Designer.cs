namespace VehicleTransportClient.UI
{
    partial class FormTransferCarMgr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTransferCarMgr));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvList = new VehicleTransportClient.Tools.DataGridViewEx();
            this.colcheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtplancode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.dtStop = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnreview = new Common.ButtonEx();
            this.btnquery = new Common.ButtonEx();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).BeginInit();
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
            this.groupPanel1.Size = new System.Drawing.Size(730, 216);
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
            this.Column2});
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
            this.dgvList.Size = new System.Drawing.Size(724, 152);
            this.dgvList.TabIndex = 20;
            // 
            // colcheck
            // 
            this.colcheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colcheck.FillWeight = 35.53299F;
            this.colcheck.HeaderText = "序号";
            this.colcheck.Name = "colcheck";
            this.colcheck.ReadOnly = true;
            this.colcheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colcheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colcheck.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 110.7445F;
            this.dataGridViewTextBoxColumn1.HeaderText = "运单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 110.7445F;
            this.Column4.HeaderText = "申请部门";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 110.7445F;
            this.Column5.HeaderText = "申请人";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 110.7445F;
            this.Column3.HeaderText = "目的地";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 110.7445F;
            this.Column7.HeaderText = "计划到货时间";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 110.7445F;
            this.Column2.HeaderText = "当前状态";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtplancode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtStop);
            this.panel1.Controls.Add(this.dtStart);
            this.panel1.Controls.Add(this.btnreview);
            this.panel1.Controls.Add(this.btnquery);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 58);
            this.panel1.TabIndex = 19;
            // 
            // txtplancode
            // 
            // 
            // 
            // 
            this.txtplancode.Border.Class = "TextBoxBorder";
            this.txtplancode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtplancode.Location = new System.Drawing.Point(410, 14);
            this.txtplancode.MaxLength = 20;
            this.txtplancode.Name = "txtplancode";
            this.txtplancode.Size = new System.Drawing.Size(123, 21);
            this.txtplancode.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "运单号";
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
            this.dtStop.Location = new System.Drawing.Point(253, 15);
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
            this.dtStop.Size = new System.Drawing.Size(107, 21);
            this.dtStop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtStop.TabIndex = 9;
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
            this.dtStart.Location = new System.Drawing.Point(81, 15);
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
            this.dtStart.Size = new System.Drawing.Size(107, 21);
            this.dtStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtStart.TabIndex = 8;
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
            this.btnreview.Location = new System.Drawing.Point(645, 12);
            this.btnreview.Name = "btnreview";
            this.btnreview.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnreview.Picture_MouseDown")));
            this.btnreview.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnreview.Picture_MouseMove")));
            this.btnreview.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnreview.Picture_Normal")));
            this.btnreview.Size = new System.Drawing.Size(75, 23);
            this.btnreview.TabIndex = 7;
            this.btnreview.Text = "交接车";
            this.btnreview.UseVisualStyleBackColor = true;
            this.btnreview.Click += new System.EventHandler(this.btnreview_Click);
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
            this.btnquery.Location = new System.Drawing.Point(549, 13);
            this.btnquery.Name = "btnquery";
            this.btnquery.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnquery.Picture_MouseDown")));
            this.btnquery.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnquery.Picture_MouseMove")));
            this.btnquery.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnquery.Picture_Normal")));
            this.btnquery.Size = new System.Drawing.Size(75, 23);
            this.btnquery.TabIndex = 6;
            this.btnquery.Text = "查询";
            this.btnquery.UseVisualStyleBackColor = true;
            this.btnquery.Click += new System.EventHandler(this.btnquery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "结束时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开始时间";
            // 
            // FormTransferCarMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 216);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTransferCarMgr";
            this.Text = "交接车";
            this.Load += new System.EventHandler(this.FormTransferCarMgr_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Panel panel1;
        private Common.ButtonEx btnreview;
        private Common.ButtonEx btnquery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStop;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStart;
        private DevComponents.DotNetBar.Controls.TextBoxX txtplancode;
        private System.Windows.Forms.Label label3;
        private Tools.DataGridViewEx dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}