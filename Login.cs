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
    public partial class Login : Form
    {
        private string defaultUser = "admin";
        private string defaultPass = "0134";
        private string User { get; set; }
        private string Password { get; set; }
        private string Role { get; set; }
        
        public Login()
        {
            InitializeComponent();
        }

        private void reset()
        {
            metroTextBox1.Text = null;
            metroTextBox2.Text = null;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == User && metroTextBox2.Text == Password)
            {
                Form a1 = new Home(User, Role);
                a1.ShowDialog();
                this.Close();
            }

            else if (metroTextBox1.Text == defaultUser && metroTextBox2.Text == defaultPass)
            {
                Form a1 = new Home(defaultUser, "admin");
                a1.ShowDialog();
                this.Close();
            }

            else
            {
                MessageBox.Show("Incorrect username or password");
                reset();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
