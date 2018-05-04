using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPcms.Common;

namespace SPcms.Web.admin.settings
{
    public partial class templet_file_list : Web.UI.ManagePage
    {
        protected string skinName = string.Empty; //模板目录

        protected void Page_Load(object sender, EventArgs e)
        {
            skinName = SPRequest.GetQueryString("skin");
            if (string.IsNullOrEmpty(skinName))
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("app_templet_list", SPEnums.ActionEnum.View.ToString()); //检查权限
                RptBind(skinName);
            }
        }

        #region 数据绑定=================================
        private void RptBind(string skin_name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", Type.GetType("System.String"));
            dt.Columns.Add("skinname", Type.GetType("System.String"));
            dt.Columns.Add("creationtime", Type.GetType("System.String"));
            dt.Columns.Add("updatetime", Type.GetType("System.String"));

            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath(@"../../templates/" + skin_name));
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                if (file.Name != "about.xml" && file.Name != "about.png")
                {
                    DataRow dr = dt.NewRow();
                    dr["name"] = file.Name;
                    dr["skinname"] = skin_name;
                    dr["creationtime"] = file.CreationTime;
                    dr["updatetime"] = file.LastWriteTime;
                    dt.Rows.Add(dr);
                }
            }

            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }
        #endregion

        //删除文件
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("app_templet_list", SPEnums.ActionEnum.Delete.ToString()); //检查权限
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string fileName = ((HiddenField)rptList.Items[i].FindControl("hideName")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    Utils.DeleteFile("../../templates/" + this.skinName + "/" + fileName);
                }
            }
            AddAdminLog(SPEnums.ActionEnum.Delete.ToString(), "删除模板文件，模板:" + this.skinName);//记录日志
            JscriptMsg("文件删除成功！", Utils.CombUrlTxt("templet_file_list.aspx", "skin={0}", this.skinName), "Success");
        }
        protected void btnsc_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("app_templet_list", SPEnums.ActionEnum.Build.ToString()); //检查权限
            BLL.channel_category bll = new BLL.channel_category();
            DataTable dt = bll.GetList(0, "is_default=1", "sort_id asc,id desc").Tables[0];
            if (dt.Rows.Count > 0)
            {

                MarkTemplates(dt.Rows[0]["build_path"].ToString(), dt.Rows[0]["templet_path"].ToString());
                //修改当前频道分类当前模板名

                new BLL.channel_category().UpdateField(dt.Rows[0]["build_path"].ToString(), "templet_path='" + dt.Rows[0]["templet_path"].ToString() + "'");

                AddAdminLog(SPEnums.ActionEnum.Build.ToString(), "生成模板:" + dt.Rows[0]["templet_path"].ToString());//记录日志
                string url = Request.RawUrl;
                JscriptMsg("生成模板成功！", url, "Success");
                return;

            }
            JscriptMsg("无默认模板文件！", "", "Error");
            return;
        }
        #region 全部生成模板=============================
        /// <summary>
        /// 生成全部模板
        /// </summary>
        private void MarkTemplates(string buildPath, string skinName)
        {
            //取得ASP目录下的所有文件
            string fullDirPath = Utils.GetMapPath(string.Format("{0}aspx/{1}/", siteConfig.webpath, buildPath));
            DirectoryInfo dirFile = new DirectoryInfo(fullDirPath);
            //获得URL配置列表
            BLL.url_rewrite bll = new BLL.url_rewrite();
            List<Model.url_rewrite> ls = bll.GetList("");

            //删除不属于URL映射表里的文件，防止冗余
            if (Directory.Exists(fullDirPath))
            {
                foreach (FileInfo file in dirFile.GetFiles())
                {
                    //检查文件
                    Model.url_rewrite modelt = ls.Find(p => p.page.ToLower() == file.Name.ToLower());
                    if (modelt == null)
                    {

                        file.Delete();
                    }
                }
            }

            //遍历URL配置列表
            foreach (Model.url_rewrite modelt in ls)
            {
                //如果URL配置对应的模板文件存在则生成
                string fullPath = Utils.GetMapPath(string.Format("{0}templates/{1}/{2}", siteConfig.webpath, skinName, modelt.templet));
                if (File.Exists(fullPath))
                {
                    PageTemplate.GetTemplate(siteConfig.webpath, "templates", skinName, modelt.templet, modelt.page, modelt.inherit, buildPath, 1);
                }
            }
        }
        #endregion
    }
}