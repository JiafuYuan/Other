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
using DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Common.MessageBoxEx;

namespace VehicleTransportClient
{
    public partial class FormMaterielType : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_MaterielType _model = new DB_VehicleTransportManage.Model.m_MaterielType();
        m_MaterielType bllMaterielType = new m_MaterielType();

        public FormMaterielType(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_MaterielType model)
        {
            InitializeComponent();
            _type = type;
            InitCmbType();
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
            cmbParentType.Nodes[0].Expand();

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
                if (bllMaterielType.GetModelList(" i_flag=0 and vc_Code='" + _model.vc_Code + "'").Count > 0)
                {
                    MessageBoxEx.Show("物料编号 【" + _model.vc_Code + "】 已存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (bllMaterielType.Add(_model) > 0)
                {
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "物料名称", _model.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_MaterielType> lstUser = bllMaterielType.GetModelList(" i_flag=0 and  vc_Code='" + _model.vc_Code + "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("物料编号【" + _model.vc_Code + "】 已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                if (bllMaterielType.Update(_model))
                {
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "物料名称", _model.vc_Name);
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
                throw new Exception("请输入物料编号！");
            }
            if (_model.vc_Code.IndexOf("'") >= 0)
            {
                txtCode.Focus();
                throw new Exception("物料编号中不可以有特殊字符！");
            }
            _model.vc_Name = txtName.Text.Trim();
            if (_model.vc_Name.Length == 0)
            {
                txtName.Focus();
                throw new Exception("请输入物料名称！");
            }
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("物料名称中不可以有特殊字符！");
            }
            _model.vc_Unit = txtUnit.Text.Trim();
            if (_model.vc_Unit.Length == 0)
            {
                txtUnit.Focus();
                throw new Exception("请输入物料单位！");
            }
            if (_model.vc_Unit.IndexOf("'") >= 0)
            {
                txtUnit.Focus();
                throw new Exception("物料单位中不可以有特殊字符！");
            }
            _model.vc_Specifications = txtSpecifications.Text.Trim();
            if (_model.vc_Specifications.IndexOf("'") >= 0)
            {
                txtSpecifications.Focus();
                throw new Exception("物料规格中不可以有特殊字符！");
            }
            if (cmbParentType.SelectedNode != null)
            {
                if (_model.vc_Name != ((Myobj)cmbParentType.SelectedNode.Tag).Vc_Name)
                {

                    _model.ParentID = ((Myobj)cmbParentType.SelectedNode.Tag).Id;
                }
                else
                {
                    cmbParentType.Focus();
                    throw new Exception("物料名称与所属物料类型不能相同！");
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
            txtCode.Text = _model.vc_Code;
            txtName.Text = _model.vc_Name;
            txtUnit.Text = _model.vc_Unit;
            txtSpecifications.Text = _model.vc_Specifications;
            GetNode((int)_model.ParentID, cmbParentType.Nodes[0]);
            txtMemo.Text = _model.vc_Memo;
        }

        private void GetNode(int id, Node pNode)
        {
            foreach (Node node in pNode.Nodes)
            {
                if (((Myobj)node.Tag).Id == id)
                {
                    cmbParentType.SelectedNode = node;
                    break;
                }
                GetNode(id, node);

            }
        }
        public void InitCmbType()
        {
            Myobj obj = new Myobj();
            obj.Id = 0;
            obj.Vc_Name = "==请选择所属类型==";
            Node node1 = new Node();
            node1.Text = obj.Vc_Name;
            node1.Tag = obj;
            cmbParentType.Nodes.Add(node1);
            LoadCmboTree(node1);
        }
        public void LoadCmboTree(Node nd)
        {
            DataSet ds = new DataSet();
            ds = bllMaterielType.GetList(" i_Flag=0 and ParentID=" + ((Myobj)nd.Tag).Id);
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
}
