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
    public class Client : IUser
    {
        public string Name { get; private set; }
        public string Password { get; set; }
        public int NKomnata { get; set; }
        public int Course { get; set; }
        public string Phone { get; private set; }
        public int Age { get; set; }
        public string Email { get; private set; }
        public string Dormitory { get; private set; }

        public Client(string name, int nkomnata, int course, string phone, int age, string email, string password, string dormitory) {
            NKomnata = nkomnata;
            Name = name;
            Course = course;
            Phone = phone;
            Age = age;
            Email = email;
            Password = password;
            Dormitory = dormitory;
        }

        public void Construct() {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source =DESKTOP-KGC5T7J; Initial Catalog =Client; database =ProdifyDatabase; integrated security = SSPI";
            DataTable sellertable = new DataTable();
            SqlCommand getseller = new SqlCommand("select * from Client where Name = @Name", sq);
            getseller.Parameters.AddWithValue("@Name", Name);
            sq.Open();
            SqlDataReader reader = getseller.ExecuteReader();
            sellertable.Load(reader);
            Name = sellertable.Rows[0].Field<string>(0);
            NKomnata = sellertable.Rows[0].Field<int>(1);
            Course = sellertable.Rows[0].Field<int>(2);
            Phone = sellertable.Rows[0].Field<string>(3);
            Age = sellertable.Rows[0].Field<int>(4);
            Password = sellertable.Rows[0].Field<string>(5);
            Email = sellertable.Rows[0].Field<string>(6);
            Dormitory = sellertable.Rows[0].Field<string>(7);
            sq.Close();
        }

    }
}
