using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.Book
{
    public class GetCountBooksByGenreView
    {
        public BookServices bookServices;

        public GetCountBooksByGenreView(BookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        public void Show()
        {
            Console.Write("Введите жанр книги (роман / рассказ / повесть / поэма):");
            string? bookGenre = Console.ReadLine();
            if (string.IsNullOrEmpty(bookGenre))
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            Console.WriteLine($"\nКоличество книг жанра {bookGenre} в библиотеке: {bookServices.GetCountBooksByGenre(bookGenre)}");
        }
    }
}
