using System.Diagnostics;
using System.Diagnostics.Metrics;
using static Homework_9.ImageDownloader;

namespace Homework_9
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();

            imageDownloader.ImageStarted += () => Console.WriteLine("Скачивание файла началось");
            imageDownloader.ImageCompleted += () => Console.WriteLine("Скачивание файла закончилось");

            bool isCompleted = imageDownloader.IsDownloadComplited();

            Console.WriteLine("\nНажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
           
            var text = Console.ReadLine();
            do
            {
                if (text == "A" || text == "a")
                {
                    Environment.Exit(0);
                }
                else if (imageDownloader.IsDownloadComplited() == true)
                {

                    Console.WriteLine("Картинка загружена");
                    isCompleted = true;
                }
                else if (isCompleted == false)
                {
                    Console.WriteLine("Картинка не загружена");
                }
            }
            while (isCompleted == false);

        }
    }
}