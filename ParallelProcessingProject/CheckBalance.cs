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
    public partial class CheckBalance : Form
    {
        public CheckBalance()
        {
            InitializeComponent();
        }
        /// <summary>
        /// It executes the stored procedure getBalanceById to retrieve the balance of the user 
        /// based on the provided id. If the balance is found, it is returned as a decimal value.
        /// </summary>
        /// <param name="id">signed in user id</param>
        /// <returns>Current Balance of User</returns>
        public async Task<decimal> getBalanceFromDb(int id)
        {
            decimal balance = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("getBalanceById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        var result = await cmd.ExecuteScalarAsync();
                        if (result != DBNull.Value)
                        {
                            balance = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return balance;
            
        }


        private async void CheckBalance_Load(object sender, EventArgs e)
        {

            if (UserSession.UserId != 0 && UserSession.UserName != null)
            {
                AccNum.Text = UserSession.UserId.ToString();
                var result = await getBalanceFromDb((UserSession.UserId));
                balance.Text = result.ToString();
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

        private void button2_Click(object sender, EventArgs e)//logout
        {
            Login l = new Login();
            l.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)//back
        {
            SelectTransaction sc = new SelectTransaction();
            sc.Show();
            Visible = false;
        }
    }
}
