USE [BW_VehicleTransportManage]
GO

--地点触发器
if exists(select  name from sysobjects where name='TLastUpdateAddressTable')
begin
drop trigger TLastUpdateAddressTable 
end
GO
create trigger TLastUpdateAddressTable 
on m_Address
after insert,update ,delete
as 
if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdateAddressTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateAddressTable',getdate(),'地点表上次更新的时间')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdateAddressTable'
end 

GO

--部门触发器
if exists(select  name from sysobjects where name='TLastUpdateDepartmentTable')
begin
drop trigger TLastUpdateDepartmentTable 
end
GO
create trigger TLastUpdateDepartmentTable 
on m_department
after insert,update ,delete
as 
if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdateDepartmentTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateDepartmentTable',getdate(),'部门表上次更新的时间')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdateDepartmentTable'
end 


GO
--物料类型触发器
if exists(select  name from sysobjects where name='TLastUpdateMaterielTypeTable')
begin
drop trigger TLastUpdateMaterielTypeTable 
end
GO
create trigger TLastUpdateMaterielTypeTable 
on m_MaterielType
after insert,update ,delete
as 
if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdateMaterielTypeTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateMaterielTypeTable',getdate(),'物料类型表上次更新的时间')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdateMaterielTypeTable'
end 

GO
--人员触发器
if exists(select  name from sysobjects where name='TLastUpdatePersonTable')
begin
drop trigger TLastUpdatePersonTable 
end
GO
create trigger TLastUpdatePersonTable 
on m_Person
after insert,update ,delete
as 
if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdatePersonTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdatePersonTable',getdate(),'人员表上次更新的时间')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdatePersonTable'
end 

GO
--车辆触发器
if exists(select  name from sysobjects where name='TLastUpdatVehicleTable')
begin
drop trigger TLastUpdatVehicleTable 
end
GO
create trigger TLastUpdatVehicleTable 
on m_Vehicle
after insert,update ,delete
as 
if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdatVehicleTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdatVehicleTable',getdate(),'车辆表上次更新的时间')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdatVehicleTable'
end 

GO
GO
--车辆类型触发器
if exists(select  name from sysobjects where name='TLastUpdatVehicleTypeTable')
begin
drop trigger TLastUpdatVehicleTypeTable 
end
GO
create trigger TLastUpdatVehicleTypeTable 
on m_VehicleType
after insert,update ,delete
as 
if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdatVehicleTypeTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdatVehicleTypeTable',getdate(),'车辆类型表上次更新的时间')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdatVehicleTypeTable'
end 

GO
--卡触发器
if exists(select  name from sysobjects where name='TLastUpdateCardTable')
begin
drop trigger TLastUpdateCardTable 
end
GO
create trigger TLastUpdateCardTable 
on m_Card
after insert,update ,delete
as 
if((select COUNT(*) from m_SystemConfig where vc_key='LastUpdateCardTable')=0)
begin 
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateCardTable',getdate(),'卡表上次更新的时间')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdateCardTable'
end 