using System;
using System.Linq;

namespace OOP_CA_Dinko_Delic
{
    public class TeacherRepository
    {
        public DataContext _data { get; }
        public TeacherRepository(DataContext data)
        {
            _data = data;
        }

        public void CreateTeacher(Teacher teacher)
        {
            Console.Clear();

            Console.WriteLine("Please input teacher's name:");
            teacher.Name = Console.ReadLine();

            Console.WriteLine("Please input teacher's phone number:");
            teacher.Phone = Console.ReadLine();

            Console.WriteLine("Please input teacher's email:");
            teacher.Email = Console.ReadLine();

            Console.WriteLine("Please input teacher's subject taught:");
            teacher.SubjectTaught = Console.ReadLine();

            Console.WriteLine("Please input teacher's salary:");
            decimal result;
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Please input the salary as numbers:");
            }
            teacher.Salary = result;

            Console.WriteLine("\n" + teacher + "\n" + "\nPress y to confirm adding a teacher, press any other key to chancel");
            string conformation = Console.ReadLine();

            if (conformation == "y")
            {
                _data.AddTeacher(teacher);
                Console.WriteLine("\nTeacher added succesfully\n");
            }
            else
            {
                Console.WriteLine("\nTeacher was not added.\n");
            }

        }

        public void DeleteTeacher()
        {
            Console.WriteLine("Please type in the full name of the teacher you wish to delete or type -1 to exit:");
            
            string name = Console.ReadLine();
            
            if (name != "-1")
            {
                Teacher delete = _data.teacherList.FirstOrDefault(t => t.Name == name);

                if (_data.RemoveTeacher(delete))
                {
                    Console.WriteLine("\nTeacher deleted succesfully\n");
                }
                else
                {
                    Console.WriteLine("\nDeletion failed\n");
                }
            }
            else
            {
                Console.WriteLine("\nExiting operation.\n");
            }

        }

        public void DisplayTeachers()
        {
            foreach (Teacher t in _data.teacherList)
            {
                Console.WriteLine(t + "\n");
            }
        }



    }
}