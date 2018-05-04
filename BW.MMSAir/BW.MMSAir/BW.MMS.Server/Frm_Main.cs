using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BW.MMS.Server
{
    public partial class Frm_Main : Form
    {
        SocServer socServer;
        public Frm_Main()
        {
            InitializeComponent();
            socServer = new SocServer(SysConfig .LocalIP, SysConfig .LocalPort .ToString ());
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            socServer.StartListing();
            btnListen.Enabled = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
           socServer.Send(textBox1 .Text.Trim());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "客户端数为：" + socServer.getClientCount();
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            socServer = null;
            GC.Collect();
            Application.Exit();
        }
    }
}
