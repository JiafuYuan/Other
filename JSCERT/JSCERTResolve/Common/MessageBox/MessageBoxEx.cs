using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Common.MessageBoxEx
{
    public class MessageBoxEx
    {
        public static frmBaseMessageForm MsgWin=new frmBaseMessageForm();
        private static DialogResult ShowWindow(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
        {
            MsgWin = new frmBaseMessageForm();
            MsgWin.StartPosition = FormStartPosition.CenterScreen;
           
            DialogResult result = MsgWin.DrawWindow(owner, text, caption, buttons, icon, defaultbutton);
            MsgWin.Dispose();
            return result;
        }

        public static DialogResult Show(string text)
        {
            return ShowWindow(null, text, "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption)
        {
            return ShowWindow(null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            return ShowWindow(null, text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return ShowWindow(null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return ShowWindow(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return ShowWindow(null, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return ShowWindow(owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return ShowWindow(null, text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return ShowWindow(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return ShowWindow(owner, text, caption, buttons, icon, defaultButton);
        }

        public static void HideWin()
        {
            MsgWin.Hide();//.Dispose();
        }
    }
}
