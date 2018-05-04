USE [BW_VehicleTransportManage]
GO

--�ص㴥����
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
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateAddressTable',getdate(),'�ص���ϴθ��µ�ʱ��')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdateAddressTable'
end 

GO

--���Ŵ�����
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
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateDepartmentTable',getdate(),'���ű��ϴθ��µ�ʱ��')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdateDepartmentTable'
end 


GO
--�������ʹ�����
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
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateMaterielTypeTable',getdate(),'�������ͱ��ϴθ��µ�ʱ��')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdateMaterielTypeTable'
end 

GO
--��Ա������
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
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdatePersonTable',getdate(),'��Ա���ϴθ��µ�ʱ��')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdatePersonTable'
end 

GO
--����������
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
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdatVehicleTable',getdate(),'�������ϴθ��µ�ʱ��')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdatVehicleTable'
end 

GO
GO
--�������ʹ�����
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
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdatVehicleTypeTable',getdate(),'�������ͱ��ϴθ��µ�ʱ��')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdatVehicleTypeTable'
end 

GO
--��������
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
insert into m_SystemConfig (vc_key,vc_value,vc_memo) values ('LastUpdateCardTable',getdate(),'�����ϴθ��µ�ʱ��')
end
else
begin
update m_SystemConfig set vc_value=getdate() where vc_key='LastUpdateCardTable'
end 