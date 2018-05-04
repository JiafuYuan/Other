USE [BW_VehicleTransportManage]

/****** Object:  Table [dbo].[m_WifiBaseStation]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_WifiBaseStation]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_WifiBaseStation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Name] [nvarchar](50) NULL,
	[i_State] [int] NULL,
	[vc_IPAddress] [varchar](50) NULL,
	[vc_MacAddress] [varchar](50) NULL,
	[LocalizerStationID] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_WifiBaseStation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Default [DF_m_WifiBaseStation_i_State]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_WifiBaseStation] ADD  CONSTRAINT [DF_m_WifiBaseStation_i_State]  DEFAULT ((0)) FOR [i_State]

/****** Object:  Default [DF_m_WifiBaseStation_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_WifiBaseStation] ADD  CONSTRAINT [DF_m_WifiBaseStation_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[data_VehicleAlarm]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[data_VehicleAlarm]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[data_VehicleAlarm](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[i_AlarmType] [int] NULL,
	[PlanID] [int] NULL,
	[VehicleID] [int] NULL,
	[i_IsPreAlarm] [int] NULL,
	[dt_Start] [datetime] NULL,
	[dt_End] [datetime] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_data_VehicleAlarm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Default [DF_data_VehicleAlarm_i_IsPreAlarm]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[data_VehicleAlarm] ADD  CONSTRAINT [DF_data_VehicleAlarm_i_IsPreAlarm]  DEFAULT ((1)) FOR [i_IsPreAlarm]

/****** Object:  Default [DF_data_VehicleAlarm_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[data_VehicleAlarm] ADD  CONSTRAINT [DF_data_VehicleAlarm_i_Flag]  DEFAULT ((0)) FOR [i_Flag]

end
GO

/****** Object:  Table [dbo].[m_VehicleType]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_VehicleType]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_VehicleType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Name] [nvarchar](50) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_VehicleType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_VehicleType_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_VehicleType] ADD  CONSTRAINT [DF_m_VehicleType_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_VehicleScrap]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_VehicleScrap]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_VehicleScrap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NULL,
	[dt_DateTime] [datetime] NULL,
	[PersonID] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_VehicleScrap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_VehicleScrap_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_VehicleScrap] ADD  CONSTRAINT [DF_m_VehicleScrap_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end

GO

/****** Object:  Table [dbo].[m_VehiclePlanDetail]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_VehiclePlanDetail]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_VehiclePlanDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanID] [int] NULL,
	[VehicleID] [int] NULL,
	[dt_DateTime] [datetime] NULL,
 CONSTRAINT [PK_m_VehiclePlanDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
end
GO

/****** Object:  Table [dbo].[m_VehicleMaintain]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_VehicleMaintain]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_VehicleMaintain](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NOT NULL,
	[dt_BeginDateTime] [datetime] NOT NULL,
	[dt_EndDateTime] [datetime] NULL,
	[RecordPersonID] [int] NOT NULL,
	[vc_PersonName] [nvarchar](50) NOT NULL,
	[vc_Content] [nvarchar](50) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_VehicleMaintain] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_VehicleMaintain_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_VehicleMaintain] ADD  CONSTRAINT [DF_m_VehicleMaintain_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Vehicle]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Vehicle]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Vehicle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Code] [nvarchar](50) NOT NULL,
	[vc_Name] [nvarchar](50) NOT NULL,
	[VehicleTypeID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[i_State] [int] NOT NULL,
	[i_SafeLoad] [int] NULL,
	[i_LocalizerStationIDChanaged] [int] NULL,
	[i_LocalizerStationID] [int] NOT NULL,
	[dt_InLocalizerStationDateTime] [datetime] NOT NULL,
	[i_MaintainInterval] [int] NULL,
	[dt_ScrapDateTime] [datetime] NULL,
	[dt_CreateDateTime] [datetime] NOT NULL,
	[dt_LastMaintainDateTIme] [datetime] NOT NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
	[i_LastLocalizerStationID] [int] NULL,
 CONSTRAINT [PK_m_Vehicle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Default [DF_m_Vehicle_i_State]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Vehicle] ADD  CONSTRAINT [DF_m_Vehicle_i_State]  DEFAULT ((0)) FOR [i_State]

/****** Object:  Default [DF_m_Vehicle_i_LocalizerStationID]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Vehicle] ADD  CONSTRAINT [DF_m_Vehicle_i_LocalizerStationID]  DEFAULT ((0)) FOR [i_LocalizerStationID]

/****** Object:  Default [DF_m_Vehicle_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Vehicle] ADD  CONSTRAINT [DF_m_Vehicle_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_User]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_User]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Name] [nvarchar](50) NULL,
	[vc_Password] [nvarchar](50) NULL,
	[PersonID] [int] NULL,
	[DepartmentID] [int] NULL,
	[RuleID] [int] NULL,
	[i_IsPDA] [int] NULL,
	[dt_CreateTime] [datetime] NULL,
	[dt_LastActiveDateTime] [datetime] NULL,
	[PdaID] [int] NULL,
	[WifiBaseStationID] [int] NULL,
	[i_State] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
	[vc_IP] [varchar](50) NULL,
	[i_Port] [int] NULL,
	[i_IdentificationCardHID] [int] NULL,
 CONSTRAINT [PK_m_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Default [DF_m_User_i_IsPDA]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_User] ADD  CONSTRAINT [DF_m_User_i_IsPDA]  DEFAULT ((0)) FOR [i_IsPDA]

/****** Object:  Default [DF_m_User_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_User] ADD  CONSTRAINT [DF_m_User_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_SystemLog]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_SystemLog]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_SystemLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[i_ActionType] [int] NULL,
	[vc_Title] [nvarchar](50) NULL,
	[vc_Description] [nvarchar](50) NULL,
	[dt_DateTime] [datetime] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_SystemLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_SystemLog_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_SystemLog] ADD  CONSTRAINT [DF_m_SystemLog_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_SystemConfig]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_SystemConfig]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_SystemConfig](
	[vc_Key] [varchar](50) NOT NULL,
	[vc_Value] [varchar](50) NULL,
	[vc_Memo] [nvarchar](50) NULL,
 CONSTRAINT [PK_m_SystemConfig] PRIMARY KEY CLUSTERED 
(
	[vc_Key] ASC
) ON [PRIMARY]
) ON [PRIMARY]
end
GO

/****** Object:  Table [dbo].[m_RuleDetail]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_RuleDetail]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_RuleDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RuleID] [int] NULL,
	[vc_ModuleName] [nvarchar](50) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_RuleDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_RuleDetail_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_RuleDetail] ADD  CONSTRAINT [DF_m_RuleDetail_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Rule]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Rule]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Rule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Name] [nvarchar](50) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Rule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Rule_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Rule] ADD  CONSTRAINT [DF_m_Rule_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Plan_UnLoad]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_UnLoad]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_UnLoad](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanID] [int] NULL,
	[VehicleID] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
	[AddressID] [int] NULL,
	[dt_DateTime] [datetime] NULL,
	[PersonID] [int] NULL,
 CONSTRAINT [PK_m_Plan_UnLoad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Plan_UnLoad_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_UnLoad] ADD  CONSTRAINT [DF_m_Plan_UnLoad_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Plan_UnLoadMaterie]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_UnLoadMaterie]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_UnLoadMaterie](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanUnloadID] [int] NULL,
	[MaterieTypeID] [int] NULL,
	[n_Count] [numeric](18, 2) NULL,
	[vc_Memo] [varchar](200) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Plan_UnLoadMaterie] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
end

/****** Object:  Table [dbo].[m_Plan_Load]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_Load]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_Load](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanID] [int] NULL,
	[VehicleID] [int] NULL,
	[MaterieTypeID] [int] NULL,
	[n_Count] [numeric](18, 2) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Plan_Load] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Plan_Load_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_Load] ADD  CONSTRAINT [DF_m_Plan_Load_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Plan_HandoverMaterie]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_HandoverMaterie]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_HandoverMaterie](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanHandoverID] [int] NULL,
	[MaterieTypeID] [int] NULL,
	[n_Count] [numeric](18, 2) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Plan_HandoverMaterie] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Plan_HandoverMaterie_n_Count]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_HandoverMaterie] ADD  CONSTRAINT [DF_m_Plan_HandoverMaterie_n_Count]  DEFAULT ((0)) FOR [n_Count]

/****** Object:  Default [DF_m_Plan_HandoverMaterie_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_HandoverMaterie] ADD  CONSTRAINT [DF_m_Plan_HandoverMaterie_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Plan_Handover]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_Handover]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_Handover](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanID] [int] NULL,
	[VehicleID] [int] NULL,
	[dt_HandoverDateTime] [datetime] NULL,
	[ReceiveVehiclePersonID] [int] NULL,
	[i_HandoverCount] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
	[AddressID] [int] NULL,
 CONSTRAINT [PK_m_Plan_Handover] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Plan_Handover_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_Handover] ADD  CONSTRAINT [DF_m_Plan_Handover_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Plan_GiveVehicle]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_GiveVehicle]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_GiveVehicle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanID] [int] NULL,
	[VehicleTypeID] [int] NULL,
	[i_Count] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Plan_GiveVehicle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
end
GO

/****** Object:  Table [dbo].[m_Plan_CheckVehicle]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_CheckVehicle]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_CheckVehicle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanID] [int] NULL,
	[VehicleTypeID] [int] NULL,
	[i_Count] [int] NULL,
	[MaterieTypeID] [int] NULL,
	[n_Count] [numeric](18, 2) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_Table_1_i_Count]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_CheckVehicle] ADD  CONSTRAINT [DF_Table_1_i_Count]  DEFAULT ((0)) FOR [i_Count]

/****** Object:  Default [DF_Table_1_n_Count]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_CheckVehicle] ADD  CONSTRAINT [DF_Table_1_n_Count]  DEFAULT ((0)) FOR [n_Count]

/****** Object:  Default [DF_Table_1_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_CheckVehicle] ADD  CONSTRAINT [DF_Table_1_i_Flag]  DEFAULT ((0)) FOR [i_Flag]

/****** Object:  Default [DF_m_Plan_GiveVehicle_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_GiveVehicle] ADD  CONSTRAINT [DF_m_Plan_GiveVehicle_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Plan_BackVehicle]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_BackVehicle]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_BackVehicle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanID] [int] NULL,
	[VehicleID] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
	[dt_DateTime] [datetime] NULL,
	[AddressID] [int] NULL,
	[PersonID] [int] NULL,
 CONSTRAINT [PK_m_Plan_BackVehicle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Plan_BackVehicle_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_BackVehicle] ADD  CONSTRAINT [DF_m_Plan_BackVehicle_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Plan_ApplyVehicle]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_ApplyVehicle]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_ApplyVehicle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ApplyID] [int] NULL,
	[VehicleTypeID] [int] NULL,
	[i_Count] [int] NULL,
	[i_CheckCount] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Plan_ApplyVehicle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

/****** Object:  Default [DF_m_Plan_ApplyVehicle_i_Count]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_ApplyVehicle] ADD  CONSTRAINT [DF_m_Plan_ApplyVehicle_i_Count]  DEFAULT ((0)) FOR [i_Count]

/****** Object:  Default [DF_m_Plan_ApplyVehicle_i_CheckCount]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_ApplyVehicle] ADD  CONSTRAINT [DF_m_Plan_ApplyVehicle_i_CheckCount]  DEFAULT ((0)) FOR [i_CheckCount]

/****** Object:  Default [DF_m_Plan_ApplyVehicle_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_ApplyVehicle] ADD  CONSTRAINT [DF_m_Plan_ApplyVehicle_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Plan_ApplyMaterie]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan_ApplyMaterie]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan_ApplyMaterie](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ApplyID] [int] NULL,
	[MaterieTypeID] [int] NULL,
	[n_Count] [numeric](18, 2) NULL,
	[n_CheckCount] [numeric](18, 2) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Plan_ApplyMaterie] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Plan_ApplyMaterie_n_Count]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_ApplyMaterie] ADD  CONSTRAINT [DF_m_Plan_ApplyMaterie_n_Count]  DEFAULT ((0)) FOR [n_Count]

/****** Object:  Default [DF_m_Plan_ApplyMaterie_n_CheckCount]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_ApplyMaterie] ADD  CONSTRAINT [DF_m_Plan_ApplyMaterie_n_CheckCount]  DEFAULT ((0)) FOR [n_CheckCount]

/****** Object:  Default [DF_m_Plan_ApplyMaterie_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan_ApplyMaterie] ADD  CONSTRAINT [DF_m_Plan_ApplyMaterie_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Plan]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Plan]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Plan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[dt_ArriveDestinationDateTime] [datetime] NULL,
	[ArriveDestinationAddressID] [int] NULL,
	[i_State] [int] NULL,
	[ApplyID] [int] NULL,
	[i_IsTemPlan] [int] NULL,
	[vc_PlanCode] [varchar](50) NULL,
	[CheckPersonID] [int] NULL,
	[dt_CheckDateTime] [datetime] NULL,
	[PlanGiveCarDepartmentID] [int] NULL,
	[vc_PDAUserIDs] [varchar](500) NULL,
	[dt_PlanGiveCarDateTime] [datetime] NULL,
	[PlanGiveCarAddressID] [int] NULL,
	[PlanUnLoadDepartmentID] [int] NULL,
	[PlanBackDepartmentID] [int] NULL,
	[dt_PlanBackDateTime] [datetime] NULL,
	[PlanBackAddressID] [int] NULL,
	[PlanLoadDepartmentID] [int] NULL,
	[PlanLoadAddressID] [int] NULL,
	[dt_PlanLoadDateTime] [datetime] NULL,
	[RealGiveCarDepartmentID] [int] NULL,
	[dt_RealGiveCarDateTime] [datetime] NULL,
	[RealGiveCarAddressID] [int] NULL,
	[RealLoadDepartmentID] [int] NULL,
	[dt_RealLoadDateTime] [datetime] NULL,
	[RealLoadAddressID] [int] NULL,
	[dt_RealArriveDestinationDateTime] [datetime] NULL,
	[RealGiveCarPersonID] [int] NULL,
	[RealLoadPersonID] [int] NULL,
 CONSTRAINT [PK_m_Plan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Plan_i_State]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan] ADD  CONSTRAINT [DF_m_Plan_i_State]  DEFAULT ((0)) FOR [i_State]

/****** Object:  Default [DF_m_Plan_ApplyID]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan] ADD  CONSTRAINT [DF_m_Plan_ApplyID]  DEFAULT ((0)) FOR [ApplyID]

/****** Object:  Default [DF_m_Plan_i_IsTemPlan]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Plan] ADD  CONSTRAINT [DF_m_Plan_i_IsTemPlan]  DEFAULT ((0)) FOR [i_IsTemPlan]
end
GO

/****** Object:  Table [dbo].[m_Person]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Person]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Person](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Code] [nvarchar](50) NOT NULL,
	[vc_Name] [nvarchar](50) NOT NULL,
	[i_Sex] [int] NULL,
	[DepartmentID] [int] NOT NULL,
	[vc_Job] [nvarchar](50) NULL,
	[vc_WorkType] [nvarchar](50) NULL,
	[vc_Telphone] [nvarchar](50) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Person] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Person_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Person] ADD  CONSTRAINT [DF_m_Person_i_Flag]  DEFAULT ((0)) FOR [i_Flag]

end
GO

/****** Object:  Table [dbo].[m_PDA]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_PDA]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_PDA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Code] [nvarchar](50) NULL,
	[vc_MacAddress] [varchar](50) NULL,
	[DepartmentID] [int] NULL,
	[i_State] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_PDA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_PDA_i_State]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_PDA] ADD  CONSTRAINT [DF_m_PDA_i_State]  DEFAULT ((0)) FOR [i_State]

/****** Object:  Default [DF_m_PDA_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_PDA] ADD  CONSTRAINT [DF_m_PDA_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Message]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Message]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanID] [int] NULL,
	[i_MessageType] [int] NULL,
	[FromUserID] [int] NULL,
	[ToUserID] [int] NULL,
	[vc_Message] [nvarchar](500) NULL,
	[dt_SendDateTime] [datetime] NULL,
	[dt_ReceiveDateTime] [datetime] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
	[i_State] [int] NULL,
	[i_Read] [int] NULL,
 CONSTRAINT [PK_m_Message] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Message_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Message] ADD  CONSTRAINT [DF_m_Message_i_Flag]  DEFAULT ((0)) FOR [i_Flag]

ALTER TABLE [dbo].[m_Message] ADD  CONSTRAINT [DF_m_Message_i_Read]  DEFAULT ((0)) FOR [i_Read]
end
GO

/****** Object:  Table [dbo].[m_MaterielType]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_MaterielType]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_MaterielType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Code] [varchar](50) NULL,
	[vc_Name] [nvarchar](50) NULL,
	[vc_Unit] [nvarchar](50) NULL,
	[ParentID] [int] NULL,
	[vc_Specifications] [nvarchar](50) NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_MaterielType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_MaterielType_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_MaterielType] ADD  CONSTRAINT [DF_m_MaterielType_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_GisMapFiles]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_GisMapFiles]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_GisMapFiles](
	[File_Name] [varchar](50) NULL,
	[File_Data] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
end
GO

/****** Object:  Table [dbo].[m_Department]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Department]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Name] [nvarchar](50) NOT NULL,
	[ParentID] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Department_ParentID]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Department] ADD  CONSTRAINT [DF_m_Department_ParentID]  DEFAULT ((0)) FOR [ParentID]

/****** Object:  Default [DF_m_Department_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Department] ADD  CONSTRAINT [DF_m_Department_i_Flag]  DEFAULT ((0)) FOR [i_Flag]

end
GO


/****** Object:  Table [dbo].[m_Card]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Card]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Card](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NULL,
	[i_LocalizerCardHID] [int] NULL,
	[i_IdentificationCardHID] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Card] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Card_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Card] ADD  CONSTRAINT [DF_m_Card_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Area]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Area]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Area](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Code] [nvarchar](50) NULL,
	[vc_Name] [nvarchar](50) NULL,
	[ParentID] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
 CONSTRAINT [PK_m_Area] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Area_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Area] ADD  CONSTRAINT [DF_m_Area_i_Flag]  DEFAULT ((0)) FOR [i_Flag]
end
GO

/****** Object:  Table [dbo].[m_Apply]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Apply]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Apply](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ApplyPersonID] [int] NULL,
	[dt_ApplyDateTime] [datetime] NULL,
	[vc_PlanUse] [nvarchar](50) NULL,
	[i_State] [int] NULL,
	[dt_ArriveDestinationDateTime] [datetime] NULL,
	[ArriveDestinationAddressID] [int] NULL,
	[i_IsUseMaterieApply] [int] NULL,
	[ApplyDepartmentID] [int] NULL,
	[vc_Remark] [nvarchar](500) NULL,
 CONSTRAINT [PK_m_Apply] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Apply_i_State]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Apply] ADD  CONSTRAINT [DF_m_Apply_i_State]  DEFAULT ((0)) FOR [i_State]

/****** Object:  Default [DF_m_Apply_i_IsUseMaterieApply]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Apply] ADD  CONSTRAINT [DF_m_Apply_i_IsUseMaterieApply]  DEFAULT ((0)) FOR [i_IsUseMaterieApply]
end
GO

/****** Object:  Table [dbo].[m_Address]    Script Date: 09/09/2014 14:25:57 ******/
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[m_Address]') AND type in (N'U'))
begin
CREATE TABLE [dbo].[m_Address](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[vc_Name] [nvarchar](50) NULL,
	[LocalizerStationID] [int] NULL,
	[AreaID] [int] NULL,
	[i_IsUpMine] [int] NULL,
	[i_IsDirectionStation] [int] NULL,
	[DirectionLocalizerStationID] [int] NULL,
	[vc_Memo] [nvarchar](50) NULL,
	[i_Flag] [int] NULL,
	[i_State] [int] NULL,
 CONSTRAINT [PK_m_Address] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
/****** Object:  Default [DF_m_Address_i_IsUpMine]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Address] ADD  CONSTRAINT [DF_m_Address_i_IsUpMine]  DEFAULT ((0)) FOR [i_IsUpMine]

/****** Object:  Default [DF_m_Address_i_DirectionStation]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Address] ADD  CONSTRAINT [DF_m_Address_i_DirectionStation]  DEFAULT ((0)) FOR [i_IsDirectionStation]

/****** Object:  Default [DF_m_Address_i_Flag]    Script Date: 10/10/2014 09:36:54 ******/
ALTER TABLE [dbo].[m_Address] ADD  CONSTRAINT [DF_m_Address_i_Flag]  DEFAULT ((0)) FOR [i_Flag]

ALTER TABLE [dbo].[m_Address] ADD  CONSTRAINT [DF_m_Address_i_State]  DEFAULT ((0)) FOR [i_State]
end
GO