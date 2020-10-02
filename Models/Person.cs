namespace OOP_CA_Dinko_Delic
{
    public abstract class Person
    {
        public Person(string name, string phone, string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;

        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Person()
        {

        }


    }
}