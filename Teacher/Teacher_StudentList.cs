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
    public partial class Teacher_StudentList : Form
    {
        public Teacher_StudentList()
        {
            InitializeComponent();
        }

        private void Studlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher_DashBoard teacher_DashBoard = new Teacher_DashBoard();
            this.Hide();
            teacher_DashBoard.Show();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher_StudentList teacher_list = new Teacher_StudentList();   
            this.Hide();
            teacher_list.Show();    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher_CourseMaterials teacher_CourseMaterials = new Teacher_CourseMaterials();    
            this.Hide();
            teacher_CourseMaterials.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Teacher_GradeManagament teacher_GradeManagament = new Teacher_GradeManagament();
            this.Hide();

        }

    }
}
