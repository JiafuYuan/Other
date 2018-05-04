using System;
using System.Text;
using System.Data;
using System.Web;
using SPcms.Common;

namespace SPcms.Web.Plugin.Flink
{
    public class Flink_js : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string code = SPRequest.GetQueryString("id");

            //获得广告位的ID
            if (code=="")
            {
                context.Response.Write("document.write('错误提示，请勿提交非法字符！');");
                return;
            }

            //=================根据code,输出代码======================

            SPcms.Model.siteconfig siteConfig = new SPcms.BLL.siteconfig().loadConfig();
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
