# InstagramDownloadMachine - C# Instagram video and image downloader
This library contains two straightforward methods:

1) `Download(string url)`- that returns a Stream from the downloaded file.

Usage: `var stream = instagramDownloadMachine.Download(yourUrl);`

2) `DownloadToPath(string url, string path)` - that downloads the file to the specified path and file name included.

Usage: `instagramDownloadMachine.Download(yourUrl, yourPathName);`
