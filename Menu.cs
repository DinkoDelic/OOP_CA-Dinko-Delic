using System;
using System.Collections.Generic;
using OOP_CA_Dinko_Delic.Data;
using OOP_CA_Dinko_Delic.Interface;

namespace OOP_CA_Dinko_Delic
{
    public class Menu
    {
        // Static method for displaying user interface inside the terminal
        public static void DisplayMenu(TeacherRepository teacherRepo, StudentRepository studentRepo)
        {
            Console.WriteLine("\n********** WELCOME TO DBS PERSONNEL MANAGEMENT SYSTEM **********\n" +
                             "\nPlease input a number for the action you wish to perform from the list bellow:\n");

            int input;

            // Using a do while loop to stay in the menu until user decides to exit
            do
            {

                Console.WriteLine(" 1 - List all users\n 2 - List all teachers\n 3 - List all students\n" +
                                  " 4 - Add a teacher\n 5 - Add a student\n 6 - Remove a user\n 7 - Find a user\n" +
                                  " 8 - Update a teacher\n 9 - Update a student\n 0 - Exit application");

                while (!(Int32.TryParse(Console.ReadLine(), out input)) || (input < 1 || input > 8))
                {
                    Console.WriteLine("Please select from the listed options");
                }

                switch (input)
                {
                    case 1:
                        teacherRepo.DisplayAll();
                        break;
                    case 2:
                        teacherRepo.DisplayType(new List<Teacher>());
                        break;

                    case 3:
                        studentRepo.DisplayType(new List<Student>());
                        break;
                    case 4:
                        Teacher teacherToCreate = teacherRepo.Create(new Teacher());

                        teacherRepo.AddToList(teacherToCreate);
                        break;
                    case 5:
                        Student studentToCreate = studentRepo.Create(new Student());

                        studentRepo.AddToList(studentToCreate);
                        break;
                    case 6:
                        Console.WriteLine("Please type in the id of the person you wish to delete or type -1 to exit:");
                        string userToDelete = Console.ReadLine();
                        teacherRepo.Delete(userToDelete);
                        break;
                    case 7:
                        Console.WriteLine("Please input the name of the user to find:");
                        string name = Console.ReadLine();
                        teacherRepo.FindUser(name);
                        break;
                    case 8:
                        Console.WriteLine("Please input the id of the user to edit:");
                        string teacherToEdit = Console.ReadLine();
                        Teacher updatedTeacher = teacherRepo.EditUser(teacherToEdit);
                        Console.WriteLine(updatedTeacher + "\n");
                        break;

                    default:
                        Console.WriteLine("You pressed a key other then the one listed above.");
                        break;
                }

            }
            while (input != -1);
        }
    }
}