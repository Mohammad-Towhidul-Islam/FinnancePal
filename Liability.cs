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
    public partial class Liability : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public Liability()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Property= textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string Category= textBox2.Text; 
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string Amount= textBox3.Text;   
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string Description= textBox4.Text;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into LiabilityList (AssetName,Category,Amount,Description) values (@AssetName,@Category,@Amount,@Description)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@AssetName", textBox1.Text);
            cmd.Parameters.AddWithValue("@Category", textBox2.Text);
            cmd.Parameters.AddWithValue("@Amount", textBox3.Text);
            cmd.Parameters.AddWithValue("@Description", textBox4.Text);

            con.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record inserted successfully");
           
        }

        private void Liability_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
