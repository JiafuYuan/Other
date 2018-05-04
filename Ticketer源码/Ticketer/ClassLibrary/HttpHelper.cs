using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;


namespace Ticketer
{
    internal class HttpHelper
    {
        #region 公共属性
        /// <summary>
        /// 获取当前服务器时间
        /// </summary>
        public DateTime ServerDateTime
        {
            get
            {
                return serverDateTime;
            }
        }

        public HttpWebRequest Request { get; set; }

        public Dictionary<string, string> RequestData { set; get; }
        public Dictionary<string, string[]> RequestArrayData { set; get; }
        #endregion


        #region 返回数据处理方法
        public JsonObject GetResponseJSON()
        {
            getResponse();
            JsonObject json = null;
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                json = new JsonObject(sr.ReadToEnd());
            }
            return json;
        }

        public Image GetResponseIMG()
        {
            getResponse();
            return new Bitmap(response.GetResponseStream());
        }

        public string GetResponseSTRING()
        {
            getResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }
        }
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="urlString"></param>
        /// <returns></returns>
        public HttpHelper(string UrlString)
        {
            this.Request = WebRequest.Create(UrlString) as HttpWebRequest;
            Request.ProtocolVersion = HttpVersion.Version10;
            Request.UserAgent = defaultUserAgent;
            Request.KeepAlive = true;
            Request.Headers.Add("DNT", "1");
        }

        #region 私有方法
        /// <summary>
        /// 提交请求获取数据
        /// </summary>
        private void getResponse()
        {
            if (Request.RequestUri.Scheme == "https")
                ServicePointManager.ServerCertificateValidationCallback = validateServerCertificate;

            Request.CookieContainer = WebCookies.GetCookies().Cookie;
            //Request.CookieContainer = new CookieContainer();
            //设置请求Cookie
            //if (WebCookies.GetCookies().Cookies != null)
            //{
            //    Request.CookieContainer.Add(WebCookies.GetCookies().Cookies);
            //}
            //设置POST参数值
            if (RequestData != null || RequestArrayData != null)
            {
                setPostRequestData();
            }
            this.response = Request.GetResponse() as HttpWebResponse;
            this.serverDateTime = response.LastModified;

            //CookieCollection cook = WebCookies.GetCookies().Cookie.GetCookies(Request.RequestUri);
            //if (WebCookies.GetCookies().Cookies == null)
            //    WebCookies.GetCookies().Cookies = new CookieCollection();
            //if (response.Cookies.Count > 0)
            //    WebCookies.GetCookies().Cookies = response.Cookies;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("服务器返回状态异常");
        }

        private void setPostRequestData()
        {
            StringBuilder sb = new StringBuilder();
            if (RequestData != null)
            {
                foreach (string key in RequestData.Keys)
                {
                    sb.AppendFormat("{0}={1}&", key, RequestData[key]);
                }
            }
            if (RequestArrayData != null)
            {
                foreach (string key in RequestArrayData.Keys)
                {
                    string[] values = RequestArrayData[key];
                    for (int i = 0; i < values.Length; i++)
                    {
                        sb.AppendFormat("{0}={1}&", key, RequestArrayData[key][i]);
                    }
                }
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
                Request.ContentType = "application/x-www-form-urlencoded";
                byte[] buff = Encoding.UTF8.GetBytes(sb.ToString());
                Request.ContentLength = buff.Length;
                using (Stream writer = Request.GetRequestStream())
                {
                    writer.Write(buff, 0, buff.Length);
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        private bool validateServerCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        #endregion

        #region 字段
        private static readonly string defaultUserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0; BOIE9;ZHCN)";

        private HttpWebResponse response;

        private DateTime serverDateTime;
        #endregion
    }

    internal class WebCookies
    {
        public static WebCookies GetCookies()
        {
            if (webCookie == null)
                webCookie = new WebCookies();
            return webCookie;
        }
        private WebCookies()
        {
        }
        public CookieCollection Cookies
        {
            set
            {
                cookies = value;
                for (int i = 0; i < cookies.Count; i++)
                {
                    cookies[i].Domain = "." + cookies[i].Domain;
                }
                count++;
            }
            get
            {
                return cookies;
            }
        }
        private CookieCollection cookies;
        private static WebCookies webCookie;
        public CookieContainer Cookie
        {
            get
            {
                return cookie;
            }
            set
            {
                cookie = value;
            }
        }
        private CookieContainer cookie = new CookieContainer();
        private int count = 1;
    }
}
