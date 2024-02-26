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
    public partial class Feedback_recieved : Form
    {
        public Feedback_recieved()
        {
            InitializeComponent();
        }

        private void Feedback_recieved_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=TOWHID\\SQLEXPRESS;Initial Catalog=fbdb;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Text FROM Feedback ORDER BY ID DESC";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string feedbackText = reader["Text"].ToString();
                            textFB.Text = feedbackText;
                        }
                    }
                }
            }
        }
    }
}
