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
                checkId.Visible = true;
                checkpassword.Visible = true;
                Invalid.Visible = false;


            }
            else if (string.IsNullOrWhiteSpace(Id.Text ) && !string.IsNullOrWhiteSpace(Password.Text) )
            {
                checkId.Visible = true;
                checkpassword.Visible = false;
                Invalid.Visible = false;


            }
            else if (!string.IsNullOrWhiteSpace(Id.Text ) && string.IsNullOrWhiteSpace(Password.Text ))
            {
                checkId.Visible = false;
                checkpassword.Visible = true;
                Invalid.Visible = false;

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
                    cmd.Parameters.AddWithValue("@password", Password.Text);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    { //he found data of User/Admin 
                        int RoleId = Convert.ToInt32(dt.Rows[0][4]);//4 representing the index of roleid in database as a column


                        if (RoleId == 1)
                        {//admin 
                         // AddUser u = new AddUser();
                         // u.Show();
                         //this.Close();
                            UserSession.UserId = Convert.ToInt32(dt.Rows[0][0]);
                            UserSession.UserName = dt.Rows[0][1].ToString();
                            AddUser u=new AddUser();
                            u.Show();
                            Visible = false;
                            //MessageBox.Show("Hello,Admin");
                        }
                        else
                        {//User
                            SelectTransaction sc = new SelectTransaction();
                            sc.Show();
                            Visible = false;
                            UserSession.UserId = Convert.ToInt32(dt.Rows[0][0]);
                            UserSession.Balance = Convert.ToDecimal(dt.Rows[0][3]);
                            UserSession.UserName = dt.Rows[0][1].ToString();
                            // MessageBox.Show($"Hello,{dt.Rows[0][1]}");

                        }
                    }
                    else
                    {//could not Find User with this Credentials
                        checkId.Visible = false;
                        checkpassword.Visible = false;
                        Invalid.Visible = true;
                        Id.Text = "";
                        Password.Text = "";
                        //y sleep shwaya ba3d keda ye3mlo return 3ala el home page
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
