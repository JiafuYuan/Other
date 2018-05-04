using System;
namespace SPcms.Web.Plugin.mail_send.Model
{
	/// <summary>
	/// mail_send:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class mail_send
	{
		public mail_send()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _recipients;
		private string _mailcontent;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string recipients
		{
			set{ _recipients=value;}
			get{return _recipients;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mailcontent
		{
			set{ _mailcontent=value;}
			get{return _mailcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

