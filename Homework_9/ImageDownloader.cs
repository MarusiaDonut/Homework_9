using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Homework_9
{
    internal class ImageDownloader
    {
        public delegate void ImageDownload();

        public event ImageDownload? ImageStarted;
        public event ImageDownload? ImageCompleted;


        public bool IsDownloadComplited()
        {
            string remoteUri = "https://oir.mobi/uploads/posts/2021-06/1623942416_31-oir_mobi-p-neveroyatno-krasivie-peizazhi-priroda-kras-33.jpg";
            string fileName = "bigimage.jpg";
 
            var myWebClient = new WebClient();
            ImageStarted?.Invoke();
            Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUri);
            var task = myWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            ImageCompleted?.Invoke();
            Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUri);
            return task.IsCompleted;
        }
    }

}
