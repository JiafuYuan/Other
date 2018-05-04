using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model = DB_VehicleTransportManage.Model;
using BLL = DB_VehicleTransportManage.BLL;
namespace VehicleTransportClient.UI
{
    public partial class FrmMyMsg : Form
    {
        private BLL.m_Message bllmsg = new BLL.m_Message();
        private BLL.m_User blluser = new BLL.m_User();
        private BLL.m_Person bllperson = new BLL.m_Person();
        List<Model.m_Message> _myMsg = new List<Model.m_Message>();
        public FrmMyMsg(List<Model.m_Message> listmymsg)
        {
            InitializeComponent();
            _myMsg = listmymsg;
        }

        private void FrmMyMsg_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < _myMsg.Count; i++)
            {
                string messageTypeName="";
                switch ((Common.Enum.EnumMessageType)_myMsg[i].i_MessageType)
                {
                    case Common.Enum.EnumMessageType.CheckResul:
                        messageTypeName = "审核结果";
                        break;
                    case Common.Enum.EnumMessageType.AriveArea:
                        messageTypeName = "到达区域";
                        break;
                    case Common.Enum.EnumMessageType.NoChanageState:
                        messageTypeName = "未置换状态";
                        break;
                    default:
                        messageTypeName = "";
                        break;
                }

                string topersonname="";
                int topersonid=blluser.GetPersonID(_myMsg[i].ToUserID.Value);
                Model.m_Person toperson=bllperson.GetModel(topersonid);
                if (toperson!=null)
                    topersonname=toperson.vc_Name;

                string frompersonname="";
                int recpersonid=blluser.GetPersonID(_myMsg[i].FromUserID.Value);
                Model.m_Person recperson=bllperson.GetModel(recpersonid);
                if (recperson!=null)
                    frompersonname = recperson.vc_Name;
                dgvList.Rows.Add(dgvList.Rows.Count + 1, messageTypeName, frompersonname, topersonname, _myMsg[i].vc_Message, _myMsg[i].dt_SendDateTime);
            }
            labcount.Text = "总记录数:" + dgvList.Rows.Count;
        }
    }
}
