using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BW.MMS.Web.HtmlExtension.Easyui
{
    /// <summary>
    /// 表示一个类，该类用于填充 EasyUI DataGrid 对象 Column 的集合。
    /// </summary>
    public class DataGridColumn
    {
        /// <summary>
        /// 初始化 MVC.Base.EasyUI.DataGridColumn 类的新实例。
        /// </summary>
        public DataGridColumn()
        {
            //构造函数
        }
        /// <summary>
        /// 获取或设置列的标题文字。
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 获取或设置列的字段名。
        /// </summary>
        public string field { get; set; }
        /// <summary>
        /// 获取或设置元素的 HTML 特性。
        /// </summary>
        public object columnAttributes { get; set; }
    }
}
