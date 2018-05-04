using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using Common.Model.FlowPath.InFlowPath;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command.NormalCommand;
using Common.Enum;

namespace VehicleTransportServer.Thread.Command.FlowPathCommand
{
    /// <summary>
    /// 审核
    /// </summary>
    public class CheckCommand : ICommand
    {
        private DB_VehicleTransportManage.BLL.m_Plan _planBLL = new DB_VehicleTransportManage.BLL.m_Plan();
        private DB_VehicleTransportManage.BLL.m_Apply _applyBLL = new DB_VehicleTransportManage.BLL.m_Apply();
        private DB_VehicleTransportManage.BLL.m_Plan_ApplyMaterie _plan_ApplyMaterieBLL = new DB_VehicleTransportManage.BLL.m_Plan_ApplyMaterie();
        private DB_VehicleTransportManage.BLL.m_Plan_ApplyVehicle _plan_ApplyVehicleBLL = new DB_VehicleTransportManage.BLL.m_Plan_ApplyVehicle();
        private DB_VehicleTransportManage.BLL.m_Plan_CheckVehicle _plan_CheckVeihcleBLL = new DB_VehicleTransportManage.BLL.m_Plan_CheckVehicle();

        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                DB_VehicleTransportManage.DB.OleDbHelper.BeginTransaction();
                CommandObjectModel cm = new CommandObjectModel();
                InCheckModel lg = Common.XmlManage<InCheckModel>.XmlToModel(cmdModel.CmdModelXml);

                cm.Result = true;

                if (UserManage.Current.IsOnLine(lg.UserID) == true)
                {
                    // lg.PersonID
                    if (_applyBLL.Update(lg.ApplyModel) == true)
                    {
                        if (lg.ApplyModel.i_State != Common.Enum.EnumApplyState.NoPass.GetHashCode())
                        {
                            int planID = _planBLL.Add(lg.PlanModel);
                            if (planID > 0)
                            {
                                lg.PlanModel.ID = planID;

                                #region do


                                if (lg.ApplyModel.i_IsUseMaterieApply == 1)
                                {
                                    foreach (DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie item in lg.ListPlan_ApplyMaterie)
                                    {
                                        if (_plan_ApplyMaterieBLL.Update(item) == false)
                                        {
                                            cm.Result = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle item in lg.ListPlan_ApplyVehicle)
                                    {
                                        if (_plan_ApplyVehicleBLL.Update(item) == false)
                                        {
                                            cm.Result = false;
                                            break;
                                        }
                                    }
                                }
                                if (cm.Result == true)
                                {
                                    foreach (DB_VehicleTransportManage.Model.m_Plan_CheckVehicle item in lg.ListPlan_CheckVehicle)
                                    {
                                        item.PlanID = lg.PlanModel.ID;
                                        if (_plan_CheckVeihcleBLL.Add(item) <= 0)
                                        {
                                            cm.Result = false;
                                            break;
                                        }
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                cm.Result = false;
                                cm.ErrorDetail = "创建新计划失败";
                            }
                        }
                    }
                    else
                    {
                        cm.Result = false;
                        cm.ErrorDetail = "更新申请信息失败";
                    }
                }
                else
                {
                    cm.Result = false;
                    cm.ErrorDetail = "用户不在线";
                }

                if (cm.Result == false)
                {
                    DB_VehicleTransportManage.DB.OleDbHelper.Rollback();
                }
                else
                {
                    DB_VehicleTransportManage.DB.OleDbHelper.Commit();
                    List<int> lst = new List<int>();
                    if (lg.PlanModel != null)
                    {
                        lst = GetIds(lg.PlanModel.vc_PDAUserIDs);
                    }
                    int applyUserID = new DB_VehicleTransportManage.BLL.m_User().GetUserIDByPersonID(lg.ApplyModel.ApplyPersonID.Value);
                    if (lg.ApplyModel.i_State == Common.Enum.EnumApplyState.Checked.GetHashCode())
                    {
                        //if (lg.UserID != applyUserID)
                        //{
                            SendNotify(lg.PlanModel.ID, lg.UserID, applyUserID, "申请通过：运单号" + lg.PlanModel.vc_PlanCode);
                       // }
                        foreach (int item in lst)
                        {
                            SendNotify(lg.PlanModel.ID, lg.UserID, item, "申请通过：运单号" + lg.PlanModel.vc_PlanCode);
                        }
                    }
                    else if (lg.ApplyModel.i_State == Common.Enum.EnumApplyState.NoPass.GetHashCode())
                    {
                        string applyPersonName = new DB_VehicleTransportManage.BLL.m_Person().GetName(lg.ApplyModel.ApplyPersonID.Value);
                        string applyArrive = new DB_VehicleTransportManage.BLL.m_Address().GetAddressNameByAddressID(lg.ApplyModel.ArriveDestinationAddressID.Value);
                        //只通知申请人
                        string mms = string.Format("申请审核不通过:申请人:{0}，申请到达目的地:{1},申请到达时间:{2},驳回理由:{3}",
                           applyPersonName, applyArrive, lg.ApplyModel.dt_ArriveDestinationDateTime, lg.ApplyModel.vc_remark);
                        SendNotify(0, lg.UserID, applyUserID,mms);
                    }
                    else if (lg.ApplyModel.i_State == Common.Enum.EnumApplyState.CheckPart.GetHashCode())
                    {
                        //if (lg.UserID != applyUserID)
                        //{
                            SendNotify(lg.PlanModel.ID, lg.UserID, applyUserID, "申请部分通过：运单号" + lg.PlanModel.vc_PlanCode);
                        //}
                        foreach (int item in lst)
                        {
                            SendNotify(lg.PlanModel.ID, lg.UserID, item, "申请部分通过：运单号" + lg.PlanModel.vc_PlanCode);
                        }
                    }
                }

                cm.CmdType = Common.Enum.EnumCommandType.Flow_Check;
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
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "审核出错：" + ex.Message + cmdModel.CmdModelXml, null, true));
            }
        }

        /// <summary>
        /// 没用
        /// </summary>
        /// <param name="planModel"></param>
        /// <returns></returns>
        private string GetMessageBody(DB_VehicleTransportManage.Model.m_Plan planModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("运单号:" + planModel.vc_PlanCode);
            DB_VehicleTransportManage.Model.m_Apply applyModel = new DB_VehicleTransportManage.BLL.m_Apply().GetModel(planModel.ApplyID.Value);
            if (applyModel!=null)
            {
                sb.Append("申请时间："+applyModel.dt_ApplyDateTime+"申请部门:"+new DB_VehicleTransportManage.BLL.m_Department().GetNameByID( applyModel.ApplyDepartmentID.Value));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 取ID列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<int> GetIds(string ids)
        {
            List<int> lst = new List<int>();
           string[] arrS= System.Text.RegularExpressions.Regex.Split(ids, ",");
           foreach (string item in arrS)
           {
               lst.Add(int.Parse(item));
           }
           return lst;
        }

        /// <summary>
        /// 通知相关PDA
        /// </summary>
        private void SendNotify(int planid, int fromUserID, int toUserID, string msg)
        {
            DB_VehicleTransportManage.Model.m_Message model = new DB_VehicleTransportManage.Model.m_Message();
            model.PlanID = planid;
            model.FromUserID = fromUserID;
            model.ToUserID = toUserID;
            model.vc_Message = msg;//"申请单完成审查";
            model.dt_SendDateTime = DateTime.Now;
            model.dt_ReceiveDateTime = Convert.ToDateTime("1900-1-1");
            model.i_MessageType = (int)EnumMessageType.CheckResul;
            model.vc_Memo = "";
            model.i_Flag = 0;
            model.i_State = 0;
            new SendMessageCommand().SendMessage(model);
        }
    }
}
