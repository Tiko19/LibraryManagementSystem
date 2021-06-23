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
    class MemberClass
    {
        private MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=schoolsystem");

        /******Method to load database******/
        public DataTable GetDataSet()
        {
            try
            {
                string load = "select * from students";

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

        /******Method to add record to database******/
        public void Add(string str1, string str2, string str3, string str4, string str5, string str6, string str7, string str8)
        {
            try
            {
                string image = str8;
                Bitmap bmp = new Bitmap(image);
                FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
                byte[] bimage = new byte[fs.Length];
                fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
                fs.Close();

                con.Open();
                string addClient = "insert into students(firstname,lastname,sex,dob,grade,address,contact,picture) values(@firstname,@lastname,@sex,@dob,@grade,@address,@contact,@picture)";
                MySqlCommand cmd = new MySqlCommand(addClient, con);
                cmd.Parameters.AddWithValue("@firstname", str1);
                cmd.Parameters.AddWithValue("@lastname", str2);
                cmd.Parameters.AddWithValue("@sex", str3);
                cmd.Parameters.AddWithValue("@dob", str4);
                cmd.Parameters.AddWithValue("@grade", str5);
                cmd.Parameters.AddWithValue("@address", str6);
                cmd.Parameters.AddWithValue("@contact", str7);
                cmd.Parameters.AddWithValue("@picture", bimage);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student has been added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        /******Method to modify records******/
        public void Modify(string str0, string str1, string str2, string str3, string str4, string str5, string str6, string str7)
        {
            try
            {
                con.Open();
                string mod = "update students set firstname='" + str1 + "', lastname='" + str2 + "',sex='" + str3 + "',dob='" + str4 + "',grade='" + str5 + "',address='" + str6 + "',contact='" + str7 + "' where id='" + Convert.ToInt32(str0) + "'";
                MySqlCommand cmd = new MySqlCommand(mod, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        /******Method to delete record******/
        public void Delete(string str1)
        {
            try
            {
                con.Open();
                string del = "delete from students where id='" + Convert.ToInt32(str1) + "'";
                MySqlCommand cmd = new MySqlCommand(del, con);
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
