using System;
using System.Web;

namespace SPcms.Common
{
	/// <summary>
	/// InitJs 的摘要说明。
	/// </summary>
	public class InitJs
	{
		public static string OpenModalDialogPage(bool Submit)
		{
			string JS = "";
			JS += "<script language=\"javascript\">\n";
			JS += "<!--\n";
			JS += "function arg(Url)\n";
			JS += "{\n";
			JS += "	this.ActionPageUrl = Url;\n";
			JS += "}\n";
			JS += "function OpenModalDialogPage(Url,Width,Height)\n";
			JS += "{\n";
			JS += "	var a = new arg(Url);\n";
			JS += "	var winresult = window.showModalDialog('../Frame/Frame_Action.htm', a, 'edge: Raised; center: Yes; help: No; resizable: No; scroll: No; status: No; dialogWidth: ' + Width + 'px; dialogHeight: ' + Height + 'px;');\n";
			if(Submit)
			{
				JS += "	document.forms[0].submit();\n";
			}
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>";
			return JS;
		}

		public static string OpenModWnd()
		{
			string JS = "";
			JS += "<script type=\"text/javascript\">\n";
			JS += "<!--\n";
			JS += "function arg(Url)\n";
			JS += "{\n";
			JS += "	this.ActionPageUrl = Url;\n";
			JS += "}\n";
			JS += "function OpenModWnd(PrimaryKey, CheckBoxName, ViewUrl, ActionUrl, Width, Height, UrlAddons, OpenValue)\n";
			JS += "{\n";
			JS += "	var isModify = false;\n";
			JS += "	for(var i = 0; i < document.forms[0].elements.length; i ++)\n";
			JS += "	{\n";
			JS += "		var e = document.forms[0].elements[i];\n";
			JS += "		if(e.name.substring(0, CheckBoxName.length).toUpperCase() == CheckBoxName.toUpperCase())\n";
			JS += "		{\n";
			JS += "			if(e.type == \"checkbox\")\n";
			JS += "			{\n";
			JS += "				if(e.checked)\n";
			JS += "				{\n";
			JS += "					if(OpenValue == e.value)\n";
			JS += "					{\n";
			JS += "						isModify = true;\n";
			JS += "						break;\n";
			JS += "					}\n";
			JS += "				}\n";
			JS += "			}\n";
			JS += "		}\n";
			JS += "	}\n";
			JS += "	if(isModify)\n";
			JS += "	{\n";
			JS += "		var a;\n";
			JS += "		if(UrlAddons != \"\")\n";
			JS += "			a = new arg(ActionUrl + \"?\" + PrimaryKey + \"=\" + OpenValue + \"&\" + UrlAddons);\n";
			JS += "		else\n";
			JS += "			a = new arg(ActionUrl + \"?\" + PrimaryKey + \"=\" + OpenValue);\n";
			JS += "		var winresult = window.showModalDialog('/Frame/Frame_Action.htm', a, 'edge: Raised; center: Yes; help: No; resizable: No; scroll: No; status: No; dialogWidth: ' + Width + 'px; dialogHeight: ' + Height + 'px;');\n";
			JS += "		//document.forms[0].submit();\n";
			JS += "		location.href=location.href;//location.replace(location.href);//window.location.reload(force=true);//document.execCommand(\"refresh\");\n";
			JS += "	}\n";
			JS += "	else\n";
			JS += "	{\n";
			JS += "		// 打开浏览窗口\n";
			JS += "		var a = new arg(ViewUrl);\n";
			JS += "		var winresult = window.showModalDialog('/Frame/Frame_Action.htm', a, 'edge: Raised; center: Yes; help: No; resizable: No; scroll: No; status: No; dialogWidth: ' + Width + 'px; dialogHeight: ' + Height + 'px;');\n";
			JS += "	}\n";
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>\n";
			return JS;
		}

		public static string OpenReturnValueModalDialogPage(bool Submit)
		{
			string JS = "";
			JS += "<script language=\"javascript\">\n";
			JS += "<!--\n";
			JS += "function arg(Url)\n";
			JS += "{\n";
			JS += "	this.ActionPageUrl = Url;\n";
			JS += "}\n";
			JS += "function OpenReturnValueModalDialogPage(Url, Width, Height, _flag, _controlValue1, _controlValue2)\n";
			JS += "{\n"; 
			JS += "	var a = new arg(Url);\n";
			JS += "	var _flag = window.showModalDialog('/Frame/Frame_Action.htm', a, 'edge: Raised; center: Yes; help: No; resizable: No; scroll: No; status: No; dialogWidth: ' + Width + 'px; dialogHeight: ' + Height + 'px;');\n";
			JS += "	if(typeof(_flag) != \"undefined\")\n";
			JS += "	{\n";
			JS += "			_controlValue1.value = _flag;\n";
			JS += "			_controlValue2.value = \"\";\n";
			JS += "	}\n";
			JS += "	else\n";
			JS += "	{\n";
			JS += "			_controlValue1.value = \"\";\n";
			JS += "			_controlValue2.value = \"\";\n";
			JS += "	}\n";
			if(Submit)
			{
				JS += "	document.forms[0].submit();\n";
			}
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>";
			return JS;
		}

		public static string SelectAll()
		{
			string JS = "";
			JS += "<script language=\"javascript\">\n";
			JS += "<!--\n";
			JS += "function SelectAll(CheckBoxNamePrefix, cb)\n";
			JS += "{\n";
			// 全选
			JS += "	for(var i = 0; i < document.forms[0].elements.length; i ++)\n";
			JS += "	{\n";
			JS += "		var e = document.forms[0].elements[i];\n";
			JS += "		if(e.name.substring(0, CheckBoxNamePrefix.length).toUpperCase() == CheckBoxNamePrefix.toUpperCase())\n";
			JS += "		{\n";
			JS += "			if(e.type == \"checkbox\")\n";
			JS += "			{\n";
			JS += "				if(!e.disabled)\n";
			JS += "				{\n";
			JS += "					e.checked = cb.checked;\n";
			JS += "				}\n";
			JS += "			}\n";
			JS += "		}\n";
			JS += "	}\n";
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>";
			return JS;
		}

		public static string PreDelete()
		{
			string JS = "";
			JS += "<script language=\"javascript\">\n";
			JS += "<!--\n";
			JS += "function PreDelete(Kind, CheckBoxNamePrefix, Message)\n";
			JS += "{\n";
			// 删除前的检查
			// kind = '' : 删除多项,否则只能删除一项; CheckBoxNamePrefix : 选择框名前缀; Message : 提示信息
			JS += "	var count = 0;\n";
			JS += "	for(var i = 0; i < document.forms[0].elements.length; i ++)\n";
			JS += "	{\n";
			JS += "		var e = document.forms[0].elements[i];\n";
			JS += "		if(e.name.substring(0, CheckBoxNamePrefix.length).toUpperCase() == CheckBoxNamePrefix.toUpperCase())\n";
			JS += "		{\n";
			JS += "			if(e.type == \"checkbox\")\n";
			JS += "			{\n";
			JS += "				if(e.checked)\n";
			JS += "				{\n";
			JS += "					count ++;\n";
			JS += "				}\n";
			JS += "			}\n";
			JS += "		}\n";
			JS += "	}\n";
			JS += "	if(count == 0)\n";
			JS += "	{\n";
			JS += "		alert('请选择要删除的记录');\n";
			JS += "		return false;\n";
			JS += "	}\n";
			JS += "	else\n";
			JS += "	{\n";
			JS += "		if(count > 1 && Kind != '')\n";
			JS += "		{\n";
			JS += "			alert('只能选择一条记录来删除');\n";
			JS += "			return false;\n";
			JS += "		}\n";
			JS += "		else\n";
			JS += "		{\n";
			JS += "			if(Message != \"\")\n";
			JS += "			{\n";
			JS += "				if(confirm(Message))\n";
			JS += "				{\n";
			JS += "					return true;\n";
			JS += "				}\n";
			JS += "				else\n";
			JS += "				{\n";
			JS += "					return false;\n";
			JS += "				}\n";
			JS += "			}\n";
			JS += "			else\n";
			JS += "			{\n";
			JS += "				return true;\n";
			JS += "			}\n";
			JS += "		}\n";
			JS += "	}\n";
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>";
			return JS;
		}

		public static string OpenModfiyPage()
		{
			string JS = "";
			JS += "<script language=\"javascript\">\n";
			JS += "<!--\n";
			JS += "function arg(Url)\n";
			JS += "{\n";
			JS += "	this.ActionPageUrl = Url;\n";
			JS += "}\n";
			JS += "function OpenModfiyPage(PrimaryKey, CheckBoxName, Url, Width, Height, UrlAddons)\n";
			JS += "{\n";
			JS += "	var count = 0;\n";
			JS += "	var id = -1;\n";
			JS += "	for(var i = 0; i < document.forms[0].elements.length; i ++)\n";
			JS += "	{\n";
			JS += "		var e = document.forms[0].elements[i];\n";
			JS += "		if(e.name.substring(0, CheckBoxName.length).toUpperCase() == CheckBoxName.toUpperCase())\n";
			JS += "		{\n";
			JS += "			if(e.type == \"checkbox\")\n";
			JS += "			{\n";
			JS += "				if(e.checked)\n";
			JS += "				{\n";
			JS += "					count ++;\n";
			JS += "					id = e.value;\n";
			JS += "				}\n";
			JS += "			}\n";
			JS += "		}\n";
			JS += "	}\n";
			JS += "	if(count == 1)\n";
			JS += "	{\n";
			JS += "		var a;\n";
			JS += "		if(UrlAddons != \"\")\n";
			JS += "			a = new arg(Url + \"?\" + PrimaryKey + \"=\" + id + \"&\" + UrlAddons);\n";
			JS += "		else\n";
			JS += "			a = new arg(Url + \"?\" + PrimaryKey + \"=\" + id);\n";
			JS += "		var winresult = window.showModalDialog('../Frame/Frame_Action.htm', a, 'edge: Raised; center: Yes; help: No; resizable: No; scroll: No; status: No; dialogWidth: ' + Width + 'px; dialogHeight: ' + Height + 'px;');\n";
			JS += "		document.forms[0].submit();\n";
			JS += "	}\n";
			JS += "	else if(count == 0)\n";
			JS += "	{\n";
			JS += "		alert('请选择要修改的记录');\n";
			JS += "	}\n";
			JS += "	else\n";
			JS += "	{\n";
			JS += "		alert('只能选择一条记录来修改');\n";
			JS += "	}\n";
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>";
			return JS;
		}

		public static string CheckCheckedCtr()
		{
			// 可检查是否有选项选中，如果有变颜色
			string JS = "";
			JS += "<script type=\"text/javascript\">\n";
			JS += "<!--\n";
			JS += "function CheckCheckedCtr(theform, trid)\n";
			JS += "{\n";
			JS += "	bb = false;\n";
			JS += "	for(var i = 0; i < theform.elements.length; i ++)\n";
			JS += "	{\n";
			JS += "		var e = theform.elements[i];\n";
			JS += "		if(e.type == \"checkbox\")\n";
			JS += "		{\n";
			JS += "			s = e.id;\n";
			JS += "			ss1 = s.split(\"_\");\n";
			JS += "			ss2 = trid.split(\"_\");\n";
			JS += "			if(ss1[1] == ss2[1] && ss1[2] == ss2[2])\n";
			JS += "			{\n";
			JS += "				if(e.checked)\n";
			JS += "				{\n";
			JS += "					bb = true;\n";
			JS += "					break;\n";
			JS += "				}\n";
			JS += "			}\n";
			JS += "		}\n";
			JS += "	}\n";
			JS += "	if(bb)\n";
			JS += "	{\n";
			JS += "		e = document.getElementById(trid)\n";
			JS += "		e.style.backgroundColor = \"#94cbef\";\n";
			JS += "	}\n";
			JS += "	else\n";
			JS += "	{\n";
			JS += "		e = document.getElementById(trid)\n";
			JS += "		e.style.backgroundColor = \"#ffffff\";\n";
			JS += "	}\n";
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>\n";
			return JS;
		}

		public static string CheckSelectTypeZ(string TypeZList)
		{
			// 此脚本用于判断在修改TypeZ时选择的TypeZ的值
			string JS = "";
			JS += "<script event=\"onload\" for=\"window\" type=\"text/javascript\">\n";
			JS += "<!--\n";
			JS += "arrayList = new Array(" + TypeZList + ");\n";
			JS += "var trid = new Array(arrayList.length);\n";
			JS += "var theform = document.forms(0).elements;\n";
			JS += "for(var i = 0; i < theform.elements.length; i ++)\n";
			JS += "{\n";
			JS += "	var e = theform.elements[i];\n";
			JS += "	if(e.type == \"checkbox\")\n";
			JS += "	{\n";
			JS += "		for(var j = 0; j < arrayList.length; j ++)\n";
			JS += "		{\n";
			JS += "			if(e.value == arrayList[j])\n";
			JS += "			{\n";
			JS += "				try\n";
			JS += "				{\n";
			JS += "					e.checked = true;\n";
			JS += "					var eid = e.id;\n";
			JS += "					_eid = eid.split(\"_\");\n";
			JS += "					trid[j] = \"Ctrl\" + \"_\" + _eid[1] + \"_\" + _eid[2];\n";
			JS += "				}\n";
			JS += "				catch(e){}\n";
			JS += "			}\n";
			JS += "		}\n";
			JS += "	}\n";
			JS += "}\n";
			JS += "	for(var i = 0; i < trid.length; i ++)\n";
			JS += "	{\n";
			JS += "		try\n";
			JS += "		{\n";
			JS += "			e = document.getElementById(trid[i])\n";
			JS += "			e.style.backgroundColor = \"#94cbef\";\n";
			JS += "		}\n";
			JS += "		catch(e){}";
			JS += "	}\n";
			JS += "//-->\n";
			JS += "</script>\n";
			return JS;
		}

		public static string ValidateCompanyID(string textbox, string url)
		{
			// 验证关系单位是否存在
			string JS = "";
			JS += "<script language=\"javascript\">\n";
			JS += "<!--\n";
			JS += "function ValidateCompanyID(theform)\n";
			JS += "{\n";
			JS += "	window.open('" + url + "?ID=' + theform." + textbox + ".value, '', 'width=300,height=80');\n";
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>\n";
			return JS;
		}

		public static string ValidateClientID(string textbox, string url)
		{
			// 验证客户是否存在
			string JS = "";
			JS += "<script language=\"javascript\">\n";
			JS += "<!--\n";
			JS += "function ValidateClientID(theform)\n";
			JS += "{\n";
			JS += "	window.open('" + url + "?ID=' + theform." + textbox + ".value, '', 'width=300,height=80');\n";
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>\n";
			return JS;
		}

		public static string submitPage(string submitButton)
		{
			string JS = "";
			JS += "<script language=\"javascript\">\n";
			JS += "<!--\n";
			JS += "function submitPage()\n";
			JS += "{\n";
			JS += "	if(event.keyCode == 13)\n";
			JS += "	{\n";
			JS += "		document.all(\"" + submitButton + "\").click();\n";
			JS += "		event.cancelBubble = true;\n";
			JS += "		event.returnValue = false;\n";
			JS += "	}\n";
			JS += "}\n";
			JS += "//-->\n";
			JS += "</script>\n";
			return JS;
		}

	

		public InitJs()
		{
		}

		public static void msgBoxWithCloseAndReturn(System.Web.UI.Page win, string msg, string rtn)
		{
			msg = msg.Replace("\"", "");
			msg = msg.Replace("\n", " ");
			//string text1 = string.Concat(new string[] { "<script language='javascript'>alert('", msg, "');window.parent.returnValue=", rtn, ";window.close();</script>" });
			string text1 = string.Concat(new string[] { "<script language='javascript'>window.parent.returnValue=", rtn, ";window.close();</script>" });
			if (!win.IsClientScriptBlockRegistered("clientScript"))
			{
				win.RegisterClientScriptBlock("clientScript", text1);
			}
		}
        #region "页面加载中效果"
        /// <summary>
        /// 页面加载中效果
        /// </summary>
        public static void initJavascript()
        {
            HttpContext.Current.Response.Write(" <script language=JavaScript type=text/javascript>");
            HttpContext.Current.Response.Write("var t_id = setInterval(animate,20);");
            HttpContext.Current.Response.Write("var pos=0;var dir=2;var len=0;");
            HttpContext.Current.Response.Write("function animate(){");
            HttpContext.Current.Response.Write("var elem = document.getElementById('progress');");
            HttpContext.Current.Response.Write("if(elem != null) {");
            HttpContext.Current.Response.Write("if (pos==0) len += dir;");
            HttpContext.Current.Response.Write("if (len>32 || pos>79) pos += dir;");
            HttpContext.Current.Response.Write("if (pos>79) len -= dir;");
            HttpContext.Current.Response.Write(" if (pos>79 && len==0) pos=0;");
            HttpContext.Current.Response.Write("elem.style.left = pos;");
            HttpContext.Current.Response.Write("elem.style.width = len;");
            HttpContext.Current.Response.Write("}}");
            HttpContext.Current.Response.Write("function remove_loading() {");
            HttpContext.Current.Response.Write(" this.clearInterval(t_id);");
            HttpContext.Current.Response.Write("var targelem = document.getElementById('loader_container');");
            HttpContext.Current.Response.Write("targelem.style.display='none';");
            HttpContext.Current.Response.Write("targelem.style.visibility='hidden';");
            HttpContext.Current.Response.Write("}");
            HttpContext.Current.Response.Write("</script>");
            HttpContext.Current.Response.Write("<style>");
            HttpContext.Current.Response.Write("#loader_container {text-align:center; position:absolute; top:40%; width:100%; left: 0;}");
            HttpContext.Current.Response.Write("#loader {font-family:Tahoma, Helvetica, sans; font-size:11.5px; color:#000000; background-color:#FFFFFF; padding:10px 0 16px 0; margin:0 auto; display:block; width:130px; border:1px solid #5a667b; text-align:left; z-index:2;}");
            HttpContext.Current.Response.Write("#progress {height:5px; font-size:1px; width:1px; position:relative; top:1px; left:0px; background-color:#8894a8;}");
            HttpContext.Current.Response.Write("#loader_bg {background-color:#e4e7eb; position:relative; top:8px; left:8px; height:7px; width:113px; font-size:1px;}");
            HttpContext.Current.Response.Write("</style>");
            HttpContext.Current.Response.Write("<div id=loader_container>");
            HttpContext.Current.Response.Write("<div id=loader>");
            HttpContext.Current.Response.Write("<div align=center>页面正在加载中 ...</div>");
            HttpContext.Current.Response.Write("<div id=loader_bg><div id=progress> </div></div>");
            HttpContext.Current.Response.Write("</div></div>");
            HttpContext.Current.Response.Flush();
        }
        #endregion

	}
}
