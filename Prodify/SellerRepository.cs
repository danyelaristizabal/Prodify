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
    class SellerRepository 
    {
        SqlConnection sq = new SqlConnection(@"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Seller; database =ProdifyDatabase; integrated security = SSPI");
       
        public List<Seller> Sellers { get; private set; }

            public bool Add(Seller seller)
            {
                SqlConnection sq = new SqlConnection();
                sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Seller; database =ProdifyDatabase; integrated security = SSPI";
                SqlCommand scmd = new SqlCommand("INSERT INTO Seller(Name, Password,  NKomnata,Course, Phone, Age, Email, Dormitory) VALUES(@Name, @Password, @NKomnata,@Course, @Phone, @Age, @Email, @Dormitory);", sq);
                scmd.Parameters.Clear();
                scmd.Parameters.AddWithValue("@Name", seller.Name);
                scmd.Parameters.AddWithValue("@Password", seller.Password);
                scmd.Parameters.AddWithValue("@NKomnata", seller.NKomnata);
                scmd.Parameters.AddWithValue("@Course", seller.Course);
                scmd.Parameters.AddWithValue("@Phone", seller.Phone);
                scmd.Parameters.AddWithValue("@Age", seller.Age);
                scmd.Parameters.AddWithValue("@Email", seller.Email);
                scmd.Parameters.AddWithValue("@Dormitory", seller.Dormitory);
            sq.Open();
            try
                {
                    scmd.ExecuteScalar();
                    sq.Close();
                    return true;
                }
            catch (Exception E)
                {
                MessageBox.Show("This Seller name is not disponible"); 
                    sq.Close(); 
                    return false;
                }

            }

            public bool Delete(Seller seller)
            {
                    SqlCommand scmd = new SqlCommand("Delete from  Seller Where Name = @Name", sq);
                    scmd.Parameters.Clear();
                    scmd.Parameters.AddWithValue("@Name", seller.Name);
                    sq.Open();
                    try
                    {
                         scmd.ExecuteScalar();
                         sq.Close(); 
                    
                        return true;
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show("Error:" + E);
                        sq.Close(); 
                        return false; 
                    }

            }

            public bool Update(Seller seller)
                {

            SqlCommand scmd = new SqlCommand("UPDATE Seller SET NKomnata = @ClientRoom, Course = @Course, Age = @Age, Password = @Password WHERE Name = @Name;", sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@Name", seller.Name);
            scmd.Parameters.AddWithValue("@ClientRoom", System.Convert.ToInt32(seller.NKomnata));
            scmd.Parameters.AddWithValue("@Course", System.Convert.ToInt32(seller.Course));
            scmd.Parameters.AddWithValue("@Age", System.Convert.ToInt32(seller.Age));
            scmd.Parameters.AddWithValue("@Password", seller.Password);
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
                MessageBox.Show("Error updating:" + E);
                sq.Close();
                return false;
            }

        }


            public bool FindById(Seller seller)
                {
                    SqlCommand scmd = new SqlCommand("select count (*) as cnt from Seller where Name = @usr and Password = @pwd", sq);
                    scmd.Parameters.Clear();
                    scmd.Parameters.AddWithValue("@usr", seller.Name);
                    scmd.Parameters.AddWithValue("@pwd", seller.Password);
                    sq.Open();
                    if (scmd.ExecuteScalar().ToString() == "1")
                        {
                            sq.Close(); 
                            return true;
                        }
                    else
                        {
                            sq.Close(); 
                            return false;
                        }
                }

            public DataTable GetBusinessList(Seller seller)
                {
                    DataTable dtBusiness = new DataTable();
                    SqlCommand scmd = new SqlCommand("SELECT * FROM Business where Seller = @name", sq);
                    scmd.Parameters.Clear();
                    scmd.Parameters.AddWithValue("@Name", seller.Name);
                    sq.Open();
                    SqlDataReader reader = scmd.ExecuteReader();
                    dtBusiness.Load(reader);
                    sq.Close(); 
                    return dtBusiness;
                }

            public DataTable GetAllBusinessList(Seller seller)
            {
                DataTable dtBusiness = new DataTable();
                SqlConnection sq = new SqlConnection();
                sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Business; database =ProdifyDatabase; integrated security = SSPI";
                SqlCommand scmd = new SqlCommand("SELECT * FROM Business WHERE Dormitory = @Dormitory", sq);
                scmd.Parameters.AddWithValue("@Dormitory", seller.Dormitory);
                sq.Open();
                SqlDataReader reader = scmd.ExecuteReader();
                dtBusiness.Load(reader);
                return dtBusiness;
            }
    }
}
