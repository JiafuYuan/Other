using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPcms.Common;
using System.IO;
using System.Data;
using System.Xml;


namespace SPcms.Web.Netadmin.settings
{
    public partial class css_mng : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("app_templet_list", SPEnums.ActionEnum.View.ToString()); //检查权限
                // TreeBind(); //绑定频道分类
                RptBind(); //绑定模板


            }
        }




        #region 数据绑定=================================
        private void RptBind()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("skinname", Type.GetType("System.String"));
            dt.Columns.Add("name", Type.GetType("System.String"));
            dt.Columns.Add("img", Type.GetType("System.String"));
            dt.Columns.Add("author", Type.GetType("System.String"));
            dt.Columns.Add("createdate", Type.GetType("System.String"));
            dt.Columns.Add("version", Type.GetType("System.String"));
            dt.Columns.Add("fordntver", Type.GetType("System.String"));

            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/sys/"));
            string inputname = txtname.Text.Trim();

            foreach (DirectoryInfo di in dirInfo.GetDirectories())
            {
                DataRow dr = dt.NewRow();
                dr["name"] = di.Name;
                if (inputname != "")
                {
                    if (!di.Name.Contains(inputname))
                    {
                        continue;
                    }
                }

                foreach (FileInfo dir in di.GetFiles())
                {



                    Model.template model = GetcssInfo(Utils.GetMapPath("../../templates/sys/" + di.Name + "/"), "index");
                    if (model != null)
                    {

                        //dr["name"] = dir.Name;  //文件夹名称
                        // dr["name"] = model.name;    // 模板名称
                        dr["img"] = "../../templates/sys/" + di.Name + "/index.png";   // 模板图片
                        dr["author"] = model.author;    //作者
                        dr["createdate"] = model.createdate;    //创建日期
                        dr["version"] = model.version;  //模板版本
                        dr["fordntver"] = model.fordntver;  //适用的版本

                    }

                }
                dt.Rows.Add(dr);
            }

            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }
        #endregion


        #region 读取样式配置信息=========================pop-20140116
        /// <summary>
        /// 从模板说明文件中获得模板说明信息
        /// </summary>
        /// <param name="xmlPath">模板路径(不包含文件名)</param>
        /// <returns>模板说明信息</returns>
        private Model.template GetcssInfo(string xmlPath, string filename)
        {
            Model.template model = new Model.template();
            ///存放关于信息的文件 about.xml是否存在,不存在返回空串
            if (!File.Exists(xmlPath + @"\" + filename + ".xml"))
            {
                return null;
            }
            try
            {
                XmlNodeList xnList = XmlHelper.ReadNodes(xmlPath + @"\" + filename + ".xml", "about");
                foreach (XmlNode n in xnList)
                {
                    if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "template")
                    {
                        model.name = n.Attributes["name"] != null ? n.Attributes["name"].Value.ToString() : "";
                        model.author = n.Attributes["author"] != null ? n.Attributes["author"].Value.ToString() : "";
                        model.createdate = n.Attributes["createdate"] != null ? n.Attributes["createdate"].Value.ToString() : "";
                        model.version = n.Attributes["version"] != null ? n.Attributes["version"].Value.ToString() : "";
                        model.fordntver = n.Attributes["fordntver"] != null ? n.Attributes["fordntver"].Value.ToString() : "";
                    }
                }
            }
            catch
            {
                return null;
            }
            return model;
        }
        #endregion


        //管理模板
        protected void btnManage_Click(object sender, EventArgs e)
        {
            RptBind();
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
                JscriptMsg("生成模板成功！", "css_mng.aspx", "Success");
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