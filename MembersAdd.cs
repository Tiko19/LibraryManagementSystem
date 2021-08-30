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
    public partial class MembersAdd : Form
    {
        public MembersAdd()
        {
            InitializeComponent();
        }

        private void reset()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                Classes.MemberClass tmp = new Classes.MemberClass();
                Classes.MemberClass.Member member = new Classes.MemberClass.Member();

                member.NationalID = textBox1.Text;
                member.FirstName = textBox2.Text;
                member.LastName = textBox3.Text;
                member.Mobile = textBox4.Text;

                if (tmp.CheckMember(member) == true)
                {
                    MessageBox.Show("Member already exists!");
                }
                else
                {
                    tmp.AddMember(member);
                }
            }
            reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
