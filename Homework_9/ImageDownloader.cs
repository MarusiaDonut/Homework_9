using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{
    internal class ImageDownloader
    {
        public delegate void ImageDownload();

        public event ImageDownload ImageStarted;
        public event ImageDownload ImageCompleted;

        public bool Download()
        {
            string remoteUri = "https://oir.mobi/uploads/posts/2021-06/1623942416_31-oir_mobi-p-neveroyatno-krasivie-peizazhi-priroda-kras-33.jpg";
            string fileName = "bigimage.jpg";


            var myWebClient = new WebClient();
            ImageStarted();
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
            var task = myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            ImageCompleted();
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
            return task.IsCompleted;
        }
    }

    class Handler_Started
    {
        public void Message()
        {
            Console.WriteLine("Скачивание файла началось");
        }
    }

    class Handler_Completed
    {
        public void Message()
        {
            Console.WriteLine("Скачивание файла закончилось");
        }
    }

}
