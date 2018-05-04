using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Model;
using Common.Enum;
using Common;
using Common.Model.InCommandModel;
using Common.Model.FlowPath.InFlowPath;

using Common.Model.DataCommand.InDataCommand;

namespace VehicleTransportClient
{
    public partial class FormSocketTest : Form
    {
        SocketManage sm;
        public FormSocketTest()
        {
            InitializeComponent();
            sm = new SocketManage();
      //

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Login;
            InLoginModel l = new InLoginModel()
            {
                UserName = "zxy",
                PassWord = "1",
                 UserType= EnumUserType.PDA
                 
            };
            cmd.CmdModelXml = XmlManage<InLoginModel>.ModelToXml(l);
            cmd.DateTime = DateTime.Now;
            try
            {
                InLoginModel c = XmlManage<InLoginModel>.XmlToModel(cmd.CmdModelXml);
            }
            catch (Exception)
            {
                throw;
            }

            bool b = sm.SendAndWait(cmd);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.GetFlowPath;
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.GetAPKVersion;
            cmd.DateTime = DateTime.Now;

            bool b = sm.SendAndWait(cmd);

            //CommandObjectModel cmd = new CommandObjectModel();
            //cmd.CmdType = EnumCommandType.Data_SendMessage;
            //Common.Model.DataCommand.InDataCommand.InSendMessageModel i = new InSendMessageModel();
            //i.M_MessageModel.
            //cmd.DateTime = DateTime.Now;
            //bool b = sm.SendAndWait(cmd);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.GetTime;
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.GetAPKFile;
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_Apply;
            Common.Model.FlowPath.InFlowPath.InApplyModel inModel = new Common.Model.FlowPath.InFlowPath.InApplyModel();

            inModel.M_Apply = new DB_VehicleTransportManage.Model.m_Apply()
            {
                ApplyPersonID = 0,
                ArriveDestinationAddressID = 0,
                dt_ArriveDestinationDateTime = DateTime.Now,
                dt_ApplyDateTime = DateTime.Now,
                vc_PlanUse = "装沙子asdfsad",
                i_IsUseMaterieApply = 1
            };

            inModel.ListM_Plan_ApplyMaterie = new List<DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie>();

            inModel.ListM_Plan_ApplyMaterie.Add(new DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie()
            {
                MaterieTypeID = 1,
                ApplyID = 0,
                n_Count = 10
            });

            inModel.ListM_Plan_ApplyMaterie.Add(new DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie()
            {
                MaterieTypeID = 2,
                ApplyID = 0,
                n_Count = 100
            });
            cmd.CmdModelXml = XmlManage<InApplyModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_Give;
            Common.Model.FlowPath.InFlowPath.InGiveModel inModel = new Common.Model.FlowPath.InFlowPath.InGiveModel();

            inModel.ListM_Plan_GiveVehicle.Add(new DB_VehicleTransportManage.Model.m_Plan_GiveVehicle()
            {
                PlanID = 1,
                VehicleTypeID = 1,
                i_Count = 1
            });

            inModel.ListM_Plan_GiveVehicle.Add(new DB_VehicleTransportManage.Model.m_Plan_GiveVehicle()
            {

                PlanID = 1,
                VehicleTypeID = 2,
                i_Count = 1
            });

            cmd.CmdModelXml = XmlManage<InGiveModel>.ModelToXml(inModel);
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button9_Click(object sender, EventArgs e)
        {
        
            DB_VehicleTransportManage.Model.m_Apply applyModel = new DB_VehicleTransportManage.Model.m_Apply();
            applyModel = new DB_VehicleTransportManage.BLL.m_Apply().GetOneNewModel();
            if (applyModel.i_State==Common.Enum.EnumApplyState.WaitCheck.GetHashCode())
            {
                DB_VehicleTransportManage.Model.m_Plan planModel = new DB_VehicleTransportManage.Model.m_Plan();
                planModel.ApplyID = applyModel.ID;
                planModel.CheckPersonID = 1;
                planModel.i_State = Common.Enum.EnumPlanState.Checked.GetHashCode();
                new DB_VehicleTransportManage.BLL.m_Plan().Add(planModel);
                applyModel.i_State = Common.Enum.EnumApplyState.Checked.GetHashCode();
                new DB_VehicleTransportManage.BLL.m_Apply().Update(applyModel);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Data_GetMaterielType;
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }



        private void button11_Click(object sender, EventArgs e)
        {

            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Data_SendMessage;
           // InSendMessageModel im = new InSendMessageModel();
            //im.ListM_MessageModel.Add(new DB_VehicleTransportManage.Model.m_Message()
            //{
            //    dt_ReceiveDateTime = DateTime.Now,
            //    dt_SendDateTime = DateTime.Now,
            //    FromUserID = 1,
            //    i_MessageType = 0,
            //    i_State = 0,
            //    ToUserID = 1,
            //    PlanID = 1,
            //    vc_Memo = "sdfa",
            //    vc_Message = "asfdas"
            //});
            //cmd.CmdModelXml = Common.XmlManage<Common.Model.DataCommand.InDataCommand.InSendMessageModel>.ModelToXml(im);
            //try
            //{
            //    im = Common.XmlManage<Common.Model.DataCommand.InDataCommand.InSendMessageModel>.XmlToModel(cmd.CmdModelXml);
            //}
            //catch (Exception)
            //{
            //}


            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Login;
            InLoginModel l = new InLoginModel()
            {
                UserName = "lsq_PDA",
                PassWord = "1",
                 UserType= EnumUserType.PDA
                
            };
            cmd.CmdModelXml = XmlManage<InLoginModel>.ModelToXml(l);
            cmd.DateTime = DateTime.Now;
            try
            {
                InLoginModel c = XmlManage<InLoginModel>.XmlToModel(cmd.CmdModelXml);
            }
            catch (Exception)
            {
                throw;
            }
            bool b = sm.SendAndWait(cmd);
        }

       

        private void button13_Click(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;
        }

        private void button14_Click(object sender, EventArgs e)
        {
          bool b=  sm.InitSocket(txtLocalIP.Text,txtRemoteIP.Text,int.Parse(txtPort.Text));
          if (b)
          {
              this.Text = "连接成功";
          }
          else
          {
              this.Text = "连接失败";
          }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.HeartBeat;
            InHeartBeatModel l = new InHeartBeatModel()
            {
                UserID = 13,
                PDAMac = "aabbccdd",
                WifiBaseStationMac = "11223344",

                // DateTime = DateTime.Now
            };
            //for (int i = 0; i < 10000*10; i++)
            //{
            //    l.ArrB[i] = 1;
            //}
            cmd.CmdModelXml = XmlManage<InHeartBeatModel>.ModelToXml(l);
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.HeartBeat;
            InHeartBeatModel l = new InHeartBeatModel()
            {
                UserID = 14,
                PDAMac = "aabbccdd",
                WifiBaseStationMac = "11223344",
                // DateTime = DateTime.Now
            };
            //for (int i = 0; i < 10000*10; i++)
            //{
            //    l.ArrB[i] = 2;
            //}
            cmd.CmdModelXml = XmlManage<InHeartBeatModel>.ModelToXml(l);
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.EndAlarm;
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);


        }

        private void button16_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            InGetPlanDetailModel model = new InGetPlanDetailModel();
            //model.ApplyDepartmentID = 1;
            //model.ArriveAddressID = 2;
            //model.BeginDateTime = DateTime.Now.AddDays(-10);
            //model.EndDateTime = DateTime.Now;
            model.UserID = 12;
            model.PageSize = 2;
            model.StartIndex = 1;
            model.FlowType = EnumFlowPathType.Give;
            cmd.CmdModelXml = XmlManage<InGetPlanDetailModel>.ModelToXml(model);

            cmd.CmdType = EnumCommandType.Data_GetPlanDetail;
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.GetDBInfo;
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Data_GetCard;
            InGetCardModel ind = new InGetCardModel();
            ind.LastUpdateTime = DateTime.Now;

            cmd.CmdModelXml = XmlManage<InGetCardModel>.ModelToXml(ind);
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            cmd.CmdType = EnumCommandType.Flow_Handover;
            InHandoverModel ind = new InHandoverModel();
            ind.UserID = 15;
            ind.ListM_Plan_Handover.Add(new DB_VehicleTransportManage.Model.m_Plan_Handover()
            {
                PlanID = 0,
                VehicleID = 3,
                ID = 0,
                dt_HandoverDateTime = DateTime.Now,
                ReceiveVehiclePersonID = 0,
                AddressID = 0,
                i_HandoverCount = 0

            }
                );
            ind.ListM_Plan_HandoverMaterie.Add(new DB_VehicleTransportManage.Model.m_Plan_HandoverMaterie()
            {
                ID = 0,
                PlanHandoverID = 0,
                MaterieTypeID = 1,

                n_Count = 1
            });
            cmd.CmdModelXml = XmlManage<InHandoverModel>.ModelToXml(ind);
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            InGetMyPlanDetailModel model = new InGetMyPlanDetailModel();
            //model.ApplyDepartmentID = 1;
            //model.ArriveAddressID = 2;
            //model.BeginDateTime = DateTime.Now.AddDays(-10);
            //model.EndDateTime = DateTime.Now;
            model.UserID = 12;
           //model.PageSize = 10;
            //model.FlowType = EnumFlowPathType.Give;
            cmd.CmdModelXml = XmlManage<InGetMyPlanDetailModel>.ModelToXml(model);

            cmd.CmdType = EnumCommandType.Data_GetMyPlanDetail;
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            CommandObjectModel cmd = new CommandObjectModel();
            InGetVehicleIsCanDoModel model = new InGetVehicleIsCanDoModel();
            //model.ApplyDepartmentID = 1;
            //model.ArriveAddressID = 2;
            //model.BeginDateTime = DateTime.Now.AddDays(-10);
            //model.EndDateTime = DateTime.Now;
            model.FlowType = EnumFlowPathType.UnLoad;
            model.VehicleID = 3;
            //model.PageSize = 10;
            //model.FlowType = EnumFlowPathType.Give;
            cmd.CmdModelXml = XmlManage<InGetVehicleIsCanDoModel>.ModelToXml(model);

            cmd.CmdType = EnumCommandType.Data_GetVehicleIsCanDo;
            cmd.DateTime = DateTime.Now;
            bool b = sm.SendAndWait(cmd);
        }
    }
}
