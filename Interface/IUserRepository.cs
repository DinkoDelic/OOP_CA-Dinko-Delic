using System.Collections.Generic;

namespace OOP_CA_Dinko_Delic.Interface
{
    public interface IUserRepository<T>
    {
         T Create(T user);

         void Delete(string id);
         void DisplayAll();

         void DisplayType(List<T> list);

         void FindUser(string name);

         T EditUser(string name);

         void AddToList(T user);
    }
}