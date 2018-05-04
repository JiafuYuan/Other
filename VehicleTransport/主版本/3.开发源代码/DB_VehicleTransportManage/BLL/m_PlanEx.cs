using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Plan
    {
        /// <summary>
        /// 写实际到达时间
        /// </summary>
        public void WriteArriveDateTime(int planID, DateTime datetime)
        {
            DB_VehicleTransportManage.Model.m_Plan plan = GetModel(planID);
            if (plan != null)
            {
                plan.dt_RealArriveDestinationDateTime = datetime;
                Update(plan);
            }
        }

        /// <summary>
        /// 更新计划状态
        /// </summary>
        /// <param name="planID"></param>
        /// <param name="state"></param>
        public bool UpdatePlanState(int planID, int state)
        {
            DB_VehicleTransportManage.Model.m_Plan plan = GetModel(planID);
            if (plan != null)
            {
                plan.i_State = state;
               return Update(plan);
            }
            return false;
        }

        /// <summary>
        /// 得到最新的一个对象实体
        /// </summary>
        public DB_VehicleTransportManage.Model.m_Plan GetOneNewModel()
        {
            DataSet ds = dal.GetList(1, "", "id desc");
            List<DB_VehicleTransportManage.Model.m_Plan> lst = DataTableToList(ds.Tables[0]);

            if (lst.Count == 1)
            {
                return lst[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        ///根据运单号查询
        /// </summary>
        public DB_VehicleTransportManage.Model.m_Plan GetModelByPlanCode(string planCode)
        {
            DataSet ds = dal.GetList("vc_PlanCode="+planCode);
            List<DB_VehicleTransportManage.Model.m_Plan> lst = DataTableToList(ds.Tables[0]);

            if (lst.Count == 1)
            {
                return lst[0];
            }
            else
            {
                return null;
            }
        }

        public string GetPlanIDsByDepartment(int depID)
        {
            DataSet ds = DB.OleDbHelper.GetDataSet("select p.* from m_Plan as p inner join m_Apply as a on p.ApplyID=a.ID where a.ApplyDepartmentID=" + depID);
            List<DB_VehicleTransportManage.Model.m_Plan> lst = DataTableToList(ds.Tables[0]);
            StringBuilder sb = new StringBuilder();
            foreach (DB_VehicleTransportManage.Model.m_Plan item in lst)
            {
                sb.Append(item.ID+",");
            }
            if (sb.Length>1)
            {
                return sb.Remove(sb.Length-1, 1).ToString();
            }
            return "";
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DB_VehicleTransportManage.Model.m_Plan> GetModelListByPage(string strWhere, int startIndex, int endIndex)
        {
            DataSet ds = dal.GetListByPage(strWhere, "", startIndex, endIndex);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            return null;
        }

        /// <summary>
        /// 获得数据列表,适合2000
        /// </summary>
        public List<DB_VehicleTransportManage.Model.m_Plan> GetModelListByPageEx(string strWhere, int startIndex, int pageSize)
        {
            DataSet ds = dal.GetListByPageEx(strWhere, "", startIndex, pageSize);
            if (ds != null)
            {
                return DataTableToList(ds.Tables[0]);
            }
            return null;
        }
    }
}
