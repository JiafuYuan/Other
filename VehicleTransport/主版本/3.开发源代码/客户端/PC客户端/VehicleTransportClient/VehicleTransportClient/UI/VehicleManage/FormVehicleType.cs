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
    public partial class FormVehicleType : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_VehicleType _model = new DB_VehicleTransportManage.Model.m_VehicleType();
        private DB_VehicleTransportManage.BLL.m_VehicleType bll = new m_VehicleType();

        public FormVehicleType(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_VehicleType model)
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
                if (
                    (new DB_VehicleTransportManage.BLL.m_VehicleType()).GetModelList(" i_flag=0 and vc_Name='" + _model.vc_Name +
                                                                             "'").Count > 0)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("车辆类型名称 【" + _model.vc_Name + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if ((new DB_VehicleTransportManage.BLL.m_VehicleType()).Add(_model) >0)
                {
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "PDA名称", "Mac地址:"+_model.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_VehicleType> lstUser =
                    (new DB_VehicleTransportManage.BLL.m_VehicleType()).GetModelList(" i_flag=0 and  vc_Name ='" + _model.vc_Name +
                                                                             "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("车辆类型名称【" + _model.vc_Name + "】 已经存在", "编辑失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                if ((new DB_VehicleTransportManage.BLL.m_VehicleType()).Update(_model))
                {
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "车辆类型名称", _model.vc_Name);
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
            if (_model.vc_Name == "")
            {
                txtName.Focus();
                throw new Exception("车辆类型名称不可以为空！");
            }
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("车辆类型名称中不可以有特殊字符！");
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
            txtName.Text = _model.vc_Name;
            txtMemo.Text = _model.vc_Memo;
        }

    }
}
