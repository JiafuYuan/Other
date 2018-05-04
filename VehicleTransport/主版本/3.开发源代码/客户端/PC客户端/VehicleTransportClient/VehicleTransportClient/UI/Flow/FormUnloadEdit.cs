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
using DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;
using Common.MessageBoxEx;
using DevComponents.AdvTree;
using BLL=DB_VehicleTransportManage.BLL;
using Model=DB_VehicleTransportManage.Model;
namespace VehicleTransportClient
{
    public partial class FormUnloadEdit : Common.frmBase
    {

        public Model.v_unload model = new Model.v_unload();
        BLL.m_MaterielType bllMaterielType = new m_MaterielType();
        BLL.m_Vehicle bllVehicle = new m_Vehicle();
        Bestway.Windows.Controls.InputPromptDialog inputPromptDialog = new InputPromptDialog();
        private int _CarID = 0;
        int _i_state = -1;
        DataGridViewRowCollection _dgrows = null;
        Com.OperateTypeEnum _OperateType;
        int _EditIndex = 0;
        public FormUnloadEdit(Com.OperateTypeEnum operatetype, DataGridViewRowCollection dgrows, int rowindex)
        {
            InitializeComponent();
            InitCmbMaterie();
            InitLoad();
            _dgrows = dgrows;
            _OperateType = operatetype;
            cmbParentType.Nodes[0].Expand();
            _EditIndex = rowindex;
            if (_OperateType == Com.OperateTypeEnum.Edit)
            {
                ShowModel();
                cmbParentType.Enabled = false;
                txtCar.Enabled = false;
            }
            
        }

        private void ShowModel()
        {
            Model.v_unload entity = (Model.v_unload)_dgrows[_EditIndex].Tag;
            txtCar.Text = entity.carcode;
            txtCount.Text = entity.n_Count.Value.ToString();
            GetNode(entity.MaterieTypeID.Value, cmbParentType.Nodes[0]);
            _CarID = entity.VehicleID.Value;

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

        private void btnNo_Click(object sender, EventArgs e)
        {

            this.Close();
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
            if (cmbParentType.SelectedNode != null && model.MaterieTypeID != 0)
            {

            }
            else
            {
                throw new Exception("请选择物料类别！");
            }
            model.VehicleID = _CarID;
            model.n_Count = count;
            model.MaterieTypeID = cmbParentType.SelectedNode==null?0:((Myobj)cmbParentType.SelectedNode.Tag).Id;
            model.carcode = txtCar.Text;
            model.matername = ((Myobj)cmbParentType.SelectedNode.Tag).Vc_Name;

           
            for (int i = 0; i < _dgrows.Count; i++)
            {
                if (((Model.v_unload)_dgrows[i].Tag).MaterieTypeID == model.MaterieTypeID && ((Model.v_unload)_dgrows[i].Tag).VehicleID == model.VehicleID)
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

        /// <summary>初始化下拉绑定等操作
        /// 初始化下拉绑定等操作
        /// </summary>
        private void InitLoad()
        {
            inputPromptDialog.ClearBind();
            DataSet dataSet = bllVehicle.DropDownSource("i_State="+Common.Enum.EnumVehicleState.Using.GetHashCode());
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
                bool iscando = Pub.BackServer.SendCarOperate(EnumFlowPathType.UnLoad, _CarID);
                if (iscando == false)
                {
                    MessageBoxEx.Show("该车辆无法进行卸车");
                    txtCar.Text = "";
                    _CarID = 0;
                }
                btnOK.Enabled = true;
                btnNo.Enabled = true;
            }
            else
            {
                _CarID = 0;
            }
        }

        private void txtCar_Click(object sender, EventArgs e)
        {
           inputPromptDialog.ShowDropDown();
        }

        private void cmbParentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Node node = cmbParentType.SelectedNode;
            if (node==null)
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

    }


}
