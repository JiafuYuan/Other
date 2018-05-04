using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Collections;

namespace VehicleTransportServer.Thread.BackWork
{
    /// <summary>
    /// 监测数据库在线线程
    /// </summary>
    public class CheckDBOnlineThread
    {
        private volatile bool _isStop = false;
        public System.Threading.Thread thread = null;
        private DB_VehicleTransportManage.BLL.m_SystemConfig _systemConfigBLL = new DB_VehicleTransportManage.BLL.m_SystemConfig();

        public CheckDBOnlineThread()
        {
            thread = new System.Threading.Thread(new ThreadStart(TestMain));
            thread.Name = "CheckDBOnlineThread" + this.GetHashCode();
        }

        public void Run()
        {
            thread.Start();
        }

        public void Stop()
        {
            _isStop = true;
            thread.Abort();
        }
       
        public void TestMain()
        {
            while (!_isStop)
            {
                try
                {
                    _systemConfigBLL.GetModel("a");//测试数据库连接用,会触发连接状态改变事件
                    Pub._isDBOnline = true;
                    //if (Pub._ms.ServerIsRun == false)
                    //{
                    //    Pub._ms.Start();
                    //}
                }
                catch (Exception)
                {
                    Pub._isDBOnline = false;
                  //  Pub._ms.Stop();
                }
                
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}

