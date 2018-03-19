using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IQiYiCrawler.Controllers
{
    [Produces("application/json")]
    [Route("api/Classify")]
    public class ClassifyController : Controller
    {
        public IEnumerable<ClassifyViewModel> Get(string classify)
        {
            return ClassifySearch.Crawler("http://list.iqiyi.com"+ classify);
        }
    }
}