using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramDownloadMachineLib;

namespace InstagramDownloadMachineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Download started");
            Download();
            Console.WriteLine("Downloading...");            
        }

        public static async void Download()
        {
            InstagramDownloadMachine instagramDownloadMachine = new InstagramDownloadMachine();
            await instagramDownloadMachine.DownloadToPath("https://www.instagram.com/p/BXEJU-jDs94", "img.jpg");
            Console.WriteLine("Download ready!");
            Console.ReadLine();
        }
    }
}
