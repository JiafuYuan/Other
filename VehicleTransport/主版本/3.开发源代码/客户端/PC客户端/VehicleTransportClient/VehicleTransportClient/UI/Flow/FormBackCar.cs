using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model = DB_VehicleTransportManage.Model;
using Common.MessageBoxEx;
using BLL = DB_VehicleTransportManage.BLL; 
namespace VehicleTransportClient.UI
{
    public partial class FormBackCar : Common.frmBase
    {
        Bestway.Windows.Controls.InputPromptDialog inputPromptPerson = new Bestway.Windows.Controls.InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptAddress = new Bestway.Windows.Controls.InputPromptDialog();
        BLL.m_Address bllAddress = new BLL.m_Address();
        BLL.m_Person bllperson = new BLL.m_Person();
        int _personID = 0;
        int _AddressID = 0;
        public FormBackCar()
        {
            InitializeComponent();
            try
            {
                InitPerson();
                InitAddress();
                txtAddress.Click += new EventHandler(txtAddress_Click);
                txtPerson.Click += new EventHandler(txtPerson_Click);
                btnAdd.Click += new EventHandler(btnAdd_Click);
                btnEdit.Click += new EventHandler(btnEdit_Click);
                btnDel.Click += new EventHandler(btnDel_Click);
            }
            catch
            { }
        }

        void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                dgvList.Rows.RemoveAt(dgvList.SelectedRows[0].Index);
                InitGridNum();

            }
            else
            {
                MessageBoxEx.Show("请选择要删除的车辆信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {

                FormBackCarEdit frmedit = new FormBackCarEdit(Com.OperateTypeEnum.Edit, dgvList.Rows, dgvList.SelectedRows[0].Index);
                if (frmedit.ShowDialog() == DialogResult.OK)
                {
                    Model.m_Vehicle entity = frmedit.model;
                    dgvList.Rows.RemoveAt(dgvList.SelectedRows[0].Index);
                    frmedit.Close();
                    int i = dgvList.Rows.Add(dgvList.Rows.Count + 1,
                   entity.vc_Code);
                    dgvList.Rows[i].Tag = entity;
                    InitGridNum();
                }
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的车辆信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {

            FormBackCarEdit frmedit = new FormBackCarEdit(Com.OperateTypeEnum.Add, dgvList.Rows, 0);
            DialogResult bresult = frmedit.ShowDialog();
            if (bresult == DialogResult.OK)
            {
                frmedit.Close();
                Model.m_Vehicle entity = frmedit.model;
                int i = dgvList.Rows.Add(dgvList.Rows.Count + 1,
                    entity.vc_Code);
                dgvList.Rows[i].Tag = entity;
            }
            else
            {
                frmedit.Close();
            }
        }

        void txtPerson_Click(object sender, EventArgs e)
        {
            inputPromptPerson.ShowDropDown();
        }

        void txtAddress_Click(object sender, EventArgs e)
        {
            inputPromptAddress.ShowDropDown();
        }
        private void InitPerson()
        {
            inputPromptPerson.ClearBind();
            DataSet dataSet = bllperson.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptPerson.Bind(txtPerson, dataSet.Tables[0], 3, new int[] { 1 });
                inputPromptPerson.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(inputPrompt_OnTextChangedEx);

            }

        }
        private void InitAddress()
        {
            inputPromptAddress.ClearBind();

            DataSet dataSet1 = bllAddress.DropDownSource();
            if (dataSet1 != null && dataSet1.Tables[0].Rows.Count > 0)
            {
                inputPromptAddress.Bind(txtAddress, dataSet1.Tables[0], 2, new int[] { 1 });
                inputPromptAddress.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(inputPromptAddress_OnTextChangedEx);

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
        void inputPromptAddress_OnTextChangedEx(object sender, Bestway.Windows.Controls.InputPromptDialog.TextChanagedEventArgs e)
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
        private void InitGridNum()
        {
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                dgvList.Rows[i].Cells[0].Value = i + 1;
            }
        }
     

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (_AddressID == 0)
            {
                MessageBoxEx.Show("请选择还车地点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnSave.Enabled = true;
                return;
            }
            if (_personID == 0)
            {
                MessageBoxEx.Show("请选择还车人", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnSave.Enabled = true;
                return;
            }
            if (dgvList.Rows.Count == 0)
            {
                MessageBoxEx.Show("请输入车辆信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnSave.Enabled = true;
                return;
            }
            List<Model.m_Plan_BackVehicle> listMain = new List<Model.m_Plan_BackVehicle>();
        
            List<int> listcar = new List<int>();
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                Model.m_Vehicle entity = (Model.m_Vehicle)dgvList.Rows[i].Tag;
                if (listcar.Contains(entity.ID) == false)
                {
                    listcar.Add(entity.ID);
                    Model.m_Plan_BackVehicle mainentity = new Model.m_Plan_BackVehicle();
                    mainentity.AddressID = _AddressID;
                    mainentity.i_Flag = 0;
                    mainentity.PersonID = _personID;
                    mainentity.vc_Memo = "";
                    mainentity.VehicleID = entity.ID;
                    mainentity.dt_DateTime = dtTime.Value;
                    mainentity.PlanID = 0;
                    listMain.Add(mainentity);
                   
                }

            }
            bool bresult = Pub.BackServer.SendBack(listMain,0, _personID, _AddressID, dtTime.Value);
            if (bresult == false)
            {
                Common.MessageBoxEx.MessageBoxEx.Show("发送失败,请重新审核");
                btnSave.Enabled = true;
                return;
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("完成还车");
                this.DialogResult = DialogResult.OK;
            }

        }
    }
}
