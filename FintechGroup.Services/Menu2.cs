namespace FintechGroup.Services
{
    internal class Menu2
    {
        public static void CallMenu()
        {
            int[] mainMenuValues = new int[] { 1, 2, 3, 4 };
            int mainMenuOption = int.Parse(Console.ReadLine());
            Menu.SelectMainMenuOption(mainMenuOption);
            while (!mainMenuValues.Contains(mainMenuOption))
            {
                Menu.DisplayMainMenu();
                mainMenuOption = int.Parse(Console.ReadLine());
                Menu.SelectMainMenuOption(mainMenuOption);
            }
        }
    }
}
