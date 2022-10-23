using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FintechGroup.Services
{
    public class AddRecord
    {
        public static void addrecordname()
        {
            Console.WriteLine($"Wpis nazwe rekordu:");
            var recordname = Console.ReadLine();
            AddRecordFile(recordname);
        }

        public static void AddRecordFile(string recordname)
        {
            var filename = $"{recordname}.txt";
            var fileExists = File.Exists(filename);
            if (fileExists == false)
            {
                using (var writer = File.CreateText(filename)) ;
            }
            fileExists = File.Exists(filename);

            Console.WriteLine($"Database stworzona: {File.GetCreationTimeUtc(filename)}");
        }
        
    }
}
