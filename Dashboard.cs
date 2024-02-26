using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financepal
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("NOT set yet!");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            label1.Visible=false;
            textBox1.Visible=false;
            
            openChildForm(new Userprofile());
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Liability());
            
        }

        private Form activeForm = null;
        private void openChildForm(Form childe)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childe;
            childe.TopLevel = false;
            childe.FormBorderStyle = FormBorderStyle.None;
            childe.Dock = DockStyle.Fill;
            panel1.Controls.Add(childe);
            panel1.Tag = childe;
            childe.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Expences());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Goal());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            openChildForm(new Asset());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Confirm Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               
              
                this.Close();
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            openChildForm(new graph___Chart());
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }
        
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Budget());
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            openChildForm(new map());
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            openChildForm(new accounts());
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            openChildForm(new GFB());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Login = new Login();
            Login.Show();
        }
    }
}
