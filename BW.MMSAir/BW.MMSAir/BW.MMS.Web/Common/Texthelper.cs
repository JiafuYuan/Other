using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace BW.MMS.Web.Common
{
    public class Texthelper
    {
        #region MD5加密

        /// <summary>
        /// 获取MD5哈希值
        /// </summary>
        /// <param name="Text">字符串</param>
        /// <returns>MD5哈希值</returns>
        public static string GetMd5Hash(string Text)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(Text));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }

        /// <summary>
        /// 验证MD5哈希值
        /// </summary>
        /// <param name="Text">字符串</param>
        /// <param name="TextHash">哈希值</param>
        /// <returns>相同返回True,不同返回False</returns>
        public static bool VerifyMd5Hash(string Text, string TextHash)
        {
            string hash = GetMd5Hash(Text);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hash, TextHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// 过滤 Sql 语句字符串中的注入脚本
        /// </summary>
        /// <param name="source">传入的字符串</param>
        /// <returns>过滤后的字符串</returns>
        public static string SqlFilter(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return "";
            }
            //单引号替换成两个单引号
            source = source.Replace("'", "''");
            source = source.Replace("\"", "");
            source = source.Replace("&", "&amp");
            source = source.Replace("<", "&lt");
            source = source.Replace(">", "&gt");
            source = source.Replace("delete", "");
            source = source.Replace("update", "");
            source = source.Replace("insert", "");

            //半角封号替换为全角封号，防止多语句执行
            source = source.Replace(";", "；");

            //半角括号替换为全角括号
            source = source.Replace("(", "（");
            source = source.Replace(")", "）");

            ///////////////要用正则表达式替换，防止字母大小写得情况////////////////////

            //去除执行存储过程的命令关键字
            source = source.Replace("Exec", "");
            source = source.Replace("Execute", "");

            //去除系统存储过程或扩展存储过程关键字
            source = source.Replace("xp_", "x p_");
            source = source.Replace("sp_", "s p_");

            //防止16进制注入
            source = source.Replace("0x", "0 x");
            return source;
        }
        /// <summary>
        /// 生成样式表
        /// </summary>
        /// <param name="serverPath">图标绝对路径</param>
        /// <returns>CSS内容</returns>
        public static string GenerateCss(string serverPath)
        {
            StringBuilder sb = new StringBuilder();
            if (System.IO.Directory.Exists(serverPath))
            {
                System.IO.DirectoryInfo dic = new System.IO.DirectoryInfo(serverPath);
                foreach (System.IO.FileSystemInfo fsi in dic.GetFileSystemInfos())
                {
                    if (fsi is System.IO.FileInfo)
                    {
                        string name = fsi.Name.Remove(fsi.Name.LastIndexOf('.'));
                        sb.Append("\n");
                        sb.Append(".icon-" + name + " {");
                        sb.Append("\n");
                        sb.AppendFormat("    background: url('{0}') no-repeat center center;", fsi.Name);
                        sb.Append("\n");
                        sb.Append("}");
                    }
                }
            }
            return sb.ToString();
        }
    }
}