using OOP_CA_Dinko_Delic.Data;
using OOP_CA_Dinko_Delic.Helpers;
using OOP_CA_Dinko_Delic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_CA_Dinko_Delic
{
    public class TeacherRepository : UserRepository<Teacher>
    {
        public TeacherRepository(DataContext data) : base(data)
        {

        }

        // Void method that mimics a form to create a teacher with series of validations for different columns
        public override Teacher Create(Teacher teacher)
        {
            Console.Clear();

            Console.WriteLine("Please input teacher's name:");
            teacher.Name = Console.ReadLine();

            Console.WriteLine("Please input teacher's phone number:");
            string phoneNumber = Console.ReadLine();

            // Using regular expressions to check for valid phone numbers
            while (!RegEx.CheckPhone(phoneNumber))
            {
                Console.WriteLine("Phone number is invalid, please input correct phone number: (XXX XXX XXXX)");
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
            decimal salary;
            // Checking that the input is a decimal and a positive number
            while (!decimal.TryParse(Console.ReadLine(), out salary) || salary < 1)
            {
                Console.WriteLine("Please input the salary as a non-negative number:");

            }
            teacher.Salary = salary;

            return teacher;
        }
        
        // Update existing teacher by creating a new teacher object and assinging it's values to the previous one
        public override Teacher EditUser(string id)
        {
            // Trimming the suffix at the end, e.g 103T
            id = id.Remove(id.Length - 1);

            // Find the object in the list and downcasting it to teacher
            Teacher teacherToEdit = (_data.userList.FirstOrDefault(u => u.PublicId.ToString() == id)) as Teacher;

            if(teacherToEdit != null)
            {
                // Reusing Create() to assign new properties to existing object
                Teacher teacherToCreate = this.Create(new Teacher());
                teacherToEdit.Name = teacherToCreate.Name;
                teacherToEdit.Email = teacherToCreate.Email;
                teacherToEdit.Phone = teacherToCreate.Phone;
                teacherToEdit.Salary = teacherToCreate.Salary;
                teacherToEdit.SubjectTaught = teacherToCreate.SubjectTaught;

                Console.WriteLine("Updated succesfully\n");
                
                return teacherToEdit;
            }
            else
            {
                Console.WriteLine("User not found.\n");
                return null;
            }
            
        }

        // Adds all the Teacher objects from our Person list into a temp Teacher list to allow for sorting and filtering
        public override void DisplayType(List<Teacher> teacherList)
        {
            Console.WriteLine("\n1 - List alphabetically\n2 - List by salary lowest to highest\n3 - List by subject");
            int option;
            while (!(Int32.TryParse(Console.ReadLine(), out option)) || (option < 1 || option > 3))
            {
                Console.WriteLine("Please select from the listed options");
            }

            
            foreach (Person user in _data.userList)
            {
                // Checking if user is of type Teacher
                if (user is Teacher)
                {
                    // Downcasting from person to teacher with "as" keyword
                    Teacher t = user as Teacher;
                    // Assigning them to a temp list for sorting functionality 
                    teacherList.Add(t);
                }
            }

            switch (option)
            {
                case 1:
                    // Sort by name
                    var teachersName = teacherList.OrderBy(t => t.Name);
                    // Loops through all the items in the list and calls .toString() implicitly to display it on screen
                    foreach (Teacher t in teachersName)
                    {
                        Console.WriteLine(t + "\n");
                    }
                    break;
                case 2:
                    // Sort by salary ASC
                    var teachersSalary = teacherList.OrderBy(t => t.Salary);

                    foreach (Teacher t in teachersSalary)
                    {
                        Console.WriteLine(t + "\n");
                    }
                    break;
                case 3:
                    // Sort by subject taught
                    var teachersSubject = teacherList.OrderBy(t => t.SubjectTaught);

                    foreach (Teacher t in teachersSubject)
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