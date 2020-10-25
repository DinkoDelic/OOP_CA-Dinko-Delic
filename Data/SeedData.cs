using OOP_CA_Dinko_Delic.Entities;

namespace OOP_CA_Dinko_Delic.Data
{
    public class SeedData
    {
        // Seeds intial data into our lists for testing purpose

        public static void CreateSeed(Persons data)
        {
            Student studentOne = new Student("Ellar Anna", "020 911 5894", "ellar@email.com", StudentStatusEnum.Postgrad);
            data.AddUser(studentOne);

            Student studentTwo = new Student("Shigeru Richelle", "001 912 2604", "shigeru.r@email.com", StudentStatusEnum.Undergrad);
            data.AddUser(studentTwo);

            Student studentThree = new Student("Alan Smith", "003 453 2456", "alan.s@email.com", StudentStatusEnum.Postgrad);
            data.AddUser(studentThree);

            Student studentFour = new Student("Becky Cavan", "034 335 4535", "cavan.becky@email.com", StudentStatusEnum.Undergrad);
            data.AddUser(studentFour);

            Teacher teacherOne = new Teacher("Tuvya Gustavs", "001 910 6718", "gustav.tuvya@email.com", 40000M, "Math");
            data.AddUser(teacherOne);

            Teacher teacherTwo = new Teacher("Praveen Ishbel", "021 914 6166", "ishbel89@email.com", 36450.4M, "Biology");
            data.AddUser(teacherTwo);

            Teacher teacherThree = new Teacher("Boris Kirn", "002 250 3635", "boris.k@gmail.com", 64253.3M, "CS");
            data.AddUser(teacherThree);

            Teacher teacherFour = new Teacher("Francisca Helsley", "005 453 3578", "helsley.fran@hotmail.com", 34566M, "Biology");
            data.AddUser(teacherFour);
        }

    }
}