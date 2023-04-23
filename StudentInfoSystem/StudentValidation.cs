using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student getStudentDataByUser(User user)
        {

            if (user.FakNum.Equals(String.Empty))
            {
                Console.WriteLine("Faculty number cannot be empty!");
            }

            foreach (Student student in StudentData.TestStudents)
            {
                if (student.FacultyNumber.Equals(user.FakNum))
                {
                    return student;
                }
            }

            Console.WriteLine("Student not found!");
            return null;
        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();

            IEnumerable<Student> queryStudents = context.Students;

            int count = queryStudents.Count();

            return count == 0 ? true : false;
        }
    }
}
