/**  版本信息模板在安装目录下，可自行修改。
* m_VehiclePlanDetail.cs
*
* 功 能： N/A
* 类 名： m_VehiclePlanDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:37   N/A    初版
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
	/// m_VehiclePlanDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_VehiclePlanDetail
	{
		public m_VehiclePlanDetail()
		{}
		#region Model
		private int _id;
		private int? _planid;
		private int? _vehicleid;
		private DateTime? _dt_datetime;
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
		public int? PlanID
		{
			set{ _planid=value;}
			get{return _planid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VehicleID
		{
			set{ _vehicleid=value;}
			get{return _vehicleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_DateTime
		{
			set{ _dt_datetime=value;}
			get{return _dt_datetime;}
		}
		#endregion Model

	}
}

