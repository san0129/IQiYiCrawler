using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Models;
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
        public IEnumerable<MovieViewModel> Get(int page=1)
        {
            return MoviesSearch.Crawler("http://list.iqiyi.com/");
        }
    }
}