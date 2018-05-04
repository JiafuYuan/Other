using System;
namespace BW.MMS.Model
{
    /// <summary>
    /// GridColumnConfig:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GridColumnConfigEntity
    {
        public GridColumnConfigEntity()
        { }
        #region Model
        private int _id;
        private int _gridconfigid;
        private int _parentid = 0;
        private string _title;
        private string _field;
        private int _width = 100;
        private int? _rowspan = 1;
        private bool _iscolspan = false;
        private int? _colspan = 1;
        private string _align = "center";
        private bool _hidden = false;
        private bool _sortable = true;
        private int? _showposition;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 主表ID
        /// </summary>
        public int gridconfigID
        {
            set { _gridconfigid = value; }
            get { return _gridconfigid; }
        }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 列的标题文字
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 列的字段名
        /// </summary>
        public string field
        {
            set { _field = value; }
            get { return _field; }
        }
        /// <summary>
        /// 列的宽度
        /// </summary>
        public int width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 指一个单元格占据多少行
        /// </summary>
        public int? rowspan
        {
            set { _rowspan = value; }
            get { return _rowspan; }
        }
        /// <summary>
        /// 是否合并列
        /// </summary>
        public bool iscolspan
        {
            set { _iscolspan = value; }
            get { return _iscolspan; }
        }
        /// <summary>
        /// 指一个单元格占据多少列
        /// </summary>
        public int? colspan
        {
            set { _colspan = value; }
            get { return _colspan; }
        }
        /// <summary>
        /// 指如何对齐此列的数据
        /// </summary>
        public string align
        {
            set { _align = value; }
            get { return _align; }
        }
        /// <summary>
        /// 是否隐藏列
        /// </summary>
        public bool hidden
        {
            set { _hidden = value; }
            get { return _hidden; }
        }
        /// <summary>
        /// 是否允许此列被排序
        /// </summary>
        public bool sortable
        {
            set { _sortable = value; }
            get { return _sortable; }
        }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int? showposition
        {
            set { _showposition = value; }
            get { return _showposition; }
        }
        #endregion Model

    }

    [Serializable]
    public partial class GridColumnConfigExpEntity : GridColumnConfigEntity
    {
        public GridColumnConfigExpEntity()
        { }
        #region Model
        private int _lev = 0;

        private int _placenum = 1;

        /// <summary>
        /// 所在层数
        /// </summary>
        public int Lev
        {
            set { _lev = value; }
            get { return _lev; }
        }

        /// <summary>
        /// 含有多少层数
        /// </summary>
        public int PlaceNum
        {
            set { _placenum = value; }
            get { return _placenum; }
        }

        
        #endregion Model

    }
}

