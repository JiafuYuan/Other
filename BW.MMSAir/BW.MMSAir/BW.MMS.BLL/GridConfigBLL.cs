using System;
using System.Data;
using System.Collections.Generic;
using BW.MMS.Model;

namespace BW.MMS.BLL
{
    /// <summary>
    /// GridConfigEntity
    /// </summary>
    public partial class GridConfigBLL
    {
        private readonly BW_AutoMationSysConfig.DAL.GridConfigDAL dal = new BW_AutoMationSysConfig.DAL.GridConfigDAL();

        public GridConfigBLL()
        {
        }

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
        public int Add(BW.MMS.Model.GridConfigEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BW.MMS.Model.GridConfigEntity model)
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
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BW.MMS.Model.GridConfigEntity GetModel(int ID)
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BW.MMS.Model.GridConfigEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BW.MMS.Model.GridConfigEntity> DataTableToList(DataTable dt)
        {
            List<BW.MMS.Model.GridConfigEntity> modelList =
                new List<BW.MMS.Model.GridConfigEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BW.MMS.Model.GridConfigEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BW.MMS.Model.GridConfigEntity();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["GridKeyName"] != null && dt.Rows[n]["GridKeyName"].ToString() != "")
                    {
                        model.GridKeyName = dt.Rows[n]["GridKeyName"].ToString();
                    }
                    if (dt.Rows[n]["ChineseName"] != null && dt.Rows[n]["ChineseName"].ToString() != "")
                    {
                        model.ChineseName = dt.Rows[n]["ChineseName"].ToString();
                    }
                    if (dt.Rows[n]["ApplicationCode"] != null && dt.Rows[n]["ApplicationCode"].ToString() != "")
                    {
                        model.ApplicationCode = dt.Rows[n]["ApplicationCode"].ToString();
                    }
                    if (dt.Rows[n]["IDField"] != null && dt.Rows[n]["IDField"].ToString() != "")
                    {
                        model.IDField = dt.Rows[n]["IDField"].ToString();
                    }
                    if (dt.Rows[n]["ischk"] != null && dt.Rows[n]["ischk"].ToString() != "")
                    {
                        if ((dt.Rows[n]["ischk"].ToString() == "1") ||
                            (dt.Rows[n]["ischk"].ToString().ToLower() == "true"))
                        {
                            model.ischk = true;
                        }
                        else
                        {
                            model.ischk = false;
                        }
                    }
                    if (dt.Rows[n]["PageCode"] != null && dt.Rows[n]["PageCode"].ToString() != "")
                    {
                        model.PageCode = dt.Rows[n]["PageCode"].ToString();
                    }
                    if (dt.Rows[n]["Type"] != null && dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = dt.Rows[n]["Type"].ToString();
                    }
                    if (dt.Rows[n]["TVName"] != null && dt.Rows[n]["TVName"].ToString() != "")
                    {
                        model.TVName = dt.Rows[n]["TVName"].ToString();
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method

        /// <summary>
        /// grid配置数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="sort"></param>
        /// <param name="dir"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public List<BW.MMS.Model.GridConfigEntity> GetPagingList(string name, int page, int rows, string sort, string order, out int record)
        {
            DataTable dt = dal.GetPagingList(name, page, rows, sort, order, out record);
            return DataTableToList(dt);
        }
        /// <summary>
        /// 获取表和视图集合
        /// </summary>
        /// <returns>DataSet</returns>
        public DataTable GetTableViews(string type)
        {
            return dal.GetTableViews(type).Tables[0];
        }
        /// <summary>
        /// 获取指定表/视图字段信息
        /// </summary>
        /// <param name="gridconfigID"></param>
        /// <param name="ParentID"></param>
        /// <param name="tvName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public DataTable GetTVField(int gridconfigID, int ParentID, string tvName,string type)
        {
            DataSet ds = dal.GetTVField(gridconfigID, ParentID, tvName, type);
            if (ds == null || ds.Tables.Count == 0)
            {
                return null;
            }
            return ds.Tables[0];
        }
    }
}

