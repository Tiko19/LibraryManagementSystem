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
    public partial class BooksView : Form
    {
        public BooksView()
        {
            InitializeComponent();
        }

        private void BooksView_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            BindingSource bindingSource1 = new BindingSource();
            Classes.BookClass tmp = new Classes.BookClass();
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = tmp.GetDataSet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form a1 = new BooksAdd();
            a1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Classes.BookClass tmp = new Classes.BookClass();
            Classes.BookClass.Book book = new Classes.BookClass.Book();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                tmp.ModifyBook(book);
            }
            MessageBox.Show("Records saved successfully!");
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Classes.BookClass tmp = new Classes.BookClass();
            Classes.BookClass.Book book = new Classes.BookClass.Book();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                book.ID = Convert.ToInt32(row.Cells[0].Value.ToString());
                tmp.DeleteBook(book);
                refresh();
            }
            MessageBox.Show("Record(s) deleted successfully!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Classes.BookClass tmp = new Classes.BookClass();
            Classes.BookClass.Book book = new Classes.BookClass.Book();
            string searchVal = textBox1.Text;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ClearSelection();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(searchVal))
                {
                    row.Selected = true;
                    break;
                }
            }
        }
    }
}
