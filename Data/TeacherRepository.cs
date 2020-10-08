using OOP_CA_Dinko_Delic.Helpers;
using System;
using System.Linq;

namespace OOP_CA_Dinko_Delic
{
    public class TeacherRepository
    {
        // Get only instance of our DataContext
        public DataContext _data { get; }
        public TeacherRepository(DataContext data)
        {
            _data = data;
        }

        // Void method that mimics a form to create a teacher with series of validations for different columns
        public void CreateTeacher()
        {
            Console.Clear();

            Teacher teacher = new Teacher();

            Console.WriteLine("Please input teacher's name:");
            teacher.Name = Console.ReadLine();

            Console.WriteLine("Please input teacher's phone number:");
            string phoneNumber = Console.ReadLine();

            // Using regular expressions to check for valid phone numbers
            while (!RegEx.CheckPhone(phoneNumber))
            {
                Console.WriteLine("Phone number is invalid, please input correct phone number:");
                phoneNumber = Console.ReadLine();
            }
            teacher.Phone = phoneNumber;

            Console.WriteLine("Please input teacher's email:");
            string email = Console.ReadLine();

            // Using regular expressions to check for valid emails
            while (!RegEx.CheckEmail(email))
            {
                Console.WriteLine("Email syntax is invalid, please input correct email:");
                email = Console.ReadLine();
            }
            teacher.Email = email;

            Console.WriteLine("Please input teacher's subject taught:");
            teacher.SubjectTaught = Console.ReadLine();

            Console.WriteLine("Please input teacher's salary:");
            decimal result;
            // Checking that the input is a decimal
            while (!decimal.TryParse(Console.ReadLine(), out result) || result < 1)
            {
                Console.WriteLine("Please input the salary as a non-negative number:");

            }
            teacher.Salary = result;

            // Review and confirm the new entry or discard it
            Console.WriteLine("\n" + teacher + "\n" + "\nPress y to confirm adding a teacher, press any other key to cancel");
            string conformation = Console.ReadLine();

            if (conformation.ToLower() == "y")
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
                // Using linq to find the same user name
                Teacher delete = _data.teacherList.FirstOrDefault(t => t.Name.ToLower() == name.ToLower());

                // Returns boolean value indicating success or failure
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

        // Loops through all the items in the list and calls .toString() implicitly to display it on screen
        public void DisplayTeachers()
        {
            Console.WriteLine("\n1 - List alphabetically\n2 - List by salary lowest to highest\n3 - List by subject");
            int value;
            while (!(Int32.TryParse(Console.ReadLine(), out value)) || (value < 1 || value > 3))
            {
                Console.WriteLine("Please select from the listed options");
            }

            switch (value)
            {
                case 1:
                    var teachersName = _data.teacherList.OrderBy(t => t.Name).ToList();
                    foreach(Teacher t in teachersName)
                    {
                        Console.WriteLine(t + "\n");
                    }
                    break;
                case 2:
                     var teachersSalary = _data.teacherList.OrderBy(t => t.Salary).ToList();
                    foreach(Teacher t in teachersSalary)
                    {
                        Console.WriteLine(t + "\n");
                    }
                    break;
                case 3:
                    var teachersSubject = _data.teacherList.OrderBy(t => t.SubjectTaught).ToList();
                     foreach(Teacher t in teachersSubject)
                    {
                        Console.WriteLine(t + "\n");
                    }
                    break;
                default:
                    break;

            }
            
            
        }



    }
}