using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BW.MMS.Server
{
    public static class SysConfig
    {
        /// <summary>
        /// Socket服务端IP
        /// </summary>
        private static string localIP = string.Empty;
        public static  string LocalIP
        {
            get { return SysConfig.localIP; }
            set { SysConfig.localIP = value; }
        }

        /// <summary>
        /// Socket服务端端口
        /// </summary>
        private static int localPort=int.MinValue;
        public static int LocalPort
        {
            get { return SysConfig.localPort; }
            set { SysConfig.localPort = value; }
        }

        static SysConfig()
        {
            XmlDocument doc=getConfigXML();
            SysConfig.LocalIP = doc.GetElementsByTagName("LocalIP")[0].InnerText;
            SysConfig.LocalPort =int.Parse( doc.GetElementsByTagName("LocalPort")[0].InnerText);
        }

        public static XmlDocument getConfigXML()
        {
            XmlDocument doc=new XmlDocument ();
            doc.Load("Config.xml");
            return doc;
        }
    }
}
