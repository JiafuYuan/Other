/**  版本信息模板在安装目录下，可自行修改。
* Regions.cs
*
* 功 能： N/A
* 类 名： Regions
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/10 10:26:04   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// Regions:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Regions
	{
		public Regions()
		{}
		#region Model
		private string _guid;
		private string _display_name;
		private string _parent_guid;
		private string _code;
		private string _description;
		private int _status;
		private DateTime _create_time;
		private DateTime _modify_time;
		/// <summary>
		/// 
		/// </summary>
		public string GUID
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Display_Name
		{
			set{ _display_name=value;}
			get{return _display_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Parent_GUID
		{
			set{ _parent_guid=value;}
			get{return _parent_guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Create_Time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Modify_Time
		{
			set{ _modify_time=value;}
			get{return _modify_time;}
		}
		#endregion Model

	}
}

