using HtmlAgilityPack;
using IQiYiCrawler.Models;
using IQiYiCrawler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQiYiCrawler
{
    public class QuerySearch
    {
        private static Logger logger = new Logger(typeof(MoviesSearch));
        public static List<SearchViewModel> Crawler(string url)
        {
            List<SearchViewModel> searchList = new List<SearchViewModel>();
            try
            {
                string html = HttpHelper.Download(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string fristPath = "//div[@class='search_result_main']/div/div[2]/div/ul/li";
                HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(fristPath);
                if (nodeList.Count > 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        searchList.Add(GetSearch(nodeList[i]));
                    }
                }
                else
                {

                    foreach (HtmlNode node in nodeList)
                    {
                        searchList.Add(GetSearch(node));
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error("CrawlerMuti出现异常", ex);
            }
            return searchList;
        }

        private static SearchViewModel GetSearch(HtmlNode node)
        {
            var search = new SearchViewModel();
            var nodeInfo = node.ChildNodes.Where(x => x.Name == "a").FirstOrDefault();
            var nodeImage = nodeInfo.ChildNodes.Where(x => x.Name == "img").FirstOrDefault();
            switch (node.Attributes["data-widget-searchlist-catageory"].Value)
            {
                case "电影": search.SearchType = SearchType.电影; break;
                case "电视剧": search.SearchType = SearchType.电视剧; break;
                case "综艺": search.SearchType = SearchType.综艺; break;
                case "动漫": search.SearchType = SearchType.动漫; break;
            }
            search.ImageUrl = nodeImage.Attributes["src"].Value;
            search.Title = nodeImage.Attributes["title"].Value;
            search.Url = $"http://jx.vgoodapi.com/jx.php?url={ nodeInfo.Attributes["href"].Value}";

            return search;
        }
    }
}
