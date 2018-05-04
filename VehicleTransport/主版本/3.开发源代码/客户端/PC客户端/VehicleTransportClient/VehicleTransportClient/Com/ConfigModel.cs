using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Tools;

namespace VehicleTransportClient.Com
{
    public class ConfigModel
    {

        public string DBServer { get; set; }

        public string DBName { get; set; }

        public string DBUserName { get; set; }

        public string DBPassword { get; set; }


        /// <summary>
        /// 开发者，如北路公司
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// 软件ID 如1001
        /// </summary>
        public short SoftID { get; set; }

        /// <summary>
        /// 软件名称  如KTK113 矿山安全数字广播系统
        /// </summary>
        public string SoftName { get; set; }

        /// <summary>
        /// 客户名称 如XXX煤矿公司
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// SN号 如00000-11111-22222-33333-44444
        /// </summary>
        public string SerialNum { get; set; }

        /// <summary>
        /// 告警距离米
        /// </summary>
        public int AlarmDistance { get; set; }

        /// <summary>
        /// 本地IP
        /// </summary>
        public string  LocalIP { get; set; }

        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerIP { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }


        public int MapY { get; set; }
    }
}
