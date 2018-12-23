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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void PhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void Course_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Client) {
                Client newClient = new Client(UName.Text, System.Convert.ToInt32(Room_Number.Text), System.Convert.ToInt32(Course.Text), PhoneNumber.Text , System.Convert.ToInt32(Age.Text), Email.Text, UPassword.Text, Dormitory.Text);

            if (newClient.Registrate()) {
                MessageBox.Show("Registering proccess was succesful");
            }
            else
            {
                MessageBox.Show("We could't register");
            }

            Form1 Log_in = new Form1(StrTextBox, Client);
            Log_in.Show();
            Close(); 
            }else {
                Seller newSeller = new Seller(UName.Text, UPassword.Text, System.Convert.ToInt32(Room_Number.Text), System.Convert.ToInt32(Course.Text), PhoneNumber.Text, System.Convert.ToInt32(Age.Text), Email.Text,  Dormitory.Text);
                if (newSeller.Registrate())
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
