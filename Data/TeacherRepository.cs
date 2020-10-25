using OOP_CA_Dinko_Delic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_CA_Dinko_Delic.Data
{
    public class TeacherRepository : UserRepository<Teacher>
    {
        public TeacherRepository(Persons data) : base(data)
        {

        }

        // Void method that mimics a form to create a teacher with series of validations for different columns
        public override Teacher Create(Teacher teacher)
        {
            // Base method to assign name, email and phone
            // Because it takes in person parameter we have to preform downcasting
            teacher = AssignPersonProperties(teacher) as Teacher;

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

            // Finds the person in the list and downcasts it to teacher
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
                Console.WriteLine("Teacher not found.\n");
                return null;
            }
            
        }

        // Adds all the Teacher objects from our Person list into a temp Teacher list to allow for sorting and filtering
        public override void DisplayType(List<Teacher> teacherList)
        {
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

            Console.WriteLine("\n1 - List alphabetically\n2 - List by salary lowest to highest\n3 - List by subject");
            int option;
            while (!(Int32.TryParse(Console.ReadLine(), out option)) || (option < 1 || option > 3))
            {
                Console.WriteLine("Please select from the listed options");
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