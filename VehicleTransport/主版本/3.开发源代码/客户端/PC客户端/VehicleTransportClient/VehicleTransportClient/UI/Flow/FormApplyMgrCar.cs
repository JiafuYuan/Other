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

namespace VehicleTransportClient
{
    public partial class FormApplyMgrCar : Common.frmBase
    {
        private OperateTypeEnum _type;
        public DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle _model = new DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle();
        DB_VehicleTransportManage.BLL.m_VehicleType bllVehicleType = new m_VehicleType();
        Bestway.Windows.Controls.InputPromptDialog inputPromptDialogCarType = new InputPromptDialog();
        private int _CarTypeID=0;
        private DataGridViewEx _dgvListCar = null;
        public FormApplyMgrCar(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle model,DataGridViewEx dgvList)
        {
            InitializeComponent();
            try
            {
                _type = type;
                _dgvListCar = dgvList;
                InitCarType();
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
                        txtCarType.Enabled = false;
                        break;
                    default:
                        break;
                }
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
            OperationLog.InsertSqlLog(EnumActionType.Add, "申请车辆添加", bllVehicleType.GetVehicleTypeName((int)_model.VehicleTypeID));
            this.DialogResult = DialogResult.OK;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void GetModel()
        {
            _model.i_Flag = 0;
            int number = 0;
            if (int.TryParse(txtCount.Text.Trim(), out number) == false || number <= 0)
            {
                throw new Exception("请填写有效数量！");
            }
            _model.i_Count = number;
           
            if(_CarTypeID==0)
            {
                throw new Exception("请选择车辆类别！");
            }
            else
            {
                for (int i = 0; i < _dgvListCar.Rows.Count; i++)
                {
                    if (_dgvListCar.Rows[i].Cells[1].Value.ToString() == txtCarType.Text.Trim() && _type != OperateTypeEnum.Edit)
                    {
                        throw new Exception("已添加该车辆类型请重新选择！");
                    }
                }
           
            }
            _model.VehicleTypeID = _CarTypeID;
            _model.vc_Memo = txtMemo.Text.Trim();
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }

        }

        private void ShowModel()
        {
            txtCount.Text = _model.i_Count.ToString();
            txtCarType.Text = bllVehicleType.GetVehicleTypeName((int) _model.VehicleTypeID);
            txtMemo.Text = _model.vc_Memo;
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
                _CarTypeID = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _CarTypeID = 0;
            }
        }

        private void txtCarType_Click(object sender, EventArgs e)
        {
            inputPromptDialogCarType.ShowDropDown();
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

      


    }


}
