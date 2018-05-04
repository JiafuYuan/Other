using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL=DB_VehicleTransportManage.BLL;
using Model=DB_VehicleTransportManage.Model;
using Bestway.Windows.Controls;
namespace VehicleTransportClient.UI
{
    public partial class FormSupplyCarEditCar : Common.frmBase
    {
        BLL.m_VehicleType bllVehicleType = new BLL.m_VehicleType();
        Bestway.Windows.Controls.InputPromptDialog inputPromptDialogCarType = new InputPromptDialog();
        private int CarTypeID = 0;
        public Model.m_Plan_CheckVehicle checkmodel = new Model.m_Plan_CheckVehicle();

        public DataGridViewRowCollection _Dgvrows;
        public FormSupplyCarEditCar(DataGridViewRowCollection rows)
        {
            InitializeComponent();
            _Dgvrows = rows;
        }

        private void FormSupplyCarEditCar_Load(object sender, EventArgs e)
        {
            InitCarType();
        }
        //初始化
        public void InitCarType()
        {
            inputPromptDialogCarType.ClearBind();
            DataSet dataSet = bllVehicleType.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptDialogCarType.Bind(txtCarType, dataSet.Tables[0], 2, new int[] { 1 });
                inputPromptDialogCarType.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptDialogCarType_OnTextChangedEx);
            }

        }

        void inputPromptDialogCarType_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                CarTypeID = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                CarTypeID = 0;
            }
        }

        private void txtCarType_Click(object sender, EventArgs e)
        {
            inputPromptDialogCarType.ShowDropDown();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            int number=txtnumber.Value;
            if (number<=0)
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请输入有效数字");
                return;
            }
            if (CarTypeID == 0)
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请输入车辆类型");
                return;
            }
            for (int i = 0; i < _Dgvrows.Count;i++)
            {
                if (_Dgvrows[i].Cells["colcartypeid"].Value.ToString() == CarTypeID.ToString())
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("该车辆类别已经存在");
                    txtCarType.Text = "";
                    txtnumber.Value = 0;
                    CarTypeID = 0;
                    return;
                }
            }
          
                checkmodel.VehicleTypeID = CarTypeID;
                checkmodel.i_Count = number;
                this.DialogResult = DialogResult.OK;
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
