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
    public partial class FormArea : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_Area _model = new DB_VehicleTransportManage.Model.m_Area();
        private BLL.m_Area bll = new BLL.m_Area();
        public FormArea(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Area model)
        {
            InitializeComponent();
            _type = type;
            InitCmbArea();
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
                if (bll.GetModelList(" i_flag=0 and vc_Name='" + _model.vc_Name + "'").Count > 0)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("区域名称 【" + _model.vc_Name + "】 已经存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (bll.GetModelList(" i_flag=0 and vc_Code='" + _model.vc_Code + "'").Count > 0)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("区域编号 【" + _model.vc_Code + "】 已经存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                int areaid=bll.Add(_model);
                if (areaid > 0)
                {
                    _model.ID = areaid;
                    Pub.GisManage.AddFeature(EnumLayerName.区域层, _model, true);
                    Pub.GisManage.UpdataGisAndDBRemark();
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "区域名称", _model.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_Area> lstName = bll.GetModelList(" i_flag=0 and  vc_Name='" + _model.vc_Name + "'");
                if (lstName.Count > 0)
                {
                    if (lstName[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("区域名称【" + _model.vc_Name + "】 已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                List<DB_VehicleTransportManage.Model.m_Area> lstCode = bll.GetModelList(" i_flag=0 and  vc_Code='" + _model.vc_Code + "'");
                if (lstCode.Count > 0)
                {
                    if (lstCode[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("区域编号【" + _model.vc_Code + "】 已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                if (bll.Update(_model))
                {
                    Pub.GisManage.ModifyFeature(EnumLayerName.区域层, _model, true);
                    Pub.GisManage.UpdataGisAndDBRemark();
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "区域名称", _model.vc_Name);
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
            _model.vc_Code = txtCode.Text.Trim();
            if (_model.vc_Code == "")
            {
                txtCode.Focus();
                throw new Exception("区域编号不可以为空！");
            }
            if (_model.vc_Code.IndexOf("'") >= 0)
            {
                txtCode.Focus();
                throw new Exception("区域编号中不可以有特殊字符！");
            }
            if (_model.vc_Name == "")
            {
                txtName.Focus();
                throw new Exception("区域名称不可以为空！");
            }
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("区域名称中不可以有特殊字符！");
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
                    throw new Exception("区域名称和上级区域不能相同！");
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
            txtCode.Text = _model.vc_Code;
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
        public void InitCmbArea()
        {
            Myobj obj = new Myobj();
            obj.Id = 0;
            obj.Vc_Name = "==请选择上级区域==";
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


}
