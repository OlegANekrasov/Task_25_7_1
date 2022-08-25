using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.User
{
    public class AddUserView
    {
        public UserServices userServices;

        public AddUserView(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public void Show()
        {
            Console.Write("Введите ФИО:");
            string? name = Console.ReadLine();

            Console.Write("Введите Email:");
            string? Email = Console.ReadLine();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(Email))
            {
                AlertMessage.Show("Ошибка ввода данных");
                return;
            }

            userServices.AddUser(name, Email);
            Program.userInfoView.Show();
        }
    }
}
