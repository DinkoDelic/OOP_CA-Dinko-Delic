using System.Collections.Generic;

namespace OOP_CA_Dinko_Delic.Interface
{
    public interface IRepository<T>
    {
         T Create(T person);
         void Delete(string id);
         void DisplayAll();

         void DisplayType(List<T> list);

         void FindUser(string name);

         T EditUser(string name);

         void AddToList(T user);
    }
}