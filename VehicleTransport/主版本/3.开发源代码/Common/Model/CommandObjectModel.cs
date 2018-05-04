using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model.InCommandModel;
using System.Data;


namespace Common.Model
{
    [Serializable]
    public class CommandObjectModel 
    {
        /// <summary>命令ID</summary>
        public int CmdID;

        /// <summary>命令类型</summary>
        public Enum.EnumCommandType CmdType;

        /// <summary>命令实体xml,相应的命令实体序列化而来，用于输入和返回，</summary>
        public string CmdModelXml;

        /// <summary>命令执行结果</summary>
        public bool Result { get; set; }

        /// <summary>执行时间</summary>
        public DateTime DateTime { get; set; }

        /// <summary>客户端IP</summary>
        public string ClientIP { get; set; }

        /// <summary>客户端口</summary>
        public int ClientPort { get; set; }

        /// <summary>失败原因</summary>
        public string ErrorDetail { get; set; }

    }

}
