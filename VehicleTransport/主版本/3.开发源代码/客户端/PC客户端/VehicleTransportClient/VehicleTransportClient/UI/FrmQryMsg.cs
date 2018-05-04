using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model=DB_VehicleTransportManage.Model;
using BLL=DB_VehicleTransportManage.BLL;
namespace VehicleTransportClient.UI
{
    public partial class FrmQryMsg : Form
    {
        public FrmQryMsg()
        {
            InitializeComponent();
        }
        private BLL.m_Message bllmsg = new BLL.m_Message();
        private BLL.m_User blluser = new BLL.m_User();
        private BLL.m_Person bllperson = new BLL.m_Person();
        private void InitGrid(DateTime dateTimeStart, DateTime dateTimeStop)
        {
            List<Model.m_User> lstUsers = new BLL.m_User().GetModelList("i_Flag=0");
            List<Model.m_Person> lstPersonss = new BLL.m_Person().GetModelList("i_Flag=0");
            dgvList.Rows.Clear();
            if (dateTimeStart.Year == 1 && dateTimeStop.Year == 1)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat(" i_Flag=0  and i_state=0");
                List<Model.m_Message> listmsg = bllmsg.GetModelList(stringBuilder.ToString());
              
                foreach (var vMessage in listmsg)
                {
                    var userModelFrom = lstUsers.Find(p => p.ID == vMessage.FromUserID);
                    string FromPersonName = "";
                    if (userModelFrom != null)
                    {
                        var personId = userModelFrom.PersonID;
                        var tt = lstPersonss.Find(p => p.ID == personId);
                        if (tt != null)
                        {
                            FromPersonName = tt.vc_Name;
                        }
                    }

                    var userModelTo = lstUsers.Find(p => p.ID == vMessage.ToUserID);
                    string ToPersonName = "";
                    if (userModelTo != null)
                    {
                        var personId = userModelTo.PersonID;
                        var tt = lstPersonss.Find(p => p.ID == personId);
                        if (tt != null)
                        {
                            ToPersonName = tt.vc_Name;
                        }
                    }
                    dgvList.Rows.Add(dgvList.Rows.Count + 1, FromPersonName, ToPersonName, vMessage.vc_Message, vMessage.dt_SendDateTime);
                }
            }
            else
            {
                if (dateTimeStart <= dateTimeStop)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendFormat(" i_Flag=0  and i_state=0 and dt_SendDateTime>='{0}' and dt_SendDateTime<='{1}'",
                        dateTimeStart.ToString("yyyy-MM-dd 00:00:00"), dateTimeStop.ToString("yyyy-MM-dd 23:59:59"));
                    List<Model.m_Message> listmsg = bllmsg.GetModelList(stringBuilder.ToString());
                    foreach (var vMessage in listmsg)
                    {
                        var userModelFrom = lstUsers.Find(p => p.ID == vMessage.FromUserID);
                        string FromPersonName = "";
                        if (userModelFrom != null)
                        {
                            var personId = userModelFrom.PersonID;
                            var tt = lstPersonss.Find(p => p.ID == personId);
                            if (tt != null)
                            {
                                FromPersonName = tt.vc_Name;
                            }
                        }

                        var userModelTo = lstUsers.Find(p => p.ID == vMessage.ToUserID);
                        string ToPersonName = "";
                        if (userModelTo != null)
                        {
                            var personId = userModelTo.PersonID;
                            var tt = lstPersonss.Find(p => p.ID == personId);
                            if (tt != null)
                            {
                                ToPersonName = tt.vc_Name;
                            }
                        }
                        dgvList.Rows.Add(dgvList.Rows.Count + 1, FromPersonName, ToPersonName, vMessage.vc_Message, vMessage.dt_SendDateTime);
                    }
                }
                else
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("开始时间必须在结束时间之前", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void FrmQryMsg_Load(object sender, EventArgs e)
        {
            //dtStart.Value = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00"));
            //dtStop.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            InitGrid(dtStart.Value, dtStop.Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitGrid(dtStart.Value, dtStop.Value);
        }
    }
}
