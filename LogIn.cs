
using StudentPerformanceTracker.Student;
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

namespace StudentPerformanceTracker
{
    public partial class LogIn : Form
    {
        public readonly string connectionstring = mechaConnectionString;
        public static string gocoConnectionString = "Data Source=AINZ\\SQLEXPRESS;Initial Catalog=StudentPerfomance;Integrated Security=True";
        public static string mechaConnectionString = "Data Source=CURIBA-PC01\\SQLEXPRESS;Initial Catalog=aa;Integrated Security=True";

       
        public LogIn()
        {
            InitializeComponent();
        }

        private void pb_showPassword_Click(object sender, EventArgs e)
        {
            if (Passwordtxt.UseSystemPasswordChar)
            {
                Passwordtxt.UseSystemPasswordChar = false;
                pb_showPassword.Image = Properties.Resources.show;
            }
            else
            {
                Passwordtxt.UseSystemPasswordChar = true;
                pb_showPassword.Image = Properties.Resources.hide;
            }
        }

        private void LogInbtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Username = Logintxt.Text;
            user.Password = Passwordtxt.Text;
            checkUser(user);
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Passwordtxt_TextChanged(object sender, EventArgs e)
        {
            if (Passwordtxt.Text != string.Empty)
                pb_showPassword.Visible = true;
            else
            {
                pb_showPassword.Visible = false;
                Passwordtxt.UseSystemPasswordChar = false;
            }
        }

        void checkUser(User user)
        {
            string query = $"SELECT * FROM Users INNER JOIN Role ON Users.UserRole = Role.roleID " +
                    "WHERE username = @Username AND Password = @Password;";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", Logintxt.Text);
                    cmd.Parameters.AddWithValue("@Password", Passwordtxt.Text);

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            string userType = dataTable.Rows[0][7].ToString();

                            if (userType.Equals("Admin"))
                            {          
                                AdminForm admin = new AdminForm();
                                admin.Show();
                                this.Close();
                            }

                            else if (userType.Equals("Teacher"))
                            {
                               TeacherForm teacher = new TeacherForm();
                                teacher.Show();
                                //GradeWeights gradeWeights = new GradeWeights(); 
                               // gradeWeights.Show();
                                this.Close(); 
                            }
                            else if (userType.Equals("Student"))
                            {
                                UserStorage.User = new User
                                {
                                    UserFirstname = dataTable.Rows[0][3].ToString(),
                                    UserLastname = dataTable.Rows[0][4].ToString()
                                };                           
                                StudentForm student = new StudentForm();
                                student.Show();
                                this.Close();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Incorrect username or password");
                        }
                    }
                }
            }
        }
    }
}
