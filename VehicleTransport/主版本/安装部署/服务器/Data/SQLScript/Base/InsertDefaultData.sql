USE [BW_VehicleTransportManage]
GO

if((select COUNT(*) from m_SystemConfig where vc_key='BackVehicleTimeOut')=0 )
begin 
insert into m_SystemConfig(vc_Key,vc_Value) values('BackVehicleTimeOut','24')
end

if((select COUNT(*) from m_SystemConfig where vc_key='FlowPath')=0 )
begin 
insert into m_SystemConfig(vc_Key,vc_Value) values('FlowPath','11008')
end

if((select COUNT(*) from m_SystemConfig where vc_key='HaveKJ222Client')=0 )
begin 
insert into m_SystemConfig(vc_Key,vc_Value) values('HaveKJ222Client','0')
end

if((select COUNT(*) from m_SystemConfig where vc_key='LoadVehicleTimeOut')=0 )
begin 
insert into m_SystemConfig(vc_Key,vc_Value) values('LoadVehicleTimeOut','24')
end

if((select COUNT(*) from m_SystemConfig where vc_key='PDAOffLineTimeOut')=0 )
begin 
insert into m_SystemConfig(vc_Key,vc_Value) values('PDAOffLineTimeOut','8')
end

if((select COUNT(*) from m_SystemConfig where vc_key='UnLoadVehicleTimeOut')=0 )
begin 
insert into m_SystemConfig(vc_Key,vc_Value) values('UnLoadVehicleTimeOut','24')
end

if((select COUNT(*) from m_SystemConfig where vc_key='UnusedVehicleTimeOutAlarm')=0 )
begin 
insert into m_SystemConfig(vc_Key,vc_Value) values('UnusedVehicleTimeOutAlarm','24')
end

if((select COUNT(*) from m_User where vc_name='admin')=0 )
begin 
insert into m_User(vc_Name,vc_Password) values('admin','admin')
end


if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdateAddressTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateAddressTable',getdate(),'地点表上次更新的时间')
end


if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdateDepartmentTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateDepartmentTable',getdate(),'部门表上次更新的时间')
end


if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdateMaterielTypeTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateMaterielTypeTable',getdate(),'物料类型表上次更新的时间')
end


if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdatePersonTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdatePersonTable',getdate(),'人员表上次更新的时间')
end


if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdatVehicleTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdatVehicleTable',getdate(),'车辆表上次更新的时间')
end


if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdatVehicleTypeTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdatVehicleTypeTable',getdate(),'车辆类型表上次更新的时间')
end

if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdateCardTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateCardTable',getdate(),'卡表上次更新的时间')
end



/****** Object:  Table [dbo].[m_RuleDetail]    Script Date: 11/12/2014 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT [dbo].[m_RuleDetail] ON
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (130, 6, N'GisMapEdit', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (131, 6, N'panelConfig', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (132, 6, N'btnUserManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (133, 6, N'btnRuleManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (134, 6, N'btnPasswordEdit', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (135, 6, N'btnAlarmSet', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (136, 6, N'panelLog', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (137, 6, N'btnSendMessage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (138, 6, N'btnSystemLog', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (139, 6, N'panelAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (140, 6, N'btnMaintainTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (141, 6, N'btnScrapTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (142, 6, N'btnGiveTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (143, 6, N'btnLoadTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (144, 6, N'btnTransportTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (145, 6, N'btnUnLoadTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (146, 6, N'btnBackTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (147, 6, N'btnNoUseAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (148, 6, N'btnRunDerictionAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (149, 6, N'btnNoChanageStateAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (150, 6, N'panelAnaly', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (151, 6, N'btnVehicleDept', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (152, 6, N'btnDeptMaterielTypeReport', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (153, 6, N'btnVehicleStatistics', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (154, 6, N'btnCheckReport', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (155, 6, N'btnNoUseMonthReport', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (156, 6, N'panelCar', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (157, 6, N'btnCarTypeManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (158, 6, N'btnCarManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (159, 6, N'btnVehicleMaintain', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (160, 6, N'btnCarScraped', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (161, 6, N'panelBaseinfo', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (162, 6, N'btnDeptManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (163, 6, N'btnPersonManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (164, 6, N'btnAreaManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (165, 6, N'btnStationManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (166, 6, N'btnWifiStation', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (167, 6, N'btnPDAManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (168, 6, N'btnCardManage', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (169, 6, N'btnMaterielType', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (170, 6, N'panelFlow', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (171, 6, N'btnmyapply', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (172, 6, N'btnCheck', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (173, 6, N'btnSupply', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (174, 6, N'btnloadcar', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (175, 6, N'btnTransfer', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (176, 6, N'btnunload', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (177, 6, N'btnbackcar', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (178, 7, N'panelAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (179, 7, N'btnMaintainTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (180, 7, N'btnScrapTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (181, 7, N'btnGiveTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (182, 7, N'btnLoadTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (183, 7, N'btnTransportTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (184, 7, N'btnUnLoadTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (185, 7, N'btnBackTimeOutAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (186, 7, N'btnNoUseAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (187, 7, N'btnRunDerictionAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (188, 7, N'btnNoChanageStateAlarm', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (189, 7, N'panelAnaly', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (190, 7, N'btnVehicleDept', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (191, 7, N'btnDeptMaterielTypeReport', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (192, 7, N'btnVehicleStatistics', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (193, 7, N'btnCheckReport', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (194, 7, N'btnNoUseMonthReport', NULL, 0)
INSERT [dbo].[m_RuleDetail] ([ID], [RuleID], [vc_ModuleName], [vc_Memo], [i_Flag]) VALUES (195, 7, N'btnmyapply', NULL, 0)

SET IDENTITY_INSERT [dbo].[m_RuleDetail] OFF
/****** Object:  Table [dbo].[m_Rule]    Script Date: 11/12/2014 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET IDENTITY_INSERT [dbo].[m_Rule] ON
INSERT [dbo].[m_Rule] ([ID], [vc_Name], [vc_Memo], [i_Flag]) VALUES (6, N'调度员', N'超级用户', 0)
INSERT [dbo].[m_Rule] ([ID], [vc_Name], [vc_Memo], [i_Flag]) VALUES (7, N'普通用户', N'', 0)
SET IDENTITY_INSERT [dbo].[m_Rule] OFF
/****** Object:  Default [DF_m_RuleDetail_i_Flag]    Script Date: 11/12/2014 14:17:34 ******/

/****** Object:  Table [BW_KJ222].[dbo].[m_Area]    Script Date: 11/12/2014 14:17:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET IDENTITY_INSERT [BW_KJ222].[dbo].[m_Area] ON
INSERT [BW_KJ222].[dbo].[m_Area] ([ID], [vc_Code], [vc_Name], [i_LimitOfPersonCount], [i_Flag], [vc_Memo], [Point_X], [Point_Y]) VALUES (1, CONVERT(TEXT, N'02'), CONVERT(TEXT, N'0水平副井口区域'), 0, 1, CONVERT(TEXT, N''), 100, 100)
SET IDENTITY_INSERT [BW_KJ222].[dbo].[m_Area] OFF
/****** Object:  Table [BW_KJ222].[dbo].[m_Area]   Script Date: 11/12/2014 14:17:34 ******/
