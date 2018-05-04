<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Flink_edit.aspx.cs" Inherits="SPcms.Web.Plugin.FLink.admin.Flink_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑友情链接</title>
    <link type="text/css" rel="stylesheet" href="../../../<%=siteConfig.webmanagepath %>/skin/default/style.css" />
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../../../<%=siteConfig.webmanagepath %>/js/layout.js"></script>
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../../tools/upload_ajax.ashx", flashurl: "../../../scripts/swfupload/swfupload.swf" });
            });
            $("#btnCopy").bind("click", function () {
                window.clipboardData.setData("Text", $("#txtcontent").val());
                alert("已将代码复制至剪切板，请将其贴粘到指定位置即可。");
            });
        });
      
    </script>
</head>
<body class="mainbody" onload="remove_loading();">
    <!--导航栏-->
    <div class="location">
        <a href="index.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../../../<%=siteConfig.webmanagepath %>/center.aspx"
            class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="index.aspx"><span>
                首页</span></a> <i class="arrow"></i><span>插件管理</span> <i class="arrow"></i>
        <span>站外链接</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑站外链接</a></li>
                </ul>
            </div>
        </div>
    </div>
    <form id="form1" action="http://<%=siteConfig.remoturl%>/HandlerData.ashx" method="post">
    <div class="tab-content">
        <input id="code" name="code" type="hidden" runat="server"  />
        <dl>
            <dt>域名</dt>
            <dd>
                <input id="txtFlinkurl" class="input normal" datatype="*2-100" sucmsg=" " name="Flinkurl"
                    value="http://" type="text" />
                *您的域名</dd>
        </dl>
        <dl>
            <dt>开启状态</dt>
            <dd>
                <div class="rule-multi-radio">
                    <span id="rblType">
                        <input id="rblType_0" type="radio" checked="checked" name="rblType" value="1" /><label
                            for="rblType_0">开启</label><input id="rblType_1" type="radio" name="rblType" value="2"
                                checked="checked" /><label for="rblType_1">未开启</label>
                    </span>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>公司名称</dt>
            <dd>
                <input id="Flinkname" class="input normal" datatype="*2-100" sucmsg=" " name="Flinkname"
                    type="text" />*公司名称--
                <%--<asp:TextBox ID="txtFlinkname" runat="server" CssClass="input normal" datatype="*2-100"
                    sucmsg=" "></asp:TextBox>*公司名称--%>
            </dd>
        </dl>
        <dl>
            <dt>行业选择</dt>
            <dd>
                <div class="rule-single-select">
                    <select name="drpcode" id="drpcode" class="select2" datatype="*" errormsg="请选择所属行业！" sucmsg=" ">
                        <option selected="selected" value="">请选择</option>
                       <%for (int i = 1; i < fields.Length; i++)
                         {
                             if (fields[i].Name != "基础字段")
                             {  %>
                        <option value="<%=fields[i].Name%>"><%=fields[i].Name%></option>
                      
                        <%}
                         }%>
                    
                    </select>
                    <%-- <asp:DropDownList ID="drpcode" runat="server" datatype="*" errormsg="请选择所属行业！" sucmsg=" ">
                        <asp:ListItem Value="">请选择所属行业...</asp:ListItem>
                    </asp:DropDownList>--%>
                    *公司所属行业
                </div>
            </dd>
        </dl>
        <dl>
            <dt>投放行业</dt>
            <dd>
                <div class="rule-multi-porp">
                 <span id="cbltfcode">
                 <%for (int i = 1; i < fields.Length; i++)
                         {
                             if (fields[i].Name != "基础字段")
                             {  %>
                        <input id="cblAttributeField_0" type="checkbox" value="<%=fields[i].Name %>" name="tfcode" /><label
                            for="cblAttributeField_0"><%=fields[i].Name%></label>
                             <%}
                         }%>
                                </span>

                    <%--    <asp:CheckBoxList ID="cbltfcode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList>--%>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>允许投放行业</dt>
            <dd>
                <div class="rule-multi-porp">
                 <span id="Span1">
                 <%for (int i = 1; i < fields.Length; i++)
                         {
                             if (fields[i].Name != "基础字段")
                             {  %>
                        <input id="Checkbox1" type="checkbox" value="<%=fields[i].Name %>" name="tfcode1" /><label
                            for="cblAttributeField_0"><%=fields[i].Name%></label>
                             <%}
                         }%>
                                </span>

                    <%--    <asp:CheckBoxList ID="cbltfcode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList>--%>  
                </div>*允许别人投放到自己网站的行业类别
            </dd>
        </dl>
        <dl>
            <dt>投放内容</dt>
            <dd>

                 <textarea id="txtcontent" class="input" runat="server" disabled="disabled" style="vertical-align: middle;"></textarea>
                *此代码自动生成
            </dd>
        </dl>
    </div>
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <input id="btnSubmit" type="submit" class="btn" value="提交保存" />
            <%--    <asp:Button ID="btnSubmit" Visible="false" runat="server" Text="提交保存" CssClass="btn"
                OnClick="btnSubmit_Click" />--%>
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>
