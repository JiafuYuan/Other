using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using SPcms.Web.UI;
using SPcms.Common;
using LitJson;

namespace SPcms.Web.tools
{
    /// <summary>
    /// moblie_ajax 的摘要说明
    /// </summary>
    public class moblie_ajax : IHttpHandler
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        Model.userconfig userConfig = new BLL.userconfig().loadConfig();
        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = SPRequest.GetQueryString("action");
            if (action == "")
            {
                action = SPRequest.GetFormString("action");
            }
            switch (action)
            {
                case "get_artice_list":
                    get_artice_list(context);
                    break;
               
            }
        }

     
        
        #region 获取文章列表


        private void get_artice_list(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string channel_name = SPRequest.GetQueryString("pd");
            int category_id = SPRequest.GetQueryInt("cateid");
            int page_index = SPRequest.GetQueryInt("page", 1);
            string temp = SPRequest.GetQueryString("temp");
            int _recordCount = 0;
            DataTable dt = get_article_list(channel_name, category_id, page_index, "", "", out _recordCount, null);
            int _pageSize = new SPcms.BLL.channel().GetPageSize(channel_name);

            int pageCount = (_recordCount + _pageSize - 1) / _pageSize;
            if (page_index > pageCount)
            {
                context.Response.Write("[{\"html\":\"" + sb.ToString() + "\"}]");
                return;
            }
            foreach (DataRow item in dt.Rows)
            {
                if (temp == "")
                {
                    sb.Append("<li>" + item["title"] + "</li>");
                }
                else
                {
                    temp = temp.Replace("temp_title", item["title"].ToString()).Replace("temp_url", "/mobile" + new Web.UI.BasePage().linkurl(channel_name + "_show", item["id"].ToString()));
                    temp = temp.Replace("temp_zhaiyao", item["zhaiyao"].ToString()).Replace("temp_imgurl", item["img_url"].ToString());
                    sb.Append(temp);
                }
            }

            context.Response.Write("[{\"html\":\"" + sb.ToString() + "\"}]");
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        protected DataTable get_article_list(string channel_name, int category_id, int page_index, string strwhere, string _key, out int totalcount, params object[] _params)
        {
            DataTable dt = new DataTable();
            int pagesize;

            if (!string.IsNullOrEmpty(channel_name))
            {
                dt = new BLL.article().GetList(channel_name, category_id, page_index, strwhere, "sort_id asc,add_time desc", out totalcount, out pagesize).Tables[0];

            }
            else
            {
                totalcount = 0;

            }
            return dt;
        }
    }
}