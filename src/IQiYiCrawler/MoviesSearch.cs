using HtmlAgilityPack;
using IQiYiCrawler.Models;
using IQiYiCrawler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQiYiCrawler
{
    /// <summary>
    /// 
    /// </summary>
    public class MoviesSearch
    {
        private static Logger logger = new Logger(typeof(MoviesSearch));
        public static List<MovieViewModel> Crawler(string url)
        {
            List<MovieViewModel> palyLists = new List<MovieViewModel>();
            try
            {
                string html = HttpHelper.DownloadPalyList(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string fristPath = "//div[@class='wrapper-piclist']/ul/li";
                HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(fristPath);
                foreach (HtmlNode node in nodeList)
                {
                    palyLists.Add(GetPalyList(node.InnerHtml));
                }
            }
            catch (Exception ex)
            {
                logger.Error("CrawlerMuti出现异常", ex);
            }
            return palyLists;
        }
        private static MovieViewModel GetPalyList(string innerHtml)
        {
            string imagePath = "div[@class='site-piclist_pic']/a/img";
            string urlPath = "div[@class='site-piclist_pic']/a";
            string rolePath = "div[@class='site-piclist_info']";
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(innerHtml);
            HtmlNodeCollection imgNodeList = doc.DocumentNode.SelectNodes(imagePath);
            HtmlNodeCollection urlNodeList = doc.DocumentNode.SelectNodes(urlPath);
            HtmlNodeCollection roleNodeList = doc.DocumentNode.SelectNodes(rolePath);
            HtmlNode imgNode = imgNodeList.FirstOrDefault();
            HtmlNode urlNode = urlNodeList.FirstOrDefault();
            HtmlNode roleNode = roleNodeList.FirstOrDefault();
            MovieViewModel palyList = new MovieViewModel();
            palyList.Url = $"http://jx.vgoodapi.com/jx.php?url={urlNode.Attributes["href"].Value}";
            palyList.Title = urlNode.Attributes["title"].Value;
            palyList.Id = urlNode.Attributes["data-qipuid"].Value;
            palyList.ImageUrl = imgNode.Attributes["src"].Value;
            var infostr = roleNode.InnerText.Replace(" ", "").Replace("\r\n", ",");

            return palyList;
        }

    }
}
