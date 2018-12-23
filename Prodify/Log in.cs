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
    public partial class Form1 : Form
    {
        public bool Client;
        public string StrTextBox; 


        public Form1(string strTextBox, bool client)
        {
            Client = client;
            StrTextBox = strTextBox; 
            InitializeComponent();
            label1.Text = strTextBox;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Client) {
                Client Log_Client = new Client(UName.Text, 0, 0, "a", 0, "a", UPassword.Text, "Dormitory");
                if (Log_Client.Log_in()) {
                    MessageBox.Show("Logged in succesfully");
                    UserWall myUserWall = new UserWall(Client, StrTextBox);
                    myUserWall.Show();
                    Close();
                }
                else {
                    MessageBox.Show("Incorrect User Name or Password");
                }
            }  
            else {
                SqlConnection sq = new SqlConnection();
                sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Seller; database =ProdifyDatabase; integrated security = SSPI";
                SqlCommand scmd = new SqlCommand("select count (*) as cnt from Seller where Name = @usr and Password = @pwd", sq);
                scmd.Parameters.Clear();
                scmd.Parameters.AddWithValue("@usr", UName.Text);
                scmd.Parameters.AddWithValue("@pwd", UPassword.Text);
                sq.Open();

                if (scmd.ExecuteScalar().ToString() == "1")
                {
                   
                    MessageBox.Show("Logged in succesfully");
                    SqlConnection sq2 = new SqlConnection();
                    sq2.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Seller; database =ProdifyDatabase; integrated security = SSPI";
                    DataTable sellertable = new DataTable(); 
                    SqlCommand getseller = new SqlCommand("select * from Seller where Name = @Name", sq2);
                    getseller.Parameters.AddWithValue("@Name", UName.Text);
                    sq2.Open();
                    SqlDataReader reader = getseller.ExecuteReader();
                    sellertable.Load(reader);
                    string Name = sellertable.Rows[0].Field<string>(0);
                    string password = sellertable.Rows[0].Field<string>(1);
                    int Nkomnata = sellertable.Rows[0].Field<int>(2);
                    int Course = sellertable.Rows[0].Field<int>(3);
                    string Phone = sellertable.Rows[0].Field<string>(4);
                    int Age = sellertable.Rows[0].Field<int>(5);
                    string Email = sellertable.Rows[0].Field<string>(6);
                    string Dormitory = sellertable.Rows[0].Field<string>(7);
                    Seller LogedSeller = new Seller(Name,password,Nkomnata, Course, Phone, Age, Email, Dormitory); 
                    SellerWall mySellerWall = new SellerWall(LogedSeller);
                    mySellerWall.Show();
                    Close(); 

                }
                else {
                    MessageBox.Show("Incorrect User Name or Password");
                }
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry();
            entry.Show();
            Close(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration NewRegistration = new Registration(Client, StrTextBox);
            NewRegistration.Show();
            Close(); 
            
        }
    }
}
