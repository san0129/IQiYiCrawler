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
        //[HttpGet]
        //public IEnumerable<MovieViewModel> Get(int page=1,string pindao="1", string region = "", string type = "",string guige="",string year="")
        //{
        //    return MoviesSearch.Crawler($"http://list.iqiyi.com/www/{pindao}/{region}-{type}-----{guige}-----{year}--11-{page}-1-iqiyi--.html");
        //}
        [HttpGet]
        public IEnumerable<MovieViewModel> Get(int page = 1, string classify = "/www/1/-------------11-{0}-1-iqiyi--.html")
        {
            if (string.IsNullOrEmpty(classify))
            {
                classify = "/www/1/-------------11-{0}-1-iqiyi--.html";
            }
            //11-2-1-iqiyi--
            if (!string.IsNullOrEmpty(classify) && classify != "/www/1/-------------11-{0}-1-iqiyi--.html")
            {
                int index = classify.IndexOf("-1-iqiyi");

                if (index > 0)
                {
                    classify = classify.Remove(index - 1, 1);
                    classify = classify.Insert(index - 1, "{0}");
                }
                else
                {
                    index = classify.IndexOf("iqiyi");
                    //classify = classify.Remove(index - 3, 1);
                    classify = classify.Insert(index - 2, "1");
                    classify = classify.Insert(index - 3, "{0}");
                    classify = classify.Insert(index - 4, "11");
                }


            }
            classify = string.Format(classify, page);
            return MoviesSearch.Crawler($"http://list.iqiyi.com{classify}");
        }
    }
}