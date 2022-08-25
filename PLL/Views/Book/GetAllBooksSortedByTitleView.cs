using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;

namespace Task_25_7_1.PLL.Views.Book
{
    internal class GetAllBooksSortedByTitleView
    {
        public BookServices bookServices;

        public GetAllBooksSortedByTitleView(BookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        public void Show()
        {
            Console.WriteLine("\nКниги:");
            var books = bookServices.GetAllBooksSortedByTitle();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id} Название: {book.Name} Автор: {book.Author.FullName} Год выпуска: {book.YearOfIssue.Year} Жанр: {book.BookGenre}");
            }
        }
    }
}
