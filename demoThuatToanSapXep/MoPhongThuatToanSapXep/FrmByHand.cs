using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingAlgorithmsGUI
{
    public partial class Form1 : Form
    {
        private string _message;
        public Form1()
        {
            InitializeComponent();
/*            pt1.Hide();
            pt2.Hide();
            pt3.Hide();
            pt4.Hide();
            pt5.Hide();
            pt6.Hide();
            pt7.Hide();
            pt8.Hide();
            pt9.Hide();
            pt10.Hide();*/
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        Label[] lb;
        private void frmByHand_Load(object sender, EventArgs e)
        {
            string k = _message;
            int n = Int32.Parse(k);
            lb = new Label[n];
            int h = 0;
            for (int i = 0; i < n; i++)
            {
                Label lbl = new Label();
                lbl.AutoSize = false;
                lbl.Size = new Size(113, 36);
                lbl.BorderStyle = BorderStyle.None;
                lbl.ForeColor = Color.Black;
                lbl.Font = new Font("Times New Roman", 16);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = "";
                if (i % 2 == 0)
                {
                    lbl.Location = new Point(12, 39 * h + 13);
                }
                else
                {
                    lbl.Location = new Point(200, 39 * h + 13);
                    h++;
                }


                Controls.Add(lbl);
                lb[i] = lbl;
                switch (i + 1)
                {
                    case 1: pt1.Show(); break;
                    case 2: pt2.Show(); break;
                    case 3: pt3.Show(); break;
                    case 4: pt4.Show(); break;
                    case 5: pt5.Show(); break;
                    case 6: pt6.Show(); break;
                    case 7: pt7.Show(); break;
                    case 8: pt8.Show(); break;
                    case 9: pt9.Show(); break;
                    case 10: pt10.Show(); break;
                    case 11: pt11.Show(); break;
                    case 12: pt12.Show(); break;
                    case 13: pt13.Show(); break;
                    case 14: pt14.Show(); break;
                    case 15: pt15.Show(); break;
                }
            }
        }
        private void btApply_Click(object sender, EventArgs e)
        {
            frmApplication.PT1 = pt1.Text;
            frmApplication.PT2 = pt2.Text;
            frmApplication.PT3 = pt3.Text;
            frmApplication.PT4 = pt4.Text;
            frmApplication.PT5 = pt5.Text;
            frmApplication.PT6 = pt6.Text;
            frmApplication.PT7 = pt7.Text;
            frmApplication.PT8 = pt8.Text;
            frmApplication.PT9 = pt9.Text;
            frmApplication.PT10 = pt10.Text;
            frmApplication.PT11 = pt11.Text;
            frmApplication.PT12 = pt12.Text;
            frmApplication.PT13 = pt13.Text;
            frmApplication.PT14 = pt14.Text;
            frmApplication.PT15 = pt15.Text;

            MessageBox.Show("OK", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void bntBack_Click(object sender, EventArgs e)
        {
            string tempt = "0";
            frmApplication.PT1 = tempt;
            frmApplication.PT2 = tempt;
            frmApplication.PT3 = tempt;
            frmApplication.PT4 = tempt;
            frmApplication.PT5 = tempt;
            frmApplication.PT6 = tempt;
            frmApplication.PT7 = tempt;
            frmApplication.PT8 = tempt;
            frmApplication.PT9 = tempt;
            frmApplication.PT10 = tempt;
            frmApplication.PT11 = tempt;
            frmApplication.PT12 = tempt;
            frmApplication.PT13 = tempt;
            frmApplication.PT14 = tempt;
            frmApplication.PT15 = tempt;
            this.Dispose();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                bntBack.PerformClick();
                return true;
            }
            else if (keyData == Keys.Enter)
            {
                btApply.PerformClick();
                return true;
            }
            else return false;
        }

        private void pt1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pt3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
