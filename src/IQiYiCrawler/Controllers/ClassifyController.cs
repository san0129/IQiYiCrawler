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
    public class ClassifyController : Controller
    {
        [HttpGet]
        public IEnumerable<ClassifyViewModel> Get(string classify)
        {
            return ClassifySearch.Crawler("http://list.iqiyi.com"+ classify);
        }
    }
}