using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Bestway.Windows.Program.MMS
{
    class DataDoneEnvetArgs : EventArgs
    {
        public bool IsSetZero { get; set; }  //lj20140909
        public bool IsRealTime { get; set; }
        public SensorModel Sensor { get; set; }
        
        public Worker.OPCPowerBaseData BasicData { get; set; }
    }

    delegate void DataDoneEventHandler(object sender, DataDoneEnvetArgs e);

    //所有传感器信息
    class Sensors : IDisposable
    {
        public Sensors()
        {
            sensors = new List<SensorModel>();

            lockData = new object();
            raiseEventThread = new System.Threading.Thread(RaiseEventProc);
            raiseEventThread.IsBackground = true;
            db.Initialize(GlobalObject.Params.Config.DbLoginInfo);
        }
        public event DataDoneEventHandler DataDone;

        private volatile bool bExit = false;
        private object lockData = null;
        private System.Threading.Thread raiseEventThread = null;
        private DB_MMS db = new DB_MMS();

        private List<SensorModel> sensors = null;

        private void RaiseEventProc(object obj)
        {
            #region
            /*
            System.Threading.Thread.Sleep(GlobalObject.Params.Config.SaveDatabaseRate * 1000);
            while (!bExit)
            {
                if (this.DataDone != null)
                {
                    //GlobalObject.Methods.WriteLog("开始处理历史记录");
                    foreach(SensorModel sm in sensors)
                    {
                        DataDoneEnvetArgs e = new DataDoneEnvetArgs();
                        e.IsSetZero = false;
                        e.IsRealTime = false;
                        
                        lock (lockData)
                        {
                            //数据没更新
                            if (!sm.IsUpdated) continue;                            
                            e.Sensor = (SensorModel)sm.Clone();
                            e.BasicData = sm.OPCPowerData;
                            sm.IsUpdated = false;
                            
                            //把当前的替换成前一次数据
                            sm.NodesPrevious = (SensorNodes)sm.NodesRealTime.Clone();
                         //zy 20140521
                        //}
                        //if (e.Sensor.IsUpdated)
                        //{
                            if (e.Sensor.Type == Bestway.Windows.Program.SocketDataModel.MMS.EnumSensorType.Power)
                            {
                                //GlobalObject.Methods.WriteLog("更新历史电量数据" + e.Sensor.ID + "当前总值:" + e.Sensor.NodesRealTime[EnumNodeType.Total].Value.ToString() + "历史总值:" + e.Sensor.NodesPrevious[EnumNodeType.Total].Value.ToString());
                            }

                            //zy 20140404 
                            if (e.Sensor.NodesPrevious[EnumNodeType.Total].Value.ToString() == "false")
                            {
                                continue;
                            }
                        
                            //GlobalObject.Methods.WriteLog(e.Sensor.ID.ToString()+":"+e.Sensor.IsUpdated.ToString()+" "+sm.IsUpdated.ToString()+" "+
                            //    e.Sensor.NodesPrevious[EnumNodeType.Total].Value.ToString() +
                            //    " :" +
                            //    e.Sensor.NodesPrevious[EnumNodeType.Realtime].Value.ToString()
                            //    +
                            //    " :" + e.Sensor.NodesRealTime[EnumNodeType.Total].Value.ToString() +
                            //    " :" +
                            //    e.Sensor.NodesRealTime[EnumNodeType.Realtime].Value.ToString());
                            this.DataDone(this, e);
                        }
                    }
                   System.Threading.Thread.Sleep(GlobalObject.Params.Config.SaveDatabaseRate * 1000);
                  
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
            */
            #endregion
            //if (DateTime.Now.Minute - GlobalObject.Params.Config.SaveDatabaseRate / 60 < 3)
            //{
            //    System.Threading.Thread.Sleep(3*60*1000);
            //}
            bool flag = false;
            while(!bExit)
            {
                DateTime t = DateTime.Now;
                int sleeptime = GlobalObject.Params.Config.SaveDatabaseRate / 60;
                //Console.WriteLine(t + " " + t.Second.ToString());
                if (t.Second == 0 && t.Minute % sleeptime == 0)
                {
                    flag = true;
                    DataProc();
                }
                if (flag)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {

                    System.Threading.Thread.Sleep(500);
                }
            }
        }


        private void DataProc()
        {
            if (this.DataDone != null)
            {
                //GlobalObject.Methods.WriteLog("开始处理历史记录");
                foreach (SensorModel sm in sensors)
                {
                    DataDoneEnvetArgs e = new DataDoneEnvetArgs();
                    e.IsSetZero = false;
                    e.IsRealTime = false;

                    lock (lockData)
                    {
                        //数据没更新
                        if (!sm.IsUpdated) continue;
                        e.Sensor = (SensorModel)sm.Clone();
                        e.BasicData = sm.OPCPowerData;
                        sm.IsUpdated = false;

                        //把当前的替换成前一次数据
                        sm.NodesPrevious = (SensorNodes)sm.NodesRealTime.Clone();
                        //zy 20140521
                        //}
                        //if (e.Sensor.IsUpdated)
                        //{
                        if (e.Sensor.Type == Bestway.Windows.Program.SocketDataModel.MMS.EnumSensorType.Power)
                        {
                            //GlobalObject.Methods.WriteLog("更新历史电量数据" + e.Sensor.ID + "当前总值:" + e.Sensor.NodesRealTime[EnumNodeType.Total].Value.ToString() + "历史总值:" + e.Sensor.NodesPrevious[EnumNodeType.Total].Value.ToString());
                        }

                        //zy 20140404 
                        if (e.Sensor.NodesPrevious[EnumNodeType.Total].Value.ToString() == "false")
                        {
                            continue;
                        }

                        //GlobalObject.Methods.WriteLog(e.Sensor.ID.ToString()+":"+e.Sensor.IsUpdated.ToString()+" "+sm.IsUpdated.ToString()+" "+
                        //    e.Sensor.NodesPrevious[EnumNodeType.Total].Value.ToString() +
                        //    " :" +
                        //    e.Sensor.NodesPrevious[EnumNodeType.Realtime].Value.ToString()
                        //    +
                        //    " :" + e.Sensor.NodesRealTime[EnumNodeType.Total].Value.ToString() +
                        //    " :" +
                        //    e.Sensor.NodesRealTime[EnumNodeType.Realtime].Value.ToString());
                        this.DataDone(this, e);
                    }
                }
            }
        }

        public bool Initialize(List<SensorModel> sensors)
        {
            this.sensors.Clear();
            foreach (SensorModel sm in sensors)
            {
                this.sensors.Add((SensorModel)sm.Clone());
            }

            bExit = false;
            raiseEventThread.Start();

            return true;
        }

        public void Dispose()
        {
            bExit = true;
            //while (raiseEventThread.ThreadState != System.Threading.ThreadState.Stopped)
            while ((int)(raiseEventThread.ThreadState & System.Threading.ThreadState.Stopped) != 0 &&
                (int)(raiseEventThread.ThreadState & System.Threading.ThreadState.Unstarted) != 0)
            {
                System.Threading.Thread.Sleep(100);
            }
            sensors.Clear();
            raiseEventThread.Abort();
           
        }



        /*
        //lj 20140814
        public string GetSensorID(string Address, out SensorModel sensor, string id)
        {
            try
            {
                foreach (SensorModel sm in sensors)
                {
                    foreach (Node n in sm.NodesRealTime)
                    {
                        if (n.Address == Address)
                        {
                            sensor = sm;
                            //nodetype = n.Type;
                            id = sensor.ID.ToString();


                        }
                    }
                }    

            }
            catch
            {
            }
            sensor = null;
            return id;
        }
        */

        /// <summary>根据地址获取传感器</summary>
        /// <param name="nodeAddress">节点地址</param>
        /// <param name="sensor"></param>
        /// <param name="nodetype"></param>
        /// <returns></returns>
        private bool FindSensor(string nodeAddress, out SensorModel sensor, ref EnumNodeType nodetype)
        {
            foreach (SensorModel sm in sensors)
            {
                foreach (Node n in sm.NodesRealTime)
                {
                    if (n.Address == nodeAddress)
                    {
                        sensor = sm;
                        nodetype = n.Type;
                        return true;
                    }
                }
            }
            sensor = null;
            return false;
        }


        /// <summary>更新数据</summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool UpdateData(Node node, Worker.OPCPowerBaseData ls)
        {
            
                //GlobalObject.Methods.WriteLog("收到的处理数据:" + node.Address+"  "+node.Value, false);
                //if (Int32.Parse(node.Value.ToString()) < 0)
                //{
                //    return false;
                //}
                //GlobalObject.Methods.WriteLog("处理数据：" + node.Address+","+node.Value+","+ls.VoltageRate, false);
                //解析节点类型
                SensorModel sm = null;
                EnumNodeType nt = EnumNodeType.Unknow;
                if (!FindSensor(node.Address, out sm, ref nt))
                {
                    //GlobalObject.Methods.WriteLog("没有该节点:" + node.Address, true);
                    return false;
                }
                //GlobalObject.Methods.WriteLog("传感器类型:" + sm.Type.GetHashCode().ToString(), true);
                
                ////累计量，当前值小于上次值
                //if (node.Type == EnumNodeType.Total &&
                //    sensors[node.ParentCode].Nodes[node.Type].Value > node.Value)
                //{
                //    GlobalObject.Methods.WriteLog(
                //        string.Format("当前累计量小于前一次累计量！设备编号:{0}，时间:{1}", 
                //        node.ParentCode, node.DataTime.ToString("yyyy-MM-dd HH:mm:ss")));
                //}
                //zy 20140521
                
            try
            {
                lock (lockData)
                {
                    
                    //传感器告警状态处理 zy
                    if (nt == EnumNodeType.State && sm.NodesRealTime[nt].Value != node.Value)
                    {
                        
                        sm.NodesTemp[nt].Value = node.Value;
                        sm.NodesTemp[nt].DataTime = node.DataTime;
                        sm.NodesRealTime[nt].Value = node.Value;
                        sm.NodesRealTime[nt].DataTime = node.DataTime;
                        if (node.Value.ToString() == "0")
                        {
                            //结束告警
                            db.SensorAlarmHistory(sm.ID);

                        }
                        else if (node.Value.ToString() == "1")
                        {
                            //产生告警
                            db.AddSensorAlarm(sm.ID, sm.AreaID, sm.DeptID);
                        }
                        return true;

                    }

                    sm.NodesTemp[nt].Value = node.Value;
                    sm.NodesTemp[nt].DataTime = node.DataTime;


                    //置换当前数据为上次数据
                    //sm.NodesPrevious[nt].Value = sm.NodesRealTime[nt].Value;
                    //sm.NodesPrevious[nt].DataTime = sm.NodesRealTime[nt].DataTime;


                    //lj20140909
                    //置换当前数据为上次数据
                    sm.NodesPrevious[nt].Value = sm.NodesRealTime[nt].Value;
                    sm.NodesPrevious[nt].DataTime = sm.NodesRealTime[nt].DataTime;

                    //更新当前数据
                    sm.NodesRealTime[nt].Value = node.Value;
                    sm.NodesRealTime[nt].DataTime = node.DataTime;

                    if (this.DataDone != null)
                    {
                        //GlobalObject.Methods.WriteLog("DataDoneOK：", false);
                        //置0时数据的存储，20140909lj
                        DataDoneEnvetArgs e = new DataDoneEnvetArgs();
                        //GlobalObject.Methods.WriteLog("前一个值 " + sm.NodesPrevious[EnumNodeType.Total].Value, false);
                        //GlobalObject.Methods.WriteLog("当前值 " + sm.NodesRealTime[EnumNodeType.Total].Value, false);
                        if (float.Parse(sm.NodesPrevious[EnumNodeType.Total].Value.ToString()) > float.Parse(sm.NodesRealTime[EnumNodeType.Total].Value.ToString()))
                        {
              
                            //DataDoneEnvetArgs e = new DataDoneEnvetArgs();
                            e.IsSetZero = true;
                            e.IsRealTime = false;
                            e.Sensor = (SensorModel)sm.Clone();
                            sm.OPCPowerData = ls;
                            e.BasicData = ls;
                            sm.IsUpdated = true;
                           
                            this.DataDone(this, e);
                           
                           
                        }
                        else
                        {
                            if (float.Parse(sm.NodesTemp[EnumNodeType.Total].Value.ToString()) > 0.00 &&
                                float.Parse(sm.NodesTemp[EnumNodeType.Realtime].Value.ToString()) > 0.00)
                            {

                                //DataDoneEnvetArgs e = new DataDoneEnvetArgs();    //lj
                                e.IsSetZero = false;
                                e.IsRealTime = true;
                                e.Sensor = (SensorModel)sm.Clone();
                                sm.OPCPowerData = ls;
                                //GlobalObject.Methods.WriteLog("处理sm的数据"+sm.OPCPowerData.VoltageRate+","+sm.OPCPowerData.CurrentRate+","+sm.OPCPowerData.CurrentValue,false);
                                e.BasicData = ls;
                                //GlobalObject.Methods.WriteLog("处理e的数据" + e.BasicData.VoltageRate + "," + e.BasicData.CurrentRate + "," + e.BasicData.CurrentValue, false);
                                //zy 20140409
                                if (e.Sensor.NodesPrevious[EnumNodeType.Total].Value.ToString() == "false")
                                {
                                    e.Sensor.NodesPrevious[EnumNodeType.Total].Value = "0";
                                }

                                sm.NodesTemp[EnumNodeType.Realtime].Value = 0;
                                sm.NodesTemp[EnumNodeType.Total].Value = 0;
                                sm.IsUpdated = true;
                                
                                this.DataDone(this, e);
                                
                                
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
               
                GlobalObject.Methods.WriteLog("UpdateData函数出错："+e.Message+e.StackTrace,false);
                return false;
            }
        }
        
    }
}
