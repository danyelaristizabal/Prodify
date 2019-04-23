using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prodify
{
    class ClientRepository {

        public List<Client> Clients { get; private set; }

         SqlConnection sq = new SqlConnection(@"Data Source =DESKTOP-KGC5T7J; Initial Catalog =Client; database =ProdifyDatabase; integrated security = SSPI");
        public bool Add(Client client) {
            SqlCommand scmd = new SqlCommand("INSERT INTO Client(Name, ClientRoom,  Course,Phone, Age, Password, Email, Dormitory) VALUES(@Name, @ClientRoom,  @Course, @Phone, @Age, @Password, @Email, @Dormitory);", sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@ClientRoom", client.NKomnata);
            scmd.Parameters.AddWithValue("@Name", client.Name);
            scmd.Parameters.AddWithValue("@Course", client.Course);
            scmd.Parameters.AddWithValue("@Phone", client.Phone);
            scmd.Parameters.AddWithValue("@Age", client.Age);
            scmd.Parameters.AddWithValue("@Password", client.Password);
            scmd.Parameters.AddWithValue("@Email", client.Email);
            scmd.Parameters.AddWithValue("@Dormitory", client.Dormitory);
            sq.Open();
            try
            {
                scmd.ExecuteScalar();
                sq.Close(); 
                return true;
                
            }
            catch (Exception E)
            {
                MessageBox.Show("This user name is not disponible");
                sq.Close(); 
                return false; 
            }

        }

        public void Delete(Client client) {
            SqlCommand scmd = new SqlCommand("Delete from  Client Where Name = @Name", sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@Name", client.Name);
            sq.Open();
            try
            {
                scmd.ExecuteScalar();
                sq.Close(); 
            } catch (Exception E){
                MessageBox.Show("Error:" + E);
                sq.Close(); 
            }
        }

        public bool Update(Client client) {
            
            SqlCommand scmd = new SqlCommand("UPDATE Client SET ClientRoom = @ClientRoom, Course = @Course, Age = @Age, Password = @Password WHERE Name = @Name;", sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@Name", client.Name);
            scmd.Parameters.AddWithValue("@ClientRoom", System.Convert.ToInt32(client.NKomnata));
            scmd.Parameters.AddWithValue("@Course", System.Convert.ToInt32(client.Course));
            scmd.Parameters.AddWithValue("@Age", System.Convert.ToInt32(client.Age));
            scmd.Parameters.AddWithValue("@Password", client.Password);
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

        public bool FindById(Client client) {
            SqlCommand scmd = new SqlCommand("select count (*) as cnt from Client where Name = @usr and Password = @pwd", sq);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@usr", client.Name);
            scmd.Parameters.AddWithValue("@pwd", client.Password);
            sq.Open();
            if (scmd.ExecuteScalar().ToString() == "1") {
                sq.Close();
                return true;
            }
            else {
                sq.Close();
                return false;
            }
        }
    }
}
