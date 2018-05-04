using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bestway.Windows.Tools.Communication.Net;
using Common.Model;
using Common.Enum;
using Common;
using System.Windows.Forms;

using System.Net;
using VehicleTransportServer.Thread.Command;
using VehicleTransportServer.BLL;
using System.Net.Sockets;

namespace VehicleTransportServer.Manage
{
    /// <summary>
    /// 通讯管理类
    /// </summary>
    public class SocketManage
    {
        private static readonly SocketManage instance = new SocketManage();
        public static SocketManage Current { get { return instance; } }
        private SocketServer _socketsvr = null;
        private Timer _timer = new Timer();

        //private Dictionary<EndPoint, List<byte>> _dicData = new Dictionary<EndPoint, List<byte>>();
        /// <summary>
        /// 保存连接状态
        /// </summary>
        //private Dictionary<EndPoint, DateTime> _dicConnect = new Dictionary<EndPoint, DateTime>();
        /// <summary>
        /// 保存Socket连接信息
        /// </summary>
        private Dictionary<EndPoint, SocketInfo> _dicSocketInfo = new Dictionary<EndPoint, SocketInfo>();

        private object _socketLock = new object();

        private SocketManage()
        {
          //  Dictionary<int, string> dic = new Dictionary<int, string>();
          //  dic.Add(1, "abc");
          //  dic.Add(2, "def");
          
          //IEnumerable<int> ii=  dic.Where(p => p.Value == "def").Select(p => p.Key);

          
        }

        public bool Init()
        {

            _timer.Interval = 10;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Enabled = true;
            System.Net.IPEndPoint iep = new System.Net.IPEndPoint(IPAddress.Parse(Pub.ConfigModel.ServerIP), Pub.ConfigModel.ServerPort);
            //System.Net.IPEndPoint iep = new System.Net.IPEndPoint(System.Net.IPAddress.Any, Pub.ConfigModel.ServerPort);
            _socketsvr = new SocketServer(iep);
            _socketsvr.SocketReceivedData += new SocketReceivedDataEventHandler(_socketsvr_SocketReceivedData);
            _socketsvr.SocketClientClosed += new SocketEventHandler(_socketsvr_SocketClientClosed);
            _socketsvr.SocketAccepted += new SocketEventHandler(_socketsvr_SocketAccepted);
            _socketsvr.SocketError += new SocketErrorEventHandler(_socketsvr_SocketError);
            return _socketsvr.Start();
        }

        void _socketsvr_SocketError(object sender, SocketErrorEventArgs e)
        {
            // Console.WriteLine(DateTime.Now.ToString() + "错误:" + e.Error.Message);
            Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, DateTime.Now.ToString() + ">>Socket错误:" + e.Error.Message, null, true));
        }

        void _socketsvr_SocketAccepted(object sender, SocketEventArgs e)
        {
            

            //Invoke(new EventHandler(delegate(object o, EventArgs ee)
            //   {
            //       InitLoad();
            //   }));
            //lock (_socketLock)
            //{
            try
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, DateTime.Now.ToString() + ">>客户程序连接成功:" + e.Socket.TcpClient.Client.RemoteEndPoint.ToString(), null, true));
                if (_dicSocketInfo.ContainsKey(e.Socket.TcpClient.Client.RemoteEndPoint) == false)
                {
                    _dicSocketInfo.Add(e.Socket.TcpClient.Client.RemoteEndPoint, new SocketInfo() { LastActiveDateTime = DateTime.Now, ListByte = new List<byte>() });
                }
            }
            catch (Exception ex)
            {
                string strText, strCaption; ;
               // Exception ex = e.ExceptionObject as Exception;
                strCaption = ex.Source;
                strText = string.Format("Socket连接：{0}\n\r方法名称:{1}", ex.ToString(), ex.TargetSite.Name);

                WriteLog.AppendErrorLog(strText);
                
            }
            Pub.SocketCount = _dicSocketInfo.Count;
            //}
        }

        void _socketsvr_SocketClientClosed(object sender, SocketEventArgs e)
        {
            Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, DateTime.Now.ToString() + ">>连接断开", null, true));
        }

        public bool Send(string ip, int port, string text)
        {
            if (ip == "" | port == 0)
            {
                return false;
            }
            try
            {
                return _socketsvr.Send(ip, port, Common.Tools.SocketData.CreateBytes(text));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "发送Socket数据出错：" + ex.Message, null, true));
            }

            return false;
        }

        /// <summary>
        /// 用来自动判断断开
        /// </summary>
        private void CheckSocketConnect()
        {
            foreach (EndPoint item in _dicSocketInfo.Keys)
            {
                if (_dicSocketInfo[item].LastActiveDateTime.AddSeconds(30) < DateTime.Now)
                {

                    for (int i = _socketsvr.Clients.Count - 1; i >= 0; i--)
                    {
                        try
                        {
                            if (_socketsvr.Clients[i].TcpClient.Client.RemoteEndPoint == item)
                            {
                                _socketsvr.Clients[i].TcpClient.Client.Close();
                                _socketsvr.Clients.RemoveAt(i);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                    _dicSocketInfo.Remove(item);
                    Pub.SocketCount = _dicSocketInfo.Count;
                    break;
                }
            }
        }

        /// <summary>
        /// 取IP地址
        /// </summary>
        /// <param name="ipe"></param>
        /// <returns></returns>
        private string GetRemoteIP(string ipe)
        {
            try
            {
                string[] strs = ipe.Split(':');
                if (strs.Length > 0)
                {
                    return strs[0];
                }
            }
            catch (Exception)
            {
                return "";
            }
            return "";
        }

        /// <summary>
        /// 取端口号
        /// </summary>
        /// <param name="ipe"></param>
        /// <returns></returns>
        private int GetRemotePort(string ipe)
        {
            try
            {
                string[] strs = ipe.Split(':');
                if (strs.Length > 1)
                {
                    return Convert.ToInt32(strs[1]);
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 0;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            lock (_socketLock)
            {
                try
                {
                    CheckSocketConnect();
                    foreach (var item in _dicSocketInfo)
                    {
                        if (item.Value.ListByte.Count > 4)
                        {
                            int dataLength = BitConverter.ToInt32(item.Value.ListByte.ToArray(), 0);
                            if (item.Value.ListByte.Count >= dataLength + 4)
                            {
                                item.Value.ListByte.RemoveRange(0, 4);
                                string t1 = System.Text.Encoding.Default.GetString(item.Value.ListByte.GetRange(0, dataLength).ToArray());
                                item.Value.ListByte.RemoveRange(0, dataLength);
                                CommandObjectModel cmd = null;

                                try
                                {
                                    cmd = XmlManage<CommandObjectModel>.XmlToModel(t1);
                                    cmd.ClientIP = GetRemoteIP(item.Key.ToString());
                                    cmd.ClientPort = GetRemotePort(item.Key.ToString());
                                    if (cmd != null)
                                    {
                                        Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Receive, "", cmd, true));
                                        if (Pub._isDBOnline == true)
                                        {
                                            CommandFactory.CreateCommand(cmd.CmdType).DoWork(cmd);
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "CommandObejctModel解析xml文件出错：" + t1, null, true));
                                    item.Value.ListByte.Clear();
                                }
                            }
                            else
                            {
                                _timer.Enabled = true;
                                return;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "集合修改", null, true));
                }

            }
            _timer.Enabled = true;
        }

        void _socketsvr_SocketReceivedData(object sender, SocketReceivedDataEventArgs e)
        {
            try
            {
                lock (_socketLock)
                {
                    if (_dicSocketInfo.ContainsKey(e.RemoteEP) == true)
                    {
                        _dicSocketInfo[e.RemoteEP].LastActiveDateTime = DateTime.Now;
                        _dicSocketInfo[e.RemoteEP].ListByte.AddRange(e.ReceivedData);
                    }
                    else
                    {
                        _dicSocketInfo.Add(e.Socket.TcpClient.Client.RemoteEndPoint, new SocketInfo() { LastActiveDateTime = DateTime.Now, ListByte = new List<byte>() });
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "接收Socket数据出错：" + ex.Message, null, true));
            }
        }
    }

    /// <summary>
    /// 通讯信息类
    /// </summary>
    public class SocketInfo
    {
        /// <summary>
        /// 上次活动时间
        /// </summary>
        public DateTime LastActiveDateTime { get; set; }

        /// <summary>
        /// 接收到的数据
        /// </summary>
        public List<byte> ListByte { get; set; }
    }
}
