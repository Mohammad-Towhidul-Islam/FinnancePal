using Guna.UI2.WinForms.Suite;
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
    public partial class Asset : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        public Asset()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Name=textBox1.Text;  
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           // string Category=textBox2.Text;  
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string Amount=textBox3.Text;    
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string Description=textBox4.Text;   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[AssetList]
           ([Name]
           ,[Category]
           ,[Amount]
           ,[Description]
           
     VALUES
           ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + ")", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record inserted successfully");
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from AssetList";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.RowTemplate.Height = 80;
        }
        private void button2_Click(object sender, EventArgs e, Liability liability)
        {
           this.Hide();
            liability.Show();
        }

        private void Asset_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                // Create a SQL command
                SqlCommand command = new SqlCommand("SELECT * FROM AssetList", connection);

                // Create a data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Create a DataTable to store the data
                DataTable dataTable = new DataTable();

                // Fill the DataTable with data from the adapter
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection(cs);
            string query = "insert into AssetList (AssetName,Category,Amount,Description) values (@AssetName,@Category,@Amount,@Description)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AssetName", textBox1.Text);
            //cmd.Parameters.AddWithValue("@Category", textBox2.Text);
            cmd.Parameters.AddWithValue("@Amount", textBox3.Text);
            cmd.Parameters.AddWithValue("@Description", textBox4.Text);

            con.Open();
            cmd.ExecuteNonQuery();
           
            MessageBox.Show("Record inserted successfully");
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from AssetList";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AssetName", textBox1.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data reset Successfully");
                BindGridView();
                
            }
            else
            {
                MessageBox.Show("Data Not Deleted");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from AssetList where AssetName=@AssetName";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AssetName", textBox1.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data delete Successfully");
                BindGridView();

            }
            else
            {
                MessageBox.Show("Data Not Deleted");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
