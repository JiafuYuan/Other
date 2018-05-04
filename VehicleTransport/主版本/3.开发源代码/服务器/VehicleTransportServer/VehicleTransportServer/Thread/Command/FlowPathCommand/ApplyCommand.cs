using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using Common.Model.InCommandModel;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using Common.Model.OutCommandModel;
using Common.Model.FlowPath.InFlowPath;
using Common.Interface;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.FlowPath
{
    /// <summary>
    /// 申请处理
    /// </summary>
    public class ApplyCommand : ICommand
    {
        private DB_VehicleTransportManage.BLL.m_Plan_ApplyMaterie _applyMaterieBLL = new DB_VehicleTransportManage.BLL.m_Plan_ApplyMaterie();
        private DB_VehicleTransportManage.BLL.m_Plan_ApplyVehicle _applyVehicleBLL = new DB_VehicleTransportManage.BLL.m_Plan_ApplyVehicle();
        private DB_VehicleTransportManage.BLL.m_Apply _applyBLL = new DB_VehicleTransportManage.BLL.m_Apply();

        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                DB_VehicleTransportManage.DB.OleDbHelper.BeginTransaction();
                CommandObjectModel cm = new CommandObjectModel();
                //cmdModel.CmdModelXml="<?xml version=\"1.0\" encoding=\"gb2312\"?><InApplyModel><M_Apply><vc_PlanUse>缺省</vc_PlanUse><dt_ArriveDestinationDateTime>2014-11-17T15:24:00</dt_ArriveDestinationDateTime><dt_ApplyDateTime>2014-11-17T15:23:45</dt_ApplyDateTime><ID>0</ID><ArriveDestinationAddressID>2</ArriveDestinationAddressID><ApplyPersonID>0</ApplyPersonID><i_IsUseMaterieApply>1</i_IsUseMaterieApply><i_State>0</i_State><ApplyDepartmentID>0</ApplyDepartmentID></M_Apply><DateTime>2014-11-17T15:24:20</DateTime><ListM_Plan_ApplyMaterie><m_Plan_ApplyMaterie><vc_Memo>mm</vc_Memo><ID>0</ID><MaterieTypeID>1</MaterieTypeID><i_Flag>123</i_Flag><n_CheckCount>0</n_CheckCount><n_Count>1.0</n_Count><ApplyID>0</ApplyID></m_Plan_ApplyMaterie></ListM_Plan_ApplyMaterie><DepartmentID>0</DepartmentID><AddressID>2</AddressID><UserID>5</UserID></InApplyModel>";
                InApplyModel lg = Common.XmlManage<InApplyModel>.XmlToModel(cmdModel.CmdModelXml);
                if (lg.M_Apply.ApplyPersonID == 0)
                {
                    lg.M_Apply.ApplyPersonID = new DB_VehicleTransportManage.BLL.m_User().GetPersonID(lg.UserID);
                }
                if (lg.M_Apply.ApplyDepartmentID == 0)
                {
                    lg.M_Apply.ApplyDepartmentID = new DB_VehicleTransportManage.BLL.m_User().GetDepartmentIDByUserID(lg.UserID);
                }

                cm.Result = true;
                if (UserManage.Current.IsOnLine(lg.UserID) == true)
                {
                    if (_applyBLL.Add(lg.M_Apply) > 0)
                    {
                        lg.M_Apply = _applyBLL.GetOneNewModel();

                        if (lg.M_Apply.i_IsUseMaterieApply == Common.Enum.EnumApplyType.Materie.GetHashCode())
                        {
                            foreach (DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie item in lg.ListM_Plan_ApplyMaterie)
                            {
                                item.ApplyID = lg.M_Apply.ID;
                                if (_applyMaterieBLL.Add(item) < 0)
                                {
                                    cm.Result = false;
                                    cm.ErrorDetail = "写入申请物料信息失败";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            foreach (DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle item in lg.ListM_Plan_ApplyVehicle)
                            {
                                item.ApplyID = lg.M_Apply.ID;
                                if (_applyVehicleBLL.Add(item) < 0)
                                {
                                    cm.Result = false;
                                    cm.ErrorDetail = "写入申请车辆信息失败";
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        cm.Result = false;
                        cm.ErrorDetail = "写入申请物料信息失败";
                    }
                }
                else
                {
                    cm.Result = false;
                    cm.ErrorDetail = "用户不在线";
                }

                if (cm.Result == true)
                {
                    DB_VehicleTransportManage.DB.OleDbHelper.Commit();
                }
                else
                {
                    DB_VehicleTransportManage.DB.OleDbHelper.Rollback();
                }
                cm.CmdType = Common.Enum.EnumCommandType.Flow_Apply;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
                if (cm.Result == true) new SendRefreshCommand().DoWork();
            }
            catch (Exception ex)
            {
                DB_VehicleTransportManage.DB.OleDbHelper.Rollback();
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "申请出错：" + ex.Message + cmdModel.CmdModelXml, null, true));
            }
        }
    }
}
