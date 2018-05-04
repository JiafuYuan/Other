namespace VehicleTransportClient.UI
{
    partial class FormLoadCarEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadCarEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPlanCode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btndetail = new Common.ButtonEx();
            this.txtAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvList = new VehicleTransportClient.Tools.DataGridViewEx();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterieTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPerson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelWorkArea.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.dgvList);
            this.panelWorkArea.Controls.Add(this.panel4);
            this.panelWorkArea.Controls.Add(this.toolStrip1);
            this.panelWorkArea.Size = new System.Drawing.Size(563, 310);
            // 
            // panelTitle
            // 
            this.panelTitle.Location = new System.Drawing.Point(59, 0);
            this.panelTitle.Size = new System.Drawing.Size(412, 28);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDel,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(563, 25);
            this.toolStrip1.TabIndex = 58;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::VehicleTransportClient.Properties.Resources.添加;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 22);
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::VehicleTransportClient.Properties.Resources.Modify;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(52, 22);
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::VehicleTransportClient.Properties.Resources.delete;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(52, 22);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::VehicleTransportClient.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 22);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.txtPerson);
            this.panel4.Controls.Add(this.txtPlanCode);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.dtTime);
            this.panel4.Controls.Add(this.btndetail);
            this.panel4.Controls.Add(this.txtAddress);
            this.panel4.Controls.Add(this.txtMemo);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(563, 100);
            this.panel4.TabIndex = 59;
            // 
            // txtPlanCode
            // 
            this.txtPlanCode.AutoSize = true;
            this.txtPlanCode.Location = new System.Drawing.Point(79, 16);
            this.txtPlanCode.Name = "txtPlanCode";
            this.txtPlanCode.Size = new System.Drawing.Size(41, 12);
            this.txtPlanCode.TabIndex = 87;
            this.txtPlanCode.Text = "运单号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(232, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 86;
            this.label6.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(469, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 85;
            this.label4.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(232, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 84;
            this.label10.Text = "*";
            // 
            // dtTime
            // 
            // 
            // 
            // 
            this.dtTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtTime.ButtonDropDown.Visible = true;
            this.dtTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtTime.IsPopupCalendarOpen = false;
            this.dtTime.Location = new System.Drawing.Point(81, 68);
            // 
            // 
            // 
            this.dtTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtTime.MonthCalendar.BackgroundStyle.Class = "";
            this.dtTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtTime.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTime.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtTime.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTime.MonthCalendar.TodayButtonVisible = true;
            this.dtTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtTime.Name = "dtTime";
            this.dtTime.Size = new System.Drawing.Size(145, 21);
            this.dtTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtTime.TabIndex = 83;
            // 
            // btndetail
            // 
            this.btndetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndetail.BackgroundImage")));
            this.btndetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndetail.BorderColor = System.Drawing.Color.Empty;
            this.btndetail.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btndetail.EnabledEx = false;
            this.btndetail.FlatAppearance.BorderSize = 0;
            this.btndetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndetail.Location = new System.Drawing.Point(388, 11);
            this.btndetail.Name = "btndetail";
            this.btndetail.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btndetail.Picture_MouseDown")));
            this.btndetail.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btndetail.Picture_MouseMove")));
            this.btndetail.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btndetail.Picture_Normal")));
            this.btndetail.Size = new System.Drawing.Size(75, 23);
            this.btndetail.TabIndex = 82;
            this.btndetail.Text = "详细信息";
            this.btndetail.UseVisualStyleBackColor = true;
            this.btndetail.Click += new System.EventHandler(this.btndetail_Click);
            // 
            // txtAddress
            // 
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddress.Location = new System.Drawing.Point(315, 40);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(148, 21);
            this.txtAddress.TabIndex = 81;
            this.txtAddress.Click += new System.EventHandler(this.txtAddress_Click);
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(315, 70);
            this.txtMemo.MaxLength = 20;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(148, 21);
            this.txtMemo.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(251, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 78;
            this.label5.Text = "备    注:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(17, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 74;
            this.label3.Text = "装车时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(250, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 72;
            this.label2.Text = "装车地点:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 70;
            this.label1.Text = "装车人:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(17, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "运单号:";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AlternatingRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvList.ColumnHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.VehicleID,
            this.MaterieTypeID,
            this.Column1});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvList.Location = new System.Drawing.Point(0, 125);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowsDefaultBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvList.RowsDefaultSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(175)))), ((int)(((byte)(225)))));
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(563, 185);
            this.dgvList.TabIndex = 60;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // 序号
            // 
            this.序号.FillWeight = 30.55624F;
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            // 
            // VehicleID
            // 
            this.VehicleID.FillWeight = 123.0476F;
            this.VehicleID.HeaderText = "车辆编号";
            this.VehicleID.Name = "VehicleID";
            this.VehicleID.ReadOnly = true;
            // 
            // MaterieTypeID
            // 
            this.MaterieTypeID.FillWeight = 122.78F;
            this.MaterieTypeID.HeaderText = "物料类型";
            this.MaterieTypeID.Name = "MaterieTypeID";
            this.MaterieTypeID.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle13.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column1.FillWeight = 124.9214F;
            this.Column1.HeaderText = "数量";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // txtPerson
            // 
            // 
            // 
            // 
            this.txtPerson.Border.Class = "TextBoxBorder";
            this.txtPerson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPerson.Location = new System.Drawing.Point(81, 40);
            this.txtPerson.MaxLength = 50;
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(145, 21);
            this.txtPerson.TabIndex = 90;
            this.txtPerson.Click += new System.EventHandler(this.txtPerson_Click);
            // 
            // FormLoadCarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 340);
            this.FormTitle = "装车";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormLoadCarEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "装车";
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Tools.DataGridViewEx dgvList;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress;
        private Common.ButtonEx btndetail;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtPlanCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterieTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPerson;


    }
}