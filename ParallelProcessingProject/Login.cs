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
        public Login()
        {
            InitializeComponent();
           
        }

        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");
        private bool CheckHash(string passwordenetred,string dbpassword)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Id.Text)  && string.IsNullOrWhiteSpace(Password.Text))
            {
                checkId.Text = "Please enter your Id";
                checkpassword.Text = "Please enter your Password";
                checkpassword.Visible = true;
                checkId.Visible = true;

            }
            else if (string.IsNullOrWhiteSpace(Id.Text ) && !string.IsNullOrWhiteSpace(Password.Text) )
            {
                checkId.Text = "Please enter your Id";
                   checkpassword.Visible = false;
                   checkId.Visible=true;
                
            }
            else if (!string.IsNullOrWhiteSpace(Id.Text ) && string.IsNullOrWhiteSpace(Password.Text ))
            {

                checkpassword.Text = "Please enter your Password";
                checkpassword.Visible = true;
                checkId.Visible=false;


            }
            else
            {
                //enetered both check ba2a credentials
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("checkUser", conn);//esm el procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", Id.Text);
                      // sheltha men el query  cmd.Parameters.AddWithValue("@password", Password.Text);
                    
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);//fill tabel with result of query
                    if (dt.Rows.Count > 0)
                    { //he found Id of User/Admin 

                        string dbpassword= dt.Rows[0][2].ToString();

                        bool ispasswordvalid=CheckHash(Password.Text, dbpassword);

                        if (ispasswordvalid) {
                            int RoleId = Convert.ToInt32(dt.Rows[0][4]);//4 representing the index of roleid in database as a column
                            if (RoleId == 1)//admin
                            {
                                UserSession.UserId = Convert.ToInt32(dt.Rows[0][0]);
                                UserSession.UserName = dt.Rows[0][1].ToString();
                                AddUser u = new AddUser();
                                u.Show();
                                Visible = false;
                               
                            }
                            else
                            {//User
                                SelectTransaction sc = new SelectTransaction();
                                sc.Show();
                                Visible = false;
                                UserSession.UserId = Convert.ToInt32(dt.Rows[0][0]);
                                UserSession.Balance = Convert.ToDecimal(dt.Rows[0][3]);
                                UserSession.UserName = dt.Rows[0][1].ToString();
                               

                            }
                        }

                    }
                    else
                    {//could not Find User with this Credentials

                        Invalid.Text = "Please enter Valid Credentials";
                        checkpassword.Visible = false;
                        checkId.Visible = false;
                        Id.Text = "";
                        Password.Text = "";
                        //a3ml eno y sleep shwaya ba3d keda ye3mlo return 3ala el home page
                    }

                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.ToString());
                    Invalid.Visible = true;

                }
                finally
                {
                    conn.Close();

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
    }
}
