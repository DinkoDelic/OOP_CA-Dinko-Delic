using System.Collections.Generic;

namespace OOP_CA_Dinko_Delic
{
    public class DataContext
    {
        // Data class storing our list, and methods to update it
        public List<Person> userList = new List<Person>();

        public void AddUser(Person user)
        {
            userList.Add(user);
        }
        
        // Returns boolean value indicating if the operation was succesful or not
        public bool RemoveUser(Person user)
        {
            return userList.Remove(user);
        }

        
    }
}