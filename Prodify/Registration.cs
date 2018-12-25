using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prodify
{
    public partial class Registration : Form
    {
        public bool Client;
        public string StrTextBox;

        public Registration(bool client, string strTextBox)
        {
            Client = client;
            StrTextBox = strTextBox; 
            InitializeComponent();
            label1.Text = StrTextBox; 
        }
        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Log_in = new Form1(StrTextBox, Client);
            Log_in.Show();
            Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (Client) {
                try
                {
                    Client newClient = new Client(UName.Text, System.Convert.ToInt32(Room_Number.Text), System.Convert.ToInt32(Course.Text), PhoneNumber.Text, System.Convert.ToInt32(Age.Text), Email.Text, UPassword.Text, Dormitory.Text);
                    ClientRepository repository = new ClientRepository(); 
                    if (repository.Add(newClient))
                    {
                        MessageBox.Show("Registering proccess was succesful");
                    }
                    else
                    {
                        MessageBox.Show("We could't register");
                    }

                    Form1 Log_in = new Form1(StrTextBox, Client);
                    Log_in.Show();
                    Close();
                }
                catch {
                    MessageBox.Show("Please fill up the form correctly");

                }

            }else {

                try {
                    Seller newSeller = new Seller(UName.Text, UPassword.Text, System.Convert.ToInt32(Room_Number.Text), System.Convert.ToInt32(Course.Text), PhoneNumber.Text, System.Convert.ToInt32(Age.Text), Email.Text, Dormitory.Text);
                    SellerRepository repository = new SellerRepository(); 
                    if (repository.Add(newSeller))
                    {
                        MessageBox.Show("Registering proccess was succesful");

                    }
                    else
                    {
                        MessageBox.Show("We could't register");

                    }
                    Form1 Log_in = new Form1(StrTextBox, Client);
                    Log_in.Show();
                    Close();
                }
                catch {
                    MessageBox.Show("Please fill up the form correctly");
                }
                


            }
        }
        private void Room_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46) {
                e.Handled = true;
            }
        }

        private void Registration_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void Age_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

        private void Course_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }


        }

        private void PhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

        }

       
    }
}
