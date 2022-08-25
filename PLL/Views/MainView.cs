using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_25_7_1.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Просмотреть данные (нажмите 1)");
                Console.WriteLine("Изменить данные (нажмите 2)");
                Console.WriteLine("Завершить (нажмите 3)");

                string? keyValue = Console.ReadLine();

                if (keyValue == "3") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.dataView.Show();
                            break;
                        }

                    case "2":
                        {
                            Program.changeDataView.Show();
                            break;
                        }
                }
            }
        }
    }
}
