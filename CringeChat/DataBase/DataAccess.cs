using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using CringeChat.DataBase;

namespace CringeChat.DataBase
{
    public static class DataAccess
    {
        public delegate void RefreshListDelegate();
        public static event RefreshListDelegate RefreshListEvent;

        public static List<Employee> GetEmployees() => ChatMishaEntities.GetContext().Employees.ToList(); 

        public static Employee GetEmployee(string username, string password)
        {
            var encryptedPassword = ComputeStringToSha256Hash(password);
            return ChatMishaEntities.GetContext().Employees.FirstOrDefault(x => x.Name == username && x.Password == encryptedPassword);
        }
        static string ComputeStringToSha256Hash(string plainText)
        {
            // Create a SHA256 hash from string   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computing Hash - returns here byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                // now convert byte array to a string   
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }
    }
}
