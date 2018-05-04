using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bestway.Windows.Tools.OPC;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Threading;
namespace Bestway.Windows.Program.MMS
{
    public class Worker:IDisposable
    {
        private OPCPowerBaseData opcdata = new OPCPowerBaseData();
        System.Timers.Timer m_timecheckPLC = new System.Timers.Timer(60 * 1000);

        System.Timers.Timer CheckOpcState = new System.Timers.Timer(1000 * 20);
        string[] itemNameCopy = null;
        OpcClient opc = null;

        List<Node> lstOpcData = null;       //未处理的OPC数据

        OPCClass opcPower = null;

        AshContent ac = null;

        object lockData = null;

        public System.Threading.Thread workerThread = null;
        volatile bool bExit = false;

        Sensors sensors = null;
        private DB_MMS db = null;
        Socket socket = null;

        public class OPCPowerBaseData
        {
            private float voltageRate=0;
            public float VoltageRate
            {
                get { return voltageRate; }
                set { voltageRate = value; }
            }

            private float currentRate=0;
            public float CurrentRate
            {
                get { return currentRate; }
                set { currentRate = value; }
            }

            private float currentValue=0;
            public float CurrentValue
            {
                get { return currentValue; }
                set { currentValue = value; }
            }
        }

        public Worker()
        {
            

            opc = new OpcClient();
            opc.DataChanged += new Opc.Da.DataChangedEventHandler(opc_DataChanged);
            opcPower = new OPCClass();
            opcPower.DataChange += new OPCClass.eventHandle(opcPower_DataChange);

            lstOpcData = new List<Node>();
            lockData = new object();

            workerThread = new System.Threading.Thread(WorkerProc);
            workerThread.IsBackground = true;

            db = new DB_MMS();


            sensors = new Sensors();
            sensors.DataDone += new DataDoneEventHandler(sensors_DataDone);

            socket = new Socket();

            ac = new AshContent();
            CheckOpcState.Elapsed+=new System.Timers.ElapsedEventHandler(CheckOpcState_Elapsed);
            CheckOpcState.Enabled = false;
           
        }

        void CheckOpcState_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                object[] obj = new object[itemNameCopy.Length];
                obj = opc.Read(itemNameCopy);
                /*
                if (obj == null)
                {
                    //推送给客户端
                }
                */
            }
            catch
            {
                //推送给客户端
                //socket.AddData(null, EnumSocketDataType.OPCServer_Unline, null);
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.ProgramFlag == false)
                    {
                        GlobalObject.Params.ProgramFlag = true;
                    }
                    GlobalObject.Params.OPC_Unline = true;
                }
                SendClient();
            }

        }
        
        //推送不在线给客户端
        public void SendClient()
        {
            FormMain frmMain = new FormMain();
            try
            {
                lock (GlobalObject.Params.lockState)
                {

                    if (GlobalObject.Params.OPC_Unline)
                    {
                        frmMain.setListBoxCallback("断开连接;",3);
                        GlobalObject.Params.OPC_Unline = false;
                        socket.AddData(null, EnumSocketDataType.OPCServer_Unline, new SensorModel());
                    }
                    if (GlobalObject.Params.OPCPower_Unline)
                    {
                        frmMain.setListBoxCallback("断开连接", 4);
                        GlobalObject.Params.OPCPower_Unline = false;
                        socket.AddData(null, EnumSocketDataType.OPCPower_Unline, new SensorModel());
                    }
                }
            }
            catch (Exception e)
            {
                lock (GlobalObject.Params.lockState)
                {
                    GlobalObject.Params.OPC_Unline = false;
                    GlobalObject.Params.OPCPower_Unline = false;
                }
                GlobalObject.Methods.WriteLog("推送OPC不在线信息给客户端失败:"+e.Message, true);
            }
        }
        void m_timecheckPLC_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            m_timecheckPLC.Enabled = false;
            List<PLCEntity> list = db.GetPLC();
            if (list == null || list.Count == 0)
            {
                GlobalObject.Methods.WriteLog("PLC地址为空，无法进行PLC状态控制");
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string ip = list[i].ip;
                    bool state = Ping(ip);
                    if (state == false)
                    {
                        int icount = 0;
                        while (icount < 3)
                        {
                            icount = icount + 1;
                            Thread.Sleep(5000);
                            state = Ping(ip);
                            if (state == true)
                            {
                                break;
                            }
                        }
                    }
                    if ((PLCState)list[i].state == PLCState.Unknow)
                    {
                        if (state == false)
                        {
                            //产生告警
                            db.PlcAlarmCurrent(list[i].id);
                        }
                    }
                    //结束告警
                    else if ((PLCState)list[i].state == PLCState.False && state == true)
                    {
                        db.PlcAlarmHistory(list[i].id);
                    }
                    //产生告警
                    else if ((PLCState)list[i].state == PLCState.True && state == false)
                    {
                        db.PlcAlarmCurrent(list[i].id);
                    }
                    //更新PLC当前状态
                    db.UpdataPLCState(list[i].id, state);
                }
            }
            m_timecheckPLC.Enabled = true;
        }

        private bool Ping(string ip)
        {
            Ping ping = new Ping();
            PingReply res;
            try
            {
                res = ping.Send(ip, 2000);
                if (res.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
      

        //System.Threading.Thread tdTestOPCDataSource;

        /// <summary>接收OPC数据</summary>
        private void opc_DataChanged(object subscriptionHandle, object requestHandle, Opc.Da.ItemValueResult[] values)
        {
            lock (lockData)
            {
                foreach (Opc.Da.ItemValueResult ivr in values)
                {
                    lstOpcData.Add(new Node()
                    {
                        Address = ivr.ItemName,
                        Value = ivr.Value,
                        DataTime = DateTime.Now
                    });
                }
            }
        }

        /// <summary>接收电力数据 </summary>
        private void opcPower_DataChange(object sender, OPCClass.ResuleItem[] resultitem)
        {
            lock (lockData)
            {
                try
                {
                    foreach (OPCClass.ResuleItem item in resultitem)
                    {
                        Node itemnode = new Node();
                        itemnode.Address = item.ItemName;
                        itemnode.Value = item.ItemValue;
                        itemnode.DataTime = DateTime.Now;
                        //sensors.UpdateData(itemnode);
                        OPCPowerBaseData baseData = new OPCPowerBaseData();
                        baseData.VoltageRate = item.PowerData.VoltageRate;
                        baseData.CurrentRate = item.PowerData.CurrentRate;
                        baseData.CurrentValue = item.PowerData.CurrentValue;
                        //GlobalObject.Methods.WriteLog("接收的电力数据:"+itemnode.Address + ":" + itemnode.Value + "," + baseData.VoltageRate + "," + baseData.CurrentRate + "," + baseData.CurrentValue, true);
                        sensors.UpdateData(itemnode, baseData);
                        //GlobalObject.Methods.WriteLog("处理接收的电力数据:",false);

                    }
                }
                catch (Exception e)
                {
                    GlobalObject.Methods.WriteLog("处理接收的电力数据异常:"+e.Message, false);
                }
            }
        }

        /// <summary>处理接收到的OPC数据</summary>
        private void WorkerProc(object obj)
        {
            Node node = null;
            while (!bExit)
            {
                lock (lockData)
                {
                    if (lstOpcData.Count > 0)
                    {
                        node = lstOpcData[0];
                        lstOpcData.RemoveAt(0);
                    }
                }
                if (node != null)
                {
                    //更新数据
                    //OPCPowerBaseData opcdata = new OPCPowerBaseData();
                    /*
                    opcdata.VoltageRate = -1;
                    opcdata.CurrentRate = -1;
                    opcdata.CurrentValue = -1;
                    */
                    //GlobalObject.Methods.WriteLog("接收的OPC数据:" + node.Address, true);
                    sensors.UpdateData(node,opcdata);

                    node = null;
                }
                else
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
            
        }


        /// <summary>数据变化事件</summary>
        private void sensors_DataDone(object sender, DataDoneEnvetArgs e)
        {

            //组建数据库SQL语句
            db.ExecData_CheckZero(e.IsRealTime, e.IsSetZero, e.Sensor, e.BasicData);

            //SOCKET发送到客户端
            if (e.IsRealTime) socket.AddData(null, EnumSocketDataType.SensorRealData, e.Sensor);
        }


        public bool Initialize()
        {
           
            if (!db.Initialize(GlobalObject.Params.Config.DbLoginInfo))
            {
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.ProgramFlag == false)
                    {
                        GlobalObject.Params.ProgramFlag = true;
                    }
                    GlobalObject.Params.DBInitialFlag = true;
                }
                db.Dispose();
                return false;
            }
            List<SensorModel> tempSensors = new List<SensorModel>();
            if (!db.GetSensorData(ref tempSensors))
            {
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.ProgramFlag == false)
                    {
                        GlobalObject.Params.ProgramFlag = true;
                    }
                    GlobalObject.Params.ReadSensorData = true;

                }
                db.Dispose();
                return false;
            }
            //SOCKET
            socket.Initialize(GlobalObject.Params.Config.SocketServerIP, GlobalObject.Params.Config.SocketServerPort);

            //初始化传感器集合类
            if (!sensors.Initialize(tempSensors))
            {
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.ProgramFlag == false)
                    {
                        GlobalObject.Params.ProgramFlag = true;
                    }
                    GlobalObject.Params.SensorInitialFlag = true;
                }
                GlobalObject.Methods.WriteLog("初始化传感器失败！");
                db.Dispose();
                socket.Dispose();
                return false;
            }
            m_timecheckPLC.Enabled = true;
            //初始化OPC
            if (!opc.Connect(GlobalObject.Params.Config.OpcServerIP,
                            GlobalObject.Params.Config.OpcType,
                            GlobalObject.Params.Config.OpcServerUserName,
                            GlobalObject.Params.Config.OpcServerPassword))
            {
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.ProgramFlag == false)
                    {
                        GlobalObject.Params.ProgramFlag = true;
                    }
                    GlobalObject.Params.OPCInitialFlag = true;
                }
                GlobalObject.Methods.WriteLog("连接OPC服务器失败！");
                db.Dispose();
                socket.Dispose();
                sensors.Dispose();
                return false;
            }
            else
            {
                //只取产量，风，水的传感器
                System.Data.DataSet dsOPCDataSource = db.getSensorAddress();
                if (dsOPCDataSource.Tables[0].Rows.Count <= 0)
                {
                    GlobalObject.Methods.WriteLog("连接OPC服务器失败，数据库中数据点个数0！");
                    db.Dispose();
                    socket.Dispose();
                    sensors.Dispose();
                    opc.Dispose();
                    return false;
                }
                string[] items = new string[dsOPCDataSource.Tables[0].Rows.Count];
                itemNameCopy = new string[dsOPCDataSource.Tables[0].Rows.Count];
                for (int i = 0; i < dsOPCDataSource.Tables[0].Rows.Count; i++)
                {
                    items[i] = dsOPCDataSource.Tables[0].Rows[i][1].ToString();
                    itemNameCopy[i] = dsOPCDataSource.Tables[0].Rows[i][1].ToString();
                }
                opc.AddItems(items);
                CheckOpcState.Enabled = true;
                
            }

            //电力部分OPC
            if (!opcPower.Connect(GlobalObject.Params.Config.OpcPowerType))
            {
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.ProgramFlag == false)
                    {
                        GlobalObject.Params.ProgramFlag = true;
                    }
                    GlobalObject.Params.OPCPowerInitialFlag = true;
                }
                GlobalObject.Methods.WriteLog("连接电力OPC服务器失败！");
                db.Dispose();
                socket.Dispose();
                sensors.Dispose();
                opc.Dispose();
                return false;
            }
            else
            {
                //只取电力传感器
                System.Data.DataSet dsOPCDataSource = db.dbHelper.GetDataSet("select NodeID, vc_Address from m_SensorNodes where SensorID in(select ID from m_sensor where TypeID=4) and NodeID<>3");
                if (dsOPCDataSource.Tables[0].Rows.Count <= 0)
                {
                    GlobalObject.Methods.WriteLog("连接OPC服务器失败，数据库中数据点个数0！");
                    db.Dispose();
                    socket.Dispose();
                    sensors.Dispose();
                    opc.Dispose();
                    opcPower.Dispose();
                    return false;
                }
                string[] items = new string[dsOPCDataSource.Tables[0].Rows.Count];
                for (int i = 0; i < dsOPCDataSource.Tables[0].Rows.Count; i++)
                {
                    items[i] = dsOPCDataSource.Tables[0].Rows[i][1].ToString();
                }
                opcPower.AddItem(items);
            }

            //灰分仪
            if (!ac.Initialize())
            {
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.ProgramFlag == false)
                    {
                        GlobalObject.Params.ProgramFlag = true;
                    }
                    GlobalObject.Params.ACInitialFlag = true;
                }
                db.Dispose();
                socket.Dispose();
                sensors.Dispose();
                opc.Dispose();
                opcPower.Dispose();
            }
            m_timecheckPLC.Elapsed += new System.Timers.ElapsedEventHandler(m_timecheckPLC_Elapsed);
            workerThread.Start();
            //tdTestOPCDataSource = new System.Threading.Thread(runTestOPCDataSource);
            //tdTestOPCDataSource.Start();
            return true;
        }


        public void Dispose()
        {

            bExit = true;
            while ((int)(workerThread.ThreadState & System.Threading.ThreadState.Stopped) !=0 &&
                   (int)(workerThread.ThreadState & System.Threading.ThreadState.Unstarted) != 0)
            {
                System.Threading.Thread.Sleep(100);
            }

            
            opcPower.Dispose();
            socket.Dispose();
            ac.Dispse();
            db.Dispose();
            sensors.Dispose();
            m_timecheckPLC.Close();
            m_timecheckPLC.Dispose();
            workerThread.Abort();
            opc.Dispose();
           
        }


        //void runTestOPCDataSource()
        //{
        //    int nData = 1;
        //    System.Data.DataSet dsOPCDataSource =db.dbHelper.GetDataSet("select NodeID, vc_Address from m_SensorNodes");

        //    while (!bExit)
        //    {
        //        for (int i = 0; i < dsOPCDataSource.Tables[0].Rows.Count; i++)
        //        {
        //            if (dsOPCDataSource.Tables[0].Rows[i][0].ToString() == "3")//状态
        //            {
        //                lstOpcData.Add(new Node()
        //                {
        //                    Address = dsOPCDataSource.Tables[0].Rows[i][1].ToString(),
        //                    Value = "0",
        //                    DataTime = DateTime.Now
        //                });
        //            }
        //            else
        //            {
        //                lstOpcData.Add(new Node()
        //                {
        //                    Address = dsOPCDataSource.Tables[0].Rows[i][1].ToString(),
        //                    Value =    Convert.ToString(nData),
        //                    DataTime = DateTime.Now
        //                });
        //            }
        //            System.Threading.Thread.Sleep(100);
        //        }
        //        ++nData;

        //        System.Threading.Thread.Sleep(2000);
        //    }
        //}
    }
    class PLCEntity
    {
        public int id;
        public string name;
        public string ip;
        public string remark;
        public int state;
        
    }
    public enum PLCState
    {
        Unknow=-1,
        True=0,
        False=1
    }
}
