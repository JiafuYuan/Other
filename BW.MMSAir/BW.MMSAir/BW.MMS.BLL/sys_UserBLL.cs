using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class sys_UserBLL
    {
        private readonly BW.MMS.DAL.sys_UserDAL dal = new BW.MMS.DAL.sys_UserDAL();
        public sys_UserBLL()
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
        public int Add(BW.MMS.Model.sys_UserEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BW.MMS.Model.sys_UserEntity model)
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
        public BW.MMS.Model.sys_UserEntity GetModel(int ID)
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
        public List<BW.MMS.Model.sys_UserEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BW.MMS.Model.sys_UserEntity> DataTableToList(DataTable dt)
        {
            List<BW.MMS.Model.sys_UserEntity> modelList = new List<BW.MMS.Model.sys_UserEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BW.MMS.Model.sys_UserEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new BW.MMS.Model.sys_UserEntity();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["vc_UserName"] != null && dt.Rows[n]["vc_UserName"].ToString() != "")
                    {
                        model.vc_UserName = dt.Rows[n]["vc_UserName"].ToString();
                    }
                    if (dt.Rows[n]["vc_RealName"] != null && dt.Rows[n]["vc_RealName"].ToString() != "")
                    {
                        model.vc_RealName = dt.Rows[n]["vc_RealName"].ToString();
                    }
                    if (dt.Rows[n]["vc_Password"] != null && dt.Rows[n]["vc_Password"].ToString() != "")
                    {
                        model.vc_Password = dt.Rows[n]["vc_Password"].ToString();
                    }
                    if (dt.Rows[n]["vc_Description"] != null && dt.Rows[n]["vc_Description"].ToString() != "")
                    {
                        model.vc_Description = dt.Rows[n]["vc_Description"].ToString();
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
        /// 用户分页数据
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="page">当前页</param>
        /// <param name="rows">每页显示条数</param>
        /// <param name="sort">提序字段</param>
        /// <param name="order">排序方式</param>
        /// <param name="total">返回总条数</param>
        /// <returns></returns>
        public List<BW.MMS.Model.sys_UserEntity> GetPagingList(string name, int page, int rows, string sort, string order, out int total)
        {
            DataTable dt = dal.GetPagingList(name, page, rows, sort, order, out total);
            return DataTableToList(dt);
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

