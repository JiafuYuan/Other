using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BW.MMS.Web.HtmlExtension.Highcharts
{
    public partial class Highcharts
    {
        /// <summary>
        /// Highcharts属性
        /// </summary>
        private IDictionary<string, object> _attributes;
        public Highcharts()
        {
            this._attributes = new Dictionary<string, object>();
            IDictionary<string, object> legend = new Dictionary<string, object>();
            legend["layout"] = "horizontal";
            legend["align"] = "center";
            legend["verticalAlign"] = "bottom";
            legend["borderWidth"] = 0;
            this._attributes["legend"] = legend;
            this._attributes["LegendEnabled"] = true;
        }
        public Highcharts(string name, ChartType type, string title, string y_title, string[] xAxis, IDictionary<string, List<float>> series)
            : this()
        {
            this._attributes["id"] = name;
            this._attributes["type"] = type.ToString();
            this._attributes["title"] = title;
            this._attributes["y_title"] = y_title;
            this._attributes["xAxis"] = xAxis;
            this._attributes["series"] = series;
        }
        public Highcharts(string name, string title, IDictionary<string, object> series)
            : this()
        {
            this._attributes["id"] = name;
            this._attributes["type"] = "pie";
            this._attributes["title"] = title;
            this._attributes["series"] = series;
        }
        public override string ToString()
        {
            TagBuilder tag = new TagBuilder("div");
            tag.MergeAttribute("id", _attributes["id"].ToString());
            return tag.ToString(TagRenderMode.SelfClosing);
        }
        /// <summary>
        /// 通过使用指定的 HTML 帮助器和窗体字段的名称，返回文本 Highcharts 元素。
        /// </summary>
        /// <returns>一个 Highcharts 元素。</returns>
        public MvcHtmlString ToMvcHtmlString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("<script type='text/javascript'>");
            sb.AppendLine("$(function () {");
            sb.AppendLine("$('#" + this._attributes["id"] + "').highcharts({");
            sb.AppendLine("credits: {");
            sb.AppendLine("enabled: false");
            sb.AppendLine("},");
            if (this._attributes["type"].ToString() == "pie")
            {
                sb.Append(GeneraPie());
            }
            else
            {
                sb.Append(GeneraChart());
            }
            sb.AppendLine("});");
            sb.AppendLine("});");
            sb.AppendLine("</script>");
            return MvcHtmlString.Create(this.ToString() + sb.ToString());
        }
        /// <summary>
        /// 生成图表
        /// </summary>
        /// <returns></returns>
        private string GeneraChart()
        {
            StringBuilder sb = new StringBuilder();
            //类型
            sb.AppendLine("chart: {");
            sb.AppendFormat("type: '{0}'", this._attributes["type"].ToString());
            sb.AppendLine();
            sb.AppendLine("},");
            //标题
            sb.Append(Title());
            //子标题
            sb.Append(SubTitle());
            //x坐标
            sb.AppendLine("xAxis: {");
            sb.Append("categories: [");
            string[] xAxis = this._attributes["xAxis"] as string[];
            for (int i = 0, length = xAxis.Length; i < length; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }
                sb.Append("'" + xAxis[i] + "'");
            }
            sb.AppendLine("]");
            sb.AppendLine("},");
            //y轴
            sb.AppendLine("yAxis: {");
            sb.AppendLine("title: {");
            string title = this._attributes["y_title"].ToString();
            if (this._attributes.ContainsKey("unit"))
            {
                title += " （" + this._attributes["unit"].ToString() + "）";
            }
            sb.AppendFormat("text: '{0}'", title);
            sb.AppendLine();
            sb.AppendLine("}");
            sb.AppendLine("},");
            //提示文本
            if (this._attributes.ContainsKey("unit"))
            {
                sb.AppendLine("tooltip: {");
                sb.AppendFormat("valueSuffix: '{0}'", this._attributes["unit"].ToString());
                sb.AppendLine();
                sb.AppendLine("},");
            }
            //图例
            sb.Append(Legend());
            //数据
            sb.Append("series: [");
            IDictionary<string, List<float>> series = this._attributes["series"] as Dictionary<string, List<float>>;
            int n = 0;
            foreach (string key in series.Keys)
            {
                if (n > 0)
                {
                    sb.Append(",");
                }
                sb.AppendLine("{");
                sb.AppendLine("name: '" + key + "',");
                sb.Append("data: [");
                List<float> list = series[key];
                for (int i = 0, length = list.Count; i < length; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(list[i].ToString());
                }
                sb.AppendLine("]");
                sb.Append("}");
                n++;
            }
            sb.AppendLine("]");
            return sb.ToString();
        }
        /// <summary>
        /// 生成饼状图表
        /// </summary>
        /// <returns></returns>
        private string GeneraPie()
        {
            StringBuilder sb = new StringBuilder();
            //标题
            sb.Append(Title());
            //子标题
            sb.Append(SubTitle());
            //提示文本
            sb.AppendLine("tooltip: {");
            sb.AppendLine("pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'");
            sb.AppendLine("},");
            //图例
            sb.Append(Legend());
            sb.AppendLine("plotOptions: {");
            sb.AppendLine("pie: {");
            sb.AppendLine("allowPointSelect: true,");
            sb.AppendLine("cursor: 'pointer',");
            sb.AppendLine("dataLabels: {");
            sb.AppendLine("enabled: true,");
            sb.AppendLine("color: '#000000',");
            sb.AppendLine("connectorColor: '#000000',");
            sb.AppendLine("format: '<b>{point.name}</b>: {point.percentage:.1f} %'");
            sb.AppendLine("},");
            sb.AppendFormat("showInLegend: {0}", this._attributes["LegendEnabled"].ToString().ToLower());
            sb.AppendLine();
            sb.AppendLine("}");
            sb.AppendLine("},");
            //数据
            sb.AppendLine("series: [{");
            sb.AppendLine("type:'" + this._attributes["type"].ToString() + "',");
            sb.AppendLine("name: '比例',");
            sb.Append("data: [");
            IDictionary<string, object> series = this._attributes["series"] as Dictionary<string, object>;
            int n = 0;
            foreach (string key in series.Keys)
            {
                if (n > 0)
                {
                    sb.Append(",");
                }
                sb.AppendFormat("['{0}',{1}]", key, series[key].ToString());
                n++;
            }
            sb.AppendLine("]");
            sb.AppendLine("}]");
            return sb.ToString();
        }
        /// <summary>
        /// 生成标题
        /// </summary>
        /// <returns></returns>
        private string Title()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("title: {");
            sb.AppendFormat("text: '{0}'", this._attributes["title"].ToString());
            sb.AppendLine();
            sb.AppendLine("},");
            return sb.ToString();
        }
        /// <summary>
        /// 生成子标题
        /// </summary>
        /// <returns></returns>
        public string SubTitle()
        {
            StringBuilder sb = new StringBuilder();
            if (this._attributes.ContainsKey("subtitle"))
            {
                sb.AppendLine("subtitle: {");
                sb.AppendFormat("text: '{0}'", this._attributes["subtitle"].ToString());
                sb.AppendLine();
                sb.AppendLine("},");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 生成图例
        /// </summary>
        /// <returns></returns>
        public string Legend()
        {
            StringBuilder sb = new StringBuilder();
            IDictionary<string, object> dicLegend = this._attributes["legend"] as Dictionary<string, object>;
            sb.AppendLine("legend: {");
            sb.AppendFormat("enabled: {0},", this._attributes["LegendEnabled"].ToString().ToLower());
            sb.AppendLine();
            sb.AppendFormat("layout: '{0}',", dicLegend["layout"].ToString());
            sb.AppendLine();
            sb.AppendFormat("align: '{0}',", dicLegend["align"].ToString());
            sb.AppendLine();
            sb.AppendFormat("verticalAlign: '{0}',", dicLegend["verticalAlign"].ToString());
            sb.AppendLine();
            sb.AppendFormat("borderWidth: {0}", dicLegend["borderWidth"].ToString());
            sb.AppendLine();
            sb.AppendLine("},");
            return sb.ToString();
        }
        /// <summary>
        /// 设置单位
        /// </summary>
        /// <param name="text">单位名称</param>
        /// <returns></returns>
        public Highcharts Unit(string text)
        {
            this._attributes["unit"] = text;
            return this;
        }
        /// <summary>
        /// 设置子标题
        /// </summary>
        /// <param name="text">子标题名称</param>
        /// <returns></returns>
        public Highcharts SubTitle(string text)
        {
            this._attributes["subtitle"] = text;
            return this;
        }
        /// <summary>
        /// 是否显示图例
        /// </summary>
        /// <param name="Enabled">启用图例</param>
        /// <returns></returns>
        public Highcharts Legend(bool Enabled)
        {
            this._attributes["LegendEnabled"] = Enabled;
            return this;
        }
        /// <summary>
        /// 设置图例样式
        /// </summary>
        /// <param name="layout">布局方式，如 horizontal, vertical </param>
        /// <param name="align">水平对齐方式，如 left, center, right</param>
        /// <param name="verticalAlign">垂直对齐方式，如 top, middle, bottom</param>
        /// <param name="borderWidth">边框宽度</param>
        /// <returns></returns>
        public Highcharts Legend(string layout, string align, string verticalAlign, int borderWidth)
        {
            IDictionary<string, object> legend = new Dictionary<string, object>();
            legend["layout"] = layout;
            legend["align"] = align;
            legend["verticalAlign"] = verticalAlign;
            legend["borderWidth"] = borderWidth;
            this._attributes["legend"] = legend;
            return this;
        }
    }
}
