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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentPerformanceTracker.Admin
{
    public partial class Accounts : Form
    {
        public static DataGridViewRow selectedRow;
        public DataTable UserList = new DataTable();
        public Accounts()
        {
            InitializeComponent();
            Filterbox.Items.Clear();   
            LoadDataFilterComboBox();
            Filterbox.SelectedIndex = 0;
            displayData();
            
        }
        private void LoadDataFilterComboBox()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();

                    string query = "SELECT RoleType FROM Role";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int counter = 0; 

                            while (reader.Read())
                            {
                                if (counter > 0)
                                {
                                    Filterbox.Items.Add(reader[0].ToString());
                                }

                                counter++;
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
        public void displayData()
        {
            string filter = "";

            if (Filterbox.Text == "Teacher" || Filterbox.Text == "Student")
            {
                filter = $"RoleType = '{Filterbox.Text}'";
            }

            UserList.Clear();

            using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT Username, Password, CONCAT(Firstname, ' ', Lastname) as Name FROM Users INNER JOIN Role ON Users.UserRole = Role.roleID  WHERE {filter}";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.Fill(UserList);
                        AccountsList.DataSource = UserList;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void Filterbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayData();
        }      
        private void AdminDashboardbtn_Click(object sender, EventArgs e)
        {
            new AdminForm().Show();
            this.Close();
        }
        private void StudentsBtn_Click(object sender, EventArgs e)
        {
            new StudentsAdmin().Show();
            this.Close();
        }
        private void Facultybtn_Click(object sender, EventArgs e)
        {
            new Faculty().Show();
            this.Close();
        }

        private void Coursesbtn_Click(object sender, EventArgs e)
        {
            new Course().Show();
            this.Close();
        }
        private void Subjectsbtn_Click(object sender, EventArgs e)
        {
            new SchoolSubjects().Show();
            this.Close();
        }

        private void AccountsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}