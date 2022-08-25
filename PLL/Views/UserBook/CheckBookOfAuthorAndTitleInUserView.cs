using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.UserBook
{
    internal class CheckBookOfAuthorAndTitleInUserView
    {
        public UserBookServices userBookServices;

        public CheckBookOfAuthorAndTitleInUserView(UserBookServices userBookServices)
        {
            this.userBookServices = userBookServices;
        }

        public void Show()
        {
            Console.Write("Введите автроа книги:");
            string? аuthor = Console.ReadLine();
            if (string.IsNullOrEmpty(аuthor))
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            Console.Write("Введите название книги:");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            if (userBookServices.CheckBookOfAuthorAndTitleInUser(аuthor, name))
            {
                Console.WriteLine($"\nКнига автора {аuthor} с названием {name} есть на руках у пользователя");
            }
            else
            {
                Console.WriteLine($"\nКниги автора {аuthor} с названием {name} нет на руках у пользователя");
            }
        }
    }
}
