using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace VehicleTransportClient.Tools
{
    public class DataGridViewEx : DataGridView
    {
        System.Windows.Forms.DataGridViewCellStyle _alternatingRowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();//奇数行
        System.Windows.Forms.DataGridViewCellStyle _columnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();//列头
        System.Windows.Forms.DataGridViewCellStyle _rowHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
        private DataGridViewMultiColumn dataGridViewMultiColumn1;
        private IContainer components;//行头
        System.Windows.Forms.DataGridViewCellStyle _rowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();//默认行

        #region 属性

        [Description("选中后的背景色")]
        public Color SelectedBackColor
        {
            get { return _alternatingRowsDefaultCellStyle.SelectionBackColor; }
            set
            {
                _alternatingRowsDefaultCellStyle.SelectionBackColor = value;
                _columnHeadersDefaultCellStyle.SelectionBackColor = value;
                _columnHeadersDefaultCellStyle.SelectionBackColor = value;
                _rowHeadersDefaultCellStyle.SelectionBackColor = value;
                _rowsDefaultCellStyle.SelectionBackColor = value;
            }
        }

        [Description("基数行的背景色")]
        public Color AlternatingRowsBackColor
        {
            get { return _alternatingRowsDefaultCellStyle.BackColor; }
            set
            {
                _alternatingRowsDefaultCellStyle.BackColor = value;
            }
        }

        [Description("默认所有行的背景色")]
        public Color RowsDefaultBackColor { get { return _rowsDefaultCellStyle.BackColor; } set { _rowsDefaultCellStyle.BackColor = value; } }

        [Description("默认所有行选中后的前景色")]
        public Color RowsDefaultSelectForeColor { get { return _rowsDefaultCellStyle.SelectionForeColor; } set { _rowsDefaultCellStyle.SelectionForeColor = value; } }

        [Description("行头的背景色")]
        public Color RowHeadersDefaultBackColor
        {
            get { return _rowHeadersDefaultCellStyle.BackColor; }
            set
            {
                _rowHeadersDefaultCellStyle.BackColor = value;
            }
        }

        [Description("列头的背景色")]
        public Color ColumnHeadersDefaultBackColor
        {
            get { return _columnHeadersDefaultCellStyle.BackColor; }
            set
            {
                _columnHeadersDefaultCellStyle.BackColor = value;
            }
        }

        #endregion

        public DataGridViewEx()
        {

            //this.SelectedBackColor = System.Drawing.Color.FromArgb(254, 211, 128);
            this.SelectedBackColor = System.Drawing.Color.FromArgb(204, 249, 133);
            this.AlternatingRowsBackColor = System.Drawing.Color.FromArgb(236, 249, 254);
            this.RowsDefaultBackColor = System.Drawing.Color.White;
            this.RowsDefaultSelectForeColor = System.Drawing.Color.FromArgb(0, 41, 80);
            this.RowHeadersDefaultBackColor = System.Drawing.Color.FromArgb(175, 219, 231);
            this.ColumnHeadersDefaultBackColor = System.Drawing.Color.FromArgb(198, 232, 243);
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            #region 奇数行样式

            //_alternatingRowsDefaultCellStyle.BackColor = _alternatingRowsBackColor;
            //_alternatingRowsDefaultCellStyle.SelectionBackColor = _selectedBackColor;
            this.AlternatingRowsDefaultCellStyle = _alternatingRowsDefaultCellStyle;
            #endregion

            #region 列标题样式

            _columnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //dataGridViewCellStyle2.BackColor = _columnHeadersDefaultBackColor;
            _columnHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            _columnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            //_columnHeadersDefaultCellStyle.SelectionBackColor = _selectedBackColor;
            _columnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Transparent;
            _columnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = _columnHeadersDefaultCellStyle;
            #endregion

            #region 行标题样式

            _rowHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //_rowHeadersDefaultCellStyle.BackColor = _rowHeadersDefaultBackColor;
            _rowHeadersDefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            _rowHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.MidnightBlue;
            //_rowHeadersDefaultCellStyle.SelectionBackColor = _selectedBackColor;
            _rowHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            _rowHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RowHeadersDefaultCellStyle = _rowHeadersDefaultCellStyle;

            #endregion

            #region 行单元格默认样式

            //_rowsDefaultCellStyle.BackColor = _rowsDefaultBackColor;
            //_rowsDefaultCellStyle.SelectionBackColor = _selectedBackColor;
            //_rowsDefaultCellStyle.SelectionForeColor = _rowsDefaultSelectForeColor;
            this.RowsDefaultCellStyle = _rowsDefaultCellStyle;
            #endregion

            #region 基本设置
            this.AutoGenerateColumns = false;//不允许自动创建列
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;



            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BackgroundColor = System.Drawing.SystemColors.Info;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;

            this.ColumnHeadersHeight = 25;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.Location = new System.Drawing.Point(3, 55);
            this.MultiSelect = false;
            this.ReadOnly = true;

            this.RowHeadersVisible = false;

            this.RowTemplate.Height = 23;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            #endregion

            #region 订阅事件

            this.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataGridViewEx_DataBindingComplete);
            this.RowPrePaint += new DataGridViewRowPrePaintEventHandler(DataGridViewEx_RowPrePaint);

            #endregion
        }

        #region 处理事件
        void DataGridViewEx_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts = e.PaintParts ^ DataGridViewPaintParts.Focus; //取消选中后的虚线

        }

        void DataGridViewEx_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // this.ClearSelection();//清除选中行
        }

        #endregion

        /// <summary>增加列</summary>
        /// <param name="columnName"></param>
        /// <param name="headText"></param>
        public void AddColumns(string columnName, string headText)
        {
            this.Columns.Add(columnName, headText);
            this.Columns[columnName].DataPropertyName = columnName;
        }

        /// <summary>删除列</summary>
        /// <param name="columnName"></param>
        public void DelColumns(string columnName)
        {
            this.Columns.Remove(columnName);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewMultiColumn1 = new VehicleTransportClient.DataGridViewMultiColumn(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMultiColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMultiColumn1
            // 
            this.dataGridViewMultiColumn1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMultiColumn1.ColumnDeep = 1;
            this.dataGridViewMultiColumn1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMultiColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMultiColumn1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewMultiColumn1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMultiColumn1.Name = "dataGridViewMultiColumn1";
            this.dataGridViewMultiColumn1.RowTemplate.Height = 35;
            this.dataGridViewMultiColumn1.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewMultiColumn1.TabIndex = 0;
            // 
            // DataGridViewEx
            // 
            this.RowTemplate.Height = 23;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMultiColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }


    }
}
