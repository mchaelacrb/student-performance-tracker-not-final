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
    public partial class GradeSheet : Form
    {
        public DataTable RecList = new DataTable();

        public GradeSheet()
        {
            InitializeComponent();
            displayData();
            WeightLabelWritten();
            WeightLabelPerf();
            WeightLabelExam();
            truncatelabel.Click += truncate_gradeweight;
            Records.CellDoubleClick += Records_CellDoubleClick;

        }

        private void GradeSheet_Load(object sender, EventArgs e)
        {

        }
        public void displayData()
        {
            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT
    r.record_id as 'ID',
    r.record_name as 'RECORD NAME',
    rt.recordtype_name as 'RECORD TYPE',
    t.term_name as 'TERM'
FROM
    record r
JOIN
    recordtype rt ON r.recordtype_id = rt.recordtype_id
JOIN
    Term t ON r.term_id = t.term_id;

	
";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(RecList);
                        Records.DataSource = RecList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }
        private void WeightLabelWritten()
        {



            string query = "SELECT weight FROM gradeweight WHERE gradeweight_id = 1;";


            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();




                    while (reader.Read())
                    {

                        decimal weight = Convert.ToDecimal(reader["weight"]);
                        decimal weightConverted = weight * 100;
                        w_weight.Text = weightConverted.ToString();


                    }

                    reader.Close();
                }
            }
        }

        private void WeightLabelPerf()
        {



            string query = "SELECT weight FROM gradeweight WHERE gradeweight_id = 2;";


            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();




                    while (reader.Read())
                    {

                        decimal weight = Convert.ToDecimal(reader["weight"]);
                        decimal weightConverted = weight * 100;
                        per_weight.Text = weightConverted.ToString();


                    }

                    reader.Close();
                }
            }
        }
        private void WeightLabelExam()
        {



            string query = "SELECT weight FROM gradeweight WHERE gradeweight_id = 3;";


            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();




                    while (reader.Read())
                    {

                        decimal weight = Convert.ToDecimal(reader["weight"]);
                        decimal weightConverted = weight * 100;
                        label11.Text = weightConverted.ToString();


                    }

                    reader.Close();
                }
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {
            RecordSheet recordSheet = new RecordSheet();
            recordSheet.Show();

        }



        private void label4_Click(object sender, EventArgs e)
        {
            ScoreSheet scoreSheet = new ScoreSheet();
            scoreSheet.Show();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            GradeWeights gradeWeights = new GradeWeights();
            gradeWeights.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ScoreSheet scoreSheet1 = new ScoreSheet();
            scoreSheet1.Show();
            this.Close();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            RecordSheet recordSheet = new RecordSheet();
            recordSheet.Show();
            this.Close();
        }

        private void AdminDashboardbtn_Click(object sender, EventArgs e)
        {
            TeacherForm teacherForm = new TeacherForm();
            teacherForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MidtermGrades midtermGrades = new MidtermGrades();
            midtermGrades.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void e_weight_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void truncate_gradeweight(object sender, EventArgs e)
        {

            try
            {
                // SQL query to truncate (delete all rows) from the table
                string query = "TRUNCATE TABLE gradeweight;";

                // Create a SqlConnection and a SqlCommand
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        GradeWeights gradeWeights1 = new GradeWeights();
                        gradeWeights1.Show();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Records_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Ask the user if they want to delete the data
                DialogResult result = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // User clicked Yes, proceed with deletion
                    try
                    {
                        int selectedRow = e.RowIndex;
                        int recordId = Convert.ToInt32(Records.Rows[selectedRow].Cells["record_id"].Value);

                        // SQL query to delete associated scores first
                        string deleteScoresQuery = $"DELETE FROM scores WHERE record_id = {recordId};";

                        // SQL query to delete the selected record
                        string deleteRecordQuery = $"DELETE FROM record WHERE record_id = {recordId};";

                        // Create a SqlConnection and a SqlCommand
                        using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                        {
                            connection.Open();

                            // Execute the query to delete scores
                            using (SqlCommand command = new SqlCommand(deleteScoresQuery, connection))
                            {
                                command.ExecuteNonQuery();
                            }

                            // Execute the query to delete the selected record
                            using (SqlCommand command = new SqlCommand(deleteRecordQuery, connection))
                            {
                                int rowsAffected = command.ExecuteNonQuery();

                                MessageBox.Show("Record Deleted");
                            }
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

        private void Records_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}


