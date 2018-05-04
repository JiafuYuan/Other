<%@ Page Language="C#" AutoEventWireup="true" Inherits="SPcms.Web.UI.Page.article_list" ValidateRequest="false" %>
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
	templateBuilder.Append("<!doctype html>\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n   ");
	string category_title = get_category_title(category_id,"荣誉资质");

	templateBuilder.Append("\r\n<title>");
	templateBuilder.Append(Utils.ObjectToStr(category_title));
	templateBuilder.Append(" -");
	templateBuilder.Append(Utils.ObjectToStr(config.webtitle));
	templateBuilder.Append("</title>\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webkeyword));
	templateBuilder.Append("\" name=\"keywords\" />\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webdescription));
	templateBuilder.Append("\" name=\"description\" />\r\n\r\n<link href=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/css/commen.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/js/jquery-1.9.1.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/js/jquery.superslide.2.1.1.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/js/Html5.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n<!--抬头开始-->\r\n");

	templateBuilder.Append("<header>\r\n<div id=\"header\" class=\"clearfix\">\r\n	<div class=\"header\">\r\n        <div class=\"header1 float_l\"><a title=\"南京永乐光电科技有限公司\" href=\"#\"><img src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/images/q.png\" alt=\"南京永乐光电科技有限公司\" border=\"0\"/></a></div>\r\n        <div class=\"header2 float_r\">\r\n            <small class=\"float_r\"><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">简体中文</a>&nbsp; | &nbsp;<a href=\"");
	templateBuilder.Append(linkurl("eindex"));

	templateBuilder.Append("\">ENGLISH</a></small>\r\n            <div class=\"search float_r\">\r\n                <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/base.js\"></");
	templateBuilder.Append("script>\r\n                <input name=\"keywords\" id=\"keywords\" value=\"\" type=\"text\" class=\"text_box\"  onkeydown=\"if(event.keyCode==13){SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');return false};\" onfocus=\"clearText(this)\" onblur=\"clearText(this)\"  />\r\n                <input name=\"btn\" value=\"\"  onclick=\"SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');\"  type=\"button\" class=\"s_but\"/>\r\n                <script language=\"javascript\" type=\"text/javascript\">\r\n                    function clearText(field) {\r\n                        if (field.defaultValue == field.value) field.value = '';\r\n                        else if (field.value == '') field.value = field.defaultValue;\r\n                    }\r\n\r\n                    $(document).ready(function () {\r\n                        var a = document.URL;\r\n                        $(\"#navul li\").each(function () {\r\n                            var b = $(this).children(\"a\")[0].href;\r\n                            if (a.indexOf(b)>0) {\r\n\r\n                                $(this).children(\"a\").addClass(\"current\");\r\n                            }\r\n                            else {\r\n                                $(this).children(\"a\").removeClass(\"current\");\r\n                            }\r\n                        })\r\n                    });\r\n                </");
	templateBuilder.Append("script>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</header>\r\n<!--抬头结束-->\r\n<div class=\"clear\"></div>\r\n<!--主体-->\r\n<section>\r\n	<!--导航-->\r\n    <div id=\"nav\" class=\"clearfix\">\r\n    	<div class=\"nav\">\r\n            <ul id=\"navul\" class=\"clearfix\">\r\n                <li><a href=\"/index.html\">网站首页</a></li>\r\n           ");
	templateBuilder.Append(导航(1).ToString());

	templateBuilder.Append("\r\n            </ul>\r\n        </div>\r\n    </div>\r\n    <!--导航结束-->\r\n    <!--大图-->\r\n    <div id=\"nbanner\">\r\n    	<div class=\"www51buycom\">\r\n            <ul class=\"51buypic\">\r\n                            ");
	DataTable articalDtzXykd = get_article_list("news", 0, 8, "status=0 and is_slide=1");

	foreach(DataRow drzXykd in articalDtzXykd.Rows)
	{

	templateBuilder.Append("\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(drzXykd["id"])));

	templateBuilder.Append("\" target=\"_blank\"><img src=\"" + Utils.ObjectToStr(drzXykd["img_url"]) + "\" /></a></li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n\r\n            </ul>\r\n            <a class=\"prev\" href=\"javascript:void(0)\"></a>\r\n            <a class=\"next\" href=\"javascript:void(0)\"></a>\r\n        </div>\r\n		<script>\r\n		    /*鼠标移过，左右按钮显示*/\r\n		    $(\".www51buycom\").hover(function () {\r\n		        $(this).find(\".prev,.next\").fadeTo(\"show\", 0.1);\r\n		    }, function () {\r\n		        $(this).find(\".prev,.next\").hide();\r\n		    })\r\n		    /*鼠标移过某个按钮 高亮显示*/\r\n		    $(\".prev,.next\").hover(function () {\r\n		        $(this).fadeTo(\"show\", 0.7);\r\n		    }, function () {\r\n		        $(this).fadeTo(\"show\", 0.1);\r\n		    })\r\n		    $(\".www51buycom\").slide({ titCell: \".num ul\", mainCell: \".51buypic\", effect: \"fold\", autoPlay: true, delayTime: 700, autoPage: true });\r\n		</");
	templateBuilder.Append("script>\r\n   ");


	templateBuilder.Append("\r\n        <div class=\"nmain clearfix\">\r\n        	<div class=\"naside float_l\"><h5>产品目录</h5></div>\r\n            <div class=\"nmainbox float_r\"><small>当前位置：<a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">首页</a> - 荣誉资质</small></div>\r\n        </div>\r\n    </div>\r\n    <!--大图结束-->\r\n    <div class=\"clear\"></div>\r\n    <div id=\"nmainbody\" class=\"clearfix\">\r\n    	<!--产品分类-->\r\n    \r\n               ");

	templateBuilder.Append("	<div class=\"aside float_l\">\r\n        	<ul>\r\n           ");
	DataTable catedtAMGjG = get_category_child_list("goods", 0);

	foreach(DataRow drAMGjG in catedtAMGjG.Rows)
	{

	templateBuilder.Append("\r\n  <li><a href=\"");
	templateBuilder.Append(linkurl("goods_list",Utils.ObjectToStr(drAMGjG["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(drAMGjG["title"]) + "</a></li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n\r\n\r\n              \r\n            </ul>\r\n            <div class=\"aside2\"><img src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/images/y.jpg\"></div>\r\n        </div>");


	templateBuilder.Append("\r\n           \r\n        <div class=\"mainbox float_r\">\r\n        	<div class=\"mainbox_2a\">\r\n                   ");
	DataTable news_list = get_article_list("ryzz", category_id, page, "status=0", out totalcount, out pagelist, "ryzz_list", category_id, "__id__");

	foreach(DataRow dr in news_list.Rows)
	{

	templateBuilder.Append("\r\n\r\n                    <dl>\r\n                        <dt><a href=\"");
	templateBuilder.Append(linkurl("ryzz_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\"><img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\"/></a></dt>\r\n                        <dd><a href=\"");
	templateBuilder.Append(linkurl("ryzz_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(dr["title"]) + "</a></dd>\r\n                    </dl>\r\n\r\n");
	}	//end for if

	templateBuilder.Append("\r\n                </div>\r\n            <div class=\"clear\"></div>\r\n            <!--分页-->\r\n            <div class=\"sh_page text_c\">\r\n              ");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!--主体结束-->\r\n<!--产品展示-->\r\n\r\n<div class=\"clear\"></div>\r\n<!--底部-->\r\n");

	templateBuilder.Append("    <footer>\r\n	<div id=\"footer\">\r\n    	<div class=\"footer\">\r\n    		");
	templateBuilder.Append(get_article_content("bqsy","content").ToString());

	templateBuilder.Append("\r\n		</div>\r\n    </div>\r\n</footer>");


	templateBuilder.Append("\r\n<!--底部结束-->\r\n<!--ui:jxq/style:cyy/code:xcx-->\r\n</body>\r\n");
	templateBuilder.Append(getlinkcode().ToString());

	templateBuilder.Append("</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
