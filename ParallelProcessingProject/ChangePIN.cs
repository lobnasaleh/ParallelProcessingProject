using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
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

        string hashedpassword;
        private static readonly SemaphoreSlim _pinUpdateSemaphore = new SemaphoreSlim(1, 1);
        /// <summary>
        /// Updates the PIN of  Given user id ,
        /// </summary>

        private async Task UpdatePinAsync(int userId, string pin)
        {
            
            using (SqlConnection conn = new SqlConnection(ConnectionStringProvider.ConnectionString))
            {
                try
                {
                    
                    await conn.OpenAsync();

                    
                    using (SqlCommand cmd = new SqlCommand("updatePIN", conn))//procedure name
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", userId);
   
                        string hashedPin = HashPassword(pin);

                        cmd.Parameters.AddWithValue("@pin", hashedPin);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("PIN updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("PIN update failed, please try again.");
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                   
                    MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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

        private async void button1_Click(object sender, EventArgs e)
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
           else if (!int.TryParse(pin.Text, out int pinNumber) || !int.TryParse(confirmpin.Text, out int pinNumber2))
            {
                confirmerr.Visible = true;
                confirmerr.Text = "PIN must be a numeric value.";

            }
            else if (pin.Text.Length != 4 || confirmpin.Text.Length != 4)
            {
                confirmerr.Visible = true;
                confirmerr.Text = "PIN must be exactly 4 digits.";
               
            }
            else
            //enetered both 
            {
                confirmerr.Visible = false;

                // Use SemaphoreSlim for thread safety
                await _pinUpdateSemaphore.WaitAsync(); // Acquire the semaphore
                try
                {

                    await UpdatePinAsync(UserSession.UserId, confirmpin.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally {

                    _pinUpdateSemaphore.Release(); // Release the semaphore

                }
            }



        }
    }
            
        }
 