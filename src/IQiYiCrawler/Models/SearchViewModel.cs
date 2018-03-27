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
        电影,
        电视剧,
        综艺,
        动漫
    }
}
