using FintechGroup.Database;

namespace FintechGroup.Services
{
    public class WorksOnRecord
    {
        private static string filename;

        public static void AddRecordName()
        {
            Console.WriteLine($"Podaj nazwę rekordu:");
            var recordName = Console.ReadLine();
            var fileName = $"{recordName}.txt";
            var fileExists = File.Exists(fileName);
            if (fileExists == false)
            {
                using (var writer = File.Create($"FinTech Group/{fileName}"));
            }
            fileExists = File.Exists(fileName);

            Console.WriteLine("\nPodaj wartość kursu otwarcia:");
            var startPrice = Console.ReadLine();
            Console.WriteLine("\nPodaj wartość kursu zamknięcia:");
            var endPrice = Console.ReadLine();
            var recordDate = DateTime.Now.ToString("d");

            //zapisiwanie rekodu
            using (var writer = File.AppendText($"FinTech Group/{recordName}.txt"))
            {
                writer.Write($"{startPrice};");
                writer.Write($"{endPrice};");
                writer.WriteLine(recordDate);
            }
            Console.Clear();
            Console.WriteLine(
                $"Utworzono nowy rekord {recordName}:\n" +
                $"Kurs otwarcia: {startPrice}\n" +
                $"Kurs zamknięcia: {endPrice}\n");
            Menu.CallAlternativeMenu();
            //Console.WriteLine($"Database stworzona: {File.GetCreationTimeUtc(filename)}");
            //Menu.DisplayMainMenu();
        }
        public static void DeleteRecord()
        {
            AllRecord();
            Console.WriteLine();
            var rootFolder = "FinTech Group";
            Console.WriteLine("Wpisz nazwę rekordu, który chcesz usunąć:");
            var authorsFileRead = Console.ReadLine();
            var authorsFile = $"{authorsFileRead}.txt";
            if (File.Exists(Path.Combine(rootFolder, authorsFile)))
            {

                File.Delete(Path.Combine(rootFolder, authorsFile));
                Console.WriteLine("\nRekord usunięty.\n");
                Menu.CallAlternativeMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Podany rekord nie istnieje.\n");
                DeleteRecord();
            }
        }
        public static void ReadRecordFile()
        {
            AllRecord();
            Console.WriteLine("\nPodaj nazwę rekordu, którego dane mają zostać wypisane:");
            var fileData = Console.ReadLine();
            Console.Clear();
            var fileDataInput = new StreamReader($"FinTech Group/{fileData}.txt").ReadToEnd().Split(';');
            Console.WriteLine($"Dane dla rekordu {fileData}\n\n" +
                $"Kurs otwarcia: {fileDataInput[0]} zł\n" +
                $"Kurs zamknięcia: {fileDataInput[1]} zł\n" +
                $"Data wpisu:" + " " + (File.GetCreationTime($"FinTech Group/{fileData}.txt")));
            //WhichRecord(filename);
            //Console.WriteLine($"Wpisz nazwę rekordu:");
            //var recordname = Console.ReadLine();
            //var fileName = $"{recordname}.txt";
            //Console.WriteLine($"Wypis zaznamu {fileName} :\n");
            //using (var reader = File.OpenText(fileName))
            //{
            //    while (reader.EndOfStream == false)
            //    {
            //        Console.WriteLine(reader.ReadLine());
            //        // brak przekstalcenia do listy i wypisanie ladnie tabulatory
            //    }
            //}
            Menu.CallAlternativeMenu();
        }
        public static void EditRecord()
        {
            AllRecord();
            Console.WriteLine();
            //pobieranie rekordu od uzytkownika
            Console.WriteLine("Podaj nazwę rekordu, który chcesz zaktualizować:");
            var recordName = Console.ReadLine();
            Console.WriteLine("\nPodaj wartość kursu otwarcia:");
            var startPrice = Console.ReadLine();
            Console.WriteLine("\nPodaj wartość kursu zamknięcia:");
            var endPrice = Console.ReadLine();
            var recordDate = DateTime.Now.ToString("d");

            //zapisiwanie rekodu
            if (File.Exists(recordName))
            {
                File.WriteAllText($"FinTech Group/{recordName}.txt", startPrice);
                File.WriteAllText($"FinTech Group/{recordName}.txt", endPrice);
                File.GetLastWriteTime($"FinTech Group/{recordName}.txt");
            }
            //using (var writer = File.AppendText($"FinTech Group/{recordname}.txt"))
            //{
            //    writer.Write($"{startprice};");
            //    writer.Write($"{endprice};");
            //    writer.WriteLine(recorddate);
            //}
            Console.Clear();
            Console.WriteLine(
                $"Zaktualizowano rekord {recordName}:\n" +
                $"Kurs otwarcia: {startPrice}\n" +
                $"Kurs zamknięcia: {startPrice}\n");
            Menu.CallAlternativeMenu();
        }

        public static void AllRecord()
        {
            //string root = new FileInfo(Assembly.GetExecutingAssembly().Location).FullName;
            var root = "FinTech Group";
            string[] files = Directory.GetFiles(root, "*.txt");

            Console.WriteLine("Istniejące rekordy:\n");

            if (files.Length == 0)
            {
                Console.WriteLine("Brak rekordów.");
                Menu.CallAlternativeMenu();
            }
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                Console.WriteLine(fileName);
            }
           
            //string[] dirs = Directory.GetFiles(root, "*.txt");
            //Console.WriteLine("W databazy sie znajduje celkem zaznamow: {0}.", dirs.Length);


            //if (dirs.Length == 0)
            //{
            //    AddRecordName();
            //}
            //else
            //{
            //    foreach (string dir in dirs)
            //    {
            //        // do poprawy wypisiwanie tylko nazw pliku bez stiezki a .txt
            //        Console.WriteLine(dir);

            //    }

            //}
                    
            
        }
      

        public static void WhichRecord(string filename)
        {
            Console.WriteLine($"Wpis nazwe rekordu:");
            var recordname = Console.ReadLine();
            _ = $"{recordname}.txt";
        }


    }
}
