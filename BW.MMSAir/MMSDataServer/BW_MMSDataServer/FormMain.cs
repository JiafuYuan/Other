using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Tools.OPC;
using System.Threading;
namespace Bestway.Windows.Program.MMS
{
    public partial class FormMain : Form
    {
        public delegate void SetListBoxCallback(string str,int select);
        public SetListBoxCallback setListBoxCallback;

        //Worker work = new Worker();
        Worker work = null;
        Thread ReInitial = null;
        public FormMain()
        {
            InitializeComponent();
            listBox_ShowMessage.HorizontalScrollbar = true;
            setListBoxCallback = new SetListBoxCallback(SetListBox);
        }
        
        private void SetListBox(string str,int select)
        {
            if (select == 1)
            {
                listBox_ShowMessage.Items.Add(str);
                listBox_ShowMessage.SelectedIndex = listBox_ShowMessage.Items.Count - 1;
                listBox_ShowMessage.ClearSelected();
            }
            if (select == 2)
            {
                InitialStatus.Text = str;
            }
            if (select == 3)
            {
                OPCServerStatus.Text = str;
            }
            if (select == 4)
            {
                OPCPowerStatus.Text = str;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            //toolStripStatusLabel2.Text = "正在初始化";
            //statusStrip1.Invoke(setListBoxCallback,"正在初始化",2);
            work = new Worker();
            //ReInitial.Start();
            btnStart.Enabled = false;
            
            listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "正在初始化程序.....",1);
            
            /*
            if(GlobalObject.Params.DBInitialFlag)
                listBox_ShowMessage.Invoke(setListBoxCallback, "初始化数据库失败");
             */

            if (!Initial())
            {
                try
                {
                    work.Dispose();
                }
                catch
                {
                }
            }
        }

        bool Initial()
        {
            if (work.Initialize())
            {
                listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "初始化成功，程序正在运行.....",1);
                ProgramStatus.Invoke(setListBoxCallback, "初始化成功;", 2);
                ProgramStatus.Invoke(setListBoxCallback, "连接成功;", 3);
                ProgramStatus.Invoke(setListBoxCallback, "连接成功", 4);
                timer_ClickBtnStart.Enabled = true;
                btnStart.Enabled = false;
                
                return true;
            }
            else
            {
                //MessageBox.Show("程序启动错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.DBInitialFlag)
                    {
                        listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "数据库连接失败",1);
                    }
                    if (GlobalObject.Params.ReadSensorData)
                    {
                        listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "读取数据库传感器信息失败",1);
                    }
                    if (GlobalObject.Params.SensorInitialFlag)
                    {
                        listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "初始化传感器失败",1);
                    }
                    if (GlobalObject.Params.OPCInitialFlag)
                    {
                        listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "连接OPC服务器失败",1);
                    }
                    if (GlobalObject.Params.OPCPowerInitialFlag)
                    {
                        listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "连接OPC电力服务器失败",1);
                    }
                    if (GlobalObject.Params.ACInitialFlag)
                    {
                        listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "初始化灰分仪失败",1);
                    }
                    GlobalObject.Params.ProgramFlag = true;
                    ProgramStatus.Invoke(setListBoxCallback, "初始化失败;", 2);
                    ProgramStatus.Invoke(setListBoxCallback, "连接失败;", 3);
                    ProgramStatus.Invoke(setListBoxCallback, "连接失败", 4);
                    listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "初始化程序失败，程序将不能正常运行！",1);
                }
                return false;
            }
        }

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            Configure con = new Configure();
            con.Save();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                work.Dispose();
            }
            catch { }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ProgramStatus.Invoke(setListBoxCallback, "正在初始化;", 2);
            ProgramStatus.Invoke(setListBoxCallback, "未知状态;", 3);
            ProgramStatus.Invoke(setListBoxCallback, "未知状态", 4);
            //btnStart.PerformClick();
            ReInitial = new Thread(new ThreadStart(ReInitial_Proc));
            //ReInitial.Start();
            timerWriteRunLog.Tick += new EventHandler(timerWriteRunLog_Tick);
            timerWriteRunLog.Enabled = true;   
            GlobalObject.Methods.WriteLog("采集程序开始运行：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), false);
            timer_ClickBtnStart.Tick += new EventHandler(timer_ClickBtnStart_Tick);
            timer_ClickBtnStart.Enabled = true;
        }

        void ReInitial_Proc()
        {
            bool InitialFlag = false;
            Thread.Sleep(10*1000);
            while (true)
            {
                Thread.Sleep(10 * 1000);
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.ProgramFlag)
                    {
                        GlobalObject.Params.OPC_Unline = false;
                        GlobalObject.Params.OPCPower_Unline = false;

                        GlobalObject.Params.ProgramFlag = false;
                        //work.Dispose();
                        GlobalObject.Params.DBInitialFlag = false;
                        GlobalObject.Params.ReadSensorData = false;
                        GlobalObject.Params.SensorInitialFlag = false;
                        GlobalObject.Params.OPCInitialFlag = false;
                        GlobalObject.Params.OPCPowerInitialFlag = false;
                        GlobalObject.Params.ACInitialFlag = false;
                        InitialFlag = true;
                    }
                }
                if (InitialFlag)
                {
                    InitialFlag = false;
                    work = new Worker();
                    listBox_ShowMessage.Invoke(setListBoxCallback, "\r\n\r\n",1);
                    listBox_ShowMessage.Invoke(setListBoxCallback, "【" + DateTime.Now + "】" + "重新初始化程序！正在初始化......",1);
                    if (!Initial())
                    {
                        try
                        {
                            work.Dispose();
                        }
                        catch
                        {
                        }
                    }
                }
                
            }
        }

        void timer_ClickBtnStart_Tick(object sender, EventArgs e)
        {
            timer_ClickBtnStart.Enabled = false;
            btnStart.PerformClick();
        }
        void timerWriteRunLog_Tick(object sender, EventArgs e)
        {
            GlobalObject.Methods.WriteLog("采集程序正在运行："+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), false);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = true;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(null, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出计量系统数据采集程序吗？\r\n退出后计量系统中的数据将不会更新。\r\n", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                GlobalObject.Methods.WriteLog("程序被手动关闭！" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), true);
                Environment.Exit(0);
            }
        }

    }
}
