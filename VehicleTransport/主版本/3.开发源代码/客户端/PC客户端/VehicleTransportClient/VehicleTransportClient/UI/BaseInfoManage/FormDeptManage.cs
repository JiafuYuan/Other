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
using BLL = DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{
    public partial class FormDeptManage : Form
    {
        private string _tableName = "FormDeptManage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_Department _model = new DB_VehicleTransportManage.Model.m_Department();
        private BLL.m_Department bll = new BLL.m_Department();
        private BLL.m_Person bllPersonEx = new BLL.m_Person();
        private BLL.v_Plan bllPlan = new BLL.v_Plan();
        public FormDeptManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormDeptManage_Load);
        }

        void FormDeptManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_Department> lst = new DB_VehicleTransportManage.BLL.m_Department().GetModelList("i_flag=0");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_Department item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_Name, bll.GetName((int)item.ParentID), item.vc_Memo);
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count + "个部门";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormDept(Com.OperateTypeEnum.Add, null).ShowDialog();
            LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Department)dgvList.Rows[_selectIndex].Tag;

                 

                if (MessageBoxEx.Show("确认要删除部门 【" + _model.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (bllPlan.IsDepartmentUsed(_model.ID) || bllPersonEx.IsDeptUsed(_model.ID) || (new DB_VehicleTransportManage.BLL.m_Department()).GetList("i_Flag=0 and ParentID=" + _model.ID).Tables[0].Rows.Count > 0)
                    {
                        MessageBoxEx.Show("当前部门已被使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    _model.i_Flag = 1;
                    if ((new DB_VehicleTransportManage.BLL.m_Department()).Update(_model))
                    {
                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //DB.BLL.m_SystemLog.WriteLog(Global.Params.PersonModel.PersonID, DB.Model.EnumLogAction.Delete, "删除隐患类型", "删除了隐患类型:" + _listUnSageLevel[_selectIndex].vc_Name);
                        //Pub.GisManage.DeleteFeature(Com.EnumLayerName.车辆, _model.ID);
                        OperationLog.InsertSqlLog(EnumActionType.Delete, "部门名称", _model.vc_Name);
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
                MessageBoxEx.Show("请选择要删除的部门", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Department)dgvList.Rows[_selectIndex].Tag;
                new FormDept(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的部门", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
