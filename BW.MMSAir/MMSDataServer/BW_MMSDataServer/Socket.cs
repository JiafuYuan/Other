using System;
using System.Collections.Generic;
using System.Text;
using Bestway.Windows.Program.SocketDataModel.MMS;
using System.Windows.Forms;
using Bestway.Windows.Tools.Communication.Net;
using Bestway.Windows.Tools.Communication;
using Bestway.Windows.Tools.Serialization;
namespace Bestway.Windows.Program.MMS
{

    /*
    class SocketClient
    {
        public string Key { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
        public object Param { get; set; }
    }
    class SocketClients
    {
        public SocketClients()
        {
            lstClient = new Dictionary<string, SocketClient>();
        }
        private Dictionary<string ,SocketClient> lstClient = null;


        public SocketClient this[string key]
        {
            get { return lstClient[key]; }
        }

        public void Add(SocketClient client)
        {

        }
        public void Remove(SocketClient client)
        {

        }

    }
    */

    /// <summary>SOCKET数据类型 </summary>
    enum EnumSocketDataType
    {
        SensorRealData=0,       //传感器实时数据
        OPCServer_Unline=1,     //OPC服务器不在线
        OPCPower_Unline = 2     //OPC电力服务器不在线
    }


    /// <summary>数据集</summary>
    class SocketDataCollection
    {
        public List<string> Clients { get; set; }
        public EnumSocketDataType DataType { get; set; }
        public SensorModel Sensor { get; set; }
    }


    class Socket : IDisposable
    {
        public Socket()
        {
            lockData = new object();
            lstData = new List<SocketDataCollection>();
            thread = new System.Threading.Thread(SocketSendDataProc);
            thread.IsBackground = true;

        }
        SocketServer server = null;
        FrameProxy frameProxy = null;
        object lockData = null;
        volatile bool bExit = false;
        List<SocketDataCollection> lstData = null;
        System.Threading.Thread thread = null;


        #region socket events
        private void socket_SocketReceivedData(object sender, SocketReceivedDataEventArgs e)
        {
            frameProxy.AddReceiveData(e.ReceivedData);
        }
        private void sa_SocketAssistantReceivedData(object sender, FrameEventArgs e)
        {

        }

        private void socket_SocketError(object sender, SocketErrorEventArgs e)
        {

        }

        private void socket_SocketClientClosed(object sender, SocketEventArgs e)
        {

        }
        private void socket_SocketAccepted(object sender, SocketEventArgs e)
        {


        }
        #endregion

        private void SocketSendDataProc(object param)
        {
            SocketDataCollection data = null;
            while (!bExit)
            {
                lock (lockData)
                {
                    if (lstData.Count > 0)
                    {
                        data = lstData[0];
                        lstData.RemoveAt(0);
                    }
                }

                if (data != null)
                {
                    
                    object obj = null;
                    if (data.DataType == EnumSocketDataType.SensorRealData)
                    {
                        Bestway.Windows.Program.SocketDataModel.MMS.SensorModel model = new Bestway.Windows.Program.SocketDataModel.MMS.SensorModel();
                        model.AreaID = data.Sensor.AreaID;
                        model.DeptID = data.Sensor.DeptID;
                        model.RealData = float.Parse(data.Sensor.NodesRealTime[EnumNodeType.Realtime].Value.ToString());
                        model.TotalData = float.Parse(data.Sensor.NodesRealTime[EnumNodeType.Total].Value.ToString());

                        //sm.State = (EnumSensorState)data.Sensor.NodesRealTime.State.Value;
                        bool result = false;
                        if (bool.TryParse(data.Sensor.NodesRealTime[EnumNodeType.State].Value.ToString(), out result))
                        {
                            model.State = (result ? EnumSensorState.Online : EnumSensorState.Unline);
                        }
                        else
                        {
                            model.State = EnumSensorState.UnKnow;
                        }

                        model.DataTime = data.Sensor.NodesRealTime[EnumNodeType.Realtime].DataTime;
                        model.SensorID = data.Sensor.ID;
                        model.Type = data.Sensor.Type;

                        obj = model;
                    }

                    if (obj != null)
                    {
                        byte[] byteDatas = SerializerInDotNet.Object2Bytes(obj);
                        IFrame frame = new Frame(0, byteDatas);
                        frameProxy.Send(null, frame, null);
                        //byteDatas = SocketAssistant.PacketData(byteDatas);
                        //if (byteDatas != null)
                        //{
                        //    try
                        //    {
                        //        socket.Send(byteDatas);
                        //    }
                        //    catch {
                        //        continue;
                        //    }
                        //}
                    }
                    if (data.DataType == EnumSocketDataType.OPCServer_Unline)
                    {
                        string str = "OPC服务器不在线";
                        byte[] byteDatas = SerializerInDotNet.Object2Bytes(str);
                        IFrame frame = new Frame(1, byteDatas);
                        frameProxy.Send(null, frame, null);
                    }
                    if (data.DataType == EnumSocketDataType.OPCPower_Unline)
                    {
                        string str = "OPC电力服务器不在线";
                        byte[] byteDatas = SerializerInDotNet.Object2Bytes(str);
                        IFrame frame = new Frame(2, byteDatas);
                        frameProxy.Send(null, frame, null);
                    }
                    data = null;
                    
                }
                else
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
        }


        public void Initialize(string ip, int port)
        {
            if (server != null) return;

            thread.Start();

            server = new SocketServer(ip, port);
            server.SocketAccepted += new SocketEventHandler(socket_SocketAccepted);
            server.SocketClientClosed += new SocketEventHandler(socket_SocketClientClosed);
            server.SocketError += new SocketErrorEventHandler(socket_SocketError);
            server.SocketReceivedData += new SocketReceivedDataEventHandler(socket_SocketReceivedData);

            //sa = new SocketAssistant(socket);
            //sa.SocketAssistantReceivedData += new SocketAssistantDataReceivedEventHandler(sa_SocketAssistantReceivedData);
            frameProxy = new FrameProxy();
            frameProxy.OnFrameReceived += new FrameEventHandler(sa_SocketAssistantReceivedData);
            frameProxy.Initialize(new FuncSendFrame(delegate(object sender, byte[] buffer, object param)
            {
                return server.Send(buffer);
            }), 1000);
            server.Start();
        }

        public void Dispose()
        {
            bExit = true;
            while ((int)(thread.ThreadState & System.Threading.ThreadState.Stopped) != 0 &&
                   (int)(thread.ThreadState & System.Threading.ThreadState.Unstarted) != 0)
            {
                System.Threading.Thread.Sleep(100);
            }
            server.Stop();
            thread.Abort();
        }

        public void AddData(List<string> clients, EnumSocketDataType datatype, SensorModel sensor)
        {
            lock (lockData)
            {
                lstData.Add(new SocketDataCollection()
                {
                    Clients = clients,
                    DataType = datatype,
                    Sensor = (SensorModel)sensor.Clone()
                });
            }
        }
    }
}
