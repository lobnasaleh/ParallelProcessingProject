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
    public partial class SelectTransaction : Form
    {
        public SelectTransaction()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)//withdraw
        {
            Withdrawal wd= new Withdrawal();
            wd.Show();
            Visible=false;
        }

        private void button2_Click(object sender, EventArgs e)//deposit
        {
            Deposit d=new Deposit();
            d.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MiniStatement ms = new MiniStatement();
            ms.Show();
            Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//logout
        {
            Login l = new Login();
            l.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)//check balance
        {
            CheckBalance cb = new CheckBalance();
            cb.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePIN cp = new ChangePIN();
            cp.Show();
            Visible = false;
        }

        private void SelectTransaction_Load(object sender, EventArgs e)
        {

        }
    }
}
