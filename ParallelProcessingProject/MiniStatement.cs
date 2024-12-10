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
       // SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");

        private async Task populateData()
        {

            if (UserSession.UserId == null)
            {
                MessageBox.Show("Invalid User ID. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                AccNum.Text = UserSession.UserId.ToString();
                DataTable dt = new DataTable();


                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True"))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("getAllTransactions", conn))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", UserSession.UserId);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            // Load the data from the reader into the DataTable
                            dt.Load(reader);
                        }
                    }
                    
                }

                    if (dt.Columns.Count > 0)
                    {//remove rolecolumn
                        dt.Columns.RemoveAt(dt.Columns.Count - 1);
                    }

                // 3ndy masln background thread rahet tgeeb el data men el data base fa mesh 3yzaha hya ely te3ml update lel
                // ui 3yza el main thread hya ely te3ml update to ensure that ui updates happen on the main thread 
                //when a background thread went to get data from db and then returned
                //i want it to tell the ui thread to update rather than updating it directly itself
                Ministgrid.Invoke((Action)(() =>
                {
                    Ministgrid.DataSource = dt;
                    Ministgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    Ministgrid.ReadOnly = true;
                    Ministgrid.ClearSelection(); // Optional: clear any default selection
                }));

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());


            }//no need for finally l2enny estakhdemt using {}
         
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

        private async void MiniStatement_Load(object sender, EventArgs e)
        {
            await populateData();//method to fetch data from db and display it in a grid
        }

        private void button1_Click(object sender, EventArgs e)//back
        {
            SelectTransaction sc = new SelectTransaction();
            sc.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)//logout
        {
            Login l = new Login();
            l.Show();
            Visible = false;
        }
    }
}
