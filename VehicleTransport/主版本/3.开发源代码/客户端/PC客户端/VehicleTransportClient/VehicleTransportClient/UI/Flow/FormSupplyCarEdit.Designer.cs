namespace VehicleTransportClient.UI
{
    partial class FormSupplyCarEdit
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPerson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtgiven = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtplancode = new System.Windows.Forms.Label();
            this.txtsupply = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtmemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.btnsave = new System.Windows.Forms.ToolStripButton();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcartypeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcartypename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colplannumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelWorkArea.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgiven)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.dgvList);
            this.panelWorkArea.Controls.Add(this.panel4);
            this.panelWorkArea.Controls.Add(this.toolStrip1);
            this.panelWorkArea.Size = new System.Drawing.Size(598, 310);
            // 
            // panelTitle
            // 
            this.panelTitle.Location = new System.Drawing.Point(59, 0);
            this.panelTitle.Size = new System.Drawing.Size(447, 28);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.txtPerson);
            this.panel4.Controls.Add(this.dtgiven);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.txtplancode);
            this.panel4.Controls.Add(this.txtsupply);
            this.panel4.Controls.Add(this.txtmemo);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(598, 116);
            this.panel4.TabIndex = 62;
            // 
            // txtPerson
            // 
            // 
            // 
            // 
            this.txtPerson.Border.Class = "TextBoxBorder";
            this.txtPerson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPerson.Location = new System.Drawing.Point(78, 42);
            this.txtPerson.MaxLength = 50;
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(171, 21);
            this.txtPerson.TabIndex = 89;
            this.txtPerson.Click += new System.EventHandler(this.txtPerson_Click);
            // 
            // dtgiven
            // 
            // 
            // 
            // 
            this.dtgiven.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtgiven.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtgiven.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtgiven.ButtonDropDown.Visible = true;
            this.dtgiven.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtgiven.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtgiven.IsPopupCalendarOpen = false;
            this.dtgiven.Location = new System.Drawing.Point(78, 75);
            // 
            // 
            // 
            this.dtgiven.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtgiven.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtgiven.MonthCalendar.BackgroundStyle.Class = "";
            this.dtgiven.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtgiven.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtgiven.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtgiven.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtgiven.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtgiven.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtgiven.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtgiven.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtgiven.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtgiven.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtgiven.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtgiven.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtgiven.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtgiven.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtgiven.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtgiven.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtgiven.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtgiven.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtgiven.MonthCalendar.TodayButtonVisible = true;
            this.dtgiven.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtgiven.Name = "dtgiven";
            this.dtgiven.Size = new System.Drawing.Size(171, 21);
            this.dtgiven.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtgiven.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(555, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 87;
            this.label6.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(269, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 86;
            this.label4.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(269, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 85;
            this.label10.Text = "*";
            // 
            // txtplancode
            // 
            this.txtplancode.AutoSize = true;
            this.txtplancode.Location = new System.Drawing.Point(78, 16);
            this.txtplancode.Name = "txtplancode";
            this.txtplancode.Size = new System.Drawing.Size(41, 12);
            this.txtplancode.TabIndex = 82;
            this.txtplancode.Text = "运单号";
            // 
            // txtsupply
            // 
            // 
            // 
            // 
            this.txtsupply.Border.Class = "TextBoxBorder";
            this.txtsupply.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtsupply.Location = new System.Drawing.Point(368, 42);
            this.txtsupply.MaxLength = 50;
            this.txtsupply.Name = "txtsupply";
            this.txtsupply.Size = new System.Drawing.Size(171, 21);
            this.txtsupply.TabIndex = 80;
            this.txtsupply.Click += new System.EventHandler(this.txtsupply_Click);
            // 
            // txtmemo
            // 
            this.txtmemo.Location = new System.Drawing.Point(367, 72);
            this.txtmemo.Name = "txtmemo";
            this.txtmemo.Size = new System.Drawing.Size(171, 21);
            this.txtmemo.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(303, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 78;
            this.label5.Text = "备    注:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(17, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 74;
            this.label3.Text = "供车时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(303, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 72;
            this.label2.Text = "供车地点:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 70;
            this.label1.Text = "供车人:";
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDel,
            this.btnsave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(598, 25);
            this.toolStrip1.TabIndex = 61;
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
            // btnDel
            // 
            this.btnDel.Image = global::VehicleTransportClient.Properties.Resources.delete;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(52, 22);
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnsave
            // 
            this.btnsave.Image = global::VehicleTransportClient.Properties.Resources.save;
            this.btnsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(52, 22);
            this.btnsave.Text = "保存";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeight = 35;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.colcartypeid,
            this.colcartypename,
            this.colplannumber,
            this.colnumber});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 141);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.RowTemplate.Height = 33;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(598, 169);
            this.dgvList.TabIndex = 63;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 101.5228F;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            // 
            // colcartypeid
            // 
            this.colcartypeid.HeaderText = "colcartypeid";
            this.colcartypeid.Name = "colcartypeid";
            this.colcartypeid.Visible = false;
            // 
            // colcartypename
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.colcartypename.DefaultCellStyle = dataGridViewCellStyle2;
            this.colcartypename.FillWeight = 99.49239F;
            this.colcartypename.HeaderText = "车辆类型";
            this.colcartypename.Name = "colcartypename";
            this.colcartypename.ReadOnly = true;
            // 
            // colplannumber
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.colplannumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.colplannumber.FillWeight = 99.49239F;
            this.colplannumber.HeaderText = "计划数量";
            this.colplannumber.Name = "colplannumber";
            this.colplannumber.ReadOnly = true;
            // 
            // colnumber
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.colnumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.colnumber.FillWeight = 99.49239F;
            this.colnumber.HeaderText = "数量";
            this.colnumber.Name = "colnumber";
            // 
            // FormSupplyCarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 340);
            this.FormTitle = "供车";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormSupplyCarEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "供车";
            this.Load += new System.EventHandler(this.FormSupplyCarEdit_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgiven)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtmemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripButton btnsave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtsupply;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label txtplancode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtgiven;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcartypeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcartypename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colplannumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnumber;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPerson;
    }
}