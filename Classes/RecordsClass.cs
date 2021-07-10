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
    class RecordsClass
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public class Record
        {
            public int ID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }

        /******Method to load database******/
        public DataTable GetDataSet()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string load = "select * from Records";

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
        public void Add(Record record)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string addRecord = "insert into Books(ISBN, Title, Author, Genre, Edition, Copies) values(@isbn, @title, @author, @genre, @edition, @copies)";
                    SqlCommand cmd = new SqlCommand(addRecord, con);
                    cmd.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = record.ISBN;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = record.Title;
                    cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = record.Author;
                    cmd.Parameters.Add("@genre", SqlDbType.NVarChar).Value = record.Genre;
                    cmd.Parameters.Add("@edition", SqlDbType.NVarChar).Value = record.Edition;
                    cmd.Parameters.Add("@copies", SqlDbType.NVarChar).Value = record.Copies;
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
        public void Modify(Record record)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string mod = "update Books set ISBN = @isbn, Title = @title, Author = @author, Genre = @genre, Edition = @edition, Copies = @copies where ID = @id";
                    SqlCommand cmd = new SqlCommand(mod, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = record.ID;
                    cmd.Parameters.Add("@isbn", SqlDbType.NVarChar).Value =record.ISBN;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = record.Title;
                    cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = record.Author;
                    cmd.Parameters.Add("@genre", SqlDbType.NVarChar).Value = record.Genre;
                    cmd.Parameters.Add("@edition", SqlDbType.NVarChar).Value = record.Edition;
                    cmd.Parameters.Add("@copies", SqlDbType.NVarChar).Value = record.Copies;
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
        public void Delete(Record record)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string del = "delete from Records where ID = @id";
                    SqlCommand cmd = new SqlCommand(del, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = record.ID;
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
