using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using VehicleTransportClient.Com;
using Model=DB_VehicleTransportManage.Model;
using Common.MessageBoxEx;
namespace VehicleTransportClient
{
    public partial class FormRule : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_Rule _model = new DB_VehicleTransportManage.Model.m_Rule();
        DB_VehicleTransportManage.BLL.m_Rule _bll = new DB_VehicleTransportManage.BLL.m_Rule();
        public FormRule(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_Rule model)
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

        private void FormRule_Load(object sender, EventArgs e)
        {

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
                    (new DB_VehicleTransportManage.BLL.m_Rule()).GetModelList(" i_flag=0 and vc_Name='" + _model.vc_Name +
                                                                             "'").Count > 0)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("角色名称 【" + _model.vc_Name + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if ((new DB_VehicleTransportManage.BLL.m_Rule()).Add(_model) >0)
                {
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "角色名称", _model.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_Rule> lstUser =
                    (new DB_VehicleTransportManage.BLL.m_Rule()).GetModelList(" i_flag=0 and  vc_Name ='" + _model.vc_Name +
                                                                             "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        Common.MessageBoxEx.MessageBoxEx.Show("角色名称 【" + _model.vc_Name + "】 已经存在", "添加失败",
                         MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                if ((new DB_VehicleTransportManage.BLL.m_Rule()).Update(_model))
                {
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, " 角色名称", _model.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("编辑失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonEx2_Click(object sender, EventArgs e)
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
                throw new Exception("角色名称不可以为空！");
            }
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("角色名称中不可以有特殊字符！");
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
