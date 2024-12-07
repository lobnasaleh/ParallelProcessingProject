using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelProcessingProject
{
    public partial class CheckBalance : Form
    {
        public CheckBalance()
        {
            InitializeComponent();
        }

        private void CheckBalance_Load(object sender, EventArgs e)
        {
            if (UserSession.UserId!=0 && UserSession.UserName != null)
            {
                AccNum.Text = UserSession.UserId.ToString();
                balance.Text = UserSession.Balance.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
