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
    public partial class Login : Form
    {
        private readonly int threadNumber;
        public Login(int threadNumber)
        {
            InitializeComponent();
            this.threadNumber = threadNumber;

        }

        public Login()
        {
            InitializeComponent();
           

        }

        //SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");
        private bool CheckHash(string passwordenetred, string dbpassword)
        {

            bool isequal = BCrypt.Net.BCrypt.EnhancedVerify(passwordenetred, dbpassword);
            return isequal;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {


        }

        private async Task AuthenticateUserAsync(string userId, string password)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True"))
            {
                await conn.OpenAsync();

                SqlCommand cmd = new SqlCommand("checkUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", userId);

                // Use SqlDataReader asynchronously
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync()) // Read the first row of data
                    {
                        string dbPassword = reader.GetString(2); // password is in the 3rd column
                        bool isPasswordValid = CheckHash(password, dbPassword);

                        if (isPasswordValid)
                        {
                            int roleId = reader.GetInt32(4); //  RoleId is in the 5th column
                            if (roleId == 1) // admin
                            {
                                UserSession.UserId = reader.GetInt32(0); // userId is in the 1st column
                                UserSession.UserName = reader.GetString(1); // userName is in the 2nd column
                                AddUser u = new AddUser();
                                u.Show();
                                Visible = false;
                            }
                            else //user
                            {
                                SelectTransaction sc = new SelectTransaction();
                                sc.Show();
                                Visible = false;
                                UserSession.UserId = reader.GetInt32(0);
                                UserSession.Balance = reader.GetDecimal(3); // balance is in the 4th column
                                UserSession.UserName = reader.GetString(1);
                            }
                        }
                        else
                        {
                            Invalid.Text = "Please enter Valid Credentials";
                            checkpassword.Visible = false;
                            checkId.Visible = false;
                            Id.Text = "";
                            Password.Text = "";
                        }
                    }
                    else
                    {
                        Invalid.Text = "Please enter Valid Credentials";
                        checkpassword.Visible = false;
                        checkId.Visible = false;
                        Id.Text = "";
                        Password.Text = "";
                    }
                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Id.Text) && string.IsNullOrWhiteSpace(Password.Text))
            {
                checkId.Text = "Please enter your Id";
                checkpassword.Text = "Please enter your Password";
                checkpassword.Visible = true;
                checkId.Visible = true;

            }
            else if (string.IsNullOrWhiteSpace(Id.Text) && !string.IsNullOrWhiteSpace(Password.Text))
            {
                checkId.Text = "Please enter your Id";
                checkpassword.Visible = false;
                checkId.Visible = true;

            }
            else if (!string.IsNullOrWhiteSpace(Id.Text) && string.IsNullOrWhiteSpace(Password.Text))
            {

                checkpassword.Text = "Please enter your Password";
                checkpassword.Visible = true;
                checkId.Visible = false;


            }
            else
            {
                //enetered both check ba2a credentials
                try
                {
                    await AuthenticateUserAsync(Id.Text, Password.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Invalid.Visible = true;

                }
            
            }


        }

        private void Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)//X
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
