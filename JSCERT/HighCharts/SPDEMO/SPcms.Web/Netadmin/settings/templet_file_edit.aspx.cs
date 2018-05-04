using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPcms.Common;
using System.Xml;
using System.Data;

namespace SPcms.Web.admin.settings
{
    public partial class templet_file_edit : Web.UI.ManagePage
    {
        protected string filePath; //文件路径
        protected string pathName; //模板目录
        protected string fileName; //文件名称

        protected void Page_Load(object sender, EventArgs e)
        {
            pathName = SPRequest.GetQueryString("path");
            fileName = SPRequest.GetQueryString("filename");
            if (string.IsNullOrEmpty(pathName) || string.IsNullOrEmpty(fileName))
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            filePath = Utils.GetMapPath(@"../../templates/" + pathName.Replace(".", "") + "/" + fileName.Replace("/", ""));
            if (!File.Exists(filePath))
            {
                JscriptMsg("该文件不存在！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("app_templet_list", SPEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo(filePath);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(string _path)
        {
            using (StreamReader objReader = new StreamReader(_path, Encoding.UTF8))
            {
                txtContent.Text = objReader.ReadToEnd();
                objReader.Close();
            }
            RptBind();
            //获取所有的频道
            repds.DataSource = new BLL.channel().GetListview(100, "1=1", "id");
            repds.DataBind();
          
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("app_templet_list", SPEnums.ActionEnum.Edit.ToString()); //检查权限
            using (FileStream fs = new FileStream(this.filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                Byte[] info = Encoding.UTF8.GetBytes(txtContent.Text);
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
            AddAdminLog(SPEnums.ActionEnum.Edit.ToString(), "修改模板文件:" + this.fileName);//记录日志
            if (pathName == "sys")
            {
                JscriptMsg("模板保存成功！", Utils.CombUrlTxt("css_mng.aspx", "skin={0}", this.pathName), "Success");
            }
            else
            {
                JscriptMsg("模板保存成功！", Utils.CombUrlTxt("templet_file_list.aspx", "skin={0}", this.pathName), "Success");
            }
        }
        //样式绑定
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


            foreach (DirectoryInfo di in dirInfo.GetDirectories())
            {
                DataRow dr = dt.NewRow();
                dr["name"] = di.Name;

                foreach (FileInfo dir in di.GetFiles())
                {
                    dr["fordntver"] = " &lt;%template src=\"../sys/" + di.Name + "/index.html\"%&gt;";  //适用的版本------改为路径

                }
                dt.Rows.Add(dr);
            }

            this.Repcss.DataSource = dt;
            this.Repcss.DataBind();
        }
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
        #endregion
    }
}