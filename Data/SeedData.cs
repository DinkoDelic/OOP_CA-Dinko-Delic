using System.Collections.Generic;

namespace OOP_CA_Dinko_Delic
{
    public static class SeedData
    {
        // Seeds intial data into our lists for testing purpose

        public static void CreateSeed(DataContext _data)
        {
            Student studentOne = new Student("Ellar Anna", "020 911 5894", "ellar@email.com", 1, StudentStatusEnum.Postgrad);
            _data.AddStudent(studentOne);

            Student studentTwo = new Student("Shigeru Richelle", "001 912 2604", "shigeru.r@email.com", 2, StudentStatusEnum.Undergrad);
            _data.AddStudent(studentTwo);

            Teacher teacherOne = new Teacher("Tuvya Gustavs", "001 910 6718", "gustav.tuvya@email.com", 40000M, "Math");
            _data.AddTeacher(teacherOne);

            Teacher teacherTwo = new Teacher("Praveen Ishbel", "021 914 6166", "ishbel89@email.com", 36450.4M, "Biology");
            _data.AddTeacher(teacherTwo);
        }

    }
}