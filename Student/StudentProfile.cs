using StudentPerformanceTracker.Teacher;
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

namespace StudentPerformanceTracker.Student
{
    public partial class StudentProfile : Form
    {
        public StudentProfile()
        {
            InitializeComponent();
            loadProfile();
        }

        private void CourseMaterial_Click(object sender, EventArgs e)
        {

        }

        private void StudentDashboard_Click(object sender, EventArgs e)
        {

        }
        void loadProfile()
        {
            
            string query = "SELECT * FROM StudentInformation s INNER JOIN Users u ON u.Firstname = s.Firstname AND u.Lastname = s.Lastname " +
                           "WHERE u.Firstname = @Firstname AND u.Lastname = @Lastname;";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Firstname", UserStorage.User.UserFirstname);
                        cmd.Parameters.AddWithValue("@Lastname", UserStorage.User.UserLastname);

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                StudentIDlbl.Text = dataTable.Rows[0]["StudentID"].ToString(); 
                                StudentNamelbl.Text = $"{dataTable.Rows[0]["Firstname"]} {dataTable.Rows[0]["Middlename"]} {dataTable.Rows[0]["Lastname"]}";
                                DateTime birthdate = Convert.ToDateTime(dataTable.Rows[0]["Birthdate"]);
                                StudBirthlbl.Text = birthdate.ToString("MMMM dd, yyyy");
                                StudAgelbl.Text = dataTable.Rows[0]["Age"].ToString();
                                StudAddresslbl.Text = dataTable.Rows[0]["HomeAddress"].ToString();
                                ContactNumlbl.Text = dataTable.Rows[0]["ContactNum"].ToString();
                                StudCourselbl.Text = dataTable.Rows[0]["Course"].ToString();
                                StudeSectionlbl.Text = dataTable.Rows[0]["Section"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("User not found");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
