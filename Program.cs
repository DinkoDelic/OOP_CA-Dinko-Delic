using System;
using System.Collections.Generic;
using OOP_CA_Dinko_Delic.Data;

namespace OOP_CA_Dinko_Delic
{
    class Program
    {
        static void Main(string[] args)
        {

            DataContext data = new DataContext();

            SeedData seedData = new SeedData(data);
            seedData.CreateSeed();


            TeacherRepository teacherRepo = new TeacherRepository(data);
            StudentRepository studentRepo = new StudentRepository(data);




            Console.WriteLine("********** WELCOME TO DBS PERSONEL MANAGMENT SYSTEM **********\n" +
                              "Please input a number for the action you wish to perform from the list bellow:\n");

            int input;
            do
            {

                Console.WriteLine(" 1 - List all teachers and students\n 2 - List all teachers\n 3 - List all students\n 4 - Add a teacher\n 5 - Remove a teacher");

                while (!(Int32.TryParse(Console.ReadLine(), out input)) || (input < 1 || input > 7))
                {
                    System.Console.WriteLine("Please select from the listed options");
                }

                switch (input)
                {
                    case 2:
                        teacherRepo.DisplayTeachers();
                        break;
                    
                    case 3:
                        studentRepo.DisplayStudents();
                        break;

                    case 4:
                        Teacher newTeacher = new Teacher();
                        teacherRepo.CreateTeacher(newTeacher);
                        break;

                    case 5:
                        teacherRepo.DeleteTeacher();
                        break;

                    case 6:
                        Student newStudent = new Student();
                        studentRepo.CreateStudent(newStudent);
                        break;

                    case 7:
                        studentRepo.DeleteStudent();
                        break;

                    default:
                        System.Console.WriteLine("You pressed a key other then the one listed above.");
                        break;
                }

            }
            while (input != 7);


        }
    }
}
