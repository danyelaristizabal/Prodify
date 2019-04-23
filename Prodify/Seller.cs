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
        public string Password { get;  set; }
        public int NKomnata { get;  set; }
        public int Course { get;  set; }
        public string Phone { get; private set; }
        public int Age { get;  set; }
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

        public void Construct()
        {

            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source =DESKTOP-KGC5T7J; Initial Catalog =Seller; database =ProdifyDatabase; integrated security = SSPI";
            DataTable sellertable = new DataTable();
            SqlCommand getseller = new SqlCommand("select * from Seller where Name = @Name", sq);
            getseller.Parameters.AddWithValue("@Name", Name);
            sq.Open();
            SqlDataReader reader = getseller.ExecuteReader();
            sellertable.Load(reader);
            Name = sellertable.Rows[0].Field<string>(0);
            Password = sellertable.Rows[0].Field<string>(1);
            NKomnata = sellertable.Rows[0].Field<int>(2);
            Course = sellertable.Rows[0].Field<int>(3);
            Phone = sellertable.Rows[0].Field<string>(4);
            Age = sellertable.Rows[0].Field<int>(5);
            Email = sellertable.Rows[0].Field<string>(6);
            Dormitory = sellertable.Rows[0].Field<string>(7);
            sq.Close();
        }

     

    }
}
