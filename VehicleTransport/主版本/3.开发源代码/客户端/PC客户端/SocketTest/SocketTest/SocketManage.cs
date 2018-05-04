using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bestway.Windows.Tools.Communication.Net;
using Common.Model;
using Common;
using Common.Enum;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using Common.Model.InCommandModel;
using VehicleTransportClient.Tools;
using Model = DB_VehicleTransportManage.Model;
using BLL = DB_VehicleTransportManage.BLL;
namespace VehicleTransportClient
{
    /// <summary>
    /// 通讯管理类,客户程序
    /// </summary>
    public class SocketManage
    {
        //  public static readonly SocketManage instance = new SocketManage();
        private SocketClient _socketClient = null;//
        private string _ip;
        private int _port;
        private CommandResult _commandResult = new CommandResult();
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        //   private System.Windows.Forms.Timer _heatertimer = new System.Windows.Forms.Timer();
        //  private int _heatercount = 0;
        /// <summary>
        /// 数据缓存
        /// </summary>
        private List<byte> _lstByte = new List<byte>();

        public bool InitSocket(string localIP,string remoteIP,int port)
        {
            try
            {
                _socketClient = new SocketClient(localIP);
                _socketClient.SocketReceivedData += new SocketReceivedDataEventHandler(_socketClient_SocketReceivedData);
                _socketClient.SocketConnected += new SocketEventHandler(_socketClient_SocketConnected);
                // _socketClient.SocketError += new SocketErrorEventHandler(_socketClient_SocketError);
                // _socketClient.SocketClosed += new SocketEventHandler(_socketClient_SocketClosed);
                return  _socketClient.Connect(remoteIP, port, 5);
            }
            catch (Exception)
            {

                return false;
            }
            
          
        }


        public SocketManage()
        {

           // InitSocket();

            _timer.Interval = 10;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Enabled = true;

            //_heatertimer.Interval = 10000;
            //_heatertimer.Tick += new EventHandler(_heatertimer_Tick);
        }



        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            if (_lstByte.Count > 4)
            {
                int dataLength = BitConverter.ToInt32(_lstByte.ToArray(), 0);
                if (_lstByte.Count >= dataLength + 4)
                {
                    _lstByte.RemoveRange(0, 4);
                    string t1 = System.Text.Encoding.Default.GetString(_lstByte.GetRange(0, dataLength).ToArray());
                    _lstByte.RemoveRange(0, dataLength);
                    CommandObjectModel gg = null;
                    try
                    {
                        gg = XmlManage<CommandObjectModel>.XmlToModel(t1);
                        _commandResult.DoCommandResult(gg.CmdID, gg.Result);
                        if (gg.CmdType == EnumCommandType.GetFlowPath)
                        {
                            // FlowPathModel fp = XmlManage<Common.Model.OutCommandModel.FlowPathModel>.XmlToModel(gg.CmdModelXml);
                        }
                        if (gg.CmdType == EnumCommandType.GetAPKFile)
                        {
                            Common.Model.OutCommandModel.OutApkFileModel ff = new Common.Model.OutCommandModel.OutApkFileModel();
                            ff = XmlManage<Common.Model.OutCommandModel.OutApkFileModel>.XmlToModel(gg.CmdModelXml);
                        }
                        if (gg.CmdType == EnumCommandType.SendRefresh)
                        {

                        }
                        if (gg.CmdType == EnumCommandType.SendAlarm)
                        {

                        }
                    }
                    catch (Exception)
                    {
                        _timer.Enabled = true;
                        throw;
                    }
                }
                else
                {
                    _timer.Enabled = true;
                    return;
                }
            }
            _timer.Enabled = true;
        }

        /// <summary>
        /// 不等待返回结果的发送
        /// </summary>
        /// <param name="cmdModel"></param>
        /// <returns></returns>
        public bool Send(CommandObjectModel cmdModel)
        {
            cmdModel.ClientIP = _ip;
            cmdModel.ClientPort = _port;
            cmdModel.CmdID = cmdModel.GetHashCode();
            string x = XmlManage<CommandObjectModel>.ModelToXml(cmdModel);
            return _socketClient.Send(Common.Tools.SocketData.CreateBytes(x));
        }

        /// <summary>
        /// 等待返回结果的发送
        /// </summary>
        /// <param name="cmdModel"></param>
        /// <returns></returns>
        /// 
        public bool SendAndWait(CommandObjectModel cmdModel)
        {
            cmdModel.ClientIP = _ip;
            cmdModel.ClientPort = _port;
            cmdModel.CmdID = cmdModel.GetHashCode();
            string x = XmlManage<CommandObjectModel>.ModelToXml(cmdModel);
            //x=x+"sdf";

            _commandResult.AddCommand(cmdModel.CmdID);
            if (_socketClient.Send(Common.Tools.SocketData.CreateBytes(x)))
            {
                DateTime dt = DateTime.Now.AddMilliseconds(1000 * 15);
                while (DateTime.Now < dt)
                {
                    if (_commandResult.GetResponseResult(cmdModel.CmdID) == true)
                    {
                        break;
                    }
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
                return _commandResult.GetExecResult(cmdModel.CmdID);
            }
            return false;
        }

        /// <summary>
        /// socket连接成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _socketClient_SocketConnected(object sender, SocketEventArgs e)
        {

            //  Pub.IsServerConnect = true;
            System.Net.IPEndPoint ie = (System.Net.IPEndPoint)_socketClient.TcpClient.Client.LocalEndPoint;
            _port = ie.Port;
            _ip = ie.Address.ToString();
            //int i = 0;
            //bool b = false;
            //if (Pub.UserId != -1)
            //{
            //    while (i < 4)
            //    {
            //        b=Login(Pub.UserName, Pub.Pwd);
            //        if (b == true)
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            i = i + 1;
            //        }
            //    }
            //    if (b == false)
            //    {
            //        Common.MessageBoxEx.MessageBoxEx.Show("登陆失败,系统即将关闭", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        Application.Exit();
            //        return;
            //    }
            //}
            //_heatertimer.Enabled=true;

        }
        /// <summary>
        /// 数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _socketClient_SocketReceivedData(object sender, SocketReceivedDataEventArgs e)
        {
            // _heatercount = 0;
            _lstByte.AddRange(e.ReceivedData);
        }

    }
}
