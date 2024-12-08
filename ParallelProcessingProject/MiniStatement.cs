using Microsoft.Data.SqlClient;
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
    public partial class MiniStatement : Form
    {
        public MiniStatement()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");

        private void populateData()
        {
            try
            {
                AccNum.Text = UserSession.UserId.ToString();

                conn.Open();

                SqlCommand cmd = new SqlCommand("getAllTransactions", conn);//esm el procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", UserSession.UserId);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt.Columns.Count > 0)
                {
                    dt.Columns.RemoveAt(dt.Columns.Count - 1);
                }

                Ministgrid.DataSource = dt;

                Ministgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                Ministgrid.ReadOnly = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());


            }
            finally
            {
                conn.Close();

            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MiniStatement_Load(object sender, EventArgs e)
        {
            populateData();//method to fetch data from db and display it in a grid
        }

        private void button1_Click(object sender, EventArgs e)//back
        {
            SelectTransaction sc = new SelectTransaction();
            sc.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)//logout
        {

        }
    }
}
