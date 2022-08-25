using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;

namespace Task_25_7_1.PLL.Views.Book
{
    internal class GetLatestPublishedBookView
    {
        public BookServices bookServices;

        public GetLatestPublishedBookView(BookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        public void Show()
        {
            var book = bookServices.GetLatestPublishedBook();
            Console.WriteLine($"\nПоследняя вышедшая книга:\n " +
                $"ID: {book.Id} Название: {book.Name} Автор: {book.Author.FullName} Год выпуска: {book.YearOfIssue.Year} Жанр: {book.BookGenre}");
        }
    }
}
