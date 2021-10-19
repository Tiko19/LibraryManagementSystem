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
    class MemberClass
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public class Member
        {
            public int ID { get; set; }
            public string NationalID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Mobile { get; set; }
        }

        /******Method to load database******/
        public DataTable GetDataSet()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string load = "select * from Members";

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

        public List<int> getMemberID()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    List<int> result = new List<int>();
                    string load = "select ID from Books";
                    SqlCommand cmd = new SqlCommand(load, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Member member = new Member();
                            member.ID = rdr.GetInt32(0);

                            result.Add(member.ID);
                        }
                        con.Close();
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
            }
        }

        /******Method to check for member******/
        public bool CheckMember(Member member)
        {
            bool result;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string checkID = "select * from Members where NationalID = @nationalID";
                SqlCommand cmd = new SqlCommand(checkID, con);
                cmd.Parameters.Add("@nationalID", SqlDbType.NVarChar).Value = member.NationalID;
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                con.Close();
                return result;
            }

        }

        /******Method to add record to database******/
        public void AddMember(Member member)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string addMember = "insert into Members(NationalID, FirstName, LastName, Mobile) values(@nationalID, @firstname, @lastname, @mobile)";
                    SqlCommand cmd = new SqlCommand(addMember, con);
                    cmd.Parameters.Add("@nationalID", SqlDbType.NVarChar).Value = member.NationalID;
                    cmd.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = member.FirstName;
                    cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = member.LastName;
                    cmd.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = member.Mobile;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Member added Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.ToString());
                }
            }
        }

        /******Method to modify records******/
        public void MemberModify(Member member)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string mod = "update users set NationalID = @nationalID, Firstname = @firstname, Lastname = @lastname, Mobile = @mobile where ID = @id";
                    SqlCommand cmd = new SqlCommand(mod, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = member.ID;
                    cmd.Parameters.Add("@nationalID", SqlDbType.NVarChar).Value = member.NationalID;
                    cmd.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = member.FirstName;
                    cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = member.LastName;
                    cmd.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = member.Mobile;
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
        public void MemberDelete(Member member)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string del = "delete from Members where ID = @id";
                    SqlCommand cmd = new SqlCommand(del, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = member.ID;
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
