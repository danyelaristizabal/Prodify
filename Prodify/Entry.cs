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
    public partial class Entry : Form
    {

        public bool Client; 

        public Entry()
        {
            InitializeComponent();
        }
        private void Entry_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Client = true; 
            Form1 frm = new Form1("Client", Client);
            frm.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client = false; 
            Form1 frm = new Form1("Seller", Client);
            frm.Show();
            Hide();
        }
    }
}
