using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.BLL;
using Common.Enum;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread
{
    /// <summary>
    /// Wifi基站在线状态线程
    /// </summary>
    public class WifiBaseStationStateThread
    {
        private System.Threading.ManualResetEvent _mEvent = new System.Threading.ManualResetEvent(true);

        //判断线程安全退出的信号量             
        private System.Threading.ManualResetEvent _mEventStopAll = new System.Threading.ManualResetEvent(false);

        public void Start()
        {
            new System.Threading.Thread(DoWork).Start();
        }

        public void Stop()
        {
            _mEventStopAll.Set();
        }


        private void DoWork()
        {
            while (_mEvent.WaitOne() == true)
            {
                //判断线程安全退出             
                if (_mEventStopAll.WaitOne(10, false) == true) break;

                try
                {
                    if (Pub._isDBOnline == true)
                    {
                        List<DB_VehicleTransportManage.Model.m_WifiBaseStation> lst = new DB_VehicleTransportManage.BLL.m_WifiBaseStation().GetModelList("i_Flag=0");
                        if (lst != null)
                        {
                            foreach (DB_VehicleTransportManage.Model.m_WifiBaseStation item in lst)
                            {
                                if (Common.Tools.SocketData.Ping(item.vc_IPAddress))
                                {
                                    if (item.i_State != EnumWifiStationStateType.OnLine.GetHashCode())
                                    {
                                        item.i_State = EnumWifiStationStateType.OnLine.GetHashCode();
                                        new DB_VehicleTransportManage.BLL.m_WifiBaseStation().Update(item);
                                        new SendGisPointStateChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                                        {
                                            EquipmentType = EnumEquipmentType.Wifi_BaseStation,
                                            ID = item.ID
                                        });
                                    }
                                }
                                else
                                {
                                    if (item.i_State != EnumWifiStationStateType.OffLine.GetHashCode())
                                    {
                                        item.i_State = EnumWifiStationStateType.OffLine.GetHashCode();
                                        new DB_VehicleTransportManage.BLL.m_WifiBaseStation().Update(item);
                                        new SendGisPointStateChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                                        {
                                            EquipmentType = EnumEquipmentType.Wifi_BaseStation,
                                            ID = item.ID
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // WriteLog.AppendErrorLog(ex.Message);
                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "WIFI基站状态判断出错：" + ex.Message, null, true));
                }

                System.Threading.Thread.Sleep(1000);
            }

        }
    }
}
