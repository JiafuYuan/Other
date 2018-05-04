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
using VehicleTransportClient.Tools;
using BLL=DB_VehicleTransportManage.BLL;
using Model=DB_VehicleTransportManage.Model;
namespace VehicleTransportClient
{
    public partial class FormLoadCarMateriel : Common.frmBase
    {
        private OperateTypeEnum _type;
        public Model.m_Plan_Load planModel = new Model.m_Plan_Load();
        BLL.m_MaterielType bllMaterielType = new m_MaterielType();
        BLL.m_Vehicle bllVehicle = new m_Vehicle();
        Bestway.Windows.Controls.InputPromptDialog inputPromptDialog = new InputPromptDialog();
        private int _CarID = 0;
        private DataGridViewEx _dgvListCar = null;
        public FormLoadCarMateriel(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Plan_Load model, DataGridViewEx dgvList)
        {
            InitializeComponent();
            try
            {
                _type = type;
                _dgvListCar = dgvList;
                InitCmbMaterie();
                InitLoad();
                switch (type)
                {
                    case OperateTypeEnum.Add:
                        this.FormTitle = "增加";
                        btnOK.Text = "添加";
                        cmbParentType.SelectedIndex = 0;
                        break;
                    case OperateTypeEnum.Edit:
                        this.FormTitle = "修改";
                        this.planModel = model;
                        btnOK.Text = "修改";
                        ShowModel();
                        txtCar.Enabled = false;
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
            OperationLog.InsertSqlLog(EnumActionType.Add, "装车信息添加", bllMaterielType.GetMaterielTypeName((int)planModel.MaterieTypeID));
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
            planModel.i_Flag = 0;
            planModel.MaterieTypeID = cmbParentType.SelectedNode == null ? 0 : ((Myobj)cmbParentType.SelectedNode.Tag).Id;
            if (planModel.MaterieTypeID==0)
            {
                throw new Exception("请选择物料类别！");
            }
          

            if (_CarID == 0)
            {
                throw new Exception("请选择发卡后的空车！");
            }
            else
            {
                for (int i = 0; i < _dgvListCar.Rows.Count; i++)
                {
                    DB_VehicleTransportManage.Model.m_Plan_Load item = (DB_VehicleTransportManage.Model.m_Plan_Load)_dgvListCar.Rows[i].Tag;
                    if (_dgvListCar.Rows[i].Cells["carnumber"].Value.ToString() == txtCar.Text.Trim() && item.MaterieTypeID == planModel.MaterieTypeID && _type != OperateTypeEnum.Edit)
                    {
                        throw new Exception("这辆车已经录入该物料信息");
                    }
                }

            }
            planModel.VehicleID = _CarID;
            planModel.n_Count = count;
            planModel.MaterieTypeID = ((Myobj)cmbParentType.SelectedNode.Tag).Id;

          

            planModel.vc_Memo = txtMemo.Text.Trim();
            if (planModel.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }



        }

        private void ShowModel()
        {
            txtCar.Text = bllVehicle.GetVehicleName((int)planModel.VehicleID)[1];
            txtCount.Text = planModel.n_Count.ToString();
            GetNode((int)planModel.MaterieTypeID, cmbParentType.Nodes[0]);
            txtMemo.Text = planModel.vc_Memo;
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
            DataSet dataSet = bllVehicle.DropDownSource("i_State="+(int)Common.Enum.EnumVehicleState.Normal +" and ID in (select VehicleID from m_Card where i_Flag=0)");
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
                bool iscando=Pub.BackServer.SendCarOperate(EnumFlowPathType.Load, _CarID);
                if (iscando == false)
                {
                    MessageBoxEx.Show("该车辆无法进行装车");
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

    }


}
