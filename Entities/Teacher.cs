using System;

namespace OOP_CA_Dinko_Delic
{
    public class Teacher : Employee
    {
        private decimal teacherSalary;
        public string SubjectTaught { get; set; }

        public string TeacherId { get; set; }
        public override decimal Salary
        {
            get
            {
                return teacherSalary;
            }
            set
            {
                if (value > 0)
                {
                    teacherSalary = value;
                }
                else
                {
                   throw new ArgumentOutOfRangeException("Salary",value,"Salary must be above 0");
                }
            }
        }
        public Teacher()
        {
            // Adds "T" at the end of the id to denote teacher
            TeacherId = PublicId.ToString() + "T";
        }

        public Teacher(string name, string phone, string email, decimal salary, string subjectTaught)
                    : base(name, phone, email, salary)
        {
            SubjectTaught = subjectTaught;
            Salary = salary;
            TeacherId = PublicId.ToString() + "T";
        }

        // Formatting to display the information into columns and rows
        public override string ToString()
        {
            return string.Format("{0,-20}{1,-15}{2,-15}{3,-18}{4,-30}{5,-15}\n{6,-20} {7,-15}{8,-15}{9,-18}{10,-30}{11,-15}", 
                                    "Name","TeacherId", "Subject", "Phone", "Email", "Salary",
                                    this.Name,this.TeacherId, this.SubjectTaught, this.Phone, this.Email, this.Salary);
        }

    }
}