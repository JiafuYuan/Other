using System;
using System.Collections.Generic;
using System.Text;

namespace Bestway.Windows.Program.MMS
{
    class Configure
    {
        public Configure()
        {
            _dbinfo = new Windows.Tools.ADODB.DBInfo();
            xml = null;

            LoadConfig();
        }
        private Windows.Tools.XML.XMLHelper xml=null;


        /// <summary> 开发商</summary>
        public string Developer { get; set; }

        /// <summary>开发商网址</summary>
        public string WebSite { get; set; }

        ///// <summary> 矿名</summary>
        //public string UserName { get; set; }

        /// <summary>注册码</summary>
        public string SN { get; set; }

        private Bestway.Windows.Tools.ADODB.DBInfo _dbinfo;
        /// <summary> 数据库登录信息</summary>
        public Bestway.Windows.Tools.ADODB.DBInfo DbLoginInfo 
        {
            get { return _dbinfo; }
            set
            {
                _dbinfo = value;
            }
        }

        /// <summary> 保存日志文件的天数，0表示不保存</summary>
        public int SaveLog { get; set; }



        ///<summary>SOCKET服务器IP地址</summary>
        public string SocketServerIP { get; set; }

        ///<summary>SOCKET服务器端口号</summary>
        public int SocketServerPort { get; set; }

        ///<summary>OPC服务器IP地址</summary>
        public string OpcServerIP { get; set; }

        ///<summary>OPC服务器用户名</summary>
        public string OpcServerUserName { get; set; }

        ///<summary>OPC服务器密码</summary>
        public string OpcServerPassword { get; set; }

        ///<summary>OPC类型</summary>
        public string OpcType { get; set; }

        ///<summary>OPC类型(电力部分)</summary>
        public string OpcPowerType { get; set; }

        /// <summary>保存数据的频率(秒)</summary>
        public int SaveDatabaseRate { get; set; }

        /// <summary>电力模块中基础数据文件存放路径</summary>
        public string PowerBaseRateFilePath { get; set; }

        /// <summary>灰分仪最后修改时间</summary>
        public DateTime AshContentLastWriteTime { get; set; }
        /// <summary>灰分仪保存数据频率（秒）</summary>
        public int AshContentSaveDataBaseRate { get; set; }
        /// <summary>灰分仪服务器IP</summary>
        public string AshContentServerIP { get; set; }
        /// <summary>灰分仪服务器用户名</summary>
        public string AshContentServerName { get; set; }
        /// <summary>灰分仪密码</summary>
        public string AshContentPwd { get; set; }

        public bool LoadConfig()
        {
            string xmlfilename = GlobalObject.Params.APP_FILE_PATH_EXE +"\\"+
                                 GlobalObject.Params.APP_PRODUCT_NAME+".xml";
            xml = new Windows.Tools.XML.XMLHelper(xmlfilename);


            _dbinfo.ProviderName =Bestway.Windows.Tools.ADODB.OleDbEnum.SQLSERVER;
            //_dbinfo.ProviderName = xml.GetItem("System/DB/ProviderName", "0") == "0" ? ADODB.OleDbEnum.SQLSERVER : ADODB.OleDbEnum.ACCESS;
            _dbinfo.HostID = xml.GetItem("System/DB/HostID", "172.21.2.58");
            _dbinfo.DatabaseName = xml.GetItem("System/DB/DatabaseName", "BW_MMS");
            _dbinfo.UserName = xml.GetItem("System/DB/UserName", "sa");
            _dbinfo.Password = xml.GetItem("System/DB/Password", "kj222");

  
            this.Developer = xml.GetItem("System/Developer", "南京北路自动化");// "Copyright© 2006-2018 南京北路自动化";
            this.WebSite = xml.GetItem("System/WebSite", "www.njbestway.com");
          
          
            this.SaveLog =Convert.ToInt32(xml.GetItem("System/SaveLog", "7"));
            
            this.SN = xml.GetItem("System/Register/SN","");


            //this.SocketServerIP = xml.GetItem("System/Socket/IP", "192.168.28.237");
            this.SocketServerIP = xml.GetItem("System/Socket/IP", "172.21.3.105");
            this.SocketServerPort = int.Parse(xml.GetItem("System/Socket/Port", "11235"));

            this.OpcServerIP = xml.GetItem("System/OPC/IP", "192.168.28.237");
            this.OpcServerUserName = xml.GetItem("System/OPC/UserName", "Administrator");
            this.OpcServerPassword = xml.GetItem("System/OPC/Password", "123456");
            this.OpcType = xml.GetItem("System/OPC/Type", "OPC.SimaticNET");
            this.OpcPowerType = xml.GetItem("System/OPC/OpcPowerType", "GD.OPCServer.3");
            this.OpcServerIP = xml.GetItem("System/OPC/IP", "192.168.28.237");
            this.OpcServerUserName = xml.GetItem("System/OPC/UserName", "Administrator");
            this.OpcServerPassword = xml.GetItem("System/OPC/Password", "123456");
            this.OpcType = xml.GetItem("System/OPC/Type", "OPC.SimaticNET");

            this.SaveDatabaseRate = int.Parse(xml.GetItem("System/SaveDatabaseRate", "600"));
            this.PowerBaseRateFilePath = xml.GetItem("System/OPC/PowerBaseRateFilePath", @"D:\计量系统\电力接入软件\Data\NodeConfig.txt");
            this.SaveDatabaseRate = int.Parse(xml.GetItem("System/SaveDatabaseRate", "60"));

            this.AshContentLastWriteTime = DateTime.Parse(xml.GetItem("System/AshContent/AshContentLastWriteTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            this.AshContentSaveDataBaseRate = int.Parse(xml.GetItem("System/AshContent/AshContentSaveDataBaseRate", "60"));
            this.AshContentServerIP = xml.GetItem("System/AshContent/AshContentServerIP", "172.21.2.229");
            this.AshContentServerName = xml.GetItem("System/AshContent/AshContentServerName", "test");
            this.AshContentPwd = xml.GetItem("System/AshContent/AshContentPwd", "test");

            return false;
        }

        public bool Save()
        {
            if (xml == null) return false;
 
            //xml.SetItem("System/DB/ProviderName", _dbinfo.ProviderName == ADODB.OleDbEnum.SQLSERVER ? "1" : "0");
            xml.SetItem("System/DB/HostID", _dbinfo.HostID);
            xml.SetItem("System/DB/DatabaseName", _dbinfo.DatabaseName);
            xml.SetItem("System/DB/UserName", _dbinfo.UserName);
            xml.SetItem("System/DB/Password", _dbinfo.Password);

            xml.SetItem("System/Developer", Developer);// "Copyright© 2006-2018 南京北路自动化";
            xml.SetItem("System/WebSite", WebSite);

            xml.SetItem("System/SaveLog", SaveLog.ToString());

            xml.SetItem("System/Register/SN", this.SN);

            xml.SetItem("System/Socket/IP", this.SocketServerIP);
            xml.SetItem("System/Socket/Port", this.SocketServerPort.ToString());
            xml.SetItem("System/Socket/IP",this.SocketServerIP);
             xml.SetItem("System/Socket/Port",this.SocketServerPort.ToString());

            xml.SetItem("System/OPC/IP", this.OpcServerIP);
            xml.SetItem("System/OPC/UserName", this.OpcServerUserName);
            xml.SetItem("System/OPC/Password", this.OpcServerPassword);
            xml.SetItem("System/OPC/Type", this.OpcType);
            xml.SetItem("System/OPC/OpcPowerType", this.OpcPowerType);

            xml.SetItem("System/SaveDatabaseRate", this.SaveDatabaseRate.ToString());
            xml.SetItem("System/OPC/PowerBaseRateFilePath", this.PowerBaseRateFilePath);

            SetAshContentLastWriteTime();
            xml.SetItem("System/AshContent/AshContentSaveDataBaseRate", this.AshContentSaveDataBaseRate.ToString());
            xml.SetItem("System/AshContent/AshContentServerIP",this.AshContentServerIP);
            xml.SetItem("System/AshContent/AshContentServerName", this.AshContentServerName);
            xml.SetItem("System/AshContent/AshContentPwd", this.AshContentPwd);

            xml.SetItem("System/SaveDatabaseRate", this.SaveDatabaseRate.ToString ());

            return true;
        }

        public bool SetAshContentLastWriteTime()
        {
            if (xml==null) return false;
            return xml.SetItem("System/AshContent/AshContentLastWriteTime", this.AshContentLastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
