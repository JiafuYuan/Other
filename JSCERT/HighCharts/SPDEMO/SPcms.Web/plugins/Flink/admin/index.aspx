<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SPcms.Web.Plugin.FLink.admin.index" %>
<%@ Import namespace="SPcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import namespace="SPcms.Common" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>站外连接管理</title>
<link type="text/css" rel="stylesheet" href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" />
<link type="text/css" rel="stylesheet" href="../../../css/pagination.css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/layout.js"></script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>插件管理</span>
  <i class="arrow"></i>
  <span>在线留言</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap" id="gjl" runat="server" >
  <div id="floatHead" class="toolbar" >
    <div class="l-list">
      <ul class="icon-list">
        <li><a runat="server" id="newadd"  href="Flink_edit.aspx?action=<%=SPEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>

        <li><asp:LinkButton ID="btnDelete" runat="server" Visible=false CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
    </div>
    
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
   
    <th align="left" style="padding-left:5px">公司ID</th>
    <th width="30%" align="left">安装代码</th>

    <th width="8%">状态</th>
    <th width="10%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
   
    <td style="padding-left:5px"><%#Eval("id")%></td>
   
    <td><%#Eval("Flinktfcontent").ToString().Replace("<", "&lt;")%></td>
    <td align="center">
    已安装
    </td>
    <td align="center"><a target="_blank"  href="http://<%= siteConfig.remoturl%>/login.aspx?id=<%#Eval("id")%>">修改</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"6\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns" style="display:none">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
