using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.Book
{
    public class GetCountBooksByAuthorView  
    {
        public BookServices bookServices;

        public GetCountBooksByAuthorView(BookServices bookServices)
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

            Console.WriteLine($"\nКоличество книг автора {аuthor} в библиотеке: {bookServices.GetCountBooksByAuthor(аuthor)}");
        }
    }
}
