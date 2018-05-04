using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Collections;

using ScramVoiceAlarmClient;

namespace Com
{
    /// <summary>
    /// 监测数据库在线线程
    /// </summary>
    public class CheckDBOnlineThread
    {
        private volatile bool _isStop = false;
        public Thread thread = null;

        public CheckDBOnlineThread()
        {
            thread = new Thread(new ThreadStart(TestMain));
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
        DB_ScramVoiceAlarm.BLL.m_Car car = new DB_ScramVoiceAlarm.BLL.m_Car();
        
        
        public void TestMain()
        {
            while (!_isStop)
            {
                try
                {
                    car.GetModel(1);//测试数据库连接用,会触发连接状态改变事件
                    Pub.IsDBOnline = true;
                }
                catch (Exception)
                {
                    Pub.IsDBOnline = false;
                }
                
                System.Threading.Thread.Sleep(10 * 1000);
            }
        }
    }
}

