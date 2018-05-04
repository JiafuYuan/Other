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
using DB_VehicleTransportManage;
using DB_VehicleTransportManage.BLL;
using DevComponents.DotNetBar.Schedule;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{
    public partial class FormPDAManage : Form
    {
        private string _tableName = "FormPDAManage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_PDA _model = new DB_VehicleTransportManage.Model.m_PDA();
        DB_VehicleTransportManage.BLL.m_PDA bll = new m_PDA();
        DB_VehicleTransportManage.BLL.m_Department bllDepartment = new m_Department();
        public FormPDAManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormPDAManage_Load);
        }

        void FormPDAManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_PDA> lst = new DB_VehicleTransportManage.BLL.m_PDA().GetModelList("i_flag=0");
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_PDA item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_Code, item.vc_MacAddress, bllDepartment.GetName((int)item.DepartmentID), item.vc_Memo);
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count + "个PDA";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormPDA(Com.OperateTypeEnum.Add, null).ShowDialog();
            LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_PDA)dgvList.Rows[_selectIndex].Tag;

                if (MessageBoxEx.Show("确认要删除MAC地址为【" + _model.vc_MacAddress + "】的PDA 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    List<DB_VehicleTransportManage.Model.m_PDA> listPda =
                        bll.GetModelList("i_flag=0 and i_State=1 and vc_MacAddress='" + _model.vc_MacAddress + "'");

                    if (listPda!=null&&listPda.Count > 0)
                    {
                        MessageBoxEx.Show("PDA正在使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    _model.i_Flag = 1;
                    if ((new DB_VehicleTransportManage.BLL.m_PDA()).Update(_model))
                    {
                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //DB.BLL.m_SystemLog.WriteLog(Global.Params.PersonModel.PersonID, DB.Model.EnumLogAction.Delete, "删除隐患类型", "删除了隐患类型:" + _listUnSageLevel[_selectIndex].vc_Name);
                        //Pub.GisManage.DeleteFeature(Com.EnumLayerName.车辆, _model.ID);
                        OperationLog.InsertSqlLog(EnumActionType.Add, "PDA名称", "Mac地址:" + _model.vc_MacAddress);
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
                MessageBoxEx.Show("请选择要删除的PDA", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_PDA)dgvList.Rows[_selectIndex].Tag;
                new FormPDA(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的PDA", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
