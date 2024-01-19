using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentPerformanceTracker.Teacher
{
    public partial class GradeWeights : Form
    {
        Weights weights = new Weights();
        public GradeWeights()
        {
            InitializeComponent();
        }

        private void GradeWeights_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Weights weights = new Weights();
            string errormsg = "Textbox can't be blank";
            try
            {
                if (w_weight.Text == "" || p_weight.Text == "" || e_weight.Text == "")
                {
                    MessageBox.Show(errormsg);
                }
                else
                {
                    decimal written, performance, exam;

                    if (!decimal.TryParse(w_weight.Text, out written) ||
                        !decimal.TryParse(p_weight.Text, out performance) ||
                        !decimal.TryParse(e_weight.Text, out exam))
                    {
                    }
                    else
                    {
                        weights.written = written;
                        weights.performance = performance;
                        weights.exam = exam;
                    }


                    decimal weightTotal = weights.written + weights.exam + weights.performance;

                    if (weightTotal == 100)
                    {
                        decimal writtenWeight = weights.written / 100;
                        decimal perfWeight = weights.performance / 100;
                        decimal examWeight = weights.exam / 100;


                        this.saveData(writtenWeight, perfWeight, examWeight);
                    }
                    else
                    {
                        MessageBox.Show("Weight total must be 100");
                    }
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid decimal values for weights.");
            }
        }
        private void saveData(decimal writtenWeight, decimal perfWeight, decimal examWeight)
        {

            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                connection.Open();

                
                string insertQuery = "INSERT INTO gradeweight (gradeweight_id, recordtype_id, weight) VALUES (@GradeweightID, @RecordTypeID, @Weight)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@GradeweightID", 1);
                    cmd.Parameters.AddWithValue("@RecordTypeID", 1);  
                    cmd.Parameters.AddWithValue("@Weight", writtenWeight);
                    cmd.ExecuteNonQuery();

                    // Inserting performance weight
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@GradeweightID", 2);
                    cmd.Parameters.AddWithValue("@RecordTypeID", 2);  
                    cmd.Parameters.AddWithValue("@Weight", perfWeight);
                    cmd.ExecuteNonQuery();

                    // Inserting exam weight
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@GradeweightID", 3);
                    cmd.Parameters.AddWithValue("@RecordTypeID", 3); 
                    cmd.Parameters.AddWithValue("@Weight", examWeight);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Saved Successfully");
                }
            }
        }


        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}




