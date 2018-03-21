using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Caching;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IQiYiCrawler.Controllers
{
    [EnableCors("any")]
    public class ClassifyController : Controller
    {
        private readonly ICacheManager _cacheManager;
        private const string CLASSIFY_CACHE = "ClassifyCache";
        public ClassifyController(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        [HttpGet]
        public IEnumerable<ClassifyViewModel> Get(string classify)
        {
            return _cacheManager.Get(CLASSIFY_CACHE, () =>
            {
                return ClassifySearch.Crawler("http://list.iqiyi.com" + classify);
            });

        }
    }
}