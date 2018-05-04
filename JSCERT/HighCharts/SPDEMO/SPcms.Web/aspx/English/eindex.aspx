<%@ Page Language="C#" AutoEventWireup="true" Inherits="SPcms.Web.UI.Page.index" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="SPcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by SPcms Template Engine at 2014/5/4 17:03:47.
		本页面代码由SPcms模板引擎生成于 2014/5/4 17:03:47. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	templateBuilder.Append("<!doctype html>\r\n<html>\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <title>");
	templateBuilder.Append(Utils.ObjectToStr(config.webetitle));
	templateBuilder.Append("</title>\r\n    <meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webekeyword));
	templateBuilder.Append("\" name=\"keywords\" />\r\n    <meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webedescription));
	templateBuilder.Append("\" name=\"description\" />\r\n    <link href=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link href=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/css/commen.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/js/jquery-1.9.1.min.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/js/jquery.superslide.2.1.1.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/js/Html5.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n    <!--抬头开始-->\r\n    ");

	templateBuilder.Append("<header>\r\n<div id=\"header\" class=\"clearfix\">\r\n	<div class=\"header\">\r\n        <div class=\"header1 float_l\"><a title=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webtitle));
	templateBuilder.Append("\" href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/images/q.png\" alt=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webtitle));
	templateBuilder.Append("\" border=\"0\"/></a></div>\r\n        <div class=\"header2 float_r\">\r\n            <small class=\"float_r\"><a href=\"index.html\">简体中文</a>&nbsp; | &nbsp;<a href=\"");
	templateBuilder.Append(linkurl("Eindex"));

	templateBuilder.Append("\">ENGLISH</a></small>\r\n            <div class=\"search float_r\">\r\n                <input name=\"keywords\" value=\"\" type=\"text\" class=\"text_box\"  onfocus=\"clearText(this)\" onblur=\"clearText(this)\"  />\r\n                <input name=\"keywords\" value=\"\" type=\"button\" class=\"s_but\"/>\r\n                <script language=\"javascript\" type=\"text/javascript\">\r\n                    function clearText(field) {\r\n                        if (field.defaultValue == field.value) field.value = '';\r\n                        else if (field.value == '') field.value = field.defaultValue;\r\n                    }\r\n                </");
	templateBuilder.Append("script>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</header>\r\n    <!--抬头结束-->\r\n    <div class=\"clear\">\r\n    </div>\r\n    <!--主体-->\r\n    <section>\r\n	<!--导航-->\r\n    <div id=\"nav\" class=\"clearfix\">\r\n    	<div class=\"nav\">\r\n            <ul class=\"clearfix\">\r\n                <li><a href=\"");
	templateBuilder.Append(linkurl("eindex"));

	templateBuilder.Append("\" class=\"current\">HOME</a></li>\r\n              <!--  <li><a href=\"page.html\">公司简介</a></li>\r\n                <li><a href=\"product.html\">产品展厅</a></li>\r\n                <li><a href=\"news.html\">新闻动态</a></li>\r\n                <li><a href=\"product.html\">资质荣誉</a></li>\r\n                <li><a href=\"page.html\">人才招聘</a></li>\r\n                <li><a href=\"message.html\">在线留言</a></li>\r\n                <li class=\"last\"><a href=\"page.html\">联系我们</a></li>-->\r\n                ");
	templateBuilder.Append(导航(2).ToString());

	templateBuilder.Append("\r\n            </ul>\r\n        </div>\r\n    </div>\r\n    <!--导航结束-->\r\n    <!--大图-->\r\n    <div id=\"banner\">\r\n    	<div class=\"www51buycom\">\r\n            <ul class=\"51buypic\">\r\n             ");
	DataTable articalDtzXykd = get_article_list("ENews", 0, 8, "status=0 and is_slide=1");

	foreach(DataRow drzXykd in articalDtzXykd.Rows)
	{

	templateBuilder.Append("\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("enews_show",Utils.ObjectToStr(drzXykd["id"])));

	templateBuilder.Append("\" target=\"_blank\"><img src=\"" + Utils.ObjectToStr(drzXykd["img_url"]) + "\" /></a></li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n\r\n\r\n             \r\n            </ul>\r\n            <a class=\"prev\" href=\"javascript:void(0)\"></a>\r\n            <a class=\"next\" href=\"javascript:void(0)\"></a>\r\n        </div>\r\n		<script>\r\n		    /*鼠标移过，左右按钮显示*/\r\n		    $(\".www51buycom\").hover(function () {\r\n		        $(this).find(\".prev,.next\").fadeTo(\"show\", 0.1);\r\n		    }, function () {\r\n		        $(this).find(\".prev,.next\").hide();\r\n		    })\r\n		    /*鼠标移过某个按钮 高亮显示*/\r\n		    $(\".prev,.next\").hover(function () {\r\n		        $(this).fadeTo(\"show\", 0.7);\r\n		    }, function () {\r\n		        $(this).fadeTo(\"show\", 0.1);\r\n		    })\r\n		    $(\".www51buycom\").slide({ titCell: \".num ul\", mainCell: \".51buypic\", effect: \"fold\", autoPlay: true, delayTime: 700, autoPage: true });\r\n		</");
	templateBuilder.Append("script>\r\n        <div class=\"ks clearfix\" align=\"center\">\r\n           <a href=\"");
	templateBuilder.Append(linkurl("egoods","0"));

	templateBuilder.Append("\" class=\"ks11 ma_l2 float_l\"></a>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("eryzz","0"));

	templateBuilder.Append("\" class=\"ks22 ma_l2 float_l\"></a>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("econtent","erczp"));

	templateBuilder.Append("\" class=\"ks33 ma_l2 float_l\"></a>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("efeedback"));

	templateBuilder.Append("\" class=\"ks44 ma_l2 float_l\"></a>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("content","elxwm"));

	templateBuilder.Append("\" class=\"ks55 ma_l2 float_r\"></a>\r\n        </div>\r\n    </div>\r\n    <!--大图结束-->\r\n    <div class=\"clear\"></div>");


	templateBuilder.Append("\r\n    <div id=\"mainbody\">\r\n        <div class=\"main1 clearfix\">\r\n            <!--公司简介-->\r\n            <div class=\"main1a float_l\">\r\n                <div class=\"lan clearfix\">\r\n                    <h5 class=\"float_l\">\r\n                        COMPANY PROFILE</h5>\r\n                    <a class=\"float_r\" href=\"");
	templateBuilder.Append(linkurl("econtent","eabout"));

	templateBuilder.Append("\">\r\n                        <img src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/images/e.gif\"></a></div>\r\n                <div class=\"main1a_2\">\r\n                    <p>\r\n                        <img src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/images/w.jpg\">");
	templateBuilder.Append(get_article_content("eabout","zhaiyao").ToString());

	templateBuilder.Append("</p>\r\n                </div>\r\n            </div>\r\n            <!--新闻-->\r\n            <div class=\"main1b clearfix float_r \">\r\n                <div class=\"qqq float_l\">\r\n                    <ul class=\"tab_h_2a\">\r\n                        <li class=\"vary\">集团新闻<span><a href=\"");
	templateBuilder.Append(linkurl("enews_list","43"));

	templateBuilder.Append("\">+MORE</a></span></li>\r\n                        <li>行业新闻<span><a href=\"");
	templateBuilder.Append(linkurl("enews_list","33"));

	templateBuilder.Append("\">+MORE</a></span></li>\r\n                    </ul>\r\n                </div>\r\n                <div class=\"tab_c_2a float_l\">\r\n                    <div class=\"m clearfix\">\r\n                        <div class=\"m1 float_l\">\r\n                         \r\n");
	DataTable articalDtYMpNG = get_article_list("enews",43, 1, "status=0 and is_red=1");

	foreach(DataRow drYMpNG in articalDtYMpNG.Rows)
	{

	templateBuilder.Append("\r\n   <img style=\"width:126px; height:91px\" src=\" " + Utils.ObjectToStr(drYMpNG["img_url"]) + "\"></div>\r\n                        <div class=\"m2 float_r\">\r\n                            <h5>\r\n                             " + Utils.ObjectToStr(drYMpNG["title"]) + "</h5>\r\n                            <p>\r\n                              " + Utils.ObjectToStr(drYMpNG["zhaiyao"]) + "</p>\r\n                        </div>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n                    </div>\r\n                    <ul>\r\n");
	DataTable articalDtpeejr = get_article_list("enews", 33,3,"status=0 and is_red=1");

	foreach(DataRow drpeejr in articalDtpeejr.Rows)
	{

	templateBuilder.Append("\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(drpeejr["id"])));

	templateBuilder.Append("\">· " + Utils.ObjectToStr(drpeejr["title"]) + "</a><span\r\n                            class=\"float_r\">");	templateBuilder.Append(Utils.ObjectToDateTime(Utils.ObjectToStr(drpeejr["add_time"])).ToString("yyyy-MM-dd"));

	templateBuilder.Append("</span></li>\r\n                      \r\n");
	}	//end for if

	templateBuilder.Append("\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n            <script type=\"text/javascript\">\r\n				<!--\r\n                $(\".tab_c_2a\").eq(0).show();\r\n                $(\".tab_h_2a li\").click(function () {\r\n                    $(this).addClass(\"vary\").siblings(\"li\").removeClass(\"vary\");\r\n                    var varyTab = $(\".tab_h_2a li\").index(this);\r\n                    $(\".tab_c_2a\").eq(varyTab).show().siblings(\".tab_c_2a\").hide();\r\n                });\r\n				-->\r\n            </");
	templateBuilder.Append("script>\r\n        </div>\r\n    </div>\r\n    </section>\r\n    <!--主体结束-->\r\n    <!--产品展示-->\r\n    <div id=\"main2\">\r\n        <div class=\"text_c pa_t\">\r\n            <img src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/images/r.gif\"></div>\r\n        <div class=\"main2\">\r\n            <div id=\"demo\">\r\n                <div id=\"indemo\">\r\n                    <div id=\"demo1\">\r\n                        <ul class=\"clearfix product1\">\r\n                          ");
	DataTable articalDtNbkfR = get_article_list("egoods", 0,100, "status=0 and is_red=1");

	foreach(DataRow drNbkfR in articalDtNbkfR.Rows)
	{

	templateBuilder.Append("\r\n    <li><a href=\"");
	templateBuilder.Append(linkurl("egoods_show",Utils.ObjectToStr(drNbkfR["id"])));

	templateBuilder.Append("\">\r\n                                <img src=\"" + Utils.ObjectToStr(drNbkfR["img_url"]) + "\" /></a><a href=\"");
	templateBuilder.Append(linkurl("egoods_show",Utils.ObjectToStr(drNbkfR["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(drNbkfR["title"]) + "</a></li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n\r\n                        </ul>\r\n                    </div>\r\n                    <div id=\"demo2\">\r\n                    </div>\r\n                    <script>\r\n                <!--\r\n                        var speed = 50; //数字越大速度越慢\r\n                        var tab = document.getElementById(\"demo\");\r\n                        var tab1 = document.getElementById(\"demo1\");\r\n                        var tab2 = document.getElementById(\"demo2\");\r\n                        tab2.innerHTML = tab1.innerHTML;\r\n                        function Marquee() {\r\n                            if (tab2.offsetWidth - tab.scrollLeft <= 0)\r\n                                tab.scrollLeft -= tab1.offsetWidth\r\n                            else {\r\n                                tab.scrollLeft++;\r\n                            }\r\n                        }\r\n                        var MyMar = setInterval(Marquee, speed);\r\n                        tab.onmouseover = function () {\r\n                            clearInterval(MyMar)\r\n                        };\r\n                        tab.onmouseout = function () {\r\n                            MyMar = setInterval(Marquee, speed)\r\n                        };\r\n                -->\r\n                    </");
	templateBuilder.Append("script>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"clear\">\r\n    </div>\r\n    <!--底部-->\r\n ");

	templateBuilder.Append("    <footer>\r\n	<div id=\"footer\">\r\n    	<div class=\"footer\">\r\n    		");
	templateBuilder.Append(get_article_content("ebqsy","content").ToString());

	templateBuilder.Append("\r\n		</div>\r\n    </div>\r\n</footer>");


	templateBuilder.Append("\r\n    <!--底部结束-->\r\n    <!--ui:jxq/style:cyy/code:xcx-->\r\n</body>\r\n");
	templateBuilder.Append(getlinkcode().ToString());

	templateBuilder.Append("</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
