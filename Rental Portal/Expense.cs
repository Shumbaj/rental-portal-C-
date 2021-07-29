using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_Portal
{
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
        }

        private void Expense_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rentalDataSet4.expense' table. You can move, or remove it, as needed.
            this.expenseTableAdapter.Fill(this.rentalDataSet4.expense);
            try
            {
                
                string que = "SELECT   [balance] FROM [rental].[dbo].[currentAccount] WHERE id=1";
                var sql = string.Format(que, Properties.Settings.Default.rentalConnectionString);
                using (var con = new SqlConnection(Properties.Settings.Default.rentalConnectionString))
                using (var cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    String returnValue = Convert.ToString(cmd.ExecuteScalar());
                    label3.Text = returnValue;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
        private void updateCashReceived(string Amount)
        {
            try
            {

                //String connectionString = ;
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.rentalConnectionString);
                String query = "UPDATE [dbo].[currentAccount] SET [balance] = balance-" + Amount + " WHERE id=1";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception b)
            {
                MessageBox.Show(b.ToString());
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text!="" && textBox1.Text!="")
            {
                try
                {
                    bool num; float amount;
                    num = float.TryParse(textBox4.Text, out amount);
                    

                    //String connectionString = ;
                    SqlConnection connection = new SqlConnection(Properties.Settings.Default.rentalConnectionString);
                    String query = "INSERT INTO [dbo].[expense]([amount],[reference]) VALUES ("+amount+",'"+textBox1.Text+"')";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Successful!");
                    connection.Close();
                    updateCashReceived(amount.ToString());
                    textBox1.Clear();
                    textBox4.Clear();
                }
                catch (Exception S)
                {
                    MessageBox.Show(S.Message);
                }

            }
            else
            {
                MessageBox.Show("Incomplete information provided!");
            }


        }

        private void back_Click(object sender, EventArgs e)
        {
            Form b = new Home();
            b.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form j = new Expense();
            j.Show();
            this.Hide();
        }
    }
    }

