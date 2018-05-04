using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Model.InCommandModel;
using Common.Enum;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command.NormalCommand;


namespace VehicleTransportServer.Manage
{
    public class UserManage
    {
        public static UserManage Current { get { return _instance; } }

        private static readonly UserManage _instance = new UserManage();
        private Timer _timer = new Timer();
        private List<DB_VehicleTransportManage.Model.m_User> _lstUser = new List<DB_VehicleTransportManage.Model.m_User>();
        private DB_VehicleTransportManage.BLL.m_User _userBLL = new DB_VehicleTransportManage.BLL.m_User();
        private DB_VehicleTransportManage.BLL.m_PDA _pdaBLL = new DB_VehicleTransportManage.BLL.m_PDA();

        private UserManage()
        {
            _timer.Interval = 1000 * 5;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Enabled = false  ;
            _timer_Tick(null, null);
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            try
            {
                if (Pub._isDBOnline == true)
                {
                    _lstUser = _userBLL.GetModelList("i_Flag=0");

                    for (int i = 0; i < _lstUser.Count; i++)
                    {
                        if (Pub._isDBOnline == false) break;
                
                        if (_lstUser[i].dt_LastActiveDateTime.AddSeconds(32) < DateTime.Now)
                        {
                            //状态有变化时更新
                            if (_lstUser[i].i_State != EnumUserState.OffLine.GetHashCode())
                            {
                                _lstUser[i].i_State = EnumUserState.OffLine.GetHashCode();
                                if (_lstUser[i].PdaID != null)
                                {
                                    DB_VehicleTransportManage.Model.m_PDA pdaModel = new DB_VehicleTransportManage.BLL.m_PDA().GetModel(_lstUser[i].PdaID.Value);
                                    if (pdaModel != null)
                                    {
                                        pdaModel.i_State = Common.Enum.EnumPDAState.OffLine.GetHashCode();
                                        new DB_VehicleTransportManage.BLL.m_PDA().Update(pdaModel);
                                    }
                                }
                                if (Pub._isDBOnline)
                                {
                                    _userBLL.Update(_lstUser[i]);    
                                }
                                
                                if (_lstUser[i].i_IsPDA == EnumUserType.PDA.GetHashCode() && _lstUser[i].PdaID > 0)
                                {
                                    new SendGisPointStateChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                                    {
                                        EquipmentType = EnumEquipmentType.PDA,
                                        ID = _lstUser[i].PdaID.Value
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "用户在线判断出错：" + ex.Message , null, true));
            }
            _timer.Enabled = true;
        }

        /// <summary>
        /// 处理心跳
        /// </summary>
        /// <param name="heartBeatModel"></param>
        /// <returns></returns>
        public bool HeartBeat(InHeartBeatModel heartBeatModel,string ip,int port)
        {
            List<DB_VehicleTransportManage.Model.m_User> lstUser = _userBLL.GetModelList("i_State=1 and i_Flag=0 and ID=" + heartBeatModel.UserID);
            if (lstUser != null && lstUser.Count > 0)
            {
                lstUser[0].dt_LastActiveDateTime = DateTime.Now;
                lstUser[0].vc_IP = ip;
                lstUser[0].i_Port = port;
                if (lstUser[0].i_IsPDA == EnumUserType.PDA.GetHashCode())
                {
                    DB_VehicleTransportManage.Model.m_PDA pdaModel = new DB_VehicleTransportManage.BLL.m_PDA().GetModelByMac(heartBeatModel.PDAMac);
                    if (pdaModel != null)
                    {
                        lstUser[0].PdaID = pdaModel.ID;

                        pdaModel.i_State = EnumPDAState.OnLine.GetHashCode();
                        _pdaBLL.Update(pdaModel);
                        new SendGisPointStateChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                        {
                            EquipmentType = EnumEquipmentType.PDA,
                            ID = pdaModel.ID
                        });
                    }
                    else
                    {
                        lstUser[0].PdaID = 0;
                    }

                    DB_VehicleTransportManage.Model.m_WifiBaseStation wifiModel = new DB_VehicleTransportManage.BLL.m_WifiBaseStation().GetModelByMac(heartBeatModel.WifiBaseStationMac);
                    if (wifiModel != null)
                    {
                        //PDA位置，要测试下

                        lstUser[0].WifiBaseStationID = wifiModel.ID;
                        new SendPDAPostionChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendPDAPostionChangedModel()
                        {
                             PDAID=lstUser[0].PdaID.Value,
                             Wifi_BaseStationID = lstUser[0].WifiBaseStationID.Value
                        });
                    }
                    else
                    {
                        lstUser[0].WifiBaseStationID = 0;
                    }

                }
                _userBLL.Update(lstUser[0]);


                return true;
            }
            else
            {
                return false;
                
            }
        }

        /// <summary>
        /// 得到在线用户列表
        /// </summary>
        /// <returns></returns>
        public List<DB_VehicleTransportManage.Model.m_User> GetUserList()
        {
            try
            {
                return _userBLL.GetModelList("i_Flag=0 and i_State=1");
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 是否在线
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool IsOnLine(int userID)
        {
            DB_VehicleTransportManage.Model.m_User userModel = _userBLL.GetModel(userID);
            if (userModel!=null &&  userModel.i_State==Common.Enum.EnumUserState.OnLine.GetHashCode())
            {
                return true;
            }
            return false;
        }
    }
}
