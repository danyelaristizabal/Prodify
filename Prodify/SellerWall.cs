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
        BusinessRepository businessRepository = new BusinessRepository();
        SellerRepository sellerRepository = new SellerRepository();
        int index;
        DataGridViewRow selectedRow;
        string SelectedBusinessName;


        public SellerWall(Seller myseller)
        {
            Myseller = myseller;
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            CreateBusiness NewBusiness = new CreateBusiness(Myseller);
            NewBusiness.Show();
            Hide(); 
        }

        private void SellerWall_Load(object sender, EventArgs e)
        {
            label1.Text = "Your Business " + businessRepository.Count(Myseller.Name, Myseller.Dormitory);
            label2.Text = "Total Business in your Dorm: " + businessRepository.Count(null, Myseller.Dormitory);

            dataGridView2.DataSource = sellerRepository.GetAllBusinessList(Myseller); 
            dataGridView1.DataSource = sellerRepository.GetBusinessList(Myseller);
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                selectedRow = dataGridView1.Rows[index];
                SelectedBusinessName = selectedRow.Cells[0].Value.ToString();
                MessageBox.Show("Selected Business: " + SelectedBusinessName);
            }
            catch{

            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            
            
                if (businessRepository.Delete(SelectedBusinessName))
                {
                    MessageBox.Show("Business Deleted Succesfully");
                    dataGridView1.DataSource = sellerRepository.GetBusinessList(Myseller);
                dataGridView2.DataSource = sellerRepository.GetAllBusinessList(Myseller); 
                }
          
        }


        private void UpdateSeller_Click(object sender, EventArgs e)
        {
            UpdateSeller updateSeller = new UpdateSeller(Myseller);
            updateSeller.Show();
            Close(); 
        }

        private void BusinessUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Business selectedBusiness = businessRepository.Construct(SelectedBusinessName);
                UpdateBusiness updateBusiness = new UpdateBusiness(Myseller, selectedBusiness);
                updateBusiness.Show();
                Close();
            }
            catch {
                MessageBox.Show("Please, select the Business that you want to update");
            }
        }
    }
}
