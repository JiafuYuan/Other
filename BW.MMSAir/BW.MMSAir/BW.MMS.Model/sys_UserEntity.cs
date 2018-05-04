using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 用户表
	/// </summary>
	[Serializable]
	public partial class sys_UserEntity
	{
		public sys_UserEntity()
		{}
		#region Model
		private int _id;
		private string _vc_username;
		private string _vc_realname;
		private string _vc_password;
		private string _vc_description;
		private int? _i_flag;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名称
		/// </summary>
		public string vc_UserName
		{
			set{ _vc_username=value;}
			get{return _vc_username;}
		}
		/// <summary>
		/// 用户姓名
		/// </summary>
		public string vc_RealName
		{
			set{ _vc_realname=value;}
			get{return _vc_realname;}
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string vc_Password
		{
			set{ _vc_password=value;}
			get{return _vc_password;}
		}
		/// <summary>
		/// 用户说明
		/// </summary>
		public string vc_Description
		{
			set{ _vc_description=value;}
			get{return _vc_description;}
		}
		/// <summary>
		/// i_Flag
		/// </summary>
		public int? i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

	}
}

