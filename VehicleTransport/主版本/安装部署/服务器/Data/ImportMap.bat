@echo off

rem %1 为路径参数;
echo 正在导入地图...


cd %1
VehicleTransportServer.exe Map

echo rd /s /q %1\Map\
echo 地图导入成功！







