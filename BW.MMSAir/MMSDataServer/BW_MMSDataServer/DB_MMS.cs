using System;
using System.Collections.Generic;
using System.Text;
using Bestway.Windows.Tools.ADODB;
using Bestway.Windows.Program.SocketDataModel.MMS;
using System.Data;
using System.Windows.Forms;
namespace Bestway.Windows.Program.MMS
{
    class DB_MMS:IDisposable
    {
        public DB_MMS()
        {
            dbHelper = new OleDbHelper();
            dbHelper.StateChanged += new System.Data.StateChangeEventHandler(dbHelper_StateChanged);

            execDataThread = new System.Threading.Thread(ExecDataProc);
            execDataThread.IsBackground = true;

            lstSql = new List<string>();
            lockSql = new object();
        }

        public OleDbHelper dbHelper = null;
        private System.Threading.Thread execDataThread = null;
        private volatile bool bExit=false;
        private object lockSql=null;
        private List<string> lstSql = null;

        private void ExecDataProc(object obj)
        {
            string sql = "";
            while (!bExit)
            {
                lock (lockSql)
                {
                    if (lstSql.Count > 0)
                    {
                        sql = lstSql[0];
                        lstSql.RemoveAt(0);
                    }
                }

                if (sql != "")
                {
                    try
                    {
                        
                        if (-1 == dbHelper.ExecuteSql(sql))
                        {
                            GlobalObject.Methods.WriteLog("执行SQL失败，SQL=" + sql);
                        }
                        sql = "";
                    }
                    catch(Exception ex)
                    {
                        GlobalObject.Methods.WriteLog("执行SQL失败，SQL=" + sql+"\r\n"+ex.Message+"\r\n"+ex.StackTrace);
                    }
                    
                }
                else
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
        }

        private void dbHelper_StateChanged(object sender, System.Data.StateChangeEventArgs e)
        {
            if(e.CurrentState== System.Data.ConnectionState.Open)
                GlobalObject.Methods.WriteLog("数据库连接成功！",false);
            else
                GlobalObject.Methods.WriteLog("数据库连接中断！");
        }

        public bool Initialize(DBInfo dbInfo)
        {
            if (OleDbHelper.ELoggingResult.Connected != dbHelper.Connection(dbInfo))
            {
                GlobalObject.Methods.WriteLog("数据库连接失败!");
                return false;
            }

            bExit = false;
            
            execDataThread.Start();


            return true;
        }

        public void Dispose()
        {
            bExit = true;
            if(execDataThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                System.Threading.Thread.Sleep(100);
            }
            execDataThread.Abort();
            
        }

        //在原有的基础上增加了置零标示和电力的变比
        public void ExecData_CheckZero(bool isRealtimeData,bool isSetZero,SensorModel sensor,Worker.OPCPowerBaseData ls)
        {
            /*
            @DataType			int,			--数据类型：实时数据-0, 其他数据暂未用到
            @SensorID			int,			--设备ID
		    @SensorType			int,			--设备类型：产量-0, 风-1, 水-2, 电-3
		
		    @DataTime			datetime,		--数据时间
		    @DataValue_Real		numeric(9,2),	--瞬时流量
		    @DataValue_Total	numeric(9,2),	--累计量
		    @DataValue_State	int,			--状态
		
		    @DataTime_Pre		datetime,		--数据时间
		    @DataValue_Real_Pre		numeric(9,2),	--瞬时流量
		    @DataValue_Total_Pre	numeric(9,2),	--累计量
		    @DataValue_State_Pre	int,			--状态
		
		    @IsSetZero			int,			--置零标示
		    @voltageRate		numeric(9,2),	--电压变比
		    @currentRate		numeric(9,2),	--电流变比
		    @currentValue		numeric(9,2),	--收到的OPC的值
		    @Param5				int=0			--预留参数
            */
          
            if (sensor.Type == Bestway.Windows.Program.SocketDataModel.MMS.EnumSensorType.Power)
            {
                /*
                if (ls.Count == 0) return;
                float voltageRate=0, currentRate=0,currentValue=0;
                foreach (Worker.OPCPowerBaseData data in ls)
                {
                    voltageRate = data.VoltageRate;
                    currentRate = data.CurrentRate;
                    currentValue = data.CurrentValue;
                }
                */
                //GlobalObject.Methods.WriteLog("数据库处理数据："+isRealtimeData+","+sensor.Type.GetHashCode().ToString(),true);
                float voltageRate = 0, currentRate = 0, currentValue = 0;
                voltageRate = ls.VoltageRate;
                currentRate = ls.CurrentRate;
                currentValue = ls.CurrentValue;
                this.AddSql(string.Format("exec dbo.ExecuteData {0},{1},{2},'{3}',{4},{5},{6},'{7}',{8},{9},{10},{11},{12},{13},{14},{15}",
                                    (isRealtimeData ? 0 : 1).ToString(),
                                    sensor.ID.ToString(),
                                    sensor.Type.GetHashCode().ToString(),
                                    ((sensor.NodesRealTime[EnumNodeType.Realtime].DataTime > sensor.NodesRealTime[EnumNodeType.Total].DataTime) ?
                                            sensor.NodesRealTime[EnumNodeType.Realtime].DataTime :
                                            sensor.NodesRealTime[EnumNodeType.Total].DataTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    sensor.NodesRealTime[EnumNodeType.Realtime].Value.ToString(),
                                    sensor.NodesRealTime[EnumNodeType.Total].Value.ToString(),
                                    sensor.NodesRealTime[EnumNodeType.State].Value.ToString(),
                                    ((sensor.NodesPrevious[EnumNodeType.Realtime].DataTime > sensor.NodesPrevious[EnumNodeType.Total].DataTime) ?
                                            sensor.NodesPrevious[EnumNodeType.Realtime].DataTime :
                                            sensor.NodesPrevious[EnumNodeType.Total].DataTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    sensor.NodesPrevious[EnumNodeType.Realtime].Value.ToString(),
                                    sensor.NodesPrevious[EnumNodeType.Total].Value.ToString(),
                                    sensor.NodesPrevious[EnumNodeType.State].Value.ToString(),
                                    (isSetZero ? 1 : 0).ToString(),
                                    voltageRate.ToString(),
                                    currentRate.ToString(),
                                    currentValue.ToString(), 0));
            }
            else
            {
                this.AddSql(string.Format("exec dbo.ExecuteData {0},{1},{2},'{3}',{4},{5},{6},'{7}',{8},{9},{10},{11},{12},{13},{14},{15}",
                                    (isRealtimeData ? 0 : 1).ToString(),
                                    sensor.ID.ToString(),
                                    sensor.Type.GetHashCode().ToString(),
                                    ((sensor.NodesRealTime[EnumNodeType.Realtime].DataTime > sensor.NodesRealTime[EnumNodeType.Total].DataTime) ?
                                            sensor.NodesRealTime[EnumNodeType.Realtime].DataTime :
                                            sensor.NodesRealTime[EnumNodeType.Total].DataTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    sensor.NodesRealTime[EnumNodeType.Realtime].Value.ToString(),
                                    sensor.NodesRealTime[EnumNodeType.Total].Value.ToString(),
                                    sensor.NodesRealTime[EnumNodeType.State].Value.ToString(),
                                    ((sensor.NodesPrevious[EnumNodeType.Realtime].DataTime > sensor.NodesPrevious[EnumNodeType.Total].DataTime) ?
                                            sensor.NodesPrevious[EnumNodeType.Realtime].DataTime :
                                            sensor.NodesPrevious[EnumNodeType.Total].DataTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                    sensor.NodesPrevious[EnumNodeType.Realtime].Value.ToString(),
                                    sensor.NodesPrevious[EnumNodeType.Total].Value.ToString(),
                                    sensor.NodesPrevious[EnumNodeType.State].Value.ToString(),
                                    (isSetZero ? 1 : 0).ToString(),
                                    0, 0, 0, 0));
            }
            
        }

        public void ExecData(bool isRealtimeData, SensorModel sensor)
        {
            /*
            @DataType			int,			--数据类型：实时数据-0, 其他数据暂未用到
            @SensorID			int,			--设备ID
		    @SensorType			int,			--设备类型：产量-0, 风-1, 水-2, 电-3
		
		    @DataTime			datetime,		--数据时间
		    @DataValue_Real		numeric(9,2),	--瞬时流量
		    @DataValue_Total	numeric(9,2),	--累计量
		    @DataValue_State	int,			--状态
		
		    @DataTime_Pre		datetime,		--数据时间
		    @DataValue_Real_Pre		numeric(9,2),	--瞬时流量
		    @DataValue_Total_Pre	numeric(9,2),	--累计量
		    @DataValue_State_Pre	int,			--状态
		
		    @Param1				int=0,			--预留参数
		    @Param2				int=0,			--预留参数
		    @Param3				int=0,			--预留参数
		    @Param4				int=0,			--预留参数
		    @Param5				int=0			--预留参数
            */
            this.AddSql(string.Format("exec dbo.ExecuteData {0},{1},{2},'{3}',{4},{5},{6},'{7}',{8},{9},{10},{11},{12},{13},{14},{15}",
                                (isRealtimeData ? 0 : 1).ToString(),
                                sensor.ID.ToString(),
                                sensor.Type.GetHashCode().ToString(),
                                ((sensor.NodesRealTime[EnumNodeType.Realtime].DataTime > sensor.NodesRealTime[EnumNodeType.Total].DataTime) ?
                                        sensor.NodesRealTime[EnumNodeType.Realtime].DataTime :
                                        sensor.NodesRealTime[EnumNodeType.Total].DataTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                sensor.NodesRealTime[EnumNodeType.Realtime].Value.ToString(),
                                sensor.NodesRealTime[EnumNodeType.Total].Value.ToString(),
                                sensor.NodesRealTime[EnumNodeType.State].Value.ToString(),
                                ((sensor.NodesPrevious[EnumNodeType.Realtime].DataTime > sensor.NodesPrevious[EnumNodeType.Total].DataTime) ?
                                        sensor.NodesPrevious[EnumNodeType.Realtime].DataTime :
                                        sensor.NodesPrevious[EnumNodeType.Total].DataTime).ToString("yyyy-MM-dd HH:mm:ss"),
                                sensor.NodesPrevious[EnumNodeType.Realtime].Value.ToString(),
                                sensor.NodesPrevious[EnumNodeType.Total].Value.ToString(),
                                sensor.NodesPrevious[EnumNodeType.State].Value.ToString(),
                                0, 0, 0, 0, 0));
        }

        public void AddSql(string sql)
        {
            lock (lockSql)
            {
                lstSql.Add(sql);
            }
        }

        /// <summary>读取设备信息与数据，如：基础信息，设备节点地址，节点最后一次数据</summary>
        /// <param name="sensors"></param>
        /// <returns></returns>
        public bool GetSensorData(ref List<SensorModel> sensors)
        {
            string sql = "select ID,vc_Code,TypeCode,AreaID,DeptID from v_Sensor where i_Flag & 1=0";
            System.Data.DataTable dt = dbHelper.GetDataTable(sql);
            if (dt == null) return false;
            sensors.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SensorModel sm = new SensorModel();
                sm.AreaID = int.Parse(dt.Rows[i]["AreaID"].ToString());
                sm.Code = dt.Rows[i]["vc_Code"].ToString();
                sm.DeptID = int.Parse(dt.Rows[i]["DeptID"].ToString());
                sm.ID = int.Parse(dt.Rows[i]["ID"].ToString());

                EnumSensorType st = EnumSensorType.Unknow;
                if (Enum.TryParse<EnumSensorType>(dt.Rows[i]["TypeCode"].ToString(), out st)
                    && st != EnumSensorType.Unknow)
                {
                    sm.Type = st;

                    //最后一次数据
                    sql = "exec dbo.GetLastNodesValue " + sm.ID.ToString();
                    System.Data.DataTable dtNodes = dbHelper.GetDataTable(sql);
                    if (dtNodes != null)
                    {
                        for (int j = 0; j < dtNodes.Rows.Count; j++)
                        {
                            EnumNodeType nt = EnumNodeType.Unknow;
                            if (Enum.TryParse<EnumNodeType>(dtNodes.Rows[j]["Key"].ToString(), out nt))
                            {
                                if (nt != EnumNodeType.Unknow)
                                {
                                    sm.NodesPrevious[nt].Address = (dtNodes.Rows[j]["Address"] == null ? "" :
                                                                    dtNodes.Rows[j]["Address"].ToString());
                                    sm.NodesPrevious[nt].Value = (dtNodes.Rows[j]["Value"] == null ? 0 :
                                                                    dtNodes.Rows[j]["Value"]);
                                    if (dtNodes.Rows[j]["DataTime"].ToString() != "")
                                        sm.NodesPrevious[nt].DataTime =
                                            DateTime.Parse(dtNodes.Rows[j]["DataTime"].ToString());
                                    //sm.NodesPrevious[nt].Type = nt;

                                    sm.NodesRealTime[nt] = (Node)sm.NodesPrevious[nt].Clone();
                                    sm.NodesTemp[nt] = (Node)sm.NodesPrevious[nt].Clone();
                                    sm.NodesTemp[nt].Value = 0;
                                    //zy 20140404
                                    //sm.NodesPrevious[EnumNodeType.Total].Value = "false";

                                    //GlobalObject.Methods.WriteLog("节点数据："+"【"+nt.ToString()+"】"+ sm.NodesPrevious[nt].Address+" "+sm.NodesPrevious[nt].Value, true);
                                }
                            }
                        }
                    }
                    sensors.Add(sm);
                }
                sm = null;
            }
            return true;
        }

        public System.Data.DataSet getSensorAddress()
        {
            string sql = "select NodeID, vc_Address from m_SensorNodes where SensorID in(select ID from m_sensor where TypeID in(1,2,3))";
            return dbHelper.GetDataSet(sql);
        }

        public bool getAsh(ref List<AshContentModule> list)
        {
            string sql = "select ID,InstallationPosition,i_Flag from m_Ash where i_Flag=0";
            System.Data.DataTable tab = dbHelper.GetDataTable(sql);
            list.Clear();
            if (tab != null)
            {
                foreach (System.Data.DataRow row in tab.Rows)
                {
                    AshContentModule acm = new AshContentModule();
                    acm.ID =int.Parse( row["ID"].ToString());
                    acm.InstallationPosition = row["InstallationPosition"].ToString();
                    acm.i_Flag =int.Parse( row["i_Flag"].ToString());
                    acm.bUpdated = false;
                    list.Add(acm);
                }
            }
            
            return true;
        }
        public List<PLCEntity> GetPLC()
        {
            List<PLCEntity> list = new List<PLCEntity>();
            try
            {
                string sql = "select * from m_PLC where i_flag=0";
                System.Data.DataTable dt = dbHelper.GetDataTable(sql);
                if (dt == null) return list;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PLCEntity entity = new PLCEntity();
                    entity.id = int.Parse(dt.Rows[i]["id"].ToString());
                    entity.ip = dt.Rows[i]["vc_IP"].ToString();
                    entity.name = dt.Rows[i]["vc_name"].ToString();
                    entity.remark = dt.Rows[i]["vc_remark"] == null ? "" : dt.Rows[i]["vc_remark"].ToString();
                    entity.state = dt.Rows[i]["state"] == null ? -1 : int.Parse(dt.Rows[i]["state"].ToString());
                    list.Add(entity);
                }
                return list;
            }
            catch
            {
                return list;
            }
        }

        public bool ExecDataAshHour(ref List<AshContentModule> list,DateTime date)
        {

            string sql =string.Empty;
            if (date.Minute != 0) date = date.AddHours(1);
            try
            {
                foreach (AshContentModule acm in list)
                {
                    if (acm.bUpdated)
                    {
                        sql = "exec ExecuteAshHour '" + acm.ID + "','" + date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + acm.AshHour + "'";
                        dbHelper.ExecuteSql(sql);
                    }
                }
            }
            catch
            {
                return false;
            }
            
            return true;
        }
        public bool ExecDataAshClass(ref List<AshContentModule> list, DateTime date)
        {

            string sql = string.Empty;
            try
            {
                foreach (AshContentModule acm in list)
                {
                    if (acm.bUpdated)
                    {
                        sql = "exec ExecuteAshClass '" + acm.ID + "','" + date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + acm.AshNightClass + "','" + acm.AshMorningClass + "','" + acm.AshMiddayClass + "'";
                        dbHelper.ExecuteSql(sql);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool ExecDataAshDay(ref List<AshContentModule> list, DateTime date)
        {
            if (date.Hour == 0 && date.Minute == 0) date = date.AddDays(-1);
            string sql = string.Empty;
            try
            {
                foreach (AshContentModule acm in list)
                {
                    if (acm.bUpdated)
                    {
                        sql = "exec ExecuteAshDay '" + acm.ID + "','" + date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + acm.AshDayValue + "'";
                        dbHelper.ExecuteSql(sql);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool ExecDataAshContent(ref List<AshContentModule> list)
        {
            string sql = "declare @tabName varchar(50), "+
		                "         @Year varchar(4), "+
		                "         @Month varchar(2), "+
		                "         @sql varchar(4000) "+
                        "set @Year='"+DateTime.Now.ToString("yyyy")+"' "+
                        "set @Month='"+DateTime.Now.ToString("MM")+"' "+
                        "set @tabName='Data_History_Ash_'+@Year+'_'+@Month "+
                        "if(not exists(select * from sysobjects where name =@tabName)) "+
	                    "  begin "+
		                "       set @sql=' select * into '+@tabName+' from Data_History_Ash_YYYY_MM where 1=2' "+
		                "       exec(@sql) "+
                         "  end " +
                         "set @sql='insert into '+@tabName+'(dt_datetime,AshContentID,AshMinute,AshTenMinute,AshHour,i_Flag) "+
                         " values(''{0}'',''{1}'',''{2}'',''{3}'',''{4}'',''{5}'')' "+
                         " exec(@sql) ";
            foreach (AshContentModule acm in list)
            {
                if (acm.bUpdated)
                {
                   string  sql1=string.Format(sql,new object[]
                    {
                        acm.Dt_datetime.ToString("yyyy-MM-dd HH:mm:ss"),
                        acm.ID.ToString(),
                        acm.AshMinute,
                        acm.AshTenMinute,
                        acm.AshHour,
                        acm.i_Flag
                    });
                    if (dbHelper.ExecuteSql(sql1) < 1)
                    {
                        GlobalObject.Methods.WriteLog(sql1, true);
                    }
                    acm.bUpdated = false;
                    
                }
            }
            return true;
            //string sql = "insert into ";
            //foreach (AshContentModule acm in list)
            //{
            //    dbHelper.ExecuteSql(sql,new System.Data.OleDb.OleDbParameter[]{});
            //}
            //return true;
        }
        //PLC实时告警
        public void PlcAlarmCurrent(int plcid)
        {
            string sql = "select * from m_sensor where i_flag=0 and plcadress='" + plcid.ToString() + "'";
            DataTable dt = dbHelper.GetDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sensorid=dt.Rows[i]["id"].ToString();
                string areaid=dt.Rows[i]["areaid"].ToString();
                string deptid=dt.Rows[i]["deptid"].ToString();  
                DateTime dttime=DateTime.Now;
                string insertsql = "insert Alarm_Current(AlarmTypeID,ObjectID,AreaID,dt_BeginTime,DeptID,i_Flag)"
                + "values(1," + sensorid + "," + areaid + ",'" + dttime.ToString() + "'," + deptid + ",0)";
                dbHelper.ExecuteSql(insertsql);
            }
        }
        //PLC历史告警
        public void PlcAlarmHistory(int plcid)
        {
            try
            {
                string sql = "select * from m_sensor where i_flag=0 and plcadress='" + plcid.ToString() + "'";
                DataTable dt = dbHelper.GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sensorid = dt.Rows[i]["id"].ToString();
                    string exesql = "insert Alarm_History(AlarmTypeID,ObjectID,AreaID,dt_BeginTime,DeptID) "
                                    + "select AlarmTypeID,ObjectID,AreaID,dt_BeginTime,DeptID from Alarm_Current where ObjectID=" + sensorid + " and AlarmTypeID=1 and i_Flag=0";
                    dbHelper.ExecuteSql(exesql);
                    exesql = "update Alarm_History set dt_EndTime='" + DateTime.Now.ToString() + "',i_Flag=0 where ObjectID=" + sensorid + " and AlarmTypeID=1 and dt_EndTime is null ";
                    dbHelper.ExecuteSql(exesql);
                    exesql = "delete from Alarm_Current where ObjectID=" + sensorid + " and AlarmTypeID=1 and i_Flag=0";
                    dbHelper.ExecuteSql(exesql);
                }
            }
            catch(Exception exc)
            {
                GlobalObject.Methods.WriteLog("插入历史PLC告警报错"+exc.ToString());
            }
        }

        public void UpdataPLCState(int plcid, bool state)
        {
            int curstate = state == true ? 0 : 1;
            string sql = "update m_plc set state=" + curstate + " where id=" + plcid.ToString();
            dbHelper.ExecuteSql(sql);
        }
        /// <summary>
        /// 结束传感器告警
        /// </summary>
        /// <param name="sensorid"></param>
        /// <param name="areaid"></param>
        /// <param name="deptid"></param>
        public void SensorAlarmHistory(int sensorid)
        {
            string sql = "insert Alarm_History(AlarmTypeID,ObjectID,AreaID,dt_BeginTime,DeptID,dt_EndTime) "
             + "select AlarmTypeID,ObjectID,AreaID,dt_BeginTime,DeptID,GETDATE() from Alarm_Current where ObjectID=" + sensorid.ToString() + " and i_Flag=0 and AlarmTypeID='1001'";
            dbHelper.ExecuteSql(sql);
            sql = "delete from Alarm_Current where ObjectID=" + sensorid.ToString() + " and i_Flag=0 and AlarmTypeID='1001'";
            dbHelper.ExecuteSql(sql);

        }
        /// <summary>
        /// 产生传感器告警
        /// </summary>
        /// <param name="sensorid"></param>
        /// <param name="areaid"></param>
        /// <param name="deptid"></param>
        public void AddSensorAlarm(int sensorid, int areaid, int deptid)
        {
            string sql = "select * from Alarm_Current where alarmtypeid='1001' and objectid=" + sensorid.ToString();
            DataTable dt = dbHelper.GetDataTable(sql);
            if (dt==null|| dt.Rows.Count == 0)
            {
                sql = "insert into Alarm_Current(AlarmTypeID,ObjectID,AreaID,dt_BeginTime,DeptID,i_Flag) "
                + "values('1001','" + sensorid.ToString() + "','" + areaid.ToString() + "',GETDATE(),'" + deptid.ToString() + "','0') select count(*) from Alarm_Current";
                    int n = dbHelper.ExecuteSql(sql);
            }
        }
    }
}
