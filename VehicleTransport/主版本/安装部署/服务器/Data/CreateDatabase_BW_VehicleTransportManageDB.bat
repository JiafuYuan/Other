@echo off

rem %1 Ϊ·������;
rem %2 ���ݿ�ʵ����;
rem %3 �û���;
rem %4 ����;



echo ���ڸ���SQL�ű�...


osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateDB.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateTable.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateView.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateProcedure.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\InsertDefaultData.sql
osql -S %2 -U %3 -P %4 -i %1\SQLScript\Base\CreateTrigger.sql

rd /s /q %1\SQLScript\

pause






