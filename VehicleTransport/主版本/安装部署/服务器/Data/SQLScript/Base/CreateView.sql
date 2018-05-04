USE [BW_VehicleTransportManage]
GO

/****** Object:  View [dbo].[v_Kj222Localizer]    Script Date: 10/10/2014 09:36:54 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_Kj222Localizer]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_Kj222Localizer]
GO
CREATE VIEW [dbo].[v_Kj222Localizer]
AS
SELECT     ID, AreaID, i_HID, i_ParentHID, i_Type, vc_Code, vc_Name, vc_Memo, i_Flag
FROM         BW_KJ222.dbo.m_Localizer
GO
CREATE VIEW [dbo].[v_Kj222Localizer]
AS
SELECT     ID, AreaID, i_HID,  i_Type, vc_Code, vc_Name, vc_Memo, i_Flag
FROM         BW_KJ222.dbo.m_Localizer
GO



/****** Object:  View [dbo].[v_PlanVehicleDetail]    Script Date: 10/10/2014 09:36:55 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_PlanVehicleDetail]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_PlanVehicleDetail]
GO
CREATE VIEW [dbo].[v_PlanVehicleDetail]
AS
SELECT     v.ID AS VehicleID, v.vc_Code, v.vc_Name AS VehicleName, v.VehicleTypeID, v.DepartmentID, v.i_State AS VehicleState, v.i_SafeLoad, v.i_LocalizerStationID, 
                      v.dt_InLocalizerStationDateTime, v.i_MaintainInterval, v.dt_ScrapDateTime, v.dt_CreateDateTime, v.dt_LastMaintainDateTIme, v.vc_Memo, v.i_Flag, p.ID AS PlanID, 
                      p.dt_ArriveDestinationDateTime, p.ArriveDestinationAddressID, p.i_State AS PlanState, p.ApplyID, p.i_IsTemPlan, p.vc_PlanCode, p.CheckPersonID, 
                      p.dt_CheckDateTime, p.PlanGiveCarDepartmentID, p.dt_PlanGiveCarDateTime, p.PlanGiveCarAddressID, p.PlanUnLoadDepartmentID, p.PlanBackDepartmentID, 
                      p.dt_PlanBackDateTime, p.PlanBackAddressID, p.PlanLoadDepartmentID, p.PlanLoadAddressID, p.RealGiveCarDepartmentID, p.dt_RealGiveCarDateTime, 
                      p.RealGiveCarAddressID, p.RealLoadDepartmentID, p.dt_RealLoadDateTime, p.RealLoadAddressID, p.dt_RealArriveDestinationDateTime, v.i_LastLocalizerStationID, 
                      a.ID AS LastAddressID
FROM         dbo.m_VehiclePlanDetail AS vd INNER JOIN
                      dbo.m_Plan AS p ON vd.PlanID = p.ID INNER JOIN
                          (SELECT     ID, vc_Code, vc_Name, VehicleTypeID, DepartmentID, i_State, i_SafeLoad, i_LocalizerStationID, dt_InLocalizerStationDateTime, i_MaintainInterval, 
                                                   dt_ScrapDateTime, dt_CreateDateTime, dt_LastMaintainDateTIme, vc_Memo, i_Flag, i_LastLocalizerStationID, i_LocalizerStationIDChanaged
                            FROM          dbo.m_Vehicle
                            WHERE      (i_Flag = 0)) AS v ON vd.VehicleID = v.ID LEFT OUTER JOIN
                          (SELECT     ID, vc_Name, LocalizerStationID, AreaID, i_IsUpMine, i_IsDirectionStation, DirectionLocalizerStationID, vc_Memo, i_Flag, i_State
                            FROM          dbo.m_Address
                            WHERE      (i_Flag = 0)) AS a ON v.i_LastLocalizerStationID = a.LocalizerStationID
GO

/****** Object:  View [dbo].[v_ApplyPlanVehicleDetail]    Script Date: 10/10/2014 09:36:55 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_ApplyPlanVehicleDetail]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_ApplyPlanVehicleDetail]
GO
CREATE VIEW [dbo].[v_ApplyPlanVehicleDetail]
AS
SELECT     vp.VehicleID, vp.vc_Code, vp.VehicleName, vp.VehicleTypeID, vp.VehicleState, vp.i_SafeLoad, vp.i_LocalizerStationID, vp.PlanID, vp.PlanState, 
                      vp.vc_PlanCode, vp.ArriveDestinationAddressID, vp.dt_ArriveDestinationDateTime, a.ApplyDepartmentID
FROM         dbo.v_PlanVehicleDetail AS vp LEFT OUTER JOIN
                      dbo.m_Apply AS a ON vp.ApplyID = a.ID
GO

/****** Object:  View [dbo].[v_Apply]    Script Date: 10/10/2014 09:36:54 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_Apply]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_Apply]
GO
CREATE VIEW [dbo].[v_Apply]
AS
SELECT     a.ID, a.dt_ApplyDateTime, g.deptname, a.ApplyDepartmentID, a.ApplyPersonID, g.username, a.vc_PlanUse, a.ArriveDestinationAddressID, 
                      d.vc_Name AS addressname, a.dt_ArriveDestinationDateTime AS dt_arrive, 
                      CASE WHEN a.i_State = - 1 THEN '申请不通过' WHEN a.i_State = 0 THEN '待审核' WHEN a.i_State = 1 THEN '已审部分' WHEN a.i_State = 2 THEN '已审完' END AS statename,a.i_State, a.i_IsUseMaterieApply, a.vc_remark
FROM         dbo.m_Apply AS a LEFT OUTER JOIN
                      dbo.m_Department AS b ON a.ApplyDepartmentID = b.ID LEFT OUTER JOIN
                      dbo.m_Address AS d ON a.ArriveDestinationAddressID = d.ID LEFT OUTER JOIN
                          (SELECT     e.ID AS personid, f.ID AS deptid, f.vc_Name AS deptname, e.vc_Name AS username
                            FROM          dbo.m_Person AS e LEFT OUTER JOIN
                                                   dbo.m_Department AS f ON e.DepartmentID = f.ID) AS g ON a.ApplyPersonID = g.personid
GO

/****** Object:  View [dbo].[v_Plan]    Script Date: 10/10/2014 09:36:54 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_Plan]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_Plan]
GO
CREATE VIEW [dbo].[v_Plan]
AS
SELECT     a.ID, a.dt_ArriveDestinationDateTime, a.ArriveDestinationAddressID, e.vc_Name AS ArriveDestinationAddressName, a.i_State, a.ApplyID, a.i_IsTemPlan, 
                      a.vc_PlanCode, a.CheckPersonID, a.dt_CheckDateTime, a.PlanGiveCarDepartmentID, a.vc_PDAUserIDs, a.dt_PlanGiveCarDateTime, a.PlanGiveCarAddressID, 
                      a.PlanUnLoadDepartmentID, a.PlanBackDepartmentID, a.dt_PlanBackDateTime, a.PlanBackAddressID, a.PlanLoadDepartmentID, a.PlanLoadAddressID, 
                      a.dt_PlanLoadDateTime, a.RealGiveCarDepartmentID, a.dt_RealGiveCarDateTime, a.RealGiveCarAddressID, a.RealLoadDepartmentID, a.dt_RealLoadDateTime, 
                      a.RealLoadAddressID, a.dt_RealArriveDestinationDateTime, a.RealLoadPersonID, d2.vc_Name AS RealLoadPersonName, a.RealGiveCarPersonID, 
                      d3.vc_Name AS RealGiveCarPersonName, b.ApplyDepartmentID, b.ApplyPersonID, c.vc_Name AS ApplyDepartmentName, d.vc_Name AS ApplyPersonName, 
                      d1.vc_Name AS CheckPersonName, c1.vc_Name AS PlanLoadDepartmentName, e1.vc_Name AS PlanLoadAddressName, 
                      c2.vc_Name AS PlanGiveCarDepartmentName, e2.vc_Name AS PlanGiveCarAddressName, c3.vc_Name AS PlanUnLoadDepartmentName, 
                      c4.vc_Name AS PlanBackDepartmentName, e3.vc_Name AS PlanBackAddressName, c5.vc_Name, e4.vc_Name AS Expr1, 
                      c6.vc_Name AS RealGiveCarDepartmentName, e5.vc_Name AS RealGiveCarAddressName, c7.vc_Name AS RealLoadDepartmentName, 
                      e6.vc_Name AS RealLoadAddressName, 
                      CASE WHEN a.i_State = 0 THEN '已审核' WHEN a.i_State = 1 THEN '已供车' WHEN a.i_State = 2 THEN '已装车' WHEN a.i_State = 3 THEN '运输中' WHEN a.i_State = 4
                       THEN '已卸车' WHEN a.i_State = 5 THEN '已还车' WHEN a.i_State = 6 THEN '已完成' END AS statename
FROM         dbo.m_Plan AS a INNER JOIN
                      dbo.m_Apply AS b ON a.ApplyID = b.ID LEFT OUTER JOIN
                      dbo.m_Department AS c ON b.ApplyDepartmentID = c.ID LEFT OUTER JOIN
                      dbo.m_Person AS d ON b.ApplyPersonID = d.ID LEFT OUTER JOIN
                      dbo.m_Person AS d1 ON a.CheckPersonID = d1.ID LEFT OUTER JOIN
                      dbo.m_Person AS d2 ON a.RealLoadPersonID = d2.ID LEFT OUTER JOIN
                      dbo.m_Person AS d3 ON a.RealGiveCarPersonID = d3.ID LEFT OUTER JOIN
                      dbo.m_Address AS e ON a.ArriveDestinationAddressID = e.ID LEFT OUTER JOIN
                      dbo.m_Department AS c1 ON a.PlanLoadDepartmentID = c1.ID LEFT OUTER JOIN
                      dbo.m_Address AS e1 ON a.PlanLoadAddressID = e1.ID LEFT OUTER JOIN
                      dbo.m_Department AS c2 ON a.PlanGiveCarDepartmentID = c2.ID LEFT OUTER JOIN
                      dbo.m_Address AS e2 ON a.PlanGiveCarAddressID = e2.ID LEFT OUTER JOIN
                      dbo.m_Department AS c3 ON a.PlanUnLoadDepartmentID = c3.ID LEFT OUTER JOIN
                      dbo.m_Department AS c4 ON a.PlanBackDepartmentID = c4.ID LEFT OUTER JOIN
                      dbo.m_Address AS e3 ON a.PlanBackAddressID = e3.ID LEFT OUTER JOIN
                      dbo.m_Department AS c5 ON a.PlanLoadDepartmentID = c5.ID LEFT OUTER JOIN
                      dbo.m_Address AS e4 ON a.PlanLoadAddressID = e4.ID LEFT OUTER JOIN
                      dbo.m_Department AS c6 ON a.RealGiveCarDepartmentID = c6.ID LEFT OUTER JOIN
                      dbo.m_Address AS e5 ON a.RealGiveCarAddressID = e5.ID LEFT OUTER JOIN
                      dbo.m_Department AS c7 ON a.RealLoadDepartmentID = c7.ID LEFT OUTER JOIN
                      dbo.m_Address AS e6 ON a.RealLoadAddressID = e6.ID
GO



/****** Object:  View [dbo].[v_Address]    Script Date: 10/10/2014 09:36:54 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_Address]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_Address]
GO
CREATE VIEW [dbo].[v_Address]
AS
SELECT     a.ID, a.vc_Name, a.LocalizerStationID, a.AreaID, a.i_IsUpMine, a.i_IsDirectionStation, a.DirectionLocalizerStationID, a.vc_Memo, a.i_Flag, b.i_HID, b.i_ParentHID, 
                      b.vc_Code, c.vc_Name AS LocalizerStationName, d.vc_Name AS AreaName
FROM         dbo.m_Address AS a LEFT OUTER JOIN
                          (SELECT     ID, i_HID, i_ParentHID, vc_Code
                            FROM          BW_KJ222.dbo.m_Localizer
                            WHERE      (i_Flag = 0)) AS b ON a.LocalizerStationID = b.ID LEFT OUTER JOIN
                          (SELECT     ID, vc_Name, LocalizerStationID, AreaID, i_IsUpMine, i_IsDirectionStation, DirectionLocalizerStationID, vc_Memo, i_Flag
                            FROM          dbo.m_Address
                            WHERE      (i_Flag = 0)) AS c ON a.DirectionLocalizerStationID = c.ID LEFT OUTER JOIN
                          (SELECT     ID, vc_Code, vc_Name, ParentID, vc_Memo, i_Flag
                            FROM          dbo.m_Area
                            WHERE      (i_Flag = 0)) AS d ON a.AreaID = d.ID
                                          
GO
CREATE VIEW [dbo].[v_Address]
AS
SELECT     a.ID, a.vc_Name, a.LocalizerStationID, a.AreaID, a.i_IsUpMine, a.i_IsDirectionStation, a.DirectionLocalizerStationID, a.vc_Memo, a.i_Flag, b.i_HID, 
                      b.vc_Code, c.vc_Name AS LocalizerStationName, d.vc_Name AS AreaName
FROM         dbo.m_Address AS a LEFT OUTER JOIN
                          (SELECT     ID, i_HID,  vc_Code
                            FROM          BW_KJ222.dbo.m_Localizer
                            WHERE      (i_Flag = 0)) AS b ON a.LocalizerStationID = b.ID LEFT OUTER JOIN
                          (SELECT     ID, vc_Name, LocalizerStationID, AreaID, i_IsUpMine, i_IsDirectionStation, DirectionLocalizerStationID, vc_Memo, i_Flag
                            FROM          dbo.m_Address
                            WHERE      (i_Flag = 0)) AS c ON a.DirectionLocalizerStationID = c.ID LEFT OUTER JOIN
                          (SELECT     ID, vc_Code, vc_Name, ParentID, vc_Memo, i_Flag
                            FROM          dbo.m_Area
                            WHERE      (i_Flag = 0)) AS d ON a.AreaID = d.ID
                                          
GO

/****** Object:  View [dbo].[v_handover]    Script Date: 10/10/2014 09:36:54 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_handover]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_handover]
GO
CREATE VIEW [dbo].[v_handover]
AS

SELECT     a.PlanID, a.VehicleID, c.vc_Code AS carcode, a.ReceiveVehiclePersonID, d.vc_Name AS personname, a.dt_HandoverDateTime, b.MaterieTypeID, 
                      e.vc_Name AS matername, a.i_HandoverCount, b.n_Count,a.AddressID,f.vc_Name as addressname
FROM         dbo.m_Plan_Handover AS a INNER JOIN
                      dbo.m_Plan_HandoverMaterie AS b ON a.ID = b.PlanHandoverID AND a.i_Flag = 0 LEFT OUTER JOIN
                      dbo.m_Vehicle AS c ON a.VehicleID = c.ID LEFT OUTER JOIN
                      dbo.m_Person AS d ON a.ReceiveVehiclePersonID = d.ID LEFT OUTER JOIN
                      dbo.m_MaterielType AS e ON b.MaterieTypeID = e.ID
                     left join m_Address f on a.AddressID=f.ID
GO

/****** Object:  View [dbo].[v_DeriError]    Script Date: 10/10/2014 09:36:54 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_DeriError]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_DeriError]
GO
CREATE VIEW [dbo].[v_DeriError]
AS
SELECT     vp.VehicleID , a.ID AS AddressID
FROM         dbo.v_PlanVehicleDetail AS vp INNER JOIN
                      dbo.m_Address AS a ON vp.ArriveDestinationAddressID = a.ID
WHERE     (vp.VehicleID =
                          (SELECT     v.ID AS VehicleID
                            FROM          dbo.m_Vehicle AS v CROSS JOIN
                                                   dbo.m_Address AS a
                            WHERE      (v.i_LocalizerStationID = a.LocalizerStationID) AND (a.i_IsDirectionStation = 1))) AND (a.ID =
                          (SELECT     a.ID AS VehicleID
                            FROM          dbo.m_Vehicle AS v CROSS JOIN
                                                   dbo.m_Address AS a
                            WHERE      (v.i_LocalizerStationID = a.LocalizerStationID) AND (a.i_IsDirectionStation = 1)))
GO


/****** Object:  View [dbo].[[v_PDA]]    Script Date: 10/10/2014 09:36:54 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_PDA]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_PDA]
GO
CREATE VIEW [dbo].[v_PDA]
AS
SELECT     a.ID, a.vc_MacAddress, a.i_State, a.i_Flag, a.DepartmentID, b.vc_Name AS deptname, c.ID AS useno, c.vc_Name AS usename, c.WifiBaseStationID, 
                      a.vc_Code
FROM         dbo.m_PDA AS a LEFT OUTER JOIN
                      dbo.m_Department AS b ON a.DepartmentID = b.ID LEFT OUTER JOIN
                      dbo.m_User AS c ON a.ID = c.PdaID
WHERE     (a.i_Flag = 0)
GO

/****** Object:  View [dbo].[v_UnLoad]    Script Date: 10/10/2014 09:36:54 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_UnLoad]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_UnLoad]
GO
CREATE VIEW [dbo].[v_UnLoad]
AS
SELECT     a.PlanID, a.VehicleID, c.vc_Code AS carcode, a.PersonID, d.vc_Name AS personname, a.dt_DateTime, b.MaterieTypeID, e.vc_Name AS matername, 
                      b.n_Count
FROM         dbo.m_Plan_UnLoad AS a INNER JOIN
                      dbo.m_Plan_UnLoadMaterie AS b ON a.ID = b.PlanUnloadID AND a.i_Flag = 0 LEFT OUTER JOIN
                      dbo.m_Vehicle AS c ON a.VehicleID = c.ID LEFT OUTER JOIN
                      dbo.m_Person AS d ON a.PersonID = d.ID LEFT OUTER JOIN
                      dbo.m_MaterielType AS e ON b.MaterieTypeID = e.ID
                      GO

/****** Object:  View [dbo].v_AreaVehicle    ***/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].v_AreaVehicle') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_AreaVehicle]
GO
CREATE VIEW [dbo].[v_AreaVehicle]
AS
SELECT     AreaID, AreaName, MAX(CASE i_state WHEN 0 THEN counts ELSE 0 END) AS EmptyVehicle, MAX(CASE i_state WHEN 1 THEN counts ELSE 0 END) 
                      AS WeightVehicle
FROM         (SELECT     AreaID, AreaName, i_State, COUNT(i_State) AS counts
                       FROM          (SELECT     a.i_State, b.AreaID, b.AreaName
                                               FROM          dbo.m_Vehicle AS a RIGHT OUTER JOIN
                                                                      dbo.v_Address AS b ON a.i_LocalizerStationID = b.LocalizerStationID
                                               WHERE      (b.AreaID <> 0 and b.i_Flag=0)) AS c
                       GROUP BY AreaID, AreaName, i_State) AS d
GROUP BY AreaID, AreaName
GO

/****** Object:  View [dbo].[v_VehicleAlarm]    Script Date: 10/10/2014 09:36:55 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_VehicleAlarm]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_VehicleAlarm]
GO
CREATE VIEW [dbo].[v_VehicleAlarm]
AS
SELECT     a.ID, a.i_AlarmType, a.PlanID, a.VehicleID, a.i_IsPreAlarm, a.dt_Start, a.dt_End, a.vc_Memo, a.i_Flag, b.vc_Name, b.vc_Code, c.vc_PlanCode, 
                      b.dt_LastMaintainDateTIme, b.dt_ScrapDateTime, b.i_MaintainInterval, d.vc_Name AS LocalizerStationName, c.ApplyDepartmentName, c.CheckPersonName, 
                      c.PlanGiveCarDepartmentName, c.dt_PlanGiveCarDateTime, c.PlanLoadDepartmentName, c.dt_PlanLoadDateTime, c.ArriveDestinationAddressName, 
                      c.dt_ArriveDestinationDateTime, c.PlanBackDepartmentName, c.dt_PlanBackDateTime
FROM         dbo.data_VehicleAlarm AS a LEFT OUTER JOIN
                          (SELECT     ID, vc_Code, vc_Name, VehicleTypeID, DepartmentID, i_State, i_SafeLoad, i_LocalizerStationID, dt_InLocalizerStationDateTime, i_MaintainInterval, 
                                                   dt_ScrapDateTime, dt_CreateDateTime, dt_LastMaintainDateTIme, vc_Memo, i_Flag, i_LastLocalizerStationID, i_LocalizerStationIDChanaged
                            FROM          dbo.m_Vehicle
                            WHERE      (i_Flag = 0)) AS b ON a.VehicleID = b.ID LEFT OUTER JOIN
                          (SELECT     ID, vc_Name, LocalizerStationID, AreaID, i_IsUpMine, i_IsDirectionStation, DirectionLocalizerStationID, vc_Memo, i_Flag, i_State
                            FROM          dbo.m_Address
                            WHERE      (i_Flag = 0)) AS d ON b.i_LocalizerStationID = d.LocalizerStationID LEFT OUTER JOIN
                      dbo.v_Plan AS c ON a.PlanID = c.ID
GO