using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Common
{
    public partial class frmBaseMessageForm : Common.frmBase
    {
        private MessageBoxButtons msgBoxButtons;

        #region DLL
        [DllImport("winmm.dll", EntryPoint = "PlaySound")]
        public static extern int PlaySound(
            string lpszName,
            int hModule,
            int dwFlags
        );
        [DllImport("user32.dll", EntryPoint = "DrawIconEx")]
        public static extern int DrawIconEx(
            IntPtr hdc,
            int xLeft,
            int yTop,
            IntPtr hIcon,
            int cxWidth,
            int cyWidth,
            int istepIfAniCur,
            IntPtr hbrFlickerFreeDraw,
            int diFlags
        );
        #endregion

        public frmBaseMessageForm()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.SizeChanged += new EventHandler(frmBaseMessageFormNew_SizeChanged);
        }

        #region 公有方法
        public DialogResult DrawWindow(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
        {
            if (owner != null)
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(1, 1);
            panelButtonShow.Width = 0;
            this.msgBoxButtons = buttons;
            this.Text = (caption != String.Empty) ? caption : " ";
            this.FormTitle = this.Text;
            //this.lblCaption.Text = this.Text.ToString();
            // this.lblShowText.Text = text;

            if (icon != MessageBoxIcon.None)
            {
                this.vPicBox.Image = this.DrawIcon(icon);
                this.panelLeft.Visible = true;
            }
            else
            {
                this.vPicBox.Image = null;
                this.panelLeft.Visible = false;
                // this.vPicBox.Visible = false;
            }
            this.SetButtonVisible(buttons);

            this.SetButtonText(buttons);

            //if ((defaultbutton == MessageBoxDefaultButton.Button1) && this.vBool1)
            //    this.vbutton1.Select();
            //else if ((defaultbutton == MessageBoxDefaultButton.Button2) && this.vBool2)
            //    this.vbutton2.Select();
            //else if ((defaultbutton == MessageBoxDefaultButton.Button3) && this.vBool3)
            //    this.vbutton3.Select();

            //this.SetLabelSize();

            //// this.SetLocation();
            //ReSetSize();

            if (icon == MessageBoxIcon.Question)
                PlaySound("SystemQuestion", 1, 3);
            else if (icon == MessageBoxIcon.Asterisk)
                PlaySound("SystemAsterisk", 2, 3);
            else
                PlaySound("SystemExclamation", 3, 3);




            //vbutton1.Visible = true;
            //vbutton2.Visible = true;
            //vbutton3.Visible = true;
            // string s = "sfs国".PadLeft(10, 'a') + "X";
            labelMessage.Text = text;
            frmBaseMessageFormNew_SizeChanged(null, null);
            SetButtonLocation();



            return base.ShowDialog(owner);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 画图标
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        private Image DrawIcon(MessageBoxIcon icon)
        {
            Icon asterisk = null;
            if (icon == MessageBoxIcon.Asterisk)
                asterisk = SystemIcons.Asterisk;
            else if ((icon == MessageBoxIcon.Hand) || (icon == MessageBoxIcon.Hand))
                asterisk = SystemIcons.Error;
            else if (icon == MessageBoxIcon.Exclamation)
                asterisk = SystemIcons.Exclamation;
            else if (icon == MessageBoxIcon.Hand)
                asterisk = SystemIcons.Hand;
            else if (icon == MessageBoxIcon.Asterisk)
                asterisk = SystemIcons.Information;
            else if (icon == MessageBoxIcon.Question)
                asterisk = SystemIcons.Question;
            else if (icon == MessageBoxIcon.Exclamation)
                asterisk = SystemIcons.Warning;
            Bitmap image = new Bitmap(asterisk.Width, asterisk.Height);
            image.MakeTransparent();
            using (Graphics graphics = Graphics.FromImage(image))
            {
                if (((Environment.Version.Build <= 0xe79) && (Environment.Version.Revision == 0x120)) && ((Environment.Version.Major == 1) && (Environment.Version.Minor == 0)))
                {
                    IntPtr hdc = graphics.GetHdc();
                    try
                    {
                        DrawIconEx(hdc, 0, 0, asterisk.Handle, asterisk.Width, asterisk.Height, 0, IntPtr.Zero, 3);


                        return image;
                    }
                    finally
                    {
                        graphics.ReleaseHdc(hdc);
                    }
                }
                if (asterisk.Handle == IntPtr.Zero)
                    return image;
                try
                {
                    graphics.DrawIcon(asterisk, 0, 0);
                    return image;
                }
                catch
                {
                    return image;
                }
            }
        }

        /// <summary>
        /// 设置button可见性
        /// </summary>
        private void SetButtonVisible(MessageBoxButtons buttons)
        {
            if (((buttons == MessageBoxButtons.OKCancel) || (buttons == MessageBoxButtons.RetryCancel)) || (buttons == MessageBoxButtons.YesNo))
            {
                this.vbutton1.Visible = true;
                this.vbutton2.Visible = true;
                this.vbutton3.Visible = false;
            }
            else if (buttons == MessageBoxButtons.OK)
            {
                this.vbutton1.Visible = true;
                this.vbutton2.Visible = false;
                this.vbutton3.Visible = false;
            }
            else if (buttons == MessageBoxButtons.AbortRetryIgnore)
            {
                this.vbutton1.Visible = true;
                this.vbutton2.Visible = true;
                this.vbutton3.Visible = true;
            }
            else if (buttons == MessageBoxButtons.YesNoCancel)
            {
                this.vbutton1.Visible = true;
                this.vbutton2.Visible = true;
                this.vbutton3.Visible = true;
            }


            if (buttons == MessageBoxButtons.OK)
            {
                this.AcceptButton = this.vbutton1;
                this.CancelButton = this.vbutton1;
            }
            else if (((buttons == MessageBoxButtons.OKCancel) || (buttons == MessageBoxButtons.RetryCancel)) || (buttons == MessageBoxButtons.YesNo))
            {
                base.AcceptButton = this.vbutton1;
                base.CancelButton = this.vbutton2;
            }
            else if (buttons == MessageBoxButtons.YesNoCancel)
            {
                base.AcceptButton = this.vbutton1;
                base.CancelButton = this.vbutton3;
            }
        }

        /// <summary>
        /// 设置buttonText
        /// </summary>
        /// <param name="buttons"></param>
        private void SetButtonText(MessageBoxButtons buttons)
        {
            if (buttons == MessageBoxButtons.AbortRetryIgnore)
            {
                this.vbutton1.Text = "中断(&A)";
                this.vbutton2.Text = "重试(&T)";
                this.vbutton3.Text = "忽略(&I)";
            }
            else if (buttons == MessageBoxButtons.OK)
                this.vbutton1.Text = "确定(&O)";
            else if (buttons == MessageBoxButtons.OKCancel)
            {
                this.vbutton1.Text = "确定(&O)";
                this.vbutton2.Text = "取消(&C)";
            }
            else if (buttons == MessageBoxButtons.RetryCancel)
            {
                this.vbutton1.Text = "重试(&T)";
                this.vbutton2.Text = "取消(&C)";
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                this.vbutton1.Text = "是(&Y)";
                this.vbutton2.Text = "否(&N)";
            }
            else if (buttons == MessageBoxButtons.YesNoCancel)
            {
                this.vbutton1.Text = "是(&Y)";
                this.vbutton2.Text = "否(&N)";
                this.vbutton3.Text = "取消(&C)";
            }
        }

        /// <summary>
        /// 得到字符宽度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private SizeF GetStringWidth(string str)
        {
            Graphics graphics = CreateGraphics();
            SizeF sizeF = graphics.MeasureString(str, new Font("宋体", 9));
            graphics.Dispose();
            return sizeF;
        }

        /// <summary>
        /// 设置Button位置
        /// </summary>
        private void SetButtonLocation()
        {
            if (panelButtonShow.Width > this.Width)
            {
                this.Width = panelButtonShow.Width + 28;
            }

            panelButtonShow.Left = (panelButton.Width - panelButtonShow.Width) / 2;

        }

        #endregion

        #region 私有事件

        void frmBaseMessageFormNew_SizeChanged(object sender, EventArgs e)
        {
            SizeF sizeF = GetStringWidth(labelMessage.Text);
            if (this.Width == this.MaximumSize.Width) //是否到最大宽度
            {
                labelMessage.AutoSize = false;
                if (vPicBox.Image != null)
                {
                    labelMessage.Width = this.Width - panelLeft.Width - 15;
                }
                else
                {
                    labelMessage.Width = this.Width - 15;
                }

                labelMessage.Height = Convert.ToInt32((sizeF.Height) * (sizeF.Width / labelMessage.Width + 1));
                labelMessage.Left = 0;
                if (labelMessage.Height >= panelMessage.Height)
                {
                    labelMessage.Top = 0;
                }
                else
                {
                    labelMessage.Top = (panelMessage.Height - labelMessage.Height) / 2;
                }
            }
            else
            {
                labelMessage.Left = (panelMessage.Width - labelMessage.Width) / 2;
                if (vPicBox.Image != null)
                {
                    labelMessage.Left = labelMessage.Left - 15;
                }
                labelMessage.Top = (panelMessage.Height - labelMessage.Height) / 2;
            }
        }


        private void vbutton1_Click(object sender, EventArgs e)
        {
            DialogResult oK = DialogResult.OK;
            if ((this.msgBoxButtons == MessageBoxButtons.OK) || (this.msgBoxButtons == MessageBoxButtons.OKCancel))
            {
                oK = DialogResult.OK;
            }
            else if ((this.msgBoxButtons == MessageBoxButtons.YesNo) || (this.msgBoxButtons == MessageBoxButtons.YesNoCancel))
            {
                oK = DialogResult.Yes;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                oK = DialogResult.Abort;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.RetryCancel)
            {
                oK = DialogResult.Retry;
            }
            base.DialogResult = oK;
        }

        private void vbutton2_Click(object sender, EventArgs e)
        {
            DialogResult cancel = DialogResult.Cancel;
            if (this.msgBoxButtons == MessageBoxButtons.OKCancel)
            {
                cancel = DialogResult.Cancel;
            }
            else if ((this.msgBoxButtons == MessageBoxButtons.YesNo) || (this.msgBoxButtons == MessageBoxButtons.YesNoCancel))
            {
                cancel = DialogResult.No;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                cancel = DialogResult.Retry;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.RetryCancel)
            {
                cancel = DialogResult.Cancel;
            }
            base.DialogResult = cancel;
        }

        private void vbutton3_Click(object sender, EventArgs e)
        {
            DialogResult cancel = DialogResult.Cancel;
            if (this.msgBoxButtons == MessageBoxButtons.AbortRetryIgnore)
            {
                cancel = DialogResult.Ignore;
            }
            else if (this.msgBoxButtons == MessageBoxButtons.YesNoCancel)
            {
                cancel = DialogResult.Cancel;
            }
            base.DialogResult = cancel;
        }

        #endregion

    }
}
