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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
            {
                Classes.BookClass tmp = new Classes.BookClass();
                Classes.BookClass.Book book = new Classes.BookClass.Book();

                book.ISBN = textBox1.Text;
                book.Title = textBox2.Text;
                book.Author = textBox3.Text;
                book.Genre = textBox4.Text;
                book.Edition = textBox5.Text;

                tmp.AddBook(book);
                MessageBox.Show("Book added successfully!");
                reset();
            }
            else
            {
                MessageBox.Show("Invalid input!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BooksAdd_Load(object sender, EventArgs e)
        {
            reset();
        }
    }
}
