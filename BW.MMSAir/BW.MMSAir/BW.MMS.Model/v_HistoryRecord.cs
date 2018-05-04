/**  版本信息模板在安装目录下，可自行修改。
* v_HistoryRecord.cs
*
* 功 能： N/A
* 类 名： v_HistoryRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/15 17:23:20   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BW.MMS.Model
{
	/// <summary>
	/// v_HistoryRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_HistoryRecord
	{
		public v_HistoryRecord()
		{}
		#region Model
		private string _guid;
		private string _pointname;
		private string _pointvalue;
		private string _pointdesc;
		private string _pointtype;
		private DateTime _recordtime;
		private string _recordtype;
		private string _recordway;
		private DateTime? _handletime;
		private string _handleresult;
		private string _handleuser;
		private string _priority;
		private string _area;
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
		public string PointName
		{
			set{ _pointname=value;}
			get{return _pointname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PointValue
		{
			set{ _pointvalue=value;}
			get{return _pointvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PointDesc
		{
			set{ _pointdesc=value;}
			get{return _pointdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PointType
		{
			set{ _pointtype=value;}
			get{return _pointtype;}
		}
		/// <summary>
		/// 
		/// </summary>
       [JsonConverter(typeof(IsoDateTimeConverter))]    
		public DateTime RecordTime
		{
			set{ _recordtime=value;}
			get{return _recordtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordType
		{
			set{ _recordtype=value;}
			get{return _recordtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordWay
		{
			set{ _recordway=value;}
			get{return _recordway;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? HandleTime
		{
			set{ _handletime=value;}
			get{return _handletime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HandleResult
		{
			set{ _handleresult=value;}
			get{return _handleresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HandleUser
		{
			set{ _handleuser=value;}
			get{return _handleuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Priority
		{
			set{ _priority=value;}
			get{return _priority;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		#endregion Model

	}
}

