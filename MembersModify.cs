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
            metroTextBox1.Text = null;
            metroTextBox2.Text = null;
            metroTextBox3.Text = null;
            metroTextBox4.Text = null;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
