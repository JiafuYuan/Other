using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mail_Test.Mail;

namespace Mail_Test
{

    public static class Config
    {

        public static EmailType TestEmailType = EmailType.Mail_163;
        /// <summary>
        /// 测试发送地址
        /// </summary>
        public static string TestFromAddress = "yuanjiafu2008@163.com";
        public static string TestUserName = "yuanjiafu2008";
        public static string TestPassword = "hale870424163";

        /// <summary>
        /// 测试收件地址  
        /// </summary>
        public static string TestToAddress = "";

        private static Dictionary<string, string> m_dicNameMap = null;
        /// <summary>
        /// 用于获取显示名称
        /// </summary>
        private static Dictionary<string, string> DicNameMap
        {
            get
            {
                if (m_dicNameMap == null)
                {
                    m_dicNameMap = new Dictionary<string, string>();
                    m_dicNameMap.Add(TestFromAddress, "滴答的雨");
                    m_dicNameMap.Add(TestToAddress, "heyuquan");
                }
                return m_dicNameMap;
            }
        }

        /// <summary>
        /// 获取邮件地址对应的显示名称
        /// </summary>
        /// <param name="address">邮件地址</param>
        /// <returns>邮件显示名称</returns>
        public static string GetAddressName(string address)
        {
            if (DicNameMap.ContainsKey(address))
                return DicNameMap[address];
            else
                return String.Empty;
        }


    }
}
