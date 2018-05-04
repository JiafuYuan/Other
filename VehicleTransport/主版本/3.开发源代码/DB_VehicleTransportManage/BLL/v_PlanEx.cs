using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class v_Plan
    {

        public bool IsDepartmentUsed(int ID)
        {
            DataSet dataSet = dal.GetList(String.Format("  i_State<>6 and (ApplyDepartmentID={0} or PlanBackDepartmentID ={0} or PlanGiveCarDepartmentID={0} " +
                                                        "or PlanLoadDepartmentID={0} or PlanUnLoadDepartmentID={0} " +
                                                        "or RealBackDepartmentID={0} or RealGiveCarDepartmentID={0} " +
                                                        "or RealLoadDepartmentID={0} or RealUnLoadDepartmentID={0})", ID));
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsPersonUsed(int ID)
        {
            DataSet dataSet = dal.GetList(String.Format("  i_State<>6 and (CheckPersonID ={0} or ApplyPersonID={0})", ID));
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        //因为v_plan,实际装车地点和卸车地点不判断【2014-10-30】
        public bool IsAddressUsed(int ID)
        {
            DataSet dataSet = dal.GetList(String.Format("   i_State<>6 and (ArriveDestinationAddressID={0} or " +
                                                        "PlanBackAddressID={0} and PlanGiveCarAddressID={0}" +
                                                        " or PlanLoadAddressID={0} or RealGiveCarAddressID={0} )", ID));
                                                        //"or RealGiveCarAddressID={0} or RealLoadAddressID={0} or " +
                                                        //"RealUnLoadAddressID={0})", ID));
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
