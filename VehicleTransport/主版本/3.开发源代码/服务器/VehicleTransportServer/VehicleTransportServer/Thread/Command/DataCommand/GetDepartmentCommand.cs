using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Manage;
using Common.Model.DataCommand.OutDataComand;
using Common.Model.DataCommand.InDataCommand;

namespace VehicleTransportServer.Thread.Command.DataCommand
{
    public class GetDepartmentCommand:ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetDepartmentModel indep = Common.XmlManage<InGetDepartmentModel>.XmlToModel(cmdModel.CmdModelXml);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = Convert.ToDateTime(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.LastUpdateDepartmentTable));
                }
                catch (Exception)
                {
                }
                
                if (dt != indep.LastUpdateTime)
                {
                    List<DB_VehicleTransportManage.Model.m_Department> lstMessage = new DB_VehicleTransportManage.BLL.m_Department().GetModelList("i_Flag=0");
                    OutGetDepartmentModel oModel = new OutGetDepartmentModel();
                    oModel.ListMessage = lstMessage;
                    oModel.LastUpdateTime = dt;
                    cm.CmdModelXml = Common.XmlManage<OutGetDepartmentModel>.ModelToXml(oModel);
                }
                
                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetDepartment;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取部门列表出错：" + ex.Message, null, true));
            }
        }
    }
}
