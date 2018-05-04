/**  版本信息模板在安装目录下，可自行修改。
* m_Person.cs
*
* 功 能： N/A
* 类 名： m_Person
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:33   N/A    初版
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
	/// m_Person:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_Person
	{
		public m_Person()
		{}
		#region Model
		private int _id;
		private string _vc_code;
		private string _vc_name;
		private int? _i_sex;
		private int _departmentid;
		private string _vc_job;
		private string _vc_worktype;
		private string _vc_telphone;
		private string _vc_memo;
		private int? _i_flag=0;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 工号
		/// </summary>
		public string vc_Code
		{
			set{ _vc_code=value;}
			get{return _vc_code;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string vc_Name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int? i_Sex
		{
			set{ _i_sex=value;}
			get{return _i_sex;}
		}
		/// <summary>
		/// 部门编号
		/// </summary>
		public int DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string vc_Job
		{
			set{ _vc_job=value;}
			get{return _vc_job;}
		}
		/// <summary>
		/// 工种
		/// </summary>
		public string vc_WorkType
		{
			set{ _vc_worktype=value;}
			get{return _vc_worktype;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string vc_Telphone
		{
			set{ _vc_telphone=value;}
			get{return _vc_telphone;}
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
		/// 
		/// </summary>
		public int? i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

	}
}

