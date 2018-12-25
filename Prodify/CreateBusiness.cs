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
    public partial class CreateBusiness : Form
    {
        Seller Myseller; 
        public CreateBusiness(Seller myseller)
        {
            Myseller = myseller; 
            InitializeComponent();
        }

        private void CreateBusiness_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SellerWall userWall = new SellerWall(Myseller);
            userWall.Show();
            Close(); 
        }


        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Business newBusiness = new Business(BusinessName.Text, BusinessDescription.Text, System.Convert.ToInt32(Price.Text), System.Convert.ToInt32(Nkomnata.Text), Myseller.Name, Myseller.Dormitory, Myseller.Phone);
                BusinessRepository repository = new BusinessRepository(); 
                if (repository.Add(newBusiness))
                {
                    MessageBox.Show("Registering proccess was succesful");
                    SellerWall wall = new SellerWall(Myseller);
                    wall.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("We could't register");
                }
            }
            catch {
                MessageBox.Show("Please fill up the form correctly"); 
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {

            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void Nkomnata_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
