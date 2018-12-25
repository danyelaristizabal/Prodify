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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Client) {
                try
                {
                    Client Log_Client = new Client(UName.Text, 0, 0, "a", 0, "a", UPassword.Text, "Dormitory");
                    ClientRepository repository = new ClientRepository(); 
                    if (repository.FindById(Log_Client))
                    {
                        Log_Client.Construct(); 
                        UserWall myUserWall = new UserWall(Client, StrTextBox, Log_Client);
                        myUserWall.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect User Name or Password");
                    }
                }
                catch (Exception E) {
                    MessageBox.Show("Error:" + E);
                }
            }if(!Client){
                try {
                         Seller log_Seller = new Seller(UName.Text, UPassword.Text, 0, 0, "a", 0,"Email", "Dormitory");
                    SellerRepository repository = new SellerRepository(); 

                         if (repository.FindById(log_Seller)) {
                        log_Seller.Construct();
                        SellerWall mySellerWall = new SellerWall(log_Seller);
                        mySellerWall.Show();
                        Close(); 
                          }   
                    else { MessageBox.Show("Incorrect User Name or Password");  }
                }catch { MessageBox.Show("Please fill up the forum correctly"); }
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
