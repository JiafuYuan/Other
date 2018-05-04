using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Expressions;

namespace BW.MMS.Web.HtmlExtension.Base
{
    public static class HtmlExtension
    {
        #region My97DatePicker
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 My97DatePicker 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <returns>一个 My97DatePicker 元素。</returns>
        public static MvcHtmlString DatePicker(this HtmlHelper htmlHelper, string name)
        {
            return DatePicker(htmlHelper, name, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 My97DatePicker 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="datePickerAttributes">一个对象，其中包含要为该元素设置的 My97DatePicker 属性。</param>
        /// <returns>一个 My97DatePicker 元素。</returns>
        public static MvcHtmlString DatePicker(this HtmlHelper htmlHelper, string name, object datePickerAttributes)
        {
            return DatePicker(htmlHelper, name, datePickerAttributes, null);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 My97DatePicker 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="datePickerAttributes">一个对象，其中包含要为该元素设置的 My97DatePicker 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 My97DatePicker 元素。</returns>
        public static MvcHtmlString DatePicker(this HtmlHelper htmlHelper, string name, object datePickerAttributes, object htmlAttributes)
        {
            return DatePicker(htmlHelper, name, datePickerAttributes, new RouteValueDictionary(htmlAttributes));
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 My97DatePicker 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="datePickerAttributes">一个对象，其中包含要为该元素设置的 My97DatePicker 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个 My97DatePicker 元素。</returns>
        public static MvcHtmlString DatePicker(this HtmlHelper htmlHelper, string name, object datePickerAttributes, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("id", name);
            tag.MergeAttribute("name", name);
            tag.MergeAttribute("type", "text");
            IDictionary<string, object> attributes = new RouteValueDictionary(datePickerAttributes);
            tag.MergeAttributes(htmlAttributes);
            StringBuilder sb = new StringBuilder();
            sb.Append("WdatePicker({");
            bool flag = false;
            foreach (string item in attributes.Keys)
            {
                if (flag)
                {
                    sb.Append(",");
                }
                sb.AppendFormat("{0}:{1}", item, attributes[item]);
                flag = true;
            }
            sb.Append("})");
            tag.MergeAttribute("onclick", sb.ToString());
            return MvcHtmlString.Create(tag.ToString());
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 My97DatePicker 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 My97DatePicker 元素。</returns>
        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return DatePickerFor(htmlHelper, expression, null);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 My97DatePicker 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="datePickerAttributes">一个对象，其中包含要为该元素设置的 My97DatePicker 属性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 My97DatePicker 元素。</returns>
        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object datePickerAttributes)
        {
            return DatePickerFor(htmlHelper, expression, datePickerAttributes, null);
        }
        /// <summary>
        /// 通过指定表达式表示的对象中的每个属性返回对应的 My97DatePicker 元素。
        /// </summary>
        /// <typeparam name="TModel">模型的类型。</typeparam>
        /// <typeparam name="TProperty">值的类型。</typeparam>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="expression">一个表达式，用于标识包含要显示的属性的对象。</param>
        /// <param name="datePickerAttributes">一个对象，其中包含要为该元素设置的 My97DatePicker 属性。</param>
        /// <param name="htmlAttributes">一个对象，其中包含要为该元素设置的 HTML 特性。</param>
        /// <returns>一个由表达式表示的对象中的每个属性所对应的 My97DatePicker 元素。</returns>
        public static MvcHtmlString DatePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object datePickerAttributes, object htmlAttributes)
        {
            string name = ExpressionHelper.GetExpressionText(expression);
            object objValue = htmlHelper.ViewData.Eval(name);
            IDictionary<string, object> attributes = new RouteValueDictionary(htmlAttributes);
            IDictionary<string, object> dateattributes = new RouteValueDictionary(datePickerAttributes);
            if (objValue != null)
            {
                if (dateattributes.ContainsKey("dateFmt"))
                {
                    attributes.Add("value", DateTime.Parse(objValue.ToString()).ToString(dateattributes["dateFmt"].ToString().Replace("'", "")));
                }
                else
                {
                    attributes.Add("value", objValue.ToString());
                }
            }
            return DatePicker(htmlHelper, name, datePickerAttributes, attributes);
        }
        #endregion
    }
}
