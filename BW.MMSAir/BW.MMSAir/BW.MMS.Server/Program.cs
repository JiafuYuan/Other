using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace BW.MMS.Server
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CheckProcess();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Main());
        }

        private static void CheckProcess()
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.ProcessName == Process.GetCurrentProcess().ProcessName && p.Id != Process.GetCurrentProcess().Id)
                {
                    p.Kill();
                    break;
                }
            }
        }
    }
}
