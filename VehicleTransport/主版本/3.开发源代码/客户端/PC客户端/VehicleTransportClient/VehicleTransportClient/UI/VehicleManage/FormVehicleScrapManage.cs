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
using DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{
    public partial class FormVehicleScrapManage : Form
    {
        private string _tableName = "FormVehicleScrapManage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_VehicleScrap _model = new DB_VehicleTransportManage.Model.m_VehicleScrap();
        private DB_VehicleTransportManage.BLL.m_Person bllPersonEx=new m_Person();
        private DB_VehicleTransportManage.BLL.m_Vehicle bllVehicle = new m_Vehicle();
        public FormVehicleScrapManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormVehicleScrapManage_Load);
        }

        void FormVehicleScrapManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_VehicleScrap> lst = new DB_VehicleTransportManage.BLL.m_VehicleScrap().GetModelList("i_flag=0");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_VehicleScrap item in lst)
            {

                int i = dgvList.Rows.Add(bllVehicle.GetVehicleNameAll((int)item.VehicleID)[0], bllVehicle.GetVehicleNameAll((int)item.VehicleID)[1], item.dt_DateTime == null ? "" : item.dt_DateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"), bllPersonEx.GetName((item.PersonID == null ? 0 : (int)item.PersonID)), item.vc_Memo);
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count + "个报废车辆";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataSet dataSet = bllVehicle.DropDownSource(" (i_State=0 or i_state=2)");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                new FormVehicleScrap(Com.OperateTypeEnum.Add, null).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("未找到可以报废的车辆！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                
                _model = (DB_VehicleTransportManage.Model.m_VehicleScrap)dgvList.Rows[_selectIndex].Tag;
                if (bllVehicle.GetVehicleName((int) _model.VehicleID)[0] == "")
                {
                    MessageBoxEx.Show("该车辆已经删除，无法撤销报废！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (MessageBoxEx.Show("确认要撤销报废，重新启用该车辆吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _model.i_Flag = 1;
                    if ((new DB_VehicleTransportManage.BLL.m_VehicleScrap()).Update(_model))
                    {
                        MessageBoxEx.Show("撤销成功，该车辆可以使用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //DB.BLL.m_SystemLog.WriteLog(Global.Params.PersonModel.PersonID, DB.Model.EnumLogAction.Delete, "删除隐患类型", "删除了隐患类型:" + _listUnSageLevel[_selectIndex].vc_Name);
                        //Pub.GisManage.DeleteFeature(Com.EnumLayerName.车辆, _model.ID);
                        bllVehicle.UpdateVehicleState((int)_model.VehicleID, 0);
                       //Pub.GisManage.UpdateFeatureState(EnumLayerName.车辆, (int)_model.VehicleID, EnumStyleIndex.CarNormal, true);
                        OperationLog.InsertSqlLog(EnumActionType.Add, "车辆报废信息", "车辆ID:" + _model.VehicleID);
                        LoadData();
                        Pub.GisManage.UpdataGisAndDBRemark();
                        Pub.GISForm.LoadGrid();
                    }
                    else
                    {
                        MessageBoxEx.Show("撤销报废失败，该车辆仍为报废状态！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("请选择要撤销的报废信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_VehicleScrap)dgvList.Rows[_selectIndex].Tag;
                new FormVehicleScrap(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的报废车辆", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
