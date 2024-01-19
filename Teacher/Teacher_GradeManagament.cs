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

namespace OOP_System
{
    public partial class Teacher_GradeManagament : Form
    {
        private DataTable StudList = new DataTable();
        public Teacher_GradeManagament()
        {
            InitializeComponent();
        }

        private void AddStudentbtn_Click(object sender, EventArgs e)
        {
            Add_Record add_Record = new Add_Record();
           
            add_Record.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            GradeWeight gradeWeight = new GradeWeight();
            this.Hide();
            gradeWeight.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentSearchtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Studlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Teacher_GradeManagament teacher_GradeManagament = new Teacher_GradeManagament();
            this.Hide();
            teacher_GradeManagament.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher_CourseMaterials teacher_CourseMaterials = new Teacher_CourseMaterials();
            this.Hide();
            teacher_CourseMaterials.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher_StudentList teacher_StudentList = new Teacher_StudentList();    
            this.Hide();
            teacher_StudentList.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher_DashBoard teacher_DashBoard = new Teacher_DashBoard();
            this.Hide();
            teacher_DashBoard.Show();
        }
        void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT StudentID, CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS 'Student Name', Course, Section FROM StudentInformation";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(StudList);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void Teacher_GradeManagament_Load(object sender, EventArgs e)
        {
            displayData();
            Studlist.DataSource = StudList;
        }

        private void Studlist_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WrittenRecord writtenRecord = new WrittenRecord();
            writtenRecord.Show();
            this.Hide();
        }
    }
}
