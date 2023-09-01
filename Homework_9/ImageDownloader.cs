using System;
using System.Net;
using System.Threading.Tasks;

namespace ImageDownloaderApp
{
    public class ImageDownloader
    {
        public event Action? DownloadStarted;
        public event Action? DownloadCompleted;

        public bool isCompleted;


        public async Task<bool> DownloadImageAsync(string remoteUri, string fileName)
        {
            using var myWebClient = new WebClient();

            try
            {
                DownloadStarted?.Invoke();
                Console.WriteLine($"Скачивание файла: \"{fileName}\" из ресурса \"{remoteUri}\"...");

               await myWebClient.DownloadFileTaskAsync(remoteUri, fileName);

                DownloadCompleted?.Invoke();
                Console.WriteLine($"Скачивание файла закончилось \"{fileName}\" из ресурса \"{remoteUri}\"");

                isCompleted = true;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return false;
            }
        }

        public bool IsCompleted()
        {
            return isCompleted;
        }
    }
}
