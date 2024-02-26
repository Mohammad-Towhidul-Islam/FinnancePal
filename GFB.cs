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



namespace Financepal
{
    public partial class GFB : Form
    {
        public GFB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string feedbackText = textBox1.Text;

                string connectionString = "Data Source=TOWHID\\SQLEXPRESS;Initial Catalog=fbdb;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Feedback (Text) VALUES (@Text)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Text", feedbackText);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Feedback submitted successfully!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
