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
            public int RecordID { get; set; }
            public int MemberID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ReturnDate { get; set; }
            public string IssuedBy { get; set; }
            public string CollectedBy { get; set; }
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
        public void RecordAdd(Record record)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string addRecord = "insert into Books(MemberID, FirstName, LastName, ISBN, Title, Author, IssueDate, ReturnDate, IssuedBy, CollectedBy) values(@memberID, @firstName, @lastName, @isbn, @title, @author, @issueDate, @returnDate, @issuedBy, @collectedBy)";
                    SqlCommand cmd = new SqlCommand(addRecord, con);
                    cmd.Parameters.Add("@memberID", SqlDbType.NVarChar).Value = record.MemberID;
                    cmd.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = record.FirstName;
                    cmd.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = record.LastName;
                    cmd.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = record.ISBN;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = record.Title;
                    cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = record.Author;
                    cmd.Parameters.Add("@issueDate", SqlDbType.DateTime).Value = record.IssueDate;
                    cmd.Parameters.Add("@returnDate", SqlDbType.DateTime).Value = record.ReturnDate;
                    cmd.Parameters.Add("@issuedBy", SqlDbType.NVarChar).Value = record.IssuedBy;
                    cmd.Parameters.Add("@collectedBy", SqlDbType.NVarChar).Value = record.CollectedBy;
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
        public void RecordModify(Record record)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string mod = "update Books set MemberID = @memberID, FirstName = @firstname, ISBN = @isbn, Title = @title, Author = @author, IssueDate = @issueDate, ReturnDate = @returnDate, CollectedBy = @collectedBy where ID = @recordID";
                    SqlCommand cmd = new SqlCommand(mod, con);
                    cmd.Parameters.Add("@recordID", SqlDbType.NVarChar).Value = record.RecordID;
                    cmd.Parameters.Add("@memberID", SqlDbType.NVarChar).Value = record.MemberID;
                    cmd.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = record.FirstName;
                    cmd.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = record.LastName;
                    cmd.Parameters.Add("@isbn", SqlDbType.NVarChar).Value = record.ISBN;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = record.Title;
                    cmd.Parameters.Add("@author", SqlDbType.NVarChar).Value = record.Author;
                    cmd.Parameters.Add("@issueDate", SqlDbType.DateTime).Value = record.IssueDate;
                    cmd.Parameters.Add("@returnDate", SqlDbType.DateTime).Value = record.ReturnDate;
                    cmd.Parameters.Add("@issuedBy", SqlDbType.NVarChar).Value = record.IssuedBy;
                    cmd.Parameters.Add("@collectedBy", SqlDbType.NVarChar).Value = record.CollectedBy;
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
        public void RecordDelete(Record record)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string del = "delete from Records where ID = @recordID";
                    SqlCommand cmd = new SqlCommand(del, con);
                    cmd.Parameters.Add("@recordID", SqlDbType.Int).Value = record.RecordID;
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
