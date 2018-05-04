using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Bestway.Windows.Program.MMS
{
    static class Program
    {
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //Loop through the running processes in with the same name 
            foreach (Process process in processes)
            {
                //Ignore the current process 
                if (process.Id != current.Id)
                {
                    //Make sure that the process is running from the exe file. 
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //Return the other process instance. 
                        return process;
                    }
                }
            }
            //No other instance was found, return null. 
            return null;
        }

        public static System.Threading.Mutex Run;

        public static bool Restart = true;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool noRun = false; Run = new System.Threading.Mutex(true, Application.ProductName, out noRun);            //检测是否已经运行            
            if (noRun)            
            {//未运行                
                Run.ReleaseMutex();                
                Application.EnableVisualStyles();                
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
                //MessageBox.Show("12121");
                
            }            
            else            
            {//已经运行                
                MessageBox.Show("该程序已经在运行");                
                //切换到已打开的实例            
            }

            //if (RunningInstance() == null)
            //{
            //    Application.Run(new FormMain());
            //}
            //else
            //{
            //   MessageBox.Show("该程序已经在运行");
            //}
        }
    }
}
