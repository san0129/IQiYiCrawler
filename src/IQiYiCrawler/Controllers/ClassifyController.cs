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
    [EnableCors("AllowSameDomain")]
    [Produces("application/json")]
    [Route("api/Classify")]
    public class ClassifyController : Controller
    {
        [HttpGet]
        public IEnumerable<ClassifyViewModel> Get(string classify)
        {
            return ClassifySearch.Crawler("http://list.iqiyi.com"+ classify);
        }
    }
}