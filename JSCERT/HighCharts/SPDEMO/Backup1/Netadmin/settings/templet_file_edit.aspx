<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="templet_file_edit.aspx.cs"
    Inherits="SPcms.Web.admin.settings.templet_file_edit" ValidateRequest="false" %>

<%@ Import Namespace="SPcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑后台导航</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script>
        (function ($) {
            $.fn.extend({
                "insertss": function (value) {
                    //默认参数 
                    value = $.extend({
                        "text": value
                    }, value);
                    var dthis = $(this)[0]; //将jQuery对象转换为DOM元素 
                    //IE下 
                    if (document.selection) {
                        $(dthis).focus(); //输入元素textara获取焦点 
                        var fus = document.selection.createRange(); //获取光标位置 
                        fus.text = value.text; //在光标位置插入值 
                        $(dthis).focus(); ///输入元素textara获取焦点 
                    }
                    //火狐下标准 
                    else if (dthis.selectionStart || dthis.selectionStart == '0') {
                        var start = dthis.selectionStart; //获取焦点前坐标 
                        var end = dthis.selectionEnd; //获取焦点后坐标 
                        //以下这句，应该是在焦点之前，和焦点之后的位置，中间插入我们传入的值 .然后把这个得到的新值，赋给文本框 
                        dthis.value = dthis.value.substring(0, start) + value.text + dthis.value.substring(end, dthis.value.length);
                    }
                    //在输入元素textara没有定位光标的情况 
                    else {
                        this.value += value.text; this.focus();
                    };
                    return $(this);
                }
            })
        })(jQuery)

        function insertds() {
            if (confirm("你要添加到文本框内吗？")) {
                if ($("#Selds").val() != "") {
                    $("#txtContent").insertss($("#Selds").val());
                }
            }
        }
        function insertcode() {
            if ($("#selcode").val() != "") {

                $("#txtContent").insertss(getcode($("#selcode").val()));
            }

        }
        function insertcss() {
            if ($("#Selcss").val() != "") {

                $("#txtContent").insertss($("#Selcss").val());
            }
        }
        function insertzd() {
            if ($("#Selzd").val() != "") {
                switch ($("#Selzd").val()) {
                    case "list_lk":
                        if ($("#Selds").val() == "") {
                            alert("请选择数据源");
                            $("#Selds").focus();
                            return;
                        }
                        $("#txtContent").insertss("<" + "%linkurl(\"" + $("#Selds").val() + "_list\",{dr" + pwd + "[id]})%" + ">");
                        break;
                    case "show_lk":
                        if ($("#Selds").val() == "") {
                            alert("请选择数据源");
                            $("#Selds").focus();
                            return;
                        }
                        $("#txtContent").insertss("<" + "%linkurl(\"" + $("#Selds").val() + "_show\",{dr" + pwd + "[id]})%" + ">");
                        break;
                    case "is_hot":
                        $("#txtContent").insertss(" and " + $("#Selzd").val() + "=1");
                        break;
                    case "is_top":
                        $("#txtContent").insertss(" and " + $("#Selzd").val() + "=1");
                        break;
                    case "is_slide":
                        $("#txtContent").insertss(" and " + $("#Selzd").val() + "=1");
                        break;
                    case "is_red":
                        $("#txtContent").insertss(" and " + $("#Selzd").val() + "=1");
                        break;
                    case "add_time":
                        $("#txtContent").insertss("<" + "%datetostr({dr" + pwd + "[" + $("#Selzd").val() + "]},yyyy-MM-dd)%>");

                        break;
                    case "substring":
                        $("#txtContent").insertss("<" + "%cutstring(字段,20)%>");
                        break;
                    default:
                        $("#txtContent").insertss("{dr" + pwd + "[" + $("#Selzd").val() + "]}");

                }



            }
        }

        function getcode(index) {

            switch (index) {
                case "1":
                    return "<" + "%templateskin%" + ">" + "/";
                case "3":
                    if ($("#Selds").val() == "") {
                        alert("请选择数据源");
                        $("#Selds").focus();
                        return "";
                    }
                    var sjs = getrand();
                    var ss = "<" + "%set DataTable articalDt" + sjs + "=get_article_list(\"" + $("#Selds").val() + "\", 0, 8, \"status=0\")%>\r\n";
                    ss += "<" + "%foreach(DataRow dr" + sjs + " in articalDt" + sjs + ".Rows)%>";
                    ss += "\r\n\r\n";
                    ss += "<" + "%/foreach%>\r\n\r\n".replace('&lt;', '<');
                    return ss;
                case "4":
                    if ($("#Selds").val() == "") {
                        alert("请选择数据源");
                        $("#Selds").focus();
                        return "";
                    }
                    var sjs = getrand();
                    var ss = "<" + "%set DataTable catedt" + sjs + "=get_category_child_list(\"" + $("#Selds").val() + "\", 0)%>\r\n";
                    ss += "<" + "%foreach(DataRow dr" + sjs + " in catedt" + sjs + ".Rows)%>".replace('&lt;', '<');
                    ss += "\r\n\r\n";
                    ss += "<" + "%/foreach%>\r\n\r\n".replace('&lt;', '<');
                    return ss;
                case "5":
                    if ($("#Selds").val() == "") {
                        alert("请选择数据源");
                        $("#Selds").focus();
                        return "";
                    }
                    var sjs = getrand();

                    var ss = "<" + "%set DataTable loopdt" + sjs + "=get_article_list(\"" + $("#Selds").val() + "\", 0, 10, \"status=0\", \"click desc,id desc\")%>\r\n";
                    ss += "<" + "%loop dr" + sjs + " loopdt" + sjs + "%>";

                    ss += "\r\n\r\n";
                    ss += "<" + "%/loop%>";
                    return ss;
                case "6":
                    if ($("#Selds").val() == "") {
                        alert("请选择数据源");
                        $("#Selds").focus();
                        return "";
                    }
                    var sjs = getrand();

                    var ss = "<" + "%set DataTable catedt" + sjs + "=get_category_child_list(\"" + $("#Selds").val() + "\", 0)%>\r\n";
                    ss += "<" + "%loop dr" + sjs + " catedt" + sjs + "%>";

                    ss += "\r\n\r\n";
                    ss += "<" + "%/loop%>";
                    return ss;
                case "11":
                    if ($("#Selds").val() == "") {
                        alert("请选择数据源");
                        $("#Selds").focus();
                        return "";
                    }


                    var ss = "<" + "%set DataTable news_list = get_article_list(\"" + $("#Selds").val() + "\", category_id, page, \"status=0\", out totalcount, out pagelist, \"" + $("#Selds").val() + "_list\", category_id, \"__id__\")%>";
                    ss += "<" + "%foreach(DataRow dr in news_list.Rows)%>";

                    ss += "\r\n\r\n";
                    ss += "<" + "%/foreach%>";
                    return ss;
                case "7":
                    var ss = "<" + "%write get_article_content(\"about\",\"zhaiyao\") %>";
                    return ss;
                case "10":
                    var ss = "<title>{config.webtitle}</title>\r\n";
                    ss += "<meta content=\"{config.webkeyword}\" name=\"keywords\" />\r\n";
                    ss += "<meta content=\"{config.webdescription}\" name=\"description\" />\r\n";
                    return ss;
                case "8":
                    var ss = "<" + "%template src=\"_header.html\"%>";
                    return ss;
                case "9":
                    var ss = "<" + "%template src=\"_foot.html\"%>";
                    return ss;

            }
        }
        function insertmy() {
            var strv = $("#selmy").val();
            if (strv != "") {
                if (strv == "11") {

                    var ss = "<title>{model.title} - {category_title} - {config.webname}</title>\r\n";
                    ss += "<meta content=\"{model.seo_keywords}\" name=\"keywords\" />\r\n";
                    ss += "<meta content=\"{model.seo_description}\" name=\"description\" />\r\n";
                    $("#txtContent").insertss(ss);
                }
                else if (strv == "12") {
                    var ss = "<" + "script type=\"text/javascript\" src=\"{config.webpath}tools/submit_ajax.ashx?action=view_article_click&id={model.id}&click=1\">" + "<" + "/script>";
                    $("#txtContent").insertss(ss);
                }

                else {
                    $("#txtContent").insertss("{model." + $("#selmy").val() + "}");
                }
            }

        }
        var pwd = '';
        function getrand() {

            var $chars = 'ABCDEFGHJKMNPQRSTWXYZabcdefhijkmnprstwxyz'; // 默认去掉了容易混淆的字符oOLl,9gq,Vv,Uu,I1
            var maxPos = $chars.length;
            pwd = '';
            for (i = 0; i < 5; i++) {
                pwd += $chars.charAt(Math.floor(Math.random() * maxPos));
            }

            return pwd;
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
        <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow">
        </i><span>应用管理</span> <i class="arrow"></i><a href="templet_list.aspx"><span>模板管理</span></a>
        <i class="arrow"></i><span>编辑模板：<%=pathName%></span>
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑模板内容</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>文件名称</dt>
            <dd>
                <%=fileName %></dd>
        </dl>
        <dl>
            <dt>快捷编辑：</dt>
            <dd>
                选择数据源：
                <div class="rule-single-select" onclick="insertds()">
                    <select id="Selds">
                        <option value="">....</option>
                        <asp:Repeater ID="repds" runat="server">
                            <ItemTemplate>
                                <option value="<%#Eval("name") %>">
                                    <%#Eval("title") %>(<%#Eval("title1") %>)</option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>
                </div>
                插入样式：
                <div class="rule-single-select" onclick="insertcss()">
                    <select id="Selcss">
                        <option value="">....</option>
                        <asp:Repeater ID="Repcss" runat="server">
                            <ItemTemplate>
                                <option value='<%#Eval("fordntver") %>'>
                                    <%#Eval("name")%></option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>
                </div>
                插入代码段：
                <div class="rule-single-select" onclick="insertcode()">
                    <select id="selcode">
                        <option value="">....</option>
                        <option value="1">当前主题路径</option>
                        <option value="3">文章+foreach循环</option>
                        <option value="4">类别+foreach循环</option>
                        <option value="5">文章+loop循环</option>
                        <option value="6">类别+loop循环</option>
                        <option value="11">列表页</option>
                        <option value="7">单页字段值</option>
                        <option value="8">头部</option>
                        <option value="9">底部</option>
                        <option value="10">SEO</option>
                    </select>
                </div>
                常用字段
                <div class="rule-single-select" onclick="insertzd()">
                    <select id="Selzd">
                        <option value="">....</option>
                        <option value="title">标题</option>
                        <option value="img_url">图片</option>
                        <option value="zhaiyao">简介</option>
                        <option value="content">内容</option>
                        <option value="add_time">添加时间</option>
                        <option value="substring">字符串截取</option>
                        <option value="list_lk">列表链接</option>
                        <option value="show_lk">末页连接</option>
                        <option value="is_hot">热门</option>
                        <option value="is_top">置顶</option>
                        <option value="is_red">推荐</option>
                        <option value="is_slide">幻灯片</option>
                    </select>
                </div>
                末页常用字段
                <div class="rule-single-select" onclick="insertmy()">
                    <select id="selmy">
                        <option value="">....</option>
                        <option value="title">标题</option>
                        <option value="img_url">图片</option>
                        <option value="zhaiyao">简介</option>
                        <option value="content">内容</option>
                        <option value="12">点击数</option>
                        <option value="add_time">添加时间</option>
                        <option value="11">末页seo</option>
                    </select>
                </div>
            </dd>
            <dl>
                <dt>文件内容</dt>
                <dd>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="input" TextMode="MultiLine"
                        Style="width: 96%; height: 450px;"></asp:TextBox>
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
