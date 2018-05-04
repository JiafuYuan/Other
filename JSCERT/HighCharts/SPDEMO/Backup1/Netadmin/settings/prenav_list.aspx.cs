using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPcms.Common;
using System.IO;
using System.Xml;


namespace SPcms.Web.Netadmin.settings
{
    public partial class prenav_list : Web.UI.ManagePage
    {
        protected static string _skin;
        protected static string _skin1;
        protected void Page_Load(object sender, EventArgs e)
        {
             _skin = SPRequest.GetQueryString("skin");
          
            string _action = SPRequest.GetQueryString("action");
            if (_action == "tj" && _skin != "")
            {
                creattjmenu(_skin);
            }
            if (!IsPostBack)
            {     //添加所属站点
                Dropsite.DataSource = new BLL.channel_category().GetList(0, "1=1", "id asc");
                Dropsite.DataTextField = "title";
                Dropsite.DataValueField = "build_path";
                Dropsite.DataBind();
                if (Session["lx"] != null)
                {
                    Dropsite.SelectedValue = Session["lx"].ToString();
                }
                RptBind();//模板绑定
          
               
                if (_skin != "")
                {
                    bdreplist(_skin);
                }

           
            }
            _skin1 = Dropsite.SelectedValue;
        }

        private void bdreplist(string _skin)
        {
            string sitename=Dropsite.SelectedValue;
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/" + _skin + "/"));
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("fid");
            dt.Columns.Add("link");
            dt.Columns.Add("index");
            dt.Columns.Add("layer");
            ///存放关于信息的文件 about.xml是否存在,不存在返回空串
            if (!File.Exists(dirInfo.FullName + @"\menu.xml"))
            {
                File.Create(dirInfo.FullName + @"\menu.xml");
            }
            try
            {
                //XmlNodeList xnList = XmlHelper.ReadNodes(dirInfo.FullName + @"\menu.xml", "menu");
                //foreach (XmlNode n1 in xnList)
                //{
                    XmlNodeList xnList2 = XmlHelper.ReadNodes(dirInfo.FullName + @"\menu.xml", @"menu/" +Dropsite.SelectedValue);
                    foreach (XmlNode n in xnList2)
                    {
                        if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "fid")
                        {
                            DataRow dr = dt.NewRow();
                            dr["id"] = n.Attributes["id"].Value.ToString();
                            dr["name"] = n.ChildNodes[1].InnerText.ToString();
                            dr["fid"] = n.ChildNodes[0].InnerText.ToString();
                            dr["link"] = n.ChildNodes[2].InnerText.ToString();
                            dr["index"] = n.ChildNodes[3].InnerText.ToString();
                            dr["layer"] = n.ChildNodes[4].InnerText.ToString();

                            dt.Rows.Add(dr);
                        }
                    }
                    //复制结构
                    DataTable newData = dt.Clone();
                    //调用迭代组合成DAGATABLE
                    GetChilds(dt, newData, "0");
                    rptList.DataSource = newData;
                    rptList.DataBind();

                //}
            }
            catch
            {


            }

            //绑定所有单页
            BLL.article blla = new BLL.article();
            dt = blla.GetList(100, "channel_id=5", "").Tables[0];

            cblsinglepage.DataSource = dt;
            cblsinglepage.DataTextField = "title";
            cblsinglepage.DataValueField = "call_index";
            cblsinglepage.DataBind();
            cblsinglepage.Items.Insert(0,"快速添加单页");
            cblsinglepage.Items.Add("给我留言");
         

        }
        protected void Dropsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            bdreplist(_skin);
            Session["lx"] = Dropsite.SelectedValue;
        }
        protected void cblsinglepage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cblsinglepage.SelectedIndex == 0)
            {
                return;
            }
            addnav();//快速添加菜单

            bdreplist(_skin);
        }

     
       
        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg1 = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";

                int classLayer = Convert.ToInt32(hidLayer.Value);
                if (classLayer == 1)
                {
                    LitFirst.Text = LitImg1;
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1);
                }
            }
        }
        /// <summary>
        /// 从内存中取得所有下级类别列表（自身迭代）
        /// </summary>
        private void GetChilds(DataTable oldData, DataTable newData, string parent_id)
        {
            DataRow[] dr = oldData.Select("fid='" + parent_id+"'");
            for (int i = 0; i < dr.Length; i++)
            {
                //添加一行数据
                DataRow row = newData.NewRow();
                row["id"] = dr[i]["id"].ToString();

                row["name"] = dr[i]["name"].ToString();
                row["fid"] = dr[i]["fid"].ToString();
                row["link"] = dr[i]["link"].ToString();
                row["layer"] = dr[i]["layer"].ToString();
                row["index"] = int.Parse(dr[i]["index"].ToString());

                newData.Rows.Add(row);
                //调用自身迭代
                this.GetChilds(oldData, newData, dr[i]["id"].ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CacheHelper.Remove(SPRequest.GetQueryString("skin")+"_1");
            CacheHelper.Remove(SPRequest.GetQueryString("skin") + "_2");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
        //private string getsitename()
        //{
        //    BLL.channel_category bll = new BLL.channel_category();
        //    return bll.GetModel(Int32.Parse(Dropsite.SelectedValue)).build_path; ;
        //}
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

            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/"));
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                DataRow dr = dt.NewRow();
                Model.template model = GetInfo(dir.FullName);
                if (model != null)
                {
                    dr["skinname"] = dir.Name;  //文件夹名称
                    dr["name"] = model.name;    // 模板名称
                    dr["img"] = "../../templates/" + dir.Name + "/about.png";   // 模板图片
                    dr["author"] = model.author;    //作者
                    dr["createdate"] = model.createdate;    //创建日期
                    dr["version"] = model.version;  //模板版本
                    dr["fordntver"] = model.fordntver;  //适用的版本
                    dt.Rows.Add(dr);
                }
            }
            this.rplisttemp.DataSource = dt;
            this.rplisttemp.DataBind();
        }
        #region 读取模板配置信息=========================
        /// <summary>
        /// 从模板说明文件中获得模板说明信息
        /// </summary>
        /// <param name="xmlPath">模板路径(不包含文件名)</param>
        /// <returns>模板说明信息</returns>
        private Model.template GetInfo(string xmlPath)
        {
            Model.template model = new Model.template();
            ///存放关于信息的文件 about.xml是否存在,不存在返回空串
            if (!File.Exists(xmlPath + @"\about.xml"))
            {
                return null;
            }
            try
            {
                XmlNodeList xnList = XmlHelper.ReadNodes(xmlPath + @"\about.xml", "about");
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

        private void creattjmenu(string skin)
        {
            #region 生成推荐数据

            string _skin = skin;


            try
            {

                //删除所有子节点
                DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/" + _skin + "/"));
                DirectoryInfo dirInfo1 = new DirectoryInfo(Utils.GetMapPath("../../templates/sys/"));
                File.Copy(dirInfo1 + @"\menu.xml", dirInfo + @"\menu.xml", true);
                //if (!File.Exists(dirInfo + @"\about.xml"))
                //{
                //    File.Copy(dirInfo1 + @"\about.xml", dirInfo + @"\about.xml",true);

                //}
                //else
                //{
                //    XmlHelper.delALLnode(dirInfo.FullName + @"\menu.xml", "menu");

                //    XmlHelper.AppendChild(dirInfo1.FullName + @"\menu.xml", "menu", dirInfo.FullName + @"\menu.xml", "menu");
                   
                //}
                JscriptMsg("推荐导航数据生成成功！", "prenav_list.aspx", "Success", "");
            }
            catch
            {


            }





            #endregion
        }
        #endregion


        #region 快速添加菜单
        

        private void addnav()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/" + SPRequest.GetQueryString("skin") + "/"));
            XmlDocument doc = new XmlDocument();
            doc.Load(dirInfo.FullName + @"\menu.xml");
            XmlNode xn = doc.SelectSingleNode(@"menu/" +Dropsite.SelectedValue + "");
            XmlElement xxfid = doc.CreateElement("fid");
            xxfid.SetAttribute("id", SPRequest.GetQueryString("id") + "_" + SPcms.Common.Utils.Number(5));
            XmlElement xmlfnod = doc.CreateElement("fnod");
            xmlfnod.InnerText ="0";
            XmlElement xmlfname = doc.CreateElement("fname");
            xmlfname.InnerText = cblsinglepage.SelectedItem.Text;

            XmlElement xmlflink = doc.CreateElement("flink");
            xmlflink.InnerText = getlink();

            XmlElement xmlfindex = doc.CreateElement("findex");
            xmlfindex.InnerText = "100";

            XmlElement xmlflayer = doc.CreateElement("flayer");
            xmlflayer.InnerText ="1";

            XmlElement xmlfclass = doc.CreateElement("fclass");
            xmlfclass.InnerText = "";


            xxfid.AppendChild(xmlfnod);
            xxfid.AppendChild(xmlfname);
            xxfid.AppendChild(xmlflink);
            xxfid.AppendChild(xmlfindex);
            xxfid.AppendChild(xmlflayer);
            xxfid.AppendChild(xmlflayer);
            xn.AppendChild(xxfid);
            doc.Save(dirInfo.FullName + @"\menu.xml");

   
        }

        private string getlink()
        {

            if (cblsinglepage.SelectedItem.Text != "给我留言")
            {
                if (Dropsite.SelectedIndex == 1)
                { return "/econtent/" + cblsinglepage.SelectedValue + ".html"; }
                else
                {
                    return "/content/" + cblsinglepage.SelectedValue + ".html";
                }
            }
            else
            {
                if (Dropsite.SelectedIndex == 1)
                {
                    return "/efeedback.html";
                }
                else
                {
                    return "/feedback.html";
                }
            }
            return "";
          
        }
        #endregion
    }
}