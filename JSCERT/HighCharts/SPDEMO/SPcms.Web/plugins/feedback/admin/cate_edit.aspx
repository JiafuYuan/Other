<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cate_edit.aspx.cs" Inherits="SPcms.Web.Plugin.Feedback.admin.cate_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑投票</title>
    <link type="text/css" rel="stylesheet" href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" />
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/layout.js"></script>
    <script type="text/javascript" src="../../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../../tools/upload_ajax.ashx", flashurl: "../../../scripts/swfupload/swfupload.swf" });
            });
            if ($("#hfxx").val() != "") {
                var num = $("#hfxx").val().split(',');
                var num2 = $("#hfxxxx").val().split(',');
                var zsnum = $(".xx").size();
                if (zsnum < num.length) {
                    for (var i = 0; i < num.length - zsnum; i++) {
                        addxxk();
                    }
                }
                $(".xx").each(function (i) {
                    $(this).val(num[i]);

                })
                $(".xxxx").each(function (i) {
                    $(this).val(num2[i]);

                })
            }
            if ('<%=action %>' == 'View') {

                $("#addxxk").hide();
                $("#img").hide();
            }
            if ('<%=action %>' == 'Edit') {

                $(".xxxx").hide();
            }

        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="index.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>留言类别管理</span>
        <i class="arrow"></i><span>编辑留言类别</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑留言类别</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>类别名称:</dt>
            <dd>
                <asp:TextBox ID="txtcate" runat="server" CssClass="input normal" datatype="*2-100"
                    sucmsg=" "></asp:TextBox></dd>
        </dl>
       
    </div>
  
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" OnClientClick="getxx()" CssClass="btn" OnClick="btnSubmit_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>