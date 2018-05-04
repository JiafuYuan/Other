namespace Ticketer
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.trainNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arriveStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardSleeper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softSleeper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.softSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highRankingSoftSleeper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trainNum,
            this.startStation,
            this.arriveStation,
            this.useTime,
            this.hardSleeper,
            this.softSleeper,
            this.secondSeat,
            this.firstSeat,
            this.hardSeat,
            this.softSeat,
            this.noSeat,
            this.specialSeat,
            this.highRankingSoftSleeper});
            this.dataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(729, 249);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // trainNum
            // 
            this.trainNum.DataPropertyName = "trainNum";
            this.trainNum.HeaderText = "车次";
            this.trainNum.Name = "trainNum";
            this.trainNum.ReadOnly = true;
            // 
            // startStation
            // 
            this.startStation.DataPropertyName = "startStation";
            this.startStation.HeaderText = "出发地";
            this.startStation.Name = "startStation";
            this.startStation.ReadOnly = true;
            // 
            // arriveStation
            // 
            this.arriveStation.DataPropertyName = "arriveStation";
            this.arriveStation.HeaderText = "目的地";
            this.arriveStation.Name = "arriveStation";
            this.arriveStation.ReadOnly = true;
            // 
            // useTime
            // 
            this.useTime.DataPropertyName = "useTime";
            this.useTime.HeaderText = "历时";
            this.useTime.Name = "useTime";
            this.useTime.ReadOnly = true;
            // 
            // hardSleeper
            // 
            this.hardSleeper.DataPropertyName = "hardSleeper";
            this.hardSleeper.HeaderText = "硬卧";
            this.hardSleeper.Name = "hardSleeper";
            this.hardSleeper.ReadOnly = true;
            // 
            // softSleeper
            // 
            this.softSleeper.DataPropertyName = "softSleeper";
            this.softSleeper.HeaderText = "软卧";
            this.softSleeper.Name = "softSleeper";
            this.softSleeper.ReadOnly = true;
            // 
            // secondSeat
            // 
            this.secondSeat.DataPropertyName = "secondSeat";
            this.secondSeat.HeaderText = "二等座";
            this.secondSeat.Name = "secondSeat";
            this.secondSeat.ReadOnly = true;
            // 
            // firstSeat
            // 
            this.firstSeat.DataPropertyName = "firstSeat";
            this.firstSeat.HeaderText = "一等座";
            this.firstSeat.Name = "firstSeat";
            this.firstSeat.ReadOnly = true;
            // 
            // hardSeat
            // 
            this.hardSeat.DataPropertyName = "hardSeat";
            this.hardSeat.HeaderText = "硬座";
            this.hardSeat.Name = "hardSeat";
            this.hardSeat.ReadOnly = true;
            // 
            // softSeat
            // 
            this.softSeat.DataPropertyName = "softSeat";
            this.softSeat.HeaderText = "软座";
            this.softSeat.Name = "softSeat";
            this.softSeat.ReadOnly = true;
            // 
            // noSeat
            // 
            this.noSeat.DataPropertyName = "noSeat";
            this.noSeat.HeaderText = "无座";
            this.noSeat.Name = "noSeat";
            this.noSeat.ReadOnly = true;
            // 
            // specialSeat
            // 
            this.specialSeat.DataPropertyName = "specialSeat";
            this.specialSeat.HeaderText = "特等座";
            this.specialSeat.Name = "specialSeat";
            this.specialSeat.ReadOnly = true;
            // 
            // highRankingSoftSleeper
            // 
            this.highRankingSoftSleeper.DataPropertyName = "highRankingSoftSleeper";
            this.highRankingSoftSleeper.HeaderText = "高级软卧";
            this.highRankingSoftSleeper.Name = "highRankingSoftSleeper";
            this.highRankingSoftSleeper.ReadOnly = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(13, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(79, 172);
            this.listBox1.TabIndex = 6;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 42);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(93, 180);
            this.checkedListBox1.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(419, 299);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(322, 232);
            this.textBox4.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "自动订票";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(98, 32);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(82, 172);
            this.listBox2.TabIndex = 13;
            this.listBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseClick);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(297, 23);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(98, 196);
            this.checkedListBox2.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(666, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(438, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(240, 8);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 21);
            this.textBox3.TabIndex = 4;
            this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 12;
            this.listBox3.Location = new System.Drawing.Point(56, 29);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(131, 184);
            this.listBox3.TabIndex = 16;
            this.listBox3.Visible = false;
            this.listBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox3_MouseClick);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(544, 10);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(120, 16);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "过滤不可预定车次";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(56, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(131, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(437, 29);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "出发地：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "目的地：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "出发日期：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.checkedListBox2);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 299);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 232);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动订票设置";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.listBox2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(105, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 211);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "预订车次选择";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "可预订车次";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "已选车次";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 543);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "winform";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn trainNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn startStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn arriveStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn useTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardSleeper;
        private System.Windows.Forms.DataGridViewTextBoxColumn softSleeper;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn softSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn noSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn specialSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn highRankingSoftSleeper;
    }
}