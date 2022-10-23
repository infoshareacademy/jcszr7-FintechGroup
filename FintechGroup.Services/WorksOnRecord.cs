using System.Reflection;

namespace FintechGroup.Services
{
    public class WorksOnRecord
    {
        private static string filename;

        public static void AddRecordName()
        {

            Console.WriteLine($"Wpis nazwe rekordu:");
            var recordname = Console.ReadLine();
            var filename = $"{recordname}.txt";
            var fileExists = File.Exists(filename);
            if (fileExists == false)
            {
                using (var writer = File.CreateText(filename)) ;
            }
            fileExists = File.Exists(filename);

            Console.WriteLine($"Database stworzona: {File.GetCreationTimeUtc(filename)}");
        }
        public static void DeleteRecord()
        {
            AllRecord();
            var rootFolder = Directory.GetCurrentDirectory();
            Console.WriteLine("Wpisy nazwe rekordu do usuniencia: ");
            var authorsFileRead = Console.ReadLine();
            var authorsFile = $"{authorsFileRead}.txt";
            try
            {
                if (File.Exists(Path.Combine(rootFolder, authorsFile)))
                {
                    File.Delete(Path.Combine(rootFolder, authorsFile));
                    Console.WriteLine("\nRecord usunienty\n");
                }
                else Console.WriteLine("\nRecord nie znalezony\n");
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }

            Menu.DisplayMainMenu();
        }
        public static void ReadRecordFile()
        {
            AllRecord();
            //WhichRecord(filename);
            Console.WriteLine($"Wpis nazwe rekordu:");
            var recordname = Console.ReadLine();
            var fileName = $"{recordname}.txt";
            Console.WriteLine($"Wypis zaznamu {fileName} :\n");
            using (var reader = File.OpenText(fileName))
            {
                while (reader.EndOfStream == false)
                {
                    Console.WriteLine(reader.ReadLine());
                    // brak przekstalcenia do listy i wypisanie ladnie tabulatory
                }
            }
        }

        public static void AllRecord()
        {
            //string root = new FileInfo(Assembly.GetExecutingAssembly().Location).FullName;
            var root = Directory.GetCurrentDirectory();
            string[] dirs = Directory.GetFiles(root, "*.txt");
            Console.WriteLine("zaznamy: {0}.", dirs.Length);
            foreach (string dir in dirs)
            {
                // do poprawy wypisiwanie tylko nazw pliku bez stiezki a .txt
                Console.WriteLine(dir);
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
