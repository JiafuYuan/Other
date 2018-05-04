using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;



namespace ReStartApp
{
    class Program
    {

        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        
        static void Main(string[] args)
        {
            WriteLog("ReStartApp看门狗软件启动成功，正在监测中.....", true);
            /*
            Process[] ps = Process.GetProcesses(); 
            foreach (Process item in ps) 
            {
                if (item.ProcessName == "BW_MMSDataServer") 
                { 
                    item.Kill();
                    Thread.Sleep(5000);
                    break;
                    
                } 
            }
            foreach (Process item in ps)
            {
                if (item.ProcessName == "GDOPC")
                {
                    item.Kill();
                    Thread.Sleep(5000);
                    break;

                }
            }
            Process proc = Process.Start(AppDomain.CurrentDomain.BaseDirectory + "BW_MMSDataServer.exe");
            */
            Console.Title = "BestWay";
            IntPtr intptr = FindWindow("ConsoleWindowClass", "BestWay");

            if (intptr != IntPtr.Zero)
            {
                ShowWindow(intptr, 0);//隐藏这个窗口
            }
            Thread.Sleep(20*1000);
            while (true)
            {
                bool flag = false;
                Process[] currentprocess = Process.GetProcesses();
                foreach (Process item in currentprocess)
                {
                    if (item.ProcessName == "BW_MMSDataServer")
                    {
                        flag = true;
                    }
                }
                if(!flag)
                {
                    try
                    {
                        Process proc = Process.Start(AppDomain.CurrentDomain.BaseDirectory + "BW_MMSDataServer.exe");
                        WriteLog("ReStartApp启动数据采集软件", true);
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e.Message);
                        /*
                        string file = AppDomain.CurrentDomain.BaseDirectory;
                        string strPath = string.Format(file+"log");
                        string m_FileFullName = string.Format(strPath+"\\ReStartAppError.txt");
                        if (!System.IO.Directory.Exists(strPath)) System.IO.Directory.CreateDirectory(strPath);
                        System.IO.FileStream fs = new System.IO.FileStream(m_FileFullName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                        if (fs != null)
                        {
                            fs.Close();
                            System.IO.StreamWriter sw = new System.IO.StreamWriter(m_FileFullName, true, Encoding.Default);
                            sw.WriteLine("【"+DateTime.Now+"】"+e.Message+ "\r");
                            sw.Flush();
                            sw.Close();
                        }
                        */

                        WriteLog(e.Message, false);
                    }
                }
                Thread.Sleep(10 * 1000);
            }
        }

        private static object lockWriteLog = new object();
        public static void WriteLog(string context, bool isError)
        {
            lock (lockWriteLog)
            {
                string file = AppDomain.CurrentDomain.BaseDirectory;
                string strPath = string.Format(file + "ReStartApplog");
                string m_FileFullName;
                if(isError==false)
                    m_FileFullName = string.Format(strPath + "\\ReStartAppError.txt");
                else
                    m_FileFullName = string.Format(strPath + "\\ReStartAppRun.txt");
                if (!System.IO.Directory.Exists(strPath)) System.IO.Directory.CreateDirectory(strPath);
                System.IO.FileStream fs = new System.IO.FileStream(m_FileFullName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                if (fs != null)
                {
                    fs.Close();
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(m_FileFullName, true, Encoding.Default);
                    sw.WriteLine("【" + DateTime.Now + "】" + context + "\r");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
    }
}
