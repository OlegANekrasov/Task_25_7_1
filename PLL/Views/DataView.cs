using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_25_7_1.PLL.Views
{
    public class DataView
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Получать список книг определенного жанра и вышедших между определенными годами (нажмите 1)");
                Console.WriteLine("Получать количество книг определенного автора в библиотеке (нажмите 2)");
                Console.WriteLine("Получать количество книг определенного жанра в библиотеке (нажмите 3)");
                Console.WriteLine("Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке (нажмите 4)");
                Console.WriteLine("Получать булевый флаг о том, есть ли определенная книга на руках у пользователя (нажмите 5)");
                Console.WriteLine("Получать количество книг на руках у пользователя (нажмите 6)");
                Console.WriteLine("Получение последней вышедшей книги (нажмите 7)");
                Console.WriteLine("Получение списка всех книг, отсортированного в алфавитном порядке по названию (нажмите 8)");
                Console.WriteLine("Получение списка всех книг, отсортированного в порядке убывания года их выхода (нажмите 9)");
                Console.WriteLine("В главное меню (нажмите 0)");

                string? keyValue = Console.ReadLine();

                if (keyValue == "0") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.getListBooksOfGenreAndYearsView.Show();
                            break;
                        }

                    case "2":
                        {
                            Program.getCountBooksByAuthorView.Show();
                            break;
                        }

                    case "3":
                        {
                            Program.getCountBooksByGenreView.Show();
                            break;
                        }

                    case "4":
                        {
                            Program.checkBookOfAuthorAndTitleView.Show();
                            break;
                        }

                    case "5":
                        {
                            Program.checkBookOfAuthorAndTitleInUserView.Show();
                            break;
                        }

                    case "6":
                        {
                            Program.getCountBooksInUserView.Show();
                            break;
                        }

                    case "7":
                        {
                            Program.getLatestPublishedBookView.Show();
                            break;
                        }

                    case "8":
                        {
                            Program.getAllBooksSortedByTitleView.Show();
                            break;
                        }

                    case "9":
                        {
                            Program.getAllBooksSortedByYearOfIssueView.Show();
                            break;
                        }
                }
            }
        }
    }
}
