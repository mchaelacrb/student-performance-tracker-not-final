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
    public partial class RecordSheet : Form
    {
        public DataTable MidList = new DataTable();
        


        public RecordSheet()
        {
            InitializeComponent();
            displayData();
            

          

        }

        public void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = @" 	SELECT
    si.StudentID,
    si.Firstname + ' ' + si.Lastname AS 'NAME',
    t.term_name as 'TERM',
    SUM(CASE WHEN rt.recordtype_name = 'Written Works' THEN sc.score * gw.weight ELSE 0 END) AS 'WEIGHTED WRITTEN',
    SUM(CASE WHEN rt.recordtype_name = 'Performance Task' THEN sc.score * gw.weight ELSE 0 END) AS 'WEIGHTED PERFORMANCE TASK',
    SUM(CASE WHEN rt.recordtype_name = 'Exam' THEN sc.score * gw.weight ELSE 0 END) AS 'WEIGHTED EXAM',
    (SUM(CASE WHEN rt.recordtype_name = 'Written Works' THEN sc.score * gw.weight ELSE 0 END) +
     SUM(CASE WHEN rt.recordtype_name = 'Performance Task' THEN sc.score * gw.weight ELSE 0 END) +
     SUM(CASE WHEN rt.recordtype_name = 'Exam' THEN sc.score * gw.weight ELSE 0 END)) AS 'FINAL GRADE'
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
    t.term_name = 'Finalterm'
GROUP BY
    si.StudentID, si.Firstname, si.Lastname, t.term_name;


                    ";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(MidList);
                        Midterms.DataSource = MidList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GradeSheet gradeSheet = new GradeSheet();
            gradeSheet.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ScoreSheet scoreSheet = new ScoreSheet();
            scoreSheet.Show();  
            this.Close();
        }

        private void AdminDashboardbtn_Click(object sender, EventArgs e)
        {
            TeacherForm teacherForm = new TeacherForm();
            teacherForm.Show();
            this.Close();
        }

        private void AccountsBtn_Click(object sender, EventArgs e)
        {
            GradeSheet gradeSheet2 = new GradeSheet();  
            gradeSheet2.Show();
            this.Close();
        }

        private void RecordSheet_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GradeSheet gradeSheet3 = new GradeSheet();
            gradeSheet3.Show();
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            MidtermGrades midtermGrades = new MidtermGrades();
            midtermGrades.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ScoreSheet scoreSheet = new ScoreSheet();
            scoreSheet.Show();
            this.Close();
        }

        private void LogOutbtn_Click(object sender, EventArgs e)
        {
           LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }

}
