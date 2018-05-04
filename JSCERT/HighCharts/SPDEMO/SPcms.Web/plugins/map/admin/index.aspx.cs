using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SPcms.Common;

namespace SPcms.Web.Plugin.map.admin
{
    public partial class index : SPcms.Web.UI.ManagePage
    {


        protected string str = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 1;
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    i = Int32.Parse(Request.QueryString["id"].ToString());
                }
                BLL.map bll = new BLL.map();
                Model.map model = bll.GetModel(i);
                if (model != null)
                {

                    string mwidth = model.mwidth;
                    string mheight = model.mheight;
                    str = " <iframe width=\""+mwidth+"px\" height=\""+mheight+"px\" src=\""+siteConfig.webpath+"plugins/map/view.aspx\"></iframe>";
                }
            }
        }





    }
}