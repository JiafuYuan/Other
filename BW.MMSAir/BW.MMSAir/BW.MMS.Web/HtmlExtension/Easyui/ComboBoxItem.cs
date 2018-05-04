using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BW.MMS.Web.HtmlExtension.Easyui
{
    /// <summary>
    /// 表示一个类，该类用于填充 EasyUI ComboBox 对象的集合。
    /// </summary>
    public class ComboBoxItem
    {
        private string _value;
        /// <summary>
        /// 获取或设置 Item 项的值。
        /// </summary>
        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
        private string _text;
        /// <summary>
        /// 获取或设置 Item 项的文本。
        /// </summary>
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
        private bool _Selected;
        /// <summary>
        /// 获取或设置 Item 项是否选中。
        /// </summary>
        public bool Selected
        {
            get { return _Selected; }
            set { _Selected = value; }
        }

    }
}
