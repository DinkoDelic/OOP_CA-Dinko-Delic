using System;
using System.Collections.Generic;
using System.Linq;
using OOP_CA_Dinko_Delic.Entities;

namespace OOP_CA_Dinko_Delic.Data
{
    public class StudentRepository : UserRepository<Student>
    {
      
        public StudentRepository(Persons data):base(data)
        {
        }

        // Void method that mimics a gui form to create a student with series of validations for different columns
        public override Student Create(Student student)
        {
            // Base method to assign name, email and phone
            // Because it takes in person parameter we have to preform downcasting
            student = AssignPersonProperties(student) as Student;

            Console.WriteLine("Please input student's status:\n 1 - postgrad    2 - undergrad");
            string status = Console.ReadLine();

            // Check if the input is one of two enum options
            while (status.ToLower() != "1" && status.ToLower() != "2")
            {
                Console.WriteLine("Please input student's status as a number:\n 1 - postgrad    2 - undergrad");
                status = Console.ReadLine();
            }
            if (status == "1")
            {
                student.Status = StudentStatusEnum.Postgrad;
            }
            else
            {
                student.Status = StudentStatusEnum.Undergrad;
            }

            return student;
        }


        // Adds all the Student types from our Person list into a temp Student list to allow for sorting and filtering
        public override void DisplayType(List<Student> studentList)
        {
            foreach (Person user in _data.userList)
            {
                // Checking if user is of type Student
                if (user is Student)
                {
                    // Downcasting from Person to Student with "as" keyword
                    Student s = user as Student;
                    // Assigning them to a temp list for sorting functionality 
                    studentList.Add(s);
                }
            }
            
            Console.WriteLine("\n1 - List alphabetically\n2 - List by id\n3 - List by status");
            int option;
            while (!(Int32.TryParse(Console.ReadLine(), out option)) || (option < 1 || option > 3))
            {
                Console.WriteLine("Please select from the listed options");
            }

            switch (option)
            {
                case 1:
                    // Sort by name
                    var studentsName = studentList.OrderBy(s => s.Name);
                    // Loops through all the items in the list and calls .toString() implicitly to display it on screen
                    foreach (Student s in studentsName)
                    {
                        Console.WriteLine(s + "\n");
                    }
                    break;
                case 2:
                    // Sort by id
                    var studentId = studentList.OrderBy(s => s.PublicId);
                    foreach (Student s in studentId)
                    {
                        Console.WriteLine(s + "\n");
                    }
                    break;
                case 3:
                    // Sort by student status
                    var studentStatus = studentList.OrderBy(s => s.Status);
                    foreach (Student s in studentStatus)
                    {
                        Console.WriteLine(s + "\n");
                    }
                    break;
                default:
                    break;
            }
        }

        public override Student EditUser(string id)
        {
             // Trimming the suffix at the end, e.g 103T
            id = id.Remove(id.Length - 1);

            // Finds the person in the list and downcasts it to student
            Student studentToEdit = (_data.userList.FirstOrDefault(u => u.PublicId.ToString() == id)) as Student;

            if(studentToEdit != null)
            {
                // Reusing Create() to assign new properties to existing object
                Student studentToCreate = this.Create(new Student());
                studentToEdit.Name = studentToCreate.Name;
                studentToEdit.Email = studentToCreate.Email;
                studentToEdit.Phone = studentToCreate.Phone;
                studentToEdit.Status = studentToCreate.Status;

                Console.WriteLine("Updated succesfully\n");
                
                return studentToEdit;
            }
            else
            {
                Console.WriteLine("Student not found.\n");
                return null;
            }
        }
    }
}