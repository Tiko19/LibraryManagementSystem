using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Home : Form
    {
        private string user { get; set; }
        private string role { get; set; }

        public Home(string x, string y)
        {
            InitializeComponent();
            user = x;
            role = y;
            label4.Text = user;
            label5.Text = role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form a1 = new MembersMenu();
            a1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form a1 = new BooksMenu();
            a1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form a1 = new BookRequest();
            a1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form a1 = new RecordsMenu();
            a1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (role == "admin")
            {
                Form a1 = new SystemConfig();
                a1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Contact System Administrator");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
