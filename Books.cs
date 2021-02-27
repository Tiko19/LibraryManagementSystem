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
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form a1 = new BooksView();
            a1.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form a1 = new BooksAdd();
            a1.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
