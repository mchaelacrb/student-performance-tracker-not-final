using StudentPerformanceTracker.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPerformanceTracker.Teacher
{
    public partial class AddScores : Form
    {
         AssignRecord assignRecord = new AssignRecord();
        Students student = new Students(); 
        Scores scores = new Scores();   
        public AddScores()
        {
            InitializeComponent();
            LoadComboBoxItem();
            LoadComboBoxItem2();    
        }
        void LoadComboBoxItem()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();
                    string query = "SELECT record_name FROM record";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                r_name.Items.Add(reader["record_name"].ToString());
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

        void LoadComboBoxItem2()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();
                    string query = "SELECT StudentID FROM StudentInformation";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                s_id.Items.Add(reader["StudentID"].ToString());
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
        private int GetRecordId(string recordName)
        {
            int recordId = -1;


            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT record_id FROM record WHERE record_name = @RecordName";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@RecordName", scores.recordName);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        recordId = Convert.ToInt32(result);
                    }
                }
            }

            return recordId;
        }

        private int GetStudentId()
        {
            scores.studentId = -1;


            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT StudentID FROM StudentInformation";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        scores.studentId = Convert.ToInt32(result);
                    }
                }
            }

            return scores.studentId;
        }


       

        private void button1_Click(object sender, EventArgs e)
        {
            string errormsg = "Textbox can't be blank";

            try
            {
                if (s_id.Text == "" || sc_txt.Text == "" || r_name.SelectedItem == null)
                {
                    MessageBox.Show(errormsg);
                }
                else
                {
                    scores.recordName = r_name.Text;
                    scores.score = Convert.ToInt32(sc_txt.Text);
                    int recordId = GetRecordId(scores.recordName);
                    int studentId = GetStudentId();

                    if (recordId != -1 && studentId != -1 )
                    {
                        scores.recordId = recordId;
                        scores.studentId = studentId;
                        
                        saveData(scores);
                        MessageBox.Show("Saved Successfully");
               
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Record type not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void saveData(Scores scores)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();

                    string query = "UPDATE scores SET score = @Score WHERE student_id = @StudentID AND record_id = @RecordId AND score = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Score", scores.score);
                        command.Parameters.AddWithValue("@RecordId", scores.recordId);
                        command.Parameters.AddWithValue("@StudentID", scores.studentId);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Saved Successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
