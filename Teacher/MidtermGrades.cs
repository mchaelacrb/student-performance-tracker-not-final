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
    public partial class MidtermGrades : Form
    {
        public DataTable MList = new DataTable();

        public MidtermGrades()
        {
            InitializeComponent();
            displayData();
        }

        private void MidtermGrades_Load(object sender, EventArgs e)
        {

        }

        private void Subjectsbtn_Click(object sender, EventArgs e)
        {

        }

        private void Scores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = @"	SELECT
    si.StudentID,
    si.Firstname + ' ' + si.Lastname AS 'NAME',
    t.term_name as 'TERM',
    SUM(CASE WHEN rt.recordtype_name = 'Written Works' THEN sc.score * gw.weight ELSE 0 END) AS 'WEIGHTED WRITTEN',
    SUM(CASE WHEN rt.recordtype_name = 'Performance Task' THEN sc.score * gw.weight ELSE 0 END) AS 'WEIGHTED PERFORMANCE TASK',
    SUM(CASE WHEN rt.recordtype_name = 'Exam' THEN sc.score * gw.weight ELSE 0 END) AS 'WEIGHTED EXAM',
    (SUM(CASE WHEN rt.recordtype_name = 'Written Works' THEN sc.score * gw.weight ELSE 0 END) +
     SUM(CASE WHEN rt.recordtype_name = 'Performance Task' THEN sc.score * gw.weight ELSE 0 END) +
     SUM(CASE WHEN rt.recordtype_name = 'Exam' THEN sc.score * gw.weight ELSE 0 END)) AS 'MIDTERM GRADE'
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
    t.term_name = 'Midterm'
GROUP BY
    si.StudentID, si.Firstname, si.Lastname, t.term_name;";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(MList);
                        Midterm.DataSource = MList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecordSheet recordSheet = new RecordSheet();
            recordSheet.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GradeSheet gradeSheet = new GradeSheet();
            gradeSheet.Show();
            this.Close();   
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ScoreSheet scoreSheet = new ScoreSheet();
            scoreSheet.Show();
            this.Close();
        }

        private void AdminDashboardbtn_Click(object sender, EventArgs e)
        {
            TeacherForm form = new TeacherForm();   
            form.Show();
            this.Close();
        }

        private void AccountsBtn_Click(object sender, EventArgs e)
        {
            RecordSheet recordSheet1 = new RecordSheet();
            recordSheet1.Show();
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
