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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

    }

       static string conn = "Data Source = . ; Initial Catalog =DB_contact ; user id = sqluser ; password = 123456 ; connect timeout=15; ";
       // SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection sqlconn = new SqlConnection(conn);


        private void button1_Click(object sender, EventArgs e)
        {
            if(txtusername.Text=="" && txtpassword.Text == "" && txtConPassword.Text == "")
            {
                MessageBox.Show("user name and password fields are empty", "Registraion failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (txtpassword.Text == txtConPassword.Text)
            {
                sqlconn.Open();
                string register = "insert into T_login values('"+txtusername.Text + "','" + txtpassword.Text+",')";

                da.InsertCommand = new SqlCommand(register, sqlconn);
                da.InsertCommand.ExecuteNonQuery();

                sqlconn.Close();

                txtusername.Text = "";
                txtpassword.Text = "";
                txtConPassword.Text = "";

                MessageBox.Show("your account has been successfully created", "Registraion success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("password doesn't match", "Registraion failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Text = "";
                txtConPassword.Text = "";
                txtpassword.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtConPassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
                txtConPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtConPassword.Text = "";
            txtusername.FindForm();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        
       
    }
}
