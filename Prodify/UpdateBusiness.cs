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
    public partial class UpdateBusiness : Form
    {
        Seller Seller;
        Business Business;
        BusinessRepository businessRepository = new BusinessRepository(); 
        public  UpdateBusiness(Seller seller, Business business)
        {
            Seller = seller;
            Business = business; 

            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        private void Back_Click(object sender, EventArgs e)
        {
            SellerWall sellerWall = new SellerWall(Seller);
            sellerWall.Show();
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Business.Description = BusinessDescription.Text;
            Business.Nkomnata = System.Convert.ToInt32(Nkomnata.Text);
            Business.Price = System.Convert.ToInt32(Price.Text);
            businessRepository.Update(Business);
        }

        private void UpdateBusiness_Load(object sender, EventArgs e)
        {
            BusinessName.Text = Business.Name;
            BusinessDescription.Text = Business.Description;
            Nkomnata.Text = Business.Nkomnata.ToString();
            PhoneNumber.Text = Business.Phone.ToString();
            Price.Text = Business.Price.ToString();
        }
    }
}
