using LibraryManagementSystem.Classes;
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

        public Login()
        {
            InitializeComponent();
        }

        private void reset()
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserClass userClass = new UserClass();
            UserClass.User user  = new UserClass.User();
            user.Username = textBox1.Text;
            user.Password = textBox2.Text;

            if (userClass.CheckPass(user) == true)
            {
                user.Role = userClass.CheckRole(user);
                Form a1 = new Home(user.Username, user.Role);
                a1.ShowDialog();
                this.Close();
            }

            else if (textBox1.Text == defaultUser && textBox2.Text == defaultPass)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
