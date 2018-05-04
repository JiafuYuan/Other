using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Enum;
using Common.Interface;
using VehicleTransportServer.Thread.FlowPath;
using VehicleTransportServer.Thread.Command.NormalCommand;
using VehicleTransportServer.Thread.Command.DataCommand;
using VehicleTransportServer.Thread.Command.FlowPathCommand;

namespace VehicleTransportServer.Thread.Command
{
    /// <summary>
    /// 命令处理
    /// </summary>
    public class CommandFactory
    {
        public static ICommand CreateCommand(EnumCommandType cmdType)
        {
            switch (cmdType)
            {
                case EnumCommandType.None:
                    break;
                case EnumCommandType.HeartBeat:
                    return new HeartBeatCommand();
                case EnumCommandType.Login:
                    return new LoginCommand();
                case EnumCommandType.LoginOut:
                    return new LoginOutCommand();
                case EnumCommandType.GetFlowPath:
                    return new GetFlowPathCommand();
                case EnumCommandType.GetAPKVersion:
                    return new GetAPKVersionCommand();
                case EnumCommandType.GetDBInfo:
                    return new GetDBInfoCommand();
                case EnumCommandType.GetAPKFile:
                    return new GetApkFileCommand();
                case EnumCommandType.ChangePassword:
                    return new ChangePasswordCommand();
                case EnumCommandType.GetTime:
                    return new GetTimeCommand();
                case EnumCommandType.Data_GetAddress:
                    return new GetAddressCommand();
                case EnumCommandType.Data_GetCard:
                    return new GetCardCommand();
                case EnumCommandType.Data_GetMessage:
                    return new GetMessageCommand();
                case EnumCommandType.Data_GetPerson:
                    return new GetPersonCommand();
                case EnumCommandType.Data_GetDepartment:
                    return new GetDepartmentCommand();
                case EnumCommandType.Data_GetMaterielType:
                    return new GetMaterielTypeCommand();
                case EnumCommandType.Data_GetVehicleIsCanDo:
                    return new GetVehicleIsCanDoCommand();
                case EnumCommandType.Data_GetPlanDetail:
                    return new GetPlanDetailCommand();
                case EnumCommandType.Data_GetMyPlanDetail:
                    return new GetMyPlanDetailCommand();
                case EnumCommandType.Data_GetVehicleDistributed:
                    return new GetVehicleDistributedCommand();
                case EnumCommandType.Data_GetVehicle:
                    return new GetVehicleCommand();
                case EnumCommandType.Data_GetVehicleType:
                    return new GetVehicleTypeCommand();
                case EnumCommandType.Flow_Apply:
                    return new ApplyCommand();
                case EnumCommandType.Flow_Check:
                    return new CheckCommand();
                case EnumCommandType.Flow_Give:
                    return new GiveCommand();
                case EnumCommandType.Flow_Load:
                    return new LoadCommand();
                case EnumCommandType.Flow_Handover:
                    return new HandoverCommand();
                case EnumCommandType.Flow_UnLoad:
                    return new UnLoadCommand();
                case EnumCommandType.Flow_Back:
                    return new BackCommand();
                case EnumCommandType.EndAlarm:
                    return new EndAlarmCommand();
                case EnumCommandType.GisChanaged:
                    return new GisChanagedCommand();
                case  EnumCommandType.Data_ReturnMessage:
                    return new ReturnMessageCommand();
                default:
                    break;
            }
            return null;
        }
    }
}
