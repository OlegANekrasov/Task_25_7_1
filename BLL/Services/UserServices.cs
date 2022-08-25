using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.DAL.DB;
using Task_25_7_1.DAL.Entities;
using Task_25_7_1.DAL.Repositories;

namespace Task_25_7_1.BLL.Services
{
    public class UserServices
    {
        UserRepository userRepository = null!;

        public UserServices()
        {
            userRepository = new UserRepository();
        }

        public IEnumerable<User> SelectAll()
        {
            return userRepository.SelectAll();
        }

        public void PrintUsers()
        {
            using (var db = new AppContextDB())
            {
                UserRepository userRepository = new UserRepository();
                Console.WriteLine("\nПользователи:");
                var allUsers = userRepository.SelectAll();
                foreach (var user in allUsers)
                {
                    Console.WriteLine($"ID: {user.Id} ФИО: {user.Name}");
                }
            }
        }

        public void AddUser(string name, string Email)
        {
            userRepository.AddUser(name, Email);
        }

        public void DelUser(int Id)
        {
            userRepository.DelUser(Id);
        }

        public void UserNameUpdate(int id, string newName)
        {
            userRepository.UserNameUpdate(id, newName);
        }

        public int GetCountBooksInUser(string name)
        {
            return userRepository.GetCountBooksInUser(name);
        }
    }
}
