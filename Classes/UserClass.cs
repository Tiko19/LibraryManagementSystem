using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.Classes
{
    class UserClass
    {
        private MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=schoolsystem");

        /******Method to load database******/
        public DataTable GetDataSet()
        {
            try
            {
                string load = "select * from users";

                MySqlDataAdapter adp = new MySqlDataAdapter(load, con);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adp);

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

        /******Method to check user password******/
        public bool CheckPass(string str1, string str2)
        {
            bool result;

            con.Open();
            string checkPassword = "select * from users where username = @username and password = @password";
            MySqlCommand cmd = new MySqlCommand(checkPassword, con);
            cmd.Parameters.Add("@username", System.Data.MySqlDbType.NVarChar).Value = user.UserID;
            cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = user.Password;
            MySqlDataReader sdr = cmd.ExecuteReader();

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

        /******Method to check for user******/
        public bool CheckUser(string str1)
        {
            bool result;

            con.Open();
            string checkUsername = "select * from users where username='" + str1 + "'";
            MySqlCommand cmd = new MySqlCommand(checkUsername, con);
            MySqlDataReader sdr = cmd.ExecuteReader();

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

        /*************************Method to add record to database********************/
        public void Add(string str1, string str2)
        {
            try
            {
                con.Open();
                string addUser = "insert into users(username,password) values(@username,@password)";
                MySqlCommand cmd = new MySqlCommand(addUser, con);
                cmd.Parameters.AddWithValue("@username", str1);
                cmd.Parameters.AddWithValue("@password", str2);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("User added Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        /****************************Method to delete record*******************************/
        public void Delete(string str1)
        {
            try
            {
                con.Open();
                string del = "delete from users where username='" + str1 + "'";
                MySqlCommand cmd = new MySqlCommand(del, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        /*************************************Method to modify records****************************/
        public void Modify(string str0, string str1, string str2)
        {
            try
            {
                con.Open();
                string mod = "update users set username='" + str1 + "', password='" + str2 + "' where id='" + Convert.ToInt32(str0) + "'";
                MySqlCommand cmd = new MySqlCommand(mod, con);
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