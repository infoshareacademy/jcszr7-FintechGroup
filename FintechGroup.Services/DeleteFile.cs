using static System.Net.Mime.MediaTypeNames;

namespace FintechGroup.Database
{
    public class DeleteFile
    {
       static readonly string rootFolder = Directory.GetCurrentDirectory();

        public static void DeleteRecord()
        {
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
    }
}
