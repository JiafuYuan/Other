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
using VehicleTransportClient.Com;
using System.Runtime.InteropServices;

namespace VehicleTransportClient
{
    /// <summary>
    /// 通讯管理类,客户程序
    /// </summary>
    public class SocketManage
    {
        public static readonly SocketManage instance = new SocketManage();
        private SocketClient _socketClient = null;//
        private string _ip;
        private int _port;

        private CommandResult _commandResult = new CommandResult();
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer _heatertimer = new System.Windows.Forms.Timer();
        private int _heatercount = 0;
        private bool _firstlogin = true;

        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(SystemTime st);
        [DllImport("Kernel32.dll")]
        public static extern void SetLocalTime(SystemTime st);

        [StructLayout(LayoutKind.Sequential)]
        public class SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort Whour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;

        }

        /// <summary>
        /// 数据缓存
        /// </summary>
        private List<byte> _lstByte = new List<byte>();

        private void InitSocket()
        {
            try
            {
                _socketClient = new SocketClient(Pub.ConfigModel.LocalIP);
            }
            catch
            {
                Program.procDlg.Hide();
                //Common.MessageBoxEx.MessageBoxEx.Show("请配置正确的客户端IP");
                //System.Environment.Exit(System.Environment.ExitCode);
                //return;
                UI.frmServerConfig frmconfig = new UI.frmServerConfig();
                DialogResult diaresult = frmconfig.ShowDialog();
                if (diaresult == DialogResult.OK)
                {
                    InitSocket();
                    return;
                }
                else
                {
                    Program.procDlg.Dispose();
                    System.Environment.Exit(System.Environment.ExitCode);
                    return;
                }

            }
            _socketClient.SocketReceivedData += new SocketReceivedDataEventHandler(_socketClient_SocketReceivedData);
            _socketClient.SocketConnected += new SocketEventHandler(_socketClient_SocketConnected);
            _socketClient.SocketError += new SocketErrorEventHandler(_socketClient_SocketError);
            _socketClient.SocketClosed += new SocketEventHandler(_socketClient_SocketClosed);
            bool b = _socketClient.Connect(Pub.ConfigModel.ServerIP, Pub.ConfigModel.Port, 5);
            if (b == false && _firstlogin)
            {
                Program.procDlg.Hide();
                UI.frmServerConfig frmconfig = new UI.frmServerConfig();
                DialogResult diaresult = frmconfig.ShowDialog();
                if (diaresult == DialogResult.OK)
                {
                    InitSocket();
                    return;
                }
                else
                {
                    Program.procDlg.Dispose();
                    System.Environment.Exit(System.Environment.ExitCode);
                    return;
                }
            }

        }

        void _socketClient_SocketClosed(object sender, SocketEventArgs e)
        {
            Com.WriteLog.AppendErrorLog("连接关闭");
            Pub.IsServerConnect = false;
            if (_heatertimer.Enabled == false)
            {
                InitSocket();
            }
           // _heatertimer.Enabled = true;
        }

        void _socketClient_SocketError(object sender, SocketErrorEventArgs e)
        {
            Com.WriteLog.AppendErrorLog("连接断开" + e.Error.Message);
            Pub.IsServerConnect = false;
            if (_heatertimer.Enabled == false)
            {
                //InitSocket();
            }
           // _heatertimer.Enabled = true;
        }
        public SocketManage()
        {

            InitSocket();

            _timer.Interval = 10;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Enabled = true;

            _heatertimer.Interval = 15000;
            _heatertimer.Tick += new EventHandler(_heatertimer_Tick);
        }

        void _heatertimer_Tick(object sender, EventArgs e)
        {
            _heatertimer.Enabled = false;
            try
            {
                if (_heatercount < 3)
                {
                    _heatercount = _heatercount + 1;
                    Heater();

                }
                else
                {
                    Com.WriteLog.AppendErrorLog("心跳未返回数据包,重连");
                    if (_heatercount > 100)
                    {
                        _heatercount = 3;
                    }
                    Pub.IsServerConnect = false;
                    InitSocket();
                }
            }
            catch(Exception exc)
            {
                Com.WriteLog.AppendErrorLog("心跳未返回数据包,重连"+exc.ToString());
            }
            _heatertimer.Enabled = true;
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
                    CommandObjectModel gg=null;
                    try
                    {
                        gg = XmlManage<CommandObjectModel>.XmlToModel(t1);
                        string error = gg.ErrorDetail;
                        if (!string.IsNullOrEmpty(error))
                        {
                            Pub.errorLogin = "服务器提示" + error;

                            
                        }
                        _commandResult.DoCommandResult(gg.CmdID, gg.Result);
                        if (gg.CmdType== EnumCommandType.GetFlowPath)
                        {
                            Common.Model.OutCommandModel.OutFlowPathModel fp = XmlManage<Common.Model.OutCommandModel.OutFlowPathModel>.XmlToModel(gg.CmdModelXml);
                            Pub.FlowPath = fp;
                            
                        }
                        if (gg.CmdType== EnumCommandType.GetAPKFile)
                        {
                            Common.Model.OutCommandModel.OutApkFileModel ff = new Common.Model.OutCommandModel.OutApkFileModel();
                            ff = XmlManage<Common.Model.OutCommandModel.OutApkFileModel>.XmlToModel(gg.CmdModelXml);
                        }
                        if (gg.CmdType== EnumCommandType.SendRefresh)
                        {
                            //MessageBox.Show("刷新");
                        }
                        if (gg.CmdType == EnumCommandType.HeartBeat)
                        {
                            if (gg.Result == false)
                            {
                                Com.WriteLog.AppendErrorLog("心跳返回false");
                                Pub.IsServerConnect = false;
                                if (Pub.UserId != -1)
                                {
                                    Login(Pub.UserName, Pub.Pwd);
                                }
                            }
                            else
                            {
                                Com.WriteLog.AppendErrorLog("心跳返回true");
                                Pub.IsServerConnect = true;
                                //Login(Pub.UserName, Pub.Pwd);
                            }
                        }
                        if (gg.CmdType == EnumCommandType.GetTime)
                        {
                            SystemTime st = new SystemTime();
                            DateTime dt = gg.DateTime;
                            st.wYear = (ushort)dt.Year;
                            st.wMonth = (ushort)dt.Month;
                            st.wDay = (ushort)dt.Day;
                            st.Whour = (ushort)dt.Hour;
                            st.wMinute = (ushort)dt.Minute;
                            st.wSecond = (ushort)dt.Second;
                            SetLocalTime(st);

                        }
                      
                        if(gg.CmdType==EnumCommandType.SendGisRefresh)
                        {
                            Pub.GISForm.LoadGrid();
                            Pub.GisManage.UpdataGisAndDBRemark();
                            //Pub.GISForm.Reload();
                        }
                        if (gg.CmdType == EnumCommandType.GetDBInfo)
                        {
                            Common.Model.NormalCommand.OutCommandModel.OutGetDBInfoModel dbinfo = new Common.Model.NormalCommand.OutCommandModel.OutGetDBInfoModel();
                            dbinfo = XmlManage<Common.Model.NormalCommand.OutCommandModel.OutGetDBInfoModel>.XmlToModel(gg.CmdModelXml);
                            Config.WriteDBinfo(dbinfo.DBServer, dbinfo.DBName, dbinfo.UID, dbinfo.Psw);
                        }
                        if (gg.CmdType == EnumCommandType.SendGisPointStateChanged)
                        {
                            Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel equipstate = XmlManage<Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel>.XmlToModel(gg.CmdModelXml);
                            int type=(int)equipstate.EquipmentType;
                            string str="类型"+type.ToString()+"状态变化   ID:"+equipstate.ID.ToString();
                            Com.WriteLog.AppendErrorLog(str);
                            Pub.GISForm.LoadGrid();
                            //Pub.GISForm.ChangeEquipState(equipstate.EquipmentType, equipstate.ID);
                            Pub.GisManage.UpdataGisAndDBRemark();
                        }
                        if (gg.CmdType == EnumCommandType.SendVehiclePostionChanged)
                        {
                            Common.Model.NormalCommand.OutCommandModel.OutSendVehiclePostionChangedModel car = XmlManage<Common.Model.NormalCommand.OutCommandModel.OutSendVehiclePostionChangedModel>.XmlToModel(gg.CmdModelXml);
                            string str = "车辆进入定位基站" + "基站ID" + car.DW_BaseStationID.ToString() + "   车辆的ID" + car.VehicleID.ToString();
                            Com.WriteLog.AppendErrorLog(str);
                            Pub.GisManage.UpdataGisAndDBRemark();
                            Pub.GISForm.LoadGrid();
                        }
                        if (gg.CmdType == EnumCommandType.SendPDAPostionChanged)
                        {
                            Common.Model.NormalCommand.OutCommandModel.OutSendPDAPostionChangedModel pdastate = XmlManage<Common.Model.NormalCommand.OutCommandModel.OutSendPDAPostionChangedModel>.XmlToModel(gg.CmdModelXml);
                            string str = "手机进入基站" + "WIFI基站ID" + pdastate.Wifi_BaseStationID.ToString() + "   手机的ID" + pdastate.PDAID.ToString();
                            Com.WriteLog.AppendErrorLog(str);
                            Pub.GisManage.UpdataGisAndDBRemark();
                        }
                        if (gg.CmdType == EnumCommandType.SendAlarm)
                        {
                            Com.WriteLog.AppendErrorLog("产生告警");
                            //Pub.GISForm.LoadGridAlarm();
                            Pub.GISForm.LoadGrid();
                        }
                    }
                    catch (Exception exc)
                    {
                        WriteLog.AppendErrorLog(exc.ToString()+"错误包"+t1);
                        _lstByte.Clear();
                        if (Pub.GisManage != null && Pub.GISForm!=null)
                        {
                            Pub.GisManage.UpdataGisAndDBRemark();
                            Pub.GISForm.LoadGrid();
                        }
                        _timer.Enabled = true;

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
                DateTime dt = DateTime.Now.AddMilliseconds(1000*15);
                while (DateTime.Now < dt)
                {
                    if (_commandResult.GetResponseResult(cmdModel.CmdID)== true)
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

            Pub.IsServerConnect = true;
            Com.WriteLog.AppendErrorLog("连接成功");
            System.Net.IPEndPoint ie = (System.Net.IPEndPoint)_socketClient.TcpClient.Client.LocalEndPoint;
            _port = ie.Port;
            _ip = ie.Address.ToString();
            int i = 0;
            bool b = false;
            if (Pub.UserId != -1)
            {
                while (i < 4)
                {
                    b=Login(Pub.UserName, Pub.Pwd);
                    Com.WriteLog.AppendErrorLog("登录");
                    if (b == true)
                    {
                        break;
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
                if (b == false)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("登录失败,系统即将关闭", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
            }
           // _heatertimer.Enabled=true;

        }
        /// <summary>
        /// 数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _socketClient_SocketReceivedData(object sender, SocketReceivedDataEventArgs e)
        {
            _heatercount = 0;
            _lstByte.AddRange(e.ReceivedData);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool Login(string username,string pwd)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Login;
            Common.Model.InCommandModel.InLoginModel l = new Common.Model.InCommandModel.InLoginModel()
            {
                UserName = username,
                PassWord = pwd,
                UserType= EnumUserType.PC
                  
            };
            cmd.CmdModelXml = XmlManage<Common.Model.InCommandModel.InLoginModel>.ModelToXml(l);
            cmd.DateTime = DateTime.Now;
            try
            {
                Common.Model.InCommandModel.InLoginModel c = XmlManage<Common.Model.InCommandModel.InLoginModel>.XmlToModel(cmd.CmdModelXml);
            }
            catch (Exception)
            {
                throw;
            }
            bool b = SendAndWait(cmd);
            if (b == true && _firstlogin == true)
            {
                _firstlogin = false;
                _heatertimer.Enabled = true;
                SendTime();
            }

            return b;
        }


        /// <summary>
        /// 心跳
        /// </summary>
        public void Heater()
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.HeartBeat;
            InHeartBeatModel l = new InHeartBeatModel()
            {
                UserID = Pub.UserId,
                //DateTime = DateTime.Now
            };
            cmd.CmdModelXml = XmlManage<InHeartBeatModel>.ModelToXml(l);
            cmd.DateTime = DateTime.Now;
            bool b = Send(cmd);
        }
        /// <summary>
        /// 结束告警
        /// </summary>
        public void OverAlarm()
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.EndAlarm;
            cmd.DateTime = DateTime.Now;
            bool b = SendAndWait(cmd);
        }

        /// <summary>
        /// 发送获取流程节点请求
        /// </summary>
        public bool SendGetFlow()
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.GetFlowPath;
            cmd.DateTime = DateTime.Now;
            bool b = SendAndWait(cmd);
            return b;

        }
        /// <summary>
        /// 对时命令
        /// </summary>
        public void SendTime()
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.GetTime;
            cmd.DateTime = DateTime.Now;
            bool b = Send(cmd);
        }
        /// <summary>
        /// 发送物料申请
        /// </summary>
        /// <param name="applymodel"></param>
        /// <param name="listdetail"></param>
        /// <returns></returns>
        public bool SendApplyMater(Model.m_Apply applymodel, List<Model.m_Plan_ApplyMaterie> listdetail,int personid,int addressid,DateTime dttime)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_Apply;
            Common.Model.FlowPath.InFlowPath.InApplyModel inModel = new Common.Model.FlowPath.InFlowPath.InApplyModel();
            inModel.UserID = Pub.UserId;
            inModel.M_Apply = applymodel;
            inModel.AddressID = addressid;
            inModel.PersonID = personid;
            inModel.DateTime = dttime;
            inModel.ListM_Plan_ApplyMaterie = listdetail;
            cmd.CmdModelXml = XmlManage<Common.Model.FlowPath.InFlowPath.InApplyModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            return Pub.BackServer.SendAndWait(cmd);
        }
        /// <summary>
        /// 发送车辆申请
        /// </summary>
        /// <param name="applymodel"></param>
        /// <param name="listdetail"></param>
        /// <returns></returns>
        public bool SendApplyCar(Model.m_Apply applymodel, List<Model.m_Plan_ApplyVehicle> listdetail,int personid,int addressid,DateTime dttime)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_Apply;
            Common.Model.FlowPath.InFlowPath.InApplyModel inModel = new Common.Model.FlowPath.InFlowPath.InApplyModel();
            inModel.UserID = Pub.UserId;
            inModel.M_Apply = applymodel;
            inModel.PersonID = personid;
            inModel.AddressID = addressid;
            inModel.DateTime = dttime;
            inModel.ListM_Plan_ApplyVehicle = listdetail;
            cmd.CmdModelXml = XmlManage<Common.Model.FlowPath.InFlowPath.InApplyModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            return Pub.BackServer.SendAndWait(cmd);
        }
        /// <summary>
        /// 发送审核
        /// </summary>
        /// <param name="listmsg"></param>
        /// <returns></returns>
        public bool SendCheck(Model.m_Plan planmodel,List<Model.m_Plan_ApplyMaterie> listApplyMater,List<Model.m_Plan_ApplyVehicle> listApplyCar,List<Model.m_Plan_CheckVehicle> listCheckCar,Model.m_Apply applymodel)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            
            cmd.CmdType = EnumCommandType.Flow_Check;
            Common.Model.FlowPath.InFlowPath.InCheckModel inModel = new Common.Model.FlowPath.InFlowPath.InCheckModel();
            inModel.UserID = Pub.UserId;
            if (applymodel!=null)
                inModel.ApplyModel = applymodel;
            if (listApplyMater!=null)
                inModel.ListPlan_ApplyMaterie = listApplyMater;
            if (listApplyCar!=null)
                inModel.ListPlan_ApplyVehicle = listApplyCar;
            if (listCheckCar!=null)
                inModel.ListPlan_CheckVehicle = listCheckCar;
            if (planmodel != null)
            {
                planmodel.RealGiveCarPersonID = 0;
                planmodel.RealLoadPersonID = 0;
                inModel.PlanModel = planmodel;
            }
            cmd.CmdModelXml = XmlManage<Common.Model.FlowPath.InFlowPath.InCheckModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            return Pub.BackServer.SendAndWait(cmd);
        }
        /// <summary>
        /// 发送供车
        /// </summary>
        /// <param name="list"></param>
        /// <param name="givendeptid"></param>
        /// <param name="givenaddressid"></param>
        /// <returns></returns>
        public bool SendGiven(List<Model.m_Plan_GiveVehicle> list, int givenpersonid,int givendeptid, int givenaddressid,int planid,DateTime dtgiven)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_Give;
            Common.Model.FlowPath.InFlowPath.InGiveModel inModel = new Common.Model.FlowPath.InFlowPath.InGiveModel();
            inModel.AddressID = givenaddressid;
            //inModel.DepartmentID = givendeptid;
            inModel.PersonID = givenpersonid;
            inModel.UserID = Pub.UserId;
            inModel.PlanID = planid;
            inModel.ListM_Plan_GiveVehicle = list;
            inModel.DateTime = dtgiven;
            cmd.CmdModelXml = XmlManage<Common.Model.FlowPath.InFlowPath.InGiveModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            return Pub.BackServer.SendAndWait(cmd);

        }
        /// <summary>
        /// 发送装车
        /// </summary>
        /// <param name="list"></param>
        /// <param name="addessid"></param>
        /// <param name="deptid"></param>
        /// <param name="planid"></param>
        /// <returns></returns>
        public bool SendLoad(List<Model.m_Plan_Load> list,int addessid,int personid,int deptid,int planid,DateTime dtload)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_Load;
            Common.Model.FlowPath.InFlowPath.InLoadModel inModel = new Common.Model.FlowPath.InFlowPath.InLoadModel();
            inModel.AddressID = addessid;
            //inModel.DepartmentID = deptid;
            inModel.UserID = Pub.UserId;
            inModel.PersonID = personid;
            inModel.ListM_Plan_Load = list;
            inModel.PlanID = planid;
            inModel.DateTime = dtload;
            cmd.CmdModelXml = XmlManage<Common.Model.FlowPath.InFlowPath.InLoadModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            return Pub.BackServer.SendAndWait(cmd);
        }
        /// <summary>
        /// 发送交接车
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listdetail"></param>
        /// <returns></returns>
        public bool SendHandOver(List<Model.m_Plan_Handover> list, List<Model.m_Plan_HandoverMaterie> listdetail, int personid,int addressid,DateTime dthander)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_Handover;
            Common.Model.FlowPath.InFlowPath.InHandoverModel inModel = new Common.Model.FlowPath.InFlowPath.InHandoverModel();
            inModel.UserID = Pub.UserId;
            inModel.PlanID = 0;
            inModel.PersonID = personid;
            inModel.AddressID = addressid;
            inModel.ListM_Plan_Handover = list;
            inModel.ListM_Plan_HandoverMaterie = listdetail;
            inModel.DateTime = dthander;
            cmd.CmdModelXml = XmlManage<Common.Model.FlowPath.InFlowPath.InHandoverModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            return Pub.BackServer.SendAndWait(cmd);

        }
        /// <summary>
        /// 发送卸车
        /// </summary>
        /// <param name="list"></param>
        /// <param name="planid"></param>
        /// <returns></returns>
        public bool SendUnload(List<Model.m_Plan_UnLoad> list, List<Model.m_Plan_UnLoadMaterie> listdetail, int personid,int addressid,DateTime dtunload)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_UnLoad;
            Common.Model.FlowPath.InFlowPath.InUnLoadModel inModel = new Common.Model.FlowPath.InFlowPath.InUnLoadModel();
            inModel.UserID = Pub.UserId;
            inModel.PlanID = 0;
            inModel.PersonID = personid;
            inModel.AddressID = addressid;
            inModel.ListM_Plan_UnLoad = list;
            inModel.Listm_Plan_UnLoadMaterie = listdetail;
            inModel.DateTime = dtunload;
            cmd.CmdModelXml = XmlManage<Common.Model.FlowPath.InFlowPath.InUnLoadModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            return Pub.BackServer.SendAndWait(cmd);

        }
        /// <summary>
        /// 发送还车
        /// </summary>
        /// <param name="list"></param>
        /// <param name="planid"></param>
        /// <param name="deptid"></param>
        /// <param name="addressid"></param>
        /// <returns></returns>
        public bool SendBack(List<Model.m_Plan_BackVehicle> list, int planid, int personid, int addressid,DateTime dtback)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_Back;
            Common.Model.FlowPath.InFlowPath.InBackModel inModel = new Common.Model.FlowPath.InFlowPath.InBackModel();
            inModel.UserID = Pub.UserId;
            inModel.PlanID = planid;
            inModel.PersonID = personid;
            inModel.AddressID = addressid;
            inModel.ListM_Plan_BackVehicle = list;
            inModel.DateTime =dtback;
            cmd.CmdModelXml = XmlManage<Common.Model.FlowPath.InFlowPath.InBackModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            return Pub.BackServer.SendAndWait(cmd);
        }
        /// <summary>
        /// 通知服务器地图修改
        /// </summary>
        /// <returns></returns>
        public bool SendGISChange()
        {
            CommandObjectModel cmd = new CommandObjectModel();
            Common.Model.NormalCommand.InCommandModel.InGisChanagedModel inModel = new Common.Model.NormalCommand.InCommandModel.InGisChanagedModel();
            inModel.UserID = Pub.UserId;
            cmd.CmdType = EnumCommandType.GisChanaged;
            cmd.DateTime = DateTime.Now;
            cmd.CmdModelXml = XmlManage<Common.Model.NormalCommand.InCommandModel.InGisChanagedModel>.ModelToXml(inModel);
            return Pub.BackServer.Send(cmd);
        }

        /// <summary>
        /// 获取服务器数据库连接信息
        /// </summary>
        /// <returns></returns>
        public bool SendDBinfo()
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.GetDBInfo;
            cmd.DateTime = DateTime.Now;
            return Pub.BackServer.SendAndWait(cmd);
        }

        public bool SendCarOperate(EnumFlowPathType type,int carid)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Data_GetVehicleIsCanDo;
            Common.Model.DataCommand.InDataCommand.InGetVehicleIsCanDoModel inModel = new Common.Model.DataCommand.InDataCommand.InGetVehicleIsCanDoModel();
            inModel.FlowType = type;
            inModel.VehicleID = carid;
            cmd.CmdModelXml = XmlManage<Common.Model.DataCommand.InDataCommand.InGetVehicleIsCanDoModel>.ModelToXml(inModel);
            return Pub.BackServer.SendAndWait(cmd);

        }

        public bool SendUnlogin()
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.LoginOut ;
            Common.Model.NormalCommand.InCommandModel.InLoginOutModel l = new Common.Model.NormalCommand.InCommandModel.InLoginOutModel
            {
               UserID=Pub.UserId

            };
            cmd.CmdModelXml = XmlManage<Common.Model.NormalCommand.InCommandModel.InLoginOutModel>.ModelToXml(l);
            cmd.DateTime = DateTime.Now;
            bool b = SendAndWait(cmd);
            return b;
        }
    }

}
