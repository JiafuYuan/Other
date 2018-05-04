using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MessagePlatFormServer.Model
{
    public class ConfigModel
    {

        public string DBServer { get; set; }

        public string DBName { get; set; }

        public string DBUserName { get; set; }

        public string DBPassword { get; set; }

        /// <summary>
        /// 服务端口
        /// </summary>
        public int ServerPort { get; set; }


        /// <summary>
        /// 服务IP
        /// </summary>
        public string ServerIP { get; set; }
        ///// <summary>
        ///// 线程执行间隔(单位豪秒)
        ///// </summary>
        //public  int ThreadInterval = 100;

        ///// <summary>
        ///// 心跳判断间隔(单位秒)
        ///// </summary>
        //public int HeartbeatInterval = 10;

        ///// <summary>
        ///// 发送命令超时(秒)
        ///// </summary>
        //public int SendCommandTimeout = 5;

        /// <summary>
        /// 手机程序的版本号
        /// </summary>
        public string ApkVersion { get; set; }

        /// <summary>
        /// 手机程序的完整路径
        /// </summary>
        public string ApkFilePath { get; set; }

        /// <summary>
        /// 是否保存日志
        /// </summary>
        public bool IsSaveLog { get; set; }

        /// <summary>
        /// 是否隐藏心跳
        /// </summary>
        public bool IsHideBreakheat { get; set; }

        /// <summary>
        /// 是否隐藏发送的信息
        /// </summary>
        public bool IsHideSend { get; set; }

        /// <summary>
        /// 是否隐藏错误信息
        /// </summary>
        public bool IsHideError { get; set; }

        /// <summary>
        /// 记录条数
        /// </summary>
        public int LogCount { get; set; }

        /// <summary>
        /// 是否允许运行第二个
        /// </summary>
        public bool CanRunSecondServer { get; set; }
    }
}
