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
        public void CreateTeacher(Teacher teacher)
        {
            Console.Clear();

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
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Please input the salary as numbers:");
            }
            teacher.Salary = result;

            // Review and confirm the new entry or discard it
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
                // Using linq to find the same user name
                Teacher delete = _data.teacherList.FirstOrDefault(t => t.Name == name);

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

        public void DisplayTeachers()
        {
            // Loops through all the items in the list and calling .toString() implicitly to display it on screen
            foreach (Teacher t in _data.teacherList)
            {
                Console.WriteLine(t + "\n");
            }
        }



    }
}