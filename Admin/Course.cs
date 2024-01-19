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

namespace StudentPerformanceTracker.Admin
{
    public partial class Course : Form
    {
        private DataTable CourseList = new DataTable();
        public static DataGridViewRow selectedRow;

        public Course()
        {
            InitializeComponent();
            displayData();
            LoadFilterBox();
            Filterbox.SelectedIndex = 0;
        }
        void LoadFilterBox() {
            Filterbox.Items.Add("Course ID");
            Filterbox.Items.Add("Course Name");
        }
        void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT CourseId,CourseName,CourseDescription FROM Courses";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(CourseList);
                        CList.DataSource = CourseList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Filterbox.SelectedIndex = 0;
            CList.DataSource = CourseList;
            coursesrctxt.Text = "";
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            searchData();
        }
        void searchData()
        {
            if (coursesrctxt.Text == "")
            {
                MessageBox.Show("Can't be blank");
                CList.DataSource = CourseList;
            }
            else
            {
                string filter = "";
                if (Filterbox.Text == "Course ID")
                {
                    filter = $"CourseID = {coursesrctxt.Text}";
                }
                else if (Filterbox.Text == "Course Name")
                {
                    filter = $"CourseName = '{coursesrctxt.Text}'";
                }
                string query = $"SELECT CourseId,CourseName,CourseDescription FROM Courses WHERE {filter}";

                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                CList.DataSource = dataTable;
                            }
                            else
                            {
                                MessageBox.Show("No matching course found.");
                                CList.DataSource = CourseList;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        private void AdminDashboardbtn_Click(object sender, EventArgs e)
        {
            new AdminForm().Show();
            this.Close();
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

        private void Subjectsbtn_Click(object sender, EventArgs e)
        {
            new SchoolSubjects().Show();
            this.Close();
        }

        private void AddCoursebtn_Click(object sender, EventArgs e)
        {
            new Add_Course().Show();
        }
    }
}
