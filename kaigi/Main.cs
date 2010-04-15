using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;

namespace kaigi
{
    public partial class mainForm : Form
    {
        private float totalCost = 0;

        private Members members;

        private void loadConfig() 
        {
            NameValueCollection appConfig = ConfigurationManager.AppSettings;
            members = new Members();
            members.load();
        }

        public mainForm()
        {
            InitializeComponent();
            loadConfig();
            suspendButton.Enabled = false;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            mainLabel.Text = "\\0";
            totalCost = 0;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            startButton.Text = "çƒäJ";
            suspendButton.Enabled = true;
            startButton.Enabled = false;
            resetButton.Enabled = false;
        }

        private void suspendButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            suspendButton.Enabled = false;
            startButton.Enabled = true;
            resetButton.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            totalCost = totalCost + members.getTotalFee();
            String cost = String.Format("{0:C}", (long)totalCost);
            mainLabel.Text = cost;
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            ConfigDialog dlg = new ConfigDialog();
            dlg.setMembers(members);
            dlg.ShowDialog();
        }
    }
}