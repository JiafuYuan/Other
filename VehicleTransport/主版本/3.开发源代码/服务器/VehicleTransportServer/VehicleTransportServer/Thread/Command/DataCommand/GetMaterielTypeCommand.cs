using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using Common.Model.DataCommand.OutDataComand;
using Common.Model.DataCommand.InDataCommand;

namespace VehicleTransportServer.Thread.Command.DataCommand
{
    public class GetMaterielTypeCommand:ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetMaterielTypeModel indep = Common.XmlManage<InGetMaterielTypeModel>.XmlToModel(cmdModel.CmdModelXml);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = Convert.ToDateTime(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.LastUpdateMaterielTypeTable));
                }
                catch (Exception)
                {
                }

                
                 if (dt != indep.LastUpdateTime)
                 {
                     List<DB_VehicleTransportManage.Model.m_MaterielType> lstMessage = new DB_VehicleTransportManage.BLL.m_MaterielType().GetModelList("i_Flag=0");
                     OutGetMaterielTypeModel oModel = new OutGetMaterielTypeModel();
                     oModel.ListM_MaterielType = lstMessage;
                     oModel.LastUpdateTime = indep.LastUpdateTime;
                     cm.CmdModelXml = Common.XmlManage<OutGetMaterielTypeModel>.ModelToXml(oModel);
                 }
                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetMaterielType;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取物料类型列表出错：" + ex.Message, null, true));
            }
        }
    }
}
