using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleTransportClient.Com
{
    class WriteLog
    {
        public static readonly string APP_EXE_PATH = System.Windows.Forms.Application.StartupPath;
        static object locker = new object();
        public static void AppendErrorLog(string Errormessage)
        {
            try
            {
                if (!System.IO.Directory.Exists(APP_EXE_PATH + "\\log"))
                    System.IO.Directory.CreateDirectory(APP_EXE_PATH + "\\log");
                string strPath = APP_EXE_PATH + string.Format("\\log\\error{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
                lock (locker)  //防止多进程调用出错
                {
                    System.IO.File.AppendAllText(strPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + Errormessage + "\r\n");
                }
            }
            catch
            {
            }
        }
    }
}
