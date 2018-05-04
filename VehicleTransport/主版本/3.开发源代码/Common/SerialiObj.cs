using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Data;
namespace Common.SOCKET
{
    /// <summary>
    /// 用于序列化的
    /// </summary>
    public class SerialiObj
    {
 


        //序列化 
        public static byte[] ObjectToBytes(object obj)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, obj);
                    return ms.GetBuffer();
                }
            }
            catch(Exception exc)
            {
                string aa = exc.ToString();
                return null;
 
            }
        }
        
        //反序列化 
        public static object BytesToObject(byte[] Bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(Bytes))
                {
                    IFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(ms);
                }
            }
            catch
            {
                return null;
            }
        } 
    }
}
