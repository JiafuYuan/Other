using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPcms.Common;
using System.Collections;
using System.IO;

namespace SPcms.Web.admin.settings
{
    public partial class sys_config : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("site_config", SPEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.siteconfig bll = new BLL.siteconfig();
            Model.siteconfig model = bll.loadConfig();

            webname.Text = model.webname;
            webename.Text = model.webename;
            weburl.Text = model.weburl;
            weblogo.Text = model.weblogo;
            webcompany.Text = model.webcompany;
            webaddress.Text = model.webaddress;
            webtel.Text = model.webtel;
            webfax.Text = model.webfax;
            webmail.Text = model.webmail;
            webcrod.Text = model.webcrod;

            webtitle.Text = model.webtitle;
            webkeyword.Text = model.webkeyword;
            webdescription.Text = model.webdescription;


            webetitle.Text = model.webetitle;
            webekeyword.Text = model.webekeyword;
            webedescription.Text = model.webedescription;

            webcopyright.Text = model.webcopyright;

            webpath.Text = model.webpath;
            webmanagepath.Text = model.webmanagepath;
            staticstatus.SelectedValue = model.staticstatus.ToString();

            if (model.Bilingualstat == 1)
            {
                Bilingualstat.Checked = true;
            }
            else
            {
                Bilingualstat.Checked = false;
            }
            staticextension.Text = model.staticextension;
            if (model.mobilestatus == 1)
            {
                mobilestatus.Checked = true;
            }
            else
            {
                mobilestatus.Checked = false;
            }
            mobiledomain.Text = model.mobiledomain;
            if (model.memberstatus == 1)
            {
                memberstatus.Checked = true;
            }
            else
            {
                memberstatus.Checked = false;
            }
            if (model.commentstatus == 1)
            {
                commentstatus.Checked = true;
            }
            else
            {
                commentstatus.Checked = false;
            }
            if (model.logstatus == 1)
            {
                logstatus.Checked = true;
            }
            else
            {
                logstatus.Checked = false;
            }
            if (model.webstatus == 1)
            {
                webstatus.Checked = true;
            }
            else
            {
                webstatus.Checked = false;
            }
            webclosereason.Text = model.webclosereason;
            webcountcode.Text = model.webcountcode;

            smsapiurl.Text = model.smsapiurl;
            smsusername.Text = model.smsusername;
            if (!string.IsNullOrEmpty(model.smspassword))
            {
                smspassword.Attributes["value"] = defaultpassword;
            }
            labSmsCount.Text = GetSmsCount(); //取得短信数量

            emailsmtp.Text = model.emailsmtp;
            emailport.Text = model.emailport.ToString();
            emailfrom.Text = model.emailfrom;
            emailusername.Text = model.emailusername;
            if (!string.IsNullOrEmpty(model.emailpassword))
            {
                emailpassword.Attributes["value"] = defaultpassword;
            }
            emailnickname.Text = model.emailnickname;

            filepath.Text = model.filepath;
            filesave.SelectedValue = model.filesave.ToString();
            fileextension.Text = model.fileextension;
            attachsize.Text = model.attachsize.ToString();
            imgsize.Text = model.imgsize.ToString();
            imgmaxheight.Text = model.imgmaxheight.ToString();
            imgmaxwidth.Text = model.imgmaxwidth.ToString();
            thumbnailheight.Text = model.thumbnailheight.ToString();
            thumbnailwidth.Text = model.thumbnailwidth.ToString();
            watermarktype.SelectedValue = model.watermarktype.ToString();
            watermarkposition.Text = model.watermarkposition.ToString();
            watermarkimgquality.Text = model.watermarkimgquality.ToString();
            watermarkpic.Text = model.watermarkpic;
            watermarktransparency.Text = model.watermarktransparency.ToString();
            watermarktext.Text = model.watermarktext;
            watermarkfont.SelectedValue = model.watermarkfont;
            watermarkfontsize.Text = model.watermarkfontsize.ToString();
        }
        #endregion

        #region 获取短信数量=================================
        private string GetSmsCount()
        {
            string code = string.Empty;
            int count = new BLL.sms_message().GetAccountQuantity(out code);
            if (code == "115")
            {
                return "查询出错：请完善账户信息";
            }
            else if (code != "100")
            {
                return "错误代码：" + code;
            }
            return count + " 条";
        }
        #endregion

        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("site_config", SPEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.siteconfig bll = new BLL.siteconfig();
            Model.siteconfig model = bll.loadConfig();
            try
            {
                model.webname = webname.Text;
                model.webename = webename.Text;
                model.weburl = weburl.Text;
                model.weblogo = weblogo.Text;
                model.webcompany = webcompany.Text;
                model.webaddress = webaddress.Text;
                model.webtel = webtel.Text;
                model.webfax = webfax.Text;
                model.webmail = webmail.Text;
                model.webcrod = webcrod.Text;
                model.webtitle = webtitle.Text;
                model.webkeyword = webkeyword.Text;
                model.webdescription = Utils.DropHTML(webdescription.Text);

                model.webetitle = webetitle.Text;
                model.webekeyword = webekeyword.Text;
                model.webedescription = Utils.DropHTML(webedescription.Text);


                model.webcopyright = webcopyright.Text;
                if (Bilingualstat.Checked == true)
                {
                    model.Bilingualstat = 1;
                    //双语开启显示后台英文频道
                    setBilingualstat(0);
                }
                else
                {
                    model.Bilingualstat = 0;
                    setBilingualstat(1);
                }
                model.webpath = webpath.Text;
                model.webmanagepath = webmanagepath.Text;
                model.staticstatus = Utils.StrToInt(staticstatus.SelectedValue, 0);
                model.staticextension = staticextension.Text;
                if (mobilestatus.Checked == true)
                {
                    model.mobilestatus = 1;
                }
                else
                {
                    model.mobilestatus = 0;
                }
                model.mobiledomain = mobiledomain.Text;
                if (memberstatus.Checked == true)
                {
                    model.memberstatus = 1;
                }
                else
                {
                    model.memberstatus = 0;
                }
                if (commentstatus.Checked == true)
                {
                    model.commentstatus = 1;
                }
                else
                {
                    model.commentstatus = 0;
                }
                if (logstatus.Checked == true)
                {
                    model.logstatus = 1;
                }
                else
                {
                    model.logstatus = 0;
                }
                if (webstatus.Checked == true)
                {
                    model.webstatus = 1;
                }
                else
                {
                    model.webstatus = 0;
                }
                model.webclosereason = webclosereason.Text;
                model.webcountcode = webcountcode.Text;

                model.smsapiurl = smsapiurl.Text;
                model.smsusername = smsusername.Text;
                //判断密码是否更改
                if (smspassword.Text.Trim() != "" && smspassword.Text.Trim() != defaultpassword)
                {
                    model.smspassword = Utils.MD5(smspassword.Text.Trim());
                }

                model.emailsmtp = emailsmtp.Text;
                model.emailport = Utils.StrToInt(emailport.Text.Trim(), 25);
                model.emailfrom = emailfrom.Text;
                model.emailusername = emailusername.Text;
                //判断密码是否更改
                if (emailpassword.Text.Trim() != defaultpassword)
                {
                    model.emailpassword = DESEncrypt.Encrypt(emailpassword.Text, model.sysencryptstring);
                }
                model.emailnickname = emailnickname.Text;

                model.filepath = filepath.Text;
                model.filesave = Utils.StrToInt(filesave.SelectedValue, 2);
                model.fileextension = fileextension.Text;
                model.attachsize = Utils.StrToInt(attachsize.Text.Trim(), 0);
                model.imgsize = Utils.StrToInt(imgsize.Text.Trim(), 0);
                model.imgmaxheight = Utils.StrToInt(imgmaxheight.Text.Trim(), 0);
                model.imgmaxwidth = Utils.StrToInt(imgmaxwidth.Text.Trim(), 0);
                model.thumbnailheight = Utils.StrToInt(thumbnailheight.Text.Trim(), 0);
                model.thumbnailwidth = Utils.StrToInt(thumbnailwidth.Text.Trim(), 0);
                model.watermarktype = Utils.StrToInt(watermarktype.SelectedValue, 0);
                model.watermarkposition = Utils.StrToInt(watermarkposition.Text.Trim(), 9);
                model.watermarkimgquality = Utils.StrToInt(watermarkimgquality.Text.Trim(), 80);
                model.watermarkpic = watermarkpic.Text;
                model.watermarktransparency = Utils.StrToInt(watermarktransparency.Text.Trim(), 5);
                model.watermarktext = watermarktext.Text;
                model.watermarkfont = watermarkfont.Text;
                model.watermarkfontsize = Utils.StrToInt(watermarkfontsize.Text.Trim(), 12);

                bll.saveConifg(model);
                AddAdminLog(SPEnums.ActionEnum.Edit.ToString(), "修改系统配置信息"); //记录日志
                JscriptMsg("修改系统配置成功！", "sys_config.aspx", "Success");
            }
            catch
            {
                JscriptMsg("文件写入失败，请检查是否有权限！", "", "Error");
            }
        }

        private void setBilingualstat(int stat)
        {
            BLL.navigation bll = new BLL.navigation();
            bll.UpdateField(71, "is_lock=" + stat);
        }


        //删除图片
        protected void btnDelImg_Click(object sender, EventArgs e)
        {    
            int sum = 0; //成功的个数

            try
            {
                List<string> listo = new List<string>();
                listo = GetImgUrlByNmae();  //获取到整个数据库中图片的地址

                //获取本地图片内容 存到 list1 中
                List<string> list1 = new List<string>();
                string filepath = Server.MapPath("/upload1");
                list1 = GetAllDirectories(filepath);

                string newPath = "";
                string oldPath = "";

                //得到两个 list 后，匹配，如果没有则删除
                foreach (string slist in list1)
                {
                    newPath = slist.Replace(@"\", @"/");
                    newPath = newPath.Remove(0, newPath.IndexOf("/upload1/"));
                    oldPath = slist;

                    if (!listo.Contains(newPath))
                    {
                        if (File.Exists(oldPath))
                        {
                            File.Delete(oldPath);
                            sum++;
                        }
                    }
                }

                JscriptMsg("成功删除" + sum + "张图片！", "", "Success");
            }
            catch 
            {
                JscriptMsg("由于未知的原因删除失败！", "", "Error");
            }

        }

        private List<string> GetImgUrlByNmae()
        {
            BLL.article bllArticle = new BLL.article();
            //获取数据库的图片信息  存到 list 中
            List<string> listd = new List<string>();

            DataTable dt = bllArticle.GetImgUrl("dt_article", "img_url").Tables[0]; // dt_article 表 img_url 字段
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["img_url"].ToString());
            }

            dt = bllArticle.GetImgByContent().Tables[0]; // dt_article 表 content 字段
            string content = "";
            string strr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                content = dt.Rows[i]["content"].ToString();
                string[] ss = content.Split(new string[] { "<img src=" }, StringSplitOptions.RemoveEmptyEntries);
                for(int j=0;j<ss.Length;j++)
                {
                    if (i % 2!=0)
                    {
                        strr = ss[i].Substring(0, ss[i].IndexOf("\""));
                        listd.Add(strr.ToString());
                    }
                }
            
            }

            dt = bllArticle.GetImgUrl("dt_article_albums", "thumb_path").Tables[0]; // dt_article_albums 表 thumb_path
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["thumb_path"].ToString());
            }

            dt = bllArticle.GetImgUrl("dt_article_albums", "original_path").Tables[0]; // dt_article_albums 表 original_path
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["original_path"].ToString());
            }

            dt = bllArticle.GetImgUrl("dt_article_attach", "file_path").Tables[0]; // dt_article_attach 表 file_path
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["file_path"].ToString());
            }

            dt = bllArticle.GetImgUrl("dt_article_category", "img_url").Tables[0]; // dt_article_category 表 img_url
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["img_url"].ToString());
            }

            dt = bllArticle.GetImgUrl("dt_link", "img_url").Tables[0]; // dt_link 表 img_url
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["img_url"].ToString());
            }

            dt = bllArticle.GetImgUrl("dt_online_service", "img_url").Tables[0]; // dt_online_service 表 img_url
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["img_url"].ToString());
            }

            dt = bllArticle.GetImgUrl("dt_payment", "img_url").Tables[0]; // dt_payment 表 img_url
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["img_url"].ToString());
            }

            dt = bllArticle.GetImgUrl("dt_user_oauth_app", "img_url").Tables[0]; // dt_user_oauth_app 表 img_url
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["img_url"].ToString());
            }

            dt = bllArticle.GetImgUrl("dt_users", "avatar").Tables[0]; // dt_users 表 avatar
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listd.Add(dt.Rows[i]["avatar"].ToString());
            }

            return listd;
        }

        List<string> list = new List<string>();
        //获取本地图片的路径
        private List<string> GetAllDirectories(string rootPath)
        {
            string[] subPaths = System.IO.Directory.GetDirectories(rootPath);//得到所有子目录
            foreach (string path in subPaths)
            {
                GetAllDirectories(path);//对每一个字目录做与根目录相同的操作：即找到子目录并将当前目录的文件名存入List
            }
            string[] files = System.IO.Directory.GetFiles(rootPath);
            foreach (string file in files)
            {
                string sss=System.IO.Path.GetExtension(file);
                if (sss == ".jpg" || sss == ".png" || sss == ".gif" || sss==".jpge")
                {
                    list.Add(file);//将当前目录中的所有文件全名存入文件List
                }
            }

            return list;
        }

    }
}