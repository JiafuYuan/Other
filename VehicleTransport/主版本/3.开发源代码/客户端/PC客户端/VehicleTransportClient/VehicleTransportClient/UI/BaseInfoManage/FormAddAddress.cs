using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using DB_VehicleTransportManage;
using DB_VehicleTransportManage.Model;
using DevComponents.DotNetBar.Schedule;
using VehicleTransportClient.Com;
using BLL = DB_VehicleTransportManage.BLL;

namespace VehicleTransportClient
{

    public partial class FormAddAddress : frmBase
    {
        private string _tableName = "FormAddAddress";
        private int _selectIndex = -1;
        DB_VehicleTransportManage.Model.v_Kj222Localizer _vKj222Localizer = new DB_VehicleTransportManage.Model.v_Kj222Localizer();
        DB_VehicleTransportManage.Model.m_Address _mAddressmodel = new DB_VehicleTransportManage.Model.m_Address();
        BLL.v_Address bllVAddress = new BLL.v_Address();
        BLL.m_Address bllmAddress = new BLL.m_Address();
        private int _ID = 0;
        public FormAddAddress( int Id)
        {
            InitializeComponent();
            _ID = Id;
        }

        private void FormRuleManage_Load(object sender, EventArgs e)
        {
            this.FormTitle = "批量导入";
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvAllList);
            LoadData();
        }

        private void LoadData()
        {
            List<DB_VehicleTransportManage.Model.v_Kj222Localizer> lst = new DB_VehicleTransportManage.BLL.v_Kj222Localizer().GetModelList("i_Flag=0 and ID not in (select ISNULL(LocalizerStationID,0) as LocalizerStationID from m_Address where i_Flag=0)");

            dgvAllList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllList.AllowUserToAddRows = false;
            dgvAllList.ReadOnly = true;

            dgvAllList.Rows.Clear();
            if (!Pub.IsKj602)
            {
                dgvAllList.Columns["PHID"].Visible = false;
                dgvAllList.Columns["CHID"].Visible = false;
                foreach (DB_VehicleTransportManage.Model.v_Kj222Localizer item in lst)
                {
                    int i = dgvAllList.Rows.Add(false, item.vc_Name, "", "", item.i_HID);
                    dgvAllList.Rows[i].Tag = item;
                }
            }
            else
            {
                dgvAllList.Columns["oneHID"].Visible = false;
                foreach (DB_VehicleTransportManage.Model.v_Kj222Localizer item in lst)
                {
                    int i = dgvAllList.Rows.Add(false, item.vc_Name, item.i_ParentHID, item.i_HID, "");
                    dgvAllList.Rows[i].Tag = item;
                }
            }
            dgvAllList.ClearSelection();
            _selectIndex = -1;

        }




        /// <summary>刷新
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>Grid样式设置
        /// Grid样式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvAllList);
            LoadData();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            List<DB_VehicleTransportManage.Model.m_Address> listModels = new List<m_Address>();
            bool bState = true;
            DB.OleDbHelper.BeginTransaction();
            for (int i = 0; i < dgvAllList.Rows.Count; i++)
            {
                if ((bool)(dgvAllList.Rows[i].Cells["colCheck"].Value))
                {
                    try
                    {
                        GetModel(i);
                    }
                    catch (Exception ex)
                    {
                        Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DB.OleDbHelper.Rollback();
                        return;
                    }
                    _mAddressmodel.ID=bllmAddress.Add(_mAddressmodel);
                    if (_mAddressmodel.ID > 0)
                    {
                       listModels.Add(_mAddressmodel);
                        OperationLog.InsertSqlLog(EnumActionType.Add, "定位卡增加", _mAddressmodel.vc_Name);
                    }
                    else
                    {
                        bState = false;
                    }
                }

            }
            if (bState)
            {
                DB.OleDbHelper.Commit();
                Pub.GISForm.LoadGrid();
                foreach (var listModel in listModels)
                {
                    Pub.GisManage.AddFeature(EnumLayerName.定位基站, listModel, true);
                }
                Pub.GisManage.UpdataGisAndDBRemark();
                MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                DB.OleDbHelper.Rollback();
                MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetModel(int i)
        {
            _mAddressmodel=new m_Address();
            _vKj222Localizer = (DB_VehicleTransportManage.Model.v_Kj222Localizer)dgvAllList.Rows[i].Tag;
            _mAddressmodel.LocalizerStationID = _vKj222Localizer.ID;
            //判断基站是否存在
            if (bllmAddress.GetModelList(" i_flag=0 and LocalizerStationID=" + _mAddressmodel.LocalizerStationID + "").Count > 0)
            {
                throw new Exception("基站编号 【" + _mAddressmodel.LocalizerStationID + "】 已存在");
            }
            _mAddressmodel.AreaID = _ID;
            _mAddressmodel.i_IsUpMine = 0;
            _mAddressmodel.vc_Name = _vKj222Localizer.vc_Name;
            _mAddressmodel.i_IsDirectionStation = 0;
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAllList.Rows.Count; i++)
            {
                dgvAllList.Rows[i].Cells["colCheck"].Value = true;
            }
        }

        /// <summary>
        /// 全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnNoSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvAllList.Rows.Count; i++)
            {
                dgvAllList.Rows[i].Cells["colCheck"].Value = false;
            }
        }

        private void dgvAllList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAllList.Columns["colCheck"].Index == e.ColumnIndex)
            {
                if ((bool)dgvAllList.Rows[e.RowIndex].Cells["colCheck"].Value)
                {
                    dgvAllList.Rows[e.RowIndex].Cells["colCheck"].Value = false;
                }
                else
                {
                    dgvAllList.Rows[e.RowIndex].Cells["colCheck"].Value = true;
                }
            }
            
        }


    }
}
