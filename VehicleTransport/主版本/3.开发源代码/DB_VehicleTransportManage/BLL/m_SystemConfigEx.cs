using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_SystemConfig
    {
        /// <summary>
        /// 根据KEY取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(EnumSystemConfigKeys key)
        {
            return GetValue(key.ToString());
        }

        /// <summary>
        /// 写入值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetValue(EnumSystemConfigKeys key, string value)
        {
            return SetValue(key.ToString(), value);
        }

        /// <summary>
        /// 根据关键字取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetValue(string key)
        {
            try
            {
                List<Model.m_SystemConfig> lst = GetModelList("vc_key='" + key + "'");
                if (lst != null && lst.Count == 1)
                {
                    return lst[0].vc_Value;
                }
                else
                {
                    dal.Add(new Model.m_SystemConfig()
                    {
                        vc_Key = key,
                        vc_Value = ""
                    });
                }
            }
            catch (Exception)
            {
                
               
            }
           
            return "";
        }

        /// <summary>
        /// 写值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool SetValue(string key, string value)
        {
            List<Model.m_SystemConfig> lst = GetModelList("vc_key='" + key + "'");
            if (lst != null && lst.Count == 1)
            {
                lst[0].vc_Value = value;
                return dal.Update(lst[0]);
            }
            else
            {
                return dal.Add(new Model.m_SystemConfig()
                {
                    vc_Key = key,
                    vc_Value = value
                });
            }
        }

        /// <summary>
        /// 获取数据库的时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDBTime()
        {
            DataSet ds = DB.OleDbHelper.GetDataSet("select getdate()");
            if (ds != null)
            {
                return Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString());
            }
            return DateTime.Now;

        }

        /// <summary>
        /// 是否可以运行服务
        /// </summary>
        /// <returns></returns>
        public bool IsCanRunServer()
        {
            try
            {
                DateTime dt = Convert.ToDateTime(GetValue(EnumSystemConfigKeys.LastServerRunTime));
                return (dt.AddSeconds(10) < DateTime.Now);
            }
            catch (Exception)
            {
                return SetValue(EnumSystemConfigKeys.LastServerRunTime, DateTime.Now.ToString());
            }
        }
    }

    public enum EnumSystemConfigKeys
    {
        /// <summary>
        /// 设置流程节点的可用性
        /// </summary>
        FlowPAth,
        /// <summary>
        /// 装车超时设置
        /// </summary>
        LoadVehicleTimeOut,
        /// <summary>
        /// //卸车超时设置
        /// </summary>
        UnLoadVehicleTimeOut,
        /// <summary>
        /// //还车超时设置
        /// </summary>
        BackVehicleTimeOut,
        /// <summary>
        /// //闲置告警设置
        /// </summary>
        UnUsedVehicleTimeOutAlarm,
        /// <summary>
        /// //PDA离线数据处理设置
        /// </summary>
        PDAOffLineTimeOut,
        /// <summary>
        /// 是否存在KJ222客户程序
        /// </summary>
        HaveKJ222Client,
        /// <summary>
        /// 上次服务运行的时间
        /// </summary>
        LastServerRunTime,
        /// <summary>
        /// 上次更新车辆表时间
        /// </summary>
        LastUpdateVehicleTable,
        /// <summary>
        /// 上次更新车辆类型表时间
        /// </summary>
        LastUpdateVehicleTypeTable,
        /// <summary>
        /// 上次更新人员表时间
        /// </summary>
        LastUpdatePersonTable,
        /// <summary>
        /// 上次更新物料表时间
        /// </summary>
        LastUpdateMaterielTypeTable,
        /// <summary>
        /// 上次更新部门表时间
        /// </summary>
        LastUpdateDepartmentTable,
        /// <summary>
        /// 上次更新地点表
        /// </summary>
        LastUpdateAddressTable,
        /// <summary>
        /// 上次更新卡表
        /// </summary>
        LastUpdateCardTable
    }
}
