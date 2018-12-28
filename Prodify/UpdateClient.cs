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
    public partial class UpdateClient : Form
    {

        ClientRepository MyClientRepository = new ClientRepository();
        Client MyClient; 
        public UpdateClient(Client myClient)
        {
            MyClient = myClient;
            InitializeComponent();
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            UName.Text = MyClient.Name;
            UPassword.Text = MyClient.Password;
            Room_Number.Text = MyClient.NKomnata.ToString();
            PhoneNumber.Text = MyClient.Phone;
            Course.Text = MyClient.Course.ToString();
            Age.Text = MyClient.Age.ToString();
            Email.Text = MyClient.Email;
            Dormitory.Text = MyClient.Dormitory; 
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Save_Click(object sender, EventArgs e)
        {
              MyClient.Password = UPassword.Text;
               MyClient.NKomnata = System.Convert.ToInt32(Room_Number.Text);
               MyClient.Course = System.Convert.ToInt32(Course.Text);
               MyClient.Age = System.Convert.ToInt32(Age.Text);


           
            MyClientRepository.Update(MyClient);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            UserWall userWall = new UserWall(true, "Client", MyClient);
            userWall.Show();
            Close(); 

        }

        private void UName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
