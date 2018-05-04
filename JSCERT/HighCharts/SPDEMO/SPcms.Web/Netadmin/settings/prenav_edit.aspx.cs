using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPcms.Common;
using System.Xml;
using System.IO;

namespace SPcms.Web.Netadmin.settings
{
    public partial class prenav_edit : Web.UI.ManagePage
    {
        private string action = SPEnums.ActionEnum.Add.ToString(); //操作类型
        private string id = "";
        private string nod = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = SPRequest.GetQueryString("action");
            this.id = SPRequest.GetQueryString("id");
            string _skin = SPRequest.GetQueryString("skin");
            string _node = SPRequest.GetQueryString("node");
         
            if(!string.IsNullOrEmpty(_action) && _action =="del")
            {
                delnode(_skin,_node,id);
            }
            if (!string.IsNullOrEmpty(_action) && _action == SPEnums.ActionEnum.Edit.ToString())
            {
                this.action = SPEnums.ActionEnum.Edit.ToString();//修改类型
                if (this.id =="")
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                //if (!new BLL.navigation().Exists(this.id))
                //{
                //    JscriptMsg("导航不存在或已被删除！", "back", "Error");
                //    return;
                //}
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("app_navigation_list", SPEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(_skin, _node,this.id); //绑定导航菜单
              //  ActionTypeBind(); //绑定操作权限类型
                if (action == SPEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(_skin, _node,this.id);
                }
                else
                {
                    
                   
                }
            }
        }

        private void delnode(string _skin, string node, string id)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/" + SPRequest.GetQueryString("skin") + "/"));
            XmlDocument doc = new XmlDocument();
            doc.Load(dirInfo.FullName + @"\menu.xml");
            XmlNode xnList = doc.SelectSingleNode(@"menu/" + SPRequest.GetQueryString("node"));

            foreach (XmlNode item in xnList)
            {
                if (item.Attributes["id"].Value == id)
                {
                    removenode(item, xnList, id);
                    doc.Save(dirInfo.FullName + @"\menu.xml");
                    JscriptMsg("删除导航菜单成功！", "prenav_list.aspx?skin=" + SPRequest.GetQueryString("skin"), "Success");
                }
            }
            JscriptMsg("删除失败！", "prenav_list.aspx?skin=" + SPRequest.GetQueryString("skin"), "Success");
        }

        private void removenode(XmlNode item, XmlNode xnList, string id)
        {
            xnList.RemoveChild(item);
            foreach (XmlNode item1 in xnList)
            {
                if (item1.ChildNodes[0].InnerText == id)
                {
                    removenode(item1, xnList, id);
                }
            }
        }

       

        private void ShowInfo(string _skin, string node,string id)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/" + _skin + "/"));
            XmlNodeList xnList = XmlHelper.ReadNodes(dirInfo.FullName + @"\menu.xml", @"menu/" + node);
            foreach (XmlNode item in xnList)
            {
                if (item.Attributes["id"].Value == id)
                {
                    hfnid.Value = id;
                    HDParentId.Value = item.ChildNodes[0].InnerText;
                    txtSortId.Text = item.ChildNodes[3].InnerText;
                    txtTitle.Text = item.ChildNodes[1].InnerText;
                    txtLinkUrl.Text = item.ChildNodes[2].InnerText;
                    txtfclass.Text = item.ChildNodes[4].InnerText;

                }
            }
            fiddl.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            //清除菜单缓存
            CacheHelper.Remove(SPRequest.GetQueryString("skin") + "_1");
            CacheHelper.Remove(SPRequest.GetQueryString("skin") + "_2");
            if (action == SPEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("app_navigation_list", SPEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改导航菜单成功！", "prenav_list.aspx?skin=" + SPRequest.GetQueryString("skin"), "Success");
            }
            else //添加
            {
                ChkAdminLevel("app_navigation_list", SPEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加导航菜单成功！", "prenav_list.aspx?skin=" + SPRequest.GetQueryString("skin"), "Success");
            }
        
        }

        private bool DoAdd()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/" + SPRequest.GetQueryString("skin") + "/"));
                XmlDocument doc = new XmlDocument();
                doc.Load(dirInfo.FullName + @"\menu.xml");
                XmlNode xn = doc.SelectSingleNode(@"menu/" + SPRequest.GetQueryString("node") + "");
                XmlElement xxfid = doc.CreateElement("fid");
                xxfid.SetAttribute("id", SPRequest.GetQueryString("id") + "_" + SPcms.Common.Utils.Number(5));
                XmlElement xmlfnod = doc.CreateElement("fnod");
                xmlfnod.InnerText = SPRequest.GetQueryString("id");
                XmlElement xmlfname = doc.CreateElement("fname");
                xmlfname.InnerText = txtTitle.Text;

                XmlElement xmlflink = doc.CreateElement("flink");
                xmlflink.InnerText = txtLinkUrl.Text;

                XmlElement xmlfindex = doc.CreateElement("findex");
                xmlfindex.InnerText = txtSortId.Text;

                XmlElement xmlflayer = doc.CreateElement("flayer");
                xmlflayer.InnerText = (Int32.Parse(Hdlayer.Value) + 1).ToString();

                XmlElement xmlfclass = doc.CreateElement("fclass");
                xmlfclass.InnerText = txtfclass.Text;


                xxfid.AppendChild(xmlfnod);
                xxfid.AppendChild(xmlfname);
                xxfid.AppendChild(xmlflink);
                xxfid.AppendChild(xmlfindex);
                xxfid.AppendChild(xmlflayer);
                xxfid.AppendChild(xmlflayer);
                xn.AppendChild(xxfid);
                doc.Save(dirInfo.FullName + @"\menu.xml");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           


        }

        private bool DoEdit(string id)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/" + SPRequest.GetQueryString("skin") + "/"));
            XmlDocument doc = new XmlDocument();
            doc.Load(dirInfo.FullName + @"\menu.xml");
            XmlNode xnList = doc.SelectSingleNode(@"menu/" + SPRequest.GetQueryString("node"));
         
            foreach (XmlNode item in xnList.ChildNodes)
            {
                if (item.Attributes["id"].Value == id)
                {
                    try
                    {
                         item.ChildNodes[0].InnerText= HDParentId.Value;
                         item.ChildNodes[3].InnerText= txtSortId.Text;
                         item.ChildNodes[1].InnerText = txtSubTitle.Text.Trim() == "" ? txtTitle.Text : txtSubTitle.Text;
                         item.ChildNodes[2].InnerText = txtLinkUrl.Text;
                         item.ChildNodes[4].InnerText = txtfclass.Text;
                         doc.Save(dirInfo.FullName + @"\menu.xml");
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
            }
            return false;
          
        }

        //private string getsitename(string node)
        //{
        //    BLL.channel_category bll = new BLL.channel_category();
        //    return bll.GetModel(Int32.Parse(node)).build_path; ;
        //}
        #region 绑定父级菜单=============================
        private void TreeBind(string _skin,string node,string id)
        {

            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/" + _skin + "/"));
            XmlNodeList xnList = XmlHelper.ReadNodes(dirInfo.FullName + @"\menu.xml", @"menu/" + node);
            foreach (XmlNode item in xnList)
            {
                if (item.Attributes["id"].Value == id)
                {
                 
                    Hdlayer.Value = item.ChildNodes[4].InnerText;
                    ListItem li = new ListItem();
                    li.Text = item.ChildNodes[1].InnerText;
                    li.Value = item.Attributes["id"].ToString();
                    this.ddlParentId.Items.Add(li);


                }
            }
            HDParentId.Value = id;
            //DataTable dt =

            //this.ddlParentId.Items.Clear();
            //this.ddlParentId.Items.Add(new ListItem("无父级导航", "0"));
            //foreach (DataRow dr in dt.Rows)
            //{
            //    string Id = dr["id"].ToString();
            //    int ClassLayer = int.Parse(dr["class_layer"].ToString());
            //    string Title = dr["title"].ToString().Trim();

            //    if (ClassLayer == 1)
            //    {
            //        this.ddlParentId.Items.Add(new ListItem(Title, Id));
            //    }
            //    else
            //    {
            //        //Title = "├ " + Title;
            //        //Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
            //        //this.ddlParentId.Items.Add(new ListItem(Title, Id));
            //    }
            //}
        }
        #endregion
       
        
    }
}