using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
    /// <summary>
    /// 历史告警数据表
    /// </summary>
    public partial class Alarm_HistoryBLL
    {
        private readonly BW.MMS.DAL.Alarm_HistoryDAL dal = new BW.MMS.DAL.Alarm_HistoryDAL();
        public Alarm_HistoryBLL()
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
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BW.MMS.Model.Alarm_HistoryEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BW.MMS.Model.Alarm_HistoryEntity model)
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
        public BW.MMS.Model.Alarm_HistoryEntity GetModel(int ID)
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
        public List<BW.MMS.Model.Alarm_HistoryEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BW.MMS.Model.Alarm_HistoryEntity> DataTableToList(DataTable dt)
        {
            List<BW.MMS.Model.Alarm_HistoryEntity> modelList = new List<BW.MMS.Model.Alarm_HistoryEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BW.MMS.Model.Alarm_HistoryEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BW.MMS.Model.Alarm_HistoryEntity();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["AlarmTypeID"] != null && dt.Rows[n]["AlarmTypeID"].ToString() != "")
                    {
                        model.AlarmTypeID = int.Parse(dt.Rows[n]["AlarmTypeID"].ToString());
                    }
                    if (dt.Rows[n]["AreaID"] != null && dt.Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(dt.Rows[n]["AreaID"].ToString());
                    }
                    if (dt.Rows[n]["vc_Address"] != null && dt.Rows[n]["vc_Address"].ToString() != "")
                    {
                        model.vc_Address = dt.Rows[n]["vc_Address"].ToString();
                    }
                    if (dt.Rows[n]["dt_BeginTime"] != null && dt.Rows[n]["dt_BeginTime"].ToString() != "")
                    {
                        model.dt_BeginTime = DateTime.Parse(dt.Rows[n]["dt_BeginTime"].ToString());
                    }
                    if (dt.Rows[n]["dt_EndTime"] != null && dt.Rows[n]["dt_EndTime"].ToString() != "")
                    {
                        model.dt_EndTime = DateTime.Parse(dt.Rows[n]["dt_EndTime"].ToString());
                    }
                    if (dt.Rows[n]["vc_AlarmReason"] != null && dt.Rows[n]["vc_AlarmReason"].ToString() != "")
                    {
                        model.vc_AlarmReason = dt.Rows[n]["vc_AlarmReason"].ToString();
                    }
                    if (dt.Rows[n]["vc_UnAlarmPlan"] != null && dt.Rows[n]["vc_UnAlarmPlan"].ToString() != "")
                    {
                        model.vc_UnAlarmPlan = dt.Rows[n]["vc_UnAlarmPlan"].ToString();
                    }
                    if (dt.Rows[n]["DeptID"] != null && dt.Rows[n]["DeptID"].ToString() != "")
                    {
                        model.DeptID = int.Parse(dt.Rows[n]["DeptID"].ToString());
                    }
                    if (dt.Rows[n]["vc_DeptName"] != null && dt.Rows[n]["vc_DeptName"].ToString() != "")
                    {
                        model.vc_DeptName = dt.Rows[n]["vc_DeptName"].ToString();
                    }
                    if (dt.Rows[n]["PersonID"] != null && dt.Rows[n]["PersonID"].ToString() != "")
                    {
                        model.PersonID = int.Parse(dt.Rows[n]["PersonID"].ToString());
                    }
                    if (dt.Rows[n]["vc_PersonNmae"] != null && dt.Rows[n]["vc_PersonNmae"].ToString() != "")
                    {
                        model.vc_PersonNmae = dt.Rows[n]["vc_PersonNmae"].ToString();
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
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <param name="page">当前页</param>
        /// <param name="rows">每页显示条数</param>
        /// <param name="sort">提序字段</param>
        /// <param name="order">排序方式</param>
        /// <param name="total">返回总条数</param>
        /// <returns></returns>
        public DataTable GetPagingList(string where, int page, int rows, string sort, string order, out int total)
        {
            return dal.GetPagingList(where, page, rows, sort, order, out total);
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

