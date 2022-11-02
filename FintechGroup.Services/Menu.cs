using FintechGroup.Services;
using System.Security.Cryptography.X509Certificates;

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
            var v = Console.ReadKey();

            if (v.Key == ConsoleKey.T)
            {

                Console.Clear();
                Console.WriteLine("Aplikacja zostane zakończona.");
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
            Console.WriteLine(
            "1. Wyświetl istniejące rekordy\n" +
            "2. Zarządzaj rekordami\n" +
            "3. Wyszukaj lub filtruj \n" +
            "4. Zakończ działanie aplikacji\n\n" +
            "Napisz numer preferowanej opcji:\n");
            Menu2.CallMenu();
        }

        public static void SelectMainMenuOption(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    WorksOnRecord.ReadRecordFile();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    Console.WriteLine("1. Dodaj nowy rekord");
                    Console.WriteLine("2. Dodaj nowy wpis do rekordu");
                    Console.WriteLine("3. Usuń rekord");
                    Console.WriteLine("\nNaciśnij 'Enter', aby wyświetlić dodatkowe opcje.\n");
                    var key2 = Console.ReadKey();

                    switch (key2.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.Clear();
                            WorksOnRecord.AddRecordName();
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.Clear();
                            WorksOnRecord.EditRecord();
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.Clear();
                            WorksOnRecord.DeleteRecord();
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            DisplayAlternativeMenu();
                            break;
                    }
                    break;
                   
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    Console.WriteLine("1. Wyszukaj");
                    Console.WriteLine("2. Filtruj");
                    Console.WriteLine("\nNaciśnij 'Enter', aby wyświetlić dodatkowe opcje.");
                    var key4 = Console.ReadKey();

                    switch (key4.Key)
                    {

                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.Clear();
                            //brak funkcji
                            Wyszukiwanie.WyszukiwanieMenu();
                            break;

                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.Clear();
                            //brak funkcji
                            Filtracja.FiltracjaMenu();
                            break;

                        case ConsoleKey.Enter:
                            Console.Clear();
                            DisplayAlternativeMenu();
                            break;
                    }
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.Clear();
                    DisplayMenuFarewell();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wybierz prawidłową opcję z przedziału 1-4.\n");
                    DisplayMainMenu();
                    break;
            }
        }

        public static void DisplayAlternativeMenu()
        {
            Console.WriteLine(
               "1. Wróć do głównego menu.\n" +
               "2. Zakończ działanie aplikacji.\n" +
               "3. Użyj tej funkcji ponownie.\n");
            Menu3.AlternativeMenu();
        }

        public static void SelectAlternativeMenuOptions(ConsoleKey alternativeKey)
        {
            switch (alternativeKey)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    DisplayMainMenu();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    DisplayMenuFarewell();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    Console.WriteLine("Użyj tej funkcji ponownie.");
                    
                    break;
            }
        }
        public static void CallAlternativeMenu()
        {
            Console.WriteLine("\nNaciśnij 'Enter', aby wyświetlić dodatkowe opcje.\n");
            var key1 = Console.ReadKey();

            switch (key1.Key)
            {
                case ConsoleKey.Enter:
                    Console.Clear();
                    DisplayAlternativeMenu();
                    break;
            }
        }
    }
}

