using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPerformanceTracker.Admin
{
    public partial class UpdateTeacher : Form
    {
        public UpdateTeacher()
        {
            InitializeComponent();
            LoadComboBoxItem();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                deleteData();
                this.Close();
                new Faculty().Show();
            }
        }

        private void t_save_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void deleteData()
        {
            try
            {
                SqlConnection connection = new SqlConnection(new LogIn().connectionstring);
                connection.Open();

                string query = $"DELETE FROM Teachers WHERE TeacherId = @TeacherID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = Convert.ToInt32(Faculty.selectedRow.Cells[0].Value);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No data deleted.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void updateData()
        {
            string query = "UPDATE Teachers SET Firstname = @FirstName,Lastname = @LastName,Departement = @Department, Subject = @Subject WHERE Teacherid = @Teacherid";

            SqlConnection connection = new SqlConnection(new LogIn().connectionstring);
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Teacherid", SqlDbType.Int).Value = Convert.ToInt32(Faculty.selectedRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@FirstName", t_first.Text);
                cmd.Parameters.AddWithValue("@LastName", t_last.Text);
                cmd.Parameters.AddWithValue("@Department", t_dep.Text);
                cmd.Parameters.AddWithValue("@Subject", t_sub.Text);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Data updated successfully!");
        }
        void LoadComboBoxItem()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Departement  FROM Teachers";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                t_dep.Items.Add(reader["Departement"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(new LogIn().connectionstring))
                {
                    connection.Open();
                    string query1 = "SELECT DISTINCT SubjectName FROM Subjects";

                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                t_sub.Items.Add(reader["SubjectName"].ToString());
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
