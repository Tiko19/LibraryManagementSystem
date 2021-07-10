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
    class UserClass
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public class User
        {
            public int ID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }

        /******Method to load database******/
        public DataTable GetDataSet()
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    string load = "select * from Users";

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

        /******Method to check user password******/
        public bool CheckPass(User user)
        {
            bool result;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string checkPassword = "select * from Users where Username = @username and Password = @password";
                SqlCommand cmd = new SqlCommand(checkPassword, con);
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.Username;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = user.Password;
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

        public string CheckRole(User user)
        {
            string result;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string checkRole = "select Role from Users where Username = @username";
                SqlCommand cmd = new SqlCommand(checkRole, con);
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.Username;
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    result = sdr["Role"].ToString();
                }
                else
                {
                    result = "";
                }
                con.Close();
                return result;
            }
        }

        /******Method to check for user******/
        public bool CheckUser(User user)
        {
            bool result;

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string checkUsername = "select * from Users where Username = @username";
                SqlCommand cmd = new SqlCommand(checkUsername, con);
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.Username;
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

        /*************************Method to add record to database********************/
        public void UserAdd(User user)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string addUser = "insert into Users(Username, Password, Role) values(@username, @password, @role)";
                    SqlCommand cmd = new SqlCommand(addUser, con);
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.Username;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = user.Password;
                    cmd.Parameters.Add("@role", SqlDbType.NVarChar).Value = user.Role;
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

        /****************************Method to delete record*******************************/
        public void Delete(User user)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string del = "delete from Users where ID = @id";
                    SqlCommand cmd = new SqlCommand(del, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = user.ID;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! " + ex.ToString());
                }
            }
        }

        /*************************************Method to modify records****************************/
        public void Modify(User user)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string mod = "update users set Username = @username, Password = @password, Role = @role where ID = @id";
                    SqlCommand cmd = new SqlCommand(mod, con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = user.ID;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = user.Username;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = user.Password;
                    cmd.Parameters.Add("@role", SqlDbType.NVarChar).Value = user.Role;
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
    }
}