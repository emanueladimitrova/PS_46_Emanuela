using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInfoSystem
{
    public class StudentData
    {
        public static List<Student> TestStudents
        {
            get
            {
                List<Student> _testStudents = new List<Student>();

                Student newStudent = new Student();
                newStudent.Name = "ekd";
                newStudent.MiddleName = "ekd";
                newStudent.FamilyName = "ekd";
                newStudent.Faculty = "FKST";
                newStudent.Specialty = "KSI";
                newStudent.EducationLevel = "Bachelor";
                newStudent.Status = "Active";
                newStudent.FacultyNumber = "12312312";
                newStudent.Course = "PS";
                newStudent.FacultyGroup = "10";
                newStudent.LocalizedGroup = "46";

                _testStudents.Add(newStudent);

                return _testStudents;
            }
            private set {
                
            }
        }

        public void copyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach (Student student in TestStudents)
            {
                context.Students.Add(student);
            }

            context.SaveChanges();
        }

        private static List<Student> GetRegions()
        {
            StudentInfoContext context = new StudentInfoContext();
            List<Student> students = context.Students.ToList();
            return students;
        }

        public Student isThereStudent(String facNum)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student result =
                (from st in context.Students where st.FacultyNumber == facNum select st).First();
            return result;
        }

        public Student isUserPassCorrect(String facNum, String password)
        {
            StudentInfoContext context = new StudentInfoContext();
            Student result =
                (from st in context.Students where st.FacultyNumber == facNum & st.Password == password select st).First();
            return result;
        }
    }
}
