/**  �汾��Ϣģ���ڰ�װĿ¼�£��������޸ġ�
* m_Plan_GiveVehicle.cs
*
* �� �ܣ� N/A
* �� ���� m_Plan_GiveVehicle
*
* Ver    �������             ������  �������
* ����������������������������������������������������������������������
* V0.01  2014-08-11 11:08:35   N/A    ����
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*������������������������������������������������������������������������
*�����˼�����ϢΪ����˾������Ϣ��δ������˾����ͬ���ֹ���������¶������
*������Ȩ���У�����׿Խ���������Ƽ����޹�˾������������������������������
*������������������������������������������������������������������������
*/
using System;
using System.Data;
using System.Collections.Generic;

using DB_VehicleTransportManage.Model;
namespace DB_VehicleTransportManage.BLL
{
	/// <summary>
	/// m_Plan_GiveVehicle
	/// </summary>
	public partial class m_Plan_GiveVehicle
	{
		private readonly DB_VehicleTransportManage.DAL.m_Plan_GiveVehicle dal=new DB_VehicleTransportManage.DAL.m_Plan_GiveVehicle();
		public m_Plan_GiveVehicle()
		{}
		#region  BasicMethod



		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(DB_VehicleTransportManage.Model.m_Plan_GiveVehicle model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(DB_VehicleTransportManage.Model.m_Plan_GiveVehicle model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return false;
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DB_VehicleTransportManage.Model.m_Plan_GiveVehicle GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}



		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DB_VehicleTransportManage.Model.m_Plan_GiveVehicle> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DB_VehicleTransportManage.Model.m_Plan_GiveVehicle> DataTableToList(DataTable dt)
		{
			List<DB_VehicleTransportManage.Model.m_Plan_GiveVehicle> modelList = new List<DB_VehicleTransportManage.Model.m_Plan_GiveVehicle>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_VehicleTransportManage.Model.m_Plan_GiveVehicle model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

