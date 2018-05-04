/**  版本信息模板在安装目录下，可自行修改。
* v_Plan.cs
*
* 功 能： N/A
* 类 名： v_Plan
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/4 16:33:10   N/A    初版
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
	/// v_Plan:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_Plan
	{
		public v_Plan()
		{}
		#region Model
		private int _id;
		private DateTime? _dt_arrivedestinationdatetime;
		private int? _arrivedestinationaddressid;
		private int? _i_state;
		private int? _applyid;
		private int? _i_istemplan;
		private string _vc_plancode;
		private int? _checkpersonid;
		private DateTime? _dt_checkdatetime;
		private int? _plangivecardepartmentid;
		private string _vc_pdauserids;
		private DateTime? _dt_plangivecardatetime;
		private int? _plangivecaraddressid;
		private int? _planunloaddepartmentid;
		private int? _planbackdepartmentid;
		private DateTime? _dt_planbackdatetime;
		private int? _planbackaddressid;
		private int? _planloaddepartmentid;
		private int? _planloadaddressid;
		private int? _realgivecardepartmentid;
		private DateTime? _dt_realgivecardatetime;
		private int? _realgivecaraddressid;
		private int? _realloaddepartmentid;
		private int? _realgivecarpersonid;
		private int? _realloadpersonid;
		private int? _applydepartmentid;
		private int? _applypersonid;
		private DateTime? _dt_realloaddatetime;
		private int? _realloadaddressid;
		private DateTime? _dt_realarrivedestinationdatetime;
		private string _applydepartmentname;
		private string _planloaddepartmentname;
		private string _plangivecardepartmentname;
		private string _planunloaddepartmentname;
		private string _planbackdepartmentname;
		private string _vc_name;
		private string _realgivecardepartmentname;
		private string _realloaddepartmentname;
		private string _applypersonname;
		private string _checkpersonname;
		private string _realgivecarpersonname;
		private string _realloadpersonname;
		private string _arrivedestinationaddressname;
		private string _planloadaddressname;
		private string _plangivecaraddressname;
		private string _planbackaddressname;
		private string _expr1;
		private string _realgivecaraddressname;
		private string _realloadaddressname;
		private string _statename;
        private DateTime? _dt_PlanLoadDateTime;

        public DateTime? dt_PlanLoadDateTime
        {
            get { return _dt_PlanLoadDateTime; }
            set { _dt_PlanLoadDateTime = value; }
        }
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
		public DateTime? dt_ArriveDestinationDateTime
		{
			set{ _dt_arrivedestinationdatetime=value;}
			get{return _dt_arrivedestinationdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ArriveDestinationAddressID
		{
			set{ _arrivedestinationaddressid=value;}
			get{return _arrivedestinationaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_State
		{
			set{ _i_state=value;}
			get{return _i_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApplyID
		{
			set{ _applyid=value;}
			get{return _applyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_IsTemPlan
		{
			set{ _i_istemplan=value;}
			get{return _i_istemplan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_PlanCode
		{
			set{ _vc_plancode=value;}
			get{return _vc_plancode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CheckPersonID
		{
			set{ _checkpersonid=value;}
			get{return _checkpersonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_CheckDateTime
		{
			set{ _dt_checkdatetime=value;}
			get{return _dt_checkdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanGiveCarDepartmentID
		{
			set{ _plangivecardepartmentid=value;}
			get{return _plangivecardepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_PDAUserIDs
		{
			set{ _vc_pdauserids=value;}
			get{return _vc_pdauserids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_PlanGiveCarDateTime
		{
			set{ _dt_plangivecardatetime=value;}
			get{return _dt_plangivecardatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanGiveCarAddressID
		{
			set{ _plangivecaraddressid=value;}
			get{return _plangivecaraddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanUnLoadDepartmentID
		{
			set{ _planunloaddepartmentid=value;}
			get{return _planunloaddepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanBackDepartmentID
		{
			set{ _planbackdepartmentid=value;}
			get{return _planbackdepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_PlanBackDateTime
		{
			set{ _dt_planbackdatetime=value;}
			get{return _dt_planbackdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanBackAddressID
		{
			set{ _planbackaddressid=value;}
			get{return _planbackaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanLoadDepartmentID
		{
			set{ _planloaddepartmentid=value;}
			get{return _planloaddepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanLoadAddressID
		{
			set{ _planloadaddressid=value;}
			get{return _planloadaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealGiveCarDepartmentID
		{
			set{ _realgivecardepartmentid=value;}
			get{return _realgivecardepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_RealGiveCarDateTime
		{
			set{ _dt_realgivecardatetime=value;}
			get{return _dt_realgivecardatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealGiveCarAddressID
		{
			set{ _realgivecaraddressid=value;}
			get{return _realgivecaraddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealLoadDepartmentID
		{
			set{ _realloaddepartmentid=value;}
			get{return _realloaddepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealGiveCarPersonID
		{
			set{ _realgivecarpersonid=value;}
			get{return _realgivecarpersonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealLoadPersonID
		{
			set{ _realloadpersonid=value;}
			get{return _realloadpersonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApplyDepartmentID
		{
			set{ _applydepartmentid=value;}
			get{return _applydepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApplyPersonID
		{
			set{ _applypersonid=value;}
			get{return _applypersonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_RealLoadDateTime
		{
			set{ _dt_realloaddatetime=value;}
			get{return _dt_realloaddatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealLoadAddressID
		{
			set{ _realloadaddressid=value;}
			get{return _realloadaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_RealArriveDestinationDateTime
		{
			set{ _dt_realarrivedestinationdatetime=value;}
			get{return _dt_realarrivedestinationdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyDepartmentName
		{
			set{ _applydepartmentname=value;}
			get{return _applydepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanLoadDepartmentName
		{
			set{ _planloaddepartmentname=value;}
			get{return _planloaddepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanGiveCarDepartmentName
		{
			set{ _plangivecardepartmentname=value;}
			get{return _plangivecardepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanUnLoadDepartmentName
		{
			set{ _planunloaddepartmentname=value;}
			get{return _planunloaddepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanBackDepartmentName
		{
			set{ _planbackdepartmentname=value;}
			get{return _planbackdepartmentname;}
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
		public string RealGiveCarDepartmentName
		{
			set{ _realgivecardepartmentname=value;}
			get{return _realgivecardepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealLoadDepartmentName
		{
			set{ _realloaddepartmentname=value;}
			get{return _realloaddepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyPersonName
		{
			set{ _applypersonname=value;}
			get{return _applypersonname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckPersonName
		{
			set{ _checkpersonname=value;}
			get{return _checkpersonname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealGiveCarPersonName
		{
			set{ _realgivecarpersonname=value;}
			get{return _realgivecarpersonname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealLoadPersonName
		{
			set{ _realloadpersonname=value;}
			get{return _realloadpersonname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArriveDestinationAddressName
		{
			set{ _arrivedestinationaddressname=value;}
			get{return _arrivedestinationaddressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanLoadAddressName
		{
			set{ _planloadaddressname=value;}
			get{return _planloadaddressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanGiveCarAddressName
		{
			set{ _plangivecaraddressname=value;}
			get{return _plangivecaraddressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanBackAddressName
		{
			set{ _planbackaddressname=value;}
			get{return _planbackaddressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Expr1
		{
			set{ _expr1=value;}
			get{return _expr1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealGiveCarAddressName
		{
			set{ _realgivecaraddressname=value;}
			get{return _realgivecaraddressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealLoadAddressName
		{
			set{ _realloadaddressname=value;}
			get{return _realloadaddressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string statename
		{
			set{ _statename=value;}
			get{return _statename;}
		}
		#endregion Model

	}
}

