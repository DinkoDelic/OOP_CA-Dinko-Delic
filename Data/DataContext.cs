using System.Collections.Generic;

namespace OOP_CA_Dinko_Delic
{
    public class DataContext
    {
        public List<Teacher> teacherList = new List<Teacher>();

        public List<Student> studentList = new List<Student>();

        public void AddStudent(Student student)
        {
            studentList.Add(student);
        }
         public void AddTeacher(Teacher teacher)
        {
            teacherList.Add(teacher);
        }
         public bool RemoveStudent(Student student)
        {
            return studentList.Remove(student);
        }
         public bool RemoveTeacher(Teacher teacher)
        {
           return teacherList.Remove(teacher);
        }
    }
}