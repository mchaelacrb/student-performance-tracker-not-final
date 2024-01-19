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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentPerformanceTracker.Admin
{
    public partial class StudentsAdmin : Form
    {
        public DataTable StudList = new DataTable();
        public static DataGridViewRow selectedRow;
        public StudentsAdmin()
        {
            InitializeComponent();
            Clearbtn.FlatAppearance.BorderSize = 0;
            Filterbox.Items.Clear();
            LoadDataFilterComboBox();
            Filterbox.SelectedIndex = 0;
        }
        private void LoadDataFilterComboBox()
        {
            Filterbox.Items.Add("Student ID");
            Filterbox.Items.Add("First Name");
            Filterbox.Items.Add("Last Name");
            Filterbox.Items.Add("Course");
            Filterbox.Items.Add("Section");
        }
        private void AddStudentbtn_Click(object sender, EventArgs e)
        {
            AddStudent_Admin_ add = new AddStudent_Admin_();
            add.Show();
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            searchData();
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Filterbox.SelectedIndex = 0;
            Studlist.DataSource = StudList;
            StudentSearchtxt.Text = "";
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
        private void Sectionsbtn_Click(object sender, EventArgs e)
        {
            new SchoolSubjects().Show();
            this.Close();
        }

        public void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT  FORMAT(StudentID, '0000') AS 'StudentID', FirstName as 'First Name',MiddleName " +
                        "as 'Middle Name' , LastName as 'Last Name', Course,Section, HomeAddress AS 'Address', ContactNum as " +
                        "'Contact Number',Birthdate, Age, Gender  FROM StudentInformation;";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(StudList);
                        Studlist.DataSource = StudList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void Studlist_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateStudentInfo update = new UpdateStudentInfo();

            if (Studlist.SelectedRows.Count > 0)
            {
                selectedRow = Studlist.Rows[e.RowIndex];
                string firstName = selectedRow.Cells["First Name"].Value?.ToString() ?? "";
                string middleName = selectedRow.Cells["Middle Name"].Value?.ToString() ?? "";
                string lastName = selectedRow.Cells["Last Name"].Value?.ToString() ?? "";
                string Course = selectedRow.Cells["Course"].Value?.ToString() ?? "";
                string YearAndSection = selectedRow.Cells["Section"].Value?.ToString() ?? "";
                string[] SectionSplit = YearAndSection.Split('-');
                string Yearlvl = "";
                string Section = "";
                if (SectionSplit.Length == 2)
                {
                    Yearlvl = SectionSplit[0];
                    Section = SectionSplit[1];
                }
                string Address = selectedRow.Cells["Address"].Value?.ToString() ?? "";
                string Contact = selectedRow.Cells["Contact Number"].Value?.ToString() ?? "";
                DateTime Birthdate = Convert.ToDateTime(selectedRow.Cells["Birthdate"].Value);
                string age = selectedRow.Cells["Age"].Value?.ToString() ?? "";
                string gender = selectedRow.Cells["Gender"].Value?.ToString() ?? "";


                update.loadData(firstName, middleName, lastName, Course, Yearlvl, Section, Address, Contact, Birthdate, age, gender);
                update.Show();
            }
        }
        void searchData()
        {
            if (StudentSearchtxt.Text == "")
            {
                MessageBox.Show("Can't be blank");
                Studlist.DataSource = StudList;
            }
            else
            {
                string filter = "";
                if (Filterbox.Text == "Student ID")
                {
                    filter = $"StudentID = {StudentSearchtxt.Text}";
                }
                else if (Filterbox.Text == "First Name")
                {
                    filter = $"Firstname = '{StudentSearchtxt.Text}'";
                }
                else if (Filterbox.Text == "Last Name")
                {
                    filter = $"Lastname = '{StudentSearchtxt.Text}'";
                }
                else if (Filterbox.Text == "Course")
                {
                    filter = $"Course = '{StudentSearchtxt.Text}'";
                }
                else if (Filterbox.Text == "Section")
                {
                    filter = $"Section = '{StudentSearchtxt.Text}'";
                }
                string query = $"SELECT  FORMAT(StudentID, '0000') AS 'StudentID', CONCAT(Firstname, ' ', Middlename, ' ', Lastname) AS 'Student Name', Course, Section " +
                      $"FROM StudentInformation where {filter}";
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
                                Studlist.DataSource = dataTable;
                            }
                            else
                            {
                                MessageBox.Show("No matching student found.");
                                Studlist.DataSource = null;
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

        private void StudentsAdmin_Load(object sender, EventArgs e)
        {
            displayData();
            Studlist.DataSource = StudList;
        }

       
    }// class
} // namespace
