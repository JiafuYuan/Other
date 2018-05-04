namespace VehicleTransportClient.UI
{
    partial class FormLoadCarMgr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadCarMgr));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label6 = new System.Windows.Forms.Label();
            this.dtStop = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label1 = new System.Windows.Forms.Label();
            this.txtplancode = new DevComponents.Editors.IntegerInput();
            this.btnSearch = new Common.ButtonEx();
            this.btnreview = new Common.ButtonEx();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtplancode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dgvList);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 498);
            this.panel2.TabIndex = 2;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(248)))), ((int)(((byte)(251)))));
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeight = 35;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colck,
            this.dataGridViewTextBoxColumn1,
            this.Column8,
            this.Column9,
            this.Column11,
            this.Column10,
            this.Column12,
            this.Column13,
            this.Column2});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.dgvList.Location = new System.Drawing.Point(0, 76);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvList.RowTemplate.Height = 33;
            this.dgvList.RowTemplate.ReadOnly = true;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1000, 422);
            this.dgvList.TabIndex = 22;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // colck
            // 
            this.colck.FillWeight = 36.994F;
            this.colck.HeaderText = "";
            this.colck.Name = "colck";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 98.82682F;
            this.dataGridViewTextBoxColumn1.HeaderText = "运单号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 98.82682F;
            this.Column8.HeaderText = "申请部门";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 98.82682F;
            this.Column9.HeaderText = "申请人";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.FillWeight = 98.82682F;
            this.Column11.HeaderText = "目的地";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.FillWeight = 98.82682F;
            this.Column10.HeaderText = "计划到达时间";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.FillWeight = 98.82682F;
            this.Column12.HeaderText = "计划装车部门";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.FillWeight = 98.82682F;
            this.Column13.HeaderText = "计划装车地点";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "状态";
            this.Column2.Name = "Column2";
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
            this.panel3.Size = new System.Drawing.Size(1000, 76);
            this.panel3.TabIndex = 20;
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
            this.flowLayoutPanel1.Controls.Add(this.btnSearch);
            this.flowLayoutPanel1.Controls.Add(this.btnreview);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(41, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(949, 76);
            this.flowLayoutPanel1.TabIndex = 27;
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
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.BorderColor = System.Drawing.Color.Empty;
            this.btnSearch.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnSearch.EnabledEx = false;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(603, 33);
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
            this.btnreview.Text = "装车";
            this.btnreview.UseVisualStyleBackColor = true;
            this.btnreview.Click += new System.EventHandler(this.btnreview_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(990, 0);
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
            // FormLoadCarMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 522);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLoadCarMgr";
            this.Text = "装车";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtplancode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStart;
        private System.Windows.Forms.Label label6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStop;
        private System.Windows.Forms.Label label1;
        private DevComponents.Editors.IntegerInput txtplancode;
        private Common.ButtonEx btnSearch;
        private Common.ButtonEx btnreview;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colck;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}