using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Tools
{
    public class SocketData
    {
        /// <summary>
        /// 将内容前面加4个字节内容的长度
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] CreateBytes(string text)
        {
            

            
            byte[] bytContent = System.Text.Encoding.Default.GetBytes(text );

            byte[] bytLength = BitConverter.GetBytes((Int32)bytContent.Length);
            List<byte> lstB = bytLength.ToList();

            lstB.AddRange(bytContent);
            //  lstB.AddRange(bb);
            return lstB.ToArray();
        }


        public static bool Ping(string ip)
        {

            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();

            options.DontFragment = true;

            string data = "Test Data!";

            byte[] buffer = Encoding.ASCII.GetBytes(data);

            int timeout = 1000; // Timeout 时间，单位：毫秒

            System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout, buffer, options);

            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)

                return true;

            else

                return false;

        }
    }
}
