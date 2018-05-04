using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 传感器关系表
	/// </summary>
	[Serializable]
	public partial class m_SensorRelationshipEntity
	{
		public m_SensorRelationshipEntity()
		{}
		#region Model
		private int? _id;
		private int _sensorid;
		private int? _parentsensorid;
		private int? _i_flag;
		private string _vc_memo;
		/// <summary>
		/// ID
		/// </summary>
		public int? ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 传感器ID
		/// </summary>
		public int SensorID
		{
			set{ _sensorid=value;}
			get{return _sensorid;}
		}
		/// <summary>
		/// 父节点传感器ID
		/// </summary>
		public int? ParentSensorID
		{
			set{ _parentsensorid=value;}
			get{return _parentsensorid;}
		}
		/// <summary>
		/// i_Flag
		/// </summary>
		public int? i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		/// <summary>
		/// vc_Memo
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		#endregion Model

	}
}

