using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financepal
{
    public partial class Expences : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=TOWHID\\SQLEXPRESS;Initial Catalog=budget;Integrated Security=True");

        public Expences()
        {
            InitializeComponent();
        }

        private void ClearInputs()
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void RefreshDataGridView()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM BUDGET", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            dataGridView1.DataSource = table;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string category = comboBox1.SelectedItem.ToString();
            decimal amount = decimal.Parse(textBox3.Text);


            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO BUDGET (Title, Category, Amount, Remaining) " +
                "VALUES (@Title, @Category, @Amount, @Amount)", connection);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Category", category);
            cmd.Parameters.AddWithValue("@Amount", amount);
            cmd.ExecuteNonQuery();
            connection.Close();

            RefreshDataGridView();
            ClearInputs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM BUDGET WHERE ID = @ID", connection);
                cmd.Parameters.AddWithValue("@ID", selectedID);
                cmd.ExecuteNonQuery();
                connection.Close();

                RefreshDataGridView();
            }
        }

        private void Expences_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
