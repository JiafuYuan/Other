using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.MessageBoxEx;
using DB_VehicleTransportManage;
using BLL = DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Model = DB_VehicleTransportManage.Model;
using Bestway.Windows.Controls;
namespace VehicleTransportClient.UI
{
    public partial class FormLoadCar : Common.frmBase
    {
        BLL.m_Address bllAddress = new BLL.m_Address();
        BLL.m_Department bllDepartment = new BLL.m_Department();
        BLL.m_MaterielType bllMaterielType = new BLL.m_MaterielType();
        BLL.m_Apply bllapply = new BLL.m_Apply();
        BLL.m_Person bllperson = new BLL.m_Person();
        Bestway.Windows.Controls.InputPromptDialog inputPromptAddress = new InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptPerson = new Bestway.Windows.Controls.InputPromptDialog();
        private int _AddressID = 0;
        private int _selectIndex = -1;
        private Model.v_Plan _vplanmodel = new Model.v_Plan();
        private bool _bCarApply = false;
        int _personID = 0;
        public FormLoadCar(Model.v_Plan vplanmodel)
        {
            InitializeComponent();
            try
            {
                _vplanmodel = vplanmodel;
                this.FormTitle = "运单号：" + _vplanmodel.vc_PlanCode;
                Model.m_Apply applymodel = bllapply.GetModel(_vplanmodel.ApplyID.Value);
                if (applymodel.i_IsUseMaterieApply == 0)
                {
                    _bCarApply = true;
                }
                InitLoad();
                dtTime.Value = DateTime.Now;
            }
            catch
            { }
        }
        private void InitLoad()
        {

            inputPromptPerson.ClearBind();
            DataSet dataSet = bllperson.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptPerson.Bind(txtPerson, dataSet.Tables[0], 3, new int[] { 1 });
                inputPromptPerson.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(inputPrompt_OnTextChangedEx);

            }

            inputPromptAddress.ClearBind();

            DataSet dataSet1 = bllAddress.DropDownSource();
            if (dataSet1 != null && dataSet1.Tables[0].Rows.Count > 0)
            {
                inputPromptAddress.Bind(txtAddress, dataSet1.Tables[0], 2, new int[] { 1 });
                inputPromptAddress.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptAddress_OnTextChangedEx);

            }
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormLoadCarMateriel formLoadCarMateriel = new FormLoadCarMateriel(Com.OperateTypeEnum.Add, null, dgvList);
            formLoadCarMateriel.ShowDialog();
            if (formLoadCarMateriel.DialogResult == DialogResult.OK)
            {
                formLoadCarMateriel.Close();
                LoadDataMaterie(formLoadCarMateriel.planModel);
            }
        }

        void inputPrompt_OnTextChangedEx(object sender, Bestway.Windows.Controls.InputPromptDialog.TextChanagedEventArgs e)
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


        private void txtAddress_Click(object sender, EventArgs e)
        {
            inputPromptAddress.ShowDropDown();
        }
        public Model.m_Plan GetModel()
        {
            if (_AddressID == 0)
            {
                throw new Exception("请填写装货地址");
            }
            if (_personID == 0)
            {
                throw new Exception("请填写装车人");

            }
            Model.m_Plan_Load _model = new Model.m_Plan_Load();
            Model.m_Plan _modelPlan = new Model.m_Plan();
            _modelPlan.vc_PlanCode = _vplanmodel.vc_PlanCode;
            _modelPlan.RealLoadPersonID = _personID;
            _modelPlan.RealLoadDepartmentID = bllperson.GetModel(_personID) == null ? 0 : bllperson.GetModel(_personID).DepartmentID;

            _modelPlan.RealLoadAddressID = _AddressID;
            _modelPlan.dt_RealLoadDateTime = dtTime.Value;
            _model.vc_Memo ="";
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {

                throw new Exception("物料用途中不可以有特殊字符！");
            }
            return _modelPlan;
        }
        /// <summary>载入编辑或新增的物料
        /// 载入编辑或新增的物料
        /// </summary>
        public void LoadDataMaterie(DB_VehicleTransportManage.Model.m_Plan_Load item)
        {
            BLL.m_Vehicle bllVehicle = new BLL.m_Vehicle();
            int i = dgvList.Rows.Add(dgvList.Rows.Count + 1, bllVehicle.GetModel(item.VehicleID.Value).vc_Code, bllMaterielType.GetModel(item.MaterieTypeID.Value).vc_Name, item.n_Count, item.vc_Memo);
            dgvList.Rows[i].Tag = item;
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (dgvList.Rows.Count > 0)
            {


                Model.m_Plan m_plan = new Model.m_Plan();
                try
                {
                    m_plan = GetModel();
                }
                catch (Exception ex)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnSave.Enabled = true;
                    return;
                }
                List<Model.m_Plan_Load> listdetail = new List<Model.m_Plan_Load>();
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    Model.m_Plan_Load _model = (DB_VehicleTransportManage.Model.m_Plan_Load)dgvList.Rows[i].Tag;
                    _model.PlanID = _vplanmodel.ID;
                    _model.i_Flag = 0;
                    _model.vc_Memo = "";
                    listdetail.Add(_model);
                }
                bool bresult = Pub.BackServer.SendLoad(listdetail, _AddressID, m_plan.RealLoadPersonID.Value, m_plan.RealLoadDepartmentID.Value, _vplanmodel.ID, dtTime.Value);
                if (bresult == false)
                {
                    MessageBoxEx.Show("发送失败,请重新审核");
                    btnSave.Enabled = true;
                    return;
                }
                else
                {
                    MessageBoxEx.Show("完成装车");
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请添加装车信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnSave.Enabled = true;
                return;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                Model.m_Plan_Load _model = (DB_VehicleTransportManage.Model.m_Plan_Load)dgvList.Rows[_selectIndex].Tag;
                FormLoadCarMateriel frmedit = new FormLoadCarMateriel(Com.OperateTypeEnum.Edit, _model, dgvList);
                if (frmedit.ShowDialog() == DialogResult.OK)
                {
                    dgvList.Rows.RemoveAt(_selectIndex);
                    frmedit.Close();
                    LoadDataMaterie(frmedit.planModel);
                    InitGridNum();

                }
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的装车信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void InitGridNum()
        {
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                dgvList.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                dgvList.Rows.RemoveAt(_selectIndex);
                InitGridNum();
            }
            else
            {
                MessageBoxEx.Show("请选择要删除的装车信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        /// <summary>详细信息按钮
        /// 详细信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndetail_Click(object sender, EventArgs e)
        {
            FormLoadCarDetail formLoadCarDetail = new FormLoadCarDetail(_vplanmodel.ID);
            formLoadCarDetail.ShowDialog();
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        private void txtPerson_Click(object sender, EventArgs e)
        {
            inputPromptPerson.ShowDropDown();
        }
    }
}
