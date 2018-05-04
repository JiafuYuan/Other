using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model = DB_VehicleTransportManage.Model;
using DB_VehicleTransportManage.BLL;
using Common.MessageBoxEx;
namespace VehicleTransportClient.UI
{
    public partial class FrmLogin : Form
    {

        private m_User _userbll = new m_User();
        private m_RuleDetail _ruledetailbll = new m_RuleDetail();
        public FrmLogin()
        {
            InitializeComponent();
         
        }

        private void btcancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();

        private void btok_Click(object sender, EventArgs e)
        {
            //procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "  正在登录，请稍等...");
            lblOk.Enabled = false;
            if (Pub.BackServer.Login(txtuser.Text, txtpwd.Text))
            {
                //procDlg.Dispose();
                List<Model.m_User> listuser = _userbll.GetModelList("vc_Name='" + txtuser.Text + "' and vc_Password='" + txtpwd.Text + "' and i_flag=0");
                if (listuser.Count > 0)
                {
                    if (listuser[0].RuleID != null)
                    {
                        List<Model.m_RuleDetail> listdetail = _ruledetailbll.GetModelList("i_Flag=0 and RuleID=" + listuser[0].RuleID.Value.ToString());
                        foreach(Model.m_RuleDetail model in listdetail)
                        {
                            Pub.ListFunRight.Add(model.vc_ModuleName);
                        }

                    }
                    Pub.UserId = listuser[0].ID;
                    Pub.UserName = txtuser.Text;
                    Pub.Pwd = txtpwd.Text;
                    if (Pub.BackServer.SendGetFlow())
                    {
                        this.DialogResult = DialogResult.OK;
                    }

                }

            }
            else
            {
                if (string.IsNullOrEmpty(Pub.errorLogin) == false)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show(Pub.errorLogin);
                }
                else
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("登录失败");
                }
                //procDlg.Dispose();
                txtuser.Text = "";
                txtpwd.Text = "";
                txtuser.Focus();
                //MessageBoxEx.Show("请输入有效的用户信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            lblOk.Enabled = true;
        }

        private void txtpwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btok_Click(null,null);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtuser.Focus();
        }

     
    }
}
