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
    public partial class MembersModify : Form
    {
        public MembersModify()
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
            reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
