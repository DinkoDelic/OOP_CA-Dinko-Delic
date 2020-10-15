using OOP_CA_Dinko_Delic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_CA_Dinko_Delic.Data
{
    public abstract class UserRepository<T> : IRepository<T>
    {
        public DataContext _data { get; }
        // Injecting our data class that stores user list
        public UserRepository(DataContext data)
        {
            _data = data;
        }

        public abstract T Create(T user);

        public void Delete(string id)
        {
            // Removes identity suffix at the end, e.g. 105T
            id = id.Remove(id.Length - 1);

            if (id != "-1")
            {
                //Using linq to find the same user id
                Person userToDelete = _data.userList.FirstOrDefault(t => t.PublicId.ToString() == id);

                // Returns boolean value indicating success or failure
                if (_data.RemoveUser(userToDelete))
                {
                    Console.WriteLine("\nUser deleted succesfully\n");
                }
                else
                {
                    Console.WriteLine("\nDeletion failed\n");
                }
            }
            else
            {
                Console.WriteLine("\nExiting operation.\n");
            }
        }

        public void DisplayAll()
        {
            // Loops through all the items in a list and calls .ToString() implicitly
            foreach (Person p in _data.userList)
            {
                Console.WriteLine(p + "\n");
            }
        }

        public void FindUser(string name)
        {
            bool found = false;
            foreach (Person p in _data.userList)
            {
                if (p.Name.ToLower() == name.ToLower())
                {
                    Console.WriteLine("\n" + p + "\n");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("\nUser not found\n");
            }
        }

        public void AddToList(T userToCreate)
        {
            // Review and confirm the new entry or discard it
            Console.WriteLine("\n" + userToCreate + "\n" + "\nPress y to confirm adding a user, press any other key to cancel");
            string conformation = Console.ReadLine();

            if (conformation.ToLower() == "y")
            {
                _data.AddPerson(userToCreate as Person);
                Console.WriteLine("\nUser added succesfully\n");
            }
            else
            {
                Console.WriteLine("\nUser was not added.\n");
            }
        }

        public abstract void DisplayType(List<T> list);

        public abstract T EditUser(string name);

    }
}
