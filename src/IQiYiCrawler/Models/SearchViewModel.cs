using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQiYiCrawler.Models
{
    public class SearchViewModel
    {
        public SearchType SearchType { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
    public enum SearchType
    {
        电视剧 = 0,
        电影 =1,
        综艺=2,
        动漫=3
    }
}
