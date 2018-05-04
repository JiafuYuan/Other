using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleTransportServer
{
    public static class WriteLog
    {
        public static readonly string APP_EXE_PATH = System.Windows.Forms.Application.StartupPath;
        public static void AppendErrorLog(string Errormessage)
        {
            if (!System.IO.Directory.Exists(APP_EXE_PATH + "\\log"))
                System.IO.Directory.CreateDirectory(APP_EXE_PATH + "\\log");
            string strPath = APP_EXE_PATH + string.Format("\\log\\error{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
            System.IO.File.AppendAllText(strPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + Errormessage + "\r\n");
        }

        /// <summary>
        /// 按小时生成
        /// </summary>
        /// <param name="Errormessage"></param>
        public static void AppendRunLog(string Errormessage)
        {
            if (!System.IO.Directory.Exists(APP_EXE_PATH + "\\run"))
            {
                System.IO.Directory.CreateDirectory(APP_EXE_PATH + "\\run");
            }
            string strPath = APP_EXE_PATH + string.Format("\\run\\run{0}.log", DateTime.Now.ToString("yyyy-MM-dd_HH"));
            System.IO.File.AppendAllText(strPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + Errormessage + "\r\n\r\n");
        }

        public static void AppendLog(string message)
        {
            if (!System.IO.Directory.Exists(APP_EXE_PATH + "\\log"))
                System.IO.Directory.CreateDirectory(APP_EXE_PATH + "\\log");
            string strPath = APP_EXE_PATH + string.Format("\\log\\log{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
            System.IO.File.AppendAllText(strPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + message + "\r\n\r\n");
        }
    }
}
