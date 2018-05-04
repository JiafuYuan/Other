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
using DevExpress.XtraBars.ViewInfo;
using DevExpress.XtraDataLayout;
using VehicleTransportClient.Com;
using DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Common.MessageBoxEx;

namespace VehicleTransportClient
{
    public partial class FormPasswordEdit : Common.frmBase
    {
        private DB_VehicleTransportManage.Model.m_User _model = new DB_VehicleTransportManage.Model.m_User();
        private DB_VehicleTransportManage.BLL.m_User bllUser = new m_User();
        private string oldPassWord="";
        public FormPasswordEdit()
        {
            InitializeComponent();
            _model = bllUser.GetModel(Pub.UserId);
            oldPassWord = _model.vc_Password;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.FormTitle = "密码修改";
            ShowModel();
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

            if (bllUser.Update(_model))
            {
                MessageBoxEx.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                OperationLog.InsertSqlLog(EnumActionType.Update, "密码修改,用户名称", bllUser.GetUserName(Pub.UserId));
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("修改失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void GetModel()
        {


            if (txtOldPassword.Text.Trim().Length == 0)
            {
                txtOldPassword.Focus();
                throw new Exception("请输入旧密码！");
            }

            if (txtOldPassword.Text.Trim().IndexOf("'") >= 0)
            {
                txtOldPassword.Focus();
                throw new Exception("旧密码中不可以有特殊字符！");
            }

            if (txtOldPassword.Text.Trim() != oldPassWord)
            {
                txtOldPassword.Focus();
                throw new Exception("旧密码输入不正确！");
            }
            _model.vc_Password = txtNewPassword.Text.Trim();
            if (_model.vc_Password.Length == 0)
            {
                txtNewPassword.Focus();
                throw new Exception("请输入新密码！");
            }
            if (_model.vc_Password.IndexOf("'") >= 0)
            {
                txtNewPassword.Focus();
                throw new Exception("新密码中不可以有特殊字符！");
            }

            if (txtNewPasswordCopy.Text.Trim().Length == 0)
            {
                txtNewPasswordCopy.Focus();
                throw new Exception("请再次输入新密码！");
            }
            if (txtNewPasswordCopy.Text.Trim().IndexOf("'") >= 0)
            {
                txtNewPasswordCopy.Focus();
                throw new Exception("新密码中不可以有特殊字符！");
            }
            if (txtNewPasswordCopy.Text.Trim() != txtNewPassword.Text.Trim())
            {
                txtNewPasswordCopy.Focus();
                throw new Exception("两次输入密码不同！");
                txtNewPasswordCopy.Text = "";
                txtNewPassword.Text = "";
            }
        }

        private void ShowModel()
        {
            txtUserName.Text = _model.vc_Name;
        }


    }
}
