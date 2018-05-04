using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OPCAutomation;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
namespace Bestway.Windows.Program.MMS
{
    /// <summary>
    /// OPC连接类(变态的电力部分专用)
    /// </summary>
    public class OPCClass
    {
        
        private OPCAutomation.OPCServer server = null;     //OPC服务器
        private OPCAutomation.OPCGroup group = null;       //添加组
        private Array ServerHandlers;                      //服务端句柄
        private Array ClientHandles;                       //客户端句柄
        private Array OPCItems;                            //OPC节点数组
        private Array arrError;                            //错误信息数组
        private Dictionary<int, string> dicClientHandlerToItemName=new Dictionary<int,string>();        //存放客户端句柄跟节点地址的对应关系
        private Dictionary<string, float[]> dicCleintHandlerToRate = new Dictionary<string, float[]>();       //存放客户端句柄跟变比的对应关系
        private bool isExit = false;
        private object lockObj = new object();
        private System.Threading.Thread tdFlashRate = null;
        System.Timers.Timer checkopc = new System.Timers.Timer(1000 * 60);
        System.Timers.Timer CheckOpcPowerState = new System.Timers.Timer(1000 * 20);
        private DateTime lastupDt = DateTime.Now;
        public delegate void eventHandle(object sender,ResuleItem[] resultitem);

        public event eventHandle DataChange;

        
        public struct ResuleItem
        {
            private string itemName;
            public string ItemName
            {
                get { return itemName; }
                set { itemName = value; }
            }

            private object itemValue;
            public object ItemValue
            {
              get { return itemValue; }
              set { itemValue = value; }
            }

            //lj20140909
            /*
            private float voltageRate;
            public float VoltageRate
            {
                get { return voltageRate; }
                set { voltageRate = value; }
            }

            private float currentRate;
            public float CurrentRate
            {
                get { return currentRate; }
                set { currentRate = value; }
            }

            private float currentValue;
            public float CurrentValue
            {
                get { return currentValue; }
                set { currentValue = value; }
            }
            */
            private Worker.OPCPowerBaseData powerData;
            public Worker.OPCPowerBaseData PowerData 
            {
                get { return powerData; }
                set { powerData = value; }
            }

        }
        public OPCClass()
        {
            checkopc.Elapsed += new System.Timers.ElapsedEventHandler(checkopc_Elapsed);
            CheckOpcPowerState.Elapsed+=new System.Timers.ElapsedEventHandler(CheckOpcState_Elapsed);
            CheckOpcPowerState.Enabled = false;
            tdFlashRate = new System.Threading.Thread(new System.Threading.ThreadStart(FlashRateProc));
            tdFlashRate.IsBackground = true;
            
        }

        void CheckOpcState_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (server.ServerState != (int)OPCServerState.OPCRunning)
            {
                //推送给客户端
                lock (GlobalObject.Params.lockState)
                {
                    if (GlobalObject.Params.ProgramFlag == false)
                    {
                        GlobalObject.Params.ProgramFlag = true;
                    }
                    GlobalObject.Params.OPCPower_Unline = true;
                }
                Worker work_OPC = new Worker();
                work_OPC.SendClient();
            }
        }

        void checkopc_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            checkopc.Enabled = false;
            try
            {
                if (!group.IsActive || !group.IsSubscribed)
                {
                    GlobalObject.Methods.WriteLog("电力OPC服务器连接失败，重新启动");
                    //GetStartApp();
                    return;
                }
                DateTime curdt = DateTime.Now;
                TimeSpan ts = curdt - lastupDt;
                if (ts.TotalMinutes >59)
                {
                    GlobalObject.Methods.WriteLog("持续59分钟没有获取到电量数据，重新启动");
                    //GetStartApp();
                    return;
                }
            }
            catch(Exception exc)
            {
                GlobalObject.Methods.WriteLog("电力OPC服务器连接失败，重新启动"+exc.ToString());
                //GetStartApp();
                return;
            }
            checkopc.Enabled = true;
        }
        /*
        private void GetStartApp()
        {
            Process proc = Process.Start(Application.StartupPath+"\\ReStartApp.exe");
        }
        */
        private void FlashRateProc()
        {
            /*
            StreamReader sr = null;
            while (!isExit)
            {
                sr = new StreamReader(@"D:\计量系统\电力接入软件\Data\NodeConfig.txt", Encoding.GetEncoding("GB2312"));
                string str = sr.ReadToEnd();
                int nNewer = str.LastIndexOf("电力系统配置输出");
                str = str.Substring(nNewer - 21);
                string[] strLine = str.Split('\n');
                lock (lockObj)
                {
                    dicCleintHandlerToRate.Clear();
                    for (int i = 1; i < strLine.Length; i += 2)
                    {
                        try
                        {
                            if (strLine[i].Trim() != "")
                            {
                                string strMainNode = strLine[i].Split(',')[0];
                                string strSubNode = strLine[i].Split(',')[1];
                                string newKey1 = "V" + strMainNode + "_" + strSubNode + ".expand19";
                                string newKey2 = "V" + strMainNode + "_" + strSubNode + ".P";
                                float VoltageRate = float.Parse(strLine[i].Split(',')[6]);//电压变比
                                float CurrentRate = float.Parse(strLine[i].Split(',')[7]);//电流变比
                                foreach (KeyValuePair<int, string> k in dicClientHandlerToItemName)
                                {
                                    if (k.Value == newKey1)
                                    {
                                        dicCleintHandlerToRate.Add(newKey1, new float[] { VoltageRate, CurrentRate });
                                    }
                                    else
                                    {
                                        if (k.Value == newKey2)
                                        {
                                            dicCleintHandlerToRate.Add(newKey2, new float[] { VoltageRate, CurrentRate });
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                sr.Dispose();
                sr = null;
                //StreamWriter sw = new StreamWriter("", false);
                System.Threading.Thread.Sleep(24*60*60*1000);
            }
            */

            string writeTime = "";
            //StreamReader sr = null;
            while (true)
            {
                try
                {
                    FileInfo file = new FileInfo("D:\\计量系统\\电力接入软件\\Data\\NodeConfig.txt");
                    if (!file.Exists)
                    {
                        //Console.WriteLine("文件不存在！");
                        GlobalObject.Methods.WriteLog("电力配置文件NodeConfig不存在!", true);

                    }
                    else
                    {
                        if (writeTime == "")
                        {
                            //DateTime lastAccessTime=file.LastAccessTime;
                            DateTime lastWriteTime = file.LastWriteTime;
                            writeTime = lastWriteTime.ToString();
                            GetOPCPowerConfigMessage();
                        }
                        else
                        {
                            //FileInfo file = new FileInfo("D:\\计量系统\\电力接入软件\\Data\\NodeConfig.txt");
                            DateTime lastWriteTime = file.LastWriteTime;
                            if (writeTime != lastWriteTime.ToString())
                            {
                                GetOPCPowerConfigMessage();
                                writeTime = lastWriteTime.ToString();
                            }

                        }
                    }
                }
                catch (Exception e)
                {
                    GlobalObject.Methods.WriteLog("读取电力配置文件错误："+e.Message, true);
                }
                System.Threading.Thread.Sleep(5 * 1000);
            }
            

        }

        void GetOPCPowerConfigMessage()
        {
            StreamReader sr = null;
            sr = new StreamReader(@"D:\计量系统\电力接入软件\Data\NodeConfig.txt", Encoding.GetEncoding("GB2312"));
            string str = sr.ReadToEnd();
            int nNewer = str.LastIndexOf("电力系统配置输出");
            //str = str.Substring(nNewer - 21);
            string[] strLine = str.Split('\n');
            lock (lockObj)
            {
                dicCleintHandlerToRate.Clear();
                for (int i = 1; i < strLine.Length; i += 2)
                {
                    try
                    {
                        if (strLine[i].Trim() != "")
                        {
                            string strMainNode = strLine[i].Split(',')[0];
                            string strSubNode = strLine[i].Split(',')[1];
                            string newKey1 = "V" + strMainNode + "_" + strSubNode + ".expand19";
                            string newKey2 = "V" + strMainNode + "_" + strSubNode + ".P";
                            float VoltageRate = float.Parse(strLine[i].Split(',')[6]);//电压变比
                            float CurrentRate = float.Parse(strLine[i].Split(',')[7]);//电流变比
                            foreach (KeyValuePair<int, string> k in dicClientHandlerToItemName)
                            {
                                if (k.Value == newKey1)
                                {
                                    dicCleintHandlerToRate.Add(newKey1, new float[] { VoltageRate, CurrentRate });
                                }
                                else
                                {
                                    if (k.Value == newKey2)
                                    {
                                        dicCleintHandlerToRate.Add(newKey2, new float[] { VoltageRate, CurrentRate });
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                sr.Dispose();
                sr = null;
            }
        }

        ~OPCClass()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            isExit = true;
            while ((int)(tdFlashRate.ThreadState & System.Threading.ThreadState.Stopped) != 0 &&
                (int)(tdFlashRate.ThreadState & System.Threading.ThreadState.Unstarted) != 0)
            {
                System.Threading.Thread.Sleep(100);
            }

            try
            {
                //删除Group组，组名称要与添加组时一致
                server.OPCGroups.Remove("Power");

                //断开与服务器连接
                server.Disconnect();

                checkopc.Close();
                checkopc.Dispose();

                CheckOpcPowerState.Close();
                CheckOpcPowerState.Dispose();

                tdFlashRate.Abort();
            }
            catch
            {
            }
        }

        public bool Connect(string ProgID)
        {
            server = new OPCServer();
            checkopc.Enabled = false;
            try
            {

                if (!isExistProg(ProgID))
                {
                    return false;
                }
                server.Connect(ProgID);
                server.OPCGroups.DefaultGroupIsActive = true;
                server.OPCGroups.DefaultGroupDeadband = 0;
                server.OPCGroups.DefaultGroupUpdateRate = 2000;
                group = server.OPCGroups.Add("Power");
                group.UpdateRate = 2000;
                group.IsSubscribed = true;
                group.IsActive = true;
                group.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(group_DataChange);
                CheckOpcPowerState.Enabled = true;
                return true;
                
            }
            catch
            {
                throw new Exception("OPC类型错误！");
            }
            finally
            {
                checkopc.Enabled = true;
            }
        }

        private bool isExistProg(string ProgID)
        {
            object serverAll = new object();
            serverAll = server.GetOPCServers();
            string[] strServerNames = new string[((Array)serverAll).Length];
            for (int i = 0; i < strServerNames.Length; i++)
            {
                strServerNames[i] = ((Array)serverAll).GetValue(i + 1).ToString();
            }
            foreach (string s in strServerNames)
            {
                if (s == ProgID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddItem(string[] items)
        {
            if (group != null)
            {
                OPCItems = new string[items.Length + 1];//由于数组下标从1开始，故加1
                ClientHandles = new Int32[items.Length + 1];//由于数组下标从1开始，故加1
                for (int i = 0; i < items.Length; i++)
                {
                    OPCItems.SetValue(items[i], i + 1);
                    ClientHandles.SetValue(i + 1, i + 1);
                    dicClientHandlerToItemName.Add(i + 1, items[i]);
                }

                try
                {
                    group.OPCItems.AddItems(OPCItems.Length - 1, ref OPCItems, ref ClientHandles, out ServerHandlers, out arrError);
                    tdFlashRate.Start();
                    System.Threading.Thread.Sleep(200);
                }
                catch
                {
                    return false;
                }
                return true;
            }
                
            return false;
        }

        public void Read(out Array values)
        {
            object Qualities;
            object timeStamps;
            group.SyncRead((short)OPCDataSource.OPCDevice, OPCItems.Length - 1, ref ServerHandlers, out values, out arrError, out Qualities, out timeStamps);

        }
        Hashtable hs = new Hashtable();
        private void group_DataChange(int TransactionID, int NumItems, ref System.Array ClientHandles, ref System.Array ItemValues, ref System.Array Qualities, ref System.Array TimeStamps)
        {
            /*
            //lj 20140814
            Sensors sensors = null;
            SensorModel sm = null;
            string id = "";
            */
            object ItemValue;
            string ItemName;
            float VoltageRate = 0;//电压变比
            float CurrentRate = 0;//电流变比 
            LinkedList<ResuleItem> listItem = new LinkedList<ResuleItem>();
            for (int i = 0; i < ItemValues.Length; i++)
            {
                ResuleItem result = new ResuleItem();
                ItemValue = ItemValues.GetValue(i + 1);
                ItemName = dicClientHandlerToItemName[(Int32)ClientHandles.GetValue(i + 1)];
                result.ItemName = ItemName;

                //GlobalObject.Methods.WriteLog((ItemName + "  " + "电力数据:" + ItemValue.ToString()), false);
                /*
                //lj 20140731 将接受的到电力数据写入日志文件,201408014 加入id                
                id = sensors.GetSensorID(ItemName, out sm, id);
                GlobalObject.Methods.WriteLog((result.ItemName+"("+id+")" + " 电力数据：" + ItemValue.ToString()),false);
                */

                lock (lockObj)
                {
                    try
                    {
                        VoltageRate = ((float[])dicCleintHandlerToRate[dicClientHandlerToItemName[(Int32)ClientHandles.GetValue(i + 1)]])[0];
                        CurrentRate = ((float[])dicCleintHandlerToRate[dicClientHandlerToItemName[(Int32)ClientHandles.GetValue(i + 1)]])[1];
                    }
                    catch { continue; }
                    
                    //lj20140909
                    /*
                    result.VoltageRate = VoltageRate;
                    result.CurrentRate = CurrentRate;
                    result.CurrentValue = float.Parse(ItemValue.ToString());
                    */
                    /*
                    result.PowerData.VoltageRate = VoltageRate;
                    result.PowerData.CurrentRate = CurrentRate;
                    result.PowerData.CurrentValue = float.Parse(ItemValue.ToString());
                    */
                    Worker.OPCPowerBaseData opcdata = new Worker.OPCPowerBaseData();
                    opcdata.VoltageRate = VoltageRate;
                    opcdata.CurrentRate = CurrentRate;
                    opcdata.CurrentValue = float.Parse(ItemValue.ToString());
                    result.PowerData = opcdata;
                    if (ItemName.Contains(".P"))
                    {
                        result.ItemValue = float.Parse(ItemValue.ToString()).ToString("0.0");
                    }
                    else
                    {
                        result.ItemValue = double.Parse(Convert.ToString(float.Parse(ItemValue.ToString()) * VoltageRate * CurrentRate)).ToString("0.0");
                    }
                }
                if (double.Parse(result.ItemValue.ToString()) > 0)
                {
                    if (hs.Contains(result.ItemName))
                    {
                        if (hs[result.ItemName].ToString() != result.ItemValue.ToString())
                        {
                            if (result.ItemName.Contains(".expand19"))
                            {
                                lastupDt = DateTime.Now;
                                //GlobalObject.Methods.WriteLog(result.ItemName + " 当前数值:" + result.ItemValue.ToString() + " 历史值：" + hs[result.ItemName].ToString());
                            }
                            hs[result.ItemName] = result.ItemValue.ToString();
                            listItem.AddLast(result);
                        }
                    }
                    else
                    {
                        hs.Add(result.ItemName, result.ItemValue.ToString());
                        listItem.AddLast(result);
                    }
                }
            }
            ResuleItem[] resultItems = listItem.ToArray();
            this.DataChange(this, resultItems);
        }

    }
}
