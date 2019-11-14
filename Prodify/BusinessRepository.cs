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
    class BusinessRepository
    {
        public List<Business> Businesses { get; private set; }



        SqlConnection sq = new SqlConnection(@"Data Source =DESKTOP-KGC5T7J; Initial Catalog =Business; database =ProdifyDatabase; integrated security = SSPI");

        public bool Add(Business business)
        {
            SqlCommand scmd = new SqlCommand("INSERT INTO Business(Name, Description, Price, Nkomnata, Seller, Dormitory, Phone) VALUES(@Name, @Description, @Price, @Nkomnata, @Seller, @Dormitory,@Phone); ", sq);

            scmd.Parameters.Clear();

            scmd.Parameters.AddWithValue("@Name", business.Name);

            scmd.Parameters.AddWithValue("@Description", business.Description);

            scmd.Parameters.AddWithValue("@Price", business.Price);

            scmd.Parameters.AddWithValue("@Nkomnata", business.Nkomnata);

            scmd.Parameters.AddWithValue("@Seller", business.Seller);

            scmd.Parameters.AddWithValue("@Dormitory", business.Dormitory);

            scmd.Parameters.AddWithValue("@Phone", business.Phone);

            sq.Open();

            try
            {
                scmd.ExecuteScalar();

                sq.Close();

                return true;
            }
            catch
            {
                sq.Close();

                MessageBox.Show("This Business name is not disponible");

                return false;
            }
        }




        public bool Delete(string businessName)
        {


            SqlCommand scmd = new SqlCommand("Delete from Business where Name = @BName", sq);

            scmd.Parameters.Clear();

            scmd.Parameters.AddWithValue("@BName", businessName);

            sq.Open();

            try
            {
                scmd.ExecuteNonQuery();

                sq.Close();

                return true;
            }
            catch (Exception E)
            {
                sq.Close();

                MessageBox.Show("Please, Select the business that you want to Delete ");

                return false;
            }
        }
        public bool Update(Business business)
        {
            SqlCommand scmd = new SqlCommand("UPDATE Business SET Description = @Description, Nkomnata = @Nkomnata, Price = @Price WHERE Name = @Name;", sq);

            scmd.Parameters.Clear();

            scmd.Parameters.AddWithValue("@Name", business.Name);

            scmd.Parameters.AddWithValue("@Description", business.Description);

            scmd.Parameters.AddWithValue("@Nkomnata", System.Convert.ToInt32(business.Nkomnata));

            scmd.Parameters.AddWithValue("@Price", System.Convert.ToInt32(business.Price));

            sq.Open();

            try
            {
                scmd.ExecuteScalar();

                sq.Close();

                MessageBox.Show("Information Updated Succesfully");

                return true;
            }
            catch (Exception E)
            {
                MessageBox.Show("Error updating");

                sq.Close();

                return false;
            }

        }
        public bool FindById(Business business)
        {
            SqlCommand scmd = new SqlCommand("select count (*) as cnt from Business where Name = @usr", sq);

            scmd.Parameters.Clear();

            scmd.Parameters.AddWithValue("@usr", business.Name);

            sq.Open();

            try
            {
                scmd.ExecuteScalar();

                sq.Close();

                return true; 
            }
            catch (Exception E) {
                MessageBox.Show("Error:" + E);

                return false; 
            }

        }
        public string Count(string userName, string Dorm) {
            
            if (userName != null) {

                string total;

                SqlCommand scmd = new SqlCommand("SELECT COUNT(*) FROM Business WHERE Seller = @Seller and Dormitory = @Dormitory;", sq);

                scmd.Parameters.AddWithValue("@Seller", userName);

                scmd.Parameters.AddWithValue("@Dormitory", Dorm);

                sq.Open();

                try
                {
                    total = scmd.ExecuteScalar().ToString();

                    sq.Close(); 

                    return total; 


                }
                catch (Exception E)
                {
                    MessageBox.Show("Error" + E);

                    sq.Close();

                    return "Error";
                }


            } else {

                string total;

                SqlCommand scmd = new SqlCommand("SELECT COUNT(*) FROM Business WHERE Dormitory = @Dormitory", sq);

                scmd.Parameters.Clear();

                scmd.Parameters.AddWithValue("@Dormitory", Dorm);

                sq.Open();
                
                try
                {
                    total = scmd.ExecuteScalar().ToString();

                    sq.Close(); 

                    return total; 
                }
                catch (Exception E)
                {
                    MessageBox.Show("Error" + E);

                    sq.Close(); 

                    return "Error";
                }
            }
            



        }
        public Business Construct(string Name)
        {

            SqlConnection sq = new SqlConnection();

            sq.ConnectionString = @"Data Source =DESKTOP-KGC5T7J; Initial Catalog =Business; database =ProdifyDatabase; integrated security = SSPI";

            DataTable sellertable = new DataTable();

            SqlCommand getseller = new SqlCommand("select * from Business where Name = @Name", sq);

            getseller.Parameters.AddWithValue("@Name", Name);

            sq.Open();

            SqlDataReader reader = getseller.ExecuteReader(); 
            
            sellertable.Load(reader);

            Name = sellertable.Rows[0].Field<string>(0);

            string Description  = sellertable.Rows[0].Field<string>(1);

            int Price = sellertable.Rows[0].Field<int>(2);

            int Nkomnata = sellertable.Rows[0].Field<int>(3);

            string Seller = sellertable.Rows[0].Field<string>(4);

            string Dormitory = sellertable.Rows[0].Field<string>(5);

            string Phone = sellertable.Rows[0].Field<string>(6);

            sq.Close();

            Business Constructed = new Business(Name, Description, Price, Nkomnata, Seller, Dormitory, Phone); 

            return Constructed; 
        }
    }
}
    