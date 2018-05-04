<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emailadd.aspx.cs" Inherits="SPcms.Web.Plugin.mail_send.admin.emailadd" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>回复留言信息</title>
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../../../scripts/datepicker/WdatePicker.js"></script>
<script type="text/javascript" src="../../../scripts/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../../../scripts/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="../../../scripts/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../../editor/lang/zh_CN.js"></script>


<script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/layout.js"></script>
<link type="text/css" rel="stylesheet" href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" />

<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
        //初始化编辑器
        var editor = KindEditor.create('.editor', {
            width: '98%',
            height: '350px',
            resizeType: 1,
            uploadJson: '../../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1',
            fileManagerJson: '../../../tools/upload_ajax.ashx?action=ManagerFile',
            allowFileManager: true
        });
    });
   
   
</script>
</head>
<body class="mainbody" onload="remove_loading();" >
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="index.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>首页</span></a>
  
  <i class="arrow"></i>
  <span>插件管理</span>
  <i class="arrow"></i>
  <span>邮件群发</span>
 
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<%--<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" onclick="tabs(this);" class="selected">查看留言</a></li>
      </ul>
    </div>
  </div>
</div>--%>

<div class="tab-content">
  <dl>
    <dt>收件人：</dt>
    <dd>
        <asp:TextBox ID="txtsjr"   class="input max" datatype="*2-100" sucmsg="" runat="server"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>主题</dt>
    <dd> <asp:TextBox ID="txttitle"  class="input normal" datatype="*2-100" sucmsg=" "  runat="server"></asp:TextBox></dd>
  </dl>
  
  <dl>
    <dt>邮件正文</dt>
    <dd>
     <textarea id="txtContent" class="editor"  style="visibility:hidden;"  runat="server"></textarea>
    </dd>
  </dl>
 
</div>
<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="开始发送" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->
</form>
</body>
</html>
