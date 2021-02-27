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
            metroLabel3.Text = user;
            metroLabel5.Text = role;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form a1 = new Members();
            a1.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form a1 = new Books();
            a1.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Form a1 = new IssuedBooks();
            a1.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Form a1 = new Records();
            a1.ShowDialog();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if(role == "admin")
            {
                Form a1 = new SystemConfig();
                a1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Contact System Administrator");
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
