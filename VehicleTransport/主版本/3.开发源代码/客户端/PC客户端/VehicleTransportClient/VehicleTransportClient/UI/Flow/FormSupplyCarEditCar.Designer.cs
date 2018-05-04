namespace VehicleTransportClient.UI
{
    partial class FormSupplyCarEditCar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSupplyCarEditCar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtnumber = new DevComponents.Editors.IntegerInput();
            this.txtCarType = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonEx3 = new Common.ButtonEx();
            this.btnok = new Common.ButtonEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumber)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.panel1);
            this.panelWorkArea.Size = new System.Drawing.Size(348, 200);
            // 
            // panelTitle
            // 
            this.panelTitle.Location = new System.Drawing.Point(59, 0);
            this.panelTitle.Size = new System.Drawing.Size(197, 28);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtnumber);
            this.panel1.Controls.Add(this.txtCarType);
            this.panel1.Controls.Add(this.buttonEx3);
            this.panel1.Controls.Add(this.btnok);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 200);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(278, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 110;
            this.label3.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(278, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 109;
            this.label10.Text = "*";
            // 
            // txtnumber
            // 
            // 
            // 
            // 
            this.txtnumber.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtnumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtnumber.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtnumber.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.txtnumber.Location = new System.Drawing.Point(124, 74);
            this.txtnumber.MaxValue = 99999;
            this.txtnumber.MinValue = 0;
            this.txtnumber.Name = "txtnumber";
            this.txtnumber.Size = new System.Drawing.Size(148, 21);
            this.txtnumber.TabIndex = 108;
            // 
            // txtCarType
            // 
            // 
            // 
            // 
            this.txtCarType.Border.Class = "TextBoxBorder";
            this.txtCarType.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCarType.Location = new System.Drawing.Point(124, 33);
            this.txtCarType.MaxLength = 50;
            this.txtCarType.Name = "txtCarType";
            this.txtCarType.Size = new System.Drawing.Size(148, 21);
            this.txtCarType.TabIndex = 107;
            this.txtCarType.Click += new System.EventHandler(this.txtCarType_Click);
            // 
            // buttonEx3
            // 
            this.buttonEx3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEx3.BackgroundImage")));
            this.buttonEx3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEx3.BorderColor = System.Drawing.Color.Empty;
            this.buttonEx3.ButtonStyle = Common.ButtonStyle.Custom1;
            this.buttonEx3.EnabledEx = false;
            this.buttonEx3.FlatAppearance.BorderSize = 0;
            this.buttonEx3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx3.Location = new System.Drawing.Point(197, 144);
            this.buttonEx3.Name = "buttonEx3";
            this.buttonEx3.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("buttonEx3.Picture_MouseDown")));
            this.buttonEx3.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("buttonEx3.Picture_MouseMove")));
            this.buttonEx3.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("buttonEx3.Picture_Normal")));
            this.buttonEx3.Size = new System.Drawing.Size(75, 23);
            this.buttonEx3.TabIndex = 106;
            this.buttonEx3.Text = "取消";
            this.buttonEx3.UseVisualStyleBackColor = true;
            this.buttonEx3.Click += new System.EventHandler(this.buttonEx3_Click);
            // 
            // btnok
            // 
            this.btnok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnok.BackgroundImage")));
            this.btnok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnok.BorderColor = System.Drawing.Color.Empty;
            this.btnok.ButtonStyle = Common.ButtonStyle.Custom1;
            this.btnok.EnabledEx = false;
            this.btnok.FlatAppearance.BorderSize = 0;
            this.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnok.Location = new System.Drawing.Point(61, 144);
            this.btnok.Name = "btnok";
            this.btnok.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("btnok.Picture_MouseDown")));
            this.btnok.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("btnok.Picture_MouseMove")));
            this.btnok.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("btnok.Picture_Normal")));
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 105;
            this.btnok.Text = "保存";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(59, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 104;
            this.label1.Text = "车辆数量:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(59, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 103;
            this.label2.Text = "车辆类型:";
            // 
            // FormSupplyCarEditCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 230);
            this.FormTitle = "供车";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormSupplyCarEditCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "供车";
            this.Load += new System.EventHandler(this.FormSupplyCarEditCar_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private DevComponents.Editors.IntegerInput txtnumber;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCarType;
        private Common.ButtonEx buttonEx3;
        private Common.ButtonEx btnok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}