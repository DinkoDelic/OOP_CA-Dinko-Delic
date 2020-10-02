using System;

namespace OOP_CA_Dinko_Delic
{
    public class Teacher : Employee
    {
        private decimal teacherSalary;
        public string SubjectTaught { get; set; }
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

        }

        public Teacher(string name, string phone, string email, decimal salary, string subjectTaught)
                    : base(name, phone, email, salary)
        {
            SubjectTaught = subjectTaught;
            Salary = salary;
        }


        public override string ToString()
        {
            return string.Format("{0,-20} {1,-15}{2,-15}{3,-15}{4,-10}\n{5,-20} {6,-15}{7,-15}{8,-15}{9,-10}", "Name", "Salary", "Subject", "Phone", "Email",
                                    this.Name, this.Salary, this.SubjectTaught, this.Phone, this.Email);
        }

    }
}