using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prodify
{
    public class Business
    {

        public string Name;
        public string Description;
        public int Price;
        public  int  Nkomnata;
        public string Seller;
        public string Dormitory;
        public string Phone; 

        public Business(string name, string description, int price, int nkomnata, string seller, string dormitory, string phone) {
            Name = name;
            Description = description;
            Price = price;
            Nkomnata = nkomnata;
            Seller = seller;
            Dormitory = dormitory;
            Phone = phone; 

        }
      
    }
}
