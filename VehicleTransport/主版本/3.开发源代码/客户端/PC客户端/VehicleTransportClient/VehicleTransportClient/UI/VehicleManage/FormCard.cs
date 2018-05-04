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
using VehicleTransportClient.Com;
using DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Common.MessageBoxEx;

namespace VehicleTransportClient
{
    public partial class FormCard : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_Card _model = new DB_VehicleTransportManage.Model.m_Card();
        
        m_Card bllCard = new m_Card();
        m_Vehicle bllVehicle = new m_Vehicle();
        Bestway.Windows.Controls.InputPromptDialog inputPrompt = new InputPromptDialog();
        private int _iInputVehicle = 0;
        private int _iOldIdentificationCardHID = 0;
        private int _iOldLocalizerCardHID = 0;
        public FormCard(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Card model)
        {
            InitializeComponent();
            _type = type;
            InitVehicle();
            switch (type)
            {
                case OperateTypeEnum.Add:
                    this.FormTitle = "发卡";
                    btnOK.Text = "保存";
                    break;
                case OperateTypeEnum.Edit:
                    this.FormTitle = "换卡";
                    this._model = model;
                    _iOldIdentificationCardHID = model.i_IdentificationCardHID.Value;
                    _iOldLocalizerCardHID = model.i_LocalizerCardHID.Value;
                    btnOK.Text = "保存";
                    txtVehicle.Enabled = false;
                    ShowModel();
                    break;
                default:
                    break;
            }
            inputPrompt.HideForm();
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
                if (bllCard.GetModelList(" i_flag=0 and VehicleID=" + _model.VehicleID).Count > 0)
                {
                    MessageBoxEx.Show("车辆名称 【" + txtVehicle.Text + "】 已发卡", "发卡失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                if (InsertHID((int)_model.i_LocalizerCardHID))
                {

                    if (bllCard.Add(_model) > 0)
                    {
                        MessageBoxEx.Show("发卡成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        OperationLog.InsertSqlLog(EnumActionType.Add, "车辆名称发卡", txtVehicle.Text);
                        this.Close();
                    }
                    else
                    {
                        DeleteHID((int)_model.i_LocalizerCardHID);
                        MessageBoxEx.Show("该卡号已经存在，发卡失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBoxEx.Show("该卡号已经存在，发卡失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_Card> lstUser = bllCard.GetModelList(" i_flag=0 and  VehicleID='" + _model.VehicleID + "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("车辆名称【" + txtVehicle.Text + "】 已经发卡", "换卡失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                if (UpdateHID(_iOldLocalizerCardHID, (int)_model.i_LocalizerCardHID))
                {
                    if (bllCard.Update(_model))
                    {
                        MessageBoxEx.Show("换卡成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        OperationLog.InsertSqlLog(EnumActionType.Update, "车辆名称发卡", txtVehicle.Text);
                        this.Close();
                    }
                    else
                    {
                        UpdateHID((int)_model.i_LocalizerCardHID, _iOldLocalizerCardHID);
                        MessageBoxEx.Show("该卡号已经存在，发卡失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBoxEx.Show("该卡号已经存在，发卡失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtVehicle.Enabled)
            {
                _model.VehicleID = _iInputVehicle;
                if (_model.VehicleID == 0)
                {
                    txtIdentificationCard.Focus();
                    throw new Exception("请选择正确的车辆名称！");
                }
            }
            if (txtLocalizerCard.Text.Trim().Length == 0 || txtLocalizerCard.Text.Trim().Length > 20)
            {
                txtLocalizerCard.Focus();
                throw new Exception("请输入正确的定位卡HID！");
            }
            //if (int.Parse(txtLocalizerCard.Text.Trim())>32767)
            //{
            //    txtLocalizerCard.Focus();
            //    throw new Exception("定位卡HID应小于32767！");
            //}
            _model.i_LocalizerCardHID = int.Parse(txtLocalizerCard.Text.Trim());

            if (txtIdentificationCard.Text.Trim().Length == 0 || txtIdentificationCard.Text.Trim().Length > 20)
            {
                txtIdentificationCard.Focus();
                throw new Exception("请输入正确的标识卡HID！");
            }
            //if (int.Parse(txtIdentificationCard.Text.Trim()) > 32767)
            //{
            //    txtIdentificationCard.Focus();
            //    throw new Exception("标识卡HID应小于32767！");
            //}
            _model.i_IdentificationCardHID = int.Parse(txtIdentificationCard.Text.Trim());

            _model.vc_Memo = txtMemo.Text.Trim();
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }

        }

        private void ShowModel()
        {
            txtVehicle.Text = bllVehicle.GetVehicleName((int)_model.VehicleID)[1];
            txtLocalizerCard.Text = _model.i_LocalizerCardHID.ToString();
            txtIdentificationCard.Text = _model.i_IdentificationCardHID.ToString();
            txtMemo.Text = _model.vc_Memo;
        }

        public void InitVehicle()
        {
            inputPrompt.ClearBind();
            DataSet dataSet = bllVehicle.DropDownSource(" i_state=0 and ID not in (select VehicleID from m_card where i_Flag=0)");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPrompt.Bind(txtVehicle, dataSet.Tables[0], 3, new int[] { 1 });
                inputPrompt.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPrompt_OnTextChangedEx);
            }

        }

        void inputPrompt_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            _iInputVehicle = 0;
            if (e.IsFind)
            {
                _iInputVehicle = int.Parse(e.SelectedRow["ID"].ToString());
            }
        }

        private void txtVehicle_Click(object sender, EventArgs e)
        {
            inputPrompt.ShowDropDown();
        }

        private void txtLocalizerCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
           
        }

        private void txtIdentificationCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
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

        private bool DeleteHID(int i_LocalizerCardHID)
        {
            bool bDeleteHID = true;

            if (!(bllCard.DeleteKj222Hid(i_LocalizerCardHID)))
            {

                bDeleteHID = false;
            }

            return bDeleteHID;
        }


        private bool UpdateHID(int i_LocalizerCardHIDOld, int i_LocalizerCardHIDNew)
        {
            bool bDeleteHID = true;

            if (!(bllCard.UpdateKj222Hid(i_LocalizerCardHIDOld, i_LocalizerCardHIDNew)))
            {

                bDeleteHID = false;
            }

            return bDeleteHID;
        }

        private void txtLocalizerCard_TextChanged(object sender, EventArgs e)
        {
                txtIdentificationCard.Text = txtLocalizerCard.Text;
        }
    }


}
