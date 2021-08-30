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
        
        private void BookRequest_Load(object sender, EventArgs e)
        {
            reset();
            Classes.BookClass bookClass = new Classes.BookClass();
            Classes.MemberClass memberClass = new Classes.MemberClass();
            Classes.BookClass.Book book = new Classes.BookClass.Book();
            Classes.MemberClass.Member member = new Classes.MemberClass.Member();
            
            BindingSource bindingSource1 = new BindingSource();
            BindingSource bindingSource2 = new BindingSource();
            comboBox1.DataSource = bindingSource1;
            comboBox2.DataSource = bindingSource2;
            this.comboBox1.ValueMember = "ISBN";
            this.comboBox2.ValueMember = "ID";
            bindingSource1.DataSource = bookClass.GetDataSet();
            bindingSource2.DataSource = memberClass.GetDataSet();
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
