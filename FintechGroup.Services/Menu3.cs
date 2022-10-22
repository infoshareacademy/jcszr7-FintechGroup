namespace FintechGroup.Services
{
    internal class Menu3
    {
        public static void AlternativeMenu()
        {
            ConsoleKey[] alternativeMenuValues = new ConsoleKey[] { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3 };
            var alternativeMenuOption = Console.ReadKey();
            Menu.SelectAlternativeMenuOptions(alternativeMenuOption.Key);
            //while (!alternativeMenuValues.Contains(alternativeMenuOption))
            //    {
            //        Menu.DisplayAlternativeMenu();
            //        alternativeMenuOption = int.Parse(Console.ReadLine());
            //        Menu.SelectAlternativeMenuOptions(alternativeMenuOption);
            //    }
        }
    }
}
