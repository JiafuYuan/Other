using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bestway.Windows.Tools.ADODB;
using System.IO;
using System.Threading;
using System.Xml;
using System.Diagnostics;

namespace Bestway.Windows.Program.MMS
{
    /// <summary>
    /// 灰分仪操作类
    /// </summary>
    public class AshContent
    {
        List<AshContentModule> AshList;
        private DB_MMS db = null;
        private static Thread tdAsh = null;
        private bool bExit;
        public AshContent()
        {
            db = new DB_MMS();
            AshList = new List<AshContentModule>();
            bExit = false;
            tdAsh = new Thread(new ThreadStart(threadProc));
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public bool Initialize()
        {
            if(!db.Initialize(GlobalObject.Params.Config.DbLoginInfo))return false;
            db.getAsh(ref AshList);

            tdAsh.Start();
            Thread.Sleep(1);
            return true;
        }

        /// <summary>
        /// 释放灰分仪占用的资源
        /// </summary>
        public void Dispse()
        {
            
            bExit = true;
            while ((int)(tdAsh.ThreadState & System.Threading.ThreadState.Stopped) != 0 &&
                (int)(tdAsh.ThreadState & System.Threading.ThreadState.Unstarted) != 0)
            {
                System.Threading.Thread.Sleep(100);
            }
            db.Dispose();
        }

        private void threadProc()
        {
            while (!bExit)
            {
                GlobalObject.Methods.WriteLog("开始执行循环："+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), false);
                StreamReader sr=null;
                try
                {
                    string straddress = "\\\\" + GlobalObject.Params.Config.AshContentServerIP + "\\hrecord";

                    //if (ConnectServer(@"\\172.21.2.229\新建文件夹", GlobalObject.Params.Config.AshContentServerName, GlobalObject.Params.Config.AshContentPwd))
                    if (ConnectServer(straddress, GlobalObject.Params.Config.AshContentServerName, GlobalObject.Params.Config.AshContentPwd))
                    {

                        //FileInfo fInfo = new FileInfo(@"\\172.21.2.229\新建文件夹\rtdata.TXT");
                        FileInfo fInfo = new FileInfo(straddress+"\\rtdata.TXT");
                        DateTime date = DateTime.Parse(fInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        if (date > GlobalObject.Params.Config.AshContentLastWriteTime)
                        {
                             sr= new StreamReader(fInfo.FullName, Encoding.GetEncoding("gb2312"));
                            string strLine = string.Empty;
                            while ((strLine = sr.ReadLine()) != null)
                            {
                                //地址1,5303,0,0,0,.0040824
                                string[] strSplit = strLine.Split(',');
                                foreach (AshContentModule acm in AshList)
                                {
                                    if (acm.InstallationPosition == strSplit[1])
                                    {
                                        acm.bUpdated = true;
                                        acm.Dt_datetime = date;
                                        acm.AshMinute = float.Parse(strSplit[2]);
                                        acm.AshTenMinute = float.Parse(strSplit[3]);
                                        acm.AshHour = float.Parse(strSplit[4]);
                                        acm.AshNightClass = float.Parse(strSplit[6]);
                                        acm.AshMorningClass = float.Parse(strSplit[7]);
                                        acm.AshMiddayClass = float.Parse(strSplit[8]);
                                        acm.AshDayValue = float.Parse(strSplit[9]);
                                        
                                        break;
                                    }
                                }
                            }
                            sr.Dispose();
                            //更新数据
                            db.ExecDataAshHour(ref AshList, date);
                            db.ExecDataAshClass(ref AshList, date);
                            db.ExecDataAshDay(ref AshList, date);
                            if (db.ExecDataAshContent(ref AshList))
                            {

                                GlobalObject.Params.Config.AshContentLastWriteTime = date;
                                GlobalObject.Params.Config.SetAshContentLastWriteTime();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (sr!=null) sr.Dispose();
                    GlobalObject.Methods.WriteLog(ex.Message, true);
                    continue;
                }

                Thread.Sleep(GlobalObject.Params.Config.AshContentSaveDataBaseRate * 1000);
            }
        }

        /// <summary>
        /// 连接远程服务器
        /// </summary>
        /// <param name="path">访问网络路径</param>
        /// <param name="userName">远程服务器用户名</param>
        /// <param name="passWord">远程服务器密码</param>
        /// <returns></returns>
        private static bool ConnectServer(string path, string userName, string passWord)
        {
            bool Flag = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                string dosLine = @"net use " + path + " /User:" + userName + " " + passWord + " /PERSISTENT:YES";
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch
            {
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }

    }

    /// <summary>
    /// 灰分仪基础信息
    /// </summary>
    public class AshContentModule
    {
        /// <summary>编号 </summary>
        public int ID { get; set; }
        /// <summary>安装位置 </summary>
        public string InstallationPosition { get; set; }
        /// <summary>删除标志：0表示正常；1表示已删除</summary>
        public int i_Flag { get; set; }

        /// <summary>数据生成时间</summary>
        public DateTime Dt_datetime { get; set; }
        /// <summary>分钟灰分</summary>
        public float AshMinute { get; set; }
        /// <summary>十分钟灰分</summary>
        public float AshTenMinute { get; set; }
        /// <summary>小时灰分</summary>
        public float AshHour { get; set; }
        /// <summary>晚班灰分</summary>
        public float AshNightClass { get; set; }
        /// <summary>早班灰分</summary>
        public float AshMorningClass { get; set; }
        /// <summary>中班灰分</summary>
        public float AshMiddayClass { get; set; }
        /// <summary>当日平均灰分</summary>
        public float AshDayValue { get; set; }

        /// <summary>数据是否已更新</summary>
        public bool bUpdated { get; set; }
    }
}
