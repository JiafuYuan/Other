<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="weixin_manage.aspx.cs" Inherits="SPcms.Web.Netadmin.weixin.weixin_manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>微信管理员设置</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>

</head>
<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>微信公众平台</span>
  <i class="arrow"></i>
  <span>微信管理员</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息设置</a></li>
      </ul>
    </div>
  </div>
</div>

<!--用户参数设置-->
<div class="tab-content">

  <dl>
    <dt>微信公众号类型</dt>
    <dd>
      <div class="rule-multi-radio">
        <asp:RadioButtonList ID="regverify" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
        <asp:ListItem Value="0" Selected="True">订阅号</asp:ListItem>
        <asp:ListItem Value="1">服务号</asp:ListItem>
        <asp:ListItem Value="2">企业号</asp:ListItem>
        </asp:RadioButtonList>
      </div>
    </dd>
  </dl>

  <dl>
    <dt>用户名</dt>
    <dd>
      <asp:TextBox ID="txtUsrename" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*微信公众登录账号</span>
    </dd>
  </dl>

  <dl>
    <dt>密码</dt>
    <dd>
      <asp:TextBox ID="txtUserPad" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*微信公众登录密码</span>
    </dd>
  </dl>

  <dl>
    <dt>AppID</dt>
    <dd>
      <asp:TextBox ID="txtAppID" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*应用ID</span>
    </dd>
  </dl>

  <dl>
    <dt>AppSecret</dt>
    <dd>
      <asp:TextBox ID="txtAppSecret" runat="server" CssClass="input normal" />
      <span class="Validform_checktip">*应用密钥</span>
    </dd>
  </dl>
  
</div>
<!--/用户参数设置-->

<!--内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
