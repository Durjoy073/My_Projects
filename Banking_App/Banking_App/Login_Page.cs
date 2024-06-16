using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_App
{
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();
           
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G6BNDA0\\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;");
            conn.ConnectionString = ("Data Source=DESKTOP-G6BNDA0\\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;");
            string username = textBox1.Text;
            string password = textBox2.Text;

            string query = "select * from Admin_Table where User_Name=@user and Password=@pass";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("user", username));
            cmd.Parameters.Add(new SqlParameter("pass", password)); 
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            if (username!=String.Empty || password!=string.Empty)
            {
                //Rows will return if there is a matching where condition satisfied
                if (reader.HasRows == true)
                {
                    Menu menu = new Menu();
                    menu.Show();
                }

                else
                {
                    MessageBox.Show("Please Enter Username and Passwod correctly.");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Username and Passwod.");
            }

            conn.Close();
        }
    }
}
