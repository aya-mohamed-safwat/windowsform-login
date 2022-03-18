using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows;


namespace test4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        static string conn = "Data Source = . ; Initial Catalog =DB_contact ; user id = sqluser ; password = 123456 ; connect timeout=15; ";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection sqlconn = new SqlConnection(conn);

        private void button1_Click(object sender, EventArgs e)
        {
            sqlconn.Open();
            string login = "select from  T_login where username = '" + txtusername.Text + "' and password= '" + txtpassword.Text + "'";
            cmd = new SqlCommand(login, sqlconn);
            

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read() == true)
                {
                    new Form3().Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("invaild username or password, please try again", "login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    txtusername.Text = "";
                    txtpassword.Text = "";
                    txtusername.Focus();

                }
            }
            catch (Exception)
            {

            }
            sqlconn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtusername.Focus();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.PasswordChar = '\0';
               
            }
            else
            {
                txtpassword.PasswordChar = '*';
               
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    }
}
