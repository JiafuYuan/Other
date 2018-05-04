using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace BW.MMS.Server
{
    public class SocServer
    {
        private Socket soc;//Socket
        private bool isWatching;
        private List<Socket> clientList;

        #region 参数
        /// <summary>
        /// 服务端IP
        /// </summary>
        private string iPServer;
        private string IPServer
        {
            get { return iPServer; }
            set { iPServer = value; }
        }
        /// <summary>
        /// 服务端端口
        /// </summary>
        private Int32 portServer;
        private Int32 PortServer
        {
            get { return portServer; }
            set { portServer = value; }
        }
        /// <summary>
        /// 服务端终结点
        /// </summary>
        private IPEndPoint endPointServer;
        private IPEndPoint EndPointServer
        {
            get { return endPointServer; }
            set { endPointServer = value; }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public SocServer(string strLocalIP, string strLocalPort)
        {
            this.IPServer = strLocalIP;
            this.PortServer = Int32.Parse(strLocalPort);
            this.EndPointServer = new IPEndPoint(IPAddress.Parse(this.IPServer), this.PortServer);
        }
        ~SocServer()
        {
            isWatching = false;
        }

        public void StartListing()
        {
            soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            soc.Bind(EndPointServer);
            clientList = new List<Socket>();
            isWatching = true;
            Thread td = new Thread(new ThreadStart(runWatching));
            td.Start();
            td.IsBackground = true;



            Thread t = new Thread(new ThreadStart(runDeleteDisConnectedSocket));
            t.Start();
        }

        private void runDeleteDisConnectedSocket()
        {
            while (isWatching)
            {
                Thread.Sleep(1000);
                Socket removeItem = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket socTmp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
               try
               {
                    foreach (Socket s in clientList)
                    {
                        try
                        {
                            socTmp.Bind(new IPEndPoint(IPAddress.Parse(this.IPServer), 11235));
                            removeItem = s;
                            socTmp.Connect(s.RemoteEndPoint);
                        }
                        catch (Exception ex)
                        {
                            if (!(((SocketException)ex).ErrorCode == 10061))
                            {
                                //表示断开
                                lock (clientList)
                                {
                                    clientList.Remove(removeItem);
                                    break;
                                }
                            }
                        }
                        socTmp.Dispose();
                        GC.Collect();
                    }
                }
               catch
               {}
            }
            
        }

        private void runWatching()
        {
            while (isWatching)
            {
                soc.Listen(10);
                Socket socClient = soc.Accept();
                clientList.Add(socClient);
            }
        }

        private void acceptResult(IAsyncResult iar)
        {
            if (iar.IsCompleted)
            {
                Socket s= (Socket )iar.AsyncState;
            }
        }
        public void Send(string content)
        {
            foreach (Socket s in clientList)
            {
                //s.Send(UTF8Encoding.UTF8.GetBytes(" " + content));
                SocketError err = new SocketError();
                s.BeginSend(UTF8Encoding.UTF8.GetBytes(" " + content), 0, UTF8Encoding.UTF8.GetBytes(" " + content).Length, SocketFlags.None,out err, new AsyncCallback(SendResult), s);
            }
        }

        private void SendResult(IAsyncResult ia)
        {
            try
            {
                if (ia.IsCompleted)
                {
                    Socket s = (Socket)ia.AsyncState;
                    int n= s.EndSend(ia);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public string getClientCount()
        {
            string str = "0";
            try
            {
                foreach (Socket s in clientList)
                {
                    if (str == "0") str = clientList.Count.ToString ()+" |";

                    str += s.RemoteEndPoint.ToString ()+" ";
                }
            }
            catch { }
            return str;
        }
    }
}