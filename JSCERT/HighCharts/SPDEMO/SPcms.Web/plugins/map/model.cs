using System;
namespace SPcms.Web.Plugin.map.Model
{
    /// <summary>
    /// map:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class map
    {
        public map()
        { }
        #region Model
        private int _id;
        private string _address;
        private string _company;
        private string _tel;
        private string _instr;
        private string _mwidth;
        private string _mheight;
        /// <summary>
        /// 
        /// </summary>
        public string mheight
        {
            set { _mheight = value; }
            get { return _mheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mwidth
        {
            set { _mwidth = value; }
            get { return _mwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string instr
        {
            set { _instr = value; }
            get { return _instr; }
        }
        #endregion Model

    }
}
