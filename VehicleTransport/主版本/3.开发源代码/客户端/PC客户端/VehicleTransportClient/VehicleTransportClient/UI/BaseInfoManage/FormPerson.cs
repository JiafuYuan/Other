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
using DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Common.MessageBoxEx;

namespace VehicleTransportClient
{
    public partial class FormPerson : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_Person _model = new DB_VehicleTransportManage.Model.m_Person();
        DB_VehicleTransportManage.BLL.m_Department bllDepartment = new m_Department();
        DB_VehicleTransportManage.BLL.m_Person bllPerson=new m_Person();
        public FormPerson(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Person model)
        {
            InitializeComponent();
            _type = type;
            InitCmbSex();
            InitCmbDuty();
            cmbDept.SelectedIndex = 0;
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
            cmbDept.Nodes[0].Expand();
           
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
                if (bllPerson.GetModelList(" i_flag=0 and vc_Code='"+_model.vc_Code+"'").Count > 0)
                {
                    MessageBoxEx.Show("人员编号 【" + _model.vc_Code + "】 已存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

               

                if (bllPerson.Add(_model) >0)
                {
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "人员姓名",_model.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_Person> lstUser = bllPerson.GetModelList(" i_flag=0 and  vc_Code='" + _model.vc_Code + "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("人员编号【" + _model.vc_Code + "】 已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                if (bllPerson.Update(_model))
                {
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "人员姓名", _model.vc_Name);
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
            _model.i_Flag = 0;
            _model.vc_Code = txtCode.Text.Trim();
            if (_model.vc_Code.Length == 0)
            {
                txtCode.Focus();
                throw new Exception("请输入人员编号！");
            }
            if (_model.vc_Code.IndexOf("'") >= 0)
            {
                txtCode.Focus();
                throw new Exception("人员编号中不可以有特殊字符！");
            }
            _model.vc_Name = txtName.Text.Trim();
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("姓名中不可以有特殊字符！");
            }
            if (_model.vc_Name.Length== 0)
            {
                txtName.Focus();
                throw new Exception("请输入姓名！");
            }
            _model.i_Sex = ((CmbItemInit) cmbSex.SelectedItem).Value;
            if (cmbDept.SelectedIndex!=0)
            {
                _model.DepartmentID = ((Myobj) cmbDept.SelectedNode.Tag).Id;
            }
            else
            {
                throw new Exception("请选择部门！");
            }

            _model.vc_Job = txtDuty.Text.Trim();
            if (_model.vc_Job.IndexOf("'") >= 0)
            {
                txtDuty.Focus();
                throw new Exception("职务中不可以有特殊字符！");
            }


            _model.vc_WorkType = txtWorkType.Text.Trim();
            if (_model.vc_WorkType.IndexOf("'") >= 0)
            {
                txtWorkType.Focus();
                throw new Exception("工种中不可以有特殊字符！");
            }


            _model.vc_Telphone = txtTelNum.Text.Trim();
            if (_model.vc_Telphone.IndexOf("'") >= 0)
            {
                txtTelNum.Focus();
                throw new Exception("请输入正确的电话号码！");
            }
          
            _model.vc_Memo = txtMemo.Text.Trim();
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }
           
           

           
            
        }

        private void ShowModel()
        {
            txtName.Text = _model.vc_Name;
                foreach (CmbItemInit item in cmbSex.Items)
                {
                    if (item.Value == _model.i_Sex)
                    {
                        cmbSex.SelectedItem = item;
                        break;
                    }
                }
                
            GetNode((int)_model.DepartmentID, cmbDept.Nodes[0]);
            txtCode.Text = _model.vc_Code;
            txtDuty.Text = _model.vc_Job;
            txtWorkType.Text = _model.vc_WorkType;
            txtTelNum.Text = _model.vc_Telphone;
            txtMemo.Text = _model.vc_Memo;

        }

        public void InitCmbSex()
        {
            cmbSex.Items.Add(new CmbItemInit("男", 0));
            cmbSex.Items.Add(new CmbItemInit("女", 1));
            cmbSex.SelectedIndex = 0;
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
      
    }
    public class CmbItemInit
        {
          
            public int Value
            {
                get; set;

            }
            public string Name
            {
                get; set;

            }

            public CmbItemInit(string name, int value)
            {
                Name = name;
                Value = value;
            }

        public override string ToString()
        {
            return Name;
        }
        }
   
}
