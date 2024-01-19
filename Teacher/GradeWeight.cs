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
using System.Xml.Linq;

namespace OOP_System
{
    public partial class GradeWeight : Form
    {
        Weights weights = new Weights();
        public GradeWeight()
        {
            InitializeComponent();
        }

        private void GradeWeight_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            string errormsg = "Textbox can't be blank";
            try
            {
                if (w_weight.Text == "")
                {
                    MessageBox.Show(errormsg);
                }
                else if (p_weight.Text == "")
                {
                    MessageBox.Show(errormsg);
                }
                else if (e_weight.Text == "")
                {
                    MessageBox.Show(errormsg);

                }
                else
                {

                    weights.WrittenWeight = Convert.ToInt32(w_weight.Text);
                    weights.PerfWeight = Convert.ToInt32(p_weight.Text);
                    weights.ExWeight = Convert.ToInt32(e_weight.Text);
                    this.saveData(weights);
                    MessageBox.Show("Saved Succesfully");
                    
                    

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void saveData(Weights weights)
        {
            try
            {
                string query = $"INSERT INTO GradeWeights (WrittenWeight,PerformanceWeight,ExamWeight) " +
                    $"VALUES ('{weights.WrittenWeight}', '{weights.PerfWeight}', '{weights.ExWeight}');";

                SqlConnection connection = new SqlConnection(new LogIn().connectionstring);
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.ExecuteNonQuery();
                }
                connection.Close();
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
