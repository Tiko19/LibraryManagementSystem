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
    public partial class BookRequest : Form
    {
        public BookRequest()
        {
            InitializeComponent();
        }

        private List<int> memID;
        private List<string> isbn;

        private void BookRequest_Load(object sender, EventArgs e)
        {
            reset();
            comboValues();
            memID = new List<int>();
            isbn = new List<string>();
        }

        private void comboValues()
        {
            for (int i = 0; i < memID.Count; i++)
            {
                comboBox1.Items.Add(memID[i]);
            }

            for (int j = 0; j < isbn.Count; j++)
            {
                comboBox2.Items.Add(isbn[j]);
            }
        }

        private void reset()
        {
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
