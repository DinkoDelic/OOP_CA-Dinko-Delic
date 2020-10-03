using System;
using OOP_CA_Dinko_Delic.Data;

namespace OOP_CA_Dinko_Delic
{
    public static class UserInterface
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

                Console.WriteLine(" 1 - List all teachers\n 2 - List all students\n 3 - Add a teacher\n" +
                                  " 4 - Remove a teacher\n 5 - Add a student\n 6 - Remove a student \n 7 - Exit application");

                while (!(Int32.TryParse(Console.ReadLine(), out input)) || (input < 1 || input > 7))
                {
                    Console.WriteLine("Please select from the listed options");
                }

                switch (input)
                {
                    case 1:
                        teacherRepo.DisplayTeachers();
                        break;

                    case 2:
                        studentRepo.DisplayStudents();
                        break;

                    case 3:
                        Teacher newTeacher = new Teacher();
                        teacherRepo.CreateTeacher(newTeacher);
                        break;

                    case 4:
                        teacherRepo.DeleteTeacher();
                        break;

                    case 5:
                        Student newStudent = new Student();
                        studentRepo.CreateStudent(newStudent);
                        break;

                    case 6:
                        studentRepo.DeleteStudent();
                        break;

                    case 7:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("You pressed a key other then the one listed above.");
                        break;
                }

            }
            while (input != 7);
        }
    }
}