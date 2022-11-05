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

        public static void DeleteRecordLine()
        {
            AllRecord();
            Console.WriteLine();
            var rootFolder = "FinTech Group";
            Console.WriteLine("Wpisz nazwę rekordu, który chcesz usunąć:");
            var authorsFileRead = Console.ReadLine();
            var authorsFile = $"{authorsFileRead}.txt";
            if (File.Exists(Path.Combine(rootFolder, authorsFile)))
            {
                Console.Clear();
                File.Delete(Path.Combine(rootFolder, authorsFile));
                Console.WriteLine("\nRekord usunięty.\n");
                Menu.CallAlternativeMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wpis o tym numer nie istnieje.\n");
                DeleteRecord();
            }
        }
        public static void ReadRecordFile()
        {
            AllRecord();
            Console.WriteLine("\nPodaj nazwę rekordu, którego dane mają zostać wypisane:");
            var fileName = Console.ReadLine();
            Console.Clear();
            var recordName = $"FinTech Group/{fileName}.txt";
            string[] fileData = File.ReadAllLines(recordName);

            var startPrice = new List<double>();
            var endPrice = new List<double>();
            var dateOfCreation = new List<DateTime>();

            for (int i = 0; i < fileData.Length; i++)
            {
                string[] rowData = fileData[i].Split(';');

                double start = Convert.ToDouble(rowData[0]);
                double end = Convert.ToDouble(rowData[1]);
                DateTime date = Convert.ToDateTime(rowData[2]);

                startPrice.Add(start);
                endPrice.Add(end);
                dateOfCreation.Add(date);

                Console.WriteLine($"Wpis nr: {i+1}");
                Console.WriteLine("Kurs otwarcia: " + startPrice[i]);
                Console.WriteLine("Kurs zamknięcia: " + endPrice[i]);
                Console.WriteLine("Data kursu: " + dateOfCreation[i].ToString("dd/MM/yyyy"));
                Console.WriteLine();
            }           
            Menu.CallAlternativeMenu();
        }
        public static void EditRecord()
        {
            AllRecord();
            Console.WriteLine();
            //pobieranie rekordu od uzytkownika
            Console.WriteLine("Podaj nazwę rekordu, który chcesz zaktualizować:");
            var recordName = Console.ReadLine();
            
            var fileName = $"FinTech Group/{recordName}.txt";

            if (File.Exists(fileName))
            {
                Console.Clear();
                Console.WriteLine("Podaj kurs owarcia:");
                var startPrice = Console.ReadLine();
                

                Console.WriteLine("Podaj kurs zamknięcia:");
                var endPrice = Console.ReadLine();
                

                File.GetLastWriteTime(fileName);

                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{startPrice};{endPrice};{DateTime.Now.ToString("dd/MM/yyyy")}");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nie istnieje rekord o podanej nazwie.");

                Menu.CallAlternativeMenu();
            }
            Menu.CallAlternativeMenu();
        }

        public static void AllRecord()
        {
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
        }
      
        public static void WhichRecord(string filename)
        {
            Console.WriteLine($"Wpis nazwe rekordu:");
            var recordname = Console.ReadLine();
            _ = $"{recordname}.txt";
        }
    }
}