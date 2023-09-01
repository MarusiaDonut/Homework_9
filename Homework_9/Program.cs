using System;

namespace ImageDownloaderApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string remoteUri = "https://oir.mobi/uploads/posts/2021-06/1623942416_31-oir_mobi-p-neveroyatno-krasivie-peizazhi-priroda-kras-33.jpg";
            string fileName = "bigimage.jpg";

            var imageDownloader = new ImageDownloader();

            imageDownloader.DownloadStarted += () => Console.WriteLine("Скачиваие началось");
            imageDownloader.DownloadCompleted += () => Console.WriteLine("Скачивание закончилось");

            imageDownloader.DownloadImageAsync(remoteUri, fileName);

            Console.WriteLine("Введите символ 'A' для выхода из программы или любой другой символ для просмотра статуса скачивания.");
            while (true)
            {

                var key = Console.ReadLine();

                if (key == "A" || key == "a")
                {
                    Environment.Exit(0);
                }
                else
                {
                    if (!imageDownloader.IsCompleted())
                    {
                        Console.WriteLine("Статус - картинка не скачана!");
                    }
                    else
                    {
                        Console.WriteLine("Статус - картинка скачана!");
                        break;
                    }
                }
            }
        }
    }
}