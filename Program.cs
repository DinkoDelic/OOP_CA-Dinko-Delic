using OOP_CA_Dinko_Delic.Data;

namespace OOP_CA_Dinko_Delic
{
    class Program
    {
        static void Main(string[] args)
        {

            // Creates a new instance of data class that includes teacher and student lists and the methods for adding/removing data
            DataContext data = new DataContext();

            // Seeds intial data into the lists for testing
            SeedData.CreateSeed(data);

            // Repositories containing methods for displaying, adding, and removing teachers and students
            TeacherRepository teacherRepo = new TeacherRepository(data);
            StudentRepository studentRepo = new StudentRepository(data);

            // Static class that contains user interface menu
            UserInterface.DisplayMenu(teacherRepo, studentRepo);

        }
    }
}
