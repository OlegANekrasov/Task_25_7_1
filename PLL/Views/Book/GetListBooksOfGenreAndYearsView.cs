using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.Book
{
    public class GetListBooksOfGenreAndYearsView
    {
        public BookServices bookServices;

        public GetListBooksOfGenreAndYearsView(BookServices bookServices)
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

            Console.Write("Введите начальный год выпуска книги:");
            string? yearOfIssueStr1 = Console.ReadLine();

            bool result = int.TryParse(yearOfIssueStr1, out var yearOfIssue1);
            if (!result || yearOfIssueStr1.Length != 4)
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            Console.Write("Введите начальный год выпуска книги:");
            string? yearOfIssueStr2 = Console.ReadLine();

            result = int.TryParse(yearOfIssueStr2, out var yearOfIssue2);
            if (!result || yearOfIssueStr2.Length != 4)
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            Console.WriteLine("\nКниги:");
            var books = bookServices.SelectBooksOfGenreAndYears(bookGenre, yearOfIssue1, yearOfIssue2);
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id} Название: {book.Name} Автор: {book.Author.FullName} Год выпуска: {book.YearOfIssue.Year} Жанр: {book.BookGenre}");
            }
        }
    }
}
