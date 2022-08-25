using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.User
{
    public class UserNameUpdateView
    {
        public UserServices userServices;

        public UserNameUpdateView(UserServices userServices)
        {
            this.userServices = userServices;
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

            Console.Write("Введите ФИО:");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                AlertMessage.Show("Ошибка ввода ФИО");
                return;
            }

            userServices.UserNameUpdate(id, name);
            Program.userInfoView.Show();
        }
    }
}
