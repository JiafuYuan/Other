using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Controls;
using Common.Enum;
using VehicleTransportClient.Com;
using BLL=DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Common.MessageBoxEx;

namespace VehicleTransportClient
{
    public partial class FormUser : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_User _model = new DB_VehicleTransportManage.Model.m_User();
        private BLL.m_Department bllDepartment = new BLL.m_Department();
        private BLL.m_User bllUser = new BLL.m_User();
        private BLL.m_Person bllPersonEx = new BLL.m_Person();
        private BLL.m_Rule bllRule = new BLL.m_Rule();
        private int _personID = 0;
        Bestway.Windows.Controls.InputPromptDialog inputPrompt = new InputPromptDialog();

        public FormUser(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_User model)
        {
            InitializeComponent();
            _type = type;
            InitLoad();
            InitCmbDuty();
            cmbDept.Nodes[0].Expand();
            cmbDept.SelectedIndexChanged += new EventHandler(cmbDept_SelectedIndexChanged);
            switch (type)
            {
                case OperateTypeEnum.Add:
                    this.FormTitle = "增加";
                    btnOK.Text = "添加";
                    break;
                case OperateTypeEnum.Edit:
                    this.FormTitle = "修改";
                    this._model = model;
                    btnOK.Text = "修改";
                    ShowModel();
                    break;
                default:
                    break;
            }
            inputPrompt.HideForm();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();
            }
            catch (Exception ex)
            {
                Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_type == OperateTypeEnum.Add)
            {
                if (bllUser.GetModelList(" i_flag=0 and vc_Name='" + _model.vc_Name + "'").Count > 0)
                {
                    MessageBoxEx.Show("用户名 【" + _model.vc_Name + "】 已存在", "添加失败", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    return;
                }

                if ((int) _model.i_IdentificationCardHID > 0)
                {
                    if (bllUser.IsIdentificationCardHIDExist((int) _model.i_IdentificationCardHID, 0))
                    {
                        MessageBoxEx.Show("标识卡 【" + (int) _model.i_IdentificationCardHID + "】 已存在", "添加失败",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                if (_personID == 0)
                {
                    if (bllUser.IsDepartmentExist((int) _model.DepartmentID, 0))
                    {
                        MessageBoxEx.Show("该部门已存在公共帐户！", "添加失败",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                else
                {
                        if (bllUser.GetModelList(" i_flag=0 and PersonID=" + _model.PersonID).Count > 0)
                        {
                            MessageBoxEx.Show("人员姓名 【" + bllPersonEx.GetName((int)_model.PersonID) + "】 已存在", "添加失败", MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
                            return;
                        }
                }
                if (bllUser.Add(_model) >0)
                {
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "用户名", _model.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_User> lstUser =
                    bllUser.GetModelList(" i_flag=0 and  vc_Name='" + _model.vc_Name + "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("用户名【" + _model.vc_Name + "】 已经存在", "编辑失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                if ((int) _model.i_IdentificationCardHID > 0)
                {
                    if (bllUser.IsIdentificationCardHIDExist((int)_model.i_IdentificationCardHID, _model.ID))
                    {
                        MessageBoxEx.Show("标识卡 【" + (int)_model.i_IdentificationCardHID + "】 已存在", "编辑失败", MessageBoxButtons.OK,
                           MessageBoxIcon.Asterisk);
                        return;
                    }
                }
               
                if (_personID == 0)
                {
                    if (bllUser.IsDepartmentExist((int)_model.DepartmentID, _model.ID))
                    {
                        MessageBoxEx.Show("该部门已存在公共账户", "编辑失败",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                else
                {
                    List<DB_VehicleTransportManage.Model.m_User> lstPerson =
                       bllUser.GetModelList(" i_flag=0 and  PersonID=" + _model.PersonID);
                    if (lstPerson.Count > 0)
                    {
                        if (lstPerson[0].ID != _model.ID)
                        {
                            MessageBoxEx.Show("人员姓名 【" + bllPersonEx.GetName((int)_model.PersonID) + "】 已存在", "编辑失败",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                }
               
                if (bllUser.Update(_model))
                {
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "用户名", _model.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("编辑失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetModel()
        {
            if (_model.dt_CreateTime.ToString().Length == 0)
            {
                _model.dt_CreateTime = DateTime.Now;
            }

            if (_model.dt_LastActiveDateTime.Year == 1)
            {
                _model.dt_LastActiveDateTime = DateTime.Now;
            }
            _model.i_Flag = 0;
            _model.vc_Name = txtUserName.Text.Trim();
            if (_model.vc_Name.Length == 0)
            {
                txtUserName.Focus();
                throw new Exception("请输入用户姓名！");
            }
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtUserName.Focus();
                throw new Exception("用户姓名中不可以有特殊字符！");
            }
            _model.vc_Password = txtPassword.Text.Trim();
            if (_model.vc_Password.Length == 0)
            {
                txtPassword.Focus();
                throw new Exception("请输入密码！");
            }
            if (_model.vc_Password.IndexOf("'") >= 0)
            {
                txtPassword.Focus();
                throw new Exception("密码中不可以有特殊字符！");
            }


            _model.RuleID = (int)cmbRule.SelectedValue;
           

            if (cmbDept.SelectedNode != null)
            {
                _model.DepartmentID = ((Myobj)cmbDept.SelectedNode.Tag).Id;
            }
            else
            {
                _model.DepartmentID = 0;
            }
            if (_personID == 0)
            {
                txtPersonName.Focus();
                throw new Exception("请选择人员姓名！");
            }
            _model.PersonID = _personID;
           
            //if (_model.DepartmentID != 0 && _model.PersonID != 0)
            //{
            //    txtPersonName.Focus();
            //    throw new Exception("人员姓名和所属部门只允许选择一个！");
            //}


            _model.vc_Memo = txtMemo.Text.Trim();
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }
            if (txtNfcNum.Text.Trim() == "0")
            {
                txtNfcNum.Focus();
                throw new Exception("请输入正确的标识卡卡号！");
            }
            if (txtNfcNum.Text.Trim().Length==0)
            {
                _model.i_IdentificationCardHID = 0;
            }
            if (txtNfcNum.Text.Trim().Length > 0)
            {
                _model.i_IdentificationCardHID = int.Parse(txtNfcNum.Text.Trim());
            }


        }

        private void ShowModel()
        {
            txtUserName.Text = _model.vc_Name;
            txtPassword.Text = _model.vc_Password;
            int i = _model.PersonID == null ? 0 : (int) _model.PersonID;
            if (i>0)
            txtPersonName.Text = bllPersonEx.GetName(i);
            else
            {
                GetNode(_model.DepartmentID == null ? 0 : (int)_model.DepartmentID, cmbDept.Nodes[0]);
            }
            cmbRule.SelectedValue = _model.RuleID;
           
            txtMemo.Text = _model.vc_Memo;
            if (_model.i_IdentificationCardHID != null && _model.i_IdentificationCardHID != 0)
                txtNfcNum.Text = _model.i_IdentificationCardHID.ToString();
       
        }



        public void InitCmbDuty()
        {
            Myobj obj = new Myobj();
            obj.Id = 0;
            obj.Vc_Name = "==请选择部门==";
            Node node1 = new Node();
            node1.Text = obj.Vc_Name;
            node1.Tag = obj;
            cmbDept.Nodes.Add(node1);
            LoadCmboTree(node1);
        }

        public void LoadCmboTree(Node nd)
        {
            DataSet ds = new DataSet();
            ds = bllDepartment.GetList(" i_Flag=0 and ParentID=" + ((Myobj)nd.Tag).Id);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Myobj obj = new Myobj();
                obj.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                obj.Vc_Name = dt.Rows[i]["vc_Name"].ToString();
                Node node1 = new Node();
                node1.Text = obj.Vc_Name;
                node1.Tag = obj;
                nd.Nodes.Add(node1);
                LoadCmboTree(node1);
            }
        }

        private void GetNode(int id, Node pNode)
        {
            foreach (Node node in pNode.Nodes)
            {
                if (((Myobj)node.Tag).Id == id)
                {
                    cmbDept.SelectedNode = node;
                    break;
                }
                GetNode(id, node);

            }
        }

        private void InitLoad()
        {
            inputPrompt.ClearBind();
            DataSet dataSet = bllPersonEx.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPrompt.Bind(txtPersonName, dataSet.Tables[0], 3, new int[] { 1 });
                inputPrompt.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPrompt_OnTextChangedEx);
            }
            dataSet = bllRule.GetList("i_Flag=0");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                cmbRule.ValueMember = "ID";
                cmbRule.DisplayMember = "vc_Name";
                cmbRule.DataSource = dataSet.Tables[0];
            }

        }

        void inputPrompt_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            cmbDept.SelectedIndexChanged -= new EventHandler(cmbDept_SelectedIndexChanged); 
            if (e.IsFind)
            {
               _personID = int.Parse(e.SelectedRow["ID"].ToString());
                int DepartmentID=bllPersonEx.GetDeptName(_personID);
                GetNode(DepartmentID, cmbDept.Nodes[0]);
            }
            else
            {
                _personID = 0;
            }
            cmbDept.SelectedIndexChanged += new EventHandler(cmbDept_SelectedIndexChanged); 
        }

        void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPersonName.Text = "";
        }

        private void txtPersonName_Click(object sender, EventArgs e)
        {
            inputPrompt.ShowDropDown();
        }

        private void txtNfcNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        

    }


}
