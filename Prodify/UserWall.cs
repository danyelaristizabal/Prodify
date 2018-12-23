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

        public bool Client;
        public string StrTextBox;


        public UserWall(bool client, string strTextBox)
        {
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserWall_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetBusinessList(); 
        }

        private DataTable GetBusinessList() {
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
            Client = false;
            Entry NewEntry = new Entry(); 
            NewEntry.Show();
            Close();
        }
    }
}
