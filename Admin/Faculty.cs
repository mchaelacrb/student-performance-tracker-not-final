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
    public partial class Faculty : Form
    {
        private DataTable TeacherList = new DataTable();
        public static DataGridViewRow selectedRow;
        public Faculty()
        {
            InitializeComponent();
            displayData();
            LoadFilterBoxItems();
            Filterbox.SelectedIndex = 0;
        }
        void LoadFilterBoxItems() {
            Filterbox.Items.Add("Teacher ID");
            Filterbox.Items.Add("First Name");
            Filterbox.Items.Add("Last Name");
            Filterbox.Items.Add("Department");  
            Filterbox.Items.Add("Subject");
        }
        private void regs_teacher_Click(object sender, EventArgs e)
        {
            Add_Teacher add_Teacher = new Add_Teacher();
            add_Teacher.Show();
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            searchData();
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Filterbox.SelectedIndex = 0;
            TList.DataSource = TeacherList;
            FacultySearchtxt.Text = "";
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
        void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TeacherId as 'TeacherID',CONCAT(FirstName, ' ', LastName) AS 'Teacher Name',Departement as 'Department',Subject FROM Teachers";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(TeacherList);
                        TList.DataSource = TeacherList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void TList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTeacher updateTeacher = new UpdateTeacher();
            updateTeacher.idtxt.Text = TList.CurrentRow.Cells[0].Value.ToString();
            string concatenatedName = TList.CurrentRow.Cells["Teacher Name"].Value?.ToString() ?? "";
            string[] nameComponents = concatenatedName.Split(' ');
            string firstName = "";
            string lastName = "";
            if (nameComponents.Length == 4)
            {
                firstName = $"{nameComponents[0]} {nameComponents[1]} {nameComponents[2]}";
                lastName = nameComponents[3];
            }
            else if (nameComponents.Length == 3)
            {
                firstName = $"{nameComponents[0]} {nameComponents[1]}";
                lastName = nameComponents[2];
            }
            else if (nameComponents.Length == 2)
            {
                firstName = $"{nameComponents[0]}";
                lastName = nameComponents[1];
            }
            updateTeacher.t_first.Text = firstName;
            updateTeacher.t_last.Text = lastName;
            updateTeacher.t_dep.Text = TList.CurrentRow.Cells[2].Value.ToString();
            updateTeacher.t_sub.Text = TList.CurrentRow.Cells[3].Value.ToString();
            updateTeacher.ShowDialog();
        }
        void searchData()
        {
            if (FacultySearchtxt.Text == "")
            {
                MessageBox.Show("Can't be blank");
                TList.DataSource = TeacherList;
            }
            else
            {
                string filter = "";
                if (Filterbox.Text == "Teacher ID")
                {
                    filter = $"Teacherid = {FacultySearchtxt.Text}";
                }
                else if (Filterbox.Text == "First Name")
                {
                    filter = $"Firstname = '{FacultySearchtxt.Text}'";
                }
                else if (Filterbox.Text == "Last Name")
                {
                    filter = $"LastName = '{FacultySearchtxt.Text}'";
                }
                else if (Filterbox.Text == "Department")
                {
                    filter = $"Departement = '{FacultySearchtxt.Text}'";
                }
                else if (Filterbox.Text == "Subject")
                {
                    filter = $"Subject = '{FacultySearchtxt.Text}'";
                }
                string query = $"SELECT TeacherId as 'TeacherID',CONCAT(FirstName, ' ', LastName) AS 'Teacher Name',Departement,Subject FROM Teachers WHERE {filter}";

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
                                TList.DataSource = dataTable;
                            }
                            else
                            {
                                MessageBox.Show("No matching techer found.");
                                TList.DataSource = TeacherList;
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
