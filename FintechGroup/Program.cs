using FintechGroup;

int[] mainMenuValues = new int[] { 1, 2, 3, 4 };
Menu.DisplayMenuGreeting();
Menu.DisplayMainMenu();
int mainMenuOption = int.Parse(Console.ReadLine());
Menu.SelectMainMenuOption(mainMenuOption);
while (!mainMenuValues.Contains(mainMenuOption))
{    
    Menu.DisplayMainMenu();
    mainMenuOption = int.Parse(Console.ReadLine());
    Menu.SelectMainMenuOption(mainMenuOption);
}



