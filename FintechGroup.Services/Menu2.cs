using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FintechGroup.Services
{
    internal class Menu2
    {
        public static void CallMenu()
        {
            ConsoleKey[] mainMenuValues = new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4 };
            var mainMenuOption = Console.ReadKey();
            Menu.SelectMainMenuOption(mainMenuOption.Key);
            //while (!mainMenuValues.Contains(mainMenuOption))
            //{
            //    Menu.DisplayMainMenu();
            //    mainMenuOption = int.Parse(Console.ReadLine());
            //    Menu.SelectMainMenuOption(mainMenuOption);
            //}
        }
    }
}
