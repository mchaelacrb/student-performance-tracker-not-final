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
    public partial class Add_Teacher : Form
    {
        public Add_Teacher()
        {
            InitializeComponent();
            LoadComboBoxItem();
            
        }

        private void Add_Teacher_Load(object sender, EventArgs e)
        {

        }

        private void t_save_Click(object sender, EventArgs e)
        {
            Teachers teachers = new Teachers();
            string errormsg = "Textbox can't be blank";

            try
            {
                if (t_first.Text == "" || t_last.Text == "" || t_dep.Text == "" || t_sub.Text == "")
                {
                    MessageBox.Show(errormsg);
                }
                else
                {
                    teachers.TeacherFirstName = t_first.Text;
                    teachers.TeacherLastName = t_last.Text;
                    teachers.TeacherDepartment = t_dep.Text;
                    teachers.TeacherSubject = t_sub.Text;
                    this.saveData(teachers);
                    MessageBox.Show("Saved Successfully");
                    this.Close();
                    Faculty faculty = new Faculty();
                    faculty.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void saveData(Teachers teachers)
        {
            try
            {
                string query = $"INSERT INTO Teachers (Firstname,Lastname,Departement,Subject) " +
                    $"VALUES ('{teachers.TeacherFirstName}', '{teachers.TeacherLastName}', '{teachers.TeacherDepartment}', '{teachers.TeacherSubject}')" +
                    $"INSERT INTO Users VALUES ('{teachers.TeacherDepartment}{teachers.TeacherLastName}','teacher', '{teachers.TeacherFirstName}','{teachers.TeacherLastName}',2)";

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
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadComboBoxItem()
        {      
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();
                    string query = "SELECT CourseName FROM Courses";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                t_dep.Items.Add(reader["CourseName"].ToString());
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

        private void t_dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();
                    string query = $"SELECT DISTINCT SubjectName FROM Subjects WHERE SubjectDepartment = '{t_dep.Text}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                t_sub.Items.Add(reader["SubjectName"].ToString());
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
    }
    }

