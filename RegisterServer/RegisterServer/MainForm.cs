using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace RegisterServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public int[] intCode = new int[127];//存储密钥
        public int[] intNumber = new int[25];//存机器码的Ascii值
        public char[] Charcode = new char[25];//存储机器码字
   
        private void MainForm_Load(object sender, EventArgs e)
        {
            //判断软件是否注册
            //SoftReg sr = new SoftReg();
            //RegistryKey retkey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey("pigway").CreateSubKey("remark");
            //string strRNum = Registry.GetValue("HKEY_CURRENT_USER\\SoftWare\\pigway\\remark", "key", 0).ToString(); ;
            //if (strRNum!="0")
            //{
            //    this.labelReg.Text = "此软件已注册！";
            //    //this.btnReg.Enabled = false;
            //    return;
            //}
            //this.labelReg.Text = "此软件尚未注册！";
            ////this.btnReg.Enabled = true;
            //MessageBox.Show("您现在使用的是试用版，可以免费试用30次！","信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //Int32 tLong;
            //try
            //{
            //     tLong= (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Angel", "UseTimes", 0);
            //    MessageBox.Show("您已经使用了" + tLong + "次！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch 
            //{
            //    MessageBox.Show("欢迎使用本软件！","信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Angel","UseTimes",0,RegistryValueKind.DWord);
            //}
            //tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Angel", "UseTimes", 0);
            //if (tLong < 30)
            //{
            //    int tTimes = tLong + 1;
            //    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Angel", "UseTimes", tTimes);
            //}
            //else 
            //{
                //DialogResult result = MessageBox.Show("试用次数已到！您是否需要注册？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //if (result == DialogResult.Yes)
                //{
                //    RegForm.state = false;
                //    btnReg_Click(sender, e);
                //}
                //else 
                //{
                //    Application.Exit();
                //}
           // }
        }

        public void SaveRedistMsg(string sPerson,string sAddress,string sPassword,string sJiqi,string sZhucema)
        {
            StreamWriter sw=File.AppendText("注册码.txt");
            sw.WriteLine("=======================================");
            sw.WriteLine("注册时间："+DateTime.Now.ToString());
            sw.WriteLine("申请人:" + sPerson);
            sw.WriteLine("地址:" + sAddress);
            sw.WriteLine("密码:" + sPassword);
            sw.WriteLine("机器码:" + sJiqi);
            sw.WriteLine("注册码:" + sZhucema);
            sw.WriteLine("=======================================");
            sw.Dispose();

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtRegist.Text != "")
            {
                Clipboard.SetDataObject(txtRegist.Text);
            }
            SaveRedistMsg(txtPersonName.Text, txt_Address.Text, txt_Password.Text, txtMachine.Text, txtRegist.Text);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SoftReg sr = new SoftReg();
            if (txtMachine.Text.Length != 0)
            {
                txtRegist.Text = sr.getRNum(txtMachine.Text);
            }
            else
            {
                MessageBox.Show("请输入机器码！");
            }
        }
    }
}