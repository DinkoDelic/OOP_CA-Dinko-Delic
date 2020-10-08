using System.Globalization;

namespace OOP_CA_Dinko_Delic
{
    public abstract class Person
    {
        // Culture Info object that let's us set language pack for our strings, which I choose to be english US
        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

        private string name;
        public string Name 
        {   
            get
            {
                return this.name;
            }
            set
            {
                //  ToTitleCase method which will correctly format name to first letter uppercase
                this.name = myTI.ToTitleCase(value);
            } 
        }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Person()
        {

        }

        public Person(string name, string phone, string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;

        }


    }
}