<%@ Page Language="C#" AutoEventWireup="true" Inherits="SPcms.Web.UI.Page.index" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="SPcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by SPcms Template Engine at 2014-05-05 14:25:42.
		本页面代码由SPcms模板引擎生成于 2014-05-05 14:25:42. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <title>");
	templateBuilder.Append(Utils.ObjectToStr(config.webtitle));
	templateBuilder.Append("</title>\r\n    <meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webkeyword));
	templateBuilder.Append("\" name=\"keywords\" />\r\n    <meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webdescription));
	templateBuilder.Append("\" name=\"description\" />\r\n    <link href=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <!--组件依赖js begin-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/touch.js\"></");
	templateBuilder.Append("script>\r\n    <!--新版zepto合并版中不包括touch.js-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.extend.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.ui.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.iscroll.js\"></");
	templateBuilder.Append("script>\r\n    <!--iScroll-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.highlight.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.fix.js\"></");
	templateBuilder.Append("script>\r\n    <!--search begin-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/quickdelete.js\"></");
	templateBuilder.Append("script>\r\n    <!--快速删除组件，配合suggestion使用-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/suggestion.js\"></");
	templateBuilder.Append("script>\r\n    <!--banner begin-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/slider.js\"></");
	templateBuilder.Append("script>\r\n    <!--组件依赖js end-->\r\n    <!--下拉 begin-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/dropmenu.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/button.js\"></");
	templateBuilder.Append("script>\r\n    <!--下拉 end-->\r\n    <!--组件依赖js begin-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/tabs.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/tabs.swipe.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/tabs.ajax.js\"></");
	templateBuilder.Append("script>\r\n    <!--组件依赖js end-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/gotop.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/add2desktop.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n    ");

	templateBuilder.Append("<header class=\"header clearfix\">\r\n	<div class=\"header1 float_l\"><a title=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webtitle));
	templateBuilder.Append("\" href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\"><img src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/images/q.jpg\" alt=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webtitle));
	templateBuilder.Append("\" border=\"0\"/></a></div>\r\n    <div class=\"header2 float_r\"><a href=\"tel:02568158000\"><img src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/images/qq.jpg\" border=\"0\"/></a></div>\r\n</header>\r\n<!--抬头结束-->\r\n<!--搜索-->\r\n<div>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/scripts/base.js\"></");
	templateBuilder.Append("script>\r\n    <div class=\"search\">\r\n        <div class=\"search-input\">\r\n            <input type=\"text\" name=\"keywords\" id=\"keywords\" onkeydown=\"if(event.keyCode==13){SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');return false};\"></div>\r\n        <div class=\"search-button\">\r\n            <input type=\"submit\" value=\"搜索\" onclick=\"SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');\"></div>\r\n    </div>\r\n</div>\r\n<!--搜索结束-->\r\n<!--导航开始-->\r\n<nav class=\"nava clearfix\">\r\n    <ul>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\" class=\"current\">关于我们</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("goods_list","0"));

	templateBuilder.Append("\">产品介绍</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("news_list","33"));

	templateBuilder.Append("\">行业新闻</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("news_list","43"));

	templateBuilder.Append("\">集团新闻</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("ryzz_list","0"));

	templateBuilder.Append("\">荣誉资质</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("content","rczp"));

	templateBuilder.Append("\">人才招聘</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a></li>\r\n      <li class=\"last\"><a href=\"");
	templateBuilder.Append(linkurl("feedback"));

	templateBuilder.Append("\">给我留言</a></li>\r\n    </ul>\r\n</nav>\r\n");


	templateBuilder.Append("\r\n    <!--导航结束-->\r\n    <!--大图开始-->\r\n    <div id=\"slider\">\r\n        ");
	DataTable articalDtzXykd = get_article_list("news", 0, 8, "status=0 and is_slide=1");

	foreach(DataRow drzXykd in articalDtzXykd.Rows)
	{

	templateBuilder.Append("\r\n        <div>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(drzXykd["id"])));

	templateBuilder.Append("\">\r\n                <img lazyload=\"" + Utils.ObjectToStr(drzXykd["img_url"]) + "\"></a>\r\n            <p>\r\n                " + Utils.ObjectToStr(drzXykd["title"]) + "</p>\r\n        </div>\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n    </div>\r\n    <script>\r\n        //创建slider组件\r\n        $('#slider').slider({ loop: true });\r\n    </");
	templateBuilder.Append("script>\r\n    <!--大图结束-->\r\n    <!--主体开始-->\r\n    <div class=\"mainbody\">\r\n        <!--公司简介-->\r\n        <section class=\"main1\">\r\n    	<div class=\"main1_1 clearfix\">\r\n    		<h4 class=\"float_l\"><span class=\"a icon\"></span><span>关于我们</span></h4>\r\n            \r\n			\r\n        </div>\r\n        <article class=\"bgg\">\r\n        	<img src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/images/g.jpg\">");
	templateBuilder.Append(get_article_content("about","zhaiyao").ToString());

	templateBuilder.Append("\r\n            <a href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\">查看更多></a>\r\n        </article>\r\n    </section>\r\n        <!--公司简介结束-->\r\n        <div class=\"clear\">\r\n        </div>\r\n        <!--特色科室-->\r\n        <section class=\"main2\">\r\n    	<div class=\"main1_1 clearfix\">\r\n    		<h4 class=\"float_l\"><span class=\"a icon\"></span><span>产品中心</span></h4>\r\n            <a class=\"float_r\" href=\"");
	templateBuilder.Append(linkurl("goods_list","0"));

	templateBuilder.Append("\"><img src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/images/more.jpg\"></a>\r\n        </div>\r\n        <div class=\"main2_2 clearfix\">\r\n        	\r\n            ");
	DataTable articalDtNbkfR = get_article_list("goods", 0,6, "status=0 and is_red=1");

	foreach(DataRow drNbkfR in articalDtNbkfR.Rows)
	{

	templateBuilder.Append("\r\n    <li><a href=\"");
	templateBuilder.Append(linkurl("goods_show",Utils.ObjectToStr(drNbkfR["id"])));

	templateBuilder.Append("\">\r\n            <dl>\r\n                <dt><a href=\"");
	templateBuilder.Append(linkurl("goods_show",Utils.ObjectToStr(drNbkfR["id"])));

	templateBuilder.Append("\"><img src=\"" + Utils.ObjectToStr(drNbkfR["img_url"]) + "\"/></a></dt>\r\n            </dl>\r\n            ");
	}	//end for if

	templateBuilder.Append("\r\n        </div>\r\n    </section>\r\n        <!--特色科室结束-->\r\n        <!--tab-->\r\n        <section class=\"sectiona\">\r\n    <div id=\"container\">\r\n        <div id=\"tabs1\">\r\n            <ul>\r\n                <li><a href=\"#conten1\">集团新闻</a></li>\r\n                <li><a href=\"../../data/tabs/proxy.php?file=sample.html&debug=1\">行业新闻</a></li>\r\n            </ul>\r\n            <div id=\"conten1\">\r\n            	<ul>\r\n                   ");
	DataTable articalDtYMpNG = get_article_list("news",43, 5, "status=0 and is_red=1");

	foreach(DataRow drYMpNG in articalDtYMpNG.Rows)
	{

	templateBuilder.Append("\r\n                    <li><span class=\"b icon\"></span><a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(drYMpNG["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(drYMpNG["title"]) + "</a></li>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </section>\r\n        <script>\r\n            window.scrollTo(0, 1); //收起地址栏\r\n            $('#tabs1').tabs({\r\n                ajax: {\r\n                    type: 'POST',\r\n                    contentType: 'application/x-www-form-urlencoded'\r\n                },\r\n                beforeLoad: function (e, xhr, settings) {\r\n                    var ui = this;\r\n                    settings.data = $.param({\r\n                        index: ui.data('active')\r\n                    });\r\n                }\r\n            });\r\n        </");
	templateBuilder.Append("script>\r\n        <!--tab结束-->\r\n        <!--专家团队-->\r\n        <section class=\"main3\">\r\n    	<div class=\"main1_1 clearfix\">\r\n    		<h4 class=\"float_l\"><span class=\"a icon\"></span><span>荣誉资质</span></h4>\r\n            <a class=\"float_r\" href=\"");
	templateBuilder.Append(linkurl("ryzz_list","0"));

	templateBuilder.Append("\"><img src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/images/more.jpg\"></a>\r\n        </div>\r\n        <div class=\"main3_2\">\r\n        	\r\n\r\n");
	DataTable articalDtBQmiw = get_article_list("ryzz", 0, 8, "status=0");

	foreach(DataRow drBQmiw in articalDtBQmiw.Rows)
	{

	templateBuilder.Append("\r\n<div class=\"yhn op clearfix\">\r\n            	<div class=\"yhn_1 float_l\"><img src=\"" + Utils.ObjectToStr(drBQmiw["img_url"]) + "\"></div>\r\n                <div class=\"yhn_2 float_l\">\r\n                	<h5>" + Utils.ObjectToStr(drBQmiw["title"]) + "</h5>\r\n                    <p><span class=\"blue\">" + Utils.ObjectToStr(drBQmiw["zhaiyao"]) + "</p>\r\n   \r\n                </div>\r\n            </div>\r\n           ");
	}	//end for if

	templateBuilder.Append("\r\n        </div>\r\n    </section>\r\n        <!--专家团队结束-->\r\n    </div>\r\n    <!--导航开始-->\r\n    ");

	templateBuilder.Append("<nav class=\"navaa clearfix\">\r\n    <ul>\r\n          <li><a href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\" class=\"current\">关于我们</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("goods_list","0"));

	templateBuilder.Append("\">产品介绍</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("news_list","33"));

	templateBuilder.Append("\">行业新闻</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("news_list","43"));

	templateBuilder.Append("\">集团新闻</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("ryzz_list","0"));

	templateBuilder.Append("\">荣誉资质</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("content","rczp"));

	templateBuilder.Append("\">人才招聘</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a></li>\r\n      <li class=\"last\"><a href=\"");
	templateBuilder.Append(linkurl("feedback"));

	templateBuilder.Append("\">给我留言</a></li>\r\n    </ul>\r\n</nav>\r\n<!--导航结束-->\r\n</div>\r\n<div class=\"clear\"></div>\r\n<!--主体结束-->\r\n<footer class=\"footer text_c\">	");
	templateBuilder.Append(get_article_content("bqsy","content").ToString());

	templateBuilder.Append("</footer>\r\n<!--底部悬浮-->\r\n<div id=\"BottomNav\">\r\n	<ul class=\"clearfix\">\r\n        <li><a href=\"tel:02568158000\"><span class=\"aa icon\"></span><span>电话</span></a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("feedback"));

	templateBuilder.Append("\"><span class=\"bb icon\"></span><span>留言</span></a></li>\r\n        <li><a href=\"http://m.mapbar.com/#c=%25E5%258D%2597%25E4%25BA%25AC%25E5%25B8%2582&k=%25E4%25B8%259D%25E7%25BB%25B8%25E5%25A4%25A7%25E5%258E%25A6&wf=ls&pn=1&rn=10\"><span class=\"cc icon\"></span><span>地图</span></a></li>\r\n        <li><a href=\"share.html\"><span class=\"dd icon\"></span><span>分享</span></a></li>\r\n        <li class=\"last\"><a href=\"index.html\"><span class=\"ee icon\"></span><span>搜索</span></a></li>\r\n    </ul>\r\n</div>\r\n<!--返回顶部-->\r\n<div id=\"gotop\"></div>\r\n<script>\r\n    //创建组件\r\n    $('#gotop').gotop();\r\n</");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/jquery-1.4.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/Html5.js\"></");
	templateBuilder.Append("script>");


	templateBuilder.Append("\r\n    <!--ui:/style:陈媛媛/code:？-->\r\n</body>\r\n");
	templateBuilder.Append(getlinkcode().ToString());

	templateBuilder.Append("</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
