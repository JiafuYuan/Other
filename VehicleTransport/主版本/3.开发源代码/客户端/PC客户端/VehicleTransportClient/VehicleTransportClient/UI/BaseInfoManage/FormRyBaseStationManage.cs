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
using VehicleTransportClient.Com;
using Model=DB_VehicleTransportManage.Model;
using BLL=DB_VehicleTransportManage.BLL;

namespace VehicleTransportClient
{
    public partial class FormRyBaseStationManage : Form
    {
        private string _tableName = "FormRyBaseStationManage";
        private int _selectIndex = -1;
        private Model.m_Localizer _model = new Model.m_Localizer();
        private BLL.m_Localizer bllLocalizer = new BLL.m_Localizer();
        private BLL.m_Address bllAddress = new BLL.m_Address();
        private BLL.m_SystemConfig bllSystemConfig = new BLL.m_SystemConfig();
        public FormRyBaseStationManage()
        {
            InitializeComponent();

            if (bllSystemConfig.GetValue(BLL.EnumSystemConfigKeys.HaveKJ222Client) == "1")
            {
                toolStrip1.Visible = false;
            }
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormRyBaseStationManage_Load);
        }

        void FormRyBaseStationManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_Localizer> lst = new DB_VehicleTransportManage.BLL.m_Localizer().GetModelList("i_flag=0");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            if (!Pub.IsKj602)
            {
                dgvList.Columns[2].Visible = false;
                dgvList.Columns[3].Visible = false;
                foreach (DB_VehicleTransportManage.Model.m_Localizer item in lst)
                {
                    int i = dgvList.Rows.Add(item.vc_Code, item.vc_Name,0,0, item.i_HID);
                    dgvList.Rows[i].Tag = item;
                }
            }
            else
            {
                dgvList.Columns[4].Visible = false;
                foreach (DB_VehicleTransportManage.Model.m_Localizer item in lst)
                {
                    int i = dgvList.Rows.Add(item.vc_Code, item.vc_Name, item.i_ParentHID, item.i_HID,0);
                    dgvList.Rows[i].Tag = item;
                }
            }
            
            lblCount.Text = "共有" + dgvList.Rows.Count + "个定位基站";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormRyBaseStation(Com.OperateTypeEnum.Add, null).ShowDialog();
            LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Localizer)dgvList.Rows[_selectIndex].Tag;

                 

                if (MessageBoxEx.Show("确认要删除定位基站 【" + _model.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (bllAddress.IsLocalizerStationUsed(_model.ID))
                    {
                        MessageBoxEx.Show("当前基站已被使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    _model.i_Flag = 1;
                    if ((new DB_VehicleTransportManage.BLL.m_Localizer()).Update(_model))
                    {

                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //DB.BLL.m_SystemLog.WriteLog(Global.Params.PersonModel.PersonID, DB.Model.EnumLogAction.Delete, "删除隐患类型", "删除了隐患类型:" + _listUnSageLevel[_selectIndex].vc_Name);
                        //Pub.GisManage.DeleteFeature(Com.EnumLayerName.车辆, _model.ID);
                        OperationLog.InsertSqlLog(EnumActionType.Delete, "定位基站", "HID:" + _model.i_HID.ToString());
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
                MessageBoxEx.Show("请选择要删除的定位基站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Localizer)dgvList.Rows[_selectIndex].Tag;
                new FormRyBaseStation(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的定位基站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
