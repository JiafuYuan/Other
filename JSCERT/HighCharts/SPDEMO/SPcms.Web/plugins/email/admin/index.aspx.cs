using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SPcms.Common;
using System.IO;

namespace SPcms.Web.Plugin.mail_send.admin
{
    public partial class index : SPcms.Web.UI.ManagePage
    {

        BLL.mail_send bll = new BLL.mail_send();           
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("plugin_mail_send", SPEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        #region 数据绑定=================================
        private void RptBind()
        {
         
            DataTable dt= bll.GetAllList().Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
        }
        #endregion

    
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("emailadd.aspx");
        }

        //删除
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = ((HiddenField)e.Item.FindControl("hidFileName")).Value;
            if (bll.Delete(Int32.Parse(id)))
            {

                JscriptMsg("删除数据成功！", "index.aspx", "Success");
            }
           
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            int sucCount = 0;
            int errorCount = 0;

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidFileName")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(SPEnums.ActionEnum.Delete.ToString(), "删除邮件成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("index.aspx", "keywords={0}", ""), "Success");

        }

    }
}