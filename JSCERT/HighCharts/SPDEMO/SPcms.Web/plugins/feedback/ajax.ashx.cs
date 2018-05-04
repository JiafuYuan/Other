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

namespace SPcms.Web.Plugin.Feedback
{
    /// <summary>
    /// 管理后台AJAX处理页
    /// </summary>
    public class ajax : IHttpHandler, IRequiresSessionState
    {

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
                case "add": //发布留言
                    feedback_add(context);
                    break;
           
                case "madd"://移动模板留言
                      feedback_madd(context);
                    break;
            }

        }

        private void feedback_madd(HttpContext context)
        {
            StringBuilder strTxt = new StringBuilder();
            BLL.feedback bll = new BLL.feedback();
            Model.feedback model = new Model.feedback();
   
          
            string _title = SPRequest.GetFormString("txtTitle");
            string _content = SPRequest.GetFormString("txtContent");
            string _user_name = SPRequest.GetFormString("txtUserName");
            string _user_tel = SPRequest.GetFormString("txtUserTel");
            string _user_qq = SPRequest.GetFormString("txtUserQQ");
            string _user_email = SPRequest.GetFormString("txtUserEmail");
            string _cateid = SPRequest.GetFormString("cateid");
          
            if (string.IsNullOrEmpty(_content))
            {

                return;
            }

            model.title = Utils.DropHTML(_title);
            model.content = Utils.ToHtml(_content);
            model.user_name = Utils.DropHTML(_user_name);
            model.user_tel = Utils.DropHTML(_user_tel);
            model.user_qq = Utils.DropHTML(_user_qq);
            model.user_email = Utils.DropHTML(_user_email);
            model.add_time = DateTime.Now;
           
            model.is_lock = 1; //不需要审核，请改为0
            if (bll.Add(model) > 0)
            {
                context.Response.Write("ok");
                return;
            }
            context.Response.Write("error");
        }

        #region 发布留言================================
        private void feedback_add(HttpContext context)
        {
            StringBuilder strTxt = new StringBuilder();
            BLL.feedback bll = new BLL.feedback();
            Model.feedback model = new Model.feedback();

            string _code = SPRequest.GetFormString("txtCode");
            string _title = SPRequest.GetFormString("txtTitle");
            string _content = SPRequest.GetFormString("txtContent");
            string _user_name = SPRequest.GetFormString("txtUserName");
            string _user_tel = SPRequest.GetFormString("txtUserTel");
            string _user_qq = SPRequest.GetFormString("txtUserQQ");
            string _user_email = SPRequest.GetFormString("txtUserEmail");
            int _cateid = SPRequest.GetFormInt("cateid");
            //校检验证码
            if (string.IsNullOrEmpty(_code))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入验证码！\"}");
                return;
            }
            if (context.Session[SPKeys.SESSION_CODE] == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，验证码已过期！\"}");
                return;
            }
            if (_code.ToLower() != (context.Session[SPKeys.SESSION_CODE].ToString()).ToLower())
            {
                context.Response.Write("{\"status\":0, \"msg\":\"验证码与系统的不一致！\"}");
                return;
            }
            if (string.IsNullOrEmpty(_content))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，请输入留言的内容！\"}");
                return;
            }

            model.title = Utils.DropHTML(_title);
            model.content = Utils.ToHtml(_content);
            model.user_name = Utils.DropHTML(_user_name);
            model.user_tel = Utils.DropHTML(_user_tel);
            model.user_qq = Utils.DropHTML(_user_qq);
            model.user_email = Utils.DropHTML(_user_email);
            model.add_time = DateTime.Now;
            model.is_lock = 1; //不需要审核，请改为0
            model.cateid = _cateid;
            if (bll.Add(model) > 0)
            {
                context.Response.Write("{\"status\": 1, \"msg\": \"恭喜您，留言提交成功！\"}");
                return;
            }
            context.Response.Write("{\"status\": 0, \"msg\": \"对不起，保存过程中发生错误！\"}");
            return;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}