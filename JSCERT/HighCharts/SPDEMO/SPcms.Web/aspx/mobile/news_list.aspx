<%@ Page Language="C#" AutoEventWireup="true" Inherits="SPcms.Web.UI.Page.article_list" ValidateRequest="false" %>
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
	templateBuilder.Append("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    ");
	string category_title = get_category_title(category_id,"新闻资讯");

	templateBuilder.Append("\r\n    <title>");
	templateBuilder.Append(Utils.ObjectToStr(category_title));
	templateBuilder.Append(" - ");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
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
	templateBuilder.Append("script>\r\n    <!--下拉 end-->\r\n    <!--加载更多 begin-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/refresh.js\"></");
	templateBuilder.Append("script>\r\n    <!--返回顶部 begin-->\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/gotop.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/moblie");
	templateBuilder.Append("/js/add2desktop.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n<body>\r\n    <!--抬头开始-->\r\n    ");

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


	templateBuilder.Append("\r\n    <!--导航结束-->\r\n    <!--主体开始-->\r\n    <div class=\"mainbody\">\r\n        <!--公司简介-->\r\n        <section class=\"main1\">\r\n    	<div class=\"main1_1 clearfix\">\r\n    		<h4 class=\"float_l\"><span class=\"a icon\"></span><span>新闻中心</span></h4>\r\n            <div class=\"section float_r\">\r\n                <div id=\"container\">\r\n                    <div class=\"btns\"><a id=\"btn3\" class=\"bat\">导航</a></div>\r\n                    <div id=\"dropmenu3\">\r\n                        <ul>\r\n                        	<li><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">返回首页</a></li>\r\n                                <li><a href=\"");
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

	templateBuilder.Append("\">给我留言</a></li>\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n			<script>\r\n			    $('#btn3').button();\r\n			    $('#dropmenu3').dropmenu({\r\n			        align: 'right'\r\n			    }).dropmenu('bindButton', $('#btn3')).on('itemClick', function (e, item) {\r\n			        alert(item.text);\r\n			    });\r\n			    $('body>.section').on('click', function () {//make blank area clickabel\r\n			    });\r\n			    //创建组件\r\n			    $('#dropmenu').gotop();	\r\n            </");
	templateBuilder.Append("script>\r\n        </div>\r\n        <div class=\"news bgg ui-refresh\">\r\n        	<ul class=\"data-list\">\r\n                ");
	DataTable news_list = get_article_list("news", category_id, page, "status=0", out totalcount, out pagelist, "news_list", category_id, "__id__");

	foreach(DataRow dr in news_list.Rows)
	{

	templateBuilder.Append("\r\n                <li><span class=\"b icon\"></span><a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\"> " + Utils.ObjectToStr(dr["title"]) + "</a></li>\r\n                ");
	}	//end for if

	templateBuilder.Append("\r\n            </ul>\r\n            <input value=\"1\" id=\"page\" type=\"hidden\" />\r\n\r\n            <div class=\"ui-refresh-down more\"></div>\r\n        </div>\r\n        <script type=\"text/javascript\">\r\n            (function () {\r\n                /*组件初始化js begin*/\r\n                $('.ui-refresh').refresh({\r\n                    ready: function (dir, type) {\r\n                        var me = this;\r\n                     var tempstr=\"<li><span class='b icon'></span><a href='temp_url'>temp_title</a></li>\";/*输出模板如果为空也可以*/\r\n                     $(\"#page\").val(parseInt($(\"#page\").val()) + 1);\r\n                        $.getJSON('/tools/moblie_ajax.ashx?action=get_artice_list', { pd: \"news\", cateid: ");
	templateBuilder.Append(category_id.ToString());

	templateBuilder.Append(", page:$(\"#page\").val(),temp:tempstr }, function (data) {\r\n                            var $list = $('.data-list'),\r\n								html = (function (data) {      //数据渲染\r\n								    var liArr = [];\r\n								    $.each(data, function () {\r\n								        liArr.push(this.html);\r\n								    });\r\n								    return liArr.join('');\r\n								})(data);\r\n\r\n                            $list[dir == 'up' ? 'prepend' : 'append'](html);\r\n                            me.afterDataLoading();    //数据加载完成后改变状态\r\n                        });\r\n                    }\r\n                });\r\n                /*组件初始化js end*/\r\n            })();\r\n	</");
	templateBuilder.Append("script>\r\n    </section>\r\n        <!--公司简介结束-->\r\n        <div class=\"clear\">\r\n        </div>\r\n    </div>\r\n    <!--导航开始-->\r\n    ");

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

	templateBuilder.Append("</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
