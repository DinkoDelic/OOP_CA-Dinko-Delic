namespace OOP_CA_Dinko_Delic
{
   public abstract class Employee : Person
    {
        public abstract decimal Salary { get; set; }

        public Employee()
        {
            
        }
        public Employee(string name, string phone, string email, decimal salary) : base(name, phone, email)
        {
            Salary = salary;
        }

    }
}