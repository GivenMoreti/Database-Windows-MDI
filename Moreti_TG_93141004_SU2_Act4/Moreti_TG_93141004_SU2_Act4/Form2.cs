using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moreti_TG_93141004_SU2_Act4
{
    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CompaniesDB.mdf;Integrated Security=True";
       
        Form1 parentForm = new Form1();
        
        private void companiesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.companiesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.companiesDBDataSet);

        }

        private void frmList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'companiesDBDataSet.Companies' table. You can move, or remove it, as needed.
            //this.companiesTableAdapter.Fill(this.companiesDBDataSet.Companies);

        }

        public void DisplayAllBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Companies";
            parentForm.CustomFunction(query);
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
