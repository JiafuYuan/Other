using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagePlatFormServer.Model;
using Common.Enum;
using DB_VehicleTransportManage.Model;

namespace VehicleTransportServer
{
    public class SystemLog
    {
        static DB_VehicleTransportManage.Model.m_SystemLog _model = new m_SystemLog();
        static DB_VehicleTransportManage.BLL.m_SystemLog bllSystemLog = new DB_VehicleTransportManage.BLL.m_SystemLog();
        public static void WriteLog(int userId, EnumActionType enumActionType, string title, string description, string memo)
        {
            _model.UserID = userId;
            _model.i_ActionType = (int)enumActionType;
            _model.vc_Title = title;
            _model.vc_Description = description;
            _model.vc_Memo = memo;
            _model.dt_DateTime = DateTime.Now;
            bllSystemLog.Add(_model);
        }
    }
}
