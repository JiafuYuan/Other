using System;
namespace BW.MMS.Model
{
    /// <summary>
    /// GridConfig:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GridConfigEntity
    {
        public GridConfigEntity()
        { }
        #region Model
        private int _id;
        private string _gridkeyname;
        private string _chinesename;
        private string _applicationcode;
        private string _idfield;
        private bool _ischk;
        private string _pagecode;
        private string _type;
        private string _tvname;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// grid标识
        /// </summary>
        public string GridKeyName
        {
            set { _gridkeyname = value; }
            get { return _gridkeyname; }
        }
        /// <summary>
        /// 中文名称
        /// </summary>
        public string ChineseName
        {
            set { _chinesename = value; }
            get { return _chinesename; }
        }
        /// <summary>
        /// 所属子系统
        /// </summary>
        public string ApplicationCode
        {
            set { _applicationcode = value; }
            get { return _applicationcode; }
        }
        /// <summary>
        /// 标识/主键字段
        /// </summary>
        public string IDField
        {
            set { _idfield = value; }
            get { return _idfield; }
        }
        /// <summary>
        /// 是否显示选择列
        /// </summary>
        public bool ischk
        {
            set { _ischk = value; }
            get { return _ischk; }
        }
        /// <summary>
        /// 所属页面
        /// </summary>
        public string PageCode
        {
            set { _pagecode = value; }
            get { return _pagecode; }
        }
        /// <summary>
        /// 数据源类型
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 数据源名称
        /// </summary>
        public string TVName
        {
            set { _tvname = value; }
            get { return _tvname; }
        }
        #endregion Model

    }
}

