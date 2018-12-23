using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prodify
{
   public partial class Client : IEntity, IUser
    {
       public string Name { get; private set; } 
       public int Nkomnata {  get;  private set;  }
       public int Course { get; private set; } 
       public string Phone { get; private set; } 
       public int Age { get; private set; }
       public string Email { get; private set; }
       public string Password { get; private set; }
       public string Dormitory { get; private set;  }
        

        public Client(string name, int nkomnata, int course, string phone, int age, string email, string password, string dormitory) {
            Nkomnata = nkomnata;
            Name = name;
            Course = course;
            Phone = phone;
            Age = age;
            Email = email;
            Password = password;
            Dormitory = dormitory; 
        }


       public bool Registrate()
        {

            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source =DANYEL-PC\SQLEXPRESS; Initial Catalog =Client; database =ProdifyDatabase; integrated security = SSPI";
            SqlCommand scmd = new SqlCommand("INSERT INTO Client(Name, ClientRoom,  Course,Phone, Age, Password, Email, Dormitory) VALUES(@Name, @ClientRoom,  @Course, @Phone, @Age, @Password, @Email, @Dormitory);", sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@ClientRoom", Nkomnata);
            scmd.Parameters.AddWithValue("@Name", Name);
            scmd.Parameters.AddWithValue("@Course", Course);
            scmd.Parameters.AddWithValue("@Phone", Phone);
            scmd.Parameters.AddWithValue("@Age", Age);
            scmd.Parameters.AddWithValue("@Password", Password);
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


        public bool Log_in(){

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
    }
}
