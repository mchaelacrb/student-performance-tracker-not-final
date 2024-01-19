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

namespace StudentPerformanceTracker.Teacher
{
    public partial class ScoreSheet : Form
    {
        public DataTable ScList = new DataTable();

        public ScoreSheet()
        {
            InitializeComponent();
            displayData();
            Scores.CellDoubleClick += Scores_CellDoubleClick;

        }

        public void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT
    si.StudentID,
    si.Firstname + ' ' + si.Lastname AS NAME,
    rt.recordtype_name AS 'RECORD TYPE',
    r.record_name AS 'RECORD NAME',
    t.term_name AS 'TERM',
    sc.score AS 'RAW SCORE',
    SUM(sc.score * gw.weight) AS 'WEIGHTED SCORE'
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
GROUP BY
    si.StudentID, si.Firstname, si.Lastname, rt.recordtype_name, r.record_name, t.term_name, sc.score;
";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(ScList);
                        Scores.DataSource = ScList;
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
            AddScores addScores = new AddScores();
            addScores.Show();
        }

        private void AdminDashboardbtn_Click(object sender, EventArgs e)
        {
            TeacherForm teacherForm = new TeacherForm();
            teacherForm.Show();
            this.Close();
        }

        private void AccountsBtn_Click(object sender, EventArgs e)
        {
            GradeSheet gradeSheet = new GradeSheet();
            gradeSheet.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GradeSheet gradeSheet2 = new GradeSheet();
            gradeSheet2.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecordSheet recordSheet = new RecordSheet();
            recordSheet.Show();
            this.Close();
        }

        private void Scores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Ask the user if they want to delete the data
                DialogResult result = MessageBox.Show("Do you want to delete this recprd?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // User clicked Yes, proceed with deletion
                    try
                    {
                        int selectedRow = e.RowIndex;
                        int scoresId = Convert.ToInt32(Scores.Rows[selectedRow].Cells["StudentID"].Value);

                        // SQL query to delete the selected record and associated scores
                        string query = $"DELETE FROM scores WHERE score_id = {scoresId};";

                        // Create a SqlConnection and a SqlCommand
                        using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();

                            // Execute the query
                            int rowsAffected = command.ExecuteNonQuery();

                            MessageBox.Show("Data Deleted");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // User clicked No, do nothing
                }

            }
        }

        private void ScoreSheet_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Scores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GradeSheet gradeSheet = new GradeSheet();
            gradeSheet.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MidtermGrades midtermGrades = new MidtermGrades();
            midtermGrades.Show();
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            RecordSheet recordSheet = new RecordSheet();    
            recordSheet.Show();
            this.Close();
        }

        private void StudentsBtn_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogOutbtn_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          AddScores addScores = new AddScores();
            addScores.Show();
          
        }
    }
}
