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
using BLL = DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;
using DevComponents.AdvTree;
using Common.MessageBoxEx;

namespace VehicleTransportClient
{
    public partial class FormVehicle : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_Vehicle _model = new DB_VehicleTransportManage.Model.m_Vehicle();
        private BLL.m_Vehicle bllVehicle = new BLL.m_Vehicle();
        Bestway.Windows.Controls.InputPromptDialog inputPromptDialogCarType = new InputPromptDialog();
        private int _inputCarType = 0;
        private BLL.m_Department bllDept = new BLL.m_Department();
        private BLL.m_VehicleType bllVehicleType = new BLL.m_VehicleType();
        private BLL.m_Address bllAddress = new BLL.m_Address();
        public FormVehicle(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Vehicle model)
        {
            InitializeComponent();
            _type = type;
            InitCarType();
            InitCmbDept();
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
            cmbDept.Nodes[0].Expand();//全部展开ComBoTree
            dtInputStop.MinDate = DateTime.Now;
            inputPromptDialogCarType.HideForm();
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
                DataSet dataSet = bllAddress.GetList("");
                if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
                {
                    //_model.i_LocalizerStationID = int.Parse(dataSet.Tables[0].Rows[0]["LocalizerStationID"].ToString());

                    _model.i_State = 0;
                    //判断地点是否存在
                    if (bllVehicle.GetModelList(" i_flag=0 and vc_Name='" + _model.vc_Name + "'").Count > 0)
                    {
                        MessageBoxEx.Show("车辆名称 【" + _model.vc_Name + "】 已存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    //判断地点是否存在
                    if (bllVehicle.GetModelList(" i_flag=0 and vc_Code='" + _model.vc_Code + "'").Count > 0)
                    {
                        MessageBoxEx.Show("车辆编号 【" + _model.vc_Code + "】 已存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    _model.dt_LastMaintainDateTIme = DateTime.Now;
                    _model.dt_CreateDateTime = DateTime.Now;
                    _model.dt_InLocalizerStationDateTime = DateTime.Now;
                    _model.ID = bllVehicle.Add(_model);
                    if (_model.ID > 0)
                    {
                        Pub.GISForm.LoadGrid();
                        Pub.GisManage.UpdataGisAndDBRemark();
                        //Pub.GisManage.AddFeature(EnumLayerName.车辆, _model, true);
                        MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        OperationLog.InsertSqlLog(EnumActionType.Add, "车辆名称", _model.vc_Name);
                        this.Close();
                    }
                    else
                    {
                        MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_Vehicle> lstUser = bllVehicle.GetModelList(" i_flag=0 and  vc_Name='" + _model.vc_Name + "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("车辆名称【" + _model.vc_Name + "】 已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                lstUser = bllVehicle.GetModelList(" i_flag=0 and  vc_Code='" + _model.vc_Code + "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("车辆编号【" + _model.vc_Code + "】 已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                if (bllVehicle.Update(_model))
                {
                    Pub.GISForm.LoadGrid();
                    Pub.GisManage.UpdataGisAndDBRemark();
                    //Pub.GisManage.ModifyFeature(EnumLayerName.车辆, _model, true);
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "车辆名称", _model.vc_Name);
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
            if (_model.vc_Name.Length == 0)
            {
                txtName.Focus();
                throw new Exception("请输入车辆名称！");
            }
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("车辆名称中不可以有特殊字符！");
            }
            _model.vc_Code = txtCode.Text.Trim();
            if (_model.vc_Code.Length == 0)
            {
                txtCode.Focus();
                throw new Exception("请输入车辆编号！");
            }
            if (_model.vc_Code.IndexOf("'") >= 0)
            {
                txtCode.Focus();
                throw new Exception("车辆编号中不可以有特殊字符！");
            }

            if (_inputCarType == 0)
            {
                txtType.Focus();
                throw new Exception("请选择正确的车辆类型名称！");
            }
            _model.VehicleTypeID = _inputCarType;
            if (txtMaintainInterval.Text.Trim().Length > 0)
                _model.i_MaintainInterval = int.Parse(txtMaintainInterval.Text.Trim());
            else
            {
                _model.i_MaintainInterval = 0;
            }


            if (cmbDept.SelectedIndex != 0)
            {
                _model.DepartmentID = ((Myobj)cmbDept.SelectedNode.Tag).Id;
            }
            else
            {
                throw new Exception("请选择部门！");
            }

            if (dtInputStop.Value.Year != 1)
            {
                _model.dt_ScrapDateTime = dtInputStop.Value;
                if (_model.dt_ScrapDateTime <= DateTime.Now)
                {
                    throw new Exception("请选择正确的报废日期！");
                }
            }

            if (txtSafeLoad.Text.Trim().Length > 0)
                _model.i_SafeLoad = int.Parse(txtSafeLoad.Text.Trim());
            else
            {
                _model.i_SafeLoad = 0;
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
            txtType.Text = bllVehicleType.GetVehicleTypeName((int)_model.VehicleTypeID);
            txtMaintainInterval.Text = _model.i_MaintainInterval.ToString();
            if (_model.dt_ScrapDateTime != null)
                dtInputStop.Value = (DateTime)_model.dt_ScrapDateTime;
            GetNode((int)_model.DepartmentID, cmbDept.Nodes[0]);
            txtMemo.Text = _model.vc_Memo;
            txtSafeLoad.Text = _model.i_SafeLoad.ToString();
        }

        /// <summary>
        /// 获得选择的Node节点
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pNode"></param>
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

        //初始化ComboTree
        public void InitCmbDept()
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

        //递归增加Node节点
        public void LoadCmboTree(Node nd)
        {
            DataSet ds = new DataSet();
            ds = bllDept.GetList(" i_Flag=0 and ParentID=" + ((Myobj)nd.Tag).Id);
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

        //初始化
        public void InitCarType()
        {
            inputPromptDialogCarType.ClearBind();
            DataSet dataSet = bllVehicleType.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptDialogCarType.Bind(txtType, dataSet.Tables[0], 2, new int[] { 1 });
                inputPromptDialogCarType.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptDialogCarType_OnTextChangedEx);
            }

        }

        void inputPromptDialogCarType_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _inputCarType = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _inputCarType = 0;
            }
        }

        private void txtType_Click(object sender, EventArgs e)
        {
            inputPromptDialogCarType.ShowDropDown();
        }

        private void txtMaintainInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtSafeLoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }





    }


}
