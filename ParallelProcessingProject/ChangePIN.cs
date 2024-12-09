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
    public partial class ChangePIN : Form
    {

        public ChangePIN()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");
        string hashedpassword;

        private void button2_Click(object sender, EventArgs e)
        {
            SelectTransaction sc = new SelectTransaction();
            sc.Show();
            Visible = false;
        }
        private string HashPassword(string password)
        {

            string passwordhash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
            return passwordhash;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // confirmerr.Visible = false;
            if (string.IsNullOrWhiteSpace(pin.Text) || string.IsNullOrWhiteSpace(confirmpin.Text))
            {
                confirmerr.Text = "Please enter both PIN and Confrirming PIN";

            }
           else if(pin.Text!= confirmpin.Text)
            {
                confirmerr.Text = " PIN and Confrirming PIN are different";

            }
            else
            {
                confirmerr.Visible = false;
                //enetered both check ba2a credentials
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("updatePIN", conn);//esm el procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", UserSession.UserId);
                    //hashpassword first
                    hashedpassword = HashPassword(confirmpin.Text);

                    cmd.Parameters.AddWithValue("@pin", hashedpassword);

                    int rowsAffected = cmd.ExecuteNonQuery();//te3ml execute lel query w aterga3 el rows ely affected


                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("PIN updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("PIN did not change ,Try again!");
                    }

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



        }
    }
            
        }
 