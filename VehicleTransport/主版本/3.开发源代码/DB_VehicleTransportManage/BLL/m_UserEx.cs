using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_User
    {
        /// <summary>人员是否关联用户
        /// 人员是否关联用户
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool IsPersonUsed(int ID)
        {
            DataSet dataSet = dal.GetList(" i_Flag=0 and PersonID=" + ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public DataSet DropDownSource()
        {
            StringBuilder stringBuilder=new StringBuilder();
            stringBuilder.Append("select a.ID,UserName as 用户名,b.vc_Name  as 姓名 from ");
            stringBuilder.Append("(select ID,PersonID,vc_Name as UserName from m_user where i_flag=0 ) as a ");
            stringBuilder.Append("left join (select * from m_person where i_flag=0) as b on a.personid=b.ID");

            return DB.OleDbHelper.GetDataSet(stringBuilder.ToString());
        }
        /// <summary>人员是否关联用户
        /// 人员是否关联用户
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool IsRuleUsed(int ID)
        {
            DataSet dataSet = dal.GetList(" i_Flag=0 and RuleID=" + ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
      

        /// <summary>获取用户名
        /// 获取用户名
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string GetUserName(int userID)
        {
            Model.m_User userModel = GetModel(userID);

            if (userModel!=null && userModel.i_Flag==0)
            {
                return userModel.vc_Name;
            }
           
            return "";
        }


        /// <summary>获取角色ID
        /// 获取角色ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetRuleID(int userID)
        {
            Model.m_User userModel = GetModel(userID);

            if (userModel != null && userModel.i_Flag == 0)
            {
                return userModel.RuleID.Value;
            }

            return 0;
        }

        /// <summary>获取用户人员编号
        /// 获取用户人员编号
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetPersonID(int userID)
        {
            Model.m_User userModel = GetModel(userID);

            if (userModel != null && userModel.i_Flag == 0 && userModel.PersonID !=null)
            {
                return (int)userModel.PersonID;
            }

            return 0;
        }
        /// <summary>
        /// 得到在线的PC用户
        /// </summary>
        /// <returns></returns>
        public List<Model.m_User> GetOnLinePCUserList()
        {
            return new DB_VehicleTransportManage.BLL.m_User().GetModelList("i_Flag=0 and i_State=1 and i_IsPDA=0");
        }

        /// <summary>
        /// 根据用户ID取部门ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetDepartmentIDByUserID(int userID)
        {
            Model.m_User user = GetModel(userID);
            if (user!=null)
            {
                if (user.DepartmentID > 0)
                {
                    return user.DepartmentID.Value;
                }
                else
                {
                    Model.m_Person personModel = new BLL.m_Person().GetModel(user.PersonID.Value);
                    if (personModel!=null)
                    {
                        return personModel.DepartmentID;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 根据用户ID取基站ID对应的地点
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetAddressIDByUserID(int userID)
        {
            Model.m_User userModel = GetModel(userID);
            if (userModel != null)
            {
                if (userModel.WifiBaseStationID==null)
                {
                    return 0;
                }
                Model.m_WifiBaseStation wifiModel = new BLL.m_WifiBaseStation().GetModel(userModel.WifiBaseStationID.Value);
                if (wifiModel!=null)
                {
                    if (wifiModel.LocalizerStationID==null)
                    {
                        return 0;
                    }
                    return   new BLL.m_Address().GetAddressIDByLocalizerID(wifiModel.LocalizerStationID.Value);
                }
            }
            return 0;
        }


        /// <summary>
        /// 人员姓名,所属部门是否唯一
        /// </summary>
        /// <returns></returns>
        public bool IsPersonCodeExist(int PersonID,int id)
        {
            List<Model.m_User> list = null;
            if (id > 0)
            {
                list = GetModelList("i_flag=0 and PersonID=" + PersonID+" and ID<>"+id);
            }
            else
            {
                list = GetModelList("i_flag=0 and PersonID=" + PersonID);
            }
            if (list.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 标识卡号,所属部门是否唯一
        /// </summary>
        /// <returns></returns>
        public bool IsIdentificationCardHIDExist(int IdentificationCardHID, int id)
        {
            List<Model.m_User> list = null;
            if (id > 0)
            {
                list = GetModelList("i_flag=0 and i_IdentificationCardHID=" + IdentificationCardHID + " and ID<>" + id);
            }
            else
            {
                list = GetModelList("i_flag=0 and i_IdentificationCardHID=" + IdentificationCardHID);
            }
            if (list.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据用户ID取UserID
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public int GetUserIDByPersonID(int personID)
        {
            List<Model.m_User> list = null;
            
                list = GetModelList("i_flag=0 and personID=" + personID );
            
            if (list!=null && list.Count > 0)
            {
                return list[0].ID;
            }
            return 0;
        }

        /// <summary>
        /// 所属部门是否唯一
        /// </summary>
        /// <returns></returns>
        public bool IsDepartmentExist(int DepartmentID, int id)
        {
            List<Model.m_User> list = null;
            if (id > 0)
            {
                list = GetModelList("i_flag=0 and (PersonID is null or PersonID=0) and DepartmentID=" + DepartmentID + " and ID<>" + id);
            }
            else
            {
                list = GetModelList("i_flag=0 and (PersonID is null or PersonID=0) and DepartmentID=" + DepartmentID);
            }
            if (list.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
