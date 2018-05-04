/**  版本信息模板在安装目录下，可自行修改。
* v_unload.cs
*
* 功 能： N/A
* 类 名： v_unload
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/31 9:03:30   N/A    初版
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
	/// v_unload:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_unload
	{
		public v_unload()
		{}
		#region Model
		private int? _planid;
		private int? _vehicleid;
		private string _carcode;
		private int? _personid;
		private string _personname;
		private DateTime? _dt_datetime;
		private int? _materietypeid;
		private string _matername;
		private decimal? _n_count;
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
		public string carcode
		{
			set{ _carcode=value;}
			get{return _carcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PersonID
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string personname
		{
			set{ _personname=value;}
			get{return _personname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_DateTime
		{
			set{ _dt_datetime=value;}
			get{return _dt_datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MaterieTypeID
		{
			set{ _materietypeid=value;}
			get{return _materietypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string matername
		{
			set{ _matername=value;}
			get{return _matername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? n_Count
		{
			set{ _n_count=value;}
			get{return _n_count;}
		}
		#endregion Model

	}
}

