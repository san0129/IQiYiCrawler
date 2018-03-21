using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQiYiCrawler.Caching
{
    public class CacheSet
    {
        public Dictionary<object,object> Cache { get; set; }
        public CacheSet()
        {
            Cache = new Dictionary<object, object>();
        }
    }
}
