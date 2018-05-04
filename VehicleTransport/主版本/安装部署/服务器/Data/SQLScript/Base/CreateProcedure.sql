USE [BW_VehicleTransportManage]
GO

/*
**********************************************************************
*　　　　　　　　　　　　《部门车辆类型使用表》   　　　　　　　　　　 *
*--------------------------------------------------------------------*
*　                              *

*　　　　　　　　　　　　　　2014-10-31  *
**********************************************************************
*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VehicleTypeDept]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop proc [VehicleTypeDept]
GO

CREATE proc [dbo].[VehicleTypeDept] (@startDate varchar(50),@stopDate varchar(50),@ApplyDepartmentID int) as
declare     @sql       nvarchar(4000)
         

set @sql = 'select ApplyDepartmentID,ApplyDepartmentName,vehicleTypeName,COUNT(ApplyDepartmentName) as counts from 
(select ID,ApplyDepartmentID,ApplyDepartmentName from v_Plan where (i_State>1) and (dt_RealLoadDateTime between '''+@startDate+''' and ''' +@stopDate+''' ) '

if(@ApplyDepartmentID=0)
set @sql =@sql+' and ApplyDepartmentName is not null) as a '
else
set @sql =@sql+' and ApplyDepartmentID='+Convert(varchar(30),@ApplyDepartmentID) +' and ApplyDepartmentName is not null) as a '
set @sql =@sql+' inner join (select PlanID,VehicleID from m_Plan_Load where i_Flag=0 and VehicleID  in 
(select VehicleID from m_Plan_UnLoad where i_flag=0 and
 m_Plan_Load.PlanID=m_Plan_UnLoad.PlanID)) as b  on a.ID=b.PlanID
inner join (select ID as vehicleID, vehicleTypeID from  m_Vehicle) as c on b.VehicleID=c.vehicleID
inner join (select ID as vehicleTypeID, vc_Name as vehicleTypeName  from  m_VehicleType) as d on d.VehicleTypeID=c.vehicleTypeID
 group by ApplyDepartmentID,ApplyDepartmentName,vehicleTypeName order by ApplyDepartmentID'
print @sql
exec(@sql)




GO



/*
**********************************************************************
*　　　　　　　　　　　　《部门物料类型使用表》   　　　　　　　　　　 *
*--------------------------------------------------------------------*
*　                              *

*　　　　　　　　　　　　　　2014-11-04  *
**********************************************************************
*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MaterieTypeDept]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop proc [MaterieTypeDept]
GO
CREATE proc [dbo].[MaterieTypeDept] (@startDate varchar(50),@stopDate varchar(50),@ApplyDepartmentID int) as
declare     @sql       nvarchar(4000)
           
   
set @sql = 'select ApplyDepartmentID,ApplyDepartmentName,MaterielTypeCode,MaterielTypeName,sum(MaterielTypecounts )counts,MaterielTypeUnit from 
(select ID,ApplyDepartmentID,ApplyDepartmentName from v_Plan where (i_State>1 ) and (dt_RealLoadDateTime between '''+@startDate+''' and ''' +@stopDate+''' ) '
if(@ApplyDepartmentID=0)
set @sql =@sql+' and ApplyDepartmentName is not null) as a '
else
set @sql =@sql+' and ApplyDepartmentID='+Convert(varchar(30),@ApplyDepartmentID) +' and ApplyDepartmentName is not null) as a '
set @sql =@sql+' inner join (select PlanID,MaterieTypeID,Sum(n_Count) as MaterielTypecounts 
from m_Plan_Load where i_Flag=0 and VehicleID  in 
(select VehicleID from m_Plan_UnLoad where i_flag=0 and
 m_Plan_Load.PlanID=m_Plan_UnLoad.PlanID) group by  PlanID,MaterieTypeID) as b  on a.ID=b.PlanID
inner join (select ID as MaterielTypeID, vc_Code as MaterielTypeCode,vc_Name as MaterielTypeName,
vc_Unit as MaterielTypeUnit
 from  m_MaterielType) as c on b.MaterieTypeID=c.MaterielTypeID 
 group by ApplyDepartmentID,ApplyDepartmentName,MaterielTypeCode,MaterielTypeName,MaterielTypeUnit order by ApplyDepartmentName'
print @sql
exec(@sql)


GO
/*
**********************************************************************
*　　　　　　　　　　　　《创建轨迹表_机车》   　　　　　　　　　　 *
*--------------------------------------------------------------------*
*　                              *

*　　　　　　　　　　　　　　2013-12-16  *
**********************************************************************
*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VT_CreateTable_Track]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop proc [VT_CreateTable_Track]
GO
Create proc [dbo].[VT_CreateTable_Track](@lDate datetime,@TableName varchar(50) output) as
declare @sql       nvarchar(4000)
set @TableName='VT_Track_'+replace(convert(varchar(7),@lDate,120),'-','_')
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].['+@TableName+']') 
   and OBJECTPROPERTY(id, N'IsUserTable') = 1)
   begin
     set @sql='CREATE TABLE [dbo].['+@TableName+'] (
              	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	             	[VehicleCarID] [int] NOT NULL ,	
             		[KJ222LocalizerID] [int] NOT NULL ,
             		[dt_InTime] [datetime] not NULL ,
             		[dt_OutTime] [datetime] NULL ,
             		[i_Flag] [smallint] NOT NULL ,
             		[vc_Memo] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
             	) ON [PRIMARY]'
     exec sp_executesql @sql

     set @sql='ALTER TABLE [dbo].['+@TableName+'] WITH NOCHECK ADD 
             		CONSTRAINT [PK_'+@TableName+'] PRIMARY KEY  CLUSTERED 
             		([VehicleCarID],[dt_InTime],[ID])  ON [PRIMARY] '
     exec sp_executesql @sql

     set @sql='ALTER TABLE [dbo].['+@TableName+'] ADD 
             		CONSTRAINT [DF_'+@TableName+'_VehicleCarID] DEFAULT (0) FOR [VehicleCarID],
             		CONSTRAINT [DF_'+@TableName+'_KJ222LocalizerID] DEFAULT (0) FOR [KJ222LocalizerID],
             		CONSTRAINT [DF_'+@TableName+'_i_Flag] DEFAULT (0) FOR [i_Flag]'
     exec sp_executesql @sql
   end
GO
/****** Object:  StoredProcedure [dbo].[VehicleNoUseMonth]    Script Date: 10/10/2014 09:36:52 ******/

/*
**********************************************************************
*　　　　　　　　　　　　《车辆闲置月报表》   　　　　　　　　　　 *
*--------------------------------------------------------------------*
*　                              *

*　　　　　　　　　　　　　　2014-09-17  *
**********************************************************************
*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VehicleNoUseMonth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop proc [VehicleNoUseMonth]
GO
CREATE proc [dbo].[VehicleNoUseMonth](@startDate varchar(50),@stopDate varchar(50)) as
declare     @sql       nvarchar(4000)
         
    
set @sql='select vc_Code,vc_Name,a.Counts from (select VehicleID,COUNT(VehicleID) as Counts from data_VehicleAlarm where i_AlarmType=8 and dt_Start>='''
+@startDate+''' and dt_Start<='''+@stopDate+'''  and  i_Flag=0 group by VehicleID) as a 
left join m_Vehicle as b on b.ID=a.VehicleID'
print @sql
exec (@sql)
GO



/*
**********************************************************************
*　　　　　　　　　　　　《车辆位置统计表》   　　　　　　　　　　 *
*--------------------------------------------------------------------*
*　                              *

*　　　　　　　　　　　　　　2014-10-31  *
**********************************************************************
*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VehicleAddress]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop proc [VehicleAddress]
GO
CREATE proc [dbo].[VehicleAddress]  as
declare     @sql       nvarchar(4000)
         

set @sql = 'select VehicleTypeName as 车辆类型, max(case i_IsUpMine when 0 then counts ELSE 0 END) 井下, max(case i_IsUpMine when 1 then counts ELSE 0 END) 井上,sum(counts) as 合计
from(
select b.i_IsUpMine,c.vc_Name as VehicleTypeName,COUNT(c.vc_Name) as counts
 from m_Vehicle as a 
 left join m_VehicleType as c 
 on a.VehicleTypeID=c.ID
 left join 
m_Address as b
on a.i_LocalizerStationID=b.LocalizerStationID where b.vc_Name is not null
group by b.i_IsUpMine,c.vc_Name) as e GROUP BY VehicleTypeName
union all 
select ''合计'' as 车辆类型,sum(地面) 地面,SUM(井下) 井下,SUM(合计) 合计
from(
select VehicleTypeName as 车辆类型, max(case i_IsUpMine when 0 then counts ELSE 0 END) 地面, max(case i_IsUpMine when 1 then counts ELSE 0 END) 井下,sum(counts) as 合计
from(
select b.i_IsUpMine,c.vc_Name as VehicleTypeName,COUNT(c.vc_Name) as counts
 from m_Vehicle as a 
 left join m_VehicleType as c 
 on a.VehicleTypeID=c.ID
 left join 
m_Address as b
on a.i_LocalizerStationID=b.LocalizerStationID where b.vc_Name is not null
group by b.i_IsUpMine,c.vc_Name) as e GROUP BY VehicleTypeName) as d'
print @sql
exec(@sql)




GO




/****** Object:  StoredProcedure [dbo].[VehicleMonth]    Script Date: 10/10/2014 09:36:52 ******/

/*
**********************************************************************
*　　　　　　　　　　　　《车辆使用月报表》   　　　　　　　　　　 *
*--------------------------------------------------------------------*
*　                              *

*　　　　　　　　　　　　　　2014-09-17  *
**********************************************************************
*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VehicleMonth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop proc [VehicleMonth]
GO
CREATE proc [dbo].[VehicleMonth](@Date datetime) as
declare     @sql       nvarchar(4000),
            @start     nvarchar(100),
            @stop      nvarchar(100)
    set     @start=convert(varchar(8),@Date,120)+'01 00:00:00'
    set     @stop=convert(varchar(8),@Date,120)+cast(Day(dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,@Date)+1,0)))  as varchar(10))+' 23:59:59'
    

set @sql='select c.vc_Code,c.vc_Name,Count(b.VehicleID) as VehicleCount  from (select * from m_Plan where i_State>1 and dt_RealLoadDateTime>='''
+@start+''' and dt_RealLoadDateTime<='''+@stop+''' ) as a inner join  m_VehiclePlanDetail as b on a.ID=b.PlanID '+
' inner join (select * from m_Vehicle where i_Flag=0) as c'+
' on b.VehicleID=c.ID   group by  c.vc_Code,c.vc_Name'
print @sql
exec (@sql)
GO

/****** Object:  StoredProcedure [dbo].[MaterielTypeMonth]    Script Date: 10/10/2014 09:36:52 ******/

/*
**********************************************************************
*　　　　　　　　　　　　《物料使用月报表》   　　　　　　　　　　 *
*--------------------------------------------------------------------*
*　                              *

*　　　　　　　　　　　　　　2014-09-17  *
**********************************************************************
*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MaterielTypeMonth]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop proc [MaterielTypeMonth]
GO
Create proc [dbo].[MaterielTypeMonth](@Date datetime) as

declare     @sql       nvarchar(4000),
            @start     nvarchar(100),
            @stop      nvarchar(100)
    set     @start=convert(varchar(8),@Date,120)+'01 00:00:00'
    set     @stop=convert(varchar(8),@Date,120)+cast(Day(dateadd(ms,-3,DATEADD(mm, DATEDIFF(m,0,@Date)+1,0)))  as varchar(10))+' 23:59:59'
    

set @sql = 'select MaterielTypeCode,MaterielTypeName,sum(MaterielTypecounts )counts,MaterielTypeUnit from 
(select ID,ApplyDepartmentID,ApplyDepartmentName from v_Plan where (i_State>1) and (dt_RealLoadDateTime between '''+@start+''' and ''' +@stop+''' ) '
set @sql =@sql+' and ApplyDepartmentName is not null) as a '
set @sql =@sql+' inner join (select PlanID,MaterieTypeID,Sum(n_Count) as MaterielTypecounts 
from m_Plan_Load where i_Flag=0 and VehicleID in 
(select VehicleID from m_Plan_UnLoad where i_flag=0 and
 m_Plan_Load.PlanID=m_Plan_UnLoad.PlanID) group by  PlanID,MaterieTypeID) as b  on a.ID=b.PlanID
inner join (select ID as MaterielTypeID, vc_Code as MaterielTypeCode,vc_Name as MaterielTypeName,
vc_Unit as MaterielTypeUnit
 from  m_MaterielType) as c on b.MaterieTypeID=c.MaterielTypeID 
 group by MaterielTypeCode,MaterielTypeName,MaterielTypeUnit order by MaterielTypeName'
print @sql
exec (@sql)
GO

USE [BW_KJ222]
GO
/****** Object:  StoredProcedure [dbo].[DisposeData_History_TramCar]    Script Date: 10/10/2014 09:13:35 ******/

/*
**********************************************************************
*　　　　　　　　　　　　《历史数据处理过程_矿车》   　　　　　　　　　　 *
*--------------------------------------------------------------------*
*　 第1个参数 识别卡HID                                               *
*　 第2个参数 基站ID                                                  *
*   第3个参数 卡状态:   进入0     离开1                                *
*   第4个参数 时间                                                    *
*   第5个参数 基站电量  用于告警                                    　 *
*   第6个参数 卡电量    用于告警                                    　 *
*                                                                    *
*     返回值   0  执行成功                                            *
*	           -1  非法卡，未处理                                 *
*************************** ******************************************
*　　　　　　　　　　　　　　　Written by Hezison(一根火柴) 2008-08-27  *
**********************************************************************
*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DisposeData_History_TramCar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop proc [DisposeData_History_TramCar]
GO
CREATE                   proc [dbo].[DisposeData_History_TramCar](
             @CardHID        int,
             @LocalizerID    int,
             @LocalizerType  smallint,
             @OnLine         smallint,        --进入0     离开1
             @dtTime         datetime
 )as
  declare @sql               nvarchar(4000),
          @VehicleCarID       varchar(50),
          @TableName         varchar(50),
          @InTime            datetime,
          @AreaInTime        datetime,
          @AreaID            varchar(50),
          @HistoryAreaID     int,
          @Flag              smallint,
          @dt_OutTime  dateTime,
          @i_LocalizerStationID  int
        
 select @VehicleCarID=VehicleID from BW_VehicleTransportManage.dbo.m_Card where i_LocalizerCardHID=@CardHID  and i_Flag & 1=0
 select @i_LocalizerStationID=i_LocalizerStationID from BW_VehicleTransportManage.dbo.m_Vehicle where ID=@VehicleCarID
   if @VehicleCarID is null 
     return  --非矿车卡
  
  if @OnLine=0      --进入
     begin
         set @Flag=@LocalizerType 
          update BW_VehicleTransportManage.dbo.m_Vehicle set i_LastLocalizerStationID=@i_LocalizerStationID ,i_LocalizerStationIDChanaged=1 where ID=@VehicleCarID 
                                            and (dt_InLocalizerStationDateTime is null or dt_InLocalizerStationDateTime<@dtTime)
                                            
          update BW_VehicleTransportManage.dbo.m_Vehicle set i_LocalizerStationID=@LocalizerID,dt_InLocalizerStationDateTime=@dtTime where ID=@VehicleCarID 
                                            and (dt_InLocalizerStationDateTime is null or dt_InLocalizerStationDateTime<@dtTime)
          exec BW_VehicleTransportManage.dbo.VT_CreateTable_Track @dtTime,@TableName output
          set @sql='insert into BW_VehicleTransportManage.dbo.'+@TableName+' (VehicleCarID,KJ222LocalizerID,dt_InTime,i_Flag) values ('+
                                               convert(varchar(10),@VehicleCarID)+','+
                                               convert(varchar(10),@LocalizerID)+','''+
                                               convert(varchar(19),@dtTime,120)+''','+
                                               convert(varchar(10),@Flag)+')'
          exec (@sql)




     end

  else              --离开
     begin
       
        
          --update BW_VehicleTransportManage.dbo.m_Vehicle  set dt_OutTime=@dtTime where ID=@VehicleCarID and dt_InTime<@dtTime
          select @InTime=dt_InLocalizerStationDateTime from BW_VehicleTransportManage.dbo.m_Vehicle  where ID=@VehicleCarID
          exec BW_VehicleTransportManage.dbo.VT_CreateTable_Track @InTime,@TableName output
          set @sql='update BW_VehicleTransportManage.dbo.'+@TableName+' set dt_OutTime='''+convert(varchar(19),@dtTime,120)+''' where VehicleCarID='+
                                           convert(varchar(10),@VehicleCarID)+' and KJ222LocalizerID='+
                                           convert(varchar(10),@LocalizerID)+' and dt_OutTime is null and dt_InTime='''+
                                           convert(varchar(19),@InTime,120)+''''
          exec (@sql)
        
     end



--rollback transaction
GO
/****** Object:  StoredProcedure [dbo].[DisposeData_Current_TramCar]    Script Date: 10/10/2014 09:13:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec dbo.DisposeData_Current_TramCar 6025,12,1,0,'2014-08-12 14:34:00',3



/*
**********************************************************************
*　　　　　　　　　　　　《当前数据处理过程_机车》   　　　　　　　　　　 *
*--------------------------------------------------------------------*
*　 第1个参数 识别卡HID                                               *
*　 第2个参数 基站ID                                                  *
*   第3个参数 卡状态:   进入0     离开1                                *
*   第4个参数 时间                                                    *
*   第5个参数 基站电量  用于告警                                    　 *
*   第6个参数 卡电量    用于告警                                    　 *
*                                                                    *
*     返回值   0  执行成功                                            *
*	           -1  非法卡，未处理                                 *
**********************************************************************
*　　　　　　　　　　　　　　　Written by Hezison(一根火柴) 2008-05-29  *
**********************************************************************
*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DisposeData_Current_TramCar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop proc [DisposeData_Current_TramCar]
GO
CREATE                   proc  [dbo].[DisposeData_Current_TramCar](
             @CardHID        int,
             @LocalizerID    int,
             @LocalizerType  smallint,
             @OnLine         smallint,        --进入0     离开1
             @dtTime         datetime,
             @CardPower      smallint
) as
  declare @sql               nvarchar(4000),
          @VehicleCarID         int,
          @TableName         varchar(50),
          @InTime            datetime,
          @AreaInTime        datetime,
          @AreaID            int,
          @HistoryAreaID     int,
          @i_LocalizerStationID  int,
          @Flag              smallint

  select @VehicleCarID=VehicleID from BW_VehicleTransportManage.dbo.m_Card where i_LocalizerCardHID=@CardHID  and i_Flag & 1=0
  select @i_LocalizerStationID=i_LocalizerStationID from BW_VehicleTransportManage.dbo.m_Vehicle where ID=@VehicleCarID
  if @VehicleCarID is null 
     return  --非矿车卡
  /*
    --卡电量告警
  if @CardPower=1
     exec dbo.Alarm_InsertIntoCurrent 2001,@PersonID,0,''
  else
     exec dbo.Alarm_MoveToHistory 2001,@PersonID,0
  --更新卡表中的电量值
  */
  --date m_card set i_power=@CardPower where i_hid=@CardHID

  
  if @OnLine=0      --进入
    begin
     if @i_LocalizerStationID<>@LocalizerID 
        begin
          set @Flag=@LocalizerType 
          update BW_VehicleTransportManage.dbo.m_Vehicle set i_LastLocalizerStationID=@i_LocalizerStationID,i_LocalizerStationIDChanaged=1  where ID=@VehicleCarID 
                                            and ( dt_InLocalizerStationDateTime is null or dt_InLocalizerStationDateTime<@dtTime) 
          update BW_VehicleTransportManage.dbo.m_Vehicle set i_LocalizerStationID=@LocalizerID,dt_InLocalizerStationDateTime=@dtTime where ID=@VehicleCarID 
                                            and ( dt_InLocalizerStationDateTime is null or dt_InLocalizerStationDateTime<@dtTime) 
          exec BW_VehicleTransportManage.dbo.VT_CreateTable_Track @dtTime,@TableName output
          set @sql='insert into BW_VehicleTransportManage.dbo.'+@TableName+' (VehicleCarID,KJ222LocalizerID,dt_InTime,i_Flag) values ('+
                                               convert(varchar(10),@VehicleCarID)+','+
                                               convert(varchar(10),@LocalizerID)+','''+
                                               convert(varchar(19),@dtTime,120)+''','+
                                               convert(varchar(10),@Flag)+')'
          exec (@sql)
        end
   

    end
  else              --离开
    begin
      
         -- update BW_VehicleTransportManage.dbo.m_Vehicle  set dt_InLocalizerStationDateTime=@dtTime where ID=@VehicleCarID and dt_InLocalizerStationDateTime<@dtTime 
          select @InTime=dt_InLocalizerStationDateTime from BW_VehicleTransportManage.dbo.m_Vehicle  where ID=@VehicleCarID
          exec BW_VehicleTransportManage.dbo.VT_CreateTable_Track @InTime,@TableName output
          set @sql='update BW_VehicleTransportManage.dbo.'+@TableName+' set dt_OutTime='''+convert(varchar(19),@dtTime,120)+''' where VehicleCarID='+
                                           convert(varchar(10),@VehicleCarID)+' and KJ222LocalizerID='+
                                           convert(varchar(10),@LocalizerID)+' and dt_OutTime is null and dt_InTime='''+
                                           convert(varchar(19),@InTime,120)+''''
          exec (@sql)
      

    end
GO



