using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceTracker
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserFirstname { get; set; }
        public string UserLastname { get; set; }
    }
    public static class UserStorage
    {
        public static User User { get; set; }
    }
    public class Students
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string course { get; set; }

        private string _section = "1";
        public string section
        {
            get { return _section; }
            set { _section = value; }
        }
    }
    public class Teachers
    {
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string TeacherDepartment { get; set; }
        public string TeacherSubject { get; set; }

    }

    public class Courses
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
    }

    public class Subjects
    {
        public string SubjectDepartment { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        public string SubjectCode { get; set; }
    }


    public class Weights
    {
        public decimal written { get; set; }
        public decimal performance { get; set; }
        public decimal exam { get; set; }

        public decimal writtenWeight { get; set; }
        public decimal examWeight { get; set; }
        public decimal perfWeight { get; set; }
    }

    public class AssignRecord
    {
        public string recordname { get; set; }
        public string recordtype { get; set; }
        public int recordtype_id { get; set; }

        public string term_name { get; set; }   
         public int term_id { get; set; }    

    }

    public class Scores
    {
        public int score { get; set; }  
        public int recordId { get; set; }   

        public int studentId { get; set; }  

        public string recordName { get; set; }  
    }
   
}