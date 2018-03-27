﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Caching;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace IQiYiCrawler.Controllers
{
    [EnableCors("any")]
    public class PlayListController : Controller
    {

        private readonly IMemoryCache _memoryCache;
        private const string PALYLIST_CACHE = "PlayListCache";
        public PlayListController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IEnumerable<PlayViewModel> Get(string url, string checkedIndex = "0")
        {
            return _memoryCache.Get(PALYLIST_CACHE, () =>
             {
                 url = url.Replace("http://jx.vgoodapi.com/jx.php?url=", "");
                 return PlayListSearch.Crawler(url, checkedIndex);
             });

        }
    }
}