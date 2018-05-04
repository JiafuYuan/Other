using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bestway.Windows.Tools.XML;
using MessagePlatFormServer.Model;
using System.Windows.Forms;
using Common.Model.OutCommandModel;
using System.Net;
using VehicleTransportServer.BLL;

namespace VehicleTransportServer
{
    public class Config
    {
        public static ConfigModel GetModel()
        {


            XMLHelper xml = new XMLHelper(Application.StartupPath + "\\ServerConfig.xml");
            ConfigModel model = new ConfigModel();

            model.ServerPort = int.Parse(xml.GetItem("ServerPort", "9999"));
            //   model.ThreadInterval = int.Parse(xml.GetItem("ThreadInterval", "100"));
            //   model.SendCommandTimeout = int.Parse(xml.GetItem("SendCommandTimeout", "3"));

            model.DBServer = xml.GetItem("DBServer", ".");
            model.DBName = xml.GetItem("DBName", "BW_VehicleTransportManage");
            model.DBUserName = xml.GetItem("DBUserName", "sa");
            model.DBPassword = xml.GetItem("DBPassword", "kj222");
            model.ApkVersion = xml.GetItem("ApkVersion", "1.0.0");
            model.ApkFilePath = xml.GetItem("ApkFilePath", "C:\\test.apk");
            model.ServerIP = xml.GetItem("ServerIP", GetIP());
            model.IsSaveLog = Convert.ToBoolean(xml.GetItem("IsSaveLog", "true"));
            model.IsHideBreakheat = Convert.ToBoolean(xml.GetItem("IsHideBreakheat", "false"));
            model.IsHideError = Convert.ToBoolean(xml.GetItem("IsHideError", "false"));
            model.IsHideSend = Convert.ToBoolean(xml.GetItem("IsHideSend", "false"));
            model.LogCount = Convert.ToInt32(xml.GetItem("LogCount", "100"));
            model.CanRunSecondServer = Convert.ToBoolean(xml.GetItem("CanRunSecondServer", "false"));
            return model;
        }

        public static bool WriteModel(ConfigModel model)
        {
            XMLHelper xml = new XMLHelper(Application.StartupPath + "\\ServerConfig.xml");

            xml.SetItem("ServerPort", model.ServerPort.ToString());
            xml.SetItem("DBServer", model.DBServer);
            xml.SetItem("DBName", model.DBName);
            xml.SetItem("DBUserName", model.DBUserName);
            xml.SetItem("DBPassword", model.DBPassword);
            xml.SetItem("IsSaveLog", model.IsSaveLog.ToString());
            xml.SetItem("IsHideBreakheat", model.IsHideBreakheat.ToString());
            xml.SetItem("IsHideError", model.IsHideError.ToString());
            xml.SetItem("IsHideSend", model.IsHideSend.ToString());
            xml.SetItem("LogCount", model.LogCount.ToString());
            return true;
        }

        public static string GetIP()
        {
            IPHostEntry MyEntry = Dns.GetHostByName(Dns.GetHostName());
            IPAddress MyAddress = new IPAddress(MyEntry.AddressList[0].Address);
            return MyAddress.ToString();
          
        }

        public static void GetFlowPath()
        {

            try
            {
                int value = Convert.ToInt32(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.FlowPAth));
                
                value = value >> 8;
                Pub.FlowPathModel.Apply = true;// Convert.ToBoolean(value & 1);
                Pub.FlowPathModel.Check = true;// Convert.ToBoolean(value & 2);
                Pub.FlowPathModel.Give = Convert.ToBoolean(value & 4);
                Pub.FlowPathModel.Load = true; //Convert.ToBoolean(value & 8);
                Pub.FlowPathModel.Handover = Convert.ToBoolean(value & 16);
                Pub.FlowPathModel.UnLoad = true;// Convert.ToBoolean(value & 32);
                Pub.FlowPathModel.Back = Convert.ToBoolean(value & 64);
                //这里有四个环节是必须的，不管怎么设置都是True
            }
            catch (Exception ex)
            {

                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "读取数据库流程节点出错：" + ex.Message, null, true));
            }

        }
    }
}
