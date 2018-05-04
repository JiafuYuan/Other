using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPcms.Common;

namespace SPcms.Web.Plugin.mail_send.admin
{
    public partial class emailadd : SPcms.Web.UI.ManagePage
    {

        protected Model.mail_send model = new Model.mail_send();

        protected void Page_Load(object sender, EventArgs e)
        {
            SPcms.Common.InitJs.initJavascript();


            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_feedback", SPEnums.ActionEnum.View.ToString()); //检查权限
                // ShowInfo(this.id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {

        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SPcms.Model.siteconfig siteConfig = new SPcms.BLL.siteconfig().loadConfig();
            if (txtContent.Value.Trim() == "")
            {
                JscriptMsg("请填写邮件内容", "", "Error");
                return;
            }
            if (siteConfig.emailsmtp == "" || siteConfig.emailusername == "" || siteConfig.emailpassword == "" || siteConfig.emailnickname == "")
            {
                JscriptMsg("邮件配置不全，请完成邮件发送设置", "../../../"+siteConfig.webmanagepath + "/settings/sys_config.aspx", "Error");
                return;
            }
        
            //开始发送邮件
            int i=0;
            string mailContent = txtContent.Value;
            string sub = txttitle.Text;
            //用户密码解密
            //siteConfig.emailpassword = DESEncrypt.Decrypt(siteConfig.emailpassword,siteConfig.sysencryptstring); ;
            foreach (string item in txtsjr.Text.Trim().Split(','))
            {

                if (item != "")
                {
                    try
                    {
                        SPMail.sendMail(siteConfig.emailsmtp, siteConfig.emailusername,  DESEncrypt.Decrypt(siteConfig.emailpassword), siteConfig.emailnickname,
                        siteConfig.emailfrom,item, sub,mailContent);
                        i++;
                        //发送成功后添加到数据库
                        BLL.mail_send bll = new BLL.mail_send();
                        model.addtime = DateTime.Now;
                        model.mailcontent = txtContent.Value;
                        model.recipients = txtsjr.Text;
                        model.title = txttitle.Text;
                        bll.Add(model);
                    }
                    catch (Exception)
                    {
                        
                      
                    }
                    //发送邮件
                    
                }
            }
            JscriptMsg("群发邮件成功，共发送"+i+"封邮件！", "index.aspx", "Success");
        }

    }
}