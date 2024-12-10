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
        //SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");
        private static readonly SemaphoreSlim _roleUpdateSemaphore = new SemaphoreSlim(1, 1);

        private async Task AddRoleAsync(string roleName)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True"))
                {
                    await conn.OpenAsync();  

                    using (SqlCommand cmd = new SqlCommand("addrole", conn))  // esm el stored procedure
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@rolename", roleName);
                       
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();  // Async to avoid blocking the UI thread

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Role added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No rows affected. The Role was not added.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
             
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private async Task<bool> CheckDuplicateRoleNameAsync(string roleName)
        {
            try
            {
                // Use 'using' to ensure proper disposal of the SqlConnection
                using (var conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True"))
                {
                   
                    await conn.OpenAsync();

                   
                    using (SqlCommand cmdd = new SqlCommand("checkDuplicateRoleName", conn))
                    {
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("@rolename", roleName);

                       
                        int count = (int)await cmdd.ExecuteScalarAsync();

                        // Return true if duplicate role name exists, and otherwise false
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return true; 
            }
        }
        private void username_TextChanged(object sender, EventArgs e)
        {
        }

        private async void button4_Click(object sender, EventArgs e)
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
                    if (await CheckDuplicateRoleNameAsync(rolename.Text))
                    {

                        rolee.Text = "This Role already exists";

                    }
                    else
                    {
                        rolee.Visible = false;
           //  SemaphoreSlim to ensure that only one thread can update the role at a time


                        await _roleUpdateSemaphore.WaitAsync(); // Asynchronously wait to enter the critical section
                        try
                        {
                            await AddRoleAsync(rolename.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            _roleUpdateSemaphore.Release();//release when done

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

