using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financepal
{
    public partial class Userprofile : Form
    {
        private string connectionString = "Data Source=Towhid\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True";
        public Userprofile()
        {
            InitializeComponent();
        }
        public void Insert(string filename, byte[] image)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Picture (FileName, Image) VALUES (@FileName, @Image)", connection);
                command.Parameters.AddWithValue("@FileName", filename);
                command.Parameters.AddWithValue("@Image", image);
                command.ExecuteNonQuery();
            }
        }

        public void LoadData()
        {
            LoadData(guna2CirclePictureBox1);
        }

        public void LoadData(PictureBox pictureBox1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Pictures", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                //adapter.Fill();
                // dataGridView1.DataSource = table;
            }
        }

        byte[] ConvertImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public Image ConvertBytesToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Image image= guna2CirclePictureBox1.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    guna2CirclePictureBox1.Image = Image.FromFile(ofd.FileName);
                    guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                   // guna2TextBox1.Text = ofd.FileName;
                    Insert(ofd.FileName, ConvertImageToBytes(guna2CirclePictureBox1.Image));
                    LoadData();
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=TOWHID\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[UserRegistration]
           ([first_name]
           ,[last_name]
           ,[email]
           ,[contact_number]
           ,[password])
     VALUES
           ('" + guna2TextBox1.Text + "','" + guna2TextBox4.Text + "','" + guna2TextBox5.Text + "','" + guna2TextBox2.Text + "','" + guna2TextBox3.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record inserted successfully");
        }
    }
}
