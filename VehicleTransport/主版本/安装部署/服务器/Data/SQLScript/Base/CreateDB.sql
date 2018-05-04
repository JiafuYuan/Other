use master
IF Not Exists (SELECT name FROM master.dbo.sysdatabases WHERE name = 'BW_VehicleTransportManage')
begin
create database [BW_VehicleTransportManage]
end