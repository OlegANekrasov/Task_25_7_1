using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_25_7_1.PLL.Views
{
    public class ChangeDataView
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Добавить пользователя (нажмите 1)");
                Console.WriteLine("Удалить пользователя (нажмите 2)");
                Console.WriteLine("Обновить имя пользователя (нажмите 3)");
                Console.WriteLine("Добавить книгу (нажмите 4)");
                Console.WriteLine("Удалить книгу (нажмите 5)");
                Console.WriteLine("Обновить год выпуска книги (нажмите 6)");
                Console.WriteLine("Выдать книгу пользователю (нажмите 7)");
                Console.WriteLine("Вернуть книгу пользователем (нажмите 8)");
                Console.WriteLine("В главное меню (нажмите 9)");

                string? keyValue = Console.ReadLine();

                if (keyValue == "9") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.addUserView.Show();
                            break;
                        }

                    case "2":
                        {
                            Program.delUserView.Show();
                            break;
                        }

                    case "3":
                        {
                            Program.userNameUpdateView.Show();
                            break;
                        }

                    case "4":
                        {
                            Program.addBookView.Show();
                            break;
                        }

                    case "5":
                        {
                            Program.delBookView.Show();
                            break;
                        }

                    case "6":
                        {
                            Program.bookYearUpdateView.Show();
                            break;
                        }

                    case "7":
                        {
                            Program.issueBookToUserView.Show();
                            break;
                        }

                    case "8":
                        {
                            Program.bookReturnView.Show();
                            break;
                        }
                }
            }
        }
    }
}
