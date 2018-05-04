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
using DevComponents.AdvTree;
using Common.MessageBoxEx;
namespace VehicleTransportClient.UI
{
    public partial class FormSupplyCar : Common.frmBase
    {
        private Model.v_Plan _planmodel = new Model.v_Plan();
        Bestway.Windows.Controls.InputPromptDialog inputPromptsupply = new Bestway.Windows.Controls.InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptPerson = new Bestway.Windows.Controls.InputPromptDialog();
        BLL.m_Address bllAddress = new BLL.m_Address();
        BLL.m_Department bllDepartment = new BLL.m_Department();
        BLL.m_Plan_CheckVehicle bllcheckcar = new BLL.m_Plan_CheckVehicle();
        BLL.m_VehicleType bllcartype = new BLL.m_VehicleType();
        BLL.m_Person bllperson = new BLL.m_Person();
        int _supplyaddressid = 0;
        int _personID = 0;
        public FormSupplyCar(Model.v_Plan vplanmodel)
        {
            InitializeComponent();
            _planmodel = vplanmodel;
            this.FormTitle = "运单号:" + _planmodel.vc_PlanCode;
            inputPromptPerson.ClearBind();
            DataSet dataSet = bllperson.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptPerson.Bind(txtPerson, dataSet.Tables[0], 3, new int[] { 1 });
                inputPromptPerson.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(inputPrompt_OnTextChangedEx);

            }
            inputPromptsupply.ClearBind();
            DataSet dataSet1 = bllAddress.DropDownSource();
            inputPromptsupply.Bind(txtsupply, dataSet1.Tables[0], 2, new int[] { 1 });
            inputPromptsupply.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(inputPromptsupply_OnTextChangedEx);
            dtgiven.Value = DateTime.Now;
        }
        void inputPromptsupply_OnTextChangedEx(object sender, Bestway.Windows.Controls.InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _supplyaddressid = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _supplyaddressid = 0;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvList.DataSource;
            FormSupplyCarEditCar frmedit = new FormSupplyCarEditCar(dgvList.Rows);
            DialogResult bresult = frmedit.ShowDialog();
            if (bresult == DialogResult.OK)
            {
                int i = dgvList.Rows.Add(dgvList.Rows.Count + 1, frmedit.checkmodel.VehicleTypeID, bllcartype.GetModel(frmedit.checkmodel.VehicleTypeID.Value).vc_Name, 0, frmedit.checkmodel.i_Count);
                dgvList.Rows[i].Tag = frmedit.checkmodel;
                dgvList.ClearSelection();
                frmedit.Close();

            }

        }

        private void FormSupplyCar_Load(object sender, EventArgs e)
        {
            InitGrid(null);
        }
        private void txtsupply_Click(object sender, EventArgs e)
        {
            inputPromptsupply.ShowDropDown();
        }
        public void InitGrid(Model.m_Plan_CheckVehicle model)
        {
            List<Model.m_Plan_CheckVehicle> listplancar = bllcheckcar.GetModelList("planid=" + _planmodel.ID);

            for (int i = 0; i < listplancar.Count; i++)
            {
                int j = dgvList.Rows.Add(i + 1, listplancar[i].VehicleTypeID, bllcartype.GetModel(listplancar[i].VehicleTypeID.Value).vc_Name, listplancar[i].i_Count, listplancar[i].i_Count);
                dgvList.Rows[j].Tag = listplancar[i];
                dgvList.ClearSelection();
            }


        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                dgvList.Rows.RemoveAt(dgvList.SelectedRows[0].Index);
                InitGridNum();

            }
            else
            {
                MessageBoxEx.Show("请选择要删除的交接车信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void InitGridNum()
        {
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                dgvList.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            btnsave.Enabled = false;
            if (dgvList.Rows.Count == 0)
            {
                MessageBoxEx.Show("请输入供车信息");
                btnsave.Enabled = true;
                return;
            }

            if (_personID == 0)
            {
                MessageBoxEx.Show("请输入供车人");
                btnsave.Enabled = true;
                return;
            }
            if (_supplyaddressid == 0)
            {
                MessageBoxEx.Show("请输入供车地点信息");
                btnsave.Enabled = true;
                return;
            }
            List<Model.m_Plan_GiveVehicle> list = new List<Model.m_Plan_GiveVehicle>();
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                Model.m_Plan_GiveVehicle model = new Model.m_Plan_GiveVehicle();
                int carcount = 0;
                if (int.TryParse(dgvList.Rows[i].Cells["colnumber"].Value.ToString(), out carcount)==false)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("请输入有效供车数量");
                    btnsave.Enabled = true;
                    return;
                }
                model.i_Count = int.Parse(dgvList.Rows[i].Cells["colnumber"].Value.ToString());
                if (model.i_Count < 1)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("请输入有效供车数量");
                    btnsave.Enabled = true;
                    return;
                }
                int plancarcount=0;
                int.TryParse(dgvList.Rows[i].Cells["colplannumber"].Value.ToString(), out plancarcount);
                if (model.i_Count > plancarcount)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("供车数量不能大于计划数量");
                    btnsave.Enabled = true;
                    return;
                }
                model.i_Flag = 0;
                model.PlanID = _planmodel.ID;
                model.VehicleTypeID = int.Parse(dgvList.Rows[i].Cells["colcartypeid"].Value.ToString());
                model.vc_Memo = " ";
                model.ID = 0;
                list.Add(model);
            }
            int deptid = bllperson.GetModel(_personID) == null ? 0 : bllperson.GetModel(_personID).DepartmentID;
            bool bresult = Pub.BackServer.SendGiven(list, _personID, deptid, _supplyaddressid, _planmodel.ID, dtgiven.Value);
            if (bresult == false)
            {
                MessageBoxEx.Show("发送失败,请重新审核");
                btnsave.Enabled = true;
                return;
            }
            else
            {
                MessageBoxEx.Show("完成供车");
                this.DialogResult = DialogResult.OK;
            }


        }

        private void txtPerson_Click(object sender, EventArgs e)
        {
            inputPromptPerson.ShowDropDown();
        }
     
    }
}
