using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Helpers;

namespace Task_25_7_1.PLL.Views.UserBook
{
    public class IssueBookToUserView
    {
        public UserBookServices userBookServices;

        public IssueBookToUserView(UserBookServices userBookServices)
        {
            this.userBookServices = userBookServices;
        }

        public void Show()
        {
            Console.Write("Введите Id пользователя:");
            string? idUserStr = Console.ReadLine();

            bool result = int.TryParse(idUserStr, out var idUser);
            if (!result)
            {
                AlertMessage.Show("Ошибка ввода id");
                return;
            }

            Console.Write("Введите Id книги:");
            string? idBookStr = Console.ReadLine();

            result = int.TryParse(idBookStr, out var idBook);
            if (!result)
            {
                AlertMessage.Show("Ошибка ввода id");
                return;
            }

            userBookServices.IssueBookToUser(idUser, idBook);
            Program.userBookInfoView.Show();
        }
    }
}
