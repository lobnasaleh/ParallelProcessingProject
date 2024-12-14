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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

       //  const string con = (@"Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        //decimal oldBalance 
            decimal newBalance;
        // int Acc = 2 ;
        int userid = UserSession.UserId;


        private async void nextDeposit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Input: " + amountToDeposit.Text);

            if (amountToDeposit.Text == "" || !decimal.TryParse(amountToDeposit.Text, out decimal depositAmount) || depositAmount <= 0)
            {
                MessageBox.Show("Please enter a valid amount to Deposit");
                return;
            }

            /* if (depositAmount > oldBalance)
             {
                 MessageBox.Show("The balance cannot be negative.");
                 return;
             }
 */
            await Task.Delay(3000);

            await ProcessDeposit(depositAmount);
            
          /*  var home = new SelectTransaction();
            home.Show();
            this.Hide();*/

        }
        
        private async void Deposit_Load(object sender, EventArgs e)
        {
            await GetBalance();
        }

        private async void amountToDeposit_TextChanged(object sender, EventArgs e)
        {
            await GetBalance();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectTransaction home = new SelectTransaction();
            home.Show();
            Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkId_Click(object sender, EventArgs e)
        {

        }

        private async Task ProcessDeposit(decimal depositAmount)
        {
            if (!semaphore.Wait(0))
            {
                MessageBox.Show("Resource is busy. Try again later.");
                return;
            }
                try
                {
                using(var connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    
                    newBalance = await GetBalance() + depositAmount;
                    await connection.OpenAsync();


                    string updateQuery = "UPDATE Users SET Balance = @newBalance WHERE Id = @userid";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@newBalance", newBalance);
                    updateCmd.Parameters.AddWithValue("@userid", userid);
                    await updateCmd.ExecuteNonQueryAsync();

                    string insertTransactionQuery = "INSERT INTO Transactions (TransactionType, Amount,TransactionDate, UserId) VALUES (@TransactionType, @Amount,@TransactionDate, @userid)";
                    SqlCommand insertTransactionCmd = new SqlCommand(insertTransactionQuery, connection);
                    insertTransactionCmd.Parameters.AddWithValue("@TransactionType", "Deposit");
                    insertTransactionCmd.Parameters.AddWithValue("@Amount", depositAmount);
                    insertTransactionCmd.Parameters.AddWithValue("@UserId", userid);
                    insertTransactionCmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                    await insertTransactionCmd.ExecuteNonQueryAsync();

                }

                  //  oldBalance = newBalance; // Update the balance in memory
                    BalanceLabel.Text = $"Balance Rs: {GetBalance()}";
                    MessageBox.Show("Amount successfully deposited and transaction recorded.");
                LogTransaction("Deposit", depositAmount);


            }
                catch (Exception ex)
                {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Error processing Deposit: {ex.Message}");
                }));
            }
            finally
            {
                semaphore.Release();
            }
        }
        public async Task<decimal> GetBalance()
        {
            decimal oldbalance=0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("SELECT Balance FROM Users WHERE Id = @userid", connection))
                    {
                        cmd.Parameters.AddWithValue("@userid", userid);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                oldbalance = reader.GetDecimal(0);
                                BalanceLabel.Text = $"Balance Rs: {oldbalance}";
                            }
                            return oldbalance; // Return the balance after reading
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching balance: {ex.Message}");
                return 0; // Return 0 in case of error
            }
        }


        private void LogTransaction(string transactionType, decimal amount)
        {
            string logMessage = $"{DateTime.Now}: {transactionType} of {amount:C}. New balance: {newBalance:C}";

            string solutionPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // Combine it with the log file name
            string logFilePath = Path.Combine(solutionPath, "transaction_log.txt");
              System.IO.File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
    }
}
