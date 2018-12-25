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
    public partial class UpdateSeller : Form
    {
        Seller Seller;
        SellerRepository SellerRepository = new SellerRepository(); 

        public UpdateSeller(Seller seller)
        {
            Seller = seller; 
            InitializeComponent();
        }
        private void Back_Click(object sender, EventArgs e)
        {
            SellerWall sellerWall = new SellerWall(Seller);
            sellerWall.Show();
            Close(); 
        }
        private void Close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void UpdateSeller_Load(object sender, EventArgs e)
        {
            UName.Text = Seller.Name;
            UPassword.Text = Seller.Password;
            Room_Number.Text = Seller.NKomnata.ToString();
            PhoneNumber.Text = Seller.Phone;
            Course.Text = Seller.Course.ToString();
            Age.Text = Seller.Age.ToString();
            Email.Text = Seller.Email;
            Dormitory.Text = Seller.Dormitory;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Seller.Password = UPassword.Text;
            Seller.NKomnata = System.Convert.ToInt32(Room_Number.Text);
            Seller.Course = System.Convert.ToInt32(Course.Text);
            Seller.Age = System.Convert.ToInt32(Age.Text);
            SellerRepository.Update(Seller);
        }
    }
}
