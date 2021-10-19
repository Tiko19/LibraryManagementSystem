using LibraryManagementSystem.Classes;
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
    public partial class UsersView : Form
    {
        private BindingSource bindingSource = new BindingSource();

        public UsersView()
        {
            InitializeComponent();
        }

        private void UsersView_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void reload()
        {
            UserClass tmp = new UserClass();
            dataGridView1.DataSource = bindingSource;
            bindingSource.DataSource = tmp.GetDataSet();

            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form a1 = new UsersAdd();
            a1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserClass temp = new UserClass();
            UserClass.User user = new UserClass.User();
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    user.ID = System.Convert.ToInt32(row.Cells[0].Value.ToString());
                    user.Username = row.Cells[1].Value.ToString();
                    user.Password = row.Cells[2].Value.ToString();
                    user.Role = row.Cells[3].Value.ToString();
                    temp.UserModify(user);
                    reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserClass temp = new UserClass();
            UserClass.User user = new UserClass.User();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    user.ID = System.Convert.ToInt32(row.Cells[0].Value.ToString());
                    user.Username = row.Cells[1].Value.ToString();
                    user.Password = row.Cells[2].Value.ToString();
                    user.Role = row.Cells[3].Value.ToString();
                    temp.UserDelete(user);
                    reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
