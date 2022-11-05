namespace FintechGroup.Services
{
    internal class Menu3
    {
        public static void AlternativeMenu()
        {
            ConsoleKey[] alternativeMenuValues = new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3 };
            var alternativeMenuOption = Console.ReadKey();
            Menu.SelectAlternativeMenuOptions(alternativeMenuOption.Key);
        }
    }
}