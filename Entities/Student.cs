using System;

namespace OOP_CA_Dinko_Delic
{
    public class Student : Person
    {
        public int StudentId { get; set; }
        public StudentStatusEnum  Status { get; set; }

        public Student()
        {
        }

        public Student(string name, string phone, string email, int studentId, StudentStatusEnum status ) 
                : base(name, phone, email)
        {
            this.StudentId = studentId;
            this.Status = status;
        }

        // Formatting to display the information into columns and rows
        public override string ToString()
        {
             return string.Format("{0,-20} {1,-15}{2,-15}{3,-15}{4,-10}\n{5,-20} {6,-15}{7,-15}{8,-15}{9,-10}", 
                                    "Name", "StudentId", "Status", "Phone", "Email",
                                    this.Name, this.StudentId, this.Status, this.Phone, this.Email);
        }

    }
}