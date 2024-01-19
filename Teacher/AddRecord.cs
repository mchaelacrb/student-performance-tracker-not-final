using StudentPerformanceTracker.Admin;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentPerformanceTracker.Teacher
{
    public partial class AddRecord : Form
    {
        LogIn LogIn = new LogIn();
        AssignRecord assign = new AssignRecord();
        private SqlConnection connection;

        public AddRecord()
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
                    string query = "SELECT recordtype_name FROM recordtype";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                r_type.Items.Add(reader["recordtype_name"].ToString());
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
                    string query = "SELECT term_name FROM Term";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                term_name.Items.Add(reader["term_name"].ToString());
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

       

        void saveData(AssignRecord assign)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();
                    string query = "INSERT INTO record (record_name, recordtype_id, term_id) VALUES (@RecordName, @RecordTypeId, @TermId)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@RecordName", assign.recordname);
                        command.Parameters.AddWithValue("@RecordTypeId", assign.recordtype_id);
                        command.Parameters.AddWithValue("@TermId", assign.term_id);

                        int rowsAffected = command.ExecuteNonQuery();

                       if (rowsAffected > 0)
                        {
                            MessageBox.Show("Saved Successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No rows were affected. Data might not have been saved.");
                        }
                    }
                }
            }
            catch  (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetRecordTypeId(string recordtype)
        {
            int recordTypeId = -1;


            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT recordtype_id FROM recordtype WHERE recordtype_name = @RecordTypeName";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@RecordTypeName",assign.recordtype);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        recordTypeId = Convert.ToInt32(result);
                    }
                }
            }

            return recordTypeId;
        }

        private int GetTermId(string term_name)
        {
            int term_id = -1;


            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                connection.Open();

                string selectQuery = "SELECT term_id FROM Term WHERE term_name = @TermName";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@TermName", assign.term_name);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        term_id = Convert.ToInt32(result);
                    }
                }
            }

            return term_id;
        }


       
        private void button1_Click(object sender, EventArgs e)
        {
            string errormsg = "Textbox can't be blank";

            try
            {
                if (r_name.Text == "" || r_type.SelectedItem == null || term_name.SelectedItem== null)
                {
                    MessageBox.Show(errormsg);
                }
                else
                {
                    assign.recordname = r_name.Text;
                    assign.recordtype = r_type.SelectedItem.ToString();
                    assign.term_name = term_name.SelectedItem.ToString();
                    int recordtypeId = GetRecordTypeId(assign.recordtype);
                    int term_id = GetTermId(assign.term_name);

                    if (recordtypeId != -1 && term_id != -1)
                    {
                        assign.term_id = term_id;
                        assign.recordtype_id = recordtypeId;
                        saveData(assign);
                        MessageBox.Show("Saved Successfully");
                        this.Hide();
                     
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

       
        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
