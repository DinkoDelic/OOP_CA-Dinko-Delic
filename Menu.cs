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

                Console.WriteLine(" 1 - List all users       4 - Add a user       7 - Edit a teacher\n\n" +
                                  " 2 - List all teachers    5 - Remove a user    8 - Edit a student\n\n" +
                                  " 3 - List all students    6 - Find a user      9 - Exit application");

                while (!(Int32.TryParse(Console.ReadLine(), out input)) || (input < 0 || input > 9))
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
                        Console.WriteLine("Would you like to add a teacher or a student?\n 1 - Teacher   2 - Student");
                        int choice;
                        while (!(Int32.TryParse(Console.ReadLine(), out choice)) || (choice < 1 || choice > 2))
                        {
                            Console.WriteLine("Please select one of the above options");
                        }

                        if (choice == 1)
                        {
                            Teacher teacherToCreate = teacherRepo.Create(new Teacher());

                            teacherRepo.AddToList(teacherToCreate);
                            break;
                        }
                        else
                        {
                            Student studentToCreate = studentRepo.Create(new Student());

                            studentRepo.AddToList(studentToCreate);
                            break;
                        }
                    case 5:
                        Console.WriteLine("Please type in the id of the person you wish to delete or type -1 to exit:");
                        string userToDelete = Console.ReadLine();
                        teacherRepo.Delete(userToDelete);
                        break;
                    case 6:
                        Console.WriteLine("Please input the name of the user to find:");
                        string name = Console.ReadLine();
                        teacherRepo.FindUser(name);
                        break;
                    case 7:
                        Console.WriteLine("Please input the id of the teacher to edit:");
                        string teacherToEdit = Console.ReadLine();
                        Teacher updatedTeacher = teacherRepo.EditUser(teacherToEdit);
                        Console.WriteLine(updatedTeacher + "\n");
                        break;
                    case 8:
                        Console.WriteLine("Please input the id of the student to edit:");
                        string studentToEdit = Console.ReadLine();
                        Student updatedStudent = studentRepo.EditUser(studentToEdit);
                        Console.WriteLine(updatedStudent + "\n");
                        break;
                    case 9:
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("You pressed a key other then the one listed above.");
                        break;
                }

            }
            while (input != 9);
        }
    }
}