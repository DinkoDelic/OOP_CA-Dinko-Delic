
namespace OOP_CA_Dinko_Delic.Entities
{
    public class Student : Person
    {
        
        public string StudentId { get; set; }
        public StudentStatusEnum  Status { get; set; }

        public Student()
        {
            // Each time a new student obj is created Id is incremented by 1 and assigned
            // Adds "S" at the end of the id to denote student
            this.StudentId = PublicId.ToString() + "S";
        }

        public Student(string name, string phone, string email, StudentStatusEnum status ) 
                : base(name, phone, email)
        {
            this.Status = status;
            this.StudentId = PublicId.ToString() + "S";
        }

        // Formatting to display the information into columns and rows
        public override string ToString()
        {
             return string.Format("{0,-20}{1,-15}{2,-15}{3,-18}{4,-10}\n{5,-20} {6,-15}{7,-15}{8,-18}{9,-10}", 
                                    "Name", "StudentId", "Status", "Phone", "Email",
                                    this.Name, this.StudentId, this.Status, this.Phone, this.Email);
        }

    }
}