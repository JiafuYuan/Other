using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using BLL=DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;
using Common.MessageBoxEx;
using DevComponents.AdvTree;

namespace VehicleTransportClient
{
    public partial class FormDept : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_Department _model = new DB_VehicleTransportManage.Model.m_Department();
        private BLL.m_Department bll = new BLL.m_Department();
        public FormDept(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Department model)
        {
            InitializeComponent();
            _type = type;
            InitCmbDuty();
            switch (type)
            {
                case OperateTypeEnum.Add:
                    this.FormTitle = "增加";
                    btnOK.Text = "添加";
                    cmbDept.SelectedIndex = 0;
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


                if ((new DB_VehicleTransportManage.BLL.m_Department()).GetModelList(" i_flag=0 and vc_Name='" + _model.vc_Name + "'").Count > 0)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("部门名称 【" + _model.vc_Name + "】 已经存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if ((new DB_VehicleTransportManage.BLL.m_Department()).Add(_model) > 0)
                {
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "部门名称", _model.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_Department> lstUser = (new DB_VehicleTransportManage.BLL.m_Department()).GetModelList(" i_flag=0 and  vc_Name='" + _model.vc_Name + "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("部门名称【" + _model.vc_Name + "】 已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                if ((new DB_VehicleTransportManage.BLL.m_Department()).Update(_model))
                {
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "部门名称", _model.vc_Name);
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
            _model.vc_Name = txtName.Text.Trim();


            if (_model.vc_Name == "")
            {
                txtName.Focus();
                throw new Exception("部门名称不可以为空！");
            }
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("部门名称中不可以有特殊字符！");
            }
            if (cmbDept.SelectedNode != null)
            {
                if (_model.vc_Name != ((Myobj)cmbDept.SelectedNode.Tag).Vc_Name)
                {

                    _model.ParentID = ((Myobj)cmbDept.SelectedNode.Tag).Id;

                }
                else
                {
                    cmbDept.Focus();
                    throw new Exception("部门名称和上级部门不能相同！");
                }
            }
            else
            {
                _model.ParentID = 0;
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
            GetNode((int)_model.ParentID, cmbDept.Nodes[0]);
            txtMemo.Text = _model.vc_Memo;
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
        public void InitCmbDuty()
        {
            Myobj obj = new Myobj();
            obj.Id = 0;
            obj.Vc_Name = "==请选择上级部门==";
            Node node1 = new Node();
            node1.Text = obj.Vc_Name;
            node1.Tag = obj;
            cmbDept.Nodes.Add(node1);
            LoadCmboTree(node1);
        }
        public void LoadCmboTree(Node nd)
        {
            DataSet ds = new DataSet();
            ds = bll.GetList(" i_Flag=0 and ParentID=" + ((Myobj)nd.Tag).Id);
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
    }

    class Myobj
    {
        public int Id;
        public string Vc_Code;
        public string Vc_Name;
        public Myobj()
        {

        }
    }
}
