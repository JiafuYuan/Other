using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.Manage;
using VehicleTransportServer.Thread.Command;
using VehicleTransportServer.Thread.Command.NormalCommand;
using VehicleTransportServer.Thread.FlowPath;
using VehicleTransportServer.Thread.BackWork;
using VehicleTransportServer.Thread;
using Common.Model.InCommandModel;
using Common;
using Common.Model;
using VehicleTransportServer.Thread.BackWork.Alarm;

namespace VehicleTransportServer
{
    public class MainServer
    {
        private AreaNofityThread _areaNofityThread = new AreaNofityThread();
        private WifiBaseStationStateThread _wifiBaseStationStateThread = new WifiBaseStationStateThread();
        private AlarmThread _alarmThread = new AlarmThread();
        private CheckEqipmentStateThread _checkEqipmentStateThread = new CheckEqipmentStateThread();
        private CheckDBOnlineThread _checkDBOnlineThread = new CheckDBOnlineThread();
        public bool ServerIsRun = false;

        public bool Start()
        {
           bool b=  SocketManage.Current.Init();

           _areaNofityThread.Start();
           _wifiBaseStationStateThread.Start();
           _alarmThread.Start();
           _checkEqipmentStateThread.Start();
           _checkDBOnlineThread.Run();
            ServerIsRun = true;
            return b;
        }

        public void Stop()
        {
            _areaNofityThread.Stop();
            _wifiBaseStationStateThread.Stop();
            _alarmThread.Stop();
            _checkEqipmentStateThread.Stop();
            _checkDBOnlineThread.Stop();
            ServerIsRun = false;
        }
    }
}
