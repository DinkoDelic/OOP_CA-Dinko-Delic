using System;
using System.Linq;
using OOP_CA_Dinko_Delic.Helpers;

namespace OOP_CA_Dinko_Delic.Data
{
    public class StudentRepository
    {
        // Get only instance of our DataContext
        public DataContext _data { get; }
        public StudentRepository(DataContext data)
        {
            _data = data;
        }

        // Void method that mimics a form to create a student with series of validations for different columns
        public void CreateStudent(Student student)
        {
            Console.Clear();

            Console.WriteLine("Please input student's name:");
            student.Name = Console.ReadLine();

            Console.WriteLine("Please input student's id:");
            int result;

            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Please input the id as a number:");
            }
            student.StudentId = result;

            Console.WriteLine("Please input student's phone number:");
            string phoneNumber = Console.ReadLine();

            // Using regular expressions to check for valid phone numbers
            while (!RegEx.CheckPhone(phoneNumber))
            {
                Console.WriteLine("Phone number is invalid, please input correct phone number:");
                phoneNumber = Console.ReadLine();
            }
            student.Phone = phoneNumber;

            Console.WriteLine("Please input student's email:");
            string email = Console.ReadLine();

            // Using regular expressions to check for valid emails
            while (!RegEx.CheckEmail(email))
            {
                Console.WriteLine("Email syntax is invalid, please input correct email:");
                email = Console.ReadLine();
            }
            student.Email = email;


            Console.WriteLine("Please input student's status either as postgrad or undergrad");
            string status = Console.ReadLine();

            // Check if the input is one of two enum options
            while (status != "postgrad" && status != "undergrad")
            {
                Console.WriteLine("Please input student's status either as postgrad or undergrad");
                status = Console.ReadLine();
            }
            if (status == "postgrad")
            {
                student.Status = StudentStatusEnum.Postgrad;
            }
            else
            {
                student.Status = StudentStatusEnum.Undergrad;
            }

            // Review the student input and confirm adding it or discard the entry
            Console.WriteLine("\n" + student + "\n" + "\nPress y to confirm adding a student, press any other key to cancel");
            string conformation = Console.ReadLine();

            if (conformation == "y")
            {
                _data.AddStudent(student);
                Console.WriteLine("\nStudent added succesfully\n");
            }
            else
            {
                Console.WriteLine("\nStudent was not added.\n");
            }
        }
        public void DeleteStudent()
        {
            
            Console.WriteLine("Please type in the full name of the student you wish to delete or type -1 to exit:");
            string name = Console.ReadLine();

            if (name != "-1")
            {
                // Using linq to find the same user name
                Student delete = _data.studentList.FirstOrDefault(s => s.Name == name);
                
                // Returns boolean value indicating success or failure
                if (_data.RemoveStudent(delete))
                {
                    Console.WriteLine("\nStudent deleted succesfully\n");
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

        public void DisplayStudents()
        {
            // Loops through all the items in the list and calling .toString() implicitly to display it on screen
            foreach (Student s in _data.studentList)
            {
                Console.WriteLine(s + "\n");
            }
        }
    }
}