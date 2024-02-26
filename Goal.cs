using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financepal
{
    public partial class Goal : Form
    {
        public Goal()
        {
            InitializeComponent();
        }

        private void LIST_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            string newGoal = guna2TextBox1.Text;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
                return;
            LIST.Items.Add(guna2TextBox1.Text);
            guna2TextBox1.Clear();
            guna2TextBox1.Focus();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (LIST.Items.Count > 0)
            {
                LIST.Items.RemoveAt(LIST.SelectedIndex);
            }
        }
    }
}

