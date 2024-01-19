using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPerformanceTracker.Teacher
{
    public partial class StudentList : Form
    {
        public DataTable STList = new DataTable();

        public StudentList()
        {
            InitializeComponent();
            displayData();
        }

        private void StudentList_Load(object sender, EventArgs e)
        {

        }
        public void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT StudentID, CONCAT(Firstname, ' ', Lastname) AS Name
FROM StudentInformation;
";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(STList);
                        Students.DataSource = STList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void AdminDashboardbtn_Click(object sender, EventArgs e)
        {
            TeacherForm form = new TeacherForm();
            form.Show();
            this.Close();   
        }

        private void AccountsBtn_Click(object sender, EventArgs e)
        {
            GradeSheet gradeSheet = new GradeSheet();
            gradeSheet.Show();
            this.Close();
        }

        private void StudentsBtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
