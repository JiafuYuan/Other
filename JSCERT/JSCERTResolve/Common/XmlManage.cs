using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace Common
{
    /// <summary>
    /// 实体转Xml，Xml转实体类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XmlManage<T> where T : new()
    {
        /// <summary>
        /// 对象实例转成xml
        /// </summary>
        /// <param name="item">对象实例</param>
        /// <returns></returns>
        public static string ModelToXml(T item)
        {
            XmlSerializer x = new XmlSerializer(typeof(T));
            
            MemoryStream ms = new MemoryStream();
            XmlWriter xw = new XmlTextWriter(ms, Encoding.GetEncoding("gb2312"));
            //XmlWriter xw = new XmlTextWriter(ms, Encoding.Default);
            
            x.Serialize(xw, item);

            int count = (int)ms.Length;
            byte[] arr = new byte[count];
            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(arr, 0, count);

            Encoding utf = Encoding.GetEncoding("gb2312");
            string ss= (utf.GetString(arr).Trim());
            //减少传送字符量
            ss = ss.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
            return ss;
        }

        /// <summary>
        /// Xml转成实体类
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        public static T XmlToModel(string xmlContent)
        {
            XmlSerializer xsx = new XmlSerializer(typeof(T));

            MemoryStream streamx = new MemoryStream(System.Text.Encoding.Default.GetBytes(xmlContent));
            return (T)xsx.Deserialize(streamx);
        }

    }

}
