using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DemoProject_Form
{
    public partial class Form1 : Form
    {

        // SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G6BNDA0\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;");
        private SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
           conn = new SqlConnection("Data Source=DESKTOP-G6BNDA0\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           // SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G6BNDA0\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;");
            conn.Open();
            SqlTransaction transaction= conn.BeginTransaction(); 
            try
            {

                SqlCommand cmd = new SqlCommand("insert into Students(Name, Age, Department, Date) values(@Name, @Age, @Department, @Date)", conn);
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Age", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Department", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
               


                SqlCommand cmd2 = new SqlCommand("insert into Course(Course_id, Course_Title,Course_Credit) values(@c_id, @c_title, @c_credit)", conn);
                cmd2.Transaction = transaction;

                cmd2.Parameters.AddWithValue("@c_id", textBox3.Text);
                cmd2.Parameters.AddWithValue("@c_title", textBox4.Text);
                cmd2.Parameters.AddWithValue("@c_credit", float.Parse(textBox5.Text));
             
                cmd2.ExecuteNonQuery();
                transaction.Commit();


                conn.Close();

                MessageBox.Show("Succesfully Added.");
            }
            
            catch (Exception ex)
            {

                MessageBox.Show("Error!"+ex.Message);

                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollbackEx)
                {
                    Console.WriteLine("Rollback Error: " + rollbackEx.Message);
                }

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G6BNDA0\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Students",conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource=dt;


            SqlCommand cmd2= new SqlCommand("select * from Course", conn);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapter.Fill(dt2);
            dataGridView2.DataSource = dt2;
            conn.Close( );  
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDBDataSet.Courses' table. You can move, or remove it, as needed.
            this.coursesTableAdapter.Fill(this.studentDBDataSet.Course);
            // TODO: This line of code loads data into the 'studentDBDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.studentDBDataSet.Students);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
