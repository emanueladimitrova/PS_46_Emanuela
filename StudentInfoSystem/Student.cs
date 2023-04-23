using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using UserLogin;

namespace StudentInfoSystem
{
    [Table("Students")]
    public class Student : User
    {
        public int StudentId { get; set; }
        public string Name
        {
            get; set;
        }

        public string MiddleName
        {
            get; set;
        }

        public string FamilyName
        {
            get; set;
        }

        public string Faculty
        {
            get; set;
        }

        public string Specialty
        {
            get; set;
        }

        public string EducationLevel
        {
            get; set;
        }

        public string Status
        {
            get; set;
        }

        public string FacultyNumber
        {
            get; set;
        }

        public string Course
        {
            get; set;
        }

        public string FacultyGroup
        {
            get; set;
        }

        public string LocalizedGroup
        {
            get; set;
        }
    }
}
