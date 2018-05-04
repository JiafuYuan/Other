using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleTransportServer.Model
{
    public class LogMessageModel
    {
        public EnumLogType LogType { get; set; }

        public string LogText { get; set; }

        /// <summary>
        /// 发送状态
        /// </summary>
        public bool SendResult = false;

        public Common.Model.CommandObjectModel cmdModel = new Common.Model.CommandObjectModel();

        public  string GetMessageBody(bool isWriteCmdContent)
        {
            string ss= string.Format("日志类型={0},日志内容={1},发送状态={2},命令类型={3},命令时间={4},命令执行状态={5}, 失败原因={6},命令内容={7},IP={8},端口={9}",
                this.LogType,
                this.LogText,
                this.SendResult,
                cmdModel.CmdType,
                cmdModel.DateTime,
                cmdModel.Result,
                cmdModel.ErrorDetail,
                isWriteCmdContent==true?cmdModel.CmdModelXml:"",
                cmdModel.ClientIP,
                cmdModel.ClientPort
                );
            return ss;
        }
    }

    /// <summary>
    /// 日志类型
    /// </summary>
    public enum EnumLogType
    {
        Server=0,
        Receive=1,
        Send=2
    }

}
