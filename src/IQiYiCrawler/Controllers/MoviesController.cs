using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Caching;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace IQiYiCrawler.Controllers
{
    [EnableCors("any")]
    public class MoviesController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        /// <summary>
        /// 0:classify
        /// 1:page
        /// </summary>
        private const string MOVIES_CACHE = "MoviesCache_{0}_{1}";
        public MoviesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IEnumerable<MovieViewModel> Get(int page = 1, string classify = "/www/1/-------------11-{0}-1-iqiyi--.html")
        {
            return _memoryCache.Get(string.Format(MOVIES_CACHE, classify, page), () =>
              {
                  if (string.IsNullOrEmpty(classify))
                  {
                      classify = "/www/1/-------------11-{0}-1-iqiyi--.html";
                  }
                  //11-2-1-iqiyi--
                  if (!string.IsNullOrEmpty(classify) && classify != "/www/1/-------------11-{0}-1-iqiyi--.html")
                  {
                      int index = classify.IndexOf("-1-iqiyi");

                      if (index > 0)
                      {
                          classify = classify.Remove(index - 1, 1);
                          classify = classify.Insert(index - 1, "{0}");
                      }
                      else
                      {
                          index = classify.IndexOf("iqiyi");
                          classify = classify.Insert(index - 2, "1");
                          classify = classify.Insert(index - 3, "{0}");
                          classify = classify.Insert(index - 4, "11");
                      }
                  }
                  classify = string.Format(classify, page);
                  if (classify.Contains("http"))
                  {
                      return MoviesSearch.Crawler(classify);
                  }
                  else
                  {
                      return MoviesSearch.Crawler($"http://list.iqiyi.com{classify}");
                  }

              });
        }
    }
}