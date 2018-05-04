using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using BLL=DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{
    public partial class FormVehicleManage : Form
    {
        private string _tableName = "FormVehicleManage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_Vehicle _model = new DB_VehicleTransportManage.Model.m_Vehicle();
        private BLL.m_Vehicle bllVehicle = new BLL.m_Vehicle();
        private BLL.m_VehicleType bllVehicleType = new BLL.m_VehicleType();
        private BLL.m_Department bllDepartment = new BLL.m_Department();
        private BLL.v_Kj222Localizer bllViewKj222Localizer = new BLL.v_Kj222Localizer();
        private BLL.m_Address bllAddress = new BLL.m_Address();
        private BLL.m_Card bllCard = new BLL.m_Card();
        public FormVehicleManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormVehicleManage_Load);
        }

        void FormVehicleManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_Vehicle> lst = new DB_VehicleTransportManage.BLL.m_Vehicle().GetModelList("i_flag=0");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_Vehicle item in lst)
            {
                string strState = "";
                switch ((EnumVehicleState)((int)item.i_State))
                {
                    case EnumVehicleState.Normal:
                        strState = "空车";
                        break;
                    case EnumVehicleState.Using:
                        strState = "重车";
                        break;
                    case EnumVehicleState.Maintaining:
                        strState = "在修";
                        break;
                    case EnumVehicleState.Scrap:
                        strState = "报废";
                        break;
                    default:
                        strState = "";
                        break;
                }

                int i = dgvList.Rows.Add(item.vc_Code, item.vc_Name,  bllVehicleType.GetVehicleTypeName((int)item.VehicleTypeID),
                    item.DepartmentID != null ? bllDepartment.GetName((int)item.DepartmentID) : "", 
                    strState, item.i_SafeLoad == 0 ? "" : item.i_SafeLoad.ToString(),
                    item.i_MaintainInterval == 0 ? "" : item.i_MaintainInterval.ToString(), item.dt_LastMaintainDateTIme, item.dt_ScrapDateTime,item.vc_Memo);
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count + "个车辆";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataSet dataSet=bllAddress.GetList("");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                new FormVehicle(Com.OperateTypeEnum.Add, null).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请在系统中添加基站！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Vehicle)dgvList.Rows[_selectIndex].Tag;
                if (MessageBoxEx.Show("确认要删除车辆 【" + _model.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //已经发卡车辆不允许删除【2014-10-29】
                    if (bllCard.VehicleCard(_model.ID))
                    {
                        MessageBoxEx.Show("当前车辆已经发卡，请撤销发卡后删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    //维护状态车辆不允许删除
                    if (bllVehicle.IsVehicleMainTain(_model.ID))
                    {
                        MessageBoxEx.Show("当前车辆正在维护，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    //正在使用车辆不允许删除
                    if (bllVehicle.IsVehicleUsed(_model.ID))
                    {
                        MessageBoxEx.Show("当前车辆正在使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    _model.i_Flag = 1;
                    if ((new DB_VehicleTransportManage.BLL.m_Vehicle()).Update(_model))
                    {
                        Pub.GISForm.LoadGrid();
                        Pub.GisManage.UpdataGisAndDBRemark();
                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        OperationLog.InsertSqlLog(EnumActionType.Delete, "车辆名称", _model.vc_Name);
                        LoadData();

                    }
                    else
                    {
                        MessageBoxEx.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("请选择要删除的车辆", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Vehicle)dgvList.Rows[_selectIndex].Tag;
                new FormVehicle(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的车辆", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }

     
    }
}
