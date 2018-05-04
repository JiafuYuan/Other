using System;
using System.Data;
using System.Collections.Generic;
using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// m_CDR
	/// </summary>
	public partial class m_CDR
	{
		private readonly BW.MMS.DAL.m_CDR dal=new BW.MMS.DAL.m_CDR();
		public m_CDR()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BW.MMS.Model.m_CDR model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.m_CDR model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.m_CDR GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_CDR> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_CDR> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.m_CDR> modelList = new List<BW.MMS.Model.m_CDR>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.m_CDR model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.m_CDR();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["vc_CallingNum"]!=null && dt.Rows[n]["vc_CallingNum"].ToString()!="")
					{
					model.vc_CallingNum=dt.Rows[n]["vc_CallingNum"].ToString();
					}
					if(dt.Rows[n]["vc_CalledNum"]!=null && dt.Rows[n]["vc_CalledNum"].ToString()!="")
					{
					model.vc_CalledNum=dt.Rows[n]["vc_CalledNum"].ToString();
					}
					if(dt.Rows[n]["dt_SetupTime"]!=null && dt.Rows[n]["dt_SetupTime"].ToString()!="")
					{
						model.dt_SetupTime=DateTime.Parse(dt.Rows[n]["dt_SetupTime"].ToString());
					}
					if(dt.Rows[n]["dt_ConnectTime"]!=null && dt.Rows[n]["dt_ConnectTime"].ToString()!="")
					{
						model.dt_ConnectTime=DateTime.Parse(dt.Rows[n]["dt_ConnectTime"].ToString());
					}
					if(dt.Rows[n]["dt_AnswerTime"]!=null && dt.Rows[n]["dt_AnswerTime"].ToString()!="")
					{
						model.dt_AnswerTime=DateTime.Parse(dt.Rows[n]["dt_AnswerTime"].ToString());
					}
					if(dt.Rows[n]["dt_DisconnectTime"]!=null && dt.Rows[n]["dt_DisconnectTime"].ToString()!="")
					{
						model.dt_DisconnectTime=DateTime.Parse(dt.Rows[n]["dt_DisconnectTime"].ToString());
					}
					if(dt.Rows[n]["dt_RemoteDisconnecTime"]!=null && dt.Rows[n]["dt_RemoteDisconnecTime"].ToString()!="")
					{
						model.dt_RemoteDisconnecTime=DateTime.Parse(dt.Rows[n]["dt_RemoteDisconnecTime"].ToString());
					}
					if(dt.Rows[n]["i_Duration"]!=null && dt.Rows[n]["i_Duration"].ToString()!="")
					{
						model.i_Duration=long.Parse(dt.Rows[n]["i_Duration"].ToString());
					}
					if(dt.Rows[n]["vc_HostIP"]!=null && dt.Rows[n]["vc_HostIP"].ToString()!="")
					{
					model.vc_HostIP=dt.Rows[n]["vc_HostIP"].ToString();
					}
					if(dt.Rows[n]["vc_VisitIP"]!=null && dt.Rows[n]["vc_VisitIP"].ToString()!="")
					{
					model.vc_VisitIP=dt.Rows[n]["vc_VisitIP"].ToString();
					}
					if(dt.Rows[n]["i_rpc"]!=null && dt.Rows[n]["i_rpc"].ToString()!="")
					{
						model.i_rpc=int.Parse(dt.Rows[n]["i_rpc"].ToString());
					}
					if(dt.Rows[n]["i_rpno"]!=null && dt.Rows[n]["i_rpno"].ToString()!="")
					{
						model.i_rpno=int.Parse(dt.Rows[n]["i_rpno"].ToString());
					}
					if(dt.Rows[n]["i_ServiceProvider"]!=null && dt.Rows[n]["i_ServiceProvider"].ToString()!="")
					{
						model.i_ServiceProvider=int.Parse(dt.Rows[n]["i_ServiceProvider"].ToString());
					}
					if(dt.Rows[n]["i_CallType"]!=null && dt.Rows[n]["i_CallType"].ToString()!="")
					{
						model.i_CallType=int.Parse(dt.Rows[n]["i_CallType"].ToString());
					}
					if(dt.Rows[n]["i_TalkType"]!=null && dt.Rows[n]["i_TalkType"].ToString()!="")
					{
						model.i_TalkType=int.Parse(dt.Rows[n]["i_TalkType"].ToString());
					}
					if(dt.Rows[n]["i_ChargeValue"]!=null && dt.Rows[n]["i_ChargeValue"].ToString()!="")
					{
						model.i_ChargeValue=long.Parse(dt.Rows[n]["i_ChargeValue"].ToString());
					}
					if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
					{
					model.vc_Memo=dt.Rows[n]["vc_Memo"].ToString();
					}
					if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
					{
						model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
					}
					if(dt.Rows[n]["vc_Path"]!=null && dt.Rows[n]["vc_Path"].ToString()!="")
					{
					model.vc_Path=dt.Rows[n]["vc_Path"].ToString();
					}
					if(dt.Rows[n]["vc_recPath"]!=null && dt.Rows[n]["vc_recPath"].ToString()!="")
					{
					model.vc_recPath=dt.Rows[n]["vc_recPath"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        public DataTable GetPagingList(string name, int page, int rows, string sort, string order, out int total)
        {
            DataTable dt = dal.GetPagingList(name, page, rows, sort, order, out total);
            return dt;
        }
		#endregion  Method
	}
}

