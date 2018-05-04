using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Manage;
using Common.Model.OutCommandModel;
using System.IO;
using Common.Interface;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    /// PDA取APK文件
    /// </summary>
    public class GetApkFileCommand : ICommand
    {
        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {

                CommandObjectModel cm = new CommandObjectModel();
                
                Byte[] buffer=new byte[1];
                try
                {
                    FileStream stream1 = new FileInfo(Config.GetModel().ApkFilePath).OpenRead();
                     buffer = new Byte[stream1.Length];
                    stream1.Read(buffer, 0, Convert.ToInt32(stream1.Length));
                    //fpModel.File = buffer;
                }
                catch (Exception xx)
                {
                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "读取APK文件出错：" + xx.Message, null, true));
                }

                int packageSize = 1024 * 50;
                int totalpackage = buffer.Length / packageSize;
                //最后一包的大小
                int lastPackageSize = buffer.Length % packageSize;
                if (lastPackageSize != 0)
                {
                    totalpackage++;
                }
                for (int i = 0; i < totalpackage; i++)
                {
                    OutApkFileModel fpModel = new OutApkFileModel();
                    fpModel.TotalPackage = totalpackage;
                    fpModel.CurrentPackage = i + 1;
                    if (totalpackage == i + 1)
                    {
                        fpModel.File = new byte[lastPackageSize];
                        Array.Copy(buffer, packageSize * i, fpModel.File, 0, lastPackageSize);
                    }
                    else
                    {
                        fpModel.File = new byte[packageSize];
                        Array.Copy(buffer, packageSize * i, fpModel.File, 0, packageSize);
                    }
                    
                    cm.CmdModelXml = Common.XmlManage<OutApkFileModel>.ModelToXml(fpModel);
                    
                    cm.Result = true;
                    cm.CmdType = Common.Enum.EnumCommandType.GetAPKFile;
                    cm.DateTime = DateTime.Now;
                    cm.CmdID = cmdModel.CmdID;
                    string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                    bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
                }
            }
            catch (Exception ex)
            {
                // WriteLog.AppendErrorLog(ex.Message);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取APK文件出错：" + ex.Message, null, true));
            }

        }
    }
}
