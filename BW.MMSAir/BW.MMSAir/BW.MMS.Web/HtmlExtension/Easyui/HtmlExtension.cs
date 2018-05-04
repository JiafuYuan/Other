using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Expressions;

namespace BW.MMS.Web.HtmlExtension.Easyui
{
    public static class HtmlExtension
    {
        /// <summary>
        /// 将 EasyUI 元素属性集合转换成 EasyUI 元素的 data-options 数据。
        /// </summary>
        /// <param name="attributes">一个属性对象，其中包含 EasyUI 元素属性集合。</param>
        /// <returns>EasyUI data-options。</returns>
        private static string ToDataOptions(IDictionary<string, object> attributes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in attributes.Keys)
            {
                if (null == attributes[item])
                {
                    continue;
                }
                sb.Append(",");
                sb.Append(item);
                sb.Append(":");
                switch (attributes[item].GetType().ToString())
                {
                    case "System.Boolean":
                        sb.Append(attributes[item].ToString().ToLower());
                        break;
                    case "System.String":
                        sb.Append("'");
                        sb.Append(attributes[item].ToString());
                        sb.Append("'");
                        break;
                    default:
                        if (attributes[item].ToString().IndexOf("function") > -1)
                        {
                            sb.Append(new RouteValueDictionary(attributes[item])["function"]);
                        }
                        else
                        {
                            sb.Append(Newtonsoft.Json.JsonConvert.SerializeObject(attributes[item]));
                        }
                        break;
                }
            }
            return sb.ToString().Substring(1);
        }

        #region LinkButton
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI linkbutton 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="text">显示在按钮上的文本。</param>
        /// <param name="iconCls">图标的css类。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI linkbutton 元素。</returns>
        public static MvcHtmlString LinkButton(this HtmlHelper htmlHelper, string text, string iconCls, object htmlAttributes)
        {
            return LinkButton(htmlHelper, text, iconCls, false, htmlAttributes);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI linkbutton 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="text">显示在按钮上的文本。</param>
        /// <param name="iconCls">图标的css类。</param>
        /// <param name="plain">设置为true将显示简洁效果。默认为false</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI linkbutton 元素。</returns>
        public static MvcHtmlString LinkButton(this HtmlHelper htmlHelper, string text, string iconCls, bool plain, object htmlAttributes)
        {
            return LinkButton(htmlHelper, text, iconCls, plain, false, htmlAttributes);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI linkbutton 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="text">显示在按钮上的文本。</param>
        /// <param name="iconCls">图标的css类。</param>
        /// <param name="plain">设置为true将显示简洁效果。默认为false</param>
        /// <param name="disabled">设置为true将禁用按钮。默认为false</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI linkbutton 元素。</returns>
        public static MvcHtmlString LinkButton(this HtmlHelper htmlHelper, string text, string iconCls, bool plain, bool disabled, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new Dictionary<string, object>();
            attributes.Add("iconCls", iconCls);
            attributes.Add("plain", plain);
            attributes.Add("disabled", disabled);
            TagBuilder tag = new TagBuilder("a");
            tag.AddCssClass("easyui-linkbutton");
            string options = Newtonsoft.Json.JsonConvert.SerializeObject(attributes);
            options = options.Substring(1, options.Length - 2);
            tag.MergeAttribute("data-options", options);
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tag.SetInnerText(text);
            return MvcHtmlString.Create(tag.ToString());
        }
        #endregion

        #region ComboBox
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combobox 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <returns>一个 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBox(this HtmlHelper htmlHelper, string name, object comboBoxAttributes)
        {
            return ComboBox(htmlHelper, name, new RouteValueDictionary(comboBoxAttributes), null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combobox 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBox(this HtmlHelper htmlHelper, string name, object comboBoxAttributes, object htmlAttributes)
        {
            return ComboBox(htmlHelper, name, new RouteValueDictionary(comboBoxAttributes), new RouteValueDictionary(htmlAttributes));
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combobox 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="comboboxList">一个用于填充下拉列表的 MVC.Base.EasyUI.ComboBoxItem 对象的集合。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <returns>一个 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBox(this HtmlHelper htmlHelper, string name, IEnumerable<ComboBoxItem> comboboxList, object comboBoxAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboBoxAttributes);
            ComboBoxItem item = comboboxList.FirstOrDefault(m => m.Selected == true);
            if (item != null)
            {
                attributes.Add("value", item.value);
            }
            attributes.Add("data", comboboxList);
            return ComboBox(htmlHelper, name, attributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combobox 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="comboboxList">个用于填充下拉列表的 MVC.Base.EasyUI.ComboBoxItem 对象的集合。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBox(this HtmlHelper htmlHelper, string name, IEnumerable<ComboBoxItem> comboboxList, object comboBoxAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboBoxAttributes);
            ComboBoxItem item = comboboxList.FirstOrDefault(m => m.Selected == true);
            if (item != null)
            {
                attributes.Add("value", item.value);
            }
            attributes.Add("data", comboboxList);
            return ComboBox(htmlHelper, name, attributes, new RouteValueDictionary(htmlAttributes));
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combobox 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBox(this HtmlHelper htmlHelper, string name, IDictionary<string, object> comboBoxAttributes, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("id", name);
            tag.MergeAttribute("name", name);
            tag.AddCssClass("easyui-combobox");
            tag.MergeAttributes(htmlAttributes);
            string str = ",onShowPanel: function () { $('#" + name + "').combobox('reload'); }";
            tag.MergeAttribute("data-options", ToDataOptions(comboBoxAttributes) + str );
            return MvcHtmlString.Create(tag.ToString());
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combobox 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object comboBoxAttributes)
        {
            return ComboBoxFor(htmlHelper, expression, comboBoxAttributes, null);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combobox 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object comboBoxAttributes, object htmlAttributes)
        {
            return ComboBoxFor(htmlHelper, expression, new RouteValueDictionary(comboBoxAttributes), htmlAttributes);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combobox 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> comboBoxAttributes, object htmlAttributes)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            object objValue = htmlHelper.ViewData.Eval(name);
            if (objValue != null)
            {
                if (comboBoxAttributes.ContainsKey("value"))
                {
                    comboBoxAttributes["value"] = objValue.ToString().Split(',');
                }
                else
                {
                    comboBoxAttributes.Add("value", objValue.ToString().Split(','));
                }
            }
            return ComboBox(htmlHelper, name, comboBoxAttributes, new RouteValueDictionary(htmlAttributes));
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combobox 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="comboboxList">用于填充下拉列表的 MVC.Base.EasyUI.ComboBoxItem 对象的集合。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<ComboBoxItem> comboboxList, object comboBoxAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboBoxAttributes);
            attributes.Add("data", comboboxList);
            return ComboBoxFor(htmlHelper, expression, attributes, null);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combobox 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="comboboxList">用于填充下拉列表的 MVC.Base.EasyUI.ComboBoxItem 对象的集合。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<ComboBoxItem> comboboxList, object comboBoxAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboBoxAttributes);
            attributes.Add("data", comboboxList);
            return ComboBoxFor(htmlHelper, expression, attributes, htmlAttributes);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combobox 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="actionName">从远程加载列表数据的 URL 。</param>
        /// <param name="valueField">绑定到 ComboBox 的 value 上的基础数据的名称。</param>
        /// <param name="textField">绑定到 ComboBox 的 text 上的基础数据的名称。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string actionName, string valueField, string textField, object comboBoxAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboBoxAttributes);
            attributes.Add("url", actionName);
            attributes.Add("valueField", valueField);
            attributes.Add("textField", textField);
            return ComboBoxFor(htmlHelper, expression, attributes, null);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combobox 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="actionName">从远程加载列表数据的 URL 。</param>
        /// <param name="valueField">绑定到 ComboBox 的 value 上的基础数据的名称。</param>
        /// <param name="textField">绑定到 ComboBox 的 text 上的基础数据的名称。</param>
        /// <param name="comboBoxAttributes">一个对象，其中包含要为该元素设置的 EasyUI combobox 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combobox 元素。</returns>
        public static MvcHtmlString ComboBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string actionName, string valueField, string textField, object comboBoxAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboBoxAttributes);
            attributes.Add("url", actionName);
            attributes.Add("valueField", valueField);
            attributes.Add("textField", textField);
            return ComboBoxFor(htmlHelper, expression, attributes, htmlAttributes);
        }
        #endregion

        #region DataGrid
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI datagrid 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="datagridAttributes">一个对象，其中包含要为该元素设置的 EasyUI DataGrid 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI DataGrid 元素。</returns>
        public static MvcHtmlString DataGrid(this HtmlHelper htmlHelper, string name, IEnumerable<object> dataGridColumn, IDictionary<string, object> datagridAttributes, object htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("table");
            tag.MergeAttribute("id", name);
            tag.AddCssClass("easyui-datagrid");
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            tag.MergeAttribute("data-options", ToDataOptions(datagridAttributes));
            StringBuilder sb = new StringBuilder();
            sb.Append(tag.ToString(TagRenderMode.StartTag));
            sb.Append("<thead>");
            foreach (IEnumerable<DataGridColumn> list in dataGridColumn)
            {
                sb.Append("<tr>");
                foreach (DataGridColumn item in list)
                {
                    sb.Append("<th data-options=\"");
                    if (!string.IsNullOrEmpty(item.field))
                    {
                        sb.AppendFormat("field:'{0}'", item.field);
                    }
                    if (item.columnAttributes != null)
                    {
                        if (!string.IsNullOrEmpty(item.field))
                        {
                            sb.Append(",");
                        }
                        IDictionary<string, object> attributes = item.columnAttributes as Dictionary<string, object>;
                        if (null == attributes)
                        {
                            attributes = new RouteValueDictionary(item.columnAttributes);
                        }
                        string span = string.Empty;
                        IDictionary<string, object> data = new Dictionary<string, object>();
                        foreach (string key in attributes.Keys)
                        {
                            if (key.Equals("rowspan"))
                            {
                                span += " rowspan=" + attributes["rowspan"];
                            }
                            else if (key.Equals("colspan"))
                            {
                                span += " colspan=" + attributes["colspan"];
                            }
                            else
                            {
                                data.Add(key, attributes[key]);
                            }
                        }
                        if (null != data)
                        {
                            sb.Append(ToDataOptions(data));
                        }
                        sb.Append("\"");
                        sb.Append(span);
                    }
                    sb.Append(">");
                    sb.Append(item.title);
                    sb.Append("</th>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</thead>");
            sb.Append("</table>");
            return MvcHtmlString.Create(sb.ToString());
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI datagrid 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="data">用于填充 DataGrid 数据对象的集合。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="datagridAttributes">一个对象，其中包含要为该元素设置的 EasyUI DataGrid 属性。</param>
        /// <returns>一个 EasyUI DataGrid 元素。</returns>
        public static MvcHtmlString DataGrid(this HtmlHelper htmlHelper, string name, object data, IEnumerable<object> dataGridColumn, object datagridAttributes)
        {
            return DataGrid(htmlHelper, name, data, dataGridColumn, datagridAttributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI datagrid 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="data">用于填充 DataGrid 数据对象的集合。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="datagridAttributes">一个对象，其中包含要为该元素设置的 EasyUI DataGrid 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI DataGrid 元素。</returns>
        public static MvcHtmlString DataGrid(this HtmlHelper htmlHelper, string name, object data, IEnumerable<object> dataGridColumn, object datagridAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(datagridAttributes);
            attributes.Add("data", data);
            return DataGrid(htmlHelper, name, dataGridColumn, attributes, htmlAttributes);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI datagrid 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="actionName">从远程站点请求数据的 URL。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="datagridAttributes">一个对象，其中包含要为该元素设置的 EasyUI DataGrid 属性。</param>
        /// <returns>一个 EasyUI DataGrid 元素。</returns>
        public static MvcHtmlString DataGrid(this HtmlHelper htmlHelper, string name, string actionName, IEnumerable<object> dataGridColumn, object datagridAttributes)
        {
            return DataGrid(htmlHelper, name, actionName, dataGridColumn, datagridAttributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI datagrid 元素。mo
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="actionName">从远程站点请求数据的 URL。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="datagridAttributes">一个对象，其中包含要为该元素设置的 EasyUI DataGrid 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI DataGrid 元素。</returns>
        public static MvcHtmlString DataGrid(this HtmlHelper htmlHelper, string name, string actionName, IEnumerable<object> dataGridColumn, object datagridAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(datagridAttributes);
            attributes.Add("url", actionName);
            return DataGrid(htmlHelper, name, dataGridColumn, attributes, htmlAttributes);
        }
        #endregion

        #region Tree
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI tree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <returns>一个 EasyUI Tree 元素。</returns>
        public static MvcHtmlString Tree(this HtmlHelper htmlHelper, string name)
        {
            return Tree(htmlHelper, name, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI tree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeAttributes">一个对象，其中包含要为该元素设置的 EasyUI Tree 属性。</param>
        /// <returns>一个 EasyUI Tree 元素。</returns>
        public static MvcHtmlString Tree(this HtmlHelper htmlHelper, string name, object treeAttributes)
        {
            return Tree(htmlHelper, name, treeAttributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI tree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeAttributes">一个对象，其中包含要为该元素设置的 EasyUI Tree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI Tree 元素。</returns>
        public static MvcHtmlString Tree(this HtmlHelper htmlHelper, string name, object treeAttributes, object htmlAttributes)
        {
            return Tree(htmlHelper, name, new RouteValueDictionary(treeAttributes), htmlAttributes);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI tree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeAttributes">一个对象，其中包含要为该元素设置的 EasyUI Tree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI Tree 元素。</returns>
        public static MvcHtmlString Tree(this HtmlHelper htmlHelper, string name, IDictionary<string, object> treeAttributes, object htmlAttributes)
        {
            return Tree(htmlHelper, name, treeAttributes, new RouteValueDictionary(htmlAttributes));
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI tree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeAttributes">一个对象，其中包含要为该元素设置的 EasyUI Tree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI Tree 元素。</returns>
        public static MvcHtmlString Tree(this HtmlHelper htmlHelper, string name, IDictionary<string, object> treeAttributes, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("ul");
            tag.MergeAttribute("id", name);
            tag.MergeAttribute("name", name);
            tag.AddCssClass("easyui-tree");
            tag.MergeAttributes(htmlAttributes);
            tag.MergeAttribute("data-options", ToDataOptions(treeAttributes));
            return MvcHtmlString.Create(tag.ToString());
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI tree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeList">用于填充 Tree 的 MVC.Base.EasyUI.TreeNode 对象的集合。</param>
        /// <param name="treeAttributes">一个对象，其中包含要为该元素设置的 EasyUI Tree 属性。</param>
        /// <returns>一个 EasyUI Tree 元素。</returns>
        public static MvcHtmlString Tree(this HtmlHelper htmlHelper, string name, IEnumerable<TreeNode> treeList, object treeAttributes)
        {
            return Tree(htmlHelper, name, treeList, treeAttributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI tree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeList">用于填充 Tree 的 MVC.Base.EasyUI.TreeNode 对象的集合。</param>
        /// <param name="treeAttributes">一个对象，其中包含要为该元素设置的 EasyUI Tree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI Tree 元素。</returns>
        public static MvcHtmlString Tree(this HtmlHelper htmlHelper, string name, IEnumerable<TreeNode> treeList, object treeAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(treeAttributes);
            attributes.Add("data", treeList);
            return Tree(htmlHelper, name, attributes, htmlAttributes);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI tree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="actionName">从远程站点请求数据的 URL。</param>
        /// <param name="treeAttributes">一个对象，其中包含要为该元素设置的 EasyUI Tree 属性。</param>
        /// <returns>一个 EasyUI Tree 元素。</returns>
        public static MvcHtmlString Tree(this HtmlHelper htmlHelper, string name, string actionName, object treeAttributes)
        {
            return Tree(htmlHelper, name, actionName, treeAttributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI tree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="actionName">从远程站点请求数据的 URL。</param>
        /// <param name="treeAttributes">一个对象，其中包含要为该元素设置的 EasyUI Tree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI Tree 元素。</returns>
        public static MvcHtmlString Tree(this HtmlHelper htmlHelper, string name, string actionName, object treeAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(treeAttributes);
            attributes.Add("url", actionName);
            return Tree(htmlHelper, name, attributes, htmlAttributes);
        }
        #endregion

        #region ComboTree
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combotree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <returns>一个 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, object comboTreeAttributes)
        {
            return ComboTree(htmlHelper, name, new RouteValueDictionary(comboTreeAttributes), null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combotree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, object comboTreeAttributes, object htmlAttributes)
        {
            return ComboTree(htmlHelper, name, new RouteValueDictionary(comboTreeAttributes), new RouteValueDictionary(htmlAttributes));
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combotree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="combotreeList">一个用于填充下拉列表的 MVC.Base.EasyUI.TreeNode 对象的集合。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <returns>一个 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, IEnumerable<TreeNode> combotreeList, object comboTreeAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboTreeAttributes);
            attributes.Add("data", combotreeList);
            return ComboTree(htmlHelper, name, attributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combotree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="combotreeList">个用于填充下拉列表的 MVC.Base.EasyUI.TreeNode 对象的集合。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, IEnumerable<TreeNode> combotreeList, object comboTreeAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboTreeAttributes);
            attributes.Add("data", combotreeList);
            return ComboTree(htmlHelper, name, attributes, new RouteValueDictionary(htmlAttributes));
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI combotree 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTree(this HtmlHelper htmlHelper, string name, IDictionary<string, object> comboTreeAttributes, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("id", name);
            tag.MergeAttribute("name", name);
            tag.AddCssClass("easyui-combotree");
            tag.MergeAttributes(htmlAttributes);
            string str = ",onShowPanel: function () { $('#" + name + "').combotree('reload'); }";
            tag.MergeAttribute("data-options", ToDataOptions(comboTreeAttributes) + str);
            return MvcHtmlString.Create(tag.ToString());
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combotree 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object comboTreeAttributes)
        {
            return ComboTreeFor(htmlHelper, expression, comboTreeAttributes, null);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combotree 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object comboTreeAttributes, object htmlAttributes)
        {
            return ComboTreeFor(htmlHelper, expression, new RouteValueDictionary(comboTreeAttributes), htmlAttributes);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combotree 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> comboTreeAttributes, object htmlAttributes)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            object objValue = htmlHelper.ViewData.Eval(name);
            if (objValue != null)
            {
                comboTreeAttributes.Add("value", objValue.ToString().Split(','));
            }
            return ComboTree(htmlHelper, name, comboTreeAttributes, new RouteValueDictionary(htmlAttributes));
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combotree 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="combotreeList">用于填充下拉列表的 MVC.Base.EasyUI.TreeNode 对象的集合。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<TreeNode> combotreeList, object comboTreeAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboTreeAttributes);
            attributes.Add("data", combotreeList);
            return ComboTreeFor(htmlHelper, expression, attributes, null);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combotree 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="combotreeList">用于填充下拉列表的 MVC.Base.EasyUI.TreeNode 对象的集合。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<TreeNode> combotreeList, object comboTreeAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboTreeAttributes);
            attributes.Add("data", combotreeList);
            return ComboTreeFor(htmlHelper, expression, attributes, htmlAttributes);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combotree 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="actionName">从远程加载列表数据的 URL 。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string actionName, object comboTreeAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboTreeAttributes);
            attributes.Add("url", actionName);
            return ComboTreeFor(htmlHelper, expression, attributes, null);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 EasyUI combotree 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="actionName">从远程加载列表数据的 URL 。</param>
        /// <param name="comboTreeAttributes">一个对象，其中包含要为该元素设置的 EasyUI combotree 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 EasyUI combotree 元素。</returns>
        public static MvcHtmlString ComboTreeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string actionName, object comboTreeAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(comboTreeAttributes);
            attributes.Add("url", actionName);
            return ComboTreeFor(htmlHelper, expression, attributes, htmlAttributes);
        }
        #endregion

        #region TreeGrid
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI treegrid 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeField">定义树节点的字段。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="treegridAttributes">一个对象，其中包含要为该元素设置的 EasyUI TreeGrid 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI TreeGrid 元素。</returns>
        public static MvcHtmlString TreeGrid(this HtmlHelper htmlHelper, string name, string treeField, IEnumerable<object> dataGridColumn, IDictionary<string, object> treegridAttributes, object htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("table");
            tag.MergeAttribute("id", name);
            tag.AddCssClass("easyui-treegrid");
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            treegridAttributes.Add("treeField", treeField);
            tag.MergeAttribute("data-options", ToDataOptions(treegridAttributes));
            StringBuilder sb = new StringBuilder();
            sb.Append(tag.ToString(TagRenderMode.StartTag));
            sb.Append("<thead>");
            foreach (IEnumerable<DataGridColumn> list in dataGridColumn)
            {
                sb.Append("<tr>");
                foreach (DataGridColumn item in list)
                {
                    sb.AppendFormat("<th data-options=\"field:'{0}'", item.field);
                    if (item.columnAttributes != null)
                    {
                        sb.Append(",");
                        sb.Append(ToDataOptions(new RouteValueDictionary(item.columnAttributes)));
                    }
                    sb.Append("\">");
                    sb.Append(item.title);
                    sb.Append("</th>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</thead>");
            sb.Append("</table>");
            return MvcHtmlString.Create(sb.ToString());
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI treegrid 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeField">定义树节点的字段。</param>
        /// <param name="data">用于填充 DataGrid 数据对象的集合。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="treegridAttributes">一个对象，其中包含要为该元素设置的 EasyUI TreeGrid 属性。</param>
        /// <returns>一个 EasyUI TreeGrid 元素。</returns>
        public static MvcHtmlString TreeGrid(this HtmlHelper htmlHelper, string name, string treeField, object data, IEnumerable<object> dataGridColumn, object treegridAttributes)
        {
            return TreeGrid(htmlHelper, name, treeField, data, dataGridColumn, treegridAttributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI treegrid 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeField">定义树节点的字段。</param>
        /// <param name="data">用于填充 DataGrid 数据对象的集合。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="treegridAttributes">一个对象，其中包含要为该元素设置的 EasyUI TreeGrid 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI TreeGrid 元素。</returns>
        public static MvcHtmlString TreeGrid(this HtmlHelper htmlHelper, string name, string treeField, object data, IEnumerable<object> dataGridColumn, object treegridAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(treegridAttributes);
            attributes.Add("data", data);
            return TreeGrid(htmlHelper, name, treeField, dataGridColumn, attributes, htmlAttributes);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI treegrid 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeField">定义树节点的字段。</param>
        /// <param name="actionName">从远程站点请求数据的 URL。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="treegridAttributes">一个对象，其中包含要为该元素设置的 EasyUI TreeGrid 属性。</param>
        /// <returns>一个 EasyUI TreeGrid 元素。</returns>
        public static MvcHtmlString TreeGrid(this HtmlHelper htmlHelper, string name, string treeField, string actionName, IEnumerable<object> dataGridColumn, object treegridAttributes)
        {
            return TreeGrid(htmlHelper, name, treeField, actionName, dataGridColumn, treegridAttributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 EasyUI treegrid 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="treeField">定义树节点的字段。</param>
        /// <param name="actionName">从远程站点请求数据的 URL。</param>
        /// <param name="dataGridColumn">用于填充 DataGrid 列的 MVC.Base.EasyUI.DataGridColumn 对象的集合。</param>
        /// <param name="treegridAttributes">一个对象，其中包含要为该元素设置的 EasyUI TreeGrid 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 EasyUI TreeGrid 元素。</returns>
        public static MvcHtmlString TreeGrid(this HtmlHelper htmlHelper, string name, string treeField, string actionName, IEnumerable<object> dataGridColumn, object treegridAttributes, object htmlAttributes)
        {
            IDictionary<string, object> attributes = new RouteValueDictionary(treegridAttributes);
            attributes.Add("url", actionName);
            return TreeGrid(htmlHelper, name, treeField, dataGridColumn, attributes, htmlAttributes);
        }
        #endregion

    }
}
