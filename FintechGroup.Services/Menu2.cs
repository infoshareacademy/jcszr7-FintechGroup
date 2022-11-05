namespace FintechGroup.Services
{
    internal class Menu2
    {
        public static void CallMenu()
        {
            ConsoleKey[] mainMenuValues = new ConsoleKey[] 
                {ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4};
            var mainMenuOption = Console.ReadKey();
            Menu.SelectMainMenuOption(mainMenuOption.Key);
        }
    }
}