using System;
using System.Data;
using System.Collections.Generic;
using SPcms.Common;

namespace SPcms.Web.Plugin.FLink.BLL
{
	/// <summary>
	/// Flink
	/// </summary>
	public partial class Flink
	{
        private readonly SPcms.Model.siteconfig siteConfig = new SPcms.BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.Flink dal;
		public Flink()
		{
            dal = new DAL.Flink(siteConfig.sysdatabaseprefix);
        }

		#region  BasicMethod

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Model.Flink model)
		{
			return dal.Add(model);
		}
        /// <summary>
		/// ����һ������
		/// </summary>
        public void UpdateField(int id,string strValue)
		{
             dal.UpdateField(id, strValue);
		}
        
		/// <summary>
		/// ����һ������
		/// </summary>
        public bool Update(Model.Flink model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public Model.Flink GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
        /// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public Model.Flink GetModel(int id, bool t)
        {

            return dal.GetModel(id, t);


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
		public List<Model.Flink> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
        public List<Model.Flink> DataTableToList(DataTable dt)
		{
            List<Model.Flink> modelList = new List<Model.Flink>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Model.Flink model;
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

