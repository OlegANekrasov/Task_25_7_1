using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.DAL.DB;
using Task_25_7_1.DAL.Entities;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.DAL.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> SelectAll()
        {
            using (var db = new AppContextDB())
            {
                return db.Users.ToList();
            }
        }

        public User SelectByID(int id)
        {
            using (var db = new AppContextDB())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public void AddUser(string name, string Email)
        {
            using (var db = new AppContextDB())
            {
                try
                {
                    db.Users.Add(new User { Name = name, Email = Email });
                    db.SaveChanges();
                    SuccessMessage.Show("Пользователь добавлен");
                }
                catch (Exception)
                {
                    AlertMessage.Show("Ошибка при добавлении пользователян");
                }
            }
        }

        public void DelUser(int id)
        {
            using (var db = new AppContextDB())
            {
                try
                {
                    var user = SelectByID(id);
                    if (user != null)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                        SuccessMessage.Show("Пользователь удален");
                    }
                    else
                    {
                        AlertMessage.Show("Не найден пользователь с данным Id");
                    }
                }
                catch (Exception)
                {
                    AlertMessage.Show("Ошибка при удалении пользователя");
                }
            }
        }

        public void UserNameUpdate(int id, string newName)
        {
            using (var db = new AppContextDB())
            {
                try
                {
                    var user = SelectByID(id);
                    if (user != null)
                    {
                        user.Name = newName;
                        db.Users.Update(user);
                        db.SaveChanges();
                        SuccessMessage.Show("Имя пользователя обновлено");
                    }
                    else
                    {
                        AlertMessage.Show("Не найден пользователь с данным Id");
                    }
                }
                catch (Exception)
                {
                    AlertMessage.Show("Ошибка при обновлении пользователя");
                }
            }
        }

        public int GetCountBooksInUser(string name)
        {
            using (var db = new AppContextDB())
            {
                User user = db.Users.FirstOrDefault(u => u.Name == name);
                if (user == null)
                {
                    AlertMessage.Show("Не найден пользователь");
                    return 0;
                }

                return db.UsersBooks.Where(o => o.User == user).Count();
            }
        }
    }
}
