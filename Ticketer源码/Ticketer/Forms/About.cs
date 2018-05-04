using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ticketer.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.label1.Text = "本程序纯粹为学习交流而开发\r\n\r\n有任何问题请与作者联系\r\n\r\n联系方式：maidi-mao@163.com";
        }
    }
}
