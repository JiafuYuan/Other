using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.Model;

namespace VehicleTransportServer.BLL
{
    public class LogMessageBLL
    {
        public static LogMessageModel GetModel(Model.EnumLogType logType, string logText,Common.Model.CommandObjectModel cmd,bool sendResult)
        {
            LogMessageModel log = new LogMessageModel();
            if (cmd == null)
            {
                log.cmdModel = new Common.Model.CommandObjectModel();
            }
            else
            {
                log.cmdModel = cmd;
            }
            log.LogType = logType;
            log.LogText = logText;
            log.SendResult = sendResult;
            return log;
        }
    }
}
