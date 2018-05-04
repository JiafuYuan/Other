/**  版本信息模板在安装目录下，可自行修改。
* m_Vehicle.cs
*
* 功 能： N/A
* 类 名： m_Vehicle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-14 16:48:07   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace DB_VehicleTransportManage.Model
{
	/// <summary>
	/// m_Vehicle:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_Vehicle
	{
		public m_Vehicle()
		{}
		#region Model
		private int _id;
		private string _vc_code;
		private string _vc_name;
		private int? _vehicletypeid;
		private int? _departmentid;
		private int _i_state=0;
		private int? _i_safeload;
		private int _i_localizerstationid=0;
		private DateTime? _dt_inlocalizerstationdatetime;
		private int? _i_maintaininterval=10;
		private DateTime? _dt_scrapdatetime;
		private DateTime? _dt_createdatetime;
		private DateTime? _dt_lastmaintaindatetime;
		private string _vc_memo;
		private int? _i_flag;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Code
		{
			set{ _vc_code=value;}
			get{return _vc_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VehicleTypeID
		{
			set{ _vehicletypeid=value;}
			get{return _vehicletypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_State
		{
			set{ _i_state=value;}
			get{return _i_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_SafeLoad
		{
			set{ _i_safeload=value;}
			get{return _i_safeload;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_LocalizerStationID
		{
			set{ _i_localizerstationid=value;}
			get{return _i_localizerstationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_InLocalizerStationDateTime
		{
			set{ _dt_inlocalizerstationdatetime=value;}
			get{return _dt_inlocalizerstationdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_MaintainInterval
		{
			set{ _i_maintaininterval=value;}
			get{return _i_maintaininterval;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_ScrapDateTime
		{
			set{ _dt_scrapdatetime=value;}
			get{return _dt_scrapdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_CreateDateTime
		{
			set{ _dt_createdatetime=value;}
			get{return _dt_createdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_LastMaintainDateTIme
		{
			set{ _dt_lastmaintaindatetime=value;}
			get{return _dt_lastmaintaindatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

        public int i_LastLocalizerStationID { get; set; }

        public int i_LocalizerStationIDChanaged { get; set; }
	}
}

