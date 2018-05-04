using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Common
{
    public partial class frmBase : Form
    {
        #region 变量
        private EnumSkinStyle _skin;
        private bool _isMaxed = false;
        private bool _needMaxbt = true;  //是否需要最大化按钮
        private bool _needMinbt = true; //是否需要最小化按钮
        private bool _needIcon = true; //是否需要图标
        private bool _isShowTitle = true;
        //记录原始的用户设置的大小，用于最大化后返回正常的大小
        private int _orginWidth;
        private int _orginHeight;

        //记录窗体的位置
        private int _oldX;
        private int _oldY;


        //窗体的状态
        public enum EnumWindowState
        {
            Normal, Max, Min
        }
        private EnumWindowState _windowState = EnumWindowState.Normal;


        #endregion

        public delegate void WindowStateChangeDelegate(EnumWindowState windowState);
        public event WindowStateChangeDelegate OnWindowStateChanged;
        #region 属性
        public Image TitleBackGroundImage
        {
            get { return panelTop.BackgroundImage; }
            set { panelTop.BackgroundImage = value; }
        }

        public Image MenuStripMinMaxCloseImage
        {
            get { return menuStripMinMaxClose.BackgroundImage; }
            set { menuStripMinMaxClose.BackgroundImage = value; }
        }

        [Description("皮肤")]
        public EnumSkinStyle Skin
        {
            get
            {
                return _skin;
            }
            set
            {
                _skin = value;
                switch (_skin)
                {
                    case EnumSkinStyle.蓝色:
                        this.BackColor = Color.Blue;
                        this.panelTop.BackColor = Color.CornflowerBlue;
                        break;
                    case EnumSkinStyle.红色:
                        this.BackColor = Color.FromArgb(223,91,1);//Color.Red;
                        this.panelTop.BackColor = Color.Pink;
                        break;
                    default:
                        break;
                }
            }
        }

        ///// <summary>
        ///// 隐藏size属性,通过BorderWidth，BorderHeight设置
        ///// </summary>
        //[Browsable(true)]
        //public new SizeF Size
        //{
        //    get { return base.Size; }
        //}

        //[CategoryAttribute("QLFSkinDll"), Description("设置窗体宽度")]
        //public int BorderWidth
        //{
        //    get { return this.Width; }
        //    set
        //    {
        //        if (value < 180)
        //        {
        //            MessageBox.Show("宽度太小了，宽度最少是180个像素。");
        //            return;
        //        }
        //        if (this.Width != value)
        //        {
        //            int newwidth = value;
        //            this.Width = value;

        //            ptbml.Left = 0;
        //            ptbmr.Left = newwidth - 2;
        //            ptbtr.Left = newwidth - 10;
        //            ptbbr.Left = newwidth - 10;

        //            panelm.Width = newwidth - 4;
        //            panelb.Width = newwidth - 20;
        //            panelt.Width = newwidth - 20;

        //            btclose.Left = newwidth - 57;
        //            btmin.Left = newwidth - 120;
        //            btmax.Left = newwidth - 89;
        //            btres.Left = newwidth - 89;
        //        }

        //    }
        //}

        //[CategoryAttribute("QLFSkinDll"), Description("设置窗体高度")]
        //public int BorderHeight
        //{
        //    get { return this.Height; }
        //    set
        //    {
        //        if (this.Height != value)
        //        {
        //            int newheight = value;
        //            this.Height = value;

        //            panelm.Height = newheight - 68;
        //            ptbml.Height = newheight - 68;
        //            ptbmr.Height = newheight - 68;
        //            ptbml.Top = 31;
        //            ptbmr.Top = 31;

        //            panelb.Top = newheight - 37;
        //            ptbbl.Top = newheight - 37;
        //            ptbbr.Top = newheight - 37;
        //        }

        //    }
        //}

        [CategoryAttribute("QControls"), Description("设置窗体标题")]
        public string FormTitle
        {
            get { return lbtitle.Text;
            }
            set { lbtitle.Text = value;
            this.Text = lbtitle.Text;
            }
        }

        [CategoryAttribute("QControls"), Description("是否需要最大化按钮")]
        public bool NeedMax
        {
            get { return _needMaxbt; }
            set
            {
                _needMaxbt = value;
                if (value == false)
                {
                   // this.btmax.Top = -50;
                   // this.btmin.Left = this.Width - 89;
                    pictureBoxMax.Visible = false;
                }
                else
                {
                    //this.btmax.Top = 0;
                    //this.btmin.Left = this.Width - 120;
                    pictureBoxMax.Visible = true;
                }
            }
        }

        [CategoryAttribute("QControls"), Description("是否需要最小化按钮")]
        public bool NeedMix
        {
            get { return _needMinbt; }
            set
            {
                _needMinbt = value;
                if (value == false)
                {
                    //this.btmin.Top = -50;
                    pictureBoxMin.Visible = false;
                }
                else
                {
                    //this.btmin.Top = 0;
                    pictureBoxMin.Visible = true;
                }
            }
        }

        [CategoryAttribute("QControls"), Description("是否需要图标")]
        public bool NeedIcon
        {
            get { return _needIcon; }
            set
            {
                _needIcon = value;
                if (value == false)
                {
                    pictureBoxIcon.Visible = false;
                }
                else
                {
                    pictureBoxIcon.Visible = true;
                }
            }
        }


        [CategoryAttribute("QControls"), Description("是否自动大小")]
        public bool PanelAutoSize
        {
            get { return panelMain.AutoSize; }
            set
            {
                panelMain.AutoSize = value;
                //_needMinbt = value;
                //if (value == false)
                //{
                //    //this.btmin.Top = -50;
                //    pictureBoxMin.Visible = false;
                //}
                //else
                //{
                //    //this.btmin.Top = 0;
                //    pictureBoxMin.Visible = true;
                //}
            }
        }


       // public new Icon Icon { get { return base.Icon; } set { base.Icon = value;        } }

        /// <summary>
        /// 图标
        /// </summary>
        public Image IconImage
        {
            get
            {
                return pictureBoxIcon.Image;
        } set { pictureBoxIcon.Image = value; } }

        /// <summary>
        /// 是否显示标题
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsShowTitle
        {
            get { return _isShowTitle; }
            set
            {
                _isShowTitle = value;
                panelTop.Visible = value;
                if (_isShowTitle == false)
                {
                    this.Padding = new Padding(0, 0, 0, 0);
                }
                else
                {
                    this.Padding = new Padding(1,1,1,1);
                }
            }
        }

        #endregion

        #region 内部方法
    



        [DllImport("User32.dll")]
        private static extern IntPtr SetWindowLong(IntPtr hwnd, IntPtr nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowLong(IntPtr hwnd, IntPtr nIndex);
        private void ShowSystemMenu()
        {
           // if (_FormStyle == emFormStyle.WindowDefault) return;

            const long GWL_STYLE = (-16);
            const long WS_SYSMENU = 0x80000;    //带系统菜单的窗口
            const long WS_CAPTION = 0xC00000;   //带标题栏的窗口
            const long WS_MINIMIZEBOX = 0x20000;//最小化
            const long WS_MAXIMIZEBOX = 0x10000;//最大化


            //初始化部分
            IntPtr lStyle = GetWindowLong(this.Handle, (IntPtr)GWL_STYLE);
          //  long l = ((long)lStyle | WS_SYSMENU | WS_MINIMIZEBOX | WS_MAXIMIZEBOX) & ~WS_CAPTION;
            long l = ((long)lStyle | WS_SYSMENU | WS_MINIMIZEBOX ) & ~WS_CAPTION;

            lStyle = (IntPtr)l;
            SetWindowLong(this.Handle, (IntPtr)GWL_STYLE, lStyle);
            EnabledSysMenu(false);
        }


        const int MF_BYCOMMAND = 0x400; //
        const int MF_BYPOSITION = 0x00; //
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_CLOSE = 0xF060;
        const int MF_ENABLED = 0x00;
        const int MF_GRAYED = 0x01;
        const int MF_DISABLED = 0x02;
        [DllImport("USER32.DLL")]
        private static extern int GetSystemMenu(int hwnd, int bRevert);
        [DllImport("USER32.DLL")]
        private static extern int RemoveMenu(int hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(int hMenu, int wIDEnableItem, int wEnable);

        private void EnabledSysMenu(bool isEnabled)
        {
            int iSysMenu;
            iSysMenu = GetSystemMenu(this.Handle.ToInt32(), 0);
            //EnableMenuItem(iSysMenu, SC_MAXIMIZE, (isEnabled ? MF_ENABLED : MF_GRAYED | MF_DISABLED) | MF_BYPOSITION);
         //   RemoveMenu(iSysMenu, SC_MAXIMIZE, 0);
            RemoveMenu(iSysMenu, SC_MAXIMIZE, 1);//移除最大化的
           
        }

        #endregion

        public frmBase()
        {
            InitializeComponent();
            this.panelTitle.MouseEnter += new EventHandler(panelTitle_MouseEnter);
            this.panelTitle.MouseLeave += new EventHandler(panelTitle_MouseLeave);
            this.panelTitle.MouseDown += new MouseEventHandler(panelTitle_MouseDown);
            ShowSystemMenu();
        }


        public void FormMaxed()
        {
            pictureBoxMax_Click(null, null);
        }

        #region 事件
       



        /// <summary>最大化</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxMax_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (!_isMaxed)
            {
                //最大化之前记录窗口信息便于缩小
                _orginHeight = this.Height;
                _orginWidth = this.Width;
                _oldX = this.Location.X;
                _oldY = this.Location.Y;

                this.Top = 0;
                this.Left = 0;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;

                _windowState = EnumWindowState.Max;
                _isMaxed = true;
            }
            else
            {
                this.Left = _oldX;
                this.Top = _oldY;
                this.Width = _orginWidth;
                this.Height = _orginHeight;
                _windowState = EnumWindowState.Normal;
                _isMaxed = false;
            }
            this.Visible = true;
            if (OnWindowStateChanged!=null)
            {
                OnWindowStateChanged(_windowState);
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //this.Close();
            if (MessageBoxEx.MessageBoxEx.Show("是否退出系统？", "提示", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

       

        private void pictureBoxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (_windowState != EnumWindowState.Max)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Common.Win32.ReleaseCapture();
                    Common.Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
            }
            if (e.Clicks == 2)
            {
                if (this.NeedMax==true)
                {
                    pictureBoxMax_Click(sender, e);    
                }
            }
        }

        void panelTitle_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        void panelTitle_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }


        #endregion

        public enum EnumSkinStyle
        {
            蓝色,
            红色
        }

        private void panelWorkArea_Paint(object sender, PaintEventArgs e)
        {
            //try
            //{
            //    Rectangle r = new Rectangle(0, 0, this.panelWorkArea.Height, this.panelWorkArea.Width);
            //   // Rectangle r = new Rectangle(0, 0, this.Height, this.Width);
            //    LinearGradientBrush brush = new LinearGradientBrush(r, System.Drawing.SystemColors.Control , Color.White, LinearGradientMode.Vertical);
            //    e.Graphics.FillRectangle(brush, r);
            //}
            //catch (Exception)
            //{

            //}
            try
            {
                Rectangle r = new Rectangle(panelWorkArea.Left, 0, panelWorkArea.Width, panelWorkArea.Height);
                LinearGradientBrush brush = new LinearGradientBrush(r, Color.FromArgb(175, 210, 255), Color.White, LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
            catch (Exception)
            {
                
                
            }
        }

     
    }

}
