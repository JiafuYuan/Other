using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Laura.Calculator
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lkBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "http://www.shuxiaolong.com/";
            OpenBrowser(url);
        }

        private void lkCnBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "http://www.cnblogs.com/shuxiaolong/";
            OpenBrowser(url);
        }

        private void OpenBrowser(string url)
        {
            
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
                string s = key == null ? string.Empty : key.GetValue("").ToString();//"D:\Program Files (x86)\Mozilla Firefox\firefox.exe" -osint -url "%1"
                string app = s.Split(new string[] { " -" }, StringSplitOptions.RemoveEmptyEntries)[0];//s就是你的默认浏览器，不过后面带了参数，把它截
                Process.Start(app/*s.Substring(0, s.Length - 5)*/, url);
            }
            catch (Exception)
            {
                try { Process.Start("IExplore.exe", url); }
                catch (Exception) { }
            }
        }

    }
}
