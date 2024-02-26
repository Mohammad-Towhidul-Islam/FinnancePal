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
using System.Windows.Forms.DataVisualization.Charting;


namespace Financepal
{
    public partial class graph___Chart : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public graph___Chart()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void graph___Chart_Load(object sender, EventArgs e)
        {
            chart1.Series["chart2"].Points.AddXY("Rifat", 1000);
            chart1.Series["chart2"].Points.AddXY("lifat", 5000);
            chart1.Series["chart2"].Points.AddXY("gifat", 3000);
            chart1.Series["chart2"].Points.AddXY("kifat", 2000);
            chart1.Series["chart2"].Points.AddXY("sifat", 4000);

            string cs = "your_connection_string_here";
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM AssetList";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string assetName = reader.GetString(1); // Assuming AssetName is in the second column (index 1)
                double amount = reader.GetDouble(2);    // Assuming Amount is in the third column (index 2)

                this.chart1.Series["chart2"].Points.AddXY(assetName, amount);
            }

            con.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /* using (ChartElement db = new ChartElement())
             {
                 chart2.DataSource = db.chart2.ToList();
                 chart2.Series["chart2"].XValueMember - "Amount";
                 chart2.Series["chart2"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                 chart2.Series["chart2"].ValueMembers = "Remaining";
                 chart2.Series["chart2"].WalueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
             }*/
            
        }
    }
}
