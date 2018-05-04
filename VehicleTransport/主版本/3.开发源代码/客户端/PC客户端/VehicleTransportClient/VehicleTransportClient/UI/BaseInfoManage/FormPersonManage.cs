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
    public partial class FormPersonManage : Form
    {
        private string _tableName = "FormPersonManage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_Person _model = new DB_VehicleTransportManage.Model.m_Person();
        BLL.m_User bllUser = new BLL.m_User();
        BLL.m_Person bllPerson = new BLL.m_Person();
        BLL.m_Department bllDepartment = new BLL.m_Department();
        BLL.v_Plan bllPlan = new BLL.v_Plan();
        BLL.m_Apply bllApply = new BLL.m_Apply();
        public FormPersonManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormPersonManage_Load);
        }

        void FormPersonManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_Person> lst = new DB_VehicleTransportManage.BLL.m_Person().GetModelList("i_flag=0");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_Person item in lst)
            {
                string sex = item.i_Sex == 0 ? "男" : "女";
                int i = dgvList.Rows.Add(item.vc_Code,item.vc_Name, sex, bllDepartment.GetName(item.DepartmentID), item.vc_Job, item.vc_WorkType, item.vc_Telphone, item.vc_Memo);
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count + "个人员";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataSet dataSetDepartment = bllDepartment.GetList("i_flag=0");
            if (dataSetDepartment != null && dataSetDepartment.Tables[0].Rows.Count>0)
            {
                new FormPerson(Com.OperateTypeEnum.Add, null).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请在系统中添加部门信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Person)dgvList.Rows[_selectIndex].Tag;
                if (MessageBoxEx.Show("确认要删除人员 【" + _model.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (bllUser.IsPersonUsed(_model.ID))
                    {
                        MessageBoxEx.Show("当前人员已经关联用户，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    if (bllApply.IsPersonUsed(_model.ID))
                    {
                        MessageBoxEx.Show("当前人员关联计划，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    if (bllPlan.IsPersonUsed(_model.ID))
                    {
                        MessageBoxEx.Show("当前人员关联计划，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    _model.i_Flag = 1;
                    if ((new DB_VehicleTransportManage.BLL.m_Person()).Update(_model))
                    {
                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        OperationLog.InsertSqlLog(EnumActionType.Delete, "人员姓名", _model.vc_Name);
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
                MessageBoxEx.Show("请选择要删除的人员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Person)dgvList.Rows[_selectIndex].Tag;
                new FormPerson(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的人员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
