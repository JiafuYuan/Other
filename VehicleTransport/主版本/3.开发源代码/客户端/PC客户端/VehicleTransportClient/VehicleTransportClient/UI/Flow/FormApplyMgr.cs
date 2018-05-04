using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;
using Common.MessageBoxEx;
using DevComponents.AdvTree;
using VehicleTransportClient.Tools;
using Model = DB_VehicleTransportManage.Model;

namespace VehicleTransportClient
{
    public partial class FormApplyMgr : Common.frmBase
    {
        private OperateTypeEnum _type;
        public DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie _model = new DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie();
        DB_VehicleTransportManage.BLL.m_MaterielType bllMaterielType = new m_MaterielType();
        private DataGridView _dgvListMateriel = null;
        public FormApplyMgr(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie model,DataGridViewEx dgvList)
        {
            InitializeComponent();
            try
            {

                _type = type;
                _dgvListMateriel = dgvList;
                InitCmbMaterie();
                switch (type)
                {
                    case OperateTypeEnum.Add:
                        this.FormTitle = "增加";
                        btnOK.Text = "添加";
                        cmbParentType.SelectedIndex = 0;
                        break;
                    case OperateTypeEnum.Edit:
                        this.FormTitle = "修改";
                        this._model = model;
                        btnOK.Text = "修改";
                        ShowModel();
                        cmbParentType.Enabled = false;
                        break;
                    default:
                        break;
                }
                cmbParentType.Nodes[0].Expand();
            }
            catch
            { }
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
            OperationLog.InsertSqlLog(EnumActionType.Add, "申请物料添加", bllMaterielType.GetMaterielTypeName((int)_model.MaterieTypeID));
            this.DialogResult = DialogResult.OK;

        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void GetModel()
        {
            _model.i_Flag = 0;
            decimal number = 0;
            if (decimal.TryParse(txtCount.Text.Trim(), out number)==false || number<=0)
            {
                throw new Exception("请填写有效数量！");
            }
            _model.n_Count = number;
             _model.MaterieTypeID = ((Myobj)cmbParentType.SelectedNode.Tag).Id;
           
            if (cmbParentType.SelectedNode != null && _model.MaterieTypeID!=0)
            {
                for(int i=0;i<_dgvListMateriel.Rows.Count;i++)
                {
                    if (_dgvListMateriel.Rows[i].Cells[1].Value.ToString() ==
                        ((Myobj)cmbParentType.SelectedNode.Tag).Vc_Name && _type!=OperateTypeEnum.Edit)
                    {
                        throw new Exception("已添加该物料类别请重新选择！");
                    }
                }
            }
            else
            {
                throw new Exception("请选择物料类别！");
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
            txtCount.Text = _model.n_Count.ToString();
            GetNode((int)_model.MaterieTypeID, cmbParentType.Nodes[0]);
            txtMemo.Text = _model.vc_Memo;
        }

        public void GetNode(int id, Node pNode)
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
        public void InitCmbMaterie()
        {
            Myobj obj = new Myobj();
            obj.Id = 0;
            obj.Vc_Name = "==请选择物料类别==";
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

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbParentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Node node = cmbParentType.SelectedNode;
            Myobj obj = (Myobj)node.Tag;
            Model.m_MaterielType model = bllMaterielType.GetModel(obj.Id);
            if (model != null)
            {
                labunit.Text = "(" + model.vc_Unit + ")";
            }
            else
            {
                labunit.Text = "";
            }
        }


    }


}
