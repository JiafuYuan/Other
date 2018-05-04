using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Common
{
    public class Logger
    {
        private string title;
        public Logger(string info)
        {
            if (string.IsNullOrEmpty(info) == false)
            {
                title = info;
            }
            if (Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "Log") == false)
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "Log");
            }
        }
        public void Info(string strcontent)
        {
            try
            {
                string filename = System.AppDomain.CurrentDomain.BaseDirectory + "Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + "_log.txt";
                if (File.Exists(filename))
                {
                    FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    string content = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] [" + title + "] " + strcontent;
                    sw.WriteLine(content);  //这里是写入的内容                
                    sw.Close();
                    fs.Close();
                }
                else
                {
                    FileStream fs = new FileStream(filename, FileMode.CreateNew, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                    string content = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] [" + title + "] " + strcontent;
                    sw.WriteLine(content);  //这里是写入的内容                
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception exc)
            {
                //string aa = exc.ToString();
            }
        }
    }
}
