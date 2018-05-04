using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace Common
{
    public enum ButtonStyle
    {
        System=0,
        Custom1=1,
        Custom2 = 2
    }
    public class ButtonEx:System.Windows.Forms.Button
    {
        public ButtonEx()
        {
            m_FlatStyle = base.FlatStyle;
            m_BorderSize = base.FlatAppearance.BorderSize;
            m_BackgroundImageLayout = base.BackgroundImageLayout;
            m_BackgroundImage = base.BackgroundImage;
            
            this.Picture_Normal = global::Common.Properties.Resources.button_normal;
            this.Picture_MouseDown = global::Common.Properties.Resources.button_mousedown;
            this.Picture_MouseMove = global::Common.Properties.Resources.button_mousemove;
            this.ButtonStyle = ButtonStyle.Custom1;
        }

        #region 变量
        private int m_BorderSize;
        private System.Windows.Forms.FlatStyle m_FlatStyle;
        private System.Windows.Forms.ImageLayout m_BackgroundImageLayout;
        private System.Drawing.Image m_BackgroundImage;

        private ButtonStyle _buttonStyle = ButtonStyle.System;
        private System.Drawing.Image _picture_Normal;
        #endregion

        #region 自定属性
        [DefaultValue(System.Windows.Forms.FlatStyle.Standard), Category("外观"), Description("按钮样式"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
        public ButtonStyle ButtonStyle
        {
            get { return _buttonStyle; }
            set
            {
                switch (value)
                {
                    case ButtonStyle.Custom1:
                        base.FlatAppearance.BorderSize = 0;
                        base.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        if (this.Picture_Normal != null) base.BackgroundImage = this.Picture_Normal;
                        break;
                    case ButtonStyle.Custom2:
                        base.FlatAppearance.BorderSize = 0;
                        base.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        if (this.Picture_Normal != null) base.BackgroundImage = this.Picture_Normal;
                        break;
                    case ButtonStyle.System:
                    default:
                        base.FlatAppearance.BorderSize = m_BorderSize;
                        base.FlatStyle = m_FlatStyle;
                        base.BackgroundImageLayout = m_BackgroundImageLayout;
                        base.BackgroundImage = m_BackgroundImage;
                        break;
                }
                _buttonStyle = value;
            }
        }

        [DefaultValue(null), Category("外观"), Description("正常图片"), /*DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),*/ Browsable(true)]
        public System.Drawing.Image Picture_Normal
        {
            get { return _picture_Normal; }
            set
            {
                _picture_Normal = value;
                if (_buttonStyle == ButtonStyle.Custom1)
                {
                    base.BackgroundImage = value;
                }
            }
        }

        [DefaultValue(null), Category("外观"), Description("鼠标移上时图片"),/* DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),*/ Browsable(true)]
        public System.Drawing.Image Picture_MouseMove { get; set; }
        
        [DefaultValue(null), Category("外观"), Description("鼠标按下时图片"), /*DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),*/ Browsable(true)]
        public System.Drawing.Image Picture_MouseDown { get; set; }

        [DefaultValue(null), Category("外观"), Description("边框颜色"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
        public Color BorderColor { get { return this.FlatAppearance.BorderColor; } set { this.FlatAppearance.BorderColor = value; } }
        #endregion

        #region 重写属性

        public  bool EnabledEx { get; set; }
        public override System.Windows.Forms.ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                if (_buttonStyle == ButtonStyle.Custom1)
                {
                    m_BackgroundImageLayout = value;
                }
                else base.BackgroundImageLayout = value;
            }
        }
        public override System.Drawing.Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                if (_buttonStyle == ButtonStyle.Custom1)
                {
                    m_BackgroundImage = value;
                }
                else base.BackgroundImage = value;
            }
        }
        #endregion 

        #region 重写事件
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
        {
            if (_buttonStyle == ButtonStyle.Custom1 && this.Picture_MouseDown!=null) base.BackgroundImage = this.Picture_MouseDown;
            base.OnMouseDown(mevent);
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs mevent)
        {
            if (_buttonStyle == ButtonStyle.Custom1 && this.Picture_MouseMove!=null) base.BackgroundImage = this.Picture_MouseMove;
            base.OnMouseUp(mevent);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (_buttonStyle == ButtonStyle.Custom1 && this.Picture_MouseMove != null)
            {
                base.BackgroundImage = this.Picture_MouseMove;
            }

            if (_buttonStyle == ButtonStyle.Custom2 && this.Picture_MouseMove != null)
            {
                this.FlatAppearance.BorderSize = 1;
                base.BackgroundImage = this.Picture_MouseMove;
            }

            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (_buttonStyle == ButtonStyle.Custom1 && this.Picture_Normal != null)
            {
                base.BackgroundImage = this.Picture_Normal;
            }
            if (_buttonStyle == ButtonStyle.Custom2 && this.Picture_Normal != null)
            {
                base.BackgroundImage = this.Picture_Normal;
                this.FlatAppearance.BorderSize = 0;
            }
            base.OnMouseLeave(e);
        }
        #endregion
    }
}
