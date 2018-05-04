using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 模块表
	/// </summary>
	[Serializable]
	public partial class sys_Module
	{
		public sys_Module()
		{}
		#region Model
		private int _id;
		private string _vc_modulename;
		private string _vc_url;
		private string _vc_icon;
		private int _parentid;
		private string _vc_description;
		private string _vc_memo;
        private int? _i_flag;
        private int? _sort;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string vc_ModuleName
		{
			set{ _vc_modulename=value;}
			get{return _vc_modulename;}
		}
		/// <summary>
		/// Url地址
		/// </summary>
		public string vc_URL
		{
			set{ _vc_url=value;}
			get{return _vc_url;}
		}
		/// <summary>
		/// 图标样式
		/// </summary>
		public string vc_Icon
		{
			set{ _vc_icon=value;}
			get{return _vc_icon;}
		}
		/// <summary>
		/// 父级模块
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 模块说明
		/// </summary>
		public string vc_Description
		{
			set{ _vc_description=value;}
			get{return _vc_description;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		/// <summary>
		/// i_Flag
		/// </summary>
		public int? i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
		#endregion Model

	}
}

