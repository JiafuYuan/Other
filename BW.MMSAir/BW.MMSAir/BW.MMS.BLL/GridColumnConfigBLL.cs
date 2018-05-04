using System;
using System.Data;
using System.Collections.Generic;
using BW.MMS.Model;

namespace BW.MMS.BLL
{
	/// <summary>
	/// GridColumnConfigEntity
	/// </summary>
	public partial class GridColumnConfigBLL
	{
        private readonly BW_AutoMationSysConfig.DAL.GridColumnConfigDAL dal = new BW_AutoMationSysConfig.DAL.GridColumnConfigDAL();
        public GridColumnConfigBLL()
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
        public int Add(BW.MMS.Model.GridColumnConfigEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BW.MMS.Model.GridColumnConfigEntity model)
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
        public BW.MMS.Model.GridColumnConfigEntity GetModel(int ID)
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
        public List<BW.MMS.Model.GridColumnConfigEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BW.MMS.Model.GridColumnConfigEntity> DataTableToList(DataTable dt)
        {
            List<BW.MMS.Model.GridColumnConfigEntity> modelList = new List<BW.MMS.Model.GridColumnConfigEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BW.MMS.Model.GridColumnConfigEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BW.MMS.Model.GridColumnConfigEntity();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["gridconfigID"] != null && dt.Rows[n]["gridconfigID"].ToString() != "")
                    {
                        model.gridconfigID = int.Parse(dt.Rows[n]["gridconfigID"].ToString());
                    }
                    if (dt.Rows[n]["ParentID"] != null && dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["field"] != null && dt.Rows[n]["field"].ToString() != "")
                    {
                        model.field = dt.Rows[n]["field"].ToString();
                    }
                    if (dt.Rows[n]["width"] != null && dt.Rows[n]["width"].ToString() != "")
                    {
                        model.width = int.Parse(dt.Rows[n]["width"].ToString());
                    }
                    if (dt.Rows[n]["rowspan"] != null && dt.Rows[n]["rowspan"].ToString() != "")
                    {
                        model.rowspan = int.Parse(dt.Rows[n]["rowspan"].ToString());
                    }
                    if (dt.Rows[n]["iscolspan"] != null && dt.Rows[n]["iscolspan"].ToString() != "")
                    {
                        if ((dt.Rows[n]["iscolspan"].ToString() == "1") || (dt.Rows[n]["iscolspan"].ToString().ToLower() == "true"))
                        {
                            model.iscolspan = true;
                        }
                        else
                        {
                            model.iscolspan = false;
                        }
                    }
                    if (dt.Rows[n]["colspan"] != null && dt.Rows[n]["colspan"].ToString() != "")
                    {
                        model.colspan = int.Parse(dt.Rows[n]["colspan"].ToString());
                    }
                    if (dt.Rows[n]["align"] != null && dt.Rows[n]["align"].ToString() != "")
                    {
                        model.align = dt.Rows[n]["align"].ToString();
                    }
                    if (dt.Rows[n]["hidden"] != null && dt.Rows[n]["hidden"].ToString() != "")
                    {
                        if ((dt.Rows[n]["hidden"].ToString() == "1") || (dt.Rows[n]["hidden"].ToString().ToLower() == "true"))
                        {
                            model.hidden = true;
                        }
                        else
                        {
                            model.hidden = false;
                        }
                    }
                    if (dt.Rows[n]["sortable"] != null && dt.Rows[n]["sortable"].ToString() != "")
                    {
                        if ((dt.Rows[n]["sortable"].ToString() == "1") || (dt.Rows[n]["sortable"].ToString().ToLower() == "true"))
                        {
                            model.sortable = true;
                        }
                        else
                        {
                            model.sortable = false;
                        }
                    }
                    if (dt.Rows[n]["showposition"] != null && dt.Rows[n]["showposition"].ToString() != "")
                    {
                        model.showposition = int.Parse(dt.Rows[n]["showposition"].ToString());
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

        #endregion  Method

        /// <summary>
        /// grid配置详情
        /// </summary>
        /// <param name="GridID"></param>
        /// <param name="ParentID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="sort"></param>
        /// <param name="dir"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public DataTable GetPagingList(int GridID,int ParentID, int PageIndex, int PageSize, string sort, string dir, out int RecordCount)
        {
            return dal.GetPagingList(GridID, ParentID, PageIndex, PageSize, sort, dir, out RecordCount);
        }

        /// <summary>
        /// 获取指定表/视图字段信息
        /// </summary>
        /// <param name="gridconfigID"></param>
        /// <param name="ParentID"></param>
        /// <param name="tvName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public DataTable GetTVField(int gridconfigID, int ParentID, string tvName, string connection)
        {
            return dal.GetTVField(gridconfigID, ParentID, tvName, connection).Tables[0];
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByGridID(string gridID)
        {
            return dal.DeleteByGridID(gridID);
        }

         /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByParentID(int ParentID, int gridID)
        {
            return dal.DeleteByParentID(ParentID, gridID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByParentID(int ParentID)
        {
            return dal.DeleteByParentID(ParentID);
        }

         /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetListLev(string strWhere)
        {
            return dal.GetListLev(strWhere).Tables[0];
        }
	}
}

