using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;

namespace Task_25_7_1.PLL.Views.User
{
    public class UserInfoView
    {
        public UserServices userServices;

        public UserInfoView(UserServices userServices)
        {
            this.userServices = userServices;
        }

        public void Show()
        {
            Console.WriteLine("\nПользователи:");
            var allUsers = userServices.SelectAll();
            foreach (var user in allUsers)
            {
                Console.WriteLine($"ID: {user.Id} ФИО: {user.Name}");
            }
        }
    }
}
