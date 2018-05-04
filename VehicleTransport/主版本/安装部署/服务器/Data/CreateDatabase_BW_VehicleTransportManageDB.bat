@echo off

rem %1 为路径参数;
rem %2 数据库实例名;
rem %3 用户名;
rem %4 密码;



echo 正在更新SQL脚本...


osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateDB.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateTable.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateView.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateProcedure.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\InsertDefaultData.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateTrigger.sql

rd /s /q %1\SQLScript\

pause






