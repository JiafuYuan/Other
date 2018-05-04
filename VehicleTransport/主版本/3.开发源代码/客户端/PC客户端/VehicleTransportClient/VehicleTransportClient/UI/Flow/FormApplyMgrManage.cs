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
using Common.MessageBoxEx;
using DB_VehicleTransportManage.DAL;
using DevComponents.AdvTree;
using DevExpress.XtraBars.ViewInfo;
using VehicleTransportClient.Com;

using Common.Model.InCommandModel;
using Common.Model;
using Model=DB_VehicleTransportManage.Model;
using BLL = DB_VehicleTransportManage.BLL;
using Common;
namespace VehicleTransportClient.UI
{
    public partial class FormApplyMgrManage : Common.frmBase
    {
        private string _tableName = "FormApplyMgrManage";
        //private int _selectIndex = -1;
        DB_VehicleTransportManage.BLL.m_MaterielType bllMaterielType = new DB_VehicleTransportManage.BLL.m_MaterielType();
        DB_VehicleTransportManage.BLL.m_Plan_ApplyMaterie bllApplyMaterie = new DB_VehicleTransportManage.BLL.m_Plan_ApplyMaterie();
        DB_VehicleTransportManage.BLL.m_Plan_ApplyVehicle bllPlanApplyVehicle = new DB_VehicleTransportManage.BLL.m_Plan_ApplyVehicle();
        public List<Model.m_Plan_ApplyMaterie> ListApplyMater = new List<Model.m_Plan_ApplyMaterie>();
        public List<Model.m_Plan_ApplyVehicle> ListApplyCar = new List<Model.m_Plan_ApplyVehicle>();
        public Model.m_Apply Apply = new Model.m_Apply();
        private BLL.m_Department bllDepartment = new BLL.m_Department();
        Bestway.Windows.Controls.InputPromptDialog inputPromptPerson = new InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptAddress = new InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptPersonCar = new InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptAddressCar = new InputPromptDialog();
        BLL.m_Person bllPersonEx = new BLL.m_Person();
        
        BLL.m_Address bllAddress = new BLL.m_Address();
        BLL.m_Apply bllApply = new BLL.m_Apply();
        BLL.m_VehicleType bllVehicleType = new BLL.m_VehicleType();
        private System.Timers.Timer _timer = new System.Timers.Timer(200);
        private int _personID = 0;
        private int _AddressID = 0;
        private int _personIDCar = 0;
        private int _AddressIDCar = 0;
        private bool _FistLoad = false;
        public FormApplyMgrManage()
        {
            InitializeComponent();
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true;
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            InitLoad();
        }

        /// <summary>新增物料
        /// 新增物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormApplyMgr frmedit = new FormApplyMgr(Com.OperateTypeEnum.Add, null,dgvList);
            if (frmedit.ShowDialog() == DialogResult.OK)
            {
                frmedit.Close();
                LoadDataMaterie(frmedit._model);
            }
            
        }

        /// <summary>移除选择的物料
        /// 移除选择的物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                dgvList.Rows.RemoveAt(dgvList.SelectedRows[0].Index);
                InitGridNum();
            }
            else
            {
                MessageBoxEx.Show("请选择要取消申请的物料类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void InitGridNum()
        {
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                dgvList.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void InitCarGridNum()
        {
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {

                dgvListCar.Rows[i].Cells[0].Value = i + 1;
            }
        }
        /// <summary>修改选择物料的内容
        /// 修改选择物料的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                Model.m_Plan_ApplyMaterie _model = (DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie)dgvList.Rows[dgvList.SelectedRows[0].Index].Tag;
                FormApplyMgr frmedit = new FormApplyMgr(Com.OperateTypeEnum.Edit, _model, dgvList);
                if (frmedit.ShowDialog() == DialogResult.OK)
                {
                    dgvList.Rows.RemoveAt(dgvList.SelectedRows[0].Index);
                    frmedit.Close();
                    LoadDataMaterie(frmedit._model);
                    InitGridNum();
                }
                
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的申请物料类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary> 确认并审核按钮
        /// 确认并审核按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (dgvList.Rows.Count > 0)
            {
                Model.m_Apply m_apply = new Model.m_Apply();
                try
                {
                    m_apply=GetModel();
                }
                catch (Exception ex)
                {
                    btnSave.Enabled = true;
                    Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                List<Model.m_Plan_ApplyMaterie> listdetail = new List<Model.m_Plan_ApplyMaterie>();
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                   Model.m_Plan_ApplyMaterie _model = (DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie)dgvList.Rows[i].Tag;
                   _model.ApplyID = 0;
                   listdetail.Add(_model);
                }
                if (Pub.BackServer.SendApplyMater(m_apply, listdetail,_personID,_AddressID,dtTime.Value) == true)
                {
                        MessageBoxEx.Show("申请成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ListApplyMater = listdetail;
                        Apply = m_apply;
                        this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBoxEx.Show("申请失败,请稍后重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
               
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请添加需要申请的物料", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            btnSave.Enabled = true;


        }

      


        /// <summary>初始化下拉绑定等操作
        /// 初始化下拉绑定等操作
        /// </summary>
        private void InitLoad()
        {
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
            //    {
            //        InitLoad();
            //    }));
            //}
            //else
            //{
                inputPromptPerson.ClearBind();
                inputPromptAddress.ClearBind();
                inputPromptPersonCar.ClearBind();
                inputPromptAddressCar.ClearBind();
                DataSet dataSet = bllPersonEx.DropDownSource();
                if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
                {
                    inputPromptPerson.Bind(txtPerson, dataSet.Tables[0], 3, new int[] { 1 });
                    inputPromptPerson.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPrompt_OnTextChangedEx);
                    inputPromptPersonCar.Bind(txtPersonCar, dataSet.Tables[0], 3, new int[] { 1 });
                    inputPromptPersonCar.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptPersonCar_OnTextChangedEx);
                }
                dataSet = bllAddress.DropDownSource();
                if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
                {
                    inputPromptAddress.Bind(txtAddress, dataSet.Tables[0], 2, new int[] { 1 });
                    inputPromptAddress.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptAddress_OnTextChangedEx);
                    inputPromptAddressCar.Bind(txtAddressCar, dataSet.Tables[0], 2, new int[] { 1 });
                    inputPromptAddressCar.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptAddressCar_OnTextChangedEx);
                }

                //InitCmbDutyCar();
                dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvList.AllowUserToAddRows = false;
                dgvList.ReadOnly = true;

                dgvListCar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListCar.AllowUserToAddRows = false;
                dgvListCar.ReadOnly = true;
           // }
        }

        void inputPromptAddressCar_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _AddressIDCar = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _AddressIDCar = 0;
            }
        }

        void inputPromptPersonCar_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {

                _personIDCar = int.Parse(e.SelectedRow["ID"].ToString());

            }
            else
            {
                _personIDCar = 0;
            }
        }
        /// <summary>获得申请人等信息
        /// 获得申请人等信息
        /// </summary>
        private Model.m_Apply GetModel()
        {
             Model.m_Apply _modelApply = new Model.m_Apply();
            if (_AddressID == 0)
            {
                txtAddress.Focus();
                throw new Exception("请选择到达地点！");
            }
            _modelApply.ArriveDestinationAddressID = _AddressID;

           
            if (_personID == 0)
            {
                throw new Exception("申请人必填！");
            }
            if (dtTime.Value <= DateTime.Now)
            {
                throw new Exception("到达时间必须要大于当前时间！");
            }
            //if (cmbDept.SelectedNode != null && ((Myobj)cmbDept.SelectedNode.Tag).Id !=0&& _personID != 0)
            //{
            //    throw new Exception("申请人和申请部门只能选择其一！");
            //}

            if (_personID > 0)
                _modelApply.ApplyPersonID = _personID;
            else
                _modelApply.ApplyPersonID = 0;

            _modelApply.ApplyDepartmentID = bllPersonEx.GetModel(_personID).DepartmentID;

            _modelApply.dt_ApplyDateTime = DateTime.Now;
            _modelApply.dt_ArriveDestinationDateTime = dtTime.Value;

            _modelApply.vc_PlanUse = txtPlanUse.Text.Trim();
            _modelApply.i_IsUseMaterieApply = 1;
            //if (txtPlanUse.Text.Trim().Length == 0)
            //{
            //    txtPlanUse.Focus();
            //    throw new Exception("请填写物料用途！");
            //}
            if (_modelApply.vc_PlanUse.IndexOf("'") >= 0)
            {
                txtPlanUse.Focus();
                throw new Exception("物料用途中不可以有特殊字符！");
            }
            return _modelApply;

        }

        /// <summary>载入编辑或新增的物料
        /// 载入编辑或新增的物料
        /// </summary>
        public void LoadDataMaterie( DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie item)
        {
            int i = dgvList.Rows.Add(dgvList.Rows.Count+1,bllMaterielType.GetMaterielTypeName((int) item.MaterieTypeID), item.n_Count, item.vc_Memo);
            dgvList.Rows[i].Tag = item;
            dgvList.ClearSelection();

        }



        /// <summary>grid样式
        /// grid样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }

        /// <summary>绑定人员下拉
        /// 绑定人员下拉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPerson_Click(object sender, EventArgs e)
        {
            inputPromptPerson.ShowDropDown();
        }
        /// <summary>绑定地点下拉框
        /// 绑定地点下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAddress_Click(object sender, EventArgs e)
        {
            inputPromptAddress.ShowDropDown();
        }

        /// <summary> Grid单击事件
        /// Grid单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //_selectIndex = e.RowIndex;
        }

        void inputPromptAddress_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _AddressID = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _AddressID = 0;
            }
        }

        void inputPrompt_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {

            if (e.IsFind)
            {
                _personID = int.Parse(e.SelectedRow["ID"].ToString());

            }
            else
            {
                _personID = 0;
            }

        }
        private Node GetNode(NodeCollection listnodes, Node node)
        {
            foreach(Node tmpnode in listnodes)
            {
                if (((Myobj)tmpnode.Tag).Id == ((Myobj)node.Tag).Id)
                {
                    //cmbDept.SelectedNode = tmpnode;
                    return tmpnode;
                }
                if (tmpnode.Nodes.Count > 0)
                {
                    Node node2= GetNode(tmpnode.Nodes, node);
                    if (node2 != null)
                    {
                        return node2;
                    }
                }
            }
            return null;
        }
        private void btnAddCar_Click(object sender, EventArgs e)
        {
            FormApplyMgrCar formApplyMgrCar = new FormApplyMgrCar(Com.OperateTypeEnum.Add, null,dgvListCar);
            formApplyMgrCar.ShowDialog();
            if (formApplyMgrCar.DialogResult == DialogResult.OK)
            {
                formApplyMgrCar.Close();
                LoadDataVehicle(formApplyMgrCar._model);
            }
          
        }
        /// <summary>载入编辑或新增的车辆
        /// 载入编辑或新增的车辆
        /// </summary>
        public void LoadDataVehicle(DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle item)
        {
            int i = dgvListCar.Rows.Add(dgvListCar.Rows.Count+1,bllVehicleType.GetVehicleTypeName((int)item.VehicleTypeID), item.i_Count, item.vc_Memo);
            dgvListCar.Rows[i].Tag = item;
            dgvListCar.ClearSelection();

        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            if (dgvListCar.SelectedRows.Count >0)
            {
                Model.m_Plan_ApplyVehicle _modelVehicle = (DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle)dgvListCar.Rows[dgvListCar.SelectedRows[0].Index].Tag;

                FormApplyMgrCar formApplyMgrCar = new FormApplyMgrCar(Com.OperateTypeEnum.Edit, _modelVehicle,dgvListCar);
                formApplyMgrCar.ShowDialog();
                if (formApplyMgrCar.DialogResult == DialogResult.OK)
                {
                    dgvListCar.Rows.RemoveAt(dgvListCar.SelectedRows[0].Index);
                    formApplyMgrCar.Close();
                    LoadDataVehicle(formApplyMgrCar._model);
                    InitCarGridNum();
                }

               
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的申请车辆类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if (dgvListCar.SelectedRows.Count > 0)
            {
                dgvListCar.Rows.RemoveAt(dgvListCar.SelectedRows[0].Index);
                InitCarGridNum();
            }
            else
            {
                MessageBoxEx.Show("请选择要取消申请的车辆类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStyleCar_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvListCar);
        }

        private void btnSaveCar_Click(object sender, EventArgs e)
        {
            btnSaveCar.Enabled = false;
            if (dgvListCar.Rows.Count > 0)
            {
                Model.m_Apply m_apply = new Model.m_Apply();
                try
                {
                    m_apply=GetModelVehicle();
                }
                catch (Exception ex)
                {
                    btnSaveCar.Enabled = true;
                    Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                List<Model.m_Plan_ApplyVehicle> listdetail = new List<Model.m_Plan_ApplyVehicle>();
                for (int i = 0; i < dgvListCar.Rows.Count; i++)
                {
                    Model.m_Plan_ApplyVehicle  _modelVehicle = (DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle)dgvListCar.Rows[i].Tag;
                    _modelVehicle.ApplyID = 0;
                    listdetail.Add(_modelVehicle);
                }
                if (Pub.BackServer.SendApplyCar(m_apply, listdetail,_personIDCar,_AddressIDCar,dtTimeCar.Value) == true)
                {
                        btnSaveCar.Enabled = true;
                        MessageBoxEx.Show("申请成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Apply = m_apply;
                        ListApplyCar = listdetail;
                        this.DialogResult = DialogResult.OK;
                }
                else
                {
                    btnSaveCar.Enabled = true;
                    MessageBoxEx.Show("申请失败,请稍后重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
               
            }
            else
            {
                btnSaveCar.Enabled = true;
                Common.MessageBoxEx.MessageBoxEx.Show("请添加需要申请的车辆", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btnSaveCar.Enabled = true;
        }

        private Model.m_Apply GetModelVehicle()
        {
            Model.m_Apply _modelApply = new Model.m_Apply();
            if (_AddressIDCar == 0)
            {
                txtAddressCar.Focus();
                throw new Exception("请选择到达地点！");
            }
            _modelApply.ArriveDestinationAddressID = _AddressIDCar;


            if ( _personIDCar == 0)
            {
                throw new Exception("申请人必填！");
            }
            if (dtTimeCar.Value <= DateTime.Now)
            {
                throw new Exception("到达时间必须大于当前时间！");
            }
            //if (cmbDeptCar.SelectedNode != null && ((Myobj)cmbDeptCar.SelectedNode.Tag).Id != 0 && _personIDCar != 0)
            //{
            //    throw new Exception("申请人和申请部门只能选择其一！");
            //}

            if (_personIDCar > 0)
                _modelApply.ApplyPersonID = _personIDCar;
            else
                _modelApply.ApplyPersonID = 0;

            _modelApply.ApplyDepartmentID = bllPersonEx.GetModel(_personIDCar).DepartmentID;

            _modelApply.dt_ApplyDateTime = DateTime.Now;
            _modelApply.dt_ArriveDestinationDateTime = dtTimeCar.Value;

            _modelApply.vc_PlanUse = txtPlanUseCar.Text.Trim();
            _modelApply.i_IsUseMaterieApply = 0;
            //if (txtPlanUseCar.Text.Trim().Length == 0)
            //{
            //    txtPlanUseCar.Focus();
            //    throw new Exception("请填写车辆用途！");
            //}
            if (_modelApply.vc_PlanUse.IndexOf("'") >= 0)
            {
                txtPlanUseCar.Focus();
                throw new Exception("物料用途中不可以有特殊字符！");
            }
            return _modelApply;
        }

        private void txtPersonCar_Click(object sender, EventArgs e)
        {
           inputPromptPersonCar.ShowDropDown();
        }

        private void txtAddressCar_Click(object sender, EventArgs e)
        {
            inputPromptAddressCar.ShowDropDown();
        }


        private void cmbDept_SelectionChanged(object sender, AdvTreeNodeEventArgs e)
        {
            txtPerson.Text = "";
            _personID = 0;
        }

        private void cmbDeptCar_SelectionChanged(object sender, AdvTreeNodeEventArgs e)
        {
            txtPersonCar.Text = "";
            _personIDCar = 0;
        }

        private void FormApplyMgrManage_Load(object sender, EventArgs e)
        {
            if (Pub.ListFunRight.Contains("btnCheck") == false)
            {
                btnSave.Text = "提交";
                btnSaveCar.Text = "提交";
            }
        }

      

      

      
    }
}
