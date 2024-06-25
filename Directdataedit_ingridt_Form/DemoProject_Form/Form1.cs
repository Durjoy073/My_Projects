using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DemoProject_Form
{
    public partial class Form1 : Form
    {

        DateTimePicker datetimepicker;
       // SqlConnection conn = new SqlConnection("Data Source=DESKTOP-G6BNDA0\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;");
        
        public Form1()
        {
            InitializeComponent();
            InitializeDateTimePicker();
        }

        private void InitializeDateTimePicker()
        {
            datetimepicker = new DateTimePicker();
            datetimepicker.Format = DateTimePickerFormat.Short;
            datetimepicker.Visible = false;
            datetimepicker.ValueChanged += new EventHandler(DPTextchange);
            dataGridView1.Controls.Add(datetimepicker);
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



        }

        //private void button2_Click(object sender, EventArgs e)


        //}

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void DPTextchange(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                dataGridView1.CurrentCell.Value = datetimepicker.Text.ToString();
            }


        }

        private void DPTclose(object sender, EventArgs e)
        {
            datetimepicker.Visible = false;
            
           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 4)
            {

                DateTimePicker dtp1 = new DateTimePicker();
                dataGridView1.Controls.Add(dtp1);
                dtp1.Format=DateTimePickerFormat.Custom;
                dtp1.CustomFormat= "dd/MM/yyyy";
                Rectangle displaycalender = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp1.Size = new Size(displaycalender.Width, displaycalender.Height);  
                dtp1.Location = new Point(displaycalender.X, displaycalender.Y);    




            }

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
            // TODO: This line of code loads data into the 'studentDBDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.studentDBDataSet.Students);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {

                Cursor.Current = Cursors.WaitCursor;
                studentsBindingSource.EndEdit();
                studentsTableAdapter.Update(this.studentDBDataSet.Students);
                MessageBox.Show("Successfully Saved");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");

            }
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete) 
            {
                if (MessageBox.Show("Delete this record?", "Message",MessageBoxButtons.YesNo, MessageBoxIcon.Question)  ==DialogResult.Yes)
                {
                    studentsBindingSource.RemoveCurrent();
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
