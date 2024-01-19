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

namespace StudentPerformanceTracker.Admin
{
    public partial class Add_Course : Form
    {
        Courses courses = new Courses();
        
        public Add_Course()
        {
            InitializeComponent();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            string errormsg = "Textbox can't be blank";
            try
            {
                if (c_name.Text == "")
                {
                    MessageBox.Show(errormsg);
                }
                else if (c_description.Text == "")
                {
                    MessageBox.Show(errormsg);
                }
                else
                {
                    courses.CourseName = c_name.Text;
                    courses.CourseDescription = c_description.Text;
                    this.saveData(courses);
                    MessageBox.Show("Saved Succesfully");
                    this.Hide();
                   Course admin_CourseManagement = new Course();
                    admin_CourseManagement.Show();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void saveData(Courses courses)
        {
            try
            {
                string query = $"INSERT INTO Courses (CourseName,CourseDescription) " +
                    $"VALUES ('{courses.CourseName}', '{courses.CourseDescription}');";

                SqlConnection connection = new SqlConnection(new LogIn().connectionstring);
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
