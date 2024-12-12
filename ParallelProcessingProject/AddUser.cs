using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ParallelProcessingProject
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");


        private async Task FillDataGridAsync()
        {
            try
            {

                using (var conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True"))
                {

                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("getAllUsers", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();


                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader); // Load the data from the reader into the DataTable
                        }

                        // Bind the data to the DataGridView
                        getallusers.DataSource = dt;


                        getallusers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        getallusers.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private int roleid = 0;
        string hashedpassword;
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);  // allow one thread at a time
        private static SemaphoreSlim _semaphoredelete = new SemaphoreSlim(1, 1);  // Ensures only one delete operation can happen at a time

        private async Task AddUserAsync()
        {
            await _semaphore.WaitAsync();  // Ensure only one thread can enter this critical section at a time
            try
            {
                using (var conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True"))
                {

                    await conn.OpenAsync();


                    using (SqlCommand cmd = new SqlCommand("adduser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username.Text);
                        //MessageBox.Show(hashedpassword);
                        cmd.Parameters.AddWithValue("@password", hashedpassword);
                        cmd.Parameters.AddWithValue("@balance", balance.Text);


                        if (role.SelectedItem.ToString() == "Admin")
                            roleid = 1;
                        else
                            roleid = 2;

                        cmd.Parameters.AddWithValue("@role", roleid);


                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        // Check if the user was successfully added
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No rows affected. The user was not added.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {

                _semaphore.Release();
                // Clear inputs after operation
                await FillDataGridAsync();  // Update data grid asynchronously
                username.Text = string.Empty;
                pin.Text = string.Empty;
                balance.Text = string.Empty;
                role.SelectedIndex = -1;
            }
        }


        private string HashPassword(string password)
        {

            string passwordhash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
            return passwordhash;
        }
        private async Task<bool> CheckDuplicateUserNameAsync(string userName)
        {
            try
            {

                using (var conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True"))
                {

                    await conn.OpenAsync();


                    using (SqlCommand cmdd = new SqlCommand("checkDuplicateUsername", conn))
                    {
                        cmdd.CommandType = CommandType.StoredProcedure;
                        cmdd.Parameters.AddWithValue("@username", userName);


                        int count = (int)await cmdd.ExecuteScalarAsync();


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


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)//create user
        {
            bool isValid = true;


            if (string.IsNullOrWhiteSpace(username.Text))
            {
                usernameerr.Visible = true;

                usernameerr.Text = "Please enter a Username";
                isValid = false;
            }
            else
            {
                try
                {
                    if (await CheckDuplicateUserNameAsync(username.Text))
                    {

                        usernameerr.Text = "Username already taken please choose another";
                        isValid = false;
                        usernameerr.Visible = true;
                    }
                    else
                    {
                        usernameerr.Visible = false;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    isValid = false;
                }


            }
            if (string.IsNullOrWhiteSpace(pin.Text))
            {
                // pinerr.Visible = true;

                pinerr.Text = "Please enter a PIN";
                isValid = false;
                pinerr.Visible = true;
            }
            else if (!int.TryParse(pin.Text, out int pinNumber))
            {
                pinerr.Visible = true;
                pinerr.Text = "PIN must be a numeric value.";
                isValid = false;
                pinerr.Visible = true;
            }
            else if (pin.Text.Length != 4)
            {
                pinerr.Visible = true;
                pinerr.Text = "PIN must be exactly 4 digits.";
                isValid = false;
                pinerr.Visible = true;
            }

            else
            {
                hashedpassword = HashPassword(pin.Text);

                pinerr.Visible = false;

            }
            if (string.IsNullOrWhiteSpace(balance.Text))
            {
                // balanceerr.Visible = true;

                balanceerr.Text = "Please enter Balance";
                isValid = false;
                balanceerr.Visible = true;

            }
            else if (!decimal.TryParse(balance.Text, out decimal balanceValue))
            {
                balanceerr.Visible = true;

                balanceerr.Text = "Balance must be a valid number.";
                isValid = false;
            }
            else if (balanceValue <= 0)
            {
                balanceerr.Visible = true;
                balanceerr.Text = "Balance must be greater than 0.";
                isValid = false;
            }

            else
            {
                balanceerr.Visible = false;

            }
            if (role.SelectedIndex == -1)
            {
                roleerr.Visible = true;

                roleerr.Text = "Please select a Role";
                isValid = false;
            }
            else
            {
                roleerr.Visible = false;

            }
            if (isValid)

            {
                //enetered both check ba2a credentials
                try
                {
                    await AddUserAsync();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());


                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {


                        conn.Close();
                    }
                    await FillDataGridAsync();
                    username.Text = string.Empty;
                    pin.Text = string.Empty;
                    balance.Text = string.Empty;
                    role.SelectedIndex = -1;

                }
            }
            else
            {
                MessageBox.Show("correct errors before proceeding");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private async void AddUser_Load(object sender, EventArgs e)
        {
            await FillDataGridAsync();//method to fetch data from db and display it in a grid
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void getallusers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void getallusers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = getallusers.Rows[e.RowIndex];
                username.Text = row.Cells[1].Value.ToString();
                pin.Text = row.Cells[2].Value.ToString();
                balance.Text = row.Cells[3].Value.ToString();

                string roleId = row.Cells[4].Value.ToString();  // Role ID at index 4

                // Set ComboBox selection based on the role ID
                if (roleId == "1") // Admin
                {
                    role.SelectedItem = "Admin";
                }
                else if (roleId == "2") // User
                {
                    role.SelectedItem = "User";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)//update
        {
            GetTransactions d = new GetTransactions();
            d.Show();
            Visible = false;
        }

        private async Task DeleteUserAsync(string username)
        {
            await _semaphoredelete.WaitAsync();
            try
            {
                using (var conn = new SqlConnection("Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True"))
                {
                    await conn.OpenAsync();
                    //DeleteUserByUsername @username

                    using (SqlCommand cmd = new SqlCommand("DeleteUserByUsername", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No user with this name exists.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                _semaphoredelete.Release();
            }
        }

        private async void button6_Click(object sender, EventArgs e)//delete
        {
            // Check if a row is selected in the DataGridView
            getallusers.MultiSelect = false;

            if (getallusers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            // Get the username from the selected row
            var selectedRow = getallusers.SelectedRows[0]; // Get the first selected row 
            string usernameToDelete = selectedRow.Cells["Username"].Value.ToString();

            var confirmResult = MessageBox.Show($"Are you sure you want to delete the user '{usernameToDelete}'?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                await DeleteUserAsync(usernameToDelete);
                await FillDataGridAsync();  // Refresh the data grid 
                username.Text = string.Empty;
                pin.Text = string.Empty;
                balance.Text = string.Empty;
                role.SelectedIndex = -1;
            }
        }

        private async void username_TextChanged(object sender, EventArgs e)
        {
            await FillDataGridAsync();//method to fetch data from db and display it in a grid

        }
    }

}