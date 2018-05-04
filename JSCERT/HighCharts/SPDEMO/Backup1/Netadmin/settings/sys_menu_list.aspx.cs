using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPcms.Common;
using System.Data;
using System.IO;
using System.Xml;

namespace SPcms.Web.Netadmin.settings
{
    public partial class sys_menu_list : Web.UI.ManagePage
    {
        private string action = SPEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        private string _skin = "";
        private static string xmlpath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            _skin = SPRequest.GetQueryString("skin");

            DirectoryInfo dirInfo = new DirectoryInfo(Utils.GetMapPath("../../templates/" + _skin + "/"));
            xmlpath = dirInfo.FullName + @"\menu.xml";

            if (!Page.IsPostBack)
            {
                ChkAdminLevel("manager_role", SPEnums.ActionEnum.View.ToString()); //检查权限
                RoleTypeBind(); //绑定角色类型
                NavBind(); //绑定导航
                if (action == SPEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 所属站点=================================
        private void RoleTypeBind()
        {
            //添加所属站点
            Dropsite.DataSource = new BLL.channel_category().GetList(0, "1=1", "id asc");
            Dropsite.DataTextField = "title";
            Dropsite.DataValueField = "build_path";
            Dropsite.DataBind();
        }
        #endregion

        #region 导航菜单=================================
        private void NavBind()
        {

            BLL.channel bll = new BLL.channel();
            DataTable dt = bll.getdtbychannelid(Dropsite.SelectedValue);
            this.rptList.DataSource = dt;
            this.rptList.DataBind();


            //绑定所有单页
            //BLL.article blla = new BLL.article();
            //dt = blla.GetList(100, "channel_id=5", "").Tables[0];
            //cblsinglepage.DataSource = dt;
            //cblsinglepage.DataTextField = "title";
            //cblsinglepage.DataValueField = "call_index";
            //cblsinglepage.DataBind();

        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            //绑定所有单页

        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            string qz = "";
            //管理权限
            if (Dropsite.SelectedValue != "main")
            {
                qz ="/"+Dropsite.SelectedValue;
            }
            XmlHelper.delALLnode(xmlpath, @"menu/" + Dropsite.SelectedValue);
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlpath);
            string site = Dropsite.SelectedValue;

            if (!XmlHelper.isexit(xmlpath, site))
            {
                XmlElement xx = doc.CreateElement(site);

                XmlNode xn1 = doc.SelectSingleNode("menu");
                xn1.AppendChild(xx);
            }

            XmlNode xn = doc.SelectSingleNode(@"menu/" + site + "");

            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
                string navid = ((HiddenField)rptList.Items[i].FindControl("hid")).Value;
                string title = ((HiddenField)rptList.Items[i].FindControl("hidtitle")).Value;
                CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
                for (int n = 0; n < cblActionType.Items.Count; n++)
                {
                    if (cblActionType.Items[n].Selected == true)
                    {

                        #region MyRegion


                        if (cblActionType.Items[n].Value == "1")
                        {
                            //Model.channel model = new BLL.channel().GetModel(Int32.Parse(navid));

                            XmlElement xxfid = doc.CreateElement("fid");
                            xxfid.SetAttribute("id", navid);
                            XmlElement xmlfnod = doc.CreateElement("fnod");
                            xmlfnod.InnerText = "0";
                            XmlElement xmlfname = doc.CreateElement("fname");
                            xmlfname.InnerText = title;

                            XmlElement xmlflink = doc.CreateElement("flink");
                            xmlflink.InnerText = "/"+navName + ".html";

                            XmlElement xmlfindex = doc.CreateElement("findex");
                            xmlfindex.InnerText = "100";

                            XmlElement xmlflayer = doc.CreateElement("flayer");
                            xmlflayer.InnerText = "1";

                            XmlElement xmlfclass = doc.CreateElement("fclass");
                            xmlfclass.InnerText = "";
                            xxfid.AppendChild(xmlfnod);
                            xxfid.AppendChild(xmlfname);
                            xxfid.AppendChild(xmlflink);
                            xxfid.AppendChild(xmlfindex);
                            xxfid.AppendChild(xmlflayer);
                            xxfid.AppendChild(xmlfclass);
                            xn.AppendChild(xxfid);

                        }
                        if (cblActionType.Items[n].Value == "2")
                        {
                            DataTable dt = new BLL.article_category().GetChildList(Int32.Parse(navid));
                            foreach (DataRow item in dt.Rows)
                            {
                                XmlElement xxfid = doc.CreateElement("fid");
                                xxfid.SetAttribute("id", navid + "_" + item["id"]);
                                XmlElement xmlfnod = doc.CreateElement("fnod");
                                if (item["parent_id"].ToString() == "0")
                                {
                                    xmlfnod.InnerText = navid;
                                }
                                else
                                {
                                    xmlfnod.InnerText = navid + "_" + item["parent_id"];
                                }
                                XmlElement xmlfname = doc.CreateElement("fname");
                                xmlfname.InnerText = item["title"].ToString();

                                XmlElement xmlflink = doc.CreateElement("flink");
                                if (navid == "5")
                                {
                                    xmlflink.InnerText = "econtent/" + item["call_index"].ToString() + ".html";
                                }
                                else
                                {
                                    xmlflink.InnerText = navName + "/" + item["id"] + ".html";
                                }
                                XmlElement xmlfindex = doc.CreateElement("findex");
                                xmlfindex.InnerText = "100";

                                XmlElement xmlflayer = doc.CreateElement("flayer");
                                xmlflayer.InnerText = (int.Parse(item["class_layer"].ToString()) + 1).ToString();
                                XmlElement xmlfclass = doc.CreateElement("fclass");
                                xmlfclass.InnerText = "";

                                xxfid.AppendChild(xmlfnod);
                                xxfid.AppendChild(xmlfname);
                                xxfid.AppendChild(xmlflink);
                                xxfid.AppendChild(xmlfindex);
                                xxfid.AppendChild(xmlflayer);
                                xxfid.AppendChild(xmlfclass);
                                xn.AppendChild(xxfid);
                            }

                        }
                        //ls.Add(new Model.manager_role_value { nav_name = navName, action_type = cblActionType.Items[n].Value });
                        #endregion
                    }

                }
            }


            doc.Save(xmlpath);


            return true;
        }

        private string getsitename()
        {
            BLL.channel_category bll = new BLL.channel_category();
            return bll.GetModel(Int32.Parse(Dropsite.SelectedValue)).build_path; ;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            // bool result = false;
            // BLL.manager_role bll = new BLL.manager_role();
            // Model.manager_role model = bll.GetModel(_id);

            // model.role_name = txtRoleName.Text.Trim();
            //// model.role_type = int.Parse(ddlRoleType.SelectedValue);

            // //管理权限
            // List<Model.manager_role_value> ls = new List<Model.manager_role_value>();
            // for (int i = 0; i < rptList.Items.Count; i++)
            // {
            //     string navName = ((HiddenField)rptList.Items[i].FindControl("hidName")).Value;
            //     CheckBoxList cblActionType = (CheckBoxList)rptList.Items[i].FindControl("cblActionType");
            //     for (int n = 0; n < cblActionType.Items.Count; n++)
            //     {
            //         if (cblActionType.Items[n].Selected == true)
            //         {
            //             ls.Add(new Model.manager_role_value { role_id = _id, nav_name = navName, action_type = cblActionType.Items[n].Value });
            //         }
            //     }
            // }
            // model.manager_role_values = ls;

            // if (bll.Update(model))
            // {
            //     AddAdminLog(SPEnums.ActionEnum.Edit.ToString(), "修改管理角色:" + model.role_name); //记录日志
            //     result = true;
            // }
            return true;
        }
        #endregion

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //美化导航树结构
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");

                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg1 = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";
                LitFirst.Text = LitImg1;

                CheckBoxList cblActionType = (CheckBoxList)e.Item.FindControl("cblActionType");
                cblActionType.Items.Clear();

                cblActionType.Items.Add(new ListItem("显示", "1"));
                cblActionType.Items.Add(new ListItem("显示子分类", "2"));
                HiddenField hidnavid = (HiddenField)e.Item.FindControl("hid");
                XmlNodeList xnl = XmlHelper.ReadNodes(xmlpath, @"menu/" + Dropsite.SelectedValue);
                if (xnl == null)
                {
                    return;
                }
                foreach (XmlNode item in xnl)
                {

                    if (item.Attributes["id"].Value == hidnavid.Value)
                    {
                        cblActionType.Items[0].Selected = true;
                        foreach (XmlNode item1 in xnl)
                        {
                            if (item.Attributes["id"].Value == item1.ChildNodes[0].InnerText)
                            {
                                cblActionType.Items[1].Selected = true;
                                break;
                            }
                        }
                    }

                }

            }
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == SPEnums.ActionEnum.Edit.ToString()) //修改
            {
                //  ChkAdminLevel("manager_role", SPEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改导航菜单成功！", "sys_menu_list.aspx", "Success");
            }
            else //添加
            {
                //ChkAdminLevel("manager_role", SPEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加导航菜单成功！", "sys_menu_list.aspx?skin=" + _skin, "Success");
            }
        }

        protected void Dropsite_SelectedIndexChanged(object sender, EventArgs e)
        {
            NavBind();
        }
    }
}