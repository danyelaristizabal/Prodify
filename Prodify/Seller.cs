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
    public class Seller : IUser
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public int NKomnata { get; private set; }
        public int Course { get; private set; }
        public string Phone { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public string Dormitory { get; private set; }


        public Seller(string name, string password, int nKomnata, int course, string phone, int age, string email, string dormitory) {
            Name = name;
            NKomnata = nKomnata;
            Password = password;
            Course = course;
            Phone = phone;
            Age = age;
            Email = email;
            Dormitory = dormitory;
        }

        public bool CheckInDataBasis()
        {
            bool OnDataBase = false;

            return OnDataBase;
        }

        public bool Log_in()
        {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Client; database =ProdifyDatabase; integrated security = SSPI";
            SqlCommand scmd = new SqlCommand("select count (*) as cnt from Client where Name = @usr and Password = @pwd", sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@usr", Name);
            scmd.Parameters.AddWithValue("@pwd", Password);
            sq.Open();

            if (scmd.ExecuteScalar().ToString() == "1")
            {
                return true;


            }
            else
            {

                return false;
            }

        }

        public bool Registrate()
        {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Seller; database =ProdifyDatabase; integrated security = SSPI";
            SqlCommand scmd = new SqlCommand("INSERT INTO Seller(Name, Password,  NKomnata,Course, Phone, Age, Email, Dormitory) VALUES(@Name, @Password, @NKomnata,@Course, @Phone, @Age, @Email, @Dormitory);", sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@Name", Name);
            scmd.Parameters.AddWithValue("@Password", Password);
            scmd.Parameters.AddWithValue("@NKomnata", NKomnata);
            scmd.Parameters.AddWithValue("@Course", Course);
            scmd.Parameters.AddWithValue("@Phone", Phone);
            scmd.Parameters.AddWithValue("@Age", Age);
            scmd.Parameters.AddWithValue("@Email", Email);
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

        public DataTable GetBusinessList()
        {
            DataTable dtBusiness = new DataTable();
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Business; database =ProdifyDatabase; integrated security = SSPI";
            SqlCommand scmd = new SqlCommand("SELECT * FROM Business where Seller = @name", sq);

            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@Name", Name);
            sq.Open();
            SqlDataReader reader = scmd.ExecuteReader();
            dtBusiness.Load(reader);
            MessageBox.Show("Logged in succesfully" + Name);
            return dtBusiness;
        }

        public bool DeleteBusiness(string businessname) {

            SqlConnection sq = new SqlConnection(@"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Business; database =ProdifyDatabase; integrated security = SSPI");
            SqlCommand scmd = new SqlCommand("Delete from Business where Name = @BName" , sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@BName", businessname);
            sq.Open();
            if (scmd.ExecuteNonQuery() == 1) {
                return true; 
            }
            else {
                return false; 
            }


        }
    }
}
