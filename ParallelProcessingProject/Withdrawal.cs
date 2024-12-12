using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelProcessingProject
{
    public partial class Withdrawal : Form
    {
        public Withdrawal()
        {
            InitializeComponent();
        }

        //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATMDB;Integrated Security=True");
        const string con = (@"Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True");
        private readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
     /*  decimal balance,*/
            decimal newBalance;
        // int Acc = 2;
        int userid = UserSession.UserId;

        private async void Withdrawal_Load(object sender, EventArgs e)
        {
            /*await Task.Run(() => UITest());*/
            await GetBalance();
        }

        private async Task<decimal> GetBalance()
        {
            decimal balance=0;

            try
            {
                using (var connection = new SqlConnection(con))
                {
                    await connection.OpenAsync();

                    // Use a 'using' block for the command and reader to ensure proper disposal
                    using (SqlCommand cmd = new SqlCommand("SELECT Balance FROM Users WHERE Id = @userid", connection))
                    {
                        cmd.Parameters.AddWithValue("@userid", userid);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                balance = reader.GetDecimal(0);
                                withdrawalLabel.Text = $"Balance Rs: {balance}";
                            }

                            return balance; // Return balance after reading the value
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


        private async void WithdrawalSubmit_Click(object sender, EventArgs e)
        {
          //  await Task.Run(() => UITest());

            if (string.IsNullOrWhiteSpace(Withdrawaltext.Text) ||
                !decimal.TryParse(Withdrawaltext.Text, out decimal withdrawalAmount) ||
                withdrawalAmount <= 0)
            {
                MessageBox.Show("Please enter a valid amount to withdrawal.");
                return;
            }

            if (withdrawalAmount > await GetBalance())
            {
                MessageBox.Show("The balance cannot be negative.");
                return;
            }
            
            await ProcessWithdrawal(withdrawalAmount);
            

             /*var home = new SelectTransaction();
             home.Show();
             this.Hide();*/
        }

        private async Task ProcessWithdrawal(decimal withdrawalAmount)
        {
            if (!semaphore.Wait(0))
            {
                MessageBox.Show("Resource is busy. Try again later.");
                return;
            }
            try
            {
                newBalance =await GetBalance() - withdrawalAmount;
                using (var connection = new SqlConnection(con))
                {
                    await connection.OpenAsync();

                    // Update the user's balance
                    string updateQuery = "UPDATE Users SET Balance = @newBalance WHERE Id = @userid";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@newBalance", newBalance);
                    updateCmd.Parameters.AddWithValue("@userid", userid);
                    await updateCmd.ExecuteNonQueryAsync();

                    // Insert the transaction record
                    string insertTransactionQuery = "INSERT INTO Transactions (TransactionType, Amount,TransactionDate, UserId) VALUES (@TransactionType, @Amount,@TransactionDate, @userid)";
                    SqlCommand insertTransactionCmd = new SqlCommand(insertTransactionQuery, connection);
                    insertTransactionCmd.Parameters.AddWithValue("@TransactionType", "Withdrawal");
                    insertTransactionCmd.Parameters.AddWithValue("@Amount", withdrawalAmount);
                    insertTransactionCmd.Parameters.AddWithValue("@userid", userid);
                    insertTransactionCmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                    await insertTransactionCmd.ExecuteNonQueryAsync();

                    
                    await connection.CloseAsync();
                }
            //    balance = newBalance; // Update the balance in memory
                withdrawalLabel.Text = $"Balance Rs: {GetBalance()}";

                // comment that line to test ui response 
                MessageBox.Show("Amount successfully withdrawn and transaction recorded.");
                LogTransaction("Withdrawal", withdrawalAmount);



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing withdrawal: {ex.Message}");
                
            }
            finally
            {
                semaphore.Release();
            }
            
        }
         private void UITest()
        {
            Thread.Sleep(5000);
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectTransaction home = new SelectTransaction();
            home.Show();
            Visible = false;
        }

        private async void Withdrawaltext_TextChanged(object sender, EventArgs e)
        {
            await GetBalance();

        }

        private void label3_Click(object sender, EventArgs e)
        {

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

