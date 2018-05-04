namespace VehicleTransportClient.UI
{
    partial class FormSupplyCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSupplyCar));
            this.panelFull = new System.Windows.Forms.Panel();
            this.panelMater = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcartypeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcartypename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colplannumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnsave = new Common.ButtonEx();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsupply = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPerson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgiven = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelWorkArea.SuspendLayout();
            this.panelFull.SuspendLayout();
            this.panelMater.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.panelFull);
            this.panelWorkArea.Size = new System.Drawing.Size(642, 300);
            // 
            // panelTitle
            // 
            this.panelTitle.Location = new System.Drawing.Point(59, 0);
            this.panelTitle.Size = new System.Drawing.Size(491, 28);
            // 
            // panelFull
            // 
            this.panelFull.BackColor = System.Drawing.Color.White;
            this.panelFull.Controls.Add(this.panelMater);
            this.panelFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFull.Location = new System.Drawing.Point(0, 0);
            this.panelFull.Name = "panelFull";
            this.panelFull.Size = new System.Drawing.Size(642, 300);
            this.panelFull.TabIndex = 2;
            // 
            // panelMater
            // 
            this.panelMater.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMater.BackColor = System.Drawing.Color.White;
            this.panelMater.Controls.Add(this.panel11);
            this.panelMater.Controls.Add(this.panel3);
            this.panelMater.Controls.Add(this.panel7);
            this.panelMater.Controls.Add(this.panel9);
            this.panelMater.Location = new System.Drawing.Point(20, 16);
            this.panelMater.Name = "panelMater";
            this.panelMater.Size = new System.Drawing.Size(603, 268);
            this.panelMater.TabIndex = 3;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.dgvList);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 52);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(603, 173);
            this.panel11.TabIndex = 51;
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
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvList.RowTemplate.Height = 33;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(603, 173);
            this.dgvList.TabIndex = 64;
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
            this.colnumber.HeaderText = "数量(可编辑)";
            this.colnumber.MaxInputLength = 5;
            this.colnumber.Name = "colnumber";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 225);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(603, 43);
            this.panel3.TabIndex = 50;
            // 
            // btnsave
            // 
            this.btnsave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnsave.BackgroundImage")));
            this.btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsave.BorderColor = System.Drawing.Color.Empty;
            this.btnsave.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnsave.EnabledEx = false;
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Location = new System.Drawing.Point(518, 10);
            this.btnsave.Name = "btnsave";
            this.btnsave.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnsave.Picture_MouseDown")));
            this.btnsave.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnsave.Picture_MouseMove")));
            this.btnsave.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnsave.Picture_Normal")));
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 35;
            this.btnsave.Text = "确认";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 40);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(603, 12);
            this.panel7.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.pictureBox2);
            this.panel9.Controls.Add(this.pictureBox1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(603, 40);
            this.panel9.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.BackgroundImage = global::VehicleTransportClient.Properties.Resources.审核_PC_05;
            this.panel10.Controls.Add(this.label3);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.txtsupply);
            this.panel10.Controls.Add(this.txtPerson);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Controls.Add(this.dtgiven);
            this.panel10.Controls.Add(this.label11);
            this.panel10.Controls.Add(this.label10);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(10, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(583, 40);
            this.panel10.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(344, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 87;
            this.label3.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(159, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 86;
            this.label1.Text = "*";
            // 
            // txtsupply
            // 
            // 
            // 
            // 
            this.txtsupply.Border.Class = "TextBoxBorder";
            this.txtsupply.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtsupply.Location = new System.Drawing.Point(235, 10);
            this.txtsupply.MaxLength = 50;
            this.txtsupply.Name = "txtsupply";
            this.txtsupply.Size = new System.Drawing.Size(105, 21);
            this.txtsupply.TabIndex = 31;
            this.txtsupply.Click += new System.EventHandler(this.txtsupply_Click);
            // 
            // txtPerson
            // 
            // 
            // 
            // 
            this.txtPerson.Border.Class = "TextBoxBorder";
            this.txtPerson.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPerson.Location = new System.Drawing.Point(52, 10);
            this.txtPerson.MaxLength = 50;
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(105, 21);
            this.txtPerson.TabIndex = 32;
            this.txtPerson.Click += new System.EventHandler(this.txtPerson_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "供车人：";
            // 
            // dtgiven
            // 
            this.dtgiven.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtgiven.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtgiven.Location = new System.Drawing.Point(426, 10);
            this.dtgiven.Name = "dtgiven";
            this.dtgiven.Size = new System.Drawing.Size(147, 21);
            this.dtgiven.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(356, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "供车时间：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(176, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "供车地点：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = global::VehicleTransportClient.Properties.Resources.审核_PC_07;
            this.pictureBox2.Location = new System.Drawing.Point(593, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 40);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::VehicleTransportClient.Properties.Resources.审核_PC_03;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 40);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormSupplyCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 330);
            this.FormTitle = "供车";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormSupplyCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "供车";
            this.Load += new System.EventHandler(this.FormSupplyCar_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panelFull.ResumeLayout(false);
            this.panelMater.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFull;
        private System.Windows.Forms.Panel panelMater;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel3;
        private Common.ButtonEx btnsave;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtsupply;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtgiven;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcartypeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcartypename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colplannumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnumber;
    }
}