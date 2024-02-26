using System;
using System.Windows.Forms;

namespace Financepal
{
    public partial class Asset_Liability_Show : Form
    {
        public Asset_Liability_Show()
        {
            InitializeComponent();
        }

        private void Asset_Liability_Show_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDBDataSet2.Expenselist' table. You can move, or remove it, as needed.
            this.expenselistTableAdapter.Fill(this.myDBDataSet2.Expenselist);
            // TODO: This line of code loads data into the 'myDBDataSet2.LiabilityList' table. You can move, or remove it, as needed.
            this.liabilityListTableAdapter.Fill(this.myDBDataSet2.LiabilityList);
            // TODO: This line of code loads data into the 'myDBDataSet2.AssetList' table. You can move, or remove it, as needed.
            this.assetListTableAdapter1.Fill(this.myDBDataSet2.AssetList);
            // TODO: This line of code loads data into the 'myDBDataSet1.AssetList' table. You can move, or remove it, as needed.
        //    this.assetListTableAdapter.Fill(this.myDBDataSet1.AssetList);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.liabilityListTableAdapter.FillBy(this.myDBDataSet2.LiabilityList);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.liabilityListTableAdapter.FillBy1(this.myDBDataSet2.LiabilityList);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
