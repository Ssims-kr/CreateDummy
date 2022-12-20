namespace CreateDummy {
    class Program {
        static void Main(string[] args)
        {
            System.Console.WriteLine("----------");
            System.Console.WriteLine("Create Dummy File");
            System.Console.WriteLine("----------");
            System.Console.WriteLine("Your list of drives. Please select a drive number.");
            var drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++) {
                System.Console.WriteLine("[{0}] : {1}", i, drives[i].Name);
            }
            System.Console.WriteLine("----------"); 
            System.Console.Write("Input : ");
            var input = System.Console.ReadLine();

            var drv = new DriveInfo(drives[Convert.ToInt32(input)].Name);
            var FilePath = string.Format(@"{0}Dummy\Dummy.dat", drives[Convert.ToInt32(input)]);

            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            using (var fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                fs.SetLength(drv.TotalFreeSpace);
            }
        }
    }
}
