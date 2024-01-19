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

namespace StudentPerformanceTracker.Teacher
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
            countStudent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GradeWeights gradeWeights = new GradeWeights();
            gradeWeights.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddRecord addRecord = new AddRecord();  
            addRecord.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddScores scores = new AddScores();
            scores.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GradeSheet gradeSheet = new GradeSheet();   
            gradeSheet.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RecordSheet recordSheet = new RecordSheet();    
            recordSheet.Show();
        }

     
        private void AccountsBtn_Click(object sender, EventArgs e)
        {
            GradeSheet gradeSheet = new GradeSheet();
            gradeSheet.Show();
            this.Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            AddRecord addRecord1 = new AddRecord();
            addRecord1.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GradeWeights gradeWeights = new GradeWeights(); 
            gradeWeights.Show();    
        }

        private void LogOutbtn_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

        private void StudentsBtn_Click(object sender, EventArgs e)
        {
            StudentList studentList = new StudentList();    
            studentList.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        void countStudent()
        {
            string query = "SELECT COUNT(*) AS StudentCount FROM StudentInformation;";

            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int studentCount = Convert.ToInt32(reader["StudentCount"]);

                        // Assuming 'per_weight' is a TextBox control
                        s_list.Text = studentCount.ToString();
                    }

                    reader.Close();
                }
            }

        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {

        }
    }
}
 