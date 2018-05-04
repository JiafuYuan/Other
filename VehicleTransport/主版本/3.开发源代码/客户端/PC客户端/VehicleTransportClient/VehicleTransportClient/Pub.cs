using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportClient.Com;
using Bestway.Windows.Tools;
using DB_VehicleTransportManage;
namespace VehicleTransportClient
{
    public  class Pub
    {
        /// <summary>系统配置信息</summary>
        public static ConfigModel ConfigModel;

        /// <summary>dataGridView样式</summary>
        public static StyleManager StyleManager = null;

        public static GISManage GisManage;

        public static string errorLogin = "";

        ///// <summary>GIS管理</summary>
        //public static Com.GISManage GisManage;

        ///// <summary>后台服务</summary>
        //public static BVMP.BVMP BackServer;

        public static UI.FrmGIS GISForm;

        /// <summary>
        /// 数据库是否连接上
        /// </summary>
        public static bool IsDBOnline = false;
        /// <summary>
        /// 当前用户ID
        /// </summary>

        public static int UserId = -1;
        /// <summary>GIS地图文件路径</summary>
        ///         //EXE执行文件路径
        public static readonly string APP_FILE_PATH_EXE = System.Windows.Forms.Application.StartupPath;
        public static readonly string APP_FILE_PATH_GISMAP = APP_FILE_PATH_EXE + "\\GisMap";
        public static readonly string APP_FILE_NAME_GISMAP = "map.tgf"; //"Map.TGF";
        /// <summary>GIS地图文件全名称</summary>
        public static readonly string APP_FILE_FULLNAME_GISMAP = APP_FILE_PATH_GISMAP + "\\" + APP_FILE_NAME_GISMAP;
        public static string UserName = "";
        public static string Pwd = "";

      
        /// <summary>
        /// 当前用户权限
        /// </summary>
        public static List<string> ListFunRight = new List<string>();

        public static SocketManage BackServer {get { return SocketManage.instance; } }

        public static bool IsServerConnect = false;

        public static Common.Model.OutCommandModel.OutFlowPathModel FlowPath = null;

        public  static bool IsKj602 = false;
    }
}
