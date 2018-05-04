<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prenav_list.aspx.cs" Inherits="SPcms.Web.Netadmin.settings.prenav_list" %>

<%@ Import Namespace="SPcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>前台导航管理</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>前台导航管理</span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <%--    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                    <li><a class="add" href="prenav_edit.aspx?action=<%=SPEnums.ActionEnum.Add %>"><i></i>
                        <span>新增</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                    <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','本操作会删除本导航及下属子导航，是否继续？');"
                            OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="btntj"  CssClass="add"  runat="server" OnClientClick="return ExePostBack('btntj','本操作会删除所有旧导航数据，是否继续？');"  onclick="btntj_Click">生成推荐菜单</asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </div>--%>
    <!--/工具栏-->
    <%if (Request.QueryString["skin"] == null)
      {%>
    <asp:Repeater ID="rplisttemp" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <%--   <th width="8%">
                        选择
                    </th>--%>
                    <th align="left" width="20%" style="text-align:center">
                        模板名称
                    </th>
                    <th width="13%">
                        作者
                    </th>
                    <th width="16%">
                        创建日期
                    </th>
                    <th width="12%">
                        版本号
                    </th>
                    <th align="left">
                        适用版本
                    </th>
                    <th width="30%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <%-- <td align="center">
                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                    <asp:HiddenField ID="hideSkinName" runat="server" Value='<%#Eval("skinname")%>' />
                </td>--%>
                <td align="center">
                    <%#Eval("name")%>(<%#Eval("skinname")%>)
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
                    <%#Eval("fordntver")%>
                </td>
                <td align="center">
                    <a href="sys_menu_list.aspx?skin=<%#Eval("skinname")%>">生成导航</a> <a href="?skin=<%#Eval("skinname")%>">
                        管理导航</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rplisttemp.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <%}
      else
      { %>
      <div class="toolbar-wrap">
  <div id="Div1" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="prenav_edit.aspx?action=<%#SPEnums.ActionEnum.Add %>&id=0&skin=<%=_skin%>&node=<%=_skin1 %>"><i></i><span>新增</span></a></li>
       <li><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>清除缓存</span></asp:LinkButton></li>
       <li></li>
       <%-- <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete','如果该频道下还存在文章则无法删除，是否继续？');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
--%>     </ul>
       <div class="menu-list">
        <div class="rule-single-select">
          <asp:DropDownList ID="Dropsite" runat="server" AutoPostBack="True" onselectedindexchanged="Dropsite_SelectedIndexChanged"></asp:DropDownList>
        </div>
      </div>

      <div class="menu-list" style="">
        <div class="rule-single-select">
          <asp:DropDownList ID="cblsinglepage" runat="server" AutoPostBack="True" onselectedindexchanged="cblsinglepage_SelectedIndexChanged" ></asp:DropDownList>
        </div>
      </div>
   
    </div>
    
  </div>
</div>


   
    <!--列表-->
    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width="5%">
                        选择
                    </th>
                    <th align="left" width="12%">
                        名称
                    </th>
                    <th width="8%">
                        链接地址
                    </th>
                    <th width="8%">
                        排序
                    </th>
                    <th width="12%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkId1" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    <asp:HiddenField ID="hidLayer" Value='<%#Eval("layer") %>' runat="server" />
                </td>
                <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                    <a href="prenav_edit.aspx?action=<%#SPEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">
                        <%#Eval("name")%></a>
                </td>
                <td align="center">
                    <%#Eval("link")%>
                </td>
                <td>
                    <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("index")%>' CssClass="sort"
                        onkeydown="return checkNumber(event);" />
                </td>
                <td align="center" style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                    <a href="prenav_edit.aspx?action=<%#SPEnums.ActionEnum.Add %>&id=<%#Eval("id")%>&skin=<%=_skin%>&node=<%=_skin1 %>">
                        添加子级</a> <a href="prenav_edit.aspx?action=<%#SPEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>&skin=<%=_skin%>&node=<%=_skin1 %>">
                            修改</a> <a onclick="return confirm('确定要删除此节点吗，此次操作会删除子节点')" href="prenav_edit.aspx?action=del&id=<%#Eval("id")%>&skin=<%=_skin%>&node=<%=_skin1 %>">
                                删除节点</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <!--/列表-->
    <%} %>
    </form>
</body>
</html>
