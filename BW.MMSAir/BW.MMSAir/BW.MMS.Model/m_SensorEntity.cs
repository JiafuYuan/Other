using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 传感器信息表
	/// </summary>
	[Serializable]
	public partial class m_SensorEntity
	{
		public m_SensorEntity()
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
		private int _i_flag;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 传感器编号
		/// </summary>
		public string vc_Code
		{
			set{ _vc_code=value;}
			get{return _vc_code;}
		}
		/// <summary>
		/// 传感器类型
		/// </summary>
		public int? TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 安装位置
		/// </summary>
		public string vc_Address
		{
			set{ _vc_address=value;}
			get{return _vc_address;}
		}
		/// <summary>
		/// 所属区域
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 使用单位
		/// </summary>
		public int? DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 能耗类型
		/// </summary>
		public int? EnergyType
		{
			set{ _energytype=value;}
			get{return _energytype;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		/// <summary>
		/// i_Flag
		/// </summary>
		public int i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

	}
}

