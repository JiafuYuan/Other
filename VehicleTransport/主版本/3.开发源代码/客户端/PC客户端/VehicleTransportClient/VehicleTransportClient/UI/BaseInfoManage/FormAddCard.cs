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
using DB_VehicleTransportManage;
using VehicleTransportClient.Com;
using DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Common.MessageBoxEx;

namespace VehicleTransportClient
{
    public partial class FormAddCard : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_Card _model = new DB_VehicleTransportManage.Model.m_Card();
        private m_VehicleType bllVehicleType = new m_VehicleType();
        private m_Card bllCard = new m_Card();
        private m_Vehicle bllVehicle = new m_Vehicle();
        Bestway.Windows.Controls.InputPromptDialog inputPromptDialogCarType = new InputPromptDialog();
        private int _inputCarType = 0;
        List<DB_VehicleTransportManage.Model.m_Vehicle> listVehicle = new List<DB_VehicleTransportManage.Model.m_Vehicle>();
        public FormAddCard()
        {
            InitializeComponent();
            this.FormTitle = "批量发卡";
            InitCarType();
            txtType.Text = "所有类型";
            inputPromptDialogCarType.HideForm();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_inputCarType == -1)
            {
                MessageBoxEx.Show("请选择存在的车辆类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (txtStartNum.Text.Length == 0 || txtOverNum.Text.Length == 0)
            {
                MessageBoxEx.Show("请输入正确的号码段", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            int iStart = int.Parse(txtStartNum.Text);
            int iOver = int.Parse(txtOverNum.Text);
            int i = 0;
            //if (iStart > 32767  )
            //{
            //    MessageBoxEx.Show("起始卡号应小于32767", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            //if (iOver > 32767)
            //{
            //    MessageBoxEx.Show("截止卡号应小于32767", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            if (iStart >= iOver)
            {
                MessageBoxEx.Show("请输入正确的号码段", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            DataSet dataSet = bllCard.GetList(String.Format("i_Flag=0 and i_IdentificationCardHID>{0} and i_IdentificationCardHID<{1}", iStart, iOver));

            if (bllCard.Kj222HIDUsed(iStart, iOver) || (dataSet != null && dataSet.Tables[0].Rows.Count > 0))
            {
                MessageBoxEx.Show("该号码段中的卡已被使用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            bool bState = true;
            if (listVehicle.Count > 0)
            {
                DB.OleDbHelper.BeginTransaction();
                foreach (DB_VehicleTransportManage.Model.m_Vehicle mVehicle in listVehicle)
                {
                    _model.VehicleID = mVehicle.ID;
                    _model.i_IdentificationCardHID = iStart + i;
                    _model.i_LocalizerCardHID = iStart + i;
                    _model.i_Flag = 0;
                    if (InsertHID((int)_model.i_LocalizerCardHID))
                    {
                        if (bllCard.Add(_model) > 0)
                        {
                            bState = true;
                            OperationLog.InsertSqlLog(EnumActionType.Add, "车辆名称,发卡卡号", bllVehicle.GetVehicleName((int)_model.VehicleID)[1] + "," + _model.i_LocalizerCardHID);
                        }
                        else
                        {
                            bState = false;

                        }
                    }
                    else
                    {
                        bState = false;

                    }
                    i++;
                    if ((iStart + i) > iOver)
                    {
                        break;
                    }
                }
                if (bState)
                {
                    DB.OleDbHelper.Commit();
                    if (
                        MessageBoxEx.Show(String.Format("本次{0}辆车发卡成功,是否继续发卡", i), "提示", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }

                }
                else
                {
                    DB.OleDbHelper.Rollback();
                    MessageBoxEx.Show("该号码段中的卡已被使用，发卡失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBoxEx.Show("所有车辆已经发卡", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private bool InsertHID(int i_LocalizerCardHID)
        {
            bool bInsertHID = true;
            if (!(bllCard.InsertKj222Hid(i_LocalizerCardHID)))
            {
                bInsertHID = false;
            }

            return bInsertHID;
        }

        private void txtStartNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtOverNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        void inputPromptDialogCarType_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {

            if (e.IsFind)
            {
                _inputCarType = int.Parse(e.SelectedRow["ID"].ToString());
                if (_inputCarType == 0)
                {
                    listVehicle = bllVehicle.GetModelList(
                      "i_Flag=0 and i_state=0 and ID not in (select VehicleID from m_card where i_Flag=0)");
                }
                else
                {
                    listVehicle = bllVehicle.GetModelList(
                      "i_Flag=0 and i_state=0 and VehicleTypeID=" + _inputCarType + " and ID not in (select VehicleID from m_card where i_Flag=0)");

                }
                lblTip.Text = "车辆类型【" + e.SelectedRow["类型名称"].ToString() + "】共有【" + listVehicle.Count.ToString() + "】辆车未发卡";
            }
            else
            {
                _inputCarType = -1;
            }
            

        }
        //初始化
        public void InitCarType()
        {
            inputPromptDialogCarType.ClearBind();
            DataSet dataSet = bllVehicleType.AddCardDropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptDialogCarType.Bind(txtType, dataSet.Tables[0], 2, new int[] { 1 });
                inputPromptDialogCarType.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptDialogCarType_OnTextChangedEx);
            }

        }

        private void txtType_Click(object sender, EventArgs e)
        {
            inputPromptDialogCarType.ShowDropDown();
        }
    }


}
