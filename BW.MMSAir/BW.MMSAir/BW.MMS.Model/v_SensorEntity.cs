using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// v_SensorEntity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_SensorEntity
	{
		public v_SensorEntity()
		{}
		#region Model
		private int _id;
		private string _vc_code;
		private int? _typeid;
		private string _vc_address;
		private int? _areaid;
		private int? _deptid;
		private int? _energytype;
		private string _vc_memo;
		private int? _i_flag;
		private string _typename;
		private string _areaname;
		private string _deptname;
		private string _energytypename;
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
		public int? TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Address
		{
			set{ _vc_address=value;}
			get{return _vc_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EnergyType
		{
			set{ _energytype=value;}
			get{return _energytype;}
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
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EnergyTypeName
		{
			set{ _energytypename=value;}
			get{return _energytypename;}
		}
		#endregion Model

	}
}

