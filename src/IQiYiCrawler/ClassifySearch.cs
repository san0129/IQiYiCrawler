using HtmlAgilityPack;
using IQiYiCrawler.Models;
using IQiYiCrawler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQiYiCrawler
{
    public class ClassifySearch
    {
        private static Logger logger = new Logger(typeof(MoviesSearch));
        public static List<ClassifyViewModel> Crawler(string url)
        {
            List<ClassifyViewModel> classifyList = new List<ClassifyViewModel>();
            try
            {
                string html = HttpHelper.DownloadPalyList(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string fristPath = "//div[@class='mod_sear_menu mt20 mb30']/div";
                HtmlNodeCollection nodeList = doc.DocumentNode.SelectNodes(fristPath);
                foreach (HtmlNode node in nodeList)

                {
                    classifyList.Add(GetClassify(node.InnerHtml));
                }
            }
            catch (Exception ex)
            {
                logger.Error("CrawlerMuti出现异常", ex);
            }
            return classifyList;
        }

        private static ClassifyViewModel GetClassify(string html)
        {
            var classify = new ClassifyViewModel();
            string classifyNamePath = "//h3";
            string keyValuePath = "ul[@class='mod_category_item']/li/a";
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection typeNameList = doc.DocumentNode.SelectNodes(classifyNamePath);
            HtmlNodeCollection keyValueNodeList = doc.DocumentNode.SelectNodes(keyValuePath);

            HtmlNode classifyNameNode = typeNameList.FirstOrDefault();
            classify.ClassifyName = classifyNameNode.InnerText;
            foreach (var keyValuePar in keyValueNodeList)
            {
                classify.DetailClassify.Add(new DetailClassifyViewModel { Name = keyValuePar.InnerText, Value = keyValuePar.Attributes["href"].Value });
            }
            return classify;
        }
    }
}
