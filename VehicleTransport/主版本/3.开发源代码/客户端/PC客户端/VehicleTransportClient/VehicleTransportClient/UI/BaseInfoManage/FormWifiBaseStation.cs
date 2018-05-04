using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using VehicleTransportClient.Com;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using Common.MessageBoxEx;
namespace VehicleTransportClient
{
    public partial class FormWifiBaseStation : Form
    {
        public FormWifiBaseStation()
        {
            InitializeComponent();
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvbs);
        }
        private int _selectindex = -1;
        private string _tableName = "FormWifiBs";

        private void LoadData()
        {
            BLL.m_Address localbll = new BLL.m_Address();
            BLL.m_WifiBaseStation wifibll = new BLL.m_WifiBaseStation();
            List<Model.m_WifiBaseStation> listwifi = wifibll.GetModelList("i_flag=0");
            for (int i = 0; i < listwifi.Count; i++)
            {
                if (listwifi[i].LocalizerStationID != null)
                {
                    listwifi[i].localname = localbll.GetLocalizerStationName(listwifi[i].LocalizerStationID.Value);
                }
            }
            dgvbs.DataSource = listwifi;
            lblCount.Text = "共有" + dgvbs.Rows.Count + "个WIFI基站";
            dgvbs.ClearSelection();
        }

        private void FormWifiBaseStation_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormWifiBaseStationEdit frmedite = new FormWifiBaseStationEdit(Com.OperateTypeEnum.Add, null);
            frmedite.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectindex >= 0)
            {
                List<Model.m_WifiBaseStation> list = (List<Model.m_WifiBaseStation>)dgvbs.DataSource;
                Model.m_WifiBaseStation entity = list[_selectindex];
                FormWifiBaseStationEdit frmedite = new FormWifiBaseStationEdit(Com.OperateTypeEnum.Edit, entity);
                frmedite.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的基站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void dgvbs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectindex = e.RowIndex;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectindex >= 0)
            {
                List<Model.m_WifiBaseStation> list = (List<Model.m_WifiBaseStation>)dgvbs.DataSource;
                Model.m_WifiBaseStation _model = list[_selectindex];
                BLL.m_WifiBaseStation wifibll = new BLL.m_WifiBaseStation();
                BLL.m_User bllUser=new BLL.m_User();
                if (MessageBoxEx.Show("确认要删除基站 【" + _model.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    List<DB_VehicleTransportManage.Model.m_User> listUser =
                       bllUser.GetModelList("i_flag=0 and PdaID<>0 and WifiBaseStationID=" + _model.ID);

                    if (listUser != null && listUser.Count > 0)
                    {
                        MessageBoxEx.Show("当前WIFI基站正在使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (wifibll.Delete(_model.ID))
                    {
                        Pub.GisManage.DeleteFeature(EnumLayerName.wifi基站, _model.ID);
                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        OperationLog.InsertSqlLog(EnumActionType.Delete, "删除基站", _model.vc_Name);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();

            Pub.StyleManager.SetGridStyle(_tableName, this.dgvbs);
        }
    }
}
