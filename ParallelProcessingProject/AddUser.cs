using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelProcessingProject
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }
        private int roleid = 0;

        string hashedpassword;
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");
        private string HashPassword(string password)
        {

           string passwordhash= BCrypt.Net.BCrypt.EnhancedHashPassword(password,13);
            return passwordhash;
        }
        private bool checkDuplicateUserName(string userName)
        {
            try
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("checkDuplicateUsername", conn);//esm el procedure
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.Parameters.AddWithValue("@username", username.Text);

                int count = (int)cmdd.ExecuteScalar();//returning a single value zy el count wa el min wa el max
                return count > 0;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
                return true;

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//create user
        {

            if (string.IsNullOrWhiteSpace(username.Text))
            {
                // usernameerr.Visible = true;

                usernameerr.Text = "Please enter a Username";
            }
            else
            {
                try
                {
                    if (checkDuplicateUserName(username.Text))
                    {

                        usernameerr.Text = "Username already taken please choose another";

                    }
                    else
                    {
                        usernameerr.Visible = false;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
            if (string.IsNullOrWhiteSpace(pin.Text))
            {
                // pinerr.Visible = true;

                pinerr.Text = "Please enter a PIN";
            }
            else if (!int.TryParse(pin.Text, out int pinNumber))
            {
                pinerr.Visible = true;
                pinerr.Text = "PIN must be a numeric value.";
            }
            else if (pin.Text.Length != 4)
            {
                pinerr.Visible = true;
                pinerr.Text = "PIN must be exactly 4 digits.";
            }

            else
            {
                 hashedpassword=HashPassword(pin.Text); 

                pinerr.Visible = false;

            }
            if (string.IsNullOrWhiteSpace(balance.Text))
            {
                // balanceerr.Visible = true;

                balanceerr.Text = "Please enter Balance";

            }
            else if (!decimal.TryParse(balance.Text, out decimal balanceValue))
            {
                balanceerr.Visible = true;
                balanceerr.Text = "Balance must be a valid number.";
            }
            else if (balanceValue <= 0)
            {
                balanceerr.Visible = true;
                balanceerr.Text = "Balance must be greater than 0.";
            }

            else
            {
                balanceerr.Visible = false;

            }
            if (role.SelectedIndex == -1)
            {
                //roleerr.Visible = true;

                roleerr.Text = "Please select a Role";
            }
            else
            {
                roleerr.Visible = false;

            }
            if (!string.IsNullOrWhiteSpace(username.Text) &&
                       !string.IsNullOrWhiteSpace(pin.Text) &&
                         !string.IsNullOrWhiteSpace(balance.Text) &&
                                        role.SelectedIndex != -1)
            {
                //enetered both check ba2a credentials
                try
                {
                    conn.Open();

                    //@username nvarchar(50),@password nvarchar(255),@balance decimal (18,2),@role int
                    SqlCommand cmd = new SqlCommand("adduser", conn);//esm el procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", hashedpassword);
                    cmd.Parameters.AddWithValue("@balance", balance.Text);
                    if (role.SelectedItem.ToString() == "Admin")
                        roleid = 1;
                    else
                        roleid = 2;

                    cmd.Parameters.AddWithValue("@role", roleid);

                    int rowsAffected = cmd.ExecuteNonQuery();//te3ml execute lel query w aterga3 el rows ely affected

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No rows affected. The user was not added.");
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l=new Login();
            l.Show();
            Visible = false;
        }
    }
}
