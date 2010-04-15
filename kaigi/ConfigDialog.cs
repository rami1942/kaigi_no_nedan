using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace kaigi
{
    public partial class ConfigDialog : Form
    {
        public Members members;

        public Label[] labels;
        public NumericUpDown[] ud;

        public bool isOk;

        public ConfigDialog()
        {
            InitializeComponent();
            labels = new Label[10];
            ud = new NumericUpDown[10];

            labels[0] = rank1Label; ud[0] = number1;
            labels[1] = rank2Label; ud[1] = number2;
            labels[2] = rank3Label; ud[2] = number3;
            labels[3] = rank4Label; ud[3] = number4;
            labels[4] = rank5Label; ud[4] = number5;
            labels[5] = rank6Label; ud[5] = number6;
            labels[6] = rank7Label; ud[6] = number7;
            labels[7] = rank8Label; ud[7] = number8;
            labels[8] = rank9Label; ud[8] = number9;
            labels[9] = rank10Label; ud[9] = number10;

            isOk = false;

        }

        public void setMembers(Members members)
        {
            this.members = members;
            for (int i = 0; i < 10; i++)
            {
                labels[i].Text = members.member[i].title;
                if (members.member[i].title.Trim().Equals(""))
                {
                    ud[i].Hide();
                }
                else
                {
                    ud[i].Show();
                }

                ud[i].Value = members.member[i].member;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            isOk = true;

            for (int i = 0; i < 10; i++)
            {
                members.member[i].member = Decimal.ToInt32(ud[i].Value);
            }

            this.Close();
        }
    }
}