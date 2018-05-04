using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BW.MMS.Web.HtmlExtension.Highcharts
{
    /// <summary>
    /// 图标类型
    /// </summary>
    public enum ChartType
    {
        line,
        spline,
        area,
        bar,
        column,
        scatter
    }
    public static class HtmlExtension
    {
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 Highcharts 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="type">图表类型</param>
        /// <param name="title">标题</param>
        /// <param name="y_title">Y轴标题</param>
        /// <param name="xAxis">X轴坐标</param>
        /// <param name="series">数据</param>
        /// <returns>一个 Highcharts 对象</returns>
        public static Highcharts Chart(this HtmlHelper htmlHelper, string name, ChartType type, string title, string y_title, string[] xAxis, IDictionary<string, List<float>> series)
        {
            return new Highcharts(name, type, title, y_title, xAxis, series);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 Highcharts pie 元素。
        /// </summary>
        /// <param name="htmlHelper">此方法扩展的 HTML 帮助器实例。</param>
        /// <param name="name">窗体字段的名称和用于查找值的 System.Web.Mvc.ViewDataDictionary 键。</param>
        /// <param name="title">标题</param>
        /// <param name="series">数据</param>
        /// <returns>一个 Highcharts 对象</returns>
        public static Highcharts Chart(this HtmlHelper htmlHelper, string name, string title, IDictionary<string, object> series)
        {
            return new Highcharts(name, title, series);
        }
    }
}
