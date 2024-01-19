using StudentPerformanceTracker.Admin;
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

namespace StudentPerformanceTracker
{
    public partial class AdminForm : Form
    {
        private UserControl activeForm;
        public AdminForm()
        {
            InitializeComponent();
            countStudent();
            countCourse();
            countFaculty();
        }
        private void AccountsBtn_Click(object sender, EventArgs e)
        {
            new Accounts().Show();
            this.Close();
        }
        private void StudentsBtn_Click(object sender, EventArgs e)
        {
            new StudentsAdmin().Show();
            this.Close();
        }
        private void Facultybtn_Click(object sender, EventArgs e)
        {
            new Faculty().Show();
            this.Close();
        }

        private void Coursesbtn_Click(object sender, EventArgs e)
        {
            new Course().Show();
            this.Close();
        }
        private void Subjectsbtn_Click(object sender, EventArgs e)
        {
            new SchoolSubjects().Show();
            this.Close();
        }
        private void LogOutbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            new LogIn().Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        void countStudent()
        {
            string query = "SELECT COUNT(*) AS StudentCount FROM StudentInformation;";

            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int studentCount = Convert.ToInt32(reader["StudentCount"]);

                        // Assuming 'per_weight' is a TextBox control
                        s_list.Text = studentCount.ToString();
                    }

                    reader.Close();
                }
            }

        }

        void countCourse()
        {
            string query = "SELECT COUNT(*) AS CourseCount FROM Courses;";

            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int studentCount = Convert.ToInt32(reader["CourseCount"]);

                        // Assuming 'per_weight' is a TextBox control
                        c_list.Text = studentCount.ToString();
                    }

                    reader.Close();
                }
            }



        }
        void countFaculty()
        {
            string query = "SELECT COUNT(*) AS TeacherCount FROM Teachers;";

            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int studentCount = Convert.ToInt32(reader["TeacherCount"]);

                        // Assuming 'per_weight' is a TextBox control
                        f_list.Text = studentCount.ToString();
                    }

                    reader.Close();
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void s_list_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}

