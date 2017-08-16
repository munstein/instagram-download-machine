using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace InstagramDownloadMachineLib
{
    public class InstagramDownloadMachine
    {
        private String fileExtension, fileKey;

        private const String imgExtension = ".jpg";
        private const String videoExtension = ".mp4";

        private const String videoKey = "video_url\": \"";
        private const String imgKey = "display_url\": \"";

        /// <summary>
        /// Returns the file's stream from the specified Instagram URL.
        /// </summary>
        /// <param name="url">Instagram url to a image or video.</param>
        /// <returns>File's Stream.</returns>
        public async Task<Stream> Download(String url)
        {
            WebRequest request = WebRequest.Create(url);
            var response = await request.GetResponseAsync();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string fileUrl = GetFileUrl(responseFromServer);
            var fileStream = GetFileStream(fileUrl);
            return fileStream;
        }

        /// <summary>
        /// Downloads the video or image from Instagram to the specified path.
        /// </summary>
        /// <param name="url">Instagram url to a image or video.</param>
        /// <param name="path">Path to download the video or image.</param>
        public async Task DownloadToPath(String url, String path)
        {
            var stream = await Download(url);
            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            File.WriteAllBytes(path, memoryStream.ToArray());
        }

        private Stream GetFileStream(String url)
        {
            HttpWebRequest fileRequest = (HttpWebRequest)WebRequest.Create(url);
            var response = fileRequest.GetResponse();
            return response.GetResponseStream();
        }

        private String GetFileUrl(String html)
        {
            String fileUrl = null;

            if (html.Contains("video_url"))
            {
                fileExtension = videoExtension;
                fileKey = videoKey;
            }
            else
            {
                fileExtension = imgExtension;
                fileKey = imgKey;
            }

            var auxIndex = html.IndexOf(fileKey);
            var partial = html.Substring(auxIndex);
            var endOfUrl = partial.IndexOf(fileExtension) + fileExtension.Length;
            fileUrl = html.Substring(auxIndex, endOfUrl);
            fileUrl = fileUrl.Substring(fileKey.Length);
            return fileUrl;
        }

    }
}
