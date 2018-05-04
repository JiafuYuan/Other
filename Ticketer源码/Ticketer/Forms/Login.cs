using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace Ticketer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "登录")
            {
                this.button1.Text = "停止";
                this.label1.Text = "登录中请稍后......";
                if (!getLoginCode())
                {
                    MessageBox.Show("服务器连接失败！");
                    this.DialogResult = DialogResult.Cancel;
                    this.Dispose();
                }
                setLabelLocation();
                thread = new Thread(new ParameterizedThreadStart(threadLogin));
                string[] arg = new string[3];
                arg[0] = this.textBox1.Text;
                arg[1] = this.textBox2.Text;
                arg[2] = this.textBox3.Text;
                thread.Start(arg);
                File.WriteAllText(userFilePath, string.Format("{0}|{1}", arg[0], arg[1]), Encoding.UTF8);
            }
            else
            {
                thread.Abort();
                this.button1.Text = "登录";
                this.label1.Text = "";
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (File.Exists(userFilePath))
            {
                string userinfo = File.ReadAllText(userFilePath, Encoding.UTF8);
                this.textBox1.Text = userinfo.Split('|')[0];
                this.textBox2.Text = userinfo.Split('|')[1];
            }
            setLoginImg();
        }

        private void threadLogin(object arg)
        {
            int i = 1;
            string[] strs = arg as string[];
            while (!login(strs))
            {
                if (!string.IsNullOrEmpty(this.errorMsg))
                {
                    setButtonText("登录");
                    setLabelText(this.errorMsg);
                    if (this.errorMsg.IndexOf("验证码") > -1)
                    {
                        setLoginImg();
                    }
                    Thread.CurrentThread.Abort();
                }
                Thread.Sleep(3000);
                setLabelText(string.Format("第{0}次登录，登录中请稍后......", ++i));
            }
            MessageBox.Show("登录成功，开始查询车票吧");
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 获取登录随机码
        /// </summary>
        private bool getLoginCode()
        {
            HttpHelper helper = new HttpHelper(LinkAddress.LOGINSUGGEST);
            helper.Request.Method = "GET";
            helper.Request.ContentType = "text/xml; charset=utf-8";
            JsonObject json = helper.GetResponseJSON();
            if (json["randError"].Value.ToLower().Equals("y"))
            {
                loginCode = json["loginRand"].Value;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 登录系统
        /// </summary>
        /// <returns></returns>
        private bool login(string[] args)
        {
            HttpHelper helper = new HttpHelper(LinkAddress.LOGIN_ADDRESS);
            helper.Request.Method = "POST";
            helper.RequestData = new Dictionary<string, string>();
            helper.RequestData.Add("loginRand", loginCode);
            helper.RequestData.Add("loginUser.user_name", args[0]);
            helper.RequestData.Add("user.password", args[1]);
            helper.RequestData.Add("randCode", args[2]);
            helper.RequestData.Add("refundFlag", "Y");
            helper.RequestData.Add("refundLogin", "N");
            helper.RequestData.Add("nameErrorFocus", "");
            helper.RequestData.Add("passwordErrorFocus", "");
            helper.RequestData.Add("randErrorFocus", "");
            //helper.GetResponse();
            string str = helper.GetResponseSTRING();
            if (str.IndexOf("欢迎您登录") > -1)
            {
                return true;
            }
            else
            {
                if (str.IndexOf("请输入正确的验证码") > -1)
                    errorMsg = "验证码错误";
                else
                {
                    Regex reg = new Regex(@"var\s+message\s*=\s*\u0022([^\u0022]*)\u0022");
                    Match m = reg.Match(str);
                    if (m != null && m.Groups.Count == 2)
                        errorMsg = m.Groups[1].Value;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取登录验证码
        /// </summary>
        private void setLoginImg()
        {
            HttpHelper helper = new HttpHelper(LinkAddress.LOGINIMG_ADDRESS);
            helper.Request.Method = "GET";
            try
            {
                this.pictureBox1.Image = helper.GetResponseIMG();
            }
            catch (Exception)
            {
                MessageBox.Show("网络连接错误");
                this.Close();
            }

            if (helper.ServerDateTime.Hour >= 23 || helper.ServerDateTime.Hour <= 7)
            {
                isAllowLogin = false;
                this.button1.Enabled = false;
                this.label1.Text = "每天23点到次日7点铁道部都在维护系统";
                setLabelLocation();
            }
        }

        private void setLabelText(object text)
        {
            if (label1.InvokeRequired)
            {
                label1.Invoke(new SetContralText(setLabelText), new object[] { text });
            }
            else
            {
                label1.Text = text.ToString();
                setLabelLocation();
            }
        }

        private void setButtonText(object text)
        {
            if (this.button1.InvokeRequired)
            {
                button1.Invoke(new SetContralText(setButtonText), new object[] { text });
            }
            else
            {
                button1.Text = text.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            setLoginImg();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (isAllowLogin && e.KeyChar == (char)13)
            {
                button1_Click(null, null);
            }
        }

        private void setLabelLocation()
        {
            Point p = this.label1.Location;
            p.X = (this.Width - this.label1.Width) / 2;
            this.label1.Location = p;
        }

        /// <summary>
        /// 登录随机验证码
        /// </summary>
        private string loginCode = string.Empty;
        /// <summary>
        /// 错误信息
        /// </summary>
        private string errorMsg = string.Empty;

        private Thread thread;

        bool isAllowLogin = true;

        string userFilePath = string.Format(@"{0}\{1}", Application.StartupPath, "uticketer.td");

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null && thread.ThreadState != ThreadState.Stopped)
                thread.Abort();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ticketer.Forms.About about = new Forms.About();
            about.ShowDialog();
        }
    }
}
