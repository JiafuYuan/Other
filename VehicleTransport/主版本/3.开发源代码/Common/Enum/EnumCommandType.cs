using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Enum
{
    /// <summary>
    /// 处理的命令类型
    /// </summary>
    public enum EnumCommandType
    {
        None ,
        #region 常用命令
        /// <summary>
        /// 心跳
        /// </summary>
        HeartBeat,
        /// <summary>
        /// 登录
        /// </summary>
        Login,
        /// <summary>
        /// 登出
        /// </summary>
        LoginOut,
        /// <summary>
        /// 取流程节点
        /// </summary>
        GetFlowPath ,
        /// <summary>
        /// 取服务时间
        /// </summary>
        GetTime,
        /// <summary>
        /// 取APK版本号
        /// </summary>
        GetAPKVersion,
        /// <summary>
        /// 取数据库连接信息
        /// </summary>
        GetDBInfo,
        /// <summary>
        /// 取APK文件
        /// </summary>
        GetAPKFile,
        /// <summary>
        /// 向PC通知告警
        /// </summary>
        SendAlarm,
        /// <summary>
        /// 结束告警，PC通知服务器
        /// </summary>
        EndAlarm,
        /// <summary>
        /// 修改密码
        /// </summary>
        ChangePassword,
        /// <summary>
        /// GIS发生了变化
        /// </summary>
        GisChanaged,
        /// <summary>
        /// 刷新GIS，通知所有PC
        /// </summary>
        SendGisRefresh,
        /// <summary>
        /// 向PC通知状态
        /// </summary>
        SendRefresh,
        /// <summary>
        /// GIS地图上点状态变化
        /// </summary>
        SendGisPointStateChanged,
        /// <summary>
        /// 车辆位置变化
        /// </summary>
        SendVehiclePostionChanged,
        /// <summary>
        /// PDA位置变化
        /// </summary>
        SendPDAPostionChanged,
        #endregion

        #region 流程命令
        /// <summary>
        /// 客户端向上位机发送流程操作
        /// </summary>
        Flow_Apply,
        /// <summary>
        /// 审核
        /// </summary>
        Flow_Check,
        /// <summary>
        /// 供车
        /// </summary>
        Flow_Give,
        /// <summary>
        /// 装车
        /// </summary>
        Flow_Load,
        /// <summary>
        /// 交接车
        /// </summary>
        Flow_Handover,
        /// <summary>
        /// 卸车
        /// </summary>
        Flow_UnLoad,
        /// <summary>
        /// 还车
        /// </summary>
        Flow_Back,
        #endregion

        #region 数据命令
        
        

        /// <summary>
        /// 取消息
        /// </summary>
        Data_GetMessage,
        /// <summary>
        /// 取物料
        /// </summary>
        Data_GetMaterielType,
        /// <summary>
        /// 取车辆信息
        /// </summary>
        Data_GetVehicle,
        /// <summary>
        /// 车辆类型
        /// </summary>
        Data_GetVehicleType,
        /// <summary>
        /// 取部门信息
        /// </summary>
        Data_GetDepartment,
        Data_GetAddress,

        /// <summary>
    /// 查询车辆在某个环节是否可提交
    /// </summary>
    Data_GetVehicleIsCanDo,

        /// <summary>
        /// 取卡表信息
        /// </summary>
        Data_GetCard,
        /// <summary>
        /// 查询计划
        /// </summary>
        Data_GetPlanDetail,
        /// <summary>
        /// 查询我的运单
        /// </summary>
        Data_GetMyPlanDetail,
        /// <summary>
        /// 查询车辆分布，按区域统计空重车数量
        /// </summary>
        Data_GetVehicleDistributed,
        ///// <summary>
        ///// 发送消息到PDA
        ///// </summary>
        Data_SendMessage,
        /// <summary>
        /// 返回消息
        /// </summary>
        Data_ReturnMessage,
        /// <summary>
        /// 人员信息
        /// </summary>
        Data_GetPerson
        #endregion
      
    }
}
