using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BW.MMS.Web.HtmlExtension.Easyui
{
    /// <summary>
    /// 表示一个类，该类用于填充 EasyUI Tree 对象的集合。
    /// </summary>
    public class TreeNode
    {
        private string _id;
        /// <summary>
        /// 获取或设置节点编号。
        /// </summary>
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _text;
        /// <summary>
        /// 获取或设置节点文本。
        /// </summary>
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
        private string _iconCls;
        /// <summary>
        /// 获取或设置节点图标的css样式。
        /// </summary>
        public string iconCls
        {
            get { return _iconCls; }
            set { _iconCls = value; }
        }
        private string _state = "open";
        /// <summary>
        /// 获取或设置节点状态， "open" 或者 "closed" ，默认是 "open" 。
        /// </summary>
        public string state
        {
            get { return _state; }
            set { _state = value; }
        }
        private bool _checked = false;
        /// <summary>
        /// 获取或设置节点是否选中。
        /// </summary>
        public bool @checked
        {
            get { return _checked; }
            set { _checked = value; }
        }
        private object _attributes;
        /// <summary>
        /// 获取或设置节点的自定义属性。
        /// </summary>
        public object attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }
        private List<TreeNode> _children = new List<TreeNode>();
        /// <summary>
        /// 获取或设置子节点。
        /// </summary>
        public List<TreeNode> children
        {
            get { return _children; }
            set { _children = value; }
        }
    }
}
