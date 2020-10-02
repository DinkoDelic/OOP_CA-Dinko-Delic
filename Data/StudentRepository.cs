using System;
using System.Linq;

namespace OOP_CA_Dinko_Delic.Data
{
    public class StudentRepository
    {
         public DataContext _data { get; }
        public StudentRepository(DataContext data)
        {
            _data = data;
        }

         public void CreateStudent(Student student)
        {
            Console.WriteLine("Please input student's name:");
            student.Name = Console.ReadLine();

            Console.WriteLine("Please input student's id:");
            int result;
            while(!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Please input the id as a number:");
            }
            student.StudentId = result;

            Console.WriteLine("Please input student's phone number:");
            student.Phone = Console.ReadLine();

            Console.WriteLine("Please input student's email:");
            student.Email = Console.ReadLine();

            Console.WriteLine("Please input student's status either as postgrad or undergrad");
            string status = Console.ReadLine();
            while(status != "postgrad" && status != "undergrad")
            {
                Console.WriteLine("Please input student's status either as postgrad or undergrad");
                status = Console.ReadLine();                 
            }
            if(status == "postgrad")
            {
                student.Status = StudentStatusEnum.Postgrad;
            }
            else
            {
                student.Status = StudentStatusEnum.Undergrad;
            }

            System.Console.WriteLine("\n" + student + "\n" + "Press y to add student, press any other key to chancel");
            string conformation = Console.ReadLine();

            while(conformation != "y")
            {
                System.Console.WriteLine("Please press y to add the student or any other key to chancel operation");
                conformation = Console.ReadLine();
            }

            if(conformation == "y")
            {
                _data.AddStudent(student);
                System.Console.WriteLine("Student added succesfully");
            }
        }
        public void DeleteStudent()
        {
            Console.WriteLine("Please type in the full name of the student you wish to delete or type -1 to exit:");
            
            string name = Console.ReadLine();
            
            if (name != "-1")
            {
                Student delete = _data.studentList.FirstOrDefault(s => s.Name == name);

                if (_data.RemoveStudent(delete))
                {
                    Console.WriteLine("Student deleted succesfully");
                }
                else
                {
                    Console.WriteLine("Deletion failed");
                }
            }
            else
            {
                Console.WriteLine("Exiting operation.");
            }

        }

        public void DisplayStudents()
        {
            foreach (Student s in _data.studentList)
            {
                Console.WriteLine(s + "\n");
            }
        }
    }
}