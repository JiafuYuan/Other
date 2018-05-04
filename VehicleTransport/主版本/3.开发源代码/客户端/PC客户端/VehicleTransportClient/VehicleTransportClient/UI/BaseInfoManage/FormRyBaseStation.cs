using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;
using Common.MessageBoxEx;
using DevComponents.AdvTree;

namespace VehicleTransportClient
{
    public partial class FormRyBaseStation : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_Localizer _model = new DB_VehicleTransportManage.Model.m_Localizer();
        private DB_VehicleTransportManage.BLL.m_Localizer bllLocalizer = new m_Localizer();

        public FormRyBaseStation(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Localizer model)
        {
            InitializeComponent();
            _type = type;
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


                if (bllLocalizer.IsExitCode(_model.vc_Code, _model.ID))

                {
                    Common.MessageBoxEx.MessageBoxEx.Show("基站编号 【" + _model.vc_Code + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (bllLocalizer.IsExitName(_model.vc_Name, _model.ID))

                {
                    Common.MessageBoxEx.MessageBoxEx.Show("基站名称 【" + _model.vc_Name + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (bllLocalizer.IsExitHID(_model.i_HID, _model.ID))

                {
                    Common.MessageBoxEx.MessageBoxEx.Show("基站HID 【" + _model.i_HID + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if ((new DB_VehicleTransportManage.BLL.m_Localizer()).Add(_model) >0)
                {
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "定位基站", "HID:"+_model.i_HID.ToString());
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (_type == OperateTypeEnum.Edit)
            {
                if (bllLocalizer.IsExitCode(_model.vc_Code,_model.ID))

                {
                    Common.MessageBoxEx.MessageBoxEx.Show("基站编号 【" + _model.vc_Code + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (bllLocalizer.IsExitName(_model.vc_Name, _model.ID))

                {
                    Common.MessageBoxEx.MessageBoxEx.Show("基站名称 【" + _model.vc_Name + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (bllLocalizer.IsExitHID(_model.i_HID, _model.ID))

                {
                    Common.MessageBoxEx.MessageBoxEx.Show("基站HID 【" + _model.i_HID + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if ((new DB_VehicleTransportManage.BLL.m_Localizer()).Update(_model))
                {
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "定位基站", "HID:" + _model.i_HID.ToString());
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
            _model.i_Type = 1;
            _model.i_Flag = 0;
            _model.vc_Code = txtCode.Text.Trim();
            if (_model.vc_Code == "")
            {
                txtCode.Focus();
                throw new Exception("基站编号不可以为空！");
            }
            if (_model.vc_Code.IndexOf("'") >= 0)
            {
                txtCode.Focus();
                throw new Exception("基站编号中不可以有特殊字符！");
            }
            _model.vc_Name = txtName.Text.Trim();
            if (_model.vc_Name == "")
            {
                txtName.Focus();
                throw new Exception("基站名称不可以为空！");
            }
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("基站名称中不可以有特殊字符！");
            }

            if (txtHid.Text.Trim().Length == 0)
            {
                txtHid.Focus();
                throw new Exception("基站HID不可以为空！");
            }

            _model.i_HID = int.Parse(txtHid.Text.Trim());


        }

        private void ShowModel()
        {
            txtCode.Text = _model.vc_Code;
            txtName.Text = _model.vc_Name;
            txtHid.Text = _model.i_HID.ToString();

        }

        private void txtHid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char) 13 && e.KeyChar != (char) 8)
            {
                e.Handled = true;
            }
        }
    }
}
