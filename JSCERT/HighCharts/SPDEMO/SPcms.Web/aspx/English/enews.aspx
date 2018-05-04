﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="SPcms.Web.UI.Page.article" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="SPcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by SPcms Template Engine at 2014/5/4 17:03:48.
		本页面代码由SPcms模板引擎生成于 2014/5/4 17:03:48. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	templateBuilder.Append("<!doctype html>\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>南京永乐光电科技有限公司</title>\r\n<link href=\"css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<link href=\"css/commen.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<script type=\"text/javascript\" src=\"js/jquery-1.9.1.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"js/jquery.superslide.2.1.1.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"js/Html5.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n<!--抬头开始-->\r\n<header>\r\n<div id=\"header\" class=\"clearfix\">\r\n	<div class=\"header\">\r\n        <div class=\"header1 float_l\"><a title=\"南京永乐光电科技有限公司\" href=\"#\"><img src=\"images/q.png\" alt=\"南京永乐光电科技有限公司\" border=\"0\"/></a></div>\r\n        <div class=\"header2 float_r\">\r\n            <small class=\"float_r\"><a href=\"index.html\">简体中文</a>&nbsp; | &nbsp;<a href=\"eindex.html\">ENGLISH</a></small>\r\n            <div class=\"search float_r\">\r\n                <input name=\"keywords\" value=\"\" type=\"text\" class=\"text_box\"  onfocus=\"clearText(this)\" onblur=\"clearText(this)\"  />\r\n                <input name=\"keywords\" value=\"\" type=\"button\" class=\"s_but\"/>\r\n                <script language=\"javascript\" type=\"text/javascript\">\r\n                function clearText(field)\r\n                {\r\n                    if (field.defaultValue == field.value) field.value = '';\r\n                    else if (field.value == '') field.value = field.defaultValue;\r\n                }\r\n                </");
	templateBuilder.Append("script>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</header>\r\n<!--抬头结束-->\r\n<div class=\"clear\"></div>\r\n<!--主体-->\r\n<section>\r\n	<!--导航-->\r\n    <div id=\"nav\" class=\"clearfix\">\r\n    	<div class=\"nav\">\r\n            <ul class=\"clearfix\">\r\n                <li><a href=\"eindex.html\">HOME</a></li>\r\n                <li><a href=\"epage.html\">COMPANY</a></li>\r\n                <li><a href=\"eproduct.html\">PRODUCT</a></li>\r\n                <li><a href=\"enews.html\" class=\"current\">NEWS</a></li>\r\n                <li><a href=\"eproduct.html\">HONOR</a></li>\r\n                <li><a href=\"epage.html\">CAREERS</a></li>\r\n                <li><a href=\"emessage.html\">GUESTBOOK</a></li>\r\n                <li class=\"last\"><a href=\"epage.html\">CONTACT US</a></li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n    <!--导航结束-->\r\n    <!--大图-->\r\n    <div id=\"nbanner\">\r\n    	<div class=\"www51buycom\">\r\n            <ul class=\"51buypic\">\r\n                <li><a href=\"#\" target=\"_blank\"><img src=\"images/banner.jpg\" /></a></li>\r\n                <li><a href=\"#\" target=\"_blank\"><img src=\"images/banner2.jpg\" /></a></li>\r\n                <li><a href=\"#\" target=\"_blank\"><img src=\"images/banner.jpg\" /></a></li>\r\n                <li><a href=\"#\" target=\"_blank\"><img src=\"images/banner2.jpg\" /></a></li>\r\n                <li><a href=\"#\" target=\"_blank\"><img src=\"images/banner.jpg\" /></a></li>\r\n                <li><a href=\"#\" target=\"_blank\"><img src=\"images/banner2.jpg\" /></a></li>\r\n                <li><a href=\"#\" target=\"_blank\"><img src=\"images/banner.jpg\" /></a></li>\r\n                <li><a href=\"#\" target=\"_blank\"><img src=\"images/banner2.jpg\" /></a></li>\r\n            </ul>\r\n            <a class=\"prev\" href=\"javascript:void(0)\"></a>\r\n            <a class=\"next\" href=\"javascript:void(0)\"></a>\r\n        </div>\r\n		<script>\r\n		/*鼠标移过，左右按钮显示*/\r\n		$(\".www51buycom\").hover(function(){\r\n			$(this).find(\".prev,.next\").fadeTo(\"show\",0.1);\r\n		},function(){\r\n			$(this).find(\".prev,.next\").hide();\r\n		})\r\n		/*鼠标移过某个按钮 高亮显示*/\r\n		$(\".prev,.next\").hover(function(){\r\n			$(this).fadeTo(\"show\",0.7);\r\n		},function(){\r\n			$(this).fadeTo(\"show\",0.1);\r\n		})\r\n		$(\".www51buycom\").slide({ titCell:\".num ul\" , mainCell:\".51buypic\" , effect:\"fold\", autoPlay:true, delayTime:700 , autoPage:true });\r\n		</");
	templateBuilder.Append("script>\r\n        <div class=\"nmain clearfix\">\r\n        	<div class=\"naside float_l\"><h5>PRODUCT</h5></div>\r\n            <div class=\"nmainbox float_r\"><small>Position：<a href=\"#\">Home</a> - News</small></div>\r\n        </div>\r\n    </div>\r\n    <!--大图结束-->\r\n    <div class=\"clear\"></div>\r\n    <div id=\"nmainbody\" class=\"clearfix\">\r\n    	<!--产品分类-->\r\n    	<div class=\"aside float_l\">\r\n        	<ul>\r\n                <li><a href=\"product.html\" class=\"current\">低压无功补偿元器件</a></li>\r\n                <li><a href=\"product.html\">低压无功补偿成套装置</a></li>\r\n                <li><a href=\"product.html\">高压无功补偿元器件</a></li>\r\n                <li><a href=\"product.html\">高压无功补偿成套装置</a></li>\r\n                <li><a href=\"product.html\">有源滤波无功补偿（SVG）</a></li>\r\n                <li><a href=\"product.html\">智能式电力电容器</a></li>\r\n                <li><a href=\"product.html\">电气知识</a></li>\r\n                <li><a href=\"product.html\">真空断路器</a></li>\r\n            </ul>\r\n            <div class=\"aside2\"><img src=\"images/y.jpg\"></div>\r\n        </div>\r\n        <div class=\"mainbox float_r\">\r\n        	<div class=\"mainbox_2a\">\r\n                    <ul class=\"clearfix\">\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>  \r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>\r\n                        <li class=\"clearfix\"><a class=\"float_l\" href=\"xiangxi.html\">&gt;&gt; 热烈庆祝南京万象瑞盈投资管理有限公司...</a><span class=\"float_r\">[2013-10-21]</span></li>\r\n                    </ul>\r\n                </div>\r\n            <div class=\"clear\"></div>\r\n            <!--分页-->\r\n            <div class=\"sh_page text_c\">\r\n                <a href=\"#\">上一页</a>\r\n                <a href=\"#\" class=\"dangqian\">1</a><a href=\"#\">2</a><a href=\"#\">3</a><a href=\"#\">4</a><a href=\"#\">5</a><a href=\"#\">6</a><a href=\"#\">7</a><a href=\"#\">8</a><a href=\"#\">.222</a>\r\n                <a href=\"#\">下一页</a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!--主体结束-->\r\n<!--产品展示-->\r\n\r\n<div class=\"clear\"></div>\r\n<!--底部-->\r\n<footer>\r\n	<div id=\"footer\">\r\n    	<div class=\"footer\">\r\n    		<p>版权所有：南京永乐光电科技有限公司   苏ICP备123456号<br>电话：025-52777080   电话：025-52777081   地址：南京市江宁区禄口街道蓝天路226号永乐工业园<br>\r\n<a style=\"border-left:4px solid #ff3300; padding-left:3px;\" href=\"http://www.weblink.cn\"  title=\"南京百度推广\">南京百度推广</a> <a href=\"http://www.weblink.cn\" title=\"南京百度公司\">南京百度公司</a> <a href=\"http://www.weblink.cn\" title=\"南京百度总代理\">南京百度总代理</a>提供建站支持</p>\r\n		</div>\r\n    </div>\r\n</footer>\r\n<!--底部结束-->\r\n<!--ui:jxq/style:cyy/code:xcx-->\r\n</body>\r\n");
	templateBuilder.Append(getlinkcode().ToString());

	templateBuilder.Append("</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>