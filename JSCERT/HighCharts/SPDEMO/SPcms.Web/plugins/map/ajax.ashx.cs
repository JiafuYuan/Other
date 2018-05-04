using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;
using SPcms.Web.UI;
using SPcms.Common;

namespace SPcms.Web.Plugin.map
{
    /// <summary>
    /// AJAX处理页
    /// </summary>
    public class ajax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = context.Request.Params["action"];

            switch (action)
            {
                case "edit_map": //
                    edit_map(context);
                    break;
                case "edit_map2": //
                    edit_map2(context);
                    break;
            }

        }

        private void edit_map(HttpContext context)
        {
            BLL.map bll = new BLL.map();
            Model.map model = new Model.map();
            model.address = context.Request["address"].ToString();
            model.company = context.Request["cname"].ToString();
            model.instr = context.Request["seojj"].ToString();
            model.tel = context.Request["tel"].ToString();
            model.mwidth = context.Request["mwidth"].ToString();
            model.mheight = context.Request["mheight"].ToString();
            if (bll.GetAllList().Tables[0].Rows.Count > 0)
            {
                model.id = 1;
                bll.Update(model);
            }
            else {
                bll.Add(model);
            }
            context.Response.Write("ok");
        }

        private void edit_map2(HttpContext context)
        {
            BLL.map bll = new BLL.map();
            Model.map model = new Model.map();
            model.address = context.Request["address"].ToString();
            model.company = context.Request["cname"].ToString();
            model.instr = context.Request["seojj"].ToString();
            model.tel = context.Request["tel"].ToString();
            model.mwidth = context.Request["mwidth"].ToString();
            model.mheight = context.Request["mheight"].ToString();
            if (bll.GetModel(2)!=null)
            {
                model.id = 2;
                bll.Update(model);
            }
            else
            {
                bll.Add(model);
            }
            context.Response.Write("ok");
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