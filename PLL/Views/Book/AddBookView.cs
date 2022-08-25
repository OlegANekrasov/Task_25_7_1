using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.Book
{
    public class AddBookView
    {
        public BookServices bookServices;

        public AddBookView(BookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        public void Show()
        {
            Console.Write("Введите название книги:");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            Console.Write("Введите автроа книги:");
            string? аuthor = Console.ReadLine();
            if (string.IsNullOrEmpty(аuthor))
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            Console.Write("Введите год выпуска книги:");
            string? yearOfIssueStr = Console.ReadLine();

            bool result = int.TryParse(yearOfIssueStr, out var yearOfIssue);
            if (!result || yearOfIssueStr.Length != 4)
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            Console.Write("Введите жанр книги (роман / рассказ / повесть / поэма):");
            string? bookGenre = Console.ReadLine();
            if (string.IsNullOrEmpty(bookGenre))
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            bookServices.AddBook(name, аuthor, yearOfIssue, bookGenre);
            Program.bookInfoView.Show();
        }
    }
}

