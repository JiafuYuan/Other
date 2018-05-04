using System;
using System.Windows.Forms;
using Laura.Compute;

namespace Laura.Calculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            Button currentButton = sender as Button;
            if (currentButton != null && currentButton.Tag != null)
            {
                string input = currentButton.Tag.ToString();
                txtExpress.Text = txtExpress.Text + input;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string express = txtExpress.Text ?? string.Empty;
            if (!string.IsNullOrEmpty(express))
            {
                txtExpress.Text = express.Substring(0, express.Length - 1);
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string express = txtExpress.Text ?? string.Empty;
            if (string.IsNullOrEmpty(express) || string.IsNullOrEmpty(express.Trim()))
            {
                txtResult.Text = "ERROR:INPUT THE EXPRESS!";
            }
            else
            {
                try
                {
                    object result = ComputeHelper.Compute(txtExpress.Text);
                    txtResult.Text = (result ?? string.Empty).ToString();
                }
                catch(Exception exp)
                {
                    txtResult.Text = "ERROR:" + exp.Message;
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtExpress.Text = txtResult.Text = string.Empty;
        }

        private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}
