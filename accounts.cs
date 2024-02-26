using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Financepal
{
    public partial class accounts : Form
    {

        public SqlConnection connection = new SqlConnection("Data Source=TOWHID\\SQLEXPRESS;Initial Catalog=Accounts;Integrated Security=True");
      

        public accounts()
        {
            InitializeComponent();
        }

        private void accounts_Load(object sender, EventArgs e)
        {

        }

        private void RefreshDataGridView()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Accounts", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();

            dataGridView1.DataSource = table;
        }

        private void ClearInputs()
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;

        }

        private void label1_Click(object sender, EventArgs e)
        {
         
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void BindGrindView()
        {
            SqlConnection connection = new SqlConnection();
            string query = "select * from Accounts";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection); // Uncomment this line
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
