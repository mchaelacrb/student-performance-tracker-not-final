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

namespace StudentPerformanceTracker.Admin
{
    public partial class UpdateAccount : Form
    {
        public string password;
        public UpdateAccount()
        {
            InitializeComponent();
        }

        private void UpdateAccount_Load(object sender, EventArgs e)
        {
            UsernameLabel.Visible = true;
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (OldPasstxt.Text != password) {
                MessageBox.Show("Incorrect Password");
            }
        }
        public void loadData(string Username) { 
            UsernameLabel.Text = Username;
        }
        public void updateData()
        {
            string query = "UPDATE Users Set Password = @Password WHERE UUsername = @Username";

            SqlConnection connection = new SqlConnection(new LogIn().connectionstring);
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Username", SqlDbType.Int).Value = Convert.ToInt32(Accounts.selectedRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@Password", NewPasstxt.Text);  
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Password changed successfully!");
        }
    }
}
