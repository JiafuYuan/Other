﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="SPcms.Web.UI.Page.register" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="SPcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by SPcms Template Engine at 2015/3/28 11:12:32.
		本页面代码由SPcms模板引擎生成于 2015/3/28 11:12:32. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>会员注册 - ");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
	templateBuilder.Append("</title>\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webkeyword));
	templateBuilder.Append("\" name=\"keywords\" />\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webdescription));
	templateBuilder.Append("\" name=\"description\" />\r\n<link media=\"screen\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\">\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.10.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/lhgdialog/lhgdialog.js?skin=idialog\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<!--Header-->\r\n");

	templateBuilder.Append("<div class=\"header\">\r\n  <div class=\"header_inner\">\r\n    <h1 class=\"logo\">\r\n      <a title=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
	templateBuilder.Append("\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
	templateBuilder.Append("</a>\r\n    </h1>\r\n    <ul class=\"nav\">\r\n\r\n\r\n    <li><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">首页</a></li>\r\n          ");
	templateBuilder.Append(导航(1).ToString());

	templateBuilder.Append("\r\n       <!-- <li><a href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\">新闻资讯</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\">购物商城</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\">图片分享</a></li>\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\">资源下载</a></li>-->\r\n    </ul>\r\n    <div class=\"search\">\r\n\r\n      <input id=\"keywords\" name=\"keywords\" class=\"input\" type=\"text\" x-webkit-speech=\"\" autofocus=\"\" placeholder=\"输入回车搜索\" onkeydown=\"if(event.keyCode==13){SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');return false};\" />\r\n      <input class=\"submit\" type=\"submit\" value=\"搜索\" onclick=\"SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');\" />\r\n    </div>\r\n    <script type=\"text/javascript\">\r\n        $.ajax({\r\n            type: \"POST\",\r\n            url: \"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_check_login\",\r\n            dataType: \"json\",\r\n            timeout: 20000,\r\n            success: function (data, textStatus) {\r\n                if (data.status == 1) {\r\n                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\">退出</a></li>');\r\n                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">会员中心</a></li>');\r\n                } else {\r\n                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\">注册</a></li>');\r\n                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">登录</a></li>');\r\n                }\r\n            }\r\n        });\r\n    </");
	templateBuilder.Append("script>\r\n    <ul id=\"menu\" class=\"menu\">\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("shopping","cart"));

	templateBuilder.Append("\">购物车<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=view_cart_count\"></");
	templateBuilder.Append("script>件</a></li>\r\n    </ul>\r\n  </div>\r\n</div>");


	templateBuilder.Append("\r\n<!--/Header-->\r\n\r\n<div class=\"boxwrap\">\r\n  <div class=\"main_box\">\r\n    <h1 class=\"main_tit\">\r\n      会员注册<strong>Register</strong>\r\n    </h1>\r\n\r\n    <div class=\"reg-box\">\r\n      <div class=\"reg-top\">\r\n        <ul class=\"step");
	templateBuilder.Append(Utils.ObjectToStr(action));
	templateBuilder.Append("\">\r\n          <li class=\"step1\"><em>1</em>填写会员信息</li>\r\n          ");
	if (uconfig.regverify>0)
	{

	templateBuilder.Append("\r\n          <li class=\"step2\"><em>2</em>验证/审核</li>\r\n          <li class=\"step3\"><em>3</em>注册成功</li>\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n          <li class=\"step3\"><em>2</em>注册成功</li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      ");
	if (action=="")
	{

	templateBuilder.Append("\r\n      <div class=\"reg-con\">\r\n        <!--用户注册-->\r\n        <link rel=\"stylesheet\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("css/validate.css\" />\r\n		<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n        <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n        <script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/js/register_validate.js\"></");
	templateBuilder.Append("script>\r\n        <form id=\"regform\" name=\"regform\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_register\">\r\n          ");
	if (uconfig.regstatus==3)
	{

	templateBuilder.Append("\r\n          <dl>\r\n            <dt><em>*</em>邀请码：</dt>\r\n            <dd>\r\n              <input id=\"txtInviteCode\" name=\"txtInviteCode\" class=\"input wide\" type=\"text\" datatype=\"*\" sucmsg=\" \" />\r\n              <span class=\"Validform_checktip\"></span>\r\n              <i>（仅通过邀请码注册，获取邀请码请联系相关人员。）</i>\r\n            </dd>\r\n          </dl>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          <dl>\r\n            <dt><em>*</em>用户名：</dt>\r\n            <dd>\r\n              <input id=\"txtUserName\" name=\"txtUserName\" class=\"input wide\" type=\"text\" datatype=\"s3-50\" nullmsg=\"请输入用户名\" sucmsg=\" \" ajaxurl=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=validate_username\" />\r\n              <span class=\"Validform_checktip\"></span>\r\n              <i>（5-20位字母、数字或下划线组合，首字符必须为字母。）</i>\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt><em>*</em>密码：</dt>\r\n            <dd>\r\n              <input id=\"txtPassword\" name=\"txtPassword\" class=\"input wide\" type=\"password\" datatype=\"*6-20\" nullmsg=\"请输入密码\" errormsg=\"密码范围在6-20位之间\" sucmsg=\" \" />\r\n              <span class=\"Validform_checktip\"></span>\r\n              <i>（为了您的帐户安全，强烈建议您的密码使用字符+数字等多种不同类型的组合，并且密码长度大于6位。）</i>\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt><em>*</em>确认密码：</dt>\r\n            <dd>\r\n              <input id=\"txtPassword1\" name=\"txtPassword1\" class=\"input wide\" type=\"password\" datatype=\"*\" recheck=\"txtPassword\" nullmsg=\"请再输入一次密码\" errormsg=\"两次输入的密码不一致\" sucmsg=\" \" />\r\n              <span class=\"Validform_checktip\"></span>\r\n              <i>（确保密码输入正确。）</i>\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt><em>*</em>手机号码：</dt>\r\n            <dd>\r\n              <input id=\"txtMobile\" name=\"txtMobile\" class=\"input wide\" type=\"text\" datatype=\"m\" nullmsg=\"请再输入手机号码\" sucmsg=\" \" />\r\n              <span class=\"Validform_checktip\"></span>\r\n              <i>（填写正确的手机号码，忘记密码时可以通过短信找回！）</i>\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt><em>*</em>Email：</dt>\r\n            <dd>\r\n              <input id=\"txtEmail\" name=\"txtEmail\" class=\"input wide\" type=\"text\" datatype=\"e\" nullmsg=\"请再输入邮箱地址\" sucmsg=\" \" />\r\n              <span class=\"Validform_checktip\"></span>\r\n              <i>（填写正确的邮箱地址，忘记密码时可以通过邮箱找回！）</i>\r\n            </dd>\r\n          </dl>\r\n          <dl>\r\n            <dt><em>*</em>验证码：</dt>\r\n            <dd>\r\n              ");
	if (uconfig.regstatus==2)
	{

	templateBuilder.Append("\r\n              <input id=\"txtCode\" name=\"txtCode\" class=\"input small\" type=\"text\" disabled=\"disabled\" datatype=\"s4-20\" style=\"ime-mode:disabled;text-transform:uppercase;\">\r\n              <input id=\"btnSendcode\" type=\"button\" class=\"btn\" value=\"获取验证码\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_register_smscode\" />\r\n              <i>（通过手机短信获取验证码，不区别大小写！）</i>\r\n              ");
	}
	else
	{

	templateBuilder.Append("\r\n              <input id=\"txtCode\" name=\"txtCode\" class=\"input small\" type=\"text\" datatype=\"s4-20\" style=\"ime-mode:disabled;text-transform:uppercase;\">\r\n              <a id=\"verifyCode\" style=\"display:none;\" href=\"javascript:;\" onclick=\"ToggleCode(this, '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx');return false;\"><img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/verify_code.ashx\" width=\"80\" height=\"22\" /> 看不清楚？</a>\r\n              <span class=\"Validform_checktip\"></span>\r\n              <i>（单击显示验证码，不区别大小写！）</i>\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </dd>\r\n          </dl>\r\n          ");
	if (uconfig.regrules==1)
	{

	templateBuilder.Append("\r\n          <dl>\r\n            <dt><em>*</em>注册条款：</dt>\r\n            <dd>\r\n              <input id=\"chkAgree\" type=\"checkbox\" value=\"1\" name=\"chkAgree\">\r\n              <label for=\"chkAgree\">我已仔细阅读并接受<a href=\"javascript:;\" onclick=\"showWindow('regrules');\">注册许可协议</a>。</label>\r\n              <div id=\"regrules\" title=\"注册许可协议\" style=\"display:none;\">");
	templateBuilder.Append(Utils.ObjectToStr(uconfig.regrulestxt));
	templateBuilder.Append("</div>\r\n            </dd>\r\n          </dl>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          <dl>\r\n            <dt></dt>\r\n            <dd>\r\n              ");
	if (uconfig.regrules==1)
	{

	templateBuilder.Append("\r\n              <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" class=\"btn_submit\" value=\"注 册\" disabled=\"disabled\" />\r\n              ");
	}
	else
	{

	templateBuilder.Append("\r\n              <input id=\"btnSubmit\" name=\"btnSubmit\" type=\"submit\" class=\"btn_submit\" value=\"注 册\" />\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </dd>\r\n          </dl>\r\n        </form>\r\n        <!--用户注册-->\r\n      </div>\r\n      ");
	}	//end for if

	if (action=="close")
	{

	templateBuilder.Append("\r\n      <!--关闭会员注册-->\r\n      <div class=\"msg_tips\">\r\n        <div class=\"ico warning\"></div>\r\n        <div class=\"msg\">\r\n          <strong>非常抱歉，系统暂停注册会员服务！</strong>\r\n          <p>由于某些原因，系统暂停注册会员，如对您造成不便之处，我们深感遗憾！</p>\r\n          <p>如需了解开放时间，请联系本站客服或管理员。</p>\r\n          <p>您可以点击这里<a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">返回网站首页</a></p>\r\n        </div>\r\n      </div>\r\n      <!--关闭会员注册-->\r\n      ");
	}	//end for if

	if (action=="sendmail")
	{

	templateBuilder.Append("\r\n      <!--发送邮箱验证-->\r\n      <div class=\"msg_tips\">\r\n        <div class=\"ico warning\"></div>\r\n        <div class=\"msg\">\r\n          <strong>注册成功，您的账户目前处于未验证状态！</strong>\r\n          <p>欢迎您成为本站会员，您的账户目前处于未验证状态，请尽快登录您的注册邮箱激活该会员账户。</p>\r\n          <p>系统已经自动为您发送了一封验证邮件，如果您长时间未收到邮件，请点击这里<a href=\"javascript:;\" onclick=\"SendEmail('");
	templateBuilder.Append(Utils.ObjectToStr(username));
	templateBuilder.Append("', '");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_verify_email');\">重新发送邮件</a>！</p>\r\n          <i>温馨提示：邮件验证有效期为\r\n          ");
	if (uconfig.regemailexpired>0)
	{

	templateBuilder.Append("\r\n          ");
	templateBuilder.Append(Utils.ObjectToStr(uconfig.regemailexpired));
	templateBuilder.Append("天\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n          无限制\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          </i>\r\n        </div>\r\n      </div>\r\n      <!--发送邮箱验证-->\r\n      ");
	}	//end for if

	if (action=="checkmail")
	{

	templateBuilder.Append("\r\n      <!--邮箱验证成功-->\r\n      <div class=\"msg_tips\">\r\n        <div class=\"ico\"></div>\r\n        <div class=\"msg\">\r\n          <strong>恭喜您");
	templateBuilder.Append(Utils.ObjectToStr(username));
	templateBuilder.Append("，已通过邮件激活会员账户</strong>\r\n          <p>您的会员账户已经激活啦，从现在起，你可以享受更多的会员服务，还等什么呢？</p>\r\n          <p>赶快点击这里返回<a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">首页</a>，点击这里<a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">进入会员中心</a>吧！</p>\r\n        </div>\r\n      </div>\r\n      <!--邮箱验证成功-->\r\n      ");
	}	//end for if

	if (action=="checkerror")
	{

	templateBuilder.Append("\r\n      <!--注册验证失败-->\r\n      <div class=\"msg_tips\">\r\n        <div class=\"ico error\"></div>\r\n        <div class=\"msg\">\r\n          <strong>出错啦，该用户不存在或验证已过期！</strong>\r\n          <p>无法验证你的账户，不知神马原因，可能是你的用户名不存在或者验证码已经过期啦！</p>\r\n          <p>不过别担心，如果您还记得你的会员名称的话，点击这里<a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">进入会员中心</a>吧。</p>\r\n        </div>\r\n      </div>\r\n      <!--注册验证失败-->\r\n      ");
	}	//end for if

	if (action=="verify")
	{

	templateBuilder.Append("\r\n      <!--人工审核-->\r\n      <div class=\"msg_tips\">\r\n        <div class=\"ico warning\"></div>\r\n        <div class=\"msg\">\r\n          <strong>账户处于未审核状态，请等待人工审核通过！</strong>\r\n          <p>很抱歉亲爱的，您的会员账户还没有审核通过呢，再等等吧，实在等不及的话请联系本站客服人员！</p>\r\n          <p>由于种种原因，本站不得以暂时开启人工审核，如对您造成不便敬请原谅哦。</p>\r\n          <p>您可以点击这里<a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">返回网站首页</a></p>\r\n        </div>\r\n      </div>\r\n      <!--人工审核-->\r\n      ");
	}	//end for if

	if (action=="succeed")
	{

	templateBuilder.Append("\r\n      <!--注册成功-->\r\n      <div class=\"msg_tips\">\r\n        <div class=\"ico\"></div>\r\n        <div class=\"msg\">\r\n          <strong>恭喜您");
	templateBuilder.Append(Utils.ObjectToStr(username));
	templateBuilder.Append("，成功注册成为本站会员！</strong>\r\n          <p>您已经是本站的会员啦，从现在起，你可以享受更多的会员服务，还等什么呢？</p>\r\n          <p>赶快点击这里返回<a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">首页</a>或点击这里<a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">进入会员中心</a>吧！</p>\r\n        </div>\r\n      </div>\r\n      <!--注册成功-->\r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n\r\n    </div>\r\n\r\n    <div class=\"clear\"></div>\r\n  </div>\r\n</div>\r\n\r\n<div class=\"clear\"></div>\r\n\r\n<!--Footer-->\r\n");

	templateBuilder.Append("<div class=\"footer\">\r\n  <div class=\"footer_inner\">\r\n    <div class=\"foot_nav\">\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">首 页</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\">关于我们</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\">新闻资讯</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\">购物商城</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\">资源下载</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\">图片分享</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("feedback"));

	templateBuilder.Append("\">留言反馈</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("link"));

	templateBuilder.Append("\">友情链接</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a>|\r\n    </div>\r\n    <div class=\"clear\"></div>\r\n    <div class=\"copyright\">\r\n      <p> 版本：V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append(" © Copyright 2013 - 2014. weblink.cn. All Rights Reserved. &nbsp; </p>\r\n    </div>\r\n  </div>\r\n</div>");


	templateBuilder.Append("\r\n<!--/Footer-->\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
