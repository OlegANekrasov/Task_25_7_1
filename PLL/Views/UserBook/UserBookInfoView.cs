using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;

namespace Task_25_7_1.PLL.Views.UserBook
{
    public class UserBookInfoView
    {
        public UserBookServices userBookServices;

        public UserBookInfoView(UserBookServices userBookServices)
        {
            this.userBookServices = userBookServices;
        }

        public void Show()
        {
            Console.WriteLine("\nВыданные книги пользователям:");
            var usersBooks = userBookServices.SelectAll();
            foreach (var book in usersBooks)
            {
                Console.WriteLine($"ID: {book.Id} Название книги: {book.Book.Name} Пользователь: {book.User.Name}");
            }
        }
    }
}
