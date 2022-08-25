using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.User
{
    public class DelUserView
    {
        public UserServices userServices;

        public DelUserView(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public void Show()
        {
            Console.Write("Введите Id:");
            string? idStr = Console.ReadLine();

            bool result = int.TryParse(idStr, out var id);
            if (result)
            {
                userServices.DelUser(id);
                Program.userInfoView.Show();
            }
            else
            {
                AlertMessage.Show("Ошибка ввода данных");
            }
        }
    }
}
