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

namespace StudentPerformanceTracker.Student
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
            GetMidtermGradeByStudentName();
            GetFinalGradeByStudentName();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            StudentProfile profile = new StudentProfile();
            profile.Show();
            this.Close();
        }

        private void CourseMaterial_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show();
            this.Close();
        }

        private void GetMidtermGradeByStudentName()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();

                    string query = @"
                SELECT
                    si.StudentID,
                    si.Firstname + ' ' + si.Lastname AS 'NAME',
                    t.term_name as 'TERM',
                    SUM(CASE WHEN rt.recordtype_name = 'Written Works' THEN sc.score * gw.weight ELSE 0 END) +
                    SUM(CASE WHEN rt.recordtype_name = 'Performance Task' THEN sc.score * gw.weight ELSE 0 END) +
                    SUM(CASE WHEN rt.recordtype_name = 'Exam' THEN sc.score * gw.weight ELSE 0 END) AS 'MidtermGrade'
                FROM
                    scores sc
                JOIN
                    record r ON sc.record_id = r.record_id
                JOIN
                    recordtype rt ON r.recordtype_id = rt.recordtype_id
                JOIN
                    gradeweight gw ON rt.recordtype_id = gw.recordtype_id
                JOIN
                    StudentInformation si ON sc.student_id = si.StudentID
                JOIN
                    Term t ON r.term_id = t.term_id
                WHERE
                    si.Firstname = @FirstName
                    AND si.Lastname = @LastName
                    AND t.term_name = 'Midterm'
                GROUP BY
                    si.StudentID, si.Firstname, si.Lastname, t.term_name;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for first name and last name
                        command.Parameters.AddWithValue("@FirstName", UserStorage.User.UserFirstname);
                        command.Parameters.AddWithValue("@LastName", UserStorage.User.UserLastname);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            decimal midtermGrade = Convert.ToDecimal(reader["MidtermGrade"]);
                            m_grade.Text = midtermGrade.ToString();

                        
                            
                        }
                        else
                        {
                            
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void GetFinalGradeByStudentName()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();

                    string query = @"
                SELECT
                    si.StudentID,
                    si.Firstname + ' ' + si.Lastname AS 'NAME',
                    t.term_name as 'TERM',
                    SUM(CASE WHEN rt.recordtype_name = 'Written Works' THEN sc.score * gw.weight ELSE 0 END) +
                    SUM(CASE WHEN rt.recordtype_name = 'Performance Task' THEN sc.score * gw.weight ELSE 0 END) +
                    SUM(CASE WHEN rt.recordtype_name = 'Exam' THEN sc.score * gw.weight ELSE 0 END) AS 'FinalGrade'
                FROM
                    scores sc
                JOIN
                    record r ON sc.record_id = r.record_id
                JOIN
                    recordtype rt ON r.recordtype_id = rt.recordtype_id
                JOIN
                    gradeweight gw ON rt.recordtype_id = gw.recordtype_id
                JOIN
                    StudentInformation si ON sc.student_id = si.StudentID
                JOIN
                    Term t ON r.term_id = t.term_id
                WHERE
                    si.Firstname = @FirstName
                    AND si.Lastname = @LastName
                    AND t.term_name = 'FinalTerm'
                GROUP BY
                    si.StudentID, si.Firstname, si.Lastname, t.term_name;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for first name and last name
                        command.Parameters.AddWithValue("@FirstName", UserStorage.User.UserFirstname);
                        command.Parameters.AddWithValue("@LastName", UserStorage.User.UserLastname);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            decimal finalGrade = Convert.ToDecimal(reader["FinalGrade"]);
                            f_grade.Text = finalGrade.ToString();



                        }
                        else
                        {

                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void f_grade_Click(object sender, EventArgs e)
        {

        }
    }
}
