<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_menu_list.aspx.cs"
    Inherits="SPcms.Web.Netadmin.settings.sys_menu_list" %>

<%@ Import Namespace="SPcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑管理角色</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //是否启用权限
            if ($("#ddlRoleType").find("option:selected").attr("value") == 1) {
                $(".border-table").find("input[type='checkbox']").prop("disabled", true);
            }
            $("#ddlRoleType").change(function () {
                if ($(this).find("option:selected").attr("value") == 1) {
                    $(".border-table").find("input[type='checkbox']").prop("checked", false);
                    $(".border-table").find("input[type='checkbox']").prop("disabled", true);
                } else {
                    $(".border-table").find("input[type='checkbox']").prop("disabled", false);
                }
            });
            //权限全选
            $("input[name='checkAll']").click(function () {
                if ($(this).prop("checked") == true) {
                    $(this).parent().siblings("td").find("input[type='checkbox']").prop("checked", true);
                } else {
                    $(this).parent().siblings("td").find("input[type='checkbox']").prop("checked", false);
                }
            });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="role_list.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="manager_list.aspx">
                <span>管理员</span></a> <i class="arrow"></i><a href="role_list.aspx"><span>管理角色</span></a>
        <i class="arrow"></i><span>编辑角色</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑角色信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>菜单类型</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="Dropsite" runat="server" datatype="*" errormsg="请选择所属站点！" sucmsg=" "
                        AutoPostBack="True" OnSelectedIndexChanged="Dropsite_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>菜单列表</dt>
            <dd>
                <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
                    <thead>
                        <tr>
                            <th width="30%">
                                导航名称
                            </th>
                            <th>
                                显示隐藏
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td style="white-space: nowrap; word-break: break-all; overflow: hidden;">
                                        <asp:HiddenField ID="hid" Value='<%#Eval("id") %>' runat="server" />
                                        <asp:HiddenField ID="hidName" Value='<%#Eval("name") %>' runat="server" />
                                        <asp:HiddenField ID="hidtitle" Value='<%#Eval("title") %>' runat="server" />
                                        <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
                                        <%#Eval("title")%>
                                    </td>
                                    <td>
                                        <asp:CheckBoxList ID="cblActionType" runat="server" RepeatDirection="Horizontal"
                                            RepeatLayout="Flow" CssClass="cbllist">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                       <%-- <tr>
                            <td>
                                单页选择：
                            </td>
                            <td>
                                <asp:CheckBoxList ID="cblsinglepage" runat="server" RepeatDirection="Horizontal"
                                    RepeatColumns="6" RepeatLayout="Flow" CssClass="cbllist">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                留言表单：
                            </td>
                            <td>
                                <asp:CheckBoxList ID="cblmessage" runat="server" RepeatDirection="Horizontal" CssClass="cbllist" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>--%>
                    </tbody>
                </table>
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
