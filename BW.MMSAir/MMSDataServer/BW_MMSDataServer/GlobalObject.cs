using System;
using System.Collections.Generic;
using System.Text;

namespace Bestway.Windows.Program.MMS
{
    static class GlobalObject
    {
        /// <summary>全局参数</summary>
        public static class Params
        {
            #region 全局常量
            //EXE执行文件路径
            public static readonly string APP_FILE_PATH_EXE =System.Windows.Forms.Application.StartupPath;

            /// <summary>程序名称</summary>
            public static readonly string APP_PRODUCT_NAME = System.Windows.Forms.Application.ProductName;

            /// <summary>程序标题</summary>
            
            
            /// <summary>程序版本号</summary>
            public static readonly string APP_PRODUCT_VERSION = System.Windows.Forms.Application.ProductVersion;             //版本号

            #endregion


            #region 全局变量

            
            //public static SCH_RegistryEx.clsRegisterSoft Register = null;
            public static Configure Config =new Configure();

            public static bool DBInitialFlag = false;
            public static bool ReadSensorData = false;
            public static bool SensorInitialFlag = false;
            public static bool OPCInitialFlag = false;
            public static bool OPCPowerInitialFlag = false;
            public static bool ACInitialFlag = false;

            //用于推送OPC服务器不在线
            public static bool OPC_Unline = false;
            public static bool OPCPower_Unline = false;

            public static bool ProgramFlag = false;
            public static object lockState = new object();


            #endregion
        }

        /// <summary>全局方法</summary>
        public static class Methods
        {
            private static object lockByte2String = new object();
            public static string Byte2String(byte[] buffer)
            {
                lock (lockByte2String)
                {
                    string s = "";
                    if (buffer == null) return s;

                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        s = string.Format("{0:X2} ", buffer[i]);
                        //s.ToUpper();
                        sb.Append(s);
                    }
                    return sb.ToString();
                }
            }

            private static object lockWriteLog = new object();
            public static bool WriteLog(string context, bool iserror)
            {
                lock (lockWriteLog)
                {
                    if (iserror == false && GlobalObject.Params.Config.SaveLog == 0) return true;

                    bool result = false;
                    DateTime t = DateTime.Now;
                    string strPath = string.Format("{0}\\log\\", Params.APP_FILE_PATH_EXE);
                    string m_FileFullName = string.Format("{0}{1}_{2}.txt",
                                                        strPath,
                                                        iserror ? "Error" : "Data",
                                                        t.ToString("yyyy-MM-dd HH时"));

                    context = "\t" + context;
                    context = t.ToString("【yyyy-MM-dd HH:mm:ss】") + context;
                    //context+="\r\n";

                    if (!System.IO.Directory.Exists(strPath)) System.IO.Directory.CreateDirectory(strPath);
                    System.IO.FileStream fs = new System.IO.FileStream(m_FileFullName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                    if (fs != null)
                    {
                        fs.Close();
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(m_FileFullName, true, Encoding.Default);
                        sw.WriteLine(context);
                        sw.Flush();
                        sw.Close();
                    }
                    return result;
                }
            }
            public static bool WriteLog(string context)
            {
                return WriteLog(context, true);
            }
        }
    }
}
