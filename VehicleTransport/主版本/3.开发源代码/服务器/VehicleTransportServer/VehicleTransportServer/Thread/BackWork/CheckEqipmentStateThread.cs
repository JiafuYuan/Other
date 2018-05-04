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
    /// 检查设备在线状态,车辆位置变化，线程
    /// </summary>
    public class CheckEqipmentStateThread
    {
        private DB_VehicleTransportManage.BLL.m_Address _addressBLL = new DB_VehicleTransportManage.BLL.m_Address();
        private DB_VehicleTransportManage.BLL.m_Vehicle _vehicleBLL = new DB_VehicleTransportManage.BLL.m_Vehicle();
        private SendVehiclePostionChangedCommand _sendVehiclePostionChangedCommand = new SendVehiclePostionChangedCommand();
        private SendGisPointStateChangedCommand _sendGisPointStateChangedCommand = new SendGisPointStateChangedCommand();
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


                        //车辆位置变化
                        List<DB_VehicleTransportManage.Model.m_Vehicle> lstVehicle = _vehicleBLL.GetModelList("i_LocalizerStationIDChanaged=1 ");
                        if (lstVehicle != null)
                        {


                            foreach (DB_VehicleTransportManage.Model.m_Vehicle item in lstVehicle)
                            {
                                _sendVehiclePostionChangedCommand.DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendVehiclePostionChangedModel()
                                     {
                                         DW_BaseStationID = item.i_LocalizerStationID,
                                         VehicleID = item.ID
                                     });
                                item.i_LocalizerStationIDChanaged = 0;
                                _vehicleBLL.Update(item);
                            }
                        }
                        //定位基站
                        List<DB_VehicleTransportManage.Model.m_Address> lstAddress = _addressBLL.GetModelList("i_Flag=0");
                        if (lstAddress != null)
                        {


                            foreach (DB_VehicleTransportManage.Model.m_Address item in lstAddress)
                            {
                                if (item.i_State != Convert.ToInt32(_addressBLL.IsOnLine(item.LocalizerStationID.Value)))
                                {
                                    _sendGisPointStateChangedCommand.DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                                    {
                                        EquipmentType = EnumEquipmentType.DW_BaseStation,
                                        ID = item.ID//m_AddressID
                                    });
                                    item.i_State = Convert.ToInt32(_addressBLL.IsOnLine(item.LocalizerStationID.Value));
                                    _addressBLL.Update(item);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    // WriteLog.AppendErrorLog(ex.Message);
                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "设备状态判断出错：" + ex.Message, null, true));
                }

                System.Threading.Thread.Sleep(1000);
            }

        }
    }
}
