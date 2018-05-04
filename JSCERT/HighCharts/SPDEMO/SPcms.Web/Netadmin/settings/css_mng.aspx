<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="css_mng.aspx.cs" Inherits="SPcms.Web.Netadmin.settings.css_mng" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>css样式管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script src="../../scripts/jquery/jquery.jqzoom.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //只能选中一项
            $(".checkall input").click(function () {
                $(".checkall input").prop("checked", false);
                $(this).prop("checked", true);
            });
            //管理图片放大
            var x = 10;
            var y = 20;
            $(".imgtip").mouseover(function (e) {


                if (e.pageY > $(document.body).height() - 100) {
                    y = -150;
                }
                else {
                    y = 20;
                }
                this.myTitle = this.title;
                this.title = "";
                var imgtip = "<div id='imgtip'><img src='" + $(this).attr("bigimg") + "' width='300' alt='预览图'/><\/div>"; //创建 div 元素
                $("body").append(imgtip); //把它追加到文档中						 
                $("#imgtip")
			    .css({
			        "top": (e.pageY + y) + "px",
			        "left": (e.pageX + x) + "px"
			    }).show("fast");   //设置x坐标和y坐标，并且显示
            }).mouseout(function () {
                this.title = this.myTitle;
                $("#imgtip").remove();  //移除 
            }).mousemove(function (e) {
                $("#imgtip")
			    .css({
			        "top": (e.pageY + y) + "px",
			        "left": (e.pageX + x) + "px"
			    });
            });

        });
       

    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="#none" onclick="javascript:window.mainframe.history.back();"  class="back"><i></i><span>返回上一页</span></a>
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>应用管理</span> <i class="arrow"></i><span>样式管理</span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <li>
                        <asp:TextBox ID="txtname" CssClass="input" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="btnManage" runat="server" CssClass="folder" OnClick="btnManage_Click"><i></i><span>查询</span></asp:LinkButton>
                         <asp:LinkButton ID="btnsc" runat="server" CssClass="folder" 
                            onclick="btnsc_Click"><i></i><span>生成当前模板</span></asp:LinkButton>
                        </li>
              
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
                    <th width="8%">
                        选择
                    </th>
                    <th align="left" width="15%">
                        模板名称
                    </th>
                    <th width="5%">
                        作者
                    </th>
                    <th width="16%">
                        创建日期
                    </th>
                    <th width="12%">
                        版本号
                    </th>
                    <th align="left">
                        调用代码
                    </th>
                    <th width="10%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                    <asp:HiddenField ID="hideSkinName" runat="server" Value='<%#Eval("skinname")%>' />
                </td>
                <td  >
                    <%#Eval("name")%><img src="../skin/default/icon_view.gif" bigimg="<%#Eval("img")%>" title="查看预览图" class="imgtip" />
                </td>
                <td align="center">
                    <%#Eval("author")%>
                </td>
                <td align="center">
                    <%#Eval("createdate")%>
                </td>
                <td align="center">
                    <%#Eval("version")%>
                </td>
                <td>
                    &lt;%template src="../sys/<%#Eval("name")%>/index.html"%>
                </td>
                <td align="center">
                    <a href="css_file_edit.aspx?path=sys/<%#Eval("name")%>&filename=index.html">管理</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <!--/列表-->
    <!--列表-->

    <!--/列表-->
    </form>
</body>
</html>
