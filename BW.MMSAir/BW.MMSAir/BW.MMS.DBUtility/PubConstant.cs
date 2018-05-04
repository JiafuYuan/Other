using System;
using System.Configuration;

namespace BW.MMS.DBUtility
{

    public class PubConstant
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                return _connectionString;
            }
        }

        public static string ConnectionStringGH_LOG
        {
            get
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["connectionString_GH_LOG"].ConnectionString;
                return _connectionString;
            }
        }

        public static string ConnectionStringGH_IMS
        {
            get
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["connectionString_GH_IMS"].ConnectionString;
                return _connectionString;
            }
        }
        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            return connectionString;
        }


    }
}
