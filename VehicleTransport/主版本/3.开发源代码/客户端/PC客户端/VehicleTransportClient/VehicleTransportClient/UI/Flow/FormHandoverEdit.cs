using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using Bestway.Windows.Controls;
using DevComponents.AdvTree;
using Common.Enum;
namespace VehicleTransportClient.UI
{

    public partial class FormHandoverEdit : Common.frmBase
    {
        BLL.m_MaterielType bllMaterielType = new BLL.m_MaterielType();
        BLL.m_Vehicle bllVehicle = new BLL.m_Vehicle();
        public Model.v_handover handovermodel = new Model.v_handover();
        Bestway.Windows.Controls.InputPromptDialog inputPromptDialog = new InputPromptDialog();
        DataGridViewRowCollection _dgrows = null; 
        int _CarID = 0;
        Com.OperateTypeEnum _OperateType;
        int _EditIndex = 0;
        public FormHandoverEdit(Com.OperateTypeEnum operatetype,DataGridViewRowCollection dgrows,int rowindex)
        {
            InitializeComponent();
            try
            {
                _dgrows = dgrows;
                InitCmbMaterie();
                InitCar();
                cmbParentType.Nodes[0].Expand();
                _OperateType = operatetype;
                _EditIndex = rowindex;
                if (_OperateType == Com.OperateTypeEnum.Edit)
                {
                    ShowModel();
                    txtCar.Enabled = false;
                    cmbParentType.Enabled = false;
                }
            }
            catch
            { }
        }

        private void ShowModel()
        {
            Model.v_handover entity = (Model.v_handover)_dgrows[_EditIndex].Tag;
            txtCar.Text = entity.carcode;
            txtCount.Text = entity.n_Count.Value.ToString();
            GetNode(entity.MaterieTypeID.Value, cmbParentType.Nodes[0]);
            _CarID = entity.VehicleID.Value;

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
            this.DialogResult = DialogResult.OK;
        }

        private void txtCar_Click(object sender, EventArgs e)
        {
            inputPromptDialog.ShowDropDown();
        }
        private void InitCar()
        {
            inputPromptDialog.ClearBind();
        DataSet dataSet = bllVehicle.DropDownSource("i_State=" + Common.Enum.EnumVehicleState.Using.GetHashCode());
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptDialog.Bind(txtCar, dataSet.Tables[0], 2, new int[] { 1 });
                inputPromptDialog.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptDialog_OnTextChangedEx);
            }
        }
        void inputPromptDialog_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                btnOK.Enabled = false;
                btnNo.Enabled = false;
                _CarID = int.Parse(e.SelectedRow["ID"].ToString());
                bool iscando = Pub.BackServer.SendCarOperate(EnumFlowPathType.Handover, _CarID);
                if (iscando == false)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("该车辆无法进行交接车");
                    _CarID = 0;
                    txtCar.Text = "";
                }
                btnOK.Enabled = true;
                btnNo.Enabled = true;
                
            }
            else
            {
                _CarID = 0;
            }
        }

        private void cmbParentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Node node = cmbParentType.SelectedNode;
            if (node == null)
                return;
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
        private void GetModel()
        {
            decimal count = 0;
            if (decimal.TryParse(txtCount.Text, out count) == false)
            {
                txtCount.Focus();
                throw new Exception("请填写有效物料数量！");
            }
            if (count <= 0)
            {
                txtCount.Focus();
                throw new Exception("请填写有效物料数量！");
            }
            if (_CarID == 0)
            {
                txtCar.Text = "";
                throw new Exception("请填写车辆编号");
            }
            handovermodel.VehicleID = _CarID;
            handovermodel.n_Count = count;
            handovermodel.MaterieTypeID = cmbParentType.SelectedNode == null ? 0 : ((Myobj)cmbParentType.SelectedNode.Tag).Id;
            handovermodel.carcode = txtCar.Text;
            handovermodel.matername = ((Myobj)cmbParentType.SelectedNode.Tag).Vc_Name;

            if (cmbParentType.SelectedNode != null && handovermodel.MaterieTypeID != 0)
            {

            }
            else
            {
                throw new Exception("请选择物料类别！");
            }
            for (int i = 0; i < _dgrows.Count; i++)
            {
                if (((Model.v_handover)_dgrows[i].Tag).MaterieTypeID == handovermodel.MaterieTypeID && ((Model.v_handover)_dgrows[i].Tag).VehicleID == handovermodel.VehicleID)
                {
                    if (_OperateType == Com.OperateTypeEnum.Add)
                    {
                        throw new Exception("该车辆对应的物料已经存在！");
                    }
                    else
                    {
                        if (_EditIndex != i)
                        {
                            throw new Exception("该车辆对应的物料已经存在！");
                        }
                    }
                }
                else
                {
                    continue;
                }
            }



        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }
}
