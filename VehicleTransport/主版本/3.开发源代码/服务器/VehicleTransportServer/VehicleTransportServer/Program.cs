using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bestway.Windows.Tools.ADODB;

using System.Data;
using System.IO;
using VehicleTransportServer.BLL;
using Common.Model.FlowPath.InFlowPath;
using Common.Model.NormalCommand.InCommandModel;

namespace VehicleTransportServer
{
    static class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
           
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ////单例模式
                //bool bCreatedNew;
                //System.Threading.Mutex mutex = new System.Threading.Mutex(false, Application.ProductName, out bCreatedNew);
                //if (!bCreatedNew)
                //{
                //    MessageBox.Show("打开失败，已有一个KJ915矿用机车运管管理系统服务正在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionEventHandler);
                Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();

                

                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "  正在连接数据库，请稍等...");
                bool b = ConnectDB();
                //int s = 0;
                //int p = 2;
                //List<DB_VehicleTransportManage.Model.m_Plan> lstPlan = new DB_VehicleTransportManage.BLL.m_Plan().GetModelListByPage(
                //   "",s+1,s+p);

                //s = 2;
                //p = 2;
                //lstPlan = new DB_VehicleTransportManage.BLL.m_Plan().GetModelListByPage(
                //   "", s+1, s + p );
                
                if (b==false)
                {
                        procDlg.Hide();
                        MessageBox.Show("连接数据库失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        procDlg.Dispose();
                        return;
                }

                procDlg.Dispose();
                if (b == true && args.Length > 0 && args[0] == "Map")//后台将地图文件写入数据库
                {
                    System.Threading.Thread.Sleep(1000);
                    System.Threading.Thread.Sleep(1000);
                    WriteLog.AppendErrorLog("Input Map " + MapFileSaveToDB());
                    return;
                }
                else
                {
                    List<DB_VehicleTransportManage.Model.m_GisMapFiles> lst = new DB_VehicleTransportManage.BLL.m_GisMapFiles().GetModelList("");
                    if (lst!=null && lst.Count==0)
                    {
                        WriteLog.AppendErrorLog("Input Map " + MapFileSaveToDB());
                    }
                    SetSystemTime.SetTime();
                    if (Pub.ConfigModel.CanRunSecondServer==true || new DB_VehicleTransportManage.BLL.m_SystemConfig().IsCanRunServer())
                    {
                        Config.GetFlowPath();
                        Application.Run(new FormMain());
                    }
                    else
                    {
                        MessageBox.Show("打开失败，已有一个KJ915矿用机车运管管理系统服务正在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog.AppendErrorLog("Main:" + ex.Message + ex.StackTrace);
            }
       
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string strText, strCaption;
            strCaption = e.Exception.Source;
            strText = string.Format("Application_ThreadException：{0}\n\r方法名称:{1}", e.Exception.ToString(), e.Exception.TargetSite.Name);
            WriteLog.AppendErrorLog(strText);
        }

        static void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)
        {
            string strText, strCaption; ;
            Exception ex = e.ExceptionObject as Exception;
            strCaption = ex.Source;
            strText = string.Format("UnhandledExceptionEventHandler：{0}\n\r方法名称:{1}", ex.ToString(), ex.TargetSite.Name);

            WriteLog.AppendErrorLog(strText);
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        private static bool ConnectDB()
        {
            Pub.ConfigModel = Config.GetModel();
            #region 从注册表取数据库连接信息，取完之后删除
            //注册表信息由打包程序生成

            string dbserver = Pub.GetRegValue("DB_Server");
            string dbuser = Pub.GetRegValue("DB_User");
            string dbpassword = Pub.GetRegValue("DB_Password");
            if (dbpassword != "" && dbuser != "" && dbpassword != "")
            {
                Pub.ConfigModel.DBServer = dbserver;
                Pub.ConfigModel.DBUserName = dbuser;
                Pub.ConfigModel.DBPassword = dbpassword;
                Config.WriteModel(Pub.ConfigModel);
            }
            #endregion

            return Program.OpenDataBase();
        }

        /// <summary>连接服务器/数据库</summary>
        public static bool OpenDataBase()
        {
            bool b = DB_VehicleTransportManage.DB.OpenDataBase(Pub.ConfigModel.DBServer,
              Pub.ConfigModel.DBName,
              Pub.ConfigModel.DBUserName,
              Pub.ConfigModel.DBPassword,
              new ExecuteErrorEventHandler(OleDbHelper_ExecuteError));
            if (b == true)
            {
                DataSet ds = DB_VehicleTransportManage.DB.OleDbHelper.GetDataSet("select * from dbo.sysobjects where id = object_id(N'[dbo].[m_User]') and OBJECTPROPERTY(id, N'IsUserTable') = 1");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static void OleDbHelper_ExecuteError(object sender, ExecuteErrorEventArgs e)
        {
            WriteLog.AppendErrorLog(e.Sql + "\r\n" + e.Exception.Message + e.Exception.StackTrace);
          //  Pub._isDBOnline = false;
        }

        /// <summary>保存地图文件到数据库 </summary>
        public static bool MapFileSaveToDB()
        {
            object obj = new object();
            try
            {
                try
                {
                    lock (obj)
                    {
                        
                        //Global.Params.OleDbHelper.ExecuteSql("delete from m_GisMapFiles");
                        (new DB_VehicleTransportManage.BLL.m_GisMapFiles()).Delete();
                        string filename;
                        string[] strFiles = Directory.GetFiles(Application.StartupPath+"\\map");
                        foreach (string strFile in strFiles)
                        {
                            string mp = strFile.ToString();//包含路径
                            FileStream fs = new FileStream(mp, FileMode.Open, FileAccess.Read);
                            Byte[] byte2 = new byte[fs.Length];
                            fs.Read(byte2, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                            filename = Path.GetFileName(strFile.ToString());//去掉路径只保留文件名
                            DB_VehicleTransportManage.Model.m_GisMapFiles gismapfiles = new DB_VehicleTransportManage.Model.m_GisMapFiles();
                            gismapfiles.File_Name = filename;
                            gismapfiles.File_Data = byte2;
                            (new DB_VehicleTransportManage.BLL.m_GisMapFiles()).Add(gismapfiles);
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
