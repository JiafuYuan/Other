namespace VehicleTransportClient.UI
{
    partial class FrmQueryGIS
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelGis = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnPan = new System.Windows.Forms.ToolStripButton();
            this.btnAll = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.panelWorkArea.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.panel1);
            this.panelWorkArea.Size = new System.Drawing.Size(734, 570);
            // 
            // panelTitle
            // 
            this.panelTitle.Location = new System.Drawing.Point(59, 0);
            this.panelTitle.Size = new System.Drawing.Size(583, 28);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panelGis);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 570);
            this.panel1.TabIndex = 0;
            // 
            // panelGis
            // 
            this.panelGis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGis.Location = new System.Drawing.Point(11, 43);
            this.panelGis.Name = "panelGis";
            this.panelGis.Size = new System.Drawing.Size(712, 517);
            this.panelGis.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnPan,
            this.btnAll,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(734, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = global::VehicleTransportClient.Properties.Resources.zoomIn;
            this.btnZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(36, 37);
            this.btnZoomIn.Text = "放大";
            this.btnZoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = global::VehicleTransportClient.Properties.Resources.zoomOut;
            this.btnZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(36, 37);
            this.btnZoomOut.Text = "缩小";
            this.btnZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnPan
            // 
            this.btnPan.Image = global::VehicleTransportClient.Properties.Resources.move;
            this.btnPan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPan.Name = "btnPan";
            this.btnPan.Size = new System.Drawing.Size(36, 37);
            this.btnPan.Text = "拖动";
            this.btnPan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPan.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // btnAll
            // 
            this.btnAll.Image = global::VehicleTransportClient.Properties.Resources.Entire;
            this.btnAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(36, 37);
            this.btnAll.Text = "全图";
            this.btnAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::VehicleTransportClient.Properties.Resources.Refresh;
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(36, 37);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FrmQueryGIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 600);
            this.FormTitle = "地图";
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmQueryGIS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地图";
            this.Load += new System.EventHandler(this.FrmQueryGIS_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.ToolStripButton btnPan;
        private System.Windows.Forms.ToolStripButton btnAll;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel panelGis;

    }
}