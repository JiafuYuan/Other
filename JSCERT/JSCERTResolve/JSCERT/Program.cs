using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using Bestway.Windows.Tools.ADODB;
using FSLib.App.SimpleUpdater;
using VehicleTransportClient.Com;

namespace JSCERT
{
    public static class Program
    {
        static System.Windows.Forms.Timer _dbtime = new Timer();
        public static Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form fr = new Form();
            fr.FormBorderStyle = FormBorderStyle.None;
            fr.Size = new System.Drawing.Size(1, 1);
            fr.Show();
            fr.Close();

            //new Form1().ShowDialog();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionEventHandler);

            //单例模式
            bool bCreatedNew;
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, Application.ProductName, out bCreatedNew);
            if (!bCreatedNew)
            {
                procDlg.Dispose();
                MessageBox.Show("打开失败，已有一个地图编辑软件正在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            //测试单例模式
            //bool bCreatedNew;
            //System.Threading.Mutex mutex = new System.Threading.Mutex(false, Application.ProductName, out bCreatedNew);
            //if (!bCreatedNew)
            //{
            //    MessageBoxEx.Show("打开失败，已有一个矿用机车运管管理系统正在运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
            //读取配置文件

            //检查软件版本，提示更新
            Updater.CheckUpdateSimple("http://qxw1142500270.my3w.com/update/{0}", "update_c.xml"); 
 
            procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "  正在连接数据库，请稍等...");

            Pub.ConfigModel = Config.GetModel();
            if (OpenDataBase() == false)
            {
                procDlg.Dispose();
                MessageBox.Show("连接数据库失败,请联系管理员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Pub.IsDBOnline = true;
            DB.OleDbHelper.StateChanged += new StateChangeEventHandler(OleDbHelper_StateChanged);
            procDlg.Hide();
            //FrmLogin frmlogin = new FrmLogin();
            //DialogResult drlogin = frmlogin.ShowDialog();
            //if (drlogin == DialogResult.Cancel)
            //{
            //    procDlg.Dispose();
            //    return;
            //}
            try
            {
                procDlg.Dispose();
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                WriteLog.AppendErrorLog("Main:" + ex.Message + ex.StackTrace);
            }
         
        }

        static void OleDbHelper_StateChanged(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Open)
            {
                WriteLog.AppendErrorLog("数据库打开");
                Pub.IsDBOnline = true;
                _dbtime.Enabled = false;
            }
            else
            {
                WriteLog.AppendErrorLog("数据库关闭");
                Pub.IsDBOnline = false;
                _dbtime.Enabled = true;
                 
            }
        }

        /// <summary>连接服务器/数据库</summary>
        public static bool OpenDataBase()
        {
            bool b = DB.OpenDataBase(Pub.ConfigModel.DBServer,
                Pub.ConfigModel.DBName,
                Pub.ConfigModel.DBUserName,
                Pub.ConfigModel.DBPassword,
                new ExecuteErrorEventHandler(OleDbHelper_ExecuteError));
            if (b == true)
            {
                DataSet ds = DB.OleDbHelper.GetDataSet("select * from dbo.sysobjects where id = object_id(N'[dbo].[m_Title]') and OBJECTPROPERTY(id, N'IsUserTable') = 1");
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
            //AppendLog(e.Sql + "\r\n" + e.Exception.Message + e.Exception.StackTrace);
            //Common.MessageBoxEx.MessageBoxEx.Show(e.Sql + "\r\n" + e.Exception.Message + e.Exception.TargetSite,"警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            string strText, strCaption;
            Exception ex = e.ExceptionObject as Exception;
            strCaption = ex.Source;
            strText = string.Format("UnhandledExceptionEventHandler：{0}\n\r方法名称:{1}", ex.ToString(), ex.TargetSite.Name);
            WriteLog.AppendErrorLog(strText);
        }
    }
}
