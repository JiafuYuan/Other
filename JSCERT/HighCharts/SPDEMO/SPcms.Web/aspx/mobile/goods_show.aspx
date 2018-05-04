<%@ Page Language="C#" AutoEventWireup="true" Inherits="SPcms.Web.UI.Page.article_show" ValidateRequest="false" %>
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
	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n");
	string category_title = get_category_title(model.category_id,"新闻中心");

	templateBuilder.Append("\r\n<title>");
	templateBuilder.Append(Utils.ObjectToStr(model.title));
	templateBuilder.Append(" - ");
	templateBuilder.Append(Utils.ObjectToStr(category_title));
	templateBuilder.Append(" - ");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
	templateBuilder.Append("</title>\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.seo_keywords));
	templateBuilder.Append("\" name=\"keywords\" />\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.seo_description));
	templateBuilder.Append("\" name=\"description\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n<!--组件依赖js begin-->\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/touch.js\"></");
	templateBuilder.Append("script>      <!--新版zepto合并版中不包括touch.js-->\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.extend.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.ui.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.iscroll.js\"></");
	templateBuilder.Append("script>   <!--iScroll-->\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.highlight.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/zepto.fix.js\"></");
	templateBuilder.Append("script>\r\n<!--search begin-->\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/quickdelete.js\"></");
	templateBuilder.Append("script>     <!--快速删除组件，配合suggestion使用-->\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/suggestion.js\"></");
	templateBuilder.Append("script>\r\n<!--banner begin-->\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/slider.js\"></");
	templateBuilder.Append("script>\r\n<!--组件依赖js end--> \r\n<!--下拉 begin-->\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/dropmenu.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/button.js\"></");
	templateBuilder.Append("script>\r\n<!--下拉 end--> \r\n<!--加载更多 begin-->\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/refresh.js\"></");
	templateBuilder.Append("script>\r\n<!--返回顶部 begin-->\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/gotop.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
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


	templateBuilder.Append("\r\n<!--导航结束-->\r\n<!--主体开始-->\r\n<div class=\"mainbody\">\r\n    <!--公司简介-->\r\n    <section class=\"main1\">\r\n    	<div class=\"main1_1 clearfix\">\r\n    		<h4 class=\"float_l\"><span class=\"a icon\"></span><span>详细信息</span></h4>\r\n            <div class=\"section float_r\">\r\n                <div id=\"container\">\r\n                    <div class=\"btns\"><a id=\"btn3\" class=\"bat\">菜单</a></div>\r\n                    <div id=\"dropmenu3\">\r\n                        <ul>\r\n                        <li><a href=\"");
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

	templateBuilder.Append("\">给我留言</a></li>\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n			<script>\r\n                $('#btn3').button();\r\n                $('#dropmenu3').dropmenu({\r\n                    align:'right'\r\n                }).dropmenu('bindButton', $('#btn3')).on('itemClick', function (e, item) {\r\n                            alert(item.text);\r\n                        });\r\n                $('body>.section').on('click', function(){//make blank area clickabel\r\n                });\r\n                //创建组件\r\n                $('#dropmenu').gotop();	\r\n            </");
	templateBuilder.Append("script>\r\n        </div>\r\n        <div class=\"proxiangxi\">\r\n        	<h4>");
	templateBuilder.Append(Utils.ObjectToStr(model.title));
	templateBuilder.Append("</h4>\r\n            <div class=\"article\"><span>发表时间：");
	templateBuilder.Append(Utils.ObjectToStr(model.add_time));
	templateBuilder.Append("</span><span>阅读次数：<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=view_article_click&id=");
	templateBuilder.Append(Utils.ObjectToStr(model.id));
	templateBuilder.Append("&click=1\"></");
	templateBuilder.Append("script></span></div>\r\n            <div align=\"center\"> ");
	if (model.img_url!="")
	{

	templateBuilder.Append("\r\n                <a href=\"#\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.img_url));
	templateBuilder.Append("\" /></a>\r\n                ");
	}	//end for if

	templateBuilder.Append("</div>\r\n            <article class=\"nr\">");
	templateBuilder.Append(Utils.ObjectToStr(model.content));
	templateBuilder.Append("</article>\r\n       \r\n          <div>下一篇文章：");
	templateBuilder.Append(get_prevandnext_article("news_show",1,"无下一条",0).ToString());

	templateBuilder.Append("</div>\r\n        </div>\r\n    </section>\r\n    <!--公司简介结束-->\r\n    <div class=\"clear\"></div>\r\n   \r\n    \r\n</div>\r\n<!--导航开始-->\r\n    ");

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


	templateBuilder.Append("\r\n<!--ui:/style:陈媛媛/code:？-->\r\n</body>\r\n");
	templateBuilder.Append(getlinkcode().ToString());

	templateBuilder.Append("</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
