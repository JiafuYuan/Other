using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Ticketer.Forms
{
    public partial class VerificationCode : Form
    {


        public string Code = string.Empty;

        public VerificationCode()
        {
            InitializeComponent();
            setVPicture();
            Thread thread = new Thread(new ParameterizedThreadStart(checkInput));
            thread.Start(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getVerificationCode();
        }

        private void getVerificationCode()
        {
            if (this.textBox1.Text.Length != 4)
            {
                this.label1.Text = "赶快输入正确的验证码...";
                this.textBox1.Text = string.Empty;
                return;
            }
            Code = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                getVerificationCode();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            setVPicture();
        }

        private void setVPicture()
        {
            HttpHelper helper = new HttpHelper(string.Format("{0}&{1}", LinkAddress.ORDERIMG_ADDRESS, (new Random()).Next()));
            helper.Request.Method = "GET";
            this.pictureBox1.Image = helper.GetResponseIMG();
            this.textBox1.Text = string.Empty;
            this.textBox1.Focus();
        }

        private void checkInput(object arg)
        {
            while (textBox1.Text.Length != 4)
            {
                Thread.Sleep(500);
            }
            getVerificationCode();
        }
    }
}
