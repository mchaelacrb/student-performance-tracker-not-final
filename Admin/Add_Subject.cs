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
    public partial class Add_Subject : Form
    {
        Subjects subjects = new Subjects();
        public Add_Subject()
        {
            InitializeComponent();
            LoadComboBoxItem();
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
                if (s_code.Text == "")
                {
                    MessageBox.Show(errormsg);
                }
                else if (s_name.Text == "")
                {
                    MessageBox.Show(errormsg);
                }
                else if (s_description.Text == "")
                {
                    MessageBox.Show(errormsg);
                }
                else
                {
                    subjects.SubjectDepartment = DepComboBox.Text;
                    subjects.SubjectCode = s_code.Text;
                    subjects.SubjectName = s_name.Text;
                    subjects.SubjectDescription = s_description.Text;
                    this.saveData(subjects);
                    MessageBox.Show("Saved Succesfully");
                    this.Close();
                    SchoolSubjects admin_SectionManagement = new SchoolSubjects();
                    admin_SectionManagement.Hide();
                    admin_SectionManagement.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
                                DepComboBox.Items.Add(reader["CourseName"].ToString());
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
        void saveData(Subjects subjects)
        {
            try
            {
                string query = $"INSERT INTO Subjects (SubjectDepartment,SubjectCode,SubjectName,SubjectDescription) " +
                    $"VALUES ('{subjects.SubjectDepartment}','{subjects.SubjectCode}','{subjects.SubjectName}', '{subjects.SubjectDescription}');";

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
