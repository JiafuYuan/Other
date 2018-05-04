using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar.Controls;
using Common;
using Common.MessageBoxEx;

using VehicleTransportClient.Com;

namespace VehicleTransportClient.UI
{
    public partial class frmDatabaseConfig : frmBase
    {
        Bestway.Windows.Forms.ProgressBarDialog frmProcess = new Bestway.Windows.Forms.ProgressBarDialog();
        public frmDatabaseConfig()
        {
            InitializeComponent();
        }

        private void frmDatabaseConfig_Load(object sender, EventArgs e)
        {
            ShowConfig();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GetConfigModel();

            frmProcess.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "正在连接数据库...");

            if (Program.OpenDataBase() == false)
            {
                frmProcess.Hide();
                MessageBoxEx.Show("数据库连接失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SaveConfig();
            }
        }

        private void SaveConfig()
        {
            if (Config.WriteModel(Pub.ConfigModel))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                frmProcess.Hide();

                MessageBoxEx.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowConfig()
        {
            txtserver.Text = Pub.ConfigModel.DBServer;
            txtdb.Text = Pub.ConfigModel.DBName;
            txtuserno.Text = Pub.ConfigModel.DBUserName;
            txtdbpwd.Text = Pub.ConfigModel.DBPassword;
        }

        private ConfigModel GetConfigModel()
        {
            Pub.ConfigModel.DBServer = txtserver.Text;
            Pub.ConfigModel.DBName = txtdb.Text;
            Pub.ConfigModel.DBUserName = txtuserno.Text;
            Pub.ConfigModel.DBPassword = txtdbpwd.Text;
            return Pub.ConfigModel;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmDatabaseConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmProcess.Dispose();
        }


    }
}
