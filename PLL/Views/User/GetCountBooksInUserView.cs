using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.User
{
    internal class GetCountBooksInUserView
    {
        public UserServices userServices;

        public GetCountBooksInUserView(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public void Show()
        {
            Console.Write("Введите ФИО:");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                AlertMessage.Show("Ошибка ввода ФИО");
                return;
            }

            Console.WriteLine($"\nКоличество книг на руках у пользователя {name}: {userServices.GetCountBooksInUser(name)}");
        }
    }
}
