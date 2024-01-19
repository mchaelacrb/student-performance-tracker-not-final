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
    public partial class SchoolSubjects : Form
    {
        private DataTable SubjectList = new DataTable();
        public static DataGridViewRow selectedRow;
        public SchoolSubjects()
        {
            InitializeComponent();
            displayData();
            LoadFilterBox();
        }
        void LoadFilterBox()
        {
            Filterbox.Items.Add("Subject ID");
            Filterbox.Items.Add("Subject Department");
            Filterbox.Items.Add("Subject Name");
            Filterbox.Items.Add("Subject Code");
        }
        private void AddStudentbtn_Click(object sender, EventArgs e)
        {
            Add_Subject add = new Add_Subject();
            add.Show();
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Filterbox.SelectedIndex = 0;
            SubList.DataSource = SubjectList;
            subjectsrctxt.Text = "";
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {

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


        private void Coursesbtn_Click(object sender, EventArgs e)
        {
            new Course().Show();
            this.Close();
        }
        void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT SubjectId as 'Subject ID',SubjectDepartment as 'Department', SubjectCode as 'Subject Code',SubjectName as 'Subject Name',SubjectDescription as 'Subject Description' FROM Subjects";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(SubjectList);
                        SubList.DataSource = SubjectList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }
        void searchData()
        {
            if (subjectsrctxt.Text == "")
            {
                MessageBox.Show("Can't be blank");
                SubList.DataSource = SubjectList;
            }
            else
            {
                string filter = "";
                if (Filterbox.Text == "Subject ID")
                {
                    filter = $"Subjectid = {subjectsrctxt.Text}";
                }
                else if (Filterbox.Text == "Subject Department")
                {
                    filter = $"SubjectDepartment = '{subjectsrctxt.Text}'";
                }
                else if (Filterbox.Text == "Subject Name")
                {
                    filter = $"SubjectName = '{subjectsrctxt.Text}'";
                }
                else if (Filterbox.Text == "Subject Code")
                {
                    filter = $"SubjectCode = '{subjectsrctxt.Text}'";
                }
                string query = $"SELECT SubjectId as 'Subject ID',SubjectDepartment as 'Department',SubjectCode as 'Subject Code',SubjectName as 'Subject Name',SubjectDescription as 'Subject Description' FROM Subjects WHERE {filter}";

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
                                SubList.DataSource = dataTable;
                            }
                            else
                            {
                                MessageBox.Show("No matching subject found.");
                                SubList.DataSource = SubjectList;
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

       
    }
}
