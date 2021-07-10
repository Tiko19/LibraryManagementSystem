using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Classes
{
    class BookClass
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public class Book
        {
            public int ID { get; set; }
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public string Edition { get; set; }
            public string Copies { get; set; }
        }

        /******Method to load database******/
        public DataTable GetDataSet()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string load = "select * from Books";

                    SqlDataAdapter adp = new SqlDataAdapter(load, con);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adp);

                    DataTable table = new DataTable();
                    adp.Fill(table);
                    return table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
            }
        }

        /******Method to add record to database******/
        public void BookAdd(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string addBook = "insert into Books(ISBN, Title, Author, Genre, Edition, Copies) values(@isbn, @title, @author, @genre, @edition, @copies)";
                    SqlCommand cmd = new SqlCommand(addBook, con);
                    cmd.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = book.ISBN;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = book.Title;
                    cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = book.Author;
                    cmd.Parameters.Add("@genre", SqlDbType.NVarChar).Value = book.Genre;
                    cmd.Parameters.Add("@edition", SqlDbType.NVarChar).Value = book.Edition;
                    cmd.Parameters.Add("@copies", SqlDbType.NVarChar).Value = book.Copies;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User added Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.ToString());
                }
            }
        }

        /******Method to modify records******/
        public void Modify(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string mod = "update Books set ISBN = @isbn, Title = @title, Author = @author, Genre = @genre, Edition = @edition, Copies = @copies where ID = @id";
                    SqlCommand cmd = new SqlCommand(mod, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = book.ID;
                    cmd.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = book.ISBN;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = book.Title;
                    cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = book.Author;
                    cmd.Parameters.Add("@genre", SqlDbType.NVarChar).Value = book.Genre;
                    cmd.Parameters.Add("@edition", SqlDbType.NVarChar).Value = book.Edition;
                    cmd.Parameters.Add("@copies", SqlDbType.NVarChar).Value = book.Copies;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record(s) saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.ToString());
                }
            }
        }

        /******Method to delete record******/
        public void Delete(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string del = "delete from Books where ID = @id";
                    SqlCommand cmd = new SqlCommand(del, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = book.ID;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.ToString());
                }
            }
        }
    }
}