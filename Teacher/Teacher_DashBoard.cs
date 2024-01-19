using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_System
{
    public partial class Teacher_DashBoard : Form
    {
        public Teacher_DashBoard()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Teacher_GradeManagament teacher_GradeManagament = new Teacher_GradeManagament();
            this.Hide();
            teacher_GradeManagament.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher_DashBoard teacher_dash = new Teacher_DashBoard();
            this.Hide();
            teacher_dash.Show();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher_StudentList teacher_StudentList = new Teacher_StudentList();
            this.Hide();
            teacher_StudentList.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher_CourseMaterials teacher_CourseMaterials = new Teacher_CourseMaterials();
            this.Hide();
            teacher_CourseMaterials.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            this.Hide();
            logIn.Show();
        }
    }
}
