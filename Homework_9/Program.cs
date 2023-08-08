using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Homework_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImageDownloader imageDownloader = new ImageDownloader();
            Handler_Started started = new Handler_Started();
            Handler_Completed completed = new Handler_Completed();

            imageDownloader.ImageStarted += started.Message;
            imageDownloader.ImageCompleted += completed.Message;

            var isCompleted = imageDownloader.Download();
            Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
            var text = Console.ReadLine();
            if (text == "A")
            {
                Environment.Exit(0);
            }
            else if (isCompleted == true)
            {
                Console.WriteLine("Картинка загружена");
            }
            else if (isCompleted == false)
            {
                Console.WriteLine("Картинка не загружена");
            }

        }
    }
}