using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Bestway.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using DevComponents.DotNetBar.Schedule;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{
    public partial class FormAddressManage : Form
    {
        private string _tableName = "FormAddressManage";
        private int _selectIndex = -1;
        private Model.v_Address _model = new Model.v_Address();
        private BLL.v_Address bllVAddress = new BLL.v_Address();
        private BLL.m_Area bllAreaEx = new BLL.m_Area();
        private BLL.m_SystemConfig bllSystemConfig = new BLL.m_SystemConfig();
        private BLL.m_WifiBaseStation bllWifiBaseStation = new BLL.m_WifiBaseStation();
        private BLL.m_Address bllAddress = new BLL.m_Address();
        private BLL.v_Plan bllPlan = new BLL.v_Plan();
        public FormAddressManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, dgvList);
            Load += new EventHandler(FormAddressManage_Load);
        }

        void FormAddressManage_Load(object sender, EventArgs e)
        {
           // if (bllSystemConfig.GetValue( BLL.EnumSystemConfigKeys.HaveKJ222Client) == "1")
            if (bllSystemConfig.GetValue(BLL.EnumSystemConfigKeys.HaveKJ222Client) == "1")
            {
                btnAdd.Visible = false;
                btnAddAll.Visible = true;
            }
            else
            {
                btnAdd.Visible = true;
                btnAddAll.Visible = false;
            }
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<Model.v_Address> lst = new BLL.v_Address().GetModelList("i_flag=0 and vc_Code<>''");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            if (!Pub.IsKj602)
            {
                dgvList.Columns["ParentHID"].Visible = false;
                dgvList.Columns["childHID"].Visible = false;
                foreach (Model.v_Address item in lst)
                {
                    string strIsUpMine = item.i_IsUpMine == 0 ? "井下" : "井上";
                    int i = dgvList.Rows.Add(item.vc_Code, item.vc_Name, 0, 0, item.i_HID,
                        bllAreaEx.GetName((int)item.AreaID), strIsUpMine
                        , bllAddress.GetLocalizerStationName((int)item.DirectionLocalizerStationID), item.i_IsDirectionStation == 0 ? "" : "方向基站", item.vc_Memo);
                    dgvList.Rows[i].Tag = item;
                }
            }
            else
            {
                
                dgvList.Columns["HID"].Visible = false;
                foreach (Model.v_Address item in lst)
                {
                    string strIsUpMine = item.i_IsUpMine == 0 ? "井下" : "井上";
                    int i = dgvList.Rows.Add(item.vc_Code, item.vc_Name, item.i_ParentHID, item.i_HID, 0,
                        bllAreaEx.GetName((int)item.AreaID), strIsUpMine
                        , bllAddress.GetLocalizerStationName((int)item.DirectionLocalizerStationID), item.i_IsDirectionStation == 0 ? "" : "方向基站", item.vc_Memo);
                    dgvList.Rows[i].Tag = item;
                }
            }
            lblCount.Text = "共有" + dgvList.Rows.Count + "个基站";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataSet dataSet=bllAreaEx.GetList(" i_Flag=0 ");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
            new FormAddress(OperateTypeEnum.Add, null).ShowDialog();
            LoadData();
            }
            else
            {
                MessageBoxEx.Show("请在系统中添加区域", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (Model.v_Address)dgvList.Rows[_selectIndex].Tag;

                if (MessageBoxEx.Show("确认要删除基站 【" + _model.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (bllPlan.IsAddressUsed(_model.ID) || bllAddress.IsLocalizerStationUsed((int)_model.LocalizerStationID.Value) || bllWifiBaseStation.IsAddressUsed((int)_model.LocalizerStationID.Value))
                    {
                        MessageBoxEx.Show("当前基站已被使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    bool iState = false;
                    _model.i_Flag = 1;
                    if ((new BLL.v_Address()).Update(_model))
                    {
                        if (bllSystemConfig.GetValue(BLL.EnumSystemConfigKeys.HaveKJ222Client ) != "1")
                        {
                            iState = (new BLL.m_Localizer()).Delete((int)_model.LocalizerStationID);
                        }
                        else
                        {
                            iState = true;
                        }
                    }
                    else
                    {
                        iState = false;
                    }
                    if (iState)
                    {
                        Pub.GISForm.LoadGrid();
                        Pub.GisManage.DeleteFeature(EnumLayerName.定位基站, _model.ID);
                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OperationLog.InsertSqlLog(EnumActionType.Delete, "基站名称", _model.vc_Name);
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
                MessageBoxEx.Show("请选择要删除的基站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (Model.v_Address)dgvList.Rows[_selectIndex].Tag;
                new FormAddress(OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的基站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            GridStyleForm gFrom = new GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableName, dgvList);
            LoadData();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            List<Model.m_Area> list = bllAreaEx.GetModelList(" i_flag=0 ");
            if (list != null && list.Count > 0)
            {
                FormAddAddress formAddAddress = new FormAddAddress(list[0].ID);
                formAddAddress.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请在系统中添加区域", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
           
        }



    }
}
