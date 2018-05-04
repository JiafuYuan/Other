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
using Bestway.Windows.Tools.Communication.Net;
using VehicleTransportClient.Com;

namespace VehicleTransportClient.UI
{
    public partial class frmServerConfig : frmBase
    {
        Bestway.Windows.Forms.ProgressBarDialog frmProcess = new Bestway.Windows.Forms.ProgressBarDialog();
        private bool _IsConnect = false;
        SocketClient _msocketClient = null;
        public frmServerConfig()
        {
            InitializeComponent();
        }

        private void frmDatabaseConfig_Load(object sender, EventArgs e)
        {
            ShowConfig();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                InitSocket();
                GetConfigModel();
                SaveConfig();
                Program.procDlg.Hide();
            }
            catch(Exception ex)
            {
                Program.procDlg.Hide();
                this.Show();
                Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }
          

        
        }

        private void SaveConfig()
        {
            if (Config.WriteModel(Pub.ConfigModel))
            {
                this.DialogResult = DialogResult.OK;
                
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBoxEx.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowConfig()
        {
            txtIP.Value = Pub.ConfigModel.LocalIP;
            txtPort.Text = Pub.ConfigModel.Port.ToString();
            txtServerIP.Value = Pub.ConfigModel.ServerIP;
        }

        private ConfigModel GetConfigModel()
        {
            Pub.ConfigModel.LocalIP = txtIP.Value;
            Pub.ConfigModel.Port = int.Parse(txtPort.Text);
            Pub.ConfigModel.ServerIP = txtServerIP.Value;

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

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void InitSocket()
        {
            this.Hide();
            Program.procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "正在测试连接");
            string locaip = txtIP.Text;
            string serverip = txtServerIP.Text;
            string strport = txtPort.Text;
            int port = 0;
            if (string.IsNullOrEmpty(locaip) == true)
            {
                throw new Exception("请输入本机IP地址");
            }
            if (string.IsNullOrEmpty(serverip) == true)
            {
                throw new Exception("请输入服务器IP地址");
              
            }
            if (string.IsNullOrEmpty(strport) == true || int.TryParse(strport,out port)==false)
            {
                throw new Exception("请输入有效的端口");

            }
            
            try
            {
                _msocketClient = new SocketClient(locaip);
            }
            catch
            {
                throw new Exception("请输入本机IP地址");

            }
            _msocketClient.SocketConnected += new SocketEventHandler(msocketClient_SocketConnected);
            bool b = _msocketClient.Connect(serverip, port, 0.1);
            if (b == false)
            {
                throw new Exception("无法连接服务器");
            }

        }
        void msocketClient_SocketConnected(object sender, SocketEventArgs e)
        {
            _msocketClient.Close();
        }
  


    }
}
