/**  版本信息模板在安装目录下，可自行修改。
* m_Address.cs
*
* 功 能： N/A
* 类 名： m_Address
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/12 10:39:05   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
namespace DB_VehicleTransportManage.Model
{
	/// <summary>
	/// m_Address:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_Address
	{
		public m_Address()
		{}
		#region Model
		private int _id;
		private string _vc_name;
		private int? _localizerstationid;
		private int? _areaid;
		private int? _i_isupmine=0;
		private int? _i_isdirectionstation=0;
	    private int? _directionlocalizerstationid = 0;
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
		public int? LocalizerStationID
		{
			set{ _localizerstationid=value;}
			get{return _localizerstationid;}
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
		public int? i_IsUpMine
		{
			set{ _i_isupmine=value;}
			get{return _i_isupmine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_IsDirectionStation
		{
			set{ _i_isdirectionstation=value;}
			get{return _i_isdirectionstation;}
		}

        /// <summary>
		/// 
		/// </summary>
        public int? DirectionLocalizerStationID
		{
            set { _directionlocalizerstationid = value; }
            get { return _directionlocalizerstationid; }
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

        public int i_State { get; set; }

	}
}

