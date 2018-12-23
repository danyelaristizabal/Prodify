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
            Business newBusiness = new Business(BusinessName.Text, BusinessDescription.Text, System.Convert.ToInt32(Price.Text), System.Convert.ToInt32(Nkomnata.Text), Myseller.Name, Myseller.Dormitory);
            if (newBusiness.Registrate())
            {

                MessageBox.Show("Registering proccess was succesful");

            }
            else
            {
                MessageBox.Show("We could't register");

            }

            SellerWall wall = new SellerWall(Myseller);
            wall.Show(); 
            Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
