using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO;

namespace Ticketer
{
    public partial class TestForm : Form
    {
        public static string str = null;

        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpHelper helper = new HttpHelper(LinkAddress.LOGINIMG_ADDRESS);
            helper.Request.Method = "GET";
            Image img = helper.GetResponseIMG();
            img.Save(@"d:\img.png");
            this.pictureBox1.Image = img;
            GetVeryfyCode(@"d:\img.png");
        }

        [DllImport("OCRDLL\\AspriseOCR.dll", EntryPoint = "OCR", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCR(string file, int type);
        private void GetVeryfyCode(string _imgPath)
        {
            if (File.Exists(_imgPath))//ok now?
            {
                try
                {
                    //66142304
                    this.pictureBox1.Image = System.Drawing.Bitmap.FromFile(_imgPath);
                    //string s = OCR(_imgPath, -1);
                    IntPtr intp = OCR(_imgPath, -1);   //将返回string,并以"/r/n"结尾!!
                    this.textBox1.Text = Marshal.PtrToStringAnsi(intp).Replace("", "");
                    //IntPtr.
                }
                catch (Exception e)
                {
                    this.textBox1.Text += e.Message;
                }
            }
        }
    }

    public static class OCRHelp
    {
        [DllImport("OCRDLL\\AspriseOCR.dll", EntryPoint = "OCR")]
        public static extern IntPtr OCR(string file, int type);

        [DllImport("OCRDLL\\AspriseOCR.dll", EntryPoint = "OCRpart")]
        static extern IntPtr OCRpart(string file, int type, int startX, int startY, int width, int height);

        [DllImport("OCRDLL\\AspriseOCR.dll", EntryPoint = "OCRBarCodes")]
        static extern IntPtr OCRBarCodes(string file, int type);

        [DllImport("OCRDLL\\AspriseOCR.dll", EntryPoint = "OCRpartBarCodes")]
        static extern IntPtr OCRpartBarCodes(string file, int type, int startX, int startY, int width, int height);
    }
}
