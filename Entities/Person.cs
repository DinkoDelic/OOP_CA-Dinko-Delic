using System.Globalization;

namespace OOP_CA_Dinko_Delic
{
    public abstract class Person
    {
        // Culture Info object that let's us set language pack for our strings, 
        // used to capitalize first and last name in Name property
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
        
        // Static value that's shared across all person objects
        private static int idCount = 100;

        public int PublicId { get; set; }



        public Person()
        {
            // Everytime we create a new object of person class the id gets incremented by 1 and assigned to their public id
            // Because it's a static property, it's value is shared across all objects of the class
            PublicId = ++idCount;
        }

        public Person(string name, string phone, string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.PublicId = ++idCount;
        }


    }
}