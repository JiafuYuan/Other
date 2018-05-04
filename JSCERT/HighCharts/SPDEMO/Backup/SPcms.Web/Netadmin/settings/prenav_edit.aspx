﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prenav_edit.aspx.cs" Inherits="SPcms.Web.Netadmin.settings.prenav_edit" %>

<%@ Import Namespace="SPcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑后台导航</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            $("#cbl").click(function () {

                if ($("#cbl").prop("checked") == true) {
                    var a = $("#txtLinkUrl").val();
                    if (a != "") {
                        a = a.replace(".html", "/0.html");
                    }
                   
                    $("#txtLinkUrl").val(a);
                }

                else {
                    var a = $("#txtLinkUrl").val();
                    if (a != "") {
                        a = a.replace("/0.html", ".html");
                    }
                    $("#txtLinkUrl").val(a);
                }
            })
        });
       
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="nav_list.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="nav_list.aspx">
                <span>导航列表</span></a> <i class="arrow"></i><span>编辑前台导航</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">前台导航信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl runat="server" id="fiddl">
            <dt>上级导航</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:HiddenField ID="hfnid" runat="server" />
                    <asp:HiddenField ID="HDParentId" runat="server" />
                    <asp:HiddenField ID="Hdlayer" Value="0" runat="server" />
                    <asp:DropDownList ID="ddlParentId" runat="server">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>排序数字</dt>
            <dd>
                <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                <span class="Validform_checktip">*数字，越小越向前</span>
            </dd>
        </dl>
        <%-- <dl>
    <dt>是否隐藏</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" />
      </div>
      <span class="Validform_checktip">*隐藏后不显示在界面导航菜单中。</span>
    </dd>
  </dl>--%>
        <dl>
            <dt>导航标题</dt>
            <dd>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-100"
                    sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*导航中文标题，100字符内</span></dd>
        </dl>
        <dl>
            <dt>副标题</dt>
            <dd>
                <asp:TextBox ID="txtSubTitle" runat="server" CssClass="input normal" datatype="*0-100"
                    sucmsg=" " />
                <span class="Validform_checktip">非必填，当导航拥有两个名称时使用</span>
            </dd>
        </dl>
        <dl>
            <dt>链接地址</dt>
            <dd>
                <asp:TextBox ID="txtLinkUrl" runat="server" MaxLength="255" CssClass="input normal" />
                <span class="Validform_checktip">链接地址&nbsp;&nbsp;&nbsp;&nbsp;<input id="cbl" name="cbl"
                    type="checkbox" />无首页</span>
                
            </dd>
        </dl>
        <dl>
            <dt>类名</dt>
            <dd>
                <asp:TextBox ID="txtfclass" runat="server" MaxLength="255" CssClass="input normal" />
                <span class="Validform_checktip">非必填</span>
            </dd>
        </dl>
    </div>
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>