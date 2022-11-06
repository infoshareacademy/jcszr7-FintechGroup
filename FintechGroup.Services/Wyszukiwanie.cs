using System.IO;

namespace FintechGroup.Services
{
    internal class Wyszukiwanie
    {
        public static void WyszukiwanieMenu()
        {
            var root = "FinTech Group";
            
            string[] files = Directory.GetFiles(root, "*.txt");

            if (files.Length != 0)
            {
                Console.WriteLine($"Podaj wyszukiwaną frazę:");
                var searchedPhrase = Console.ReadLine();
                foreach (var file in files)
                {
                    //przeszukiwanie zawartości pliku
                    string[] lines = File.ReadAllLines(file);
                    var resultForData = lines.Where(l => l.Contains(searchedPhrase)).ToList();
                    if (resultForData.Count != 0)
                    {
                        Console.WriteLine($"W zawartości pliku '{file}' znajduje się wyszukiwana fraza '{searchedPhrase}'.");
                        foreach (var line in resultForData)
                        {
                            Console.WriteLine($"Wyniki: '{line}'.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"W zawartości pliku '{file}' nie znaleziono frazy {searchedPhrase}");
                    }
                    //przeszukiwanie nazwy pliku
                    var resultForFileName = file.Contains(searchedPhrase);
                    if(resultForFileName)
                    {
                        Console.WriteLine($"W nazwie pliku '{file}' znajduje się wyszukiwana fraza '{searchedPhrase}'.");
                    }
                    else
                    {
                        Console.WriteLine($"W nazwie pliku '{file}' nie znaleziono frazy {searchedPhrase}");
                    }

                }
                Console.WriteLine("Naciśnij dowolny przycisk, by wrócić do menu głównego.");
                Console.ReadKey();
                Console.Clear();
                Menu.DisplayMainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nie ma żadnych danych do przeszukania.");
                Console.WriteLine("Naciśnij dowolny przycisk, by wrócić do menu głównego.");
                Console.ReadKey();
                Console.Clear();
                Menu.DisplayMainMenu();
            }
        }
    }
}