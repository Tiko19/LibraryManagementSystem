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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form a1 = new MembersView();
            a1.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form a1 = new MembersAdd();
            a1.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Form a1 = new MembersModify();
            a1.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
