using System;
using HtmlAgilityPack;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string url = "https://www.whu.edu.cn/";

        // 创建一个WebClient对象来下载网页内容
        using (WebClient client = new WebClient())
        {
            string html = client.DownloadString(url);

            // 使用HtmlAgilityPack来解析HTML内容
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var links = doc.DocumentNode.SelectNodes("//a[@href]");
            if (links != null)
            {
                foreach (var link in links)
                {
                    Console.WriteLine(link.Attributes["href"].Value);
                }
            }
        }
    }
}