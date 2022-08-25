using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.Book
{
    public class CheckBookOfAuthorAndTitleView
    {
        public BookServices bookServices;

        public CheckBookOfAuthorAndTitleView(BookServices bookServices)
        {
            this.bookServices = bookServices;
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

            if(bookServices.CheckBookOfAuthorAndTitle(аuthor, name))
            {
                Console.WriteLine($"\nКнига автора {аuthor} с названием {name} есть в библиотеке");
            }
            else
            {
                Console.WriteLine($"\nКниги автора {аuthor} с названием {name} нет в библиотеке");
            }
        }
    }
}
