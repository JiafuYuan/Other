namespace VehicleTransportClient.UI
{
    partial class FormQueryDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQueryDetail));
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Size = new System.Drawing.Size(725, 547);
            this.panelWorkArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelWorkArea_Paint);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(568, 28);
            // 
            // FormQueryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 577);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormQueryDetail";
            this.Text = "FormQueryDetail";
            this.ResumeLayout(false);

        }

        #endregion


    }
}