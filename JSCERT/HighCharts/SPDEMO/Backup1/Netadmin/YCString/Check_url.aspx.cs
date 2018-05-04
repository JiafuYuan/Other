using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SPcms.Web.Netadmin.YCString
{
    public partial class Check_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = Request.Url.DnsSafeHost;
                //验证是否存在数据库

            }
        }
    }
}