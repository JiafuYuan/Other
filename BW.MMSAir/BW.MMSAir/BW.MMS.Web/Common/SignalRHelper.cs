using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using System.Configuration;
using Bestway.Windows.Program.SocketDataModel.MMS;
using BW.MMS.Log;
using System.Threading;
using Bestway.Windows.Tools.Communication.Net;
using Bestway.Windows.Tools.Serialization;
using Bestway.Windows.Tools.Communication;

namespace BW.MMS.Web.Common
{
    [HubName("warn")]
    public class SignalRHelper : Hub
    {
        #region 属性
        /// <summary>
        /// Socket服务端对象
        /// </summary>
        private static SocketClient client;

        /// <summary>
        /// 本机IP地址
        /// </summary>
        private readonly string LocalIP = ConfigurationManager.AppSettings["LocalIP"];

        /// <summary>
        /// 服务端IP地址
        /// </summary>
        private readonly string ServerIP = ConfigurationManager.AppSettings["SocketIP"];

        /// <summary>
        /// 服务端口
        /// </summary>
        private readonly string ServerPort = ConfigurationManager.AppSettings["SocketPort"];

        /// <summary>
        /// 重连时间(毫秒)
        /// </summary>
        private int ReconnectTime = string.IsNullOrEmpty(ConfigurationManager.AppSettings["ReconnectTime"]) ? 60000 : int.Parse(ConfigurationManager.AppSettings["ReconnectTime"]);

        /// <summary>
        /// 排他锁对象，防止并发
        /// </summary>
        private readonly object obj = new object();

        public FrameProxy frame;

        public System.Timers.Timer timer;

        #endregion

        #region 客户端调用方法
        /// <summary>
        /// 接受客户端消息
        /// </summary>
        /// <param name="message">消息内容</param>
        public void send(string message)
        {
            Clients.All.Push(message);
        }

        /// <summary>
        /// 接受客户端请求传感器实时数据
        /// </summary>
        public void getSensorRealTime(string sensorID)
        {
          
            Groups.Add(Context.ConnectionId, sensorID);
        }
        #endregion

        #region Signal事件
        /// <summary>
        /// 客户端连接事件
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            if (string.IsNullOrEmpty(LocalIP) || string.IsNullOrEmpty(ServerIP) || string.IsNullOrEmpty(ServerPort))
            {
                Clients.All.Prompt("数据服务IP或端口没有配置！请联系管理员。");
            }
            else
            {
                if (client == null || client.IsConnected == false)
                {
                    ConnectServer();
                }
            }
            return base.OnConnected();
        }

        /// <summary>
        /// 客户端断开连接事件
        /// </summary>
        /// <returns></returns>
        public override Task OnDisconnected()
        {
            return base.OnDisconnected();
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 连接 Socket 服务
        /// </summary>
        private void ConnectServer()
        {
            if (client == null)
            {
                lock (obj)
                {
                    if (client == null)
                    {
                        InitSocket();
                    }
                }
            }
            client.Connect(ServerIP, int.Parse(ServerPort), 1000);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        /// <summary>
        /// 初始化 Socket 对象
        /// </summary>
        private void InitSocket()
        {
            client = new SocketClient(LocalIP, 0);
            client.SocketReceivedData += new SocketReceivedDataEventHandler(ReceivedData);
            client.SocketConnected += new SocketEventHandler(client_SocketConnected);
            client.SocketError += new SocketErrorEventHandler(client_SocketError);
            frame = new FrameProxy();
            frame.OnFrameReceived += new FrameEventHandler(frame_OnFrameReceived);
            frame.Initialize(null, 1000);

            timer = new System.Timers.Timer(ReconnectTime);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        }

        void client_SocketError(object sender, SocketErrorEventArgs e)
        {
            Clients.All.ConnectFail("数据服务连接失败！");
            Logger.Error("Socket错误：" + e.Error.Message);
        }

        void client_SocketConnected(object sender, SocketEventArgs e)
        {
            Logger.Info("Socket连接成功！");
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                try
                {
                    client.Send(new byte[2]);
                }
                catch (Exception ex)
                {
                    Logger.Error("Socket发送错误：" + ex.Message, ex);
                }
            }
            else
            {
                Logger.Warn("重新连接Socket服务");
                //InitSocket();
                client.Connect(ServerIP, int.Parse(ServerPort), 1000);
            }
        }

        #endregion

        #region Socket事件

        void ReceivedData(object sender, SocketReceivedDataEventArgs e)
        {
            try
            {
                frame.AddReceiveData(e.ReceivedData);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        void frame_OnFrameReceived(object sender, FrameEventArgs e)
        {
            try
            {
                switch (e.Frame.Command)
                {
                    case 0:
                        SensorModel mode = (SensorModel)SerializerInDotNet.Bytes2Object(e.Frame.Data);
                        Clients.Group(mode.SensorID.ToString()).PushSensorData(mode.RealData, mode.DataTime);
                        break;
                    case 1:
                        Clients.All.Prompt("OPC服务器不线！");
                        break;
                    case 2:
                        Clients.All.Prompt("OPC电力服务器不在线！");
                        break;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        #endregion
    }
}