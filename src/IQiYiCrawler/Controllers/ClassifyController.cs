using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using IQiYiCrawler.Caching;

namespace IQiYiCrawler.Controllers
{
    [EnableCors("any")]
    public class ClassifyController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private const string CLASSIFY_CACHE = "ClassifyCache_{0}";
        public ClassifyController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<ClassifyViewModel> Get(string classify)
        {
            return _memoryCache.Get(string.Format(CLASSIFY_CACHE, classify), () =>
            {
                return ClassifySearch.Crawler("http://list.iqiyi.com" + classify);
            });

        }
    }
}