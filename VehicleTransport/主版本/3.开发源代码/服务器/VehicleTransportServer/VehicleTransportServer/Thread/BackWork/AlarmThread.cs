using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.BackWork.Alarm;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.BackWork
{
    public class AlarmThread
    {
        private System.Threading.ManualResetEvent _mEvent = new System.Threading.ManualResetEvent(true);

        //判断线程安全退出的信号量             
        private System.Threading.ManualResetEvent _mEventStopAll = new System.Threading.ManualResetEvent(false);

        private BackTimeOutAlarm _backTimeOutAlarm = new BackTimeOutAlarm();
        private GiveTimeOutAlarm _giveTimeOutAlarm = new GiveTimeOutAlarm();
        private LoadTimeOutAlarm _loadTimeOutAlarm = new LoadTimeOutAlarm();
        private MaintainTimeOutAlarm _maintainTimeOutAlarm = new MaintainTimeOutAlarm();
        private NoChanageStateAlarm _noChanageStateAlarm = new NoChanageStateAlarm();
        private UnUseAlarm _unUseAlarm = new UnUseAlarm();
        private RunDerictionAlarm _runDerictionAlarm = new RunDerictionAlarm();
        private ScrapTimeOutAlarm _scrapTimeOutAlarm = new ScrapTimeOutAlarm();
        private TransportTimeOutAlarm _transportTimeOutAlarm = new TransportTimeOutAlarm();
        private UnLoadTimeOutAlarm _unLoadTimeOutAlarm = new UnLoadTimeOutAlarm();
        

        public void Start()
        {
            new System.Threading.Thread(DoWork).Start();
        }

        public void Stop()
        {
            _mEventStopAll.Set();
        }

        private void DoWork()
        {
            while (_mEvent.WaitOne() == true)
            {
                //判断线程安全退出             
                if (_mEventStopAll.WaitOne(10, false) == true) break;

                try
                {
                    if (Pub._isDBOnline == true)
                    {

                        

                        if (Pub.FlowPathModel.Give) _giveTimeOutAlarm.DoWork();

                        if (Pub.FlowPathModel.Load) _loadTimeOutAlarm.DoWork();

                        _transportTimeOutAlarm.DoWork();

                        if (Pub.FlowPathModel.UnLoad) _unLoadTimeOutAlarm.DoWork();

                         _backTimeOutAlarm.DoWork();//一直运行，判断实际到达时间

                        _maintainTimeOutAlarm.DoWork();
                        _noChanageStateAlarm.DoWork();
                        _unUseAlarm.DoWork();
                        _runDerictionAlarm.DoWork();
                        _scrapTimeOutAlarm.DoWork();
                        
                        
                        
                        
                    }
                }
                catch (Exception ex)
                {
                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "告警处理出错：" + ex.Message, null, true));
                }

                System.Threading.Thread.Sleep(3000);
            }

        }

        public void CloseAllAlarm(int planID, int vehicleID)
        {
            new GiveTimeOutAlarm().CloseAlarm(planID);
            new LoadTimeOutAlarm().CloseAlarm(planID);
            new TransportTimeOutAlarm().CloseAlarm(planID);
            new UnLoadTimeOutAlarm().CloseAlarm(planID);
            new BackTimeOutAlarm().CloseAlarm(planID);
            new UnUseAlarm().CloseAlarm(vehicleID);
            new NoChanageStateAlarm().CloseAlarm(planID);
            new RunDerictionAlarm().CloseAlarm(planID,vehicleID);
        }
    }
}
