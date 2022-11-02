namespace FintechGroup.Database

{
    public static class AddFolder
    {   
        public static void AddFolders()
        {

            var directoryName = "FinTech Group";
            var directoryExist = Directory.Exists(directoryName);
            var currentDirectory = Directory.GetCurrentDirectory();
            if(directoryExist == false)
            {
                Directory.CreateDirectory(directoryName);
            }
            //Console.WriteLine($"Databaze wytworzena: {Directory.GetCreationTimeUtc(directoryName)}");
        }

    }
}
