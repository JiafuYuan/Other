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
    public partial class FormUserManage : Form
    {
        private string _tableName = "FormUserManage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_User _model = new DB_VehicleTransportManage.Model.m_User();
        BLL.m_User bllUser = new BLL.m_User();
        BLL.m_Person bllPersonEx = new BLL.m_Person();
        BLL.m_Department bllDepartmentEx = new BLL.m_Department();
        BLL.m_Rule bllRuleEx = new BLL.m_Rule();
        public FormUserManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormUserManage_Load);
        }

        void FormUserManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_User> lst = new DB_VehicleTransportManage.BLL.m_User().GetModelList("i_flag=0 and vc_Name<>'admin'");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_User item in lst)
            {
                int i = 0;
                //int DepartmentID = item.DepartmentID == null ? 0 : (int) item.DepartmentID;
                //if (DepartmentID > 0)
               // {
                //    i = dgvList.Rows.Add(item.vc_Name,
                //       (int)item.i_IdentificationCardHID == 0 ? "" : item.i_IdentificationCardHID.Value.ToString(),
                //       bllPersonEx.GetName((item.PersonID == null ? 0 : (int)item.PersonID)),
                //       bllDepartmentEx.GetName(DepartmentID),
                //       bllRuleEx.GetName(item.RuleID == null ? 0 : (int)item.RuleID),
                //       item.dt_CreateTime.ToString().Length == 0
                //           ? ""
                //           : item.dt_CreateTime.Value.ToString("yyyy年MM月dd日"), item.vc_Memo);
                //}
                //else
                //{
                    i = dgvList.Rows.Add(item.vc_Name,
                       (int)item.i_IdentificationCardHID == 0 ? "" : item.i_IdentificationCardHID.Value.ToString(),
                       bllPersonEx.GetName((item.PersonID == null ? 0 : (int)item.PersonID)),
                        bllDepartmentEx.GetName(bllPersonEx.GetDeptName((item.PersonID == null ? 0 : (int)item.PersonID))),
                       bllRuleEx.GetName(item.RuleID == null ? 0 : (int)item.RuleID),
                       item.dt_CreateTime.ToString().Length == 0
                           ? ""
                           : item.dt_CreateTime.Value.ToString("yyyy年MM月dd日"), item.vc_Memo);
               // }
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count + "个用户";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormUser( Com.OperateTypeEnum.Add,null).ShowDialog();
            LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_User)dgvList.Rows[_selectIndex].Tag;
                if (MessageBoxEx.Show("确认要删除用户 【" + _model.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //判断是否为当前用户
                    if (_model.ID==Pub.UserId)
                    {
                        MessageBoxEx.Show("当前登录用户无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (bllUser.GetModelList(" i_flag=0 and i_State=1 and vc_Name='"+_model.vc_Name+"'").Count > 0)
                    {
                        MessageBoxEx.Show("用户【" + _model.vc_Name + "】 正在使用", "删除失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                    _model.i_Flag = 1;
                    if ((new DB_VehicleTransportManage.BLL.m_User()).Update(_model))
                    {
                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        OperationLog.InsertSqlLog(EnumActionType.Delete, "用户名", _model.vc_Name);
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
                MessageBoxEx.Show("请选择要删除的用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_User)dgvList.Rows[_selectIndex].Tag;
                new FormUser(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
