using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command;

namespace VehicleTransportServer.Thread.BackWork
{
    /// <summary>
    /// 车辆到达区域通知，所在区域的PDA
    /// </summary>
    public class AreaNofityThread
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
                        List<DB_VehicleTransportManage.Model.m_Vehicle> lst = new DB_VehicleTransportManage.BLL.m_Vehicle().GetModelList(
                            string.Format("i_Flag=0 and i_State={0}", Common.Enum.EnumVehicleState.Using.GetHashCode()));
                        if (lst != null)
                        {
                            foreach (DB_VehicleTransportManage.Model.m_Vehicle item in lst)
                            {
                                int areaID = new DB_VehicleTransportManage.BLL.m_Address().GetAreaIDByLocalizerID(item.i_LocalizerStationID);

                                string areaName = new DB_VehicleTransportManage.BLL.m_Area().GetName(areaID);
                                string localizerIDs = new DB_VehicleTransportManage.BLL.m_Address().GetLocalizerIDsByAreaID(areaID);

                                string wifiIDs = new DB_VehicleTransportManage.BLL.m_WifiBaseStation().GetWifiIDsByLocalizerIDs(localizerIDs);

                                if (wifiIDs != "")
                                {
                                    List<DB_VehicleTransportManage.Model.m_User> lstUser = new DB_VehicleTransportManage.BLL.m_User().GetModelList("WifiBaseStationID in (" + wifiIDs + ")");
                                    if (lstUser != null)
                                    {
                                        string vehicleType = new DB_VehicleTransportManage.BLL.m_VehicleType().GetVehicleTypeName(item.VehicleTypeID.Value);

                                        List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> lstPD = new List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail>();
                                        lstPD = new DB_VehicleTransportManage.BLL.v_PlanVehicleDetail().GetModelList(
                                           string.Format("(PlanState={0} or PlanState={1} ) and vehicleID={2} order by dt_RealLoadDateTime desc"
                                           , Common.Enum.EnumPlanState.Loaded.GetHashCode(), Common.Enum.EnumPlanState.Transporting.GetHashCode(), item.ID));

                                        if (lstPD != null && lstPD.Count > 0)
                                        {
                                            string address = new DB_VehicleTransportManage.BLL.m_Address().GetAddressNameByAddressID(lstPD[0].ArriveDestinationAddressID.Value);
                                            DB_VehicleTransportManage.Model.m_Apply applyModel = new DB_VehicleTransportManage.BLL.m_Apply().GetModel(lstPD[0].ApplyID.Value);
                                            string applyDepment = "";
                                            if (applyModel!=null)
                                            {
                                                applyDepment = new DB_VehicleTransportManage.BLL.m_Department().GetNameByID(applyModel.ApplyDepartmentID.Value);
                                            }
                                            foreach (DB_VehicleTransportManage.Model.m_User itemUser in lstUser)
                                            {
                                                if (itemUser.i_State == Common.Enum.EnumUserState.OnLine.GetHashCode() && itemUser.i_IsPDA==1)
                                                {
                                                    DB_VehicleTransportManage.Model.m_Message messageModel = new DB_VehicleTransportManage.Model.m_Message();
                                                    messageModel.ToUserID = itemUser.ID;
                                                    messageModel.dt_SendDateTime = DateTime.Now;
                                                    messageModel.dt_ReceiveDateTime = Convert.ToDateTime("1900-1-1");
                                                    messageModel.i_MessageType = Common.Enum.EnumMessageType.AriveArea.GetHashCode();
                                                    messageModel.vc_Message = string.Format("您所在区域{5}有车辆进入，类型:{0}，编号:{1}，申请用车部门:{2}，目的地:{3}，到达时间{4}",
                                                        vehicleType, item.vc_Code, applyDepment, address, lstPD[0].dt_ArriveDestinationDateTime, "["+areaName+"]");

                                                    new SendMessageCommand().SendMessage(messageModel);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "区域通知消息出错：" + ex.Message, null, true));
                }

                System.Threading.Thread.Sleep(1000);
            }

        }
    }
}
