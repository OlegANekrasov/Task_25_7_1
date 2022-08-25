using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.Book
{
    public class BookYearUpdateView
    {
        public BookServices bookServices;

        public BookYearUpdateView(BookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        public void Show()
        {
            Console.Write("Введите Id:");
            string? idStr = Console.ReadLine();

            bool result = int.TryParse(idStr, out var id);
            if (!result)
            {
                AlertMessage.Show("Ошибка ввода id");
                return;
            }

            Console.Write("Введите год выпуска книги:");
            string? yearStr = Console.ReadLine();

            result = int.TryParse(yearStr, out var year);
            if (!result || yearStr.Length != 4)
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            bookServices.BookYearUpdate(id, year);
            Program.bookInfoView.Show();
        }
    }
}
