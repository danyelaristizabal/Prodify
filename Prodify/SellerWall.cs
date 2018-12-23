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

namespace Prodify
{
    public partial class SellerWall : Form
    {
        Seller Myseller;
        int index;
        DataGridViewRow selectedRow; 



        public SellerWall(Seller myseller)
        {
            Myseller = myseller;
            InitializeComponent();
        }

        private DataTable GetBusinessList()
        {
            DataTable dtBusiness = new DataTable();
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Business; database =ProdifyDatabase; integrated security = SSPI";
            SqlCommand scmd = new SqlCommand("SELECT * FROM Business", sq);
            sq.Open();
            SqlDataReader reader = scmd.ExecuteReader();
            dtBusiness.Load(reader);
            return dtBusiness;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateBusiness NewBusiness = new CreateBusiness(Myseller);
            NewBusiness.Show();
            Hide(); 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            selectedRow = dataGridView1.Rows[index];

            string BNameToDelete = selectedRow.Cells[0].Value.ToString();

            MessageBox.Show("The index is" + index + "And the name is" +  BNameToDelete );
        }

        private void SellerWall_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = GetBusinessList(); 
            dataGridView1.DataSource = Myseller.GetBusinessList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newlog = new Form1("Seller", false);
            newlog.Show();
            Close(); 
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            string BNameToDelete = selectedRow.Cells[0].Value.ToString(); 

            if (Myseller.DeleteBusiness(BNameToDelete))
            {
                MessageBox.Show("Business Deleted Succesfully");
                dataGridView1.DataSource = Myseller.GetBusinessList();
            }
            else {
                MessageBox.Show("An error ocurred, the business wasn't deleted from the database"); 
            }
        }
    }
}
