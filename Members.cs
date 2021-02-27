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
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form a1 = new MembersView();
            a1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form a1 = new MembersAdd();
            a1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form a1 = new MembersModify();
            a1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
