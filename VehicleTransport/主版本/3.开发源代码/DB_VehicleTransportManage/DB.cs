using System;
using System.Collections.Generic;

using System.Text;
using Bestway.Windows.Tools.ADODB;

namespace DB_VehicleTransportManage
{
    public class DB
    {
        /// <summary>ADO数据操作</summary>
        public static OleDbHelper OleDbHelper = null;

        
        /// <summary>连接服务器/数据库</summary>
        public static bool OpenDataBase(string hostID, string databaseName, string userName, string password, ExecuteErrorEventHandler handler)
        {
            DBInfo dbInfo = new DBInfo();
            dbInfo.ProviderName = OleDbEnum.SQLSERVER;
            dbInfo.HostID = hostID;
            dbInfo.DatabaseName = databaseName;
            dbInfo.UserName = userName;
            dbInfo.Password = password;
            dbInfo.ConnectTimeout = 10;

            OleDbHelper = new OleDbHelper(dbInfo);
            OleDbHelper.ExecuteTimeOut = 10;
            OleDbHelper.ExecuteError += handler;
            return OleDbHelper.ConnState == System.Data.ConnectionState.Open;
        }
    }
}
