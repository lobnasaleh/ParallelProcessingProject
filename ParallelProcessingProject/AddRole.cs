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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ParallelProcessingProject
{
    public partial class AddRole : Form
    {
        public AddRole()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");
        private bool checkDuplicateUserName(string userName)
        {
            try
            {
                conn.Open();
                SqlCommand cmdd = new SqlCommand("checkDuplicateRoleName", conn);//esm el procedure
                cmdd.CommandType = CommandType.StoredProcedure;
                cmdd.Parameters.AddWithValue("@rolename", rolename.Text);

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
        private void username_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rolename.Text))
            {
                // usernameerr.Visible = true;

                rolee.Text = "Please enter a Role Name";
            }
            else
            {
                try
                {
                    if (checkDuplicateUserName(rolename.Text))
                    {

                        rolee.Text = "This Role already exists";

                    }
                    else
                    {
                        rolee.Visible = false;
                        try
                        {
                            conn.Open();

                            //@username nvarchar(50),@password nvarchar(255),@balance decimal (18,2),@role int
                            SqlCommand cmd = new SqlCommand("addrole", conn);//esm el procedure
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@rolename", rolename.Text);
                          
                            int rowsAffected = cmd.ExecuteNonQuery();//te3ml execute lel query w aterga3 el rows ely affected

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Role added successfully.");
                            }
                            else
                            {
                                MessageBox.Show("No rows affected. The Role was not added.");
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
           
          
                
            }
            }
    }

