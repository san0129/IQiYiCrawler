using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IQiYiCrawler.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IQiYiCrawler.Controllers
{
    [Route("api/[controller]")]
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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
