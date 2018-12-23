using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodify
{
    class Business
    {

        public string Name;
        public string Description;
        public int Price;
        public  int  Nkomnata;
        public string Seller;
        public string Dormitory; 

        public Business(string name, string description, int price, int nkomnata, string seller, string dormitory) {
            Name = name;
            Description = description;
            Price = price;
            Nkomnata = nkomnata;
            Seller = seller;
            Dormitory = dormitory; 

        }

        public bool Registrate()
        {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Business; database =ProdifyDatabase; integrated security = SSPI";
            SqlCommand scmd = new SqlCommand("INSERT INTO Business(Name, Description, Price, Nkomnata, Seller, Dormitory) VALUES(@Name, @Description, @Price, @Nkomnata, @Seller, @Dormitory); ", sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@Name", Name);
            scmd.Parameters.AddWithValue("@Description", Description);
            scmd.Parameters.AddWithValue("@Price", Price);
            scmd.Parameters.AddWithValue("@Nkomnata", Nkomnata);
            scmd.Parameters.AddWithValue("@Seller", Seller);
            scmd.Parameters.AddWithValue("@Dormitory", Dormitory); 
            sq.Open();
            try
            {
                scmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



    }
}
