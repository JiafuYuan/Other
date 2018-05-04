/**  版本信息模板在安装目录下，可自行修改。
* m_EventCode.cs
*
* 功 能： N/A
* 类 名： m_EventCode
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/16 16:21:59   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace JSCERT.Model
{
	/// <summary>
	/// m_EventCode:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_EventCode
	{
		public m_EventCode()
		{}
		#region Model
		private string _eventcode;
		private string _eventtype;
		private string _artilecode;
		private DateTime _finddate;
		private DateTime _uploaddate;
		private string _admin;
		/// <summary>
		/// 
		/// </summary>
		public string EventCode
		{
			set{ _eventcode=value;}
			get{return _eventcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EventType
		{
			set{ _eventtype=value;}
			get{return _eventtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArtileCode
		{
			set{ _artilecode=value;}
			get{return _artilecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime FindDate
		{
			set{ _finddate=value;}
			get{return _finddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UploadDate
		{
			set{ _uploaddate=value;}
			get{return _uploaddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Admin
		{
			set{ _admin=value;}
			get{return _admin;}
		}
		#endregion Model

	}
}

