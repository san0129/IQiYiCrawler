using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IQiYiCrawler.Controllers
{
    [EnableCors("any")]
    public class SearchController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<SearchViewModel> Get(string query)
        {
            //http://so.iqiyi.com/so/q_你的名字
            string queryStr = $"http://so.iqiyi.com/so/q_{query}";
            return QuerySearch.Crawler(queryStr);
        }
    }
}
