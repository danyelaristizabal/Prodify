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
    public partial class UserWall : Form
    {
        BusinessRepository repository = new BusinessRepository();
        Client MyClient; 
        public bool Client;
        public string StrTextBox;


        public UserWall(bool client, string strTextBox, Client myClient)
        {
            MyClient = myClient; 
            Client = client;
            StrTextBox = strTextBox;
            
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 newlog = new Form1(StrTextBox, Client);
            


        }
        private void UserWall_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetBusinessList();
            TotalBusiness.Text = "Total Business in your Dormitory: " + repository.Count(null, MyClient.Dormitory); 
        }

        private DataTable GetBusinessList() {
            DataTable dtBusiness = new DataTable();
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Business; database =ProdifyDatabase; integrated security = SSPI";
            SqlCommand scmd = new SqlCommand("SELECT Name, Description, Price, Nkomnata, Seller, Phone From Business WHERE Dormitory = @Dormitory", sq);
            scmd.Parameters.AddWithValue("@Dormitory", MyClient.Dormitory); 
            sq.Open(); 
            SqlDataReader reader = scmd.ExecuteReader();
            dtBusiness.Load(reader);   
            return dtBusiness;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client = false;
            Entry NewEntry = new Entry(); 
            NewEntry.Show();
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UpdateClient_Click(object sender, EventArgs e)
        {
            UpdateClient update = new UpdateClient(MyClient);
            update.Show();
            Close(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
