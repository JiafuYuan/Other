using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DB_VehicleTransportManage.BLL;

namespace VehicleTransportClient.UI.SystemManage
{
    public partial class FormLockSystem : Form
    {
        private DB_VehicleTransportManage.Model.m_User _model = new DB_VehicleTransportManage.Model.m_User();
        private DB_VehicleTransportManage.BLL.m_User bllUser = new m_User();
        private string oldPassWord = "";
        public FormLockSystem()
        {
            InitializeComponent();
            _model = bllUser.GetModel(Pub.UserId);
            oldPassWord = _model.vc_Password;
            ShowModel();
        }
        protected override void WndProc(ref   Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                return;
            }
            base.WndProc(ref m);
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

            this.Close();
        }

        private void GetModel()
        {
            _model.vc_Password = txtNewPassword.Text.Trim();
            if (_model.vc_Password.Length == 0)
            {
                txtNewPassword.Focus();
                throw new Exception("请输入解锁密码！");
            }
            if (_model.vc_Password.IndexOf("'") >= 0 || oldPassWord != txtNewPassword.Text.Trim())
            {
                txtNewPassword.Focus();
                throw new Exception("解锁密码不正确！");
            }

        }

        private void ShowModel()
        {
            lblUserName.Text = _model.vc_Name;
        }

    }
}
