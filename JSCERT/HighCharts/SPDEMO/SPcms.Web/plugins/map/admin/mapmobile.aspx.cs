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
    public partial class mapmobile : SPcms.Web.UI.ManagePage
    {
        protected string  address;
        protected string  cname;
        protected string tel;
        protected int pageSize;
        protected string jj;
        protected string keywords = string.Empty;
        protected string mwidth;
        protected string mheight;
        protected void Page_Load(object sender, EventArgs e)
        {
            bdinfor();
           
        }

        private void bdinfor()
        {
            BLL.map bll = new BLL.map();
            Model.map model = bll.GetModel(2);
            if (model!=null)
            {
                address = model.address;
                cname =  model.company;
                tel =  model.tel;
                jj = model.instr;
                mwidth = model.mwidth;
                mheight = model.mheight;
            }
            else
            {
                SPcms.Model.siteconfig siteConfig = new SPcms.BLL.siteconfig().loadConfig();
                address = siteConfig.webaddress;
                cname = siteConfig.webcompany;
                tel = siteConfig.webtel;
                jj = siteConfig.webdescription;
                mwidth = "500";
                mheight = "400";
            }
        }



    }
}