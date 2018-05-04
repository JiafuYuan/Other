using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_RuleDetail
    {
        public bool InsertRuleDetail(int ruleID, string vc_ModuleName)
        {
            string sqlInsertRule = "insert into m_RuleDetail(RuleID,vc_ModuleName) values(" + ruleID + ",'" + vc_ModuleName + "')";
            if (DB.OleDbHelper.ExecuteSql(sqlInsertRule) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteAll(int ruleID)
        {
            string sqlDeleteRule = "delete from m_RuleDetail where ruleID=" + ruleID;
            if (DB.OleDbHelper.ExecuteSql(sqlDeleteRule)>=0)
            {
                return true;
            }
            return false;
        }
    }
}
