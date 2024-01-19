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
using static System.Collections.Specialized.BitVector32;

namespace StudentPerformanceTracker.Admin
{
    public partial class AddStudent_Admin_ : Form
    {
        Students students = new Students();
        public static int section = 1;
        public AddStudent_Admin_()
        {
            InitializeComponent();
            Birthdate.Format = DateTimePickerFormat.Custom;
            Birthdate.CustomFormat = "MMMM dd, yyyy";
            LoadComboBoxItem();
        }

        private void AddStudent_Admin__Load(object sender, EventArgs e)
        {

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
                if (string.IsNullOrWhiteSpace(Firstnametxt.Text) || string.IsNullOrWhiteSpace(Lastnametxt.Text) || string.IsNullOrWhiteSpace(Addresstxt.Text) || string.IsNullOrWhiteSpace(Gendertxt.Text))
                {
                    MessageBox.Show(errormsg);
                }

                else if (CourseBox.Text == "")
                {
                    MessageBox.Show("Please select your course");
                }
                else if (Birthdate.Value > DateTime.Today.AddYears(-17))
                {
                    MessageBox.Show("Age must be 17 or above.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    students.Firstname = Firstnametxt.Text;
                    students.Middlename = Middlenametxt.Text;
                    students.Lastname = Lastnametxt.Text;
                    students.Address = Addresstxt.Text;
                    students.Birthdate = Birthdate.Value;
                    students.ContactNumber = ContactNumtxt.Text;
                    students.age = Convert.ToInt32(Agelbl.Text);
                    students.gender = Gendertxt.Text;
                    students.course = CourseBox.Text;
                    students.section = $"{YearComboBox.Text}-{Sectionlbl.Text}";
                    this.saveData(students);
                    MessageBox.Show("Saved Succesfully");
                    this.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void saveData(Students students)
        {
            try
            {
                string insertStudentQuery = $"INSERT INTO StudentInformation (Firstname, Middlename, Lastname, HomeAddress, ContactNum, Birthdate, Age, Gender, Course, Section) " +
                    $"VALUES (@Firstname, @Middlename, @Lastname, @Address, @ContactNumber, @Birthdate, @Age, @Gender, @Course, @Section)";

                string selectCountQuery = "SELECT COUNT(StudentID) FROM StudentInformation";



                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();

                    
                    using (SqlCommand command = new SqlCommand(insertStudentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Firstname", students.Firstname);
                        command.Parameters.AddWithValue("@Middlename", students.Middlename);
                        command.Parameters.AddWithValue("@Lastname", students.Lastname);
                        command.Parameters.AddWithValue("@Address", students.Address);
                        command.Parameters.AddWithValue("@ContactNumber", students.ContactNumber);
                        command.Parameters.AddWithValue("@Birthdate", students.Birthdate);
                        command.Parameters.AddWithValue("@Age", students.age);
                        command.Parameters.AddWithValue("@Gender", students.gender);
                        command.Parameters.AddWithValue("@Course", students.course);
                        command.Parameters.AddWithValue("@Section", students.section);

                        command.ExecuteNonQuery();
                    }
                   

                    using (SqlCommand command = new SqlCommand(selectCountQuery, connection))
                    {
                        students.StudentID = (int)command.ExecuteScalar();
                    }

                    string paddedID = students.StudentID.ToString("D4");
                    string username = $"{DateTime.Now.Year.ToString().Substring(2)}-{paddedID}";
                    string password = Birthdate.Value.ToString("MMddyyyy");
                    string insertUserQuery = $"INSERT INTO Users (Username, Password, Firstname, Lastname, UserRole) " +
                  $"VALUES ('{username}', '{password}', '{students.Firstname}', '{students.Lastname}', 3)";

                    
                    using (SqlCommand command = new SqlCommand(insertUserQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateAgeLabel()
        {
            DateTime birthDate = Birthdate.Value;
            int age = AgeCalculator(birthDate);
            Agelbl.Text = age.ToString();
        }
        int AgeCalculator(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;
            if (currentDate < birthDate.AddYears(age))
            {
                age--;
            }

            return age;
        }

        private void Birthdate_ValueChanged(object sender, EventArgs e)
        {
            UpdateAgeLabel();
        }
        void LoadComboBoxItem()
        {
            Gendertxt.Items.Add("Male");
            Gendertxt.Items.Add("Female");
            YearComboBox.Items.Add("1");
            YearComboBox.Items.Add("2");
            YearComboBox.Items.Add("3");
            YearComboBox.Items.Add("4");
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT CourseName FROM Courses";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CourseBox.Items.Add(reader["CourseName"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void AddStudent_Admin__FormClosed(object sender, FormClosedEventArgs e)
        {
            StudentsAdmin studentsAdmin = new StudentsAdmin();
            studentsAdmin.Hide();
            studentsAdmin.Show();
        }
        private void YearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sectionlbl.Text = students.section;
            if (CourseBox.Text != "")
            {
                try
                {
                    int studentCount;
                    string query = $"SELECT COUNT(StudentID) FROM StudentInformation WHERE Course = '{CourseBox.Text}' AND Section = '{YearComboBox.Text}-{students.section}'";

                    using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                    {
                        connection.Open();

                        using (SqlCommand countCommand = new SqlCommand(query, connection))
                        {
                            studentCount = (int)countCommand.ExecuteScalar();
                        }

                       
                        if (studentCount >= 5)
                        {  
                            if (int.TryParse(students.section, out int currentSection))
                            {
                                int newSection = currentSection += 1;
                                students.section = newSection.ToString();
                                Sectionlbl.Text = students.section;
                            }
                        }  
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in YearComboBox_SelectedIndexChanged: {ex.Message}\nStackTrace: {ex.StackTrace}");
                }
            }
            else
            {
                MessageBox.Show("Please select a Course");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Closebtn_Click_1(object sender, EventArgs e)
        {
           this.Close();
            
        }
    }
}
