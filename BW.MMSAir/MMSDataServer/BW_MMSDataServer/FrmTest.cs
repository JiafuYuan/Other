using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Tools.OPC;

namespace Bestway.Windows.Program.MMS
{
    public partial class FrmTest : Form
    {
        OpcClient opc = new OpcClient();
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            opc.DataChanged += new Opc.Da.DataChangedEventHandler(opc_DataChanged);
        }

        void opc_DataChanged(object subscriptionHandle, object requestHandle, Opc.Da.ItemValueResult[] values)
        {
            txtResult.Text = values[0].Value.ToString();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (opc.Connect("192.168.28.237", "", "Adminstrator", "123456"))
            { }
        }
    }
}
