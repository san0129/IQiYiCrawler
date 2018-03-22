using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IQiYiCrawler.Controllers
{
    [EnableCors("any")]
    public class PlayListController : Controller
    {
        public IEnumerable<PlayViewModel> Get(string url,string checkedIndex="3")
        {
            url = url.Replace("http://jx.vgoodapi.com/jx.php?url=", "");
            return PlayListSearch.Crawler(url,checkedIndex);
        }
    }
}