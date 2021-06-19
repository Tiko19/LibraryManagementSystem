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
    public partial class BooksAdd : Form
    {
        public BooksAdd()
        {
            InitializeComponent();
        }

        private void reset()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*DialogResult result = MessageBox.Show("", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //do something
            }
            else if (result == DialogResult.No)
            {
                //do something else
            }*/

            reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BooksAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
