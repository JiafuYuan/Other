using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SPcms.Common;

namespace SPcms.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        #region 列表标签======================================
        /// <summary>
        /// 文章列表
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(string channel_name, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(channel_name))
            {
                dt = new BLL.article().GetList(channel_name, top, strwhere, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 文章列表
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="category_id">分类ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(string channel_name, int category_id, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(channel_name))
            {
                dt = new BLL.article().GetList(channel_name, category_id, top, strwhere, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 文章列表
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="category_id">分类ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(string channel_name, int category_id, int top, string strwhere, string orderby)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(channel_name))
            {
                dt = new BLL.article().GetList(channel_name, category_id, top, strwhere, orderby).Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 文章分页列表
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="category_id">分类ID</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <param name="_key">URL配置名称</param>
        /// <param name="_params">传输参数</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(string channel_name, int category_id, int page_index, string strwhere, out int totalcount, out string pagelist, string _key, params object[] _params)
        {
            DataTable dt = new DataTable();
            int pagesize;
            if (!string.IsNullOrEmpty(channel_name))
            {
                dt = new BLL.article().GetList(channel_name, category_id, page_index, strwhere, "sort_id asc,add_time desc", out totalcount, out pagesize).Tables[0];
                pagelist = Utils.OutPageList(pagesize, page_index, totalcount, linkurl(_key, _params), 8);
            }
            else
            {
                totalcount = 0;
                pagelist = "";
            }
            return dt;
        }


        #endregion

        #region 内容标签======================================
        /// <summary>
        /// 根据调用标识取得内容
        /// </summary>
        /// <param name="call_index">调用别名</param>
        /// <returns>String</returns>
        protected string get_article_content(string call_index)
        {
            if (string.IsNullOrEmpty(call_index))
                return string.Empty;
            BLL.article bll = new BLL.article();
            if (bll.Exists(call_index))
            {
                return bll.GetModel(call_index).content;
            }
            return string.Empty;
        }
        /// <summary>
        /// 根据调用标识取得内容
        /// </summary>
        /// <param name="call_index">调用别名</param>
        /// <returns>String</returns>
        protected string get_article_content(string call_index, string filed)
        {
            if (string.IsNullOrEmpty(call_index))
                return string.Empty;
            BLL.article bll = new BLL.article();
            if (bll.Exists(call_index))
            {
                return bll.GetList(1, "call_index='" + call_index + "'", "").Tables[0].Rows[0][filed].ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取扩展字段的值
        /// </summary>
        /// <param name="article_id">内容ID</param>
        /// <param name="field_name">扩展字段名</param>
        /// <returns>String</returns>
        protected string get_article_field(int article_id, string field_name)
        {
            Model.article model = new BLL.article().GetModel(article_id);
            if (model != null && model.fields.ContainsKey(field_name))
            {
                return model.fields[field_name];
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取扩展字段的值
        /// </summary>
        /// <param name="call_index">调用别名</param>
        /// <param name="field_name">扩展字段名</param>
        /// <returns>String</returns>
        protected string get_article_field(string call_index, string field_name)
        {
            if (string.IsNullOrEmpty(call_index))
                return string.Empty;
            BLL.article bll = new BLL.article();
            if (!bll.Exists(call_index))
            {
                return string.Empty;
            }
            Model.article model = bll.GetModel(call_index);
            if (model != null && model.fields.ContainsKey(field_name))
            {
                return model.fields[field_name];
            }
            return string.Empty;
        }
        #endregion

        #region 购物标签======================================
        /// <summary>
        /// 返回相应的图片
        /// </summary>
        /// <param name="article_id">信息ID</param>
        /// <returns>String</returns>
        protected string get_article_img_url(int article_id)
        {
            Model.article model = new BLL.article().GetModel(article_id);
            if (model != null)
            {
                return model.img_url;
            }
            return "";
        }

        /// <summary>
        /// 返回对应商品的会员价格
        /// </summary>
        /// <param name="article_id">信息ID</param>
        /// <returns>Decimal</returns>
        protected decimal get_user_article_price(int article_id)
        {
            Model.users userModel = GetUserInfo();
            if (userModel == null)
            {
                return -1;
            }
            Model.article model = new BLL.article().GetModel(article_id);
            if (model != null)
            {
                if (model.group_price != null)
                {
                    Model.user_group_price priceModel = model.group_price.Find(p => p.group_id == userModel.group_id);
                    if (priceModel != null)
                    {
                        return priceModel.price;
                    }
                }
                if (model.fields.ContainsKey("sell_price"))
                {
                    return Utils.StrToDecimal(model.fields["sell_price"], -1);
                }
            }
            return -1;
        }
        #endregion

        #region 扩展标签============================POP=======
        /// <summary>
        /// 获取前一条字符串
        /// </summary>
        /// <returns></returns>
        protected string get_prestr(string channel_name)
        {
            return "";
        }
        #endregion

        #region 页面通用类----2014----POP
        /// <summary>
        /// 获取导航字符串
        /// </summary>
        /// <param name="chanelcateid"></param>
        /// <returns></returns>
        protected string 导航(int chanelcateid)
        {
           
            string tempath = "";
            BLL.channel_category bll = new BLL.channel_category();
            DataTable dt2 = bll.GetList(0, "is_default=1", "sort_id asc,id desc").Tables[0];
            if (dt2.Rows.Count > 0)
            {
                tempath = dt2.Rows[0]["templet_path"].ToString();
            }
            else
            {
                return "";
            }
            DataTable dt = CacheHelper.Get(tempath+"_"+chanelcateid) as DataTable;//从缓存读取导航
            if (dt == null)
            {
                dt = new DataTable();
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(Utils.GetMapPath("../../templates/" + tempath + "/"));
                System.Xml.XmlNodeList xnList = XmlHelper.ReadNodes(dirInfo.FullName + @"\menu.xml", @"menu/" + getsitename(chanelcateid.ToString()));
                if (xnList == null)
                { return "无菜单配置文件"; }
                dt.Columns.Add("id");
                dt.Columns.Add("fnod");
                dt.Columns.Add("fname");
                dt.Columns.Add("flink");
                dt.Columns.Add("findex", System.Type.GetType("System.Int32"));
                dt.Columns.Add("flayer");

                foreach (System.Xml.XmlNode item in xnList)
                {
                    DataRow dr = dt.NewRow();
                    dr["id"] = item.Attributes["id"].Value;
                    dr["fnod"] = item.ChildNodes[0].InnerText;
                    dr["fname"] = item.ChildNodes[1].InnerText;
                    dr["flink"] = item.ChildNodes[2].InnerText;
                    dr["findex"] = item.ChildNodes[3].InnerText;
                    dr["flayer"] = item.ChildNodes[4].InnerText;
                    dt.Rows.Add(dr);

                }
                //此处添加代码是为了排序使用
                //DataTable newData = dt.Clone();
                ////调用迭代组合成DAGATABLE
                //GetChilds(dt, newData, "0");
                CacheHelper.Insert(tempath + "_" + chanelcateid, dt);
            
            }
            StringBuilder sb = new StringBuilder();
           
            //sb.Append(" <li ><a href=\"" + linkurl("index") + "\">首页</a></li>");

            getstr(dt, "0", sb);
            return sb.ToString();
          

        }

        private void getstr(DataTable dt, string parent_id, StringBuilder sb)
        {

            DataRow[] drlist = dt.Select("fnod='" + parent_id + "'", "findex");
            foreach (DataRow dr in drlist)
            {
                sb.Append(" <li><a href=\"" + dr["flink"] + "\">" + dr["fname"] + "</a>" + getstr2(dt, dr["id"].ToString()) + "</li>");
            }
          
        }

        private string getstr2(DataTable dt, string parent_id )
        {
            StringBuilder sb = new StringBuilder();
            DataRow[] drlist = dt.Select("fnod='" + parent_id + "'", "findex");
            sb.Append("<ul>");
            foreach (DataRow dr in drlist)
            {
                sb.Append(" <li class=\"nav\"><a href=\"" + dr["flink"] + "\">" + dr["fname"] + "</a>" + getstr2(dt, dr["id"].ToString()) + "</li>");
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        private void GetChilds(DataTable oldData, DataTable newData, string parent_id)
        {
            DataRow[] dr = oldData.Select("fid='" + parent_id + "'", "findex");
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
        private string getsitename(string node)
        {
            BLL.channel_category bll = new BLL.channel_category();
            return bll.GetModel(Int32.Parse(node)).build_path; ;
        }

        #endregion



        #region 手机文章扩展


        #endregion
    }
}
