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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentPerformanceTracker.Admin
{
    public partial class UpdateStudentInfo : Form
    {
        public static StudentsAdmin studentAdmin = new StudentsAdmin();
        public static Students students = new Students();
        public string section;
        public UpdateStudentInfo()
        {
            InitializeComponent();
            Birthdate.Format = DateTimePickerFormat.Custom;
            Birthdate.CustomFormat = "MMMM dd, yyyy";
            LoadComboBoxItem();
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            updateData();
            this.Close();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                deleteData();          
            }
        }
        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Birthdate_ValueChanged(object sender, EventArgs e)
        {
            UpdateAgeLabel();
        }
        public void loadData(string firstName, string middleName, string lastName, string Course,string Yearlvl, string Section, string Address,
            string Contact, DateTime BirthDate, string age, string Gender)
        {
            Firstnametxt.Text = firstName;
            Middlenametxt.Text = middleName;
            Lastnametxt.Text = lastName; 
            Addresstxt.Text = Address;
            ContactNumtxt.Text = Contact;
            Birthdate.Value = BirthDate;
            Gendertxt.Text = Gender;
            Agelabel.Text = age;
            CourseBox.Text = Course;
            YearComboBox.Text = Yearlvl;
            Sectionlbl.Text = Section;
        }
        public void updateData()
        {
            
            string UsersAccquery = "UPDATE Users SET Firstname = @NewFirstName, Lastname = @NewLastName WHERE Firstname = @OldFirstName AND Lastname = @OldLastName";
            SqlConnection connection = new SqlConnection(new LogIn().connectionstring);
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(UsersAccquery, connection))
            {
                cmd.Parameters.AddWithValue("@NewFirstName", Firstnametxt.Text);
                cmd.Parameters.AddWithValue("@NewLastName", Middlenametxt.Text);
                cmd.Parameters.Add("@OldFirstName", SqlDbType.VarChar).Value = StudentsAdmin.selectedRow.Cells[1].Value?.ToString() ?? "";
                cmd.Parameters.Add("@OldLastName", SqlDbType.VarChar).Value = StudentsAdmin.selectedRow.Cells[3].Value?.ToString() ?? "";
                cmd.ExecuteNonQuery();
            }
            string query = "UPDATE StudentInformation SET Firstname = @FirstName, Middlename = @MiddleName, Lastname = @LastName, HomeAddress = @HomeAddress, ContactNum = @ContactNum," +
             "Birthdate = @Birthdate, Age = @Age, Gender = @Gender, Course = @Course, Section = @Section WHERE StudentID = @StudentID";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@StudentID", SqlDbType.Int).Value = Convert.ToInt32(StudentsAdmin.selectedRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@FirstName", Firstnametxt.Text);
                cmd.Parameters.AddWithValue("@MiddleName", Middlenametxt.Text);
                cmd.Parameters.AddWithValue("@LastName", Lastnametxt.Text);
                cmd.Parameters.AddWithValue("@HomeAddress", Addresstxt.Text);
                cmd.Parameters.AddWithValue("@ContactNum", ContactNumtxt.Text);
                cmd.Parameters.AddWithValue("@Birthdate", Birthdate.Value);
                cmd.Parameters.AddWithValue("@Age", Agelabel.Text);
                cmd.Parameters.AddWithValue("@Gender", Gendertxt.Text);
                cmd.Parameters.AddWithValue("@Course", CourseBox.Text);
                cmd.Parameters.AddWithValue("@Section", $"{YearComboBox.Text}-{Sectionlbl.Text}");
                cmd.ExecuteNonQuery();
            }
            connection.Close();
            MessageBox.Show("Data updated successfully!");
        }
        void deleteData()
        {
           
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();

                    string query = "DELETE FROM StudentInformation WHERE StudentID = @StudentID ;";
                        
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = Convert.ToInt32(StudentsAdmin.selectedRow.Cells[0].Value);                        

                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();

                    string DeleteUserquery = "DELETE FROM Users WHERE Firstname = @Firstname " +
                        "AND Lastname = @Lastname;";
                    using (SqlCommand cmd = new SqlCommand(DeleteUserquery, connection))
                    {
                        
                        cmd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = StudentsAdmin.selectedRow.Cells[1].Value?.ToString() ?? "";
                        cmd.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = StudentsAdmin.selectedRow.Cells[3].Value?.ToString() ?? "";

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data deleted successfully.");
                           
                        }
                        else
                        {
                            MessageBox.Show("No data deleted.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            studentAdmin.Show();
        }
        public void UpdateAgeLabel()
        {
            DateTime birthDate = Birthdate.Value;
            int age = AgeCalculator(birthDate);
            Agelabel.Text = age.ToString();
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


        private void UpdateStudentInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            studentAdmin.Hide();
            studentAdmin.Show();
        }

        private void YearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
