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
    public partial class UsersAdd : Form
    {
        public UsersAdd()
        {
            InitializeComponent();
        }

        private void reset()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserClass userClass = new UserClass();
            UserClass.User user = new UserClass.User();

            if(textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Passwords do not match!");
            }
            else
            {
                user.Username = textBox1.Text;
                user.Role = textBox2.Text;
                user.Password = textBox3.Text;

                if(userClass.CheckUser(user) == true)
                {
                    MessageBox.Show("User already exists!");
                }
                else
                {
                    userClass.AddUser(user);
                }
            }
            reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
