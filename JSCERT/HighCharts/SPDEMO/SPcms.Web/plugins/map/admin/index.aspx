<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SPcms.Web.Plugin.map.admin.index" %>

<%@ Import Namespace="SPcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>地图管理</title>
    <link type="text/css" rel="stylesheet" href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" />
    <link type="text/css" rel="stylesheet" href="../../../css/pagination.css" />
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/layout.js"></script>
   <script type="text/javascript">
       $(function () {
           $("#btnCopy").bind("click", function () {
              
               window.clipboardData.setData("Text", $("#txtCopyUrl").val());
               alert("已将代码复制至剪切板，请将其贴粘到指定位置即可。");
           });
       });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx" class="home"><i></i><span>
            首页</span></a> <i class="arrow"></i><span>地图管理</span> <i class="arrow"></i><span>百度地图</span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <!--/工具栏-->
    <!--列表展示.开始-->
    <table  width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
        <tr>
            <th width="150px" align="center">
                名称
            </th>
            <th>
            </th>
            <th width="15%">
                操作
            </th>
        </tr>
        <tr>
            <td align="center" width="150px">
                PC端地图
            </td>
            <td>
            </td>
            <td align="">
                <a href="?id=1" >调用</a>&nbsp; <a href="mappc.aspx">编辑</a>
            </td>
        </tr>
        <tr>
            <td align="center" width="150px">
                移动端地图
            </td>
            <td>
            </td>
            <td align="">
                <a href="?id=2">调用</a>&nbsp; <a href="mapmobile.aspx">编辑</a>
            </td>
        </tr>
    </table>
    <div id="code" class="tab-content">
       
        <dl>
            <dt>复制代码</dt>
            <dd>
                <textarea id="txtCopyUrl" class="input" style="vertical-align: middle;"> <%=str %> </textarea>
                &nbsp;<input id="btnCopy" type="button" value="复制代码" class="btn" style="vertical-align: middle;" />
            </dd>
        </dl>
        <dl>
            <dt>调用说明</dt>
            <dd>
                <div style="color: #060;">
                    1、直接粘贴到编辑器的代码里即可；<br />
                    2、可以通过编辑按钮进行公司名称和公司简介地址等信息的编辑
                    
                </div>
            </dd>
        </dl>
    </div>
    <!--列表展示.结束-->
    <!--内容底部-->
    <div class="line20">
    </div>
    <!--/内容底部-->
    </form>
</body>
</html>
