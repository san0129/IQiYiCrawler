using HtmlAgilityPack;
using IQiYiCrawler.Models;
using IQiYiCrawler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQiYiCrawler
{
    public class PlayListSearch
    {
        private static Logger logger = new Logger(typeof(MoviesSearch));
        public static List<PlayViewModel> Crawler(string url,string checkedIndex)
        {
            List<PlayViewModel> playList = new List<PlayViewModel>();
            try
            {
                string html = HttpHelper.DownloadPalyList(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string fristPath =  GetFristPath(checkedIndex);
                HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(fristPath);
                var nodeInfo = nodeList.FirstOrDefault();
                string playListUrl = nodeInfo.Attributes["href"].Value;
                //抓取集数
                string playListHtml = HttpHelper.DownloadPalyList(playListUrl);
                doc.LoadHtml(playListHtml);
                //data-series-elem="cont"
                string listPath = "//div[@data-series-elem='cont']/div/ul/li/a";
                HtmlNodeCollection nodePlayList = doc.DocumentNode.SelectNodes(listPath);
                for (int i = 1; i <= nodePlayList.Count; i++)
                {
                    playList.Add(new PlayViewModel { Number = i, Url = $"http://jx.vgoodapi.com/jx.php?url={ nodePlayList[i].Attributes["href"].Value}" });
                }

            }
            catch (Exception ex)
            {
                logger.Error("CrawlerMuti出现异常", ex);
            }
            return playList;
        }

        private static string GetFristPath(string checkedIndex)
        {
            string path = "";
            switch (checkedIndex)
            {
                case "0":
                    path = "//div[@class='info-intro']/h1/a";break;
                case "3":
                    path = "//*[@id='block-D']/div/div/div[2]/div/div[8]/a"; break;
            }
            return path;
        }
    }
}
