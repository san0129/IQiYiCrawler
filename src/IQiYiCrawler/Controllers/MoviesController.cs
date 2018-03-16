using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace IQiYiCrawler.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<MovieViewModel> Get(int page=1, string region = "", string type = "",string guige="",string year="")
        {
            return MoviesSearch.Crawler($"http://list.iqiyi.com/www/1/{region}-{type}-----{guige}-----{year}--11-{page}-1-iqiyi--.html");
        }
    }
}