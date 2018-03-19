using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQiYiCrawler.Models
{
    public class ClassifyViewModel
    {
        public ClassifyViewModel()
        {
            keyValues = new Dictionary<string, string>();
        }
        public string ClassifyName { get; set; }
        public Dictionary<string, string> keyValues;
    }
}
