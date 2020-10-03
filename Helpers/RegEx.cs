using System;
using System.Text.RegularExpressions;

namespace OOP_CA_Dinko_Delic.Helpers
{
    public static class RegEx
    {
        // Static methods to check for valid emails and phones
        public static bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        public static bool CheckPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(?:\(?)(\d{ 3})(?:[\).\s]?)(\d{ 3})(?:[-\.\s] ?)(\d{ 4})(? !\d)");
        }
       
    }
}