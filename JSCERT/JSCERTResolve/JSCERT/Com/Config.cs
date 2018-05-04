using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bestway.Windows.Tools.XML;
using System.Windows.Forms;
using JSCERT;


namespace VehicleTransportClient.Com
{
    public class Config
    {
        public static ConfigModel GetModel()
        {
            XMLHelper xml = new XMLHelper(Application.StartupPath+ "\\Config.xml");
            ConfigModel model = new ConfigModel();


            model.DBServer = xml.GetItem("DBServer", @"JIAFUYUAN\sqlserver2008");
            model.DBName = xml.GetItem("DBName", "Cert");
            model.DBUserName = xml.GetItem("DBUserName", "sa");
            model.DBPassword = xml.GetItem("DBPassword", "kj222");
            model.Tick = Convert.ToInt16(xml.GetItem("Tick", "60"));
            model.KeepRecordNumber = Convert.ToInt16(xml.GetItem("KeepRecordNumber", "10000"));
            model.Developer = xml.GetItem("Developer", "南京首屏商擎网络技术有限公司");
            model.SoftID = Convert.ToInt16(xml.GetItem("SoftID", "1016"));
            model.SoftName = xml.GetItem("SoftName", "应急中心数据处理工具");
            model.UserName = xml.GetItem("UserName", "");
            model.SerialNum = xml.GetItem("SerialNum", "00000-00000-00000-00000-00000");
            model.ExcelFolder = xml.GetItem("ExcelFolder", @"E:\快盘\Work\JSCERT\图表\Excel");
            

            //model.AlarmDistance = Convert.ToInt16(xml.GetItem("AlarmDistance", "100"));

            model.LocalIP = xml.GetItem("LocalIP", "127.0.0.1");
            Int16 iPort = 8010;
            model.Port = Int16.TryParse(xml.GetItem("Port", "8010"), out iPort) ? iPort : 8010;
            model.MapY = Convert.ToInt16(xml.GetItem("MapY", "100"));
            model.ServerIP = xml.GetItem("ServerIP", "172.21.2.67");
            return model;
        }
        public static bool WriteModel(ConfigModel model)
        {
            XMLHelper xml = new XMLHelper(Application.StartupPath + "\\Config.xml");
    
            //xml.SetItem("DBServer", model.DBServer);
            //xml.SetItem("DBName", model.DBName);
            //xml.SetItem("DBUserName", model.DBUserName);
            //xml.SetItem("DBPassword", model.DBPassword);


            xml.SetItem("Developer", model.Developer);
            xml.SetItem("SoftID", model.SoftID.ToString());
            xml.SetItem("SoftName",model.SoftName);
            xml.SetItem("UserName", model.UserName);
            xml.SetItem("SerialNum", model.SerialNum);
            //xml.SetItem("AlarmDistance", model.AlarmDistance.ToString());
            xml.SetItem("LocalIP", model.LocalIP.ToString());
            xml.SetItem("Port", model.Port.ToString());
            xml.SetItem("ServerIP", model.ServerIP.ToString());
            xml.SetItem("MapY", model.MapY.ToString());
            xml.SetItem("Tick", model.Tick.ToString());
            xml.SetItem("KeepRecordNumber", model.KeepRecordNumber.ToString());
            xml.SetItem("ExcelFolder", model.ExcelFolder);
            return true;
        }
        public static void WriteDBinfo(string dbserver,string dbname,string username,string pwd)
        {
            //XMLHelper xml = new XMLHelper(Application.StartupPath + "\\Config.xml");
            //xml.SetItem("DBServer", dbserver);
            //xml.SetItem("DBName", dbname);
            //xml.SetItem("DBUserName", username);
            //xml.SetItem("DBPassword", pwd);
            Pub.ConfigModel.DBName = dbname;
            Pub.ConfigModel.DBServer = dbserver;
            Pub.ConfigModel.DBUserName = username;
            Pub.ConfigModel.DBPassword = pwd;
        }


      
    }
}
