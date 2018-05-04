using System;
namespace SPcms.Web.Plugin.FLink.Model
{
	/// <summary>
	/// Flink:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Flink
	{
		public Flink()
		{}
		#region Model
        private string _id;
		private string _Flinkurl;
		private string _Flinkname;
		private string _Flinkcode;
		private string _Flinktfcode;
        private string _FlinkNotfcode;
		private int? _Flinktfnum;
		private string _Flinktfcontent;
		private DateTime? _faddtime;
		private DateTime? _fupdatetime;
        private int _Flinkstat;
		/// <summary>
		/// 
		/// </summary>
        public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int Flinkstat
        {
            set { _Flinkstat = value; }
            get { return _Flinkstat; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Flinkurl
		{
			set{ _Flinkurl=value;}
			get{return _Flinkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Flinkname
		{
			set{ _Flinkname=value;}
			get{return _Flinkname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Flinkcode
		{
			set{ _Flinkcode=value;}
			get{return _Flinkcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FlinktfCode
		{
			set{ _Flinktfcode=value;}
			get{return _Flinktfcode;}
		}
        public string FlinkNotfcode
		{
            set { _FlinkNotfcode = value; }
            get { return _FlinkNotfcode; }
		}
        
		/// <summary>
		/// 
		/// </summary>
		public int? Flinktfnum
		{
			set{ _Flinktfnum=value;}
			get{return _Flinktfnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Flinktfcontent
		{
			set{ _Flinktfcontent=value;}
			get{return _Flinktfcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Faddtime
		{
			set{ _faddtime=value;}
			get{return _faddtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Fupdatetime
		{
			set{ _fupdatetime=value;}
			get{return _fupdatetime;}
		}
		#endregion Model

	}
}

