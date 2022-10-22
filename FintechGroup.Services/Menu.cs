using FintechGroup.Services;

namespace FintechGroup
{
    public class Menu
    {

        public static void DisplayMenuGreeting()
        {
            Console.WriteLine("Witaj, Użytkowniku, w aplikacji FinTech. Co chciałbyś dzisiaj zrobić?\n");

        }

        public static void DisplayMenuFarewell()
        {
            Console.WriteLine("Czy na pewno chcesz zakończyć działanie aplikacji?\n" +
                "Naciśnij klawisz 't', jeśli chcesz zakończyć działanie programu.\n" +
                "Naciśnij klawisz 'n', aby powrócić do menu głównego.");
            string v = Console.ReadLine();

            if (v == "t")
            {

                Console.Clear();
                Console.WriteLine("Aplikacja zostane zakonczona");
                Exit.ExitMenu();
            }
            else
            {
                Console.Clear();
                DisplayMainMenu();
            }
        }
        public static void DisplayMainMenu()
        {
            Console.WriteLine("1. Wyświetl istniejące rekordy\n" +
            "2. Zarządzaj rekordami\n" +
            "3. Wyszukaj lub filtruj \n" +
            "4. Zakończ działanie aplikacji\n\n" +
            "Napisz numer preferowanej opcji:");
            Menu2.CallMenu();
        }

        public static void SelectMainMenuOption(int key)
        {
            switch (key)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Istniejące rekordy:");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("1. Dodaj nowy rekord");
                    Console.WriteLine("2. Edytuj istniejący rekord");
                    Console.WriteLine("3. Usuń rekord");
                    Console.WriteLine("4. Wróć do menu głównego");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("1. Wyszukaj");
                    Console.WriteLine("2. Filtruj");
                    Console.WriteLine("3. Wróć do menu głównego");
                    int vkey = int.Parse(Console.ReadLine());

                    switch (vkey)
                    {

                        case 1:
                            Console.Clear();
                            Wzszukiwanie.WzszukiwanieMenu();
                            break;

                        case 2:
                            Console.Clear();
                            Filtracja.FiltracjaMenu();
                            break;

                        case 3:
                            Console.Clear();
                            DisplayMainMenu();
                            break;
                    }
                    break;
                case 4:
                    Console.Clear();
                    DisplayMenuFarewell();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wybierz prawidłową opcję z przedziału 1-4.\n");
                    break;
            }
        }
    }
}

