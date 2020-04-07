using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace StockXPhotoParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Название папки: ");
            string DirectoryName = Console.ReadLine();
            if (!Directory.Exists("./" + DirectoryName))
            {
                Directory.CreateDirectory("./" + DirectoryName);
                Console.WriteLine("Папка создана.");
            }
            Console.Write("\nСсылка на первую фотку: ");
            string url = Console.ReadLine() + Environment.NewLine;
            WebClient web = new WebClient();
            try
            {
                for (int i = 1; i <= 36; i++)
                {
                    string num = Convert.ToString(i);
                    string img = $"img{(int.Parse(num) < 10 ? "0" + num : num)}.jpg";
                    web.DownloadFile(url.Replace("img01.jpg", img), $"./{DirectoryName}/img{i}.jpg");
                    Console.WriteLine("Скачивание фотографии #" + i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\n" + e);
            }
            Console.Read();
        }
    }
}
