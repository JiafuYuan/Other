using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagePlatFormServer.Model;
using Common.Model.InCommandModel;
using Common.Model;
using VehicleTransportServer.Model;
using Common.Model.OutCommandModel;
using Microsoft.Win32;

namespace VehicleTransportServer
{
    public class Pub
    {
        /// <summary>
        /// 系统配置信息
        /// </summary>
        public static ConfigModel ConfigModel;

        public static bool _isDBOnline = false;

        public static int SocketCount = 0;

      //  public static int DataCount = 0;
        public static MainServer _ms = null;
        #region 命令列表
        
        // <summary>
        // 登录命令列表
        // </summary>
        //public static Queue<CommandObjectModel> LoginList = new Queue<CommandObjectModel>();

        // <summary>
        // 心跳命令列表
        // </summary>
        //public static Queue<CommandObjectModel> HearbeatList = new Queue<CommandObjectModel>();

        // <summary>
        // 取流程节点命令列表
        // </summary>
        //public static Queue<CommandObjectModel> GetFlowPathList = new Queue<CommandObjectModel>();

        // <summary>
        // 取APK版本命令列表
        // </summary>
        //public static Queue<CommandObjectModel> GetApkVersionList = new Queue<CommandObjectModel>();

        // <summary>
        // 取APK文件命令列表
        // </summary>
        //public static Queue<CommandObjectModel> GetApkFileList = new Queue<CommandObjectModel>();

        // <summary>
        // 取时间命令列表
        // </summary>
        //public static Queue<CommandObjectModel> GetTimeList = new Queue<CommandObjectModel>();

        #endregion
 

        #region Data
        ///// <summary>
        ///// 发送消息命令列表
        ///// </summary>
        //public static Queue<CommandObjectModel> SendMessageList = new Queue<CommandObjectModel>();

        ///// <summary>
        ///// 接收消息命令列表
        ///// </summary>
        //public static Queue<CommandObjectModel> GetMessageList = new Queue<CommandObjectModel>();

        #endregion

        #region FlowPath
        ///// <summary>
        ///// 申请命令列表
        ///// </summary>
        //public static Queue<CommandObjectModel> ApplyList = new Queue<CommandObjectModel>();

        ///// <summary>
        ///// 供车命令列表
        ///// </summary>
        //public static Queue<CommandObjectModel> GiveList = new Queue<CommandObjectModel>();

        ///// <summary>
        ///// 装车命令列表
        ///// </summary>
        //public static Queue<CommandObjectModel> LoadList = new Queue<CommandObjectModel>();

        ///// <summary>
        ///// 交接车命令列表
        ///// </summary>
        //public static Queue<CommandObjectModel> HandoverList = new Queue<CommandObjectModel>();

        ///// <summary>
        ///// 卸车命令列表
        ///// </summary>
        //public static Queue<CommandObjectModel> UnLoadList = new Queue<CommandObjectModel>();

        ///// <summary>
        ///// 还车命令列表
        ///// </summary>
        //public static Queue<CommandObjectModel> BackList = new Queue<CommandObjectModel>();
        #endregion

        /// <summary>
        ///  命令执行日志
        /// </summary>
        public static Queue<LogMessageModel> CommandLogList = new Queue<LogMessageModel>();

        /// <summary>
        /// 流程配置
        /// </summary>
        public static OutFlowPathModel FlowPathModel = new OutFlowPathModel();

        /// <summary>
        /// 取注册表信息并删除
        /// </summary>
        /// <param name="rr"></param>
        public static string GetRegValue(string key)
        {
            

            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey run = hklm.CreateSubKey(@"SOFTWARE\BestwaySoft\VehicleTransportManage");

                string rr = "";
                rr = run.GetValue(key).ToString();

                run.SetValue(key, "");

                hklm.Close();
                return rr;
            }
            catch (Exception my)
            {
                return "";
            }
        }

        
    }


}
