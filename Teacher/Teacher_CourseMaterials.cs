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
    public partial class Teacher_CourseMaterials : Form
    {
        public Teacher_CourseMaterials()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher_CourseMaterials teacher_CourseMaterials = new Teacher_CourseMaterials();
            this.Hide();
            teacher_CourseMaterials.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher_StudentList teacher_list = new Teacher_StudentList();
            this.Hide();
            teacher_list.Show();    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher_CourseMaterials teacher_materials = new Teacher_CourseMaterials();  
            this.Hide();
            teacher_materials.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Teacher_GradeManagament teacher_grade = new Teacher_GradeManagament();
            this.Hide();
            teacher_grade.Show();   
        }

        private void Teacher_CourseMaterials_Load(object sender, EventArgs e)
        {

        }
    }
}
