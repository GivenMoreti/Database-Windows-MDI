using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moreti_TG_93141004_SU2_Act4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CompaniesDB.mdf;Integrated Security=True";
        
        
        public void CustomFunction(string userQuery)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {

                conn.Open();
                string query = userQuery;

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Companies");

                companiesDataGridView.DataSource = ds.Tables["Companies"];

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        
        
        private void DisplayAllBtn_Click(object sender, EventArgs e)
        {
            string query = "Select * from Companies";
            CustomFunction(query);

        }

        public void FindFunction(int userSearchItem,string userQuery)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try

            {
                string searchItem = userSearchItem.ToString();

                if (!string.IsNullOrEmpty(FindTB.Text))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string query = userQuery;
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Rating", userSearchItem);

                    adapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Companies");

                    companiesDataGridView.DataSource = ds.Tables["Companies"];


                }
                else
                {
                    MessageBox.Show("please type something to find");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void FindBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FindTB.Text)){
                int rating = Convert.ToInt32(FindTB.Text);      //convert the rating to int

                string query = "SELECT * from Companies Where Rating = @Rating";        //get all by rating
                FindFunction(rating, query);            //pass arguments
            }
            else
            {
                MessageBox.Show("input field empty");
                FindTB.Focus();
            }
           
           
            
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
                
            {
                string searchItem = "%" + SearchTB.Text + "%";

                if (!string.IsNullOrEmpty(SearchTB.Text))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string query = "Select * from Companies where Slogan Like @SearchItem";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue ("@SearchItem", searchItem);

                    adapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Companies");

                    companiesDataGridView.DataSource = ds.Tables["Companies"];


                }
                else
                {
                    MessageBox.Show("please type something to search");
                    SearchTB.Focus();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();         //close the app
        }

        private void companiesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.companiesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.companiesDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'companiesDBDataSet.Companies' table. You can move, or remove it, as needed.
            //this.companiesTableAdapter.Fill(this.companiesDBDataSet.Companies);

        }

        private void listAndSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmList frmList = new frmList();
            frmList.ShowDialog();
        }
    }
}
