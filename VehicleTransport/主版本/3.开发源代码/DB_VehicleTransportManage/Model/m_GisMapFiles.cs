using System;
namespace DB_VehicleTransportManage.Model
{
	/// <summary>
	/// m_GisMapFiles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_GisMapFiles
	{
		public m_GisMapFiles()
		{}
		#region Model
		private string _file_name;
		private byte[] _file_data;
		/// <summary>
		/// 
		/// </summary>
		public string File_Name
		{
			set{ _file_name=value;}
			get{return _file_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] File_Data
		{
			set{ _file_data=value;}
			get{return _file_data;}
		}
		#endregion Model

	}
}

