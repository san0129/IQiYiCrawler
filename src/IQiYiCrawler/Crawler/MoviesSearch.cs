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
            List<MovieViewModel> movies = new List<MovieViewModel>();
            try
            {
                string html = HttpHelper.Download(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string fristPath = "//div[@class='wrapper-piclist']/ul/li";
                HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(fristPath);
                foreach (HtmlNode node in nodeList)
                {
                    movies.Add(GetPalyList(node.InnerHtml));
                }
            }
            catch (Exception ex)
            {
                logger.Error("CrawlerMuti出现异常", ex);
            }
            return movies;
        }
        private static MovieViewModel GetPalyList(string innerHtml)
        {
            string imagePath = "div[@class='site-piclist_pic']/a/img";
            string urlPath = "div[@class='site-piclist_pic']/a";
            string rolePath = "div[@class='site-piclist_info']";
            string scorePath = "div[@class='site-piclist_info']/div/span/strong";
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(innerHtml);
            HtmlNodeCollection imgNodeList = doc.DocumentNode.SelectNodes(imagePath);
            HtmlNodeCollection urlNodeList = doc.DocumentNode.SelectNodes(urlPath);
            HtmlNodeCollection roleNodeList = doc.DocumentNode.SelectNodes(rolePath);
            HtmlNodeCollection scoreNodeList = doc.DocumentNode.SelectNodes(scorePath);
            HtmlNode imgNode = imgNodeList.FirstOrDefault();
            HtmlNode urlNode = urlNodeList.FirstOrDefault();
            HtmlNode roleNode = roleNodeList.FirstOrDefault();    
            MovieViewModel movie = new MovieViewModel();
            movie.Url = $"http://jx.vgoodapi.com/jx.php?url={urlNode.Attributes["href"].Value}";
            movie.Title = urlNode.Attributes["title"].Value;
            movie.Id = urlNode.Attributes["data-qipuid"].Value;
            movie.ImageUrl = imgNode.Attributes["src"].Value;
            if (scoreNodeList != null)
            {
                HtmlNode scoreNode = scoreNodeList.FirstOrDefault();
                movie.Score = scoreNode.InnerText;//评分
            }
            {
                var infoStr = roleNode.InnerText.Replace(" ", "").Replace("\r\n", ",");
                infoStr = ProcessRepetition(infoStr).Trim(',');
                var infos = infoStr.Split(",");

                if (infos.Length > 2)
                {
                    string newInfo = "";
                    for (int i = 2; i < infos.Length; i++)
                    {
                        newInfo += string.Join("", infos[i]);
                    }
                    movie.Role = newInfo.Replace(",", " ");
                }
            }

            return movie;
        }

        private static string ProcessRepetition(string oldStr)
        {
            string newStr = "";
            char oldChar = '_';
            for (int i = 0; i < oldStr.Length; i++)
            {
                if (oldChar != oldStr[i])
                {
                    oldChar = oldStr[i];
                    newStr += oldStr[i];
                }
            }
            return newStr;
        }

    }
}
