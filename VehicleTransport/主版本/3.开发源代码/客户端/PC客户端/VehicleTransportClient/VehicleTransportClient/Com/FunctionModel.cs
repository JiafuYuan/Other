using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleTransportClient
{
    //功能列表
    public  class FunctionModel
    {
        //物料运输管理
        public static string TransportationManage = "400";
        public static string FormApplyMgrManage = "401";
        public static string FormReviewMgr = "402";
        public static string FormLoadCarMgr = "403";
        public static string FormSupplyCarMgr = "404";
        public static string FormTransferCarMgr = "405";
        public static string FormUnloadCarMgr = "406";
        public static string FormBackCar = "407";

        //基础信息管理
        public static string BaseManage = "300";
        public static string FormPersonManage = "301";
        public static string FormDeptManage = "302";
        public static string FormAreaManage = "303";
        public static string FormAddressManage = "304";
        public static string FormWifiBaseStation = "305";
        public static string FormVehicleTypeManage = "306";
        public static string FormVehicleManage = "307";
        public static string FormVehicleMainTainManage = "308";
        public static string FormVehicleScrapManage = "309";
        public static string FormPDAManage = "310";
        public static string FormCardManage = "311";
        public static string FormMaterielTypeManage = "312";
      
        //统计分析
        public static string StatisticalAnalysis = "200";
        public static string FormVehicleMonth = "201";

        //告警查询
        public static string FormVehicleAlarm = "100";
        public static string MaintainTimeOutAlarm = "101";
        public static string ScrapTimeOutAlarm = "102";
        public static string GiveTimeOutAlarm = "103";
        public static string LoadTimeOutAlarm = "104";
        public static string TransportTimeOutAlarm = "105";
        public static string UnLoadTimeOutAlarm = "106";
        public static string BackTimeOutAlarm = "107";
        public static string NoUseAlarm = "108";
        public static string RunDerictionAlarm = "109";
        public static string NoChanageStateAlarm = "110";
        public static string FormSendMessage = "111";

        //系统管理
        public static string SystemConfig = "000";
        public static string FormUserManage = "001";
        public static string FormRuleManage = "002";
        public static string FormPasswordEdit = "003";
        public static string FormAlarmSet = "004";
        public static string FormSystemLog = "005";
        

        public static string Gis = "500";
        public static string FormGis = "501";
       
    }
}
