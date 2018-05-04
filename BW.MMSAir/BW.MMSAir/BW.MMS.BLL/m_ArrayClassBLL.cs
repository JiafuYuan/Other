using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
    /// <summary>
    /// 排班表
    /// </summary>
    public partial class m_ArrayClassBLL
    {
        private readonly BW.MMS.DAL.m_ArrayClassDAL dal = new BW.MMS.DAL.m_ArrayClassDAL();
        public m_ArrayClassBLL()
        { }
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
        public bool Exists(DateTime dt_Date, int DeptID, int ClassID)
        {
            return dal.Exists(dt_Date, DeptID, ClassID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BW.MMS.Model.m_ArrayClassEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BW.MMS.Model.m_ArrayClassEntity model)
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
        /// 删除数据
        /// </summary>
        public bool Delete(DateTime beginDate,DateTime endDate)
        {
            return dal.Delete(beginDate, endDate);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(DateTime dt_Date, int DeptID, int ClassID)
        {

            return dal.Delete(dt_Date, DeptID, ClassID);
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
        public BW.MMS.Model.m_ArrayClassEntity GetModel(int ID)
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
        public List<BW.MMS.Model.m_ArrayClassEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BW.MMS.Model.m_ArrayClassEntity> DataTableToList(DataTable dt)
        {
            List<BW.MMS.Model.m_ArrayClassEntity> modelList = new List<BW.MMS.Model.m_ArrayClassEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BW.MMS.Model.m_ArrayClassEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BW.MMS.Model.m_ArrayClassEntity();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["dt_Date"] != null && dt.Rows[n]["dt_Date"].ToString() != "")
                    {
                        model.dt_Date = DateTime.Parse(dt.Rows[n]["dt_Date"].ToString());
                    }
                    if (dt.Rows[n]["DeptID"] != null && dt.Rows[n]["DeptID"].ToString() != "")
                    {
                        model.DeptID = int.Parse(dt.Rows[n]["DeptID"].ToString());
                    }
                    if (dt.Rows[n]["ClassID"] != null && dt.Rows[n]["ClassID"].ToString() != "")
                    {
                        model.ClassID = int.Parse(dt.Rows[n]["ClassID"].ToString());
                    }
                    if (dt.Rows[n]["vc_Memo"] != null && dt.Rows[n]["vc_Memo"].ToString() != "")
                    {
                        model.vc_Memo = dt.Rows[n]["vc_Memo"].ToString();
                    }
                    if (dt.Rows[n]["i_Flag"] != null && dt.Rows[n]["i_Flag"].ToString() != "")
                    {
                        model.i_Flag = int.Parse(dt.Rows[n]["i_Flag"].ToString());
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

        public DataTable GetArrayClass()
        {
            return dal.GetArrayClass();
        }

        public DataTable GetArrayList(DateTime startDate, DateTime endDate)
        {
            DataSet ds = dal.GetArrayList(startDate, endDate);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

