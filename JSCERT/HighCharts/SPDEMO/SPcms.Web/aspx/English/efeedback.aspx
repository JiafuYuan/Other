<%@ Page Language="C#" AutoEventWireup="true" Inherits="SPcms.Web.Plugin.Feedback.feedback" ValidateRequest="false" %>
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
	templateBuilder.Append("<!doctype html>\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>feedback-");
	templateBuilder.Append(Utils.ObjectToStr(config.webetitle));
	templateBuilder.Append("</title>\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webekeyword));
	templateBuilder.Append("\" name=\"keywords\" />\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webedescription));
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

	templateBuilder.Append("\">ENGLISH</a></small>\r\n            <div class=\"search float_r\">\r\n                <input name=\"keywords\" value=\"\" type=\"text\" class=\"text_box\"  onfocus=\"clearText(this)\" onblur=\"clearText(this)\"  />\r\n                <input name=\"keywords\" value=\"\" type=\"button\" class=\"s_but\"/>\r\n                <script language=\"javascript\" type=\"text/javascript\">\r\n                    function clearText(field) {\r\n                        if (field.defaultValue == field.value) field.value = '';\r\n                        else if (field.value == '') field.value = field.defaultValue;\r\n                    }\r\n\r\n                    $(document).ready(function () {\r\n                        var a = document.URL;\r\n                        $(\"#navul li\").each(function () {\r\n                            var b = $(this).children(\"a\")[0].href;\r\n                            if (a.indexOf(b)>0) {\r\n\r\n                                $(this).children(\"a\").addClass(\"current\");\r\n                            }\r\n                            else {\r\n                                $(this).children(\"a\").removeClass(\"current\");\r\n                            }\r\n                        })\r\n                    });\r\n                </");
	templateBuilder.Append("script>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</header>\r\n<!--抬头结束-->\r\n<div class=\"clear\"></div>\r\n<!--主体-->\r\n<section>\r\n	<!--导航-->\r\n    <div id=\"nav\" class=\"clearfix\">\r\n    	<div class=\"nav\">\r\n            <ul id=\"navul\" class=\"clearfix\">\r\n                <li><a href=\"");
	templateBuilder.Append(linkurl("eindex"));

	templateBuilder.Append("\">HOME</a></li>\r\n           ");
	templateBuilder.Append(导航(2).ToString());

	templateBuilder.Append("\r\n            </ul>\r\n        </div>\r\n    </div>\r\n    <!--导航结束-->\r\n    <!--大图-->\r\n    <div id=\"nbanner\">\r\n    	<div class=\"www51buycom\">\r\n            <ul class=\"51buypic\">\r\n                            ");
	DataTable articalDtzXykd = get_article_list("enews", 0, 8, "status=0 and is_slide=1");

	foreach(DataRow drzXykd in articalDtzXykd.Rows)
	{

	templateBuilder.Append("\r\n   <li><a href=\"");
	templateBuilder.Append(linkurl("enews_show",Utils.ObjectToStr(drzXykd["id"])));

	templateBuilder.Append("\" target=\"_blank\"><img src=\"" + Utils.ObjectToStr(drzXykd["img_url"]) + "\" /></a></li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n\r\n            </ul>\r\n            <a class=\"prev\" href=\"javascript:void(0)\"></a>\r\n            <a class=\"next\" href=\"javascript:void(0)\"></a>\r\n        </div>\r\n		<script>\r\n		    /*鼠标移过，左右按钮显示*/\r\n		    $(\".www51buycom\").hover(function () {\r\n		        $(this).find(\".prev,.next\").fadeTo(\"show\", 0.1);\r\n		    }, function () {\r\n		        $(this).find(\".prev,.next\").hide();\r\n		    })\r\n		    /*鼠标移过某个按钮 高亮显示*/\r\n		    $(\".prev,.next\").hover(function () {\r\n		        $(this).fadeTo(\"show\", 0.7);\r\n		    }, function () {\r\n		        $(this).fadeTo(\"show\", 0.1);\r\n		    })\r\n		    $(\".www51buycom\").slide({ titCell: \".num ul\", mainCell: \".51buypic\", effect: \"fold\", autoPlay: true, delayTime: 700, autoPage: true });\r\n		</");
	templateBuilder.Append("script>\r\n   ");


	templateBuilder.Append("\r\n        <div class=\"nmain clearfix\">\r\n        	<div class=\"naside float_l\"><h5>PRODUCT</h5></div>\r\n            <div class=\"nmainbox float_r\"><small>Position：<a href=\"");
	templateBuilder.Append(linkurl("eindex"));

	templateBuilder.Append("\">HOME</a> - MESSAGE</small></div>\r\n        </div>\r\n    </div>\r\n    <!--大图结束-->\r\n    <div class=\"clear\"></div>\r\n    <div id=\"nmainbody\" class=\"clearfix\">\r\n    	<!--产品分类-->\r\n    ");

	templateBuilder.Append("	<div class=\"aside float_l\">\r\n        	<ul>\r\n           ");
	DataTable catedtAMGjG = get_category_child_list("egoods", 0);

	foreach(DataRow drAMGjG in catedtAMGjG.Rows)
	{

	templateBuilder.Append("\r\n  <li><a href=\"");
	templateBuilder.Append(linkurl("egoods_list",Utils.ObjectToStr(drAMGjG["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(drAMGjG["title"]) + "</a></li>\r\n");
	}	//end for if

	templateBuilder.Append("\r\n\r\n\r\n              \r\n            </ul>\r\n            <div class=\"aside2\"><img src=\"");
	templateBuilder.Append("/templates/shuangyu");
	templateBuilder.Append("/images/y.jpg\"></div>\r\n        </div>");


	templateBuilder.Append("\r\n        <div class=\"mainbox float_r\">\r\n        	\r\n                <div class=\"clear\"></div>\r\n                 ");

	templateBuilder.Append("<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/lhgdialog/lhgdialog.js?skin=idialog\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/base.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/style.css\"></");
	templateBuilder.Append("script>\r\n\r\n<script type=\"text/javascript\">\r\n$(function(){\r\n	//初始化发表评论表单\r\n	AjaxInitForm('feedback_form', 'btnSubmit', 1);\r\n});\r\n</");
	templateBuilder.Append("script>\r\n  <div class=\"content\">\r\n      <div class=\"meta\">\r\n        <h1 class=\"meta-tit\">reply</h1>\r\n      </div>\r\n      \r\n      <!--留言列表-->\r\n      <div class=\"comment_box\">\r\n        <ol class=\"comment_list\">\r\n          ");
	DataTable plist = new SPcms.Web.Plugin.Feedback.feedback().get_feedback_list(10, page, "", out totalcount);

	string pagelist = get_page_link(10, page, totalcount, "feedback", "__id__");

	int list__loop__id=0;
	foreach(DataRow list in plist.Rows)
	{
		list__loop__id++;


	templateBuilder.Append("\r\n          <li>\r\n            <div class=\"floor\">#");
	templateBuilder.Append((list__loop__id+10*(page-1)).ToString());

	templateBuilder.Append("</div>\r\n            <div class=\"inner\" style=\"margin-left:0;\">\r\n              <p>" + Utils.ObjectToStr(list["content"]) + "</p>\r\n              <div class=\"meta\">\r\n                <span class=\"blue\">" + Utils.ObjectToStr(list["user_name"]) + "</span>\r\n                <span class=\"time\">" + Utils.ObjectToStr(list["add_time"]) + "</span>\r\n              </div>\r\n            </div>\r\n            \r\n            ");
	if (Utils.ObjectToStr(list["reply_content"])!="")
	{

	templateBuilder.Append("\r\n            <div class=\"answer\" style=\"margin-left:0;\">\r\n              <div class=\"meta\">\r\n                <span class=\"right time\">" + Utils.ObjectToStr(list["reply_time"]) + "</span>\r\n                <span class=\"blue\">Administrator reply：</span>\r\n              </div>\r\n              <p>" + Utils.ObjectToStr(list["reply_content"]) + "</p>\r\n            </div>\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n            \r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          \r\n        </ol>\r\n      </div>\r\n      <div class=\"line10\"></div>\r\n      <div class=\"flickr\">");
	templateBuilder.Append(Utils.ObjectToStr(pagelist));
	templateBuilder.Append("</div> <!--放置页码列表-->\r\n      <!--/留言列表-->\r\n      <div class=\"line10\"></div>\r\n     \r\n      <h3 class=\"base_tit\">Publish the message<a name=\"Add\" id=\"Add\"></a></h3>\r\n      <div class=\"line10\"></div>\r\n      <form id=\"feedback_form\" name=\"feedback_form\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("plugins/feedback/ajax.ashx?action=add\">\r\n     <div class=\"form_box\">\r\n       <dl>\r\n         <dt>NAME：</dt>\r\n         <dd><input id=\"txtUserName\" name=\"txtUserName\" type=\"text\" class=\"input txt\" datatype=\"*\" sucmsg=\" \" /></dd>\r\n       </dl>\r\n       <dl>\r\n         <dt>TEL：</dt>\r\n         <dd><input id=\"txtUserTel\" name=\"txtUserTel\" type=\"text\" class=\"input txt\" datatype=\"*0-20\" sucmsg=\" \" /></dd>\r\n       </dl>\r\n       <dl>\r\n         <dt>QQ：</dt>\r\n         <dd><input id=\"txtUserQQ\" name=\"txtUserQQ\" type=\"text\" class=\"input txt\" datatype=\"*0-20\" sucmsg=\" \" /></dd>\r\n       </dl>\r\n       <dl>\r\n         <dt>EMAIL：</dt>\r\n         <dd><input id=\"txtUserEmail\" name=\"txtUserEmail\" type=\"text\" class=\"input txt\" /></dd>\r\n       </dl>\r\n       <dl>\r\n         <dt>MESSAGE TITLE：</dt>\r\n         <dd><input id=\"txtTitle\" name=\"txtTitle\" type=\"text\" class=\"input txt\" datatype=\"*2-100\" sucmsg=\" \" /></dd>\r\n       </dl>\r\n       <dl>\r\n         <dt>CONTENT：</dt>\r\n         <dd><textarea id=\"txtContent\" name=\"txtContent\" class=\"input txt\" datatype=\"*\" sucmsg=\" \" style=\"width:350px;height:80px;\"></textarea></dd>\r\n       </dl>\r\n       <dl>\r\n         <dt>VALIDCODE：</dt>\r\n         <dd>\r\n           <input id=\"txtCode\" name=\"txtCode\" type=\"text\" class=\"input small\" datatype=\"*\" sucmsg=\" \" />\r\n           <a href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"22\" align=\"absmiddle\" /> 看不清楚？</a>\r\n           <span class=\"Validform_checktip\"></span>\r\n         </dd>\r\n       </dl>\r\n       <dl>\r\n         <dt></dt>\r\n         <dd>\r\n           <input name=\"btnSubmit\" type=\"submit\" value=\"SUBMIT\" class=\"btn_submit\" />\r\n         </dd>\r\n       </dl>\r\n     </div>\r\n     <div class=\"clear\"></div>\r\n     </form>\r\n     \r\n    </div>");


	templateBuilder.Append("\r\n             \r\n               \r\n            \r\n   \r\n    </div>\r\n</section>\r\n<!--主体结束-->\r\n<!--产品展示-->\r\n\r\n<div class=\"clear\"></div>\r\n<!--底部-->\r\n");

	templateBuilder.Append("    <footer>\r\n	<div id=\"footer\">\r\n    	<div class=\"footer\">\r\n    		");
	templateBuilder.Append(get_article_content("ebqsy","content").ToString());

	templateBuilder.Append("\r\n		</div>\r\n    </div>\r\n</footer>");


	templateBuilder.Append("\r\n<!--底部结束-->\r\n<!--ui:jxq/style:cyy/code:xcx-->\r\n</body>\r\n");
	templateBuilder.Append(getlinkcode().ToString());

	templateBuilder.Append("</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
