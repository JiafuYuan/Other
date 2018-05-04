using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
namespace VehicleTransportClient.UI
{
    public partial class FormUnCheckReason : Common.frmBase
    {
        private Model.m_Apply _apply = null;
        public FormUnCheckReason(Model.m_Apply apply)
        {
            InitializeComponent();
            _apply = apply;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            string reason = txtreason.Text;

            if (!string.IsNullOrEmpty(reason))
            {
                if (Common.MessageBoxEx.MessageBoxEx.Show("确定要驳回该订单？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnok.Enabled = false;
                    btncancle.Enabled = false;
                    _apply.vc_remark = reason;
                    bool breturn = Pub.BackServer.SendCheck(null, null, null, null, _apply);
                    if (breturn == true)
                    {
                        Common.MessageBoxEx.MessageBoxEx.Show("完成审核");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Common.MessageBoxEx.MessageBoxEx.Show("发送失败,请重新审核");
                        btnok.Enabled = true;
                        btncancle.Enabled = true;
                    }

                }

            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请填写驳回理由");
            }
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
