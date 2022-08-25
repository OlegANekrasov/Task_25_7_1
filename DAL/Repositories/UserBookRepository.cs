using Microsoft.EntityFrameworkCore;
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
    public class UserBookRepository
    {
        public IEnumerable<UserBook> SelectAll()
        {
            using (var db = new AppContextDB())
            {
                return db.UsersBooks.Include(t => t.User).Include(t => t.Book).ToList();
            }
        }

        public void IssueBookToUser(int idUser, int idBook)
        {
            using (var db = new AppContextDB())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == idUser);
                if (user == null)
                {
                    AlertMessage.Show("Не найден пользователь");
                    return;
                }

                Book book = db.Books.FirstOrDefault(u => u.Id == idBook);
                if (user == null)
                {
                    AlertMessage.Show("Не найдена книга");
                    return;
                }

                try
                {
                    UserBook userBook = new UserBook { User = user, Book = book};

                    db.UsersBooks.Add(userBook);
                    db.SaveChanges();

                    SuccessMessage.Show("Книга выдана");
                }
                catch (Exception ex)
                {
                    AlertMessage.Show("Ошибка при выдаче книги... " + ex.Message);
                }
            }
        }
        
        public void BookReturn(int idUser, int idBook)
        {
            using (var db = new AppContextDB())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == idUser);
                if (user == null)
                {
                    AlertMessage.Show("Не найден пользователь");
                    return;
                }

                Book book = db.Books.FirstOrDefault(u => u.Id == idBook);
                if (user == null)
                {
                    AlertMessage.Show("Не найдена книга");
                    return;
                }

                UserBook userBook = db.UsersBooks.FirstOrDefault(o => o.User == user && o.Book == book);
                if (userBook == null)
                {
                    AlertMessage.Show("У пользователя нет данной книги");
                    return;
                }

                try
                {
                    db.UsersBooks.Remove(userBook);
                    db.SaveChanges();

                    SuccessMessage.Show("Книга возвращена");
                }
                catch (Exception ex)
                {
                    AlertMessage.Show("Ошибка при возврате книги... " + ex.Message);
                }
            }
        }

        public bool CheckBookOfAuthorAndTitleInUser(string аuthorStr, string name)
        {
            using (var db = new AppContextDB())
            {
                Author аuthor = db.Authors.Include(t => t.Books).FirstOrDefault(u => u.FullName == аuthorStr);
                if (аuthor == null)
                {
                    AlertMessage.Show("Не найден автор книги");
                    return false;
                }

                if (db.Books.Include(t => t.Author).Where(o => o.Author == аuthor && o.Name == name && o.UserBooks.Any()).Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
