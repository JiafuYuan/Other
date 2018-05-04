namespace VehicleTransportClient.UI
{
    partial class FormTransferCarEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.btnsave = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPerson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtplancode = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmatername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colplannumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelWorkArea.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.dgvList);
            this.panelWorkArea.Controls.Add(this.panel4);
            this.panelWorkArea.Controls.Add(this.toolStrip1);
            // 
            // panelTitle
            // 
            this.panelTitle.Location = new System.Drawing.Point(71, 0);
            this.panelTitle.Size = new System.Drawing.Size(315, 28);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDel,
            this.btnsave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(478, 25);
            this.toolStrip1.TabIndex = 62;
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.txtPerson);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.dtTime);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtplancode);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(478, 80);
            this.panel4.TabIndex = 63;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(218, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 86;
            this.label10.Text = "*";
            // 
            // txtPerson
            // 
            // 
            // 
            // 
            this.txtPerson.Border.Class = "TextBoxBorder";
            this.txtPerson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPerson.Location = new System.Drawing.Point(73, 39);
            this.txtPerson.MaxLength = 50;
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(145, 21);
            this.txtPerson.TabIndex = 36;
            this.txtPerson.Click += new System.EventHandler(this.txtPerson_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "交接人：";
            // 
            // dtTime
            // 
            this.dtTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTime.Location = new System.Drawing.Point(299, 39);
            this.dtTime.Name = "dtTime";
            this.dtTime.Size = new System.Drawing.Size(157, 21);
            this.dtTime.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(235, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "到达时间：";
            // 
            // txtplancode
            // 
            this.txtplancode.AutoSize = true;
            this.txtplancode.Location = new System.Drawing.Point(71, 15);
            this.txtplancode.Name = "txtplancode";
            this.txtplancode.Size = new System.Drawing.Size(41, 12);
            this.txtplancode.TabIndex = 24;
            this.txtplancode.Text = "运单号";
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
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvList.ColumnHeadersHeight = 35;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.colcarcode,
            this.colmatername,
            this.colplannumber,
            this.colnumber});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 105);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.RowTemplate.Height = 33;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(478, 205);
            this.dgvList.TabIndex = 64;
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            // 
            // colcarcode
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.colcarcode.DefaultCellStyle = dataGridViewCellStyle6;
            this.colcarcode.HeaderText = "车辆编号";
            this.colcarcode.Name = "colcarcode";
            this.colcarcode.ReadOnly = true;
            // 
            // colmatername
            // 
            this.colmatername.HeaderText = "物料类型";
            this.colmatername.Name = "colmatername";
            this.colmatername.ReadOnly = true;
            // 
            // colplannumber
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.colplannumber.DefaultCellStyle = dataGridViewCellStyle7;
            this.colplannumber.HeaderText = "数量";
            this.colplannumber.Name = "colplannumber";
            this.colplannumber.ReadOnly = true;
            // 
            // colnumber
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.colnumber.DefaultCellStyle = dataGridViewCellStyle8;
            this.colnumber.HeaderText = "当前数量";
            this.colnumber.Name = "colnumber";
            // 
            // FormTransferCarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 340);
            this.FormTitle = "交接车";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormTransferCarEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "交接车";
            this.Load += new System.EventHandler(this.FormTransferCarEdit_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripButton btnsave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmatername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colplannumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnumber;
        private System.Windows.Forms.Label txtplancode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
    }
}